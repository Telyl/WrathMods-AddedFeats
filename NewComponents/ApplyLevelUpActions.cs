using BlueprintCore.Utils;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.RuleSystem;
using Kingmaker.ResourceLinks;
using Kingmaker;

using System;
using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Controllers;
using Kingmaker.Controllers.Combat;
using Kingmaker.Designers;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Settings;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Blueprints.Facts;
using static UnityModManagerNet.UnityModManager.ModEntry;
using AddedFeats.Utils;
using Kingmaker.UnitLogic.Buffs;
using Newtonsoft.Json;
using Kingmaker.ElementsSystem;
using BlueprintCore.Conditions.Builder;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Class.LevelUp;
using Kingmaker.UnitLogic.Class.LevelUp.Actions;

namespace AddedFeats.NewComponents
{
    [TypeId("cb888ba3cc1f45909e5bae27177c1668")]
    public class ApplyLevelUpActions : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAbilityParams>, IRulebookHandler<RuleCalculateAbilityParams>, ISubscriber, IInitiatorRulebookSubscriber, IResourcesHolder
    {
        private static readonly ModLogger Logger = Logging.GetLogger("ApplyLevelUpActions");
        private static BlueprintUnitFact _championlesser;
        private static BlueprintUnitFact ChampionSpiritPowerLesser
        {
            get
            {
                _championlesser ??= BlueprintTool.Get<BlueprintUnitFact>(Guids.ChampionSpiritPowerLesser);
                return _championlesser;
            }
        }
        public void OnEventDidTrigger(RuleCalculateAbilityParams evt)
        {

        }

        public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
        {
            UnitEntityData caster = evt.Reason.Caster;
            if (caster.Descriptor.HasFact(ChampionSpiritPowerLesser))
            {
                // This is the action we want to occur.
                Logger.Log("I'm here.");
                
                var selectfeature = new Kingmaker.UnitLogic.Class.LevelUp.Actions.SelectFeature();
                // Create a LevelUpController because we're gonna want to "level up".
                caster.CreatePreview(true);
                LevelUpController levelup = new LevelUpController(caster, false, LevelUpState.CharBuildMode.LevelUp);
                levelup.ApplyLevelUpPlan(true);
                levelup.m_HasPlan = true;
                levelup.AddAction(selectfeature, true);
                levelup.EnterApplyingPlanScope();

                Game.Instance.LevelUpController = levelup;
                
                //new Kingmaker.UnitLogic.Class.LevelUp.LevelUpState(caster, LevelUpState.CharBuildMode.LevelUp, false);
            }
        }
    }
}

