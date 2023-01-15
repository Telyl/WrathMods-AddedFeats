using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
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
    /// Creates a feat that does nothing but show up.
    /// </summary>
    public class FavoredAnimalFocusBull
    {
        private static readonly string FeatName = "FavoredAnimalFocusBull";
        private static readonly string DisplayName = "FavoredBull.Name";
        private static readonly string Description = "FavoredBull.Description";

        private static readonly LogWrapper FeatLogger = LogWrapper.Get("FavoredAnimalFocus");

        public static void ConfigureDisabled()
        {
            BasicFunctions.CreateBasicFeat(FeatName + "Pet",
                Guids.FavoredAnimalFocusBullPet, "FavoredBull.Name", "FavoredBull.Description");
            BuffConfigurator.New(FeatName + "Buff", Guids.FavoredAnimalFocusBullBuff).Configure();
            FeatureConfigurator.New(FeatName, Guids.FavoredAnimalFocusBull).Configure();
        }
        public static BlueprintFeature Configure()
        {
            //Create a pet feature to use as the conditional information for the new buff.
            BlueprintFeature FavoredBullFocusPetFeat = BasicFunctions.CreateBasicFeat(FeatName + "Pet",
                Guids.FavoredAnimalFocusBullPet, DisplayName, Description);

            //The magical new ability with it's new context and everything
            BlueprintBuff FavoredAnimalBullBuff = BuffConfigurator.New(FeatName + "Buff", Guids.FavoredAnimalFocusBullBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BullsStrength.Reference.Get().Icon)
                .AddContextStatBonus(StatType.Strength, 
                value: new ContextValue()
                {
                    ValueType = ContextValueType.Rank
                }, ModifierDescriptor.Inherent)
                .AddContextRankConfig(
                    ContextRankConfigs.CharacterLevel()
                    .WithCustomProgression((7, 4), (15, 6), (16, 8)))
                .Configure();

            //Patch the existing AnimalFocusEffect to get it into our game.
            FeatureConfigurator.For(FeatureRefs.AnimalFocusBullEffect)
            .AddFactContextActions(
                activated:
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(FavoredBullFocusPetFeat).IsAnimalCompanion(),
                            ifTrue: ActionsBuilder.New().ApplyBuffPermanent(FavoredAnimalBullBuff, isNotDispelable: true, asChild: true).RemoveBuff(BuffRefs.AnimalFocusBullAnimalBuff.Reference.Get(), removeRank: false, toCaster: false)),
                deactivated:
                    ActionsBuilder.New().RemoveBuff(FavoredAnimalBullBuff, removeRank: false, toCaster: false))
            .Configure();

            //The feature we (the player) can select that adds our pet feature.
            return FeatureConfigurator.New(FeatName, Guids.FavoredAnimalFocusBull)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetReapplyOnLevelUp(true)
                .SetHideInUI(true)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .AddFeatureToPet(FavoredBullFocusPetFeat)
                .AddPrerequisiteFeature(FeatureRefs.HunterAnimalFocusFeature.Reference.Get())
                .Configure();
        }
    }
}

