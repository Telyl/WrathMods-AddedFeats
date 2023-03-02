using System;
using AddedFeats.Utils;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using static UnityModManagerNet.UnityModManager.ModEntry;


namespace AddedFeats.Feats
{
    public class ImprovedNaturalAttack
    {
        private static readonly string FeatName = "ImprovedNaturalAttack";
        internal const string DisplayName = "ImprovedNaturalAttack.Name";
        private static readonly string Description = "ImprovedNaturalAttack.Description";

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        internal static void Configure()
        {
            try
            {
                if (Settings.IsEnabled(Guids.ImprovedNaturalAttack))
                    ConfigureEnabled();
                else
                    ConfigureDisabled();
            }
            catch (Exception e)
            {
                Logger.LogException("ImprovedNaturalAttack.Configure", e);
            }
        }

        private static BlueprintFeature CreateImpNatAttack(string featname, string guid, string displayname, WeaponCategory weapon)
        {
            return FeatureConfigurator.New(featname, guid)
                .SetDisplayName(displayname)
                .SetDescription(Description)
                .AddIncreaseDiceSizeOnAttack(additionalSize: 1, categories: new WeaponCategory[] { weapon })
                .AddPrerequisiteClassLevel(CharacterClassRefs.AnimalCompanionClass.Reference.Get(), 1)
                .AddPrerequisiteFullStatValue(stat: StatType.BaseAttackBonus, value: 4)
                .AddRecommendationHasClasses(new() { CharacterClassRefs.AnimalCompanionClass.Reference.Get() })
                .Configure();
        }

        private static void ConfigureDisabled()
        {
            FeatureSelectionConfigurator.New(FeatName, Guids.ImprovedNaturalAttack).Configure();
            CreateImpNatAttack(FeatName + "Bite", Guids.ImprovedNaturalAttackBite, "ImprovedNaturalAttackBite.Name", WeaponCategory.Bite);
            CreateImpNatAttack(FeatName + "Claw", Guids.ImprovedNaturalAttackClaw, "ImprovedNaturalAttackClaw.Name", WeaponCategory.Claw);
            CreateImpNatAttack(FeatName + "Hoof", Guids.ImprovedNaturalAttackHoof, "ImprovedNaturalAttackHoof.Name", WeaponCategory.Hoof);
            CreateImpNatAttack(FeatName + "Gore", Guids.ImprovedNaturalAttackGore, "ImprovedNaturalAttackGore.Name", WeaponCategory.Gore);
            CreateImpNatAttack(FeatName + "Talon", Guids.ImprovedNaturalAttackTalon, "ImprovedNaturalAttackTalon.Name", WeaponCategory.Talon);
            CreateImpNatAttack(FeatName + "Tail", Guids.ImprovedNaturalAttackTail, "ImprovedNaturalAttackTail.Name", WeaponCategory.Tail);
            CreateImpNatAttack(FeatName + "Slam", Guids.ImprovedNaturalAttackSlam, "ImprovedNaturalAttackSlam.Name", WeaponCategory.Slam);
        }

        private static void ConfigureEnabled()
        {
            BlueprintFeature bite = CreateImpNatAttack(FeatName + "Bite", Guids.ImprovedNaturalAttackBite, "ImprovedNaturalAttackBite.Name", WeaponCategory.Bite);
            BlueprintFeature claw = CreateImpNatAttack(FeatName + "Claw", Guids.ImprovedNaturalAttackClaw, "ImprovedNaturalAttackClaw.Name", WeaponCategory.Claw);
            BlueprintFeature hoof = CreateImpNatAttack(FeatName + "Hoof", Guids.ImprovedNaturalAttackHoof, "ImprovedNaturalAttackHoof.Name", WeaponCategory.Hoof);
            BlueprintFeature gore = CreateImpNatAttack(FeatName + "Gore", Guids.ImprovedNaturalAttackGore, "ImprovedNaturalAttackGore.Name", WeaponCategory.Gore);
            BlueprintFeature talon = CreateImpNatAttack(FeatName + "Talon", Guids.ImprovedNaturalAttackTalon, "ImprovedNaturalAttackTalon.Name", WeaponCategory.Talon);
            BlueprintFeature tail = CreateImpNatAttack(FeatName + "Tail", Guids.ImprovedNaturalAttackTail, "ImprovedNaturalAttackTail.Name", WeaponCategory.Tail);
            BlueprintFeature slam = CreateImpNatAttack(FeatName + "Slam", Guids.ImprovedNaturalAttackSlam, "ImprovedNaturalAttackSlam.Name", WeaponCategory.Slam);

            var selection = FeatureSelectionConfigurator.New(FeatName, Guids.ImprovedNaturalAttack)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddPrerequisiteClassLevel(CharacterClassRefs.AnimalCompanionClass.Reference.Get(), 1)
                .AddPrerequisiteFullStatValue(stat: StatType.BaseAttackBonus, value: 4)
                .AddRecommendationHasClasses(new() { CharacterClassRefs.AnimalCompanionClass.Reference.Get(), CharacterClassRefs.AnimalClass.Reference.Get() })
                .AddToAllFeatures(bite, claw, hoof, gore, talon, tail, slam)
                .SetHideNotAvailibleInUI()
                .Configure();

            var basicFeatSelectionGuid = "247a4068-296e-8be4-2890-143f451b4b45";
            FeatureSelectionConfigurator.For(basicFeatSelectionGuid)
                .AddToAllFeatures(selection)
                .Configure();
        }
    }
}
