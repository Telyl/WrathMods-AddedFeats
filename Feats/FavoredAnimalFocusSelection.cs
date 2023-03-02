using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using AddedFeats.Feats.AnimalFocus;
using AddedFeats.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using static UnityModManagerNet.UnityModManager.ModEntry;
using System;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;

namespace AddedFeats.Feats
{
    /// <summary>
    /// Creates a feat that does nothing but show up.
    /// </summary>
    public class FavoredAnimalFocusSelection
    {
        private static readonly string FeatName = "FavoredAnimalFocusSelection";
        internal const string DisplayName = "FavoredAnimalFocus.Name";
        private static readonly string Description = "FavoredAnimalFocus.Description";
        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        internal static void Configure()
        {
            try
            {
                if (Settings.IsEnabled(Guids.FavoredAnimalFocusSelection))
                    ConfigureEnabled();
                else
                    ConfigureDisabled();
            }
            catch (Exception e)
            {
                Logger.LogException("FavoredAnimalFocusSelection.Configure", e);
            }
        }

        private static void ConfigureDisabled()
        {
            FeatureSelectionConfigurator.New(FeatName, Guids.FavoredAnimalFocusSelection).Configure();
            FavoredAnimalFocusBull.ConfigureDisabled();
            FavoredAnimalFocusBear.ConfigureDisabled();
            FavoredAnimalFocusTiger.ConfigureDisabled();
            FavoredAnimalFocusFalcon.ConfigureDisabled();
            FavoredAnimalFocusStag.ConfigureDisabled();
            FavoredAnimalFocusMouse.ConfigureDisabled();
            FavoredAnimalFocusOwl.ConfigureDisabled();
            FavoredAnimalFocusMonkey.ConfigureDisabled();
        }

        public static void ConfigureEnabled()
        {
            var focbull = FavoredAnimalFocusBull.Configure();
            var focbear = FavoredAnimalFocusBear.Configure();
            var foctiger = FavoredAnimalFocusTiger.Configure();
            var focfalcon = FavoredAnimalFocusFalcon.Configure();
            var focstag = FavoredAnimalFocusStag.Configure();
            var focmouse = FavoredAnimalFocusMouse.Configure();
            var focowl = FavoredAnimalFocusOwl.Configure();
            var focmonkey = FavoredAnimalFocusMonkey.Configure();

            var selection = FeatureSelectionConfigurator.New(FeatName, Guids.FavoredAnimalFocusSelection)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
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
                .AddToAllFeatures(focbull, focbear, foctiger, focfalcon, focstag, focmouse, focowl, focmonkey)
                .SetHideInUI(true)
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetHideNotAvailibleInUI(false)
                .Configure();

            var basicFeatSelectionGuid = "247a4068-296e-8be4-2890-143f451b4b45";
            FeatureSelectionConfigurator.For(basicFeatSelectionGuid)
                .AddToAllFeatures(selection)
                .Configure();
        }

        public static bool SetGroup(BlueprintFeatureSelection selection, FeatureGroup[] featuregroups)
        {
            try
            {
                FeatureSelectionConfigurator.For(selection)
                .AddToGroups(featuregroups)
                .Configure();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

