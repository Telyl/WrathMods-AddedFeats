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
    [TypeId("c5fd93e94da6492b866ec4f50f6b7934")]
    public class AddSpiritSurgeHierophant : UnitFactComponentDelegate,
        IInitiatorRulebookHandler<RuleCalculateAbilityParams>,
        IRulebookHandler<RuleCalculateAbilityParams>, IInitiatorRulebookHandler<RuleAttackRoll>,
        IRulebookHandler<RuleAttackRoll>,
        ISubscriber,
        IInitiatorRulebookSubscriber
    {

        private static readonly ModLogger Logger = Logging.GetLogger("AddSpiritSurgeHierophant");
        
        private DiceFormula? SurgeDice;
        private int DiceVal;
        private ModifiableValue.Modifier SpiritSurgeValue; 
        private static BlueprintUnitFact _spiritSurge;
        private static BlueprintUnitFact SpiritSurge
        {
            get
            {
                _spiritSurge ??= BlueprintTool.Get<BlueprintUnitFact>(Guids.SpiritSurge);
                return _spiritSurge;
            }
        }
        private static BlueprintUnitFact _hierophantSpirit;
        private static BlueprintUnitFact HierophantSpirit
        {
            get
            {
                _hierophantSpirit ??= BlueprintTool.Get<BlueprintUnitFact>(Guids.HierophantSpiritPowers);
                return _hierophantSpirit;
            }
        }
        /* We're about to roll our dice! We need to modify this! */
        public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
        {
            UnitEntityData caster = evt.Reason.Caster;
            if(caster.Descriptor.HasFact(SpiritSurge))
            {
                var spiritsurgeranks = caster.Descriptor.Progression.Features.GetRank(BlueprintTool.Get<BlueprintFeature>(Guids.SpiritSurge));
                switch(spiritsurgeranks)
                {
                    case 1: SurgeDice = new DiceFormula(1, DiceType.D6); DiceVal = 6;
                        break;
                    case 2: SurgeDice = new DiceFormula(1, DiceType.D8); DiceVal = 8;
                        break;
                    case 3: SurgeDice = new DiceFormula(1, DiceType.D10); DiceVal = 10;
                        break;
                    case 4: SurgeDice = new DiceFormula(2, DiceType.D8); DiceVal = 16;
                        break;
                    default: SurgeDice = null; DiceVal = 0; break;
                }
                Logger.Log($"Formula: {SurgeDice} DiceMax: {DiceVal}");
            }

        }
        public void OnEventDidTrigger(RuleCalculateAbilityParams evt)
        {
            
        }

        public void OnEventAboutToTrigger(RuleAttackRoll evt)
        {
            // If spirit is champion, blah blah blah.
            UnitEntityData caster = evt.Reason.Caster;
           // if(caster.HasFact(SpiritSurge) & caster.HasFact()
            evt.AddModifier(bonus: RulebookEvent.Dice.D(SurgeDice.GetValueOrDefault()),
                                     descriptor: ModifierDescriptor.Other,
                                     source: evt.Reason.Caster.Facts.Get(SpiritSurge));
            TimeSpan reduce1min = new TimeSpan(0, 0, 1, 0, 0);
            evt.Reason.Caster.Buffs.GetBuff(BlueprintTool.Get<BlueprintBuff>(Guids.SpiritSurgeBuff)).ReduceDuration(reduce1min);
        }

        public void OnEventDidTrigger(RuleAttackRoll evt)
        {

        }

        //[SerializeField]
        //public BlueprintFeatureReference SpiritSurge;
    }
}

