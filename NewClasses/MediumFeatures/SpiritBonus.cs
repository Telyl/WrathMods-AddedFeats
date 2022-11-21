using AddedFeats.Utils;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This will be a buff.
namespace AddedFeats.NewClasses.MediumFeatures
{
    class SpiritBonus
    {
        private static readonly string FeatName = "SpiritBonus";
        internal const string DisplayName = "SpiritBonus.Name";
        private static readonly string Description = "SpiritBonus.Description";
        public static void ConfigureDisabled()
        {
            FeatureConfigurator.New(FeatName, Guids.SpiritBonusFeat).Configure();
        }

        public static BlueprintFeature ConfigureEnabled()
        {
            BlueprintFeature SpiritBonus = FeatureConfigurator.New(FeatName, Guids.SpiritBonusFeat)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI(false)
                .SetHideNotAvailibleInUI(false)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetRanks(10)
                .SetAllowNonContextActions(false)
                .Configure();

            FeatureConfigurator.For(Guids.SpiritBonusFeat)
                .AddContextRankConfig(new ContextRankConfig
                {
                    m_Type = AbilityRankType.Default,
                    m_BaseValueType = ContextRankBaseValueType.FeatureRank,
                    m_Feature = SpiritBonus.ToReference<BlueprintFeatureReference>(),
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
            return SpiritBonus;
        }
    }
}
