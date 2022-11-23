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
using Kingmaker.RuleSystem.Rules.Damage;

namespace AddedFeats.NewComponents
{
    [AllowedOn(typeof(BlueprintUnitFact))]
    [TypeId("7acc6879834a471aa5b7281b798d3846")]
    public class AddSpiritSurgeChampion : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleCalculateAbilityParams>, IRulebookHandler<RuleCalculateAbilityParams>, 
        IInitiatorRulebookHandler<RuleAttackRoll>,IRulebookHandler<RuleAttackRoll>, 
        IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>,
        IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSavingThrow>,
        IInitiatorRulebookHandler<RuleSkillCheck>, IRulebookHandler<RuleSkillCheck>,
        ISubscriber,
        IInitiatorRulebookSubscriber
    {

        private static readonly ModLogger Logger = Logging.GetLogger("AddSpiritSurgeChampion");
        
        private static DiceFormula? SurgeDice;
        private static TimeSpan reduce1min = new TimeSpan(0, 0, 1, 0, 0);
        private static BlueprintUnitFact _spiritSurge;
        private static BlueprintUnitFact SpiritSurge
        {
            get
            {
                _spiritSurge ??= BlueprintTool.Get<BlueprintUnitFact>(Guids.SpiritSurge);
                return _spiritSurge;
            }
        }
        private static BlueprintUnitFact _championSpirit;
        private static BlueprintUnitFact ChampionSpirit
        {
            get
            {
                _championSpirit ??= BlueprintTool.Get<BlueprintUnitFact>(Guids.ChampionSpiritPowers);
                return _championSpirit;
            }
        }

        public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
        {
            UnitEntityData caster = evt.Reason.Caster;
            if(caster.Descriptor.HasFact(SpiritSurge) && caster.Descriptor.HasFact(ChampionSpirit))
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
        public void OnEventDidTrigger(RuleCalculateAbilityParams evt){ }

        public void OnEventAboutToTrigger(RuleAttackRoll evt) {
            if(SurgeDice == null) { return; }

            evt.AddModifier(bonus: RulebookEvent.Dice.D(SurgeDice.GetValueOrDefault()),
                            descriptor: ModifierDescriptor.UntypedStackable,
                            source: evt.Reason.Caster.Facts.Get(SpiritSurge));
                
            evt.Reason.Caster.Buffs.GetBuff(BlueprintTool.Get<BlueprintBuff>(Guids.SpiritSurgeBuff)).ReduceDuration(reduce1min);
        }

        public void OnEventDidTrigger(RuleAttackRoll evt) {
            if (SurgeDice == null) { return; }
            
            if (evt.IsHit) {
                evt.Reason.Caster.Buffs.GetBuff(BlueprintTool.Get<BlueprintBuff>(Guids.SpiritSurgeBuff)).ReduceDuration(reduce1min);
            }
        }

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt) {
            if (SurgeDice == null) { return; }
            
            evt.AddDamageModifier(bonus: RulebookEvent.Dice.D(SurgeDice.GetValueOrDefault()),
                                  fact: evt.Reason.Caster.Facts.Get(SpiritSurge), 
                                  descriptor: ModifierDescriptor.UntypedStackable);
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt) { }

        public void OnEventAboutToTrigger(RuleSavingThrow evt) {
            if (evt.StatType != StatType.SaveFortitude) { return; }
            if (SurgeDice == null) { return; }
            evt.AddModifier(bonus: RulebookEvent.Dice.D(SurgeDice.GetValueOrDefault()),
                            descriptor: ModifierDescriptor.UntypedStackable,
                            source: evt.Reason.Caster.Facts.Get(SpiritSurge));
            evt.Reason.Caster.Buffs.GetBuff(BlueprintTool.Get<BlueprintBuff>(Guids.SpiritSurgeBuff)).ReduceDuration(reduce1min);
        }

        public void OnEventDidTrigger(RuleSavingThrow evt) { }

        public void OnEventAboutToTrigger(RuleSkillCheck evt) {
            if (evt.StatType != StatType.SkillAthletics) { return; }
            if (SurgeDice == null) { return; }
            evt.Bonus.AddModifier(RulebookEvent.Dice.D(SurgeDice.GetValueOrDefault()),
                            evt.Reason.Caster.Facts.Get(SpiritSurge), ModifierDescriptor.UntypedStackable);
            evt.Reason.Caster.Buffs.GetBuff(BlueprintTool.Get<BlueprintBuff>(Guids.SpiritSurgeBuff)).ReduceDuration(reduce1min);
        }

        public void OnEventDidTrigger(RuleSkillCheck evt) { }
    }
}

