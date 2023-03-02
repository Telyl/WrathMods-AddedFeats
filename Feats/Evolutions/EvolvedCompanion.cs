using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using AddedFeats.Feats.AnimalFocus;
using AddedFeats.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using static UnityModManagerNet.UnityModManager.ModEntry;
using System;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;

namespace AddedFeats.Feats
{
    /// <summary>
    /// Creates a feat that does nothing but show up.
    /// </summary>
    public class EvolvedCompanion
    {
        private static readonly string FeatName = "EvolvedCompanion";
        internal const string DisplayName = "EvolvedCompanion.Name";
        private static readonly string Description = "EvolvedCompanion.Description";
        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        internal static void Configure()
        {
            try
            {
                if (Settings.IsEnabled(Guids.EvolvedCompanion))
                    ConfigureEnabled();
                else
                    ConfigureDisabled();
            }
            catch (Exception e)
            {
                Logger.LogException("EvolvedCompanion.Configure", e);
            }
        }

        private static void ConfigureDisabled()
        {
            FeatureSelectionConfigurator.New(FeatName, Guids.EvolvedCompanion).Configure();
            ImprovedDamage.ConfigureDisabled();
            Claw.ConfigureDisabled();
            Skilled.ConfigureDisabled();
            EvolutionImprovedNaturalArmor.ConfigureDisabled();
        }

        public static void ConfigureEnabled()
        {
            var idfeat = ImprovedDamage.ConfigureEnabled();
            var clawfeat= Claw.ConfigureEnabled();
            var skilledfeat = Skilled.ConfigureEnabled();
            BlueprintFeature[] EvoImpNaturalArmor = EvolutionImprovedNaturalArmor.ConfigureEnabled();

            var selection = FeatureSelectionConfigurator.New(FeatName, Guids.EvolvedCompanion)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddToAllFeatures(idfeat, clawfeat, skilledfeat, 
                EvoImpNaturalArmor[0], EvoImpNaturalArmor[1], EvoImpNaturalArmor[2], EvoImpNaturalArmor[3], EvoImpNaturalArmor[4])
                .AddPrerequisiteFullStatValue(stat: StatType.Charisma, value: 13)
                .AddPrerequisitePet()
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureBear.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureBoar.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureCentipede.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureDog.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureElk.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureHorse.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureHorse_PreorderBonus.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureLeopard.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureMammoth.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureMonitor.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureSmilodon.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureSmilodon_PreorderBonus.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureTriceratops.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureTriceratops_PreorderBonus.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureVelociraptor.Reference.Get())
                .AddRecommendationHasFeature(FeatureRefs.AnimalCompanionFeatureWolf.Reference.Get())
                .SetHideInUI(true)
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetHideNotAvailibleInUI(false)
                .Configure();

            var basicFeatSelectionGuid = "247a4068-296e-8be4-2890-143f451b4b45";
            FeatureSelectionConfigurator.For(basicFeatSelectionGuid)
                .AddToAllFeatures(selection)
                .Configure();
        }
    }
}

