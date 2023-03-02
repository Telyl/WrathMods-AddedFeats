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
    /// Creates a feat that does nothing but show up.
    /// </summary>
    public class FavoredAnimalFocusFalcon
    {
        private static readonly string FeatName = "FavoredAnimalFocusFalcon";
        private static readonly string DisplayName = "FavoredFalcon.Name";
        private static readonly string Description = "FavoredFalcon.Description";

        private static readonly LogWrapper FeatLogger = LogWrapper.Get("FavoredAnimalFocus");


        public static void ConfigureDisabled()
        {
            BasicFunctions.CreateBasicFeat(FeatName + "Pet",
                Guids.FavoredAnimalFocusFalconPet, "FavoredFalcon.Name", "FavoredFalcon.Description");
            BuffConfigurator.New(FeatName + "Buff", Guids.FavoredAnimalFocusFalconBuff).Configure();
            FeatureConfigurator.New(FeatName, Guids.FavoredAnimalFocusFalcon).Configure();
        }
        public static BlueprintFeature Configure()
        {
            //Create a pet feature to use as the conditional information for the new buff.
            BlueprintFeature FavoredFalconFocusPetFeat = BasicFunctions.CreateBasicFeat(FeatName + "Pet",
                Guids.FavoredAnimalFocusFalconPet, DisplayName, Description);

            //The magical new ability with it's new context and everything
            BlueprintBuff FavoredAnimalFalconBuff = BuffConfigurator.New(FeatName + "Buff", Guids.FavoredAnimalFocusFalconBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.AspectOfTheFalcon.Reference.Get().Icon)
                .AddContextStatBonus(StatType.SkillPerception, 
                value: new ContextValue()
                {
                    ValueType = ContextValueType.Rank
                }, ModifierDescriptor.Competence)
                .AddContextRankConfig(
                    ContextRankConfigs.CharacterLevel()
                    .WithCustomProgression((7, 6), (15, 8), (16, 12)))
                .Configure();

            //Patch the existing AnimalFocusEffect to get it into our game.
            FeatureConfigurator.For(FeatureRefs.AnimalFocusFalconEffect)
            .AddFactContextActions(
                activated:
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(FavoredFalconFocusPetFeat).IsAnimalCompanion(),
                            ifTrue: ActionsBuilder.New().ApplyBuffPermanent(FavoredAnimalFalconBuff, isNotDispelable: true, asChild: true)),
                deactivated:
                    ActionsBuilder.New().RemoveBuff(FavoredAnimalFalconBuff, removeRank: false, toCaster: false))
            .Configure();


            //The feature we (the player) can select that adds our pet feature.
            return FeatureConfigurator.New(FeatName, Guids.FavoredAnimalFocusFalcon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetReapplyOnLevelUp(true)
                .SetHideInUI(true)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .AddFeatureToPet(FavoredFalconFocusPetFeat)
                .AddPrerequisiteFeature(FeatureRefs.HunterAnimalFocusFeature.Reference.Get())
                .Configure();
        }
    }
}

