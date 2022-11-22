using BlueprintCore.Utils;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.ResourceLinks;
using System;
using Kingmaker.Utility;
using Kingmaker.Enums;
using Kingmaker.Blueprints.Facts;
using static UnityModManagerNet.UnityModManager.ModEntry;
using AddedFeats.Utils;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.Blueprints;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Parts;
using UnityEngine;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace AddedFeats.NewComponents
{
    [AllowedOn(typeof(BlueprintUnitFact))]
    [TypeId("13d948daff964e66ad8b8600d8bd00a1")]
    public class AddSpiritSurgeMarshal : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleCalculateAbilityParams>,
        IRulebookHandler<RuleCalculateAbilityParams>,
        IInitiatorRulebookHandler<RuleSkillCheck>, IRulebookHandler<RuleSkillCheck>,
        ISubscriber,
        IInitiatorRulebookSubscriber
    {

        private static readonly ModLogger Logger = Logging.GetLogger("AddSpiritSurgeMarshal");

        private DiceFormula? SurgeDice;
        private TimeSpan reduce1min = new TimeSpan(0, 0, 1, 0, 0);
        private static BlueprintUnitFact _spiritSurge;
        private static BlueprintUnitFact SpiritSurge
        {
            get
            {
                _spiritSurge ??= BlueprintTool.Get<BlueprintUnitFact>(Guids.SpiritSurge);
                return _spiritSurge;
            }
        }
        private static BlueprintUnitFact _marshalSpirit;
        private static BlueprintUnitFact MarshalSpirit
        {
            get
            {
                _marshalSpirit ??= BlueprintTool.Get<BlueprintUnitFact>(Guids.MarshalSpiritPowers);
                return _marshalSpirit;
            }
        }
        private static BlueprintUnitFact _spiritBonus;
        private static BlueprintUnitFact SpiritBonus
        {
            get
            {
                _spiritBonus ??= BlueprintTool.Get<BlueprintUnitFact>(Guids.SpiritBonusFeat);
                return _spiritBonus;
            }
        }

        /* We're about to roll our dice! We need to modify this! */
        public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
        {
            UnitEntityData caster = evt.Reason.Caster;
            if (caster.Descriptor.HasFact(SpiritSurge) && caster.Descriptor.HasFact(MarshalSpirit))
            {
                var spiritsurgeranks = caster.Descriptor.Progression.Features.GetRank(BlueprintTool.Get<BlueprintFeature>(Guids.SpiritSurge));
                SurgeDice = spiritsurgeranks switch
                {
                    1 => new DiceFormula(1, DiceType.D6),
                    2 => new DiceFormula(1, DiceType.D8),
                    3 => new DiceFormula(1, DiceType.D10),
                    4 => new DiceFormula(2, DiceType.D8),
                    _ => null
                };
            }
        }
        public void OnEventDidTrigger(RuleCalculateAbilityParams evt)
        {

        }

        public void OnEventAboutToTrigger(RuleSkillCheck evt)
        {
            if (evt.StatType != StatType.SkillPersuasion || evt.StatType != StatType.SkillUseMagicDevice) { return; }
            if (SurgeDice == null) { return; }
            var spiritbonus = evt.Reason.Caster.Descriptor.Progression.Features.GetRank(BlueprintTool.Get<BlueprintFeature>(Guids.SpiritBonusFeat));
            evt.AddModifier(bonus: RulebookEvent.Dice.D(SurgeDice.GetValueOrDefault()),
                            descriptor: ModifierDescriptor.UntypedStackable,
                            source: evt.Reason.Caster.Facts.Get(SpiritSurge));
            evt.AddModifier(bonus: spiritbonus,
                            descriptor: ModifierDescriptor.UntypedStackable,
                            source: evt.Reason. Caster.Facts.Get(SpiritBonus));
            evt.Reason.Caster.Buffs.GetBuff(BlueprintTool.Get<BlueprintBuff>(Guids.SpiritSurgeBuff)).ReduceDuration(reduce1min);
        }

        public void OnEventDidTrigger(RuleSkillCheck evt) { }
    }
}

