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
    public class ImprovedDamage
    {
        private static readonly string FeatName = "ImprovedDamage";
        internal const string DisplayName = "ImprovedDamage.Name";
        internal const string BiteDisplayName = "BiteImprovedDamage.Name";
        internal const string ClawDisplayName = "ClawImprovedDamage.Name";
        internal const string HoofDisplayName = "HoofImprovedDamage.Name";
        internal const string GoreDisplayName = "GoreImprovedDamage.Name";
        internal const string TalonDisplayName = "TalonImprovedDamage.Name";
        internal const string SlamDisplayName = "SlamImprovedDamage.Name";
        internal const string TailDisplayName = "TailImprovedDamage.Name";
        private static readonly string Description = "ImprovedDamage.Description";

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        public static void ConfigureDisabled()
        {
            FeatureConfigurator.New(FeatName, Guids.ImprovedDamage).Configure();
            FeatureConfigurator.New(FeatName + "BitePet", Guids.ImprovedDamageBitePet).Configure();
            FeatureConfigurator.New(FeatName + "ClawPet", Guids.ImprovedDamageClawPet).Configure();
            FeatureConfigurator.New(FeatName + "HoofPet", Guids.ImprovedDamageHoofPet).Configure();
            FeatureConfigurator.New(FeatName + "GorePet", Guids.ImprovedDamageGorePet).Configure();
            FeatureConfigurator.New(FeatName + "TalonPet", Guids.ImprovedDamageTalonPet).Configure();
            FeatureConfigurator.New(FeatName + "SlamPet", Guids.ImprovedDamageSlamPet).Configure();
            FeatureConfigurator.New(FeatName + "TailPet", Guids.ImprovedDamageTailPet).Configure();
            
            FeatureConfigurator.New(FeatName + "Bite", Guids.ImprovedDamageBiteFeat).Configure();
            FeatureConfigurator.New(FeatName + "Claw", Guids.ImprovedDamageClawFeat).Configure();
            FeatureConfigurator.New(FeatName + "Hoof", Guids.ImprovedDamageHoofFeat).Configure();
            FeatureConfigurator.New(FeatName + "Gore", Guids.ImprovedDamageGoreFeat).Configure();
            FeatureConfigurator.New(FeatName + "Talon", Guids.ImprovedDamageTalonFeat).Configure();
            FeatureConfigurator.New(FeatName + "Tail", Guids.ImprovedDamageTailFeat).Configure();
            FeatureConfigurator.New(FeatName + "Slam", Guids.ImprovedDamageSlamFeat).Configure(); 
        }

        public static BlueprintFeature ConfigureEnabled()
        {
            //Base: Bite, Claw, Hooves, Gore, Talons, Slam
            //Evolution: Tail
            #region PetFeatsToAdd
            var PetBiteFeat = FeatureConfigurator.New(FeatName + "BitePet", Guids.ImprovedDamageBitePet)
                .SetDisplayName(BiteDisplayName)
                .SetDescription(Description)
                .AddIncreaseDiceSizeOnAttack(additionalSize: 1, categories: new WeaponCategory[] { WeaponCategory.Bite }, checkWeaponCategories: true)
                .Configure();
            var PetClawFeat = FeatureConfigurator.New(FeatName + "ClawPet", Guids.ImprovedDamageClawPet)
                .SetDisplayName(ClawDisplayName)
                .SetDescription(Description)
                .AddIncreaseDiceSizeOnAttack(additionalSize: 1, categories: new WeaponCategory[] { WeaponCategory.Claw }, checkWeaponCategories: true)
                .Configure();
            var PetHoofFeat = FeatureConfigurator.New(FeatName + "HoofPet", Guids.ImprovedDamageHoofPet)
                .SetDisplayName(HoofDisplayName)
                .SetDescription(Description)
                .AddIncreaseDiceSizeOnAttack(additionalSize: 1, categories: new WeaponCategory[] { WeaponCategory.Hoof }, checkWeaponCategories: true)
                .Configure();
            var PetGoreFeat = FeatureConfigurator.New(FeatName + "GorePet", Guids.ImprovedDamageGorePet)
                .SetDisplayName(GoreDisplayName)
                .SetDescription(Description)
                .AddIncreaseDiceSizeOnAttack(additionalSize: 1, categories: new WeaponCategory[] { WeaponCategory.Gore }, checkWeaponCategories: true)
                .Configure();
            var PetTalonFeat = FeatureConfigurator.New(FeatName + "TalonPet", Guids.ImprovedDamageTalonPet)
                .SetDisplayName(TalonDisplayName)
                .SetDescription(Description)
                .AddIncreaseDiceSizeOnAttack(additionalSize: 1, categories: new WeaponCategory[] { WeaponCategory.Talon }, checkWeaponCategories: true)
                .Configure();
            var PetTailFeat = FeatureConfigurator.New(FeatName + "TailPet", Guids.ImprovedDamageTailPet)
                .SetDisplayName(TailDisplayName)
                .SetDescription(Description)
                .AddIncreaseDiceSizeOnAttack(additionalSize: 1, categories: new WeaponCategory[] { WeaponCategory.Tail }, checkWeaponCategories: true)
                .Configure();
            var PetSlamFeat = FeatureConfigurator.New(FeatName + "SlamPet", Guids.ImprovedDamageSlamPet)
                .SetDisplayName(SlamDisplayName)
                .SetDescription(Description)
                .AddIncreaseDiceSizeOnAttack(additionalSize: 1, categories: new WeaponCategory[] { WeaponCategory.Slam }, checkWeaponCategories: true)
                .Configure();
            #endregion
            #region PCFeatThatAddsPetFeat
            var BiteFeat = FeatureConfigurator.New(FeatName + "BiteFeat", Guids.ImprovedDamageBiteFeat).SetDisplayName(BiteDisplayName).AddFeatureToPet(PetBiteFeat).Configure();
            var ClawFeat = FeatureConfigurator.New(FeatName + "ClawFeat", Guids.ImprovedDamageClawFeat).SetDisplayName(ClawDisplayName).AddFeatureToPet(PetClawFeat).Configure();
            var HoofFeat = FeatureConfigurator.New(FeatName + "HoofFeat", Guids.ImprovedDamageHoofFeat).SetDisplayName(HoofDisplayName).AddFeatureToPet(PetHoofFeat).Configure();
            var GoreFeat = FeatureConfigurator.New(FeatName + "GoreFeat", Guids.ImprovedDamageGoreFeat).SetDisplayName(GoreDisplayName).AddFeatureToPet(PetGoreFeat).Configure();
            var TalonFeat = FeatureConfigurator.New(FeatName + "TalonFeat", Guids.ImprovedDamageTalonFeat).SetDisplayName(TalonDisplayName).AddFeatureToPet(PetTalonFeat).Configure();
            var TailFeat = FeatureConfigurator.New(FeatName + "TailFeat", Guids.ImprovedDamageTailFeat).SetDisplayName(TailDisplayName).AddFeatureToPet(PetTailFeat).Configure();
            var SlamFeat = FeatureConfigurator.New(FeatName + "SlamFeat", Guids.ImprovedDamageSlamFeat).SetDisplayName(SlamDisplayName).AddFeatureToPet(PetSlamFeat).Configure();

            #endregion

            var Feat = FeatureSelectionConfigurator.New(FeatName, Guids.ImprovedDamage)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddToAllFeatures(BiteFeat, ClawFeat, HoofFeat, GoreFeat, TalonFeat, TailFeat, SlamFeat)
                .Configure();

            return Feat;
        }
    }
}
