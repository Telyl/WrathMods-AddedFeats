using AddedFeats.NewComponents;
using AddedFeats.Utils;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Activatable embedded menu. Investigator class by SIGURD
namespace AddedFeats.NewClasses.MediumFeatures
{
    class SpiritSurge
    {
        private static readonly string FeatName = "SpiritSurge";
        private static readonly string DisplayName = "SpiritSurge.Name";
        private static readonly string Description = "SpiritSurge.Description";
       
        public static void ConfigureDisabled()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.SpiritSurgeBuff).Configure();
            AbilityConfigurator.New(FeatName + "Ability", Guids.SpiritSurgeAbility).Configure();
            FeatureConfigurator.New(FeatName, Guids.SpiritSurge).Configure();
            //FeatureConfigurator.New(FeatName + "Progression", Guids.SpiritSurgeProgression).Configure();
        }

        public static BlueprintFeature ConfigureEnabled()
        {
            var feat = FeatureConfigurator.New(FeatName, Guids.SpiritSurge)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI(false)
                .SetHideNotAvailibleInUI(false)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetRanks(10)
                .SetAllowNonContextActions(false)
                .Configure();

            var buff = BuffConfigurator.New(FeatName + "Buff", Guids.SpiritSurgeBuff)
            .SetIcon(AbilityRefs.BladeBarrier.Reference.Get().Icon)
            .AddComponent<AddSpiritSurgeChampion>()
            .AddContextRankConfig(
                    ContextRankConfigs.FeatureRank(Guids.SpiritSurgeProgression, max: 20, min: 1))
            .Configure();

            var ability = AbilityConfigurator.New(FeatName + "Ability", Guids.SpiritSurgeAbility)
                .SetIcon(AbilityRefs.BladeBarrier.Reference.Get().Icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddAbilityEffectRunAction(
                    actions: ActionsBuilder.New()
                        .ApplyBuff(buff, ContextDuration.Variable(ContextValues.Rank(), rate: DurationRate.Minutes),
                                    asChild: false, isFromSpell: false, isNotDispelable: true))
                .Configure();

            FeatureConfigurator.For(feat)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI(false)
                .SetHideNotAvailibleInUI(false)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetRanks(10)
                .SetAllowNonContextActions(false)
                .AddFacts(new() { ability })
                .AddContextRankConfig(new ContextRankConfig
                {
                    m_Type = AbilityRankType.Default,
                    m_BaseValueType = ContextRankBaseValueType.FeatureRank,
                    m_Feature = feat.ToReference<BlueprintFeatureReference>(),
                    m_Stat = StatType.Unknown,
                    m_Buff = null,
                    m_Progression = ContextRankProgression.AsIs,
                    m_StartLevel = 0,
                    m_StepLevel = 0,
                    m_UseMin = false,
                    m_Min = 0,
                    m_UseMax = false,
                    m_Max = 20,
                    m_ExceptClasses = false,
                    Archetype = null
                })
                .Configure();         

            return feat;
        }
    }
}
