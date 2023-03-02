using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using BlueprintCore.Utils;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using AddedFeats.Utils;

namespace AddedFeats.Feats.AnimalFocus
{
    /// <summary>
    /// Creates a feat that does nothing but show up.
    /// </summary>
    public class FavoredAnimalFocusMouse
    {
        private static readonly string FeatName = "FavoredAnimalFocusMouse";

        private static readonly string DisplayName = "FavoredMouse.Name";
        private static readonly string Description = "FavoredMouse.Description";

        private static readonly LogWrapper FeatLogger = LogWrapper.Get("FavoredAnimalFocus");

        public static void ConfigureDisabled()
        {
            BasicFunctions.CreateBasicFeat(FeatName + "Pet",
                Guids.FavoredAnimalFocusMousePet, "FavoredMouse.Name", "FavoredMouse.Description");
            BuffConfigurator.New(FeatName + "Buff", Guids.FavoredAnimalFocusMouseBuff).Configure();
            FeatureConfigurator.New(FeatName, Guids.FavoredAnimalFocusMouse).Configure();
        }
        public static BlueprintFeature Configure()
        {
            //Create a pet feature to use as the conditional information for the new buff.
            BlueprintFeature FavoredMouseFocusPetFeat = BasicFunctions.CreateBasicFeat(FeatName + "Pet",
                Guids.FavoredAnimalFocusMousePet, DisplayName, Description);

            //The magical new ability with it's new context and everything
            BlueprintBuff FavoredAnimalMouseBuff = BuffConfigurator.New(FeatName + "Buff", Guids.FavoredAnimalFocusMouseBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.AnimalAspectRacoon.Reference.Get().Icon)
                .AddTemporaryFeat(FeatureRefs.ImprovedUncannyDodge.Reference.Get())
                .AddContextRankConfig(
                    ContextRankConfigs.CharacterLevel()
                    .WithLinearProgression(1,0))
                .Configure();

            //Patch the existing AnimalFocusEffect to get it into our game.
            FeatureConfigurator.For(FeatureRefs.AnimalFocusMouseEffect)
            .AddFactContextActions(
                activated:
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(FavoredMouseFocusPetFeat).IsAnimalCompanion(),
                            ifTrue: ActionsBuilder.New().ApplyBuffPermanent(FavoredAnimalMouseBuff, isNotDispelable: true, asChild: true)),
                deactivated:
                    ActionsBuilder.New().RemoveBuff(FavoredAnimalMouseBuff, removeRank: false, toCaster: false))
            .Configure();

            //The feature we (the player) can select that adds our pet feature.
            return FeatureConfigurator.New(FeatName, Guids.FavoredAnimalFocusMouse)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetReapplyOnLevelUp(true)
                .SetHideInUI(true)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .AddFeatureToPet(FavoredMouseFocusPetFeat)
                .AddPrerequisiteFeature(FeatureRefs.HunterAnimalFocusFeature.Reference.Get())
                .Configure();
        }
    }
}

