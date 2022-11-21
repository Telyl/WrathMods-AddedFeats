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
    class SpiritPower
    {
        private static readonly string FeatName = "SpiritPower";
        internal const string DisplayName = "SpiritPower.Name";
        private static readonly string Description = "SpiritPower.Description";
        public static void ConfigureDisabled()
        {
            FeatureConfigurator.New(FeatName, Guids.SpiritPowerFeat).Configure();
            FeatureConfigurator.New(FeatName + "Lesser", Guids.SpiritPowerLesser).SetHideInCharacterSheetAndLevelUp().Configure();
            FeatureConfigurator.New(FeatName + "Intermediate", Guids.SpiritPowerIntermediate).SetHideInCharacterSheetAndLevelUp().Configure();
            FeatureConfigurator.New(FeatName + "Greater", Guids.SpiritPowerGreater).SetHideInCharacterSheetAndLevelUp().Configure();
            FeatureConfigurator.New(FeatName + "Supreme", Guids.SpiritPowerSupreme).SetHideInCharacterSheetAndLevelUp().Configure();
        }

        public static BlueprintFeature ConfigureEnabled()
        {
            BlueprintFeature SpiritPowerLesser = FeatureConfigurator.New(FeatName + "Lesser", Guids.SpiritPowerLesser)
                .SetDisplayName("SpiritPowerLesser.Name")
                .SetDescription("SpiritPowerLesser.Description")
                .Configure();
            BlueprintFeature SpiritPowerIntermediate = FeatureConfigurator.New(FeatName + "Intermediate", Guids.SpiritPowerIntermediate)
                .SetDisplayName("SpiritPowerIntermediate.Name")
                .SetDescription("SpiritPowerIntermediate.Description")
                .Configure();
            BlueprintFeature SpiritPowerGreater = FeatureConfigurator.New(FeatName + "Greater", Guids.SpiritPowerGreater)
                .SetDisplayName("SpiritPowerGreater.Name")
                .SetDescription("SpiritPowerGreater.Description")
                .Configure();
            BlueprintFeature SpiritPowerSupreme = FeatureConfigurator.New(FeatName + "Supreme", Guids.SpiritPowerSupreme)
                .SetDisplayName("SpiritPowerSupreme.Name")
                .SetDescription("SpiritPowerSupreme.Description")
                .Configure();
            BlueprintFeature SpiritPower = FeatureConfigurator.New(FeatName, Guids.SpiritPowerFeat)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI(false)
                .SetHideNotAvailibleInUI(false)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(true)
                .AddFeatureOnClassLevel(clazz: BlueprintTool.Get<BlueprintCharacterClass>(Guids.MediumClass), level: 1, feature: SpiritPowerLesser)
                .AddFeatureOnClassLevel(clazz: BlueprintTool.Get<BlueprintCharacterClass>(Guids.MediumClass), level: 6, feature: SpiritPowerIntermediate)
                .AddFeatureOnClassLevel(clazz: BlueprintTool.Get<BlueprintCharacterClass>(Guids.MediumClass), level: 11, feature: SpiritPowerGreater)
                .AddFeatureOnClassLevel(clazz: BlueprintTool.Get<BlueprintCharacterClass>(Guids.MediumClass), level: 17, feature: SpiritPowerSupreme)
                .SetAllowNonContextActions(false)
                .Configure();
            return SpiritPower;
        }
    }
}
