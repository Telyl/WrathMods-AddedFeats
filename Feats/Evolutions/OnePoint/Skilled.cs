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
    public class Skilled
    {
        private static readonly string FeatName = "Skilled";
        internal const string DisplayName = "Skilled.Name";
        internal const string AthleticsDisplayName = "SkilledAthletics.Name";
        internal const string MobilityDisplayName = "SkilledMobility.Name";
        internal const string TrickeryDisplayName = "SkilledTrickery.Name";
        internal const string StealthDisplayName = "SkilledStealth.Name";
        internal const string ArcanaDisplayName = "SkilledArcana.Name";
        internal const string WorldDisplayName = "SkilledWorld.Name";
        internal const string NatureDisplayName = "SkilledNature.Name";
        internal const string ReligionDisplayName = "SkilledReligion.Name";
        internal const string PerceptionDisplayName = "SkilledPerception.Name";
        internal const string PersuasionDisplayName = "SkilledPersuasion.Name";
        internal const string UMDDisplayName = "SkilledUMD.Name";
        private static readonly string Description = "Skilled.Description";

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        public static void ConfigureDisabled()
        {
            FeatureSelectionConfigurator.New(FeatName, Guids.Skilled).Configure();
            FeatureConfigurator.New(FeatName + "AthleticsPet", Guids.SkilledAthleticsPet).Configure();
            FeatureConfigurator.New(FeatName + "MobilityPet", Guids.SkilledMobilityPet).Configure();
            FeatureConfigurator.New(FeatName + "TrickeryPet", Guids.SkilledTrickeryPet).Configure();
            FeatureConfigurator.New(FeatName + "StealthPet", Guids.SkilledStealthPet).Configure();
            FeatureConfigurator.New(FeatName + "ArcanaPet", Guids.SkilledArcanaPet).Configure();
            FeatureConfigurator.New(FeatName + "WorldPet", Guids.SkilledWorldPet).Configure();
            FeatureConfigurator.New(FeatName + "NaturePet", Guids.SkilledNaturePet).Configure();
            FeatureConfigurator.New(FeatName + "ReligionPet", Guids.SkilledReligionPet).Configure();
            FeatureConfigurator.New(FeatName + "PerceptionPet", Guids.SkilledPerceptionPet).Configure();
            FeatureConfigurator.New(FeatName + "PersuasionPet", Guids.SkilledPersuasionPet).Configure();
            FeatureConfigurator.New(FeatName + "UMDPet", Guids.SkilledUMDPet).Configure();

            FeatureConfigurator.New(FeatName + "Athletics", Guids.SkilledAthleticsFeat).Configure();
            FeatureConfigurator.New(FeatName + "Mobility", Guids.SkilledMobilityFeat).Configure();
            FeatureConfigurator.New(FeatName + "Trickery", Guids.SkilledTrickeryFeat).Configure();
            FeatureConfigurator.New(FeatName + "Stealth", Guids.SkilledStealthFeat).Configure();
            FeatureConfigurator.New(FeatName + "Arcana", Guids.SkilledArcanaFeat).Configure();
            FeatureConfigurator.New(FeatName + "World", Guids.SkilledWorldFeat).Configure();
            FeatureConfigurator.New(FeatName + "Nature", Guids.SkilledNatureFeat).Configure();
            FeatureConfigurator.New(FeatName + "Religion", Guids.SkilledReligionFeat).Configure();
            FeatureConfigurator.New(FeatName + "Perception", Guids.SkilledPerceptionFeat).Configure();
            FeatureConfigurator.New(FeatName + "Persuasion", Guids.SkilledPersuasionFeat).Configure();
            FeatureConfigurator.New(FeatName + "UMD", Guids.SkilledUMDFeat).Configure();
        }
        public static BlueprintFeature CreatePCPetFeats(string displayname, string statname, string guidpet, string guidpc, StatType skill)
        {
            var petfeat = FeatureConfigurator.New(FeatName + statname + "Pet", guidpet)
                    .SetDisplayName(displayname)
                    .SetDescription(Description)
                    .AddStatBonus(descriptor: ModifierDescriptor.Racial, stat: skill, value: 8)
                    .Configure();

            return FeatureConfigurator.New(FeatName + statname, guidpc)
                .SetDisplayName(displayname)
                .SetDescription(Description)
                .AddFeatureToPet(petfeat)
                .Configure();
        }
        public static BlueprintFeature ConfigureEnabled()
        {

            BlueprintFeature athleticsfeat = CreatePCPetFeats(AthleticsDisplayName, "Athletics", Guids.SkilledAthleticsPet, Guids.SkilledAthleticsFeat, StatType.SkillAthletics);
            BlueprintFeature mobilityfeat = CreatePCPetFeats(MobilityDisplayName, "Mobility", Guids.SkilledMobilityPet, Guids.SkilledMobilityFeat, StatType.SkillMobility);
            BlueprintFeature trickeryfeat = CreatePCPetFeats(TrickeryDisplayName, "Trickery", Guids.SkilledTrickeryPet, Guids.SkilledTrickeryFeat, StatType.SkillThievery);
            BlueprintFeature stealthfeat = CreatePCPetFeats(StealthDisplayName, "Stealth", Guids.SkilledStealthPet, Guids.SkilledStealthFeat, StatType.SkillStealth);
            BlueprintFeature arcanafeat = CreatePCPetFeats(ArcanaDisplayName, "Arcana", Guids.SkilledArcanaPet, Guids.SkilledArcanaFeat, StatType.SkillKnowledgeArcana);
            BlueprintFeature worldfeat = CreatePCPetFeats(WorldDisplayName, "World", Guids.SkilledWorldPet, Guids.SkilledWorldFeat, StatType.SkillKnowledgeWorld);
            BlueprintFeature naturefeat = CreatePCPetFeats(NatureDisplayName, "Nature", Guids.SkilledNaturePet, Guids.SkilledNatureFeat, StatType.SkillLoreNature);
            BlueprintFeature religionfeat = CreatePCPetFeats(ReligionDisplayName, "Religion", Guids.SkilledReligionPet, Guids.SkilledReligionFeat, StatType.SkillLoreReligion);
            BlueprintFeature perceptionfeat = CreatePCPetFeats(PerceptionDisplayName, "Perception", Guids.SkilledPerceptionPet, Guids.SkilledPerceptionFeat, StatType.SkillPerception);
            BlueprintFeature persuasionfeat = CreatePCPetFeats(PersuasionDisplayName, "Persuasion", Guids.SkilledPersuasionPet, Guids.SkilledPersuasionFeat, StatType.SkillPersuasion);
            BlueprintFeature umdfeat = CreatePCPetFeats(UMDDisplayName, "UMD", Guids.SkilledUMDPet, Guids.SkilledUMDFeat, StatType.SkillUseMagicDevice);

            var Feat = FeatureSelectionConfigurator.New(FeatName, Guids.Skilled)
               .SetDisplayName(DisplayName)
               .SetDescription(Description)
               .AddToAllFeatures(athleticsfeat, mobilityfeat, trickeryfeat, stealthfeat, arcanafeat, worldfeat, naturefeat,
               religionfeat, perceptionfeat, persuasionfeat, umdfeat)
               .Configure();

            return Feat;
        }


    }
}
