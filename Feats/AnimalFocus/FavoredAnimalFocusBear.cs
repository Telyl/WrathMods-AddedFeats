using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.UnitLogic;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
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
    /// Creates the Favored Animal Focus - Bear logic and feature.
    /// </summary>
    public class FavoredAnimalFocusBear
    {
        private static readonly string FeatName = "FavoredAnimalFocusBear";
        private static readonly string DisplayName = "FavoredBear.Name";
        private static readonly string Description = "FavoredBear.Description";

        private static readonly LogWrapper FeatLogger = LogWrapper.Get("FavoredAnimalFocus");

        public static void ConfigureDisabled()
        {
            BasicFunctions.CreateBasicFeat(FeatName + "Pet",
                Guids.FavoredAnimalFocusBearPet, "FavoredBear.Name", "FavoredBear.Description");
            BuffConfigurator.New(FeatName + "Buff", Guids.FavoredAnimalFocusBearBuff).Configure();
            FeatureConfigurator.New(FeatName, Guids.FavoredAnimalFocusBear).Configure();
        }

        public static BlueprintFeature Configure()
        {
            //Create a pet feature to use as the conditional information for the new buff.
            BlueprintFeature FavoredBearFocusPetFeat = BasicFunctions.CreateBasicFeat(FeatName + "Pet", 
                Guids.FavoredAnimalFocusBearPet, "FavoredBear.Name", "FavoredBear.Description");

            //The magical new ability with it's new context and everything
            BlueprintBuff FavoredAnimalBearBuff = BuffConfigurator.New(FeatName + "Buff", Guids.FavoredAnimalFocusBearBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BearsEndurance.Reference.Get().Icon)
                .AddContextStatBonus(StatType.Constitution, 
                value: new ContextValue()
                {
                    ValueType = ContextValueType.Rank
                }, ModifierDescriptor.Inherent)
                .AddContextRankConfig(
                    ContextRankConfigs.CharacterLevel()
                    .WithCustomProgression((7, 4), (15, 6), (16, 8)))
                .Configure();

            //Patch the existing AnimalFocusEffect to get it into our game.
            FeatureConfigurator.For(FeatureRefs.AnimalFocusBearEffect)
            .AddFactContextActions(
                activated:
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(FavoredBearFocusPetFeat).IsAnimalCompanion(),
                            ifTrue: ActionsBuilder.New().ApplyBuffPermanent(FavoredAnimalBearBuff, isNotDispelable: true, asChild: true)),
                deactivated:
                    ActionsBuilder.New().RemoveBuff(FavoredAnimalBearBuff, removeRank: false, toCaster: false))
            .Configure();

            //The feature we (the player) can select that adds our pet feature.
            return FeatureConfigurator.New(FeatName, Guids.FavoredAnimalFocusBear)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetReapplyOnLevelUp(true)
                .SetHideInUI(true)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .AddFeatureToPet(FavoredBearFocusPetFeat)
                .AddPrerequisiteFeature(FeatureRefs.HunterAnimalFocusFeature.Reference.Get())
                .Configure();
        }
    }
}

