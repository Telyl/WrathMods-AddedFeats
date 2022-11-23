using AddedFeats.Utils;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddedFeats.NewClasses.MediumFeatures
{
    class MediumProficiencies
    {
        private static readonly string FeatName = "MediumProficiencies";
        internal const string DisplayName = "MediumProficiencies.Name";
        private static readonly string Description = "MediumProficiencies.Description";
        public static void ConfigureDisabled()
        {
            FeatureConfigurator.New(FeatName, Guids.MediumProficiencies).Configure();
        }

        public static BlueprintFeature ConfigureEnabled()
        {
            return FeatureConfigurator.New(FeatName, Guids.MediumProficiencies)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new()
                {
                    FeatureRefs.SimpleWeaponProficiency.Reference.Get(),
                    FeatureRefs.LightArmorProficiency.Reference.Get(),
                    FeatureRefs.MediumArmorProficiency.Reference.Get()
                })
                .SetHideInUI(false)
                .SetHideNotAvailibleInUI(false)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetRanks(1)
                .SetAllowNonContextActions(false)
                .Configure();
        }
    }
}
