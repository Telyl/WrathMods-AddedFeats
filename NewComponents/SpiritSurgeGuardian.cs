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
    [TypeId("e022d3524a1542dd8151f93e7e52fa54")]
    public class AddSpiritSurgeGuardian : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleCalculateAbilityParams>,
        IRulebookHandler<RuleCalculateAbilityParams>, IInitiatorRulebookHandler<RuleSavingThrow>,
        IRulebookHandler<RuleSavingThrow>, IInitiatorRulebookHandler<RuleCalculateAC>,
        IRulebookHandler<RuleCalculateAC>,
        ISubscriber,
        IInitiatorRulebookSubscriber
    {

        private static readonly ModLogger Logger = Logging.GetLogger("AddSpiritSurgeGuardian");

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
        private static BlueprintUnitFact _guardianSpirit;
        private static BlueprintUnitFact GuardianSpirit
        {
            get
            {
                _guardianSpirit ??= BlueprintTool.Get<BlueprintUnitFact>(Guids.GuardianSpiritPowers);
                return _guardianSpirit;
            }
        }

        public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
        {
            UnitEntityData caster = evt.Reason.Caster;
            if (caster.Descriptor.HasFact(SpiritSurge) && caster.Descriptor.HasFact(GuardianSpirit))
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

        public void OnEventDidTrigger(RuleCalculateAbilityParams evt) { }
        public void OnEventAboutToTrigger(RuleSavingThrow evt)
        {
            if (evt.StatType != StatType.SaveFortitude || evt.StatType != StatType.SaveReflex) { return; }
            if (SurgeDice == null) { return; }
            evt.AddModifier(bonus: RulebookEvent.Dice.D(SurgeDice.GetValueOrDefault()),
                            descriptor: ModifierDescriptor.UntypedStackable,
                            source: evt.Reason.Caster.Facts.Get(SpiritSurge));
            evt.Reason.Caster.Buffs.GetBuff(BlueprintTool.Get<BlueprintBuff>(Guids.SpiritSurgeBuff)).ReduceDuration(reduce1min);
        }

        public void OnEventDidTrigger(RuleSavingThrow evt) { }

        public void OnEventAboutToTrigger(RuleCalculateAC evt) 
        {
            if (SurgeDice == null) { return; }
            evt.AddModifier(bonus: RulebookEvent.Dice.D(SurgeDice.GetValueOrDefault()),
                            descriptor: ModifierDescriptor.UntypedStackable,
                            source: evt.Reason.Caster.Facts.Get(SpiritSurge));
            evt.Reason.Caster.Buffs.GetBuff(BlueprintTool.Get<BlueprintBuff>(Guids.SpiritSurgeBuff)).ReduceDuration(reduce1min);
        }

        public void OnEventDidTrigger(RuleCalculateAC evt) { }
    }
}

