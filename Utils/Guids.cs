using AddedFeats.Feats;
using AddedFeats.NewSpells;
using AddedFeats.Homebrew;
using AddedFeats.NewClasses;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace AddedFeats.Utils
{
    /// <summary>
    /// Creates a feat that does nothing but show up.
    /// </summary>
    public class Guids
    {
        private static readonly ModLogger Logger = Logging.GetLogger(nameof(Guids));


        //** Feats **//
        #region Features
        #region Favored Animal Focus
        // Favored Animal Selection Feat
        internal const string FavoredAnimalFocusSelection = "fe2d7d81-6631-4bff-8a35-b56c9811d7eb";
        // Favored Animal Focus Tiger
        internal const string FavoredAnimalFocusTiger = "85120543-d4b6-403e-ac84-3acf07fa2d52";
        internal const string FavoredAnimalFocusTigerPet = "c246781a-4e26-460d-ab32-673307ece6f0";
        internal const string FavoredAnimalFocusTigerBuff = "cdde9ed1-46cf-4457-8b8e-af3d7b0f3055";
        // Favored Animal Focus Stag
        internal const string FavoredAnimalFocusStag = "66c9bcda-64bf-45ab-9412-477c28bf61ce";
        internal const string FavoredAnimalFocusStagPet = "e94f30bf-2072-42fc-bb81-9e8f009b788f";
        internal const string FavoredAnimalFocusStagBuff = "0b56ec52-cc94-49eb-a65a-37cd3af3b061";
        // Favored Animal Focus Owl
        internal const string FavoredAnimalFocusOwl = "4cfe9a7f-74d8-46d2-bc47-aafd383b30d6";
        internal const string FavoredAnimalFocusOwlPet = "b6096f3e-e95a-4700-b7fa-695a3f25f103";
        internal const string FavoredAnimalFocusOwlBuff = "725a9c22-a69f-41ee-9aed-cddd2b2af560";
        // Favored Animal Focus Mouse
        internal const string FavoredAnimalFocusMouse = "8ad4b17f-fc7d-41b3-9021-fe70108484a1";
        internal const string FavoredAnimalFocusMousePet = "373677ff-532d-49d0-bee3-eb6513fef7c7";
        internal const string FavoredAnimalFocusMouseBuff = "322ddf08-5a72-41c1-a020-cf0f871967ec";
        // Favored Animal Focus Monkey
        internal const string FavoredAnimalFocusMonkey = "fa0ba92e-6304-494f-be38-8e4a4a840e16";
        internal const string FavoredAnimalFocusMonkeyPet = "b462262d-73ee-4f85-a321-6c4a63de44cf";
        internal const string FavoredAnimalFocusMonkeyBuff = "f5273925-3e0f-4b91-9bdc-26d39a674825";
        // Favored Animal Focus Falcon
        internal const string FavoredAnimalFocusFalcon = "acfeb870-ad3f-4036-874f-4ec277944290";
        internal const string FavoredAnimalFocusFalconPet = "8f297ce8-6233-4ef6-a578-0988ded5dc0b";
        internal const string FavoredAnimalFocusFalconBuff = "b101cef2-6e25-46ac-945c-bf9f1fcdb722";
        // Favored Animal Focus Bull
        internal const string FavoredAnimalFocusBull = "60b339a3-33e6-4fce-0c9c-e51403ef5ada";
        internal const string FavoredAnimalFocusBullPet = "60c339a3-33e3-4fce-8c8c-e51403ef5ada";
        internal const string FavoredAnimalFocusBullBuff = "16c88e20-b823-44b9-b15f-e69fc4c6a556";
        // Favored Animal Focus Bear
        internal const string FavoredAnimalFocusBear = "bca79523-3d18-4ff6-ae9d-a14ace7ff516";
        internal const string FavoredAnimalFocusBearPet = "80a1a04e-ed27-43f9-8ee0-783625d155c6";
        internal const string FavoredAnimalFocusBearBuff = "ef3f2bfe-6ab0-4259-ae1e-5a6aa14cb4a2";
        #endregion
        #region Forceful Charge
        // Forceful Charge
        internal const string ForcefulCharge = "b7874cf6-0a94-4685-a295-f2467b6c5428";
        internal const string ForcefulChargeAbility= "d8ec6b3f-c687-493a-b5d9-2b31715b5fd2";
        internal const string ForcefulChargeBuff = "508b7605-623c-468e-af65-7bac9cc36af7";
        internal const string ForcefulChargeEffect = "19041d0c-3ae9-40aa-ae0f-addc3aefc7e2";
        // Improved Forceful Charge
        internal const string ImprovedForcefulCharge = "c6374cf6-0b94-4386-a281-f1167b6c5428";
        internal const string ImprovedForcefulChargeEffect = "5ccb7545-623c-468e-bbbb-7b32ccc36af7";
        #endregion
        #region Planar Focus
        // Planar Focus
        internal const string PlanarFocus = "3d64ed44-42f3-4a8f-b7ae-a927a45af820";
        // Planar Focus Air
        internal const string PlanarFocusAir = "31c9d157-fb70-4997-a0b3-56f9026d1c40";
        internal const string PlanarFocusAirBuff = "31d9d157-fb70-4997-a0b3-56f9026d1c40";
        internal const string PlanarFocusAirAnimalBuffEffect = "e55cc808-4cf2-4272-88f5-bda65d0417fc";
        internal const string PlanarFocusAirEffect = "06c88e20-b823-44b9-b15f-e69fc4c6a556";
        internal const string PlanarFocusAirAnimalBuff = "56722f70-03e5-4272-9aa3-115382ae869f";
        // Planar Focus Chaotic
        internal const string PlanarFocusChaotic = "4828c37e-3d59-4358-a042-b9fa4fb7bb72";
        internal const string PlanarFocusChaoticBuff = "db903e19-7586-45a5-ac05-3cb8b410f039";
        internal const string PlanarFocusChaoticAnimalBuffEffect = "502cba69-f94a-4399-b37f-3577ad8018a2";
        internal const string PlanarFocusChaoticEffect = "b5741066-de62-447c-8ba5-e265aa4e1292";
        internal const string PlanarFocusChaoticAnimalBuff = "fd904798-952b-45aa-b594-0841156bdc7a";
        // Planar Focus Cold
        internal const string PlanarFocusCold = "cc239df8-dfbf-49d2-86ca-ea462717ab4d";
        internal const string PlanarFocusColdBuff = "f47e182b-f8d3-4477-b78e-075fc8205892";
        internal const string PlanarFocusColdAnimalBuffEffect = "775bb39b-8d48-40d9-bed7-55f2411575dd";
        internal const string PlanarFocusColdEffect = "818f4cdb-2939-4824-90cc-118269fe5203";
        internal const string PlanarFocusColdAnimalBuff = "958b8209-4ece-4233-b592-87c3997fc073";
        // Planar Focus Earth
        internal const string PlanarFocusEarth = "548da62f-f01a-420c-9528-e8bee75a7d34";
        internal const string PlanarFocusEarthBuff = "7119f97b-110a-4001-b770-8b5eb08799e5";
        internal const string PlanarFocusEarthAnimalBuffEffect = "9d3fbbc5-0609-4fe3-9cd2-53991c10620d";
        internal const string PlanarFocusEarthEffect = "6ebaa1dc-a6d2-48f9-81fa-80eb1d822b6e";
        internal const string PlanarFocusEarthAnimalBuff = "b0f6b4b8-3dc7-4197-95ad-b242db6651bd";
        // Planar Focus Evil
        internal const string PlanarFocusEvil = "db542378-f53b-4d5c-ada2-461cea97a6b3";
        internal const string PlanarFocusEvilBuff = "2d294f73-f191-4309-b103-7a3eecc505b0";
        internal const string PlanarFocusEvilAnimalBuffEffect = "b81875c8-313b-473f-a16c-be34c011b579";
        internal const string PlanarFocusEvilEffect = "a54b8dd2-d0cc-44d3-bd6e-068274031a3b";
        internal const string PlanarFocusEvilAnimalBuff = "856c95f9-05a9-4dd6-89b3-6f2ebd51eef2";
        // Planar Focus Fire
        internal const string PlanarFocusFire = "33628596-101f-4c2d-bcf8-e6814ddda153";
        internal const string PlanarFocusFireBuff = "456b7bc9-600b-4ac6-8a57-3f5d6061753d";
        internal const string PlanarFocusFireAnimalBuffEffect = "d2864f28-e5f9-4421-ad0f-c64f63124906";
        internal const string PlanarFocusFireEffect = "9899c88c-2e31-425b-946e-829e8666387e";
        internal const string PlanarFocusFireAnimalBuff = "595d616f-73ac-4da7-aa3b-402eeb53ee79";
        // Planar Focus Good
        internal const string PlanarFocusGood = "dc063444-4fdf-45e2-95dd-6c656be7eea0";
        internal const string PlanarFocusGoodBuff = "dd28cb24-248f-4db5-b633-8d4d5e9fcd97";
        internal const string PlanarFocusGoodAnimalBuffEffect = "0b264ada-ab69-4e83-b146-51a2cb8d5365";
        internal const string PlanarFocusGoodEffect = "ab623544-9f58-4065-a969-7b080b9745fe";
        internal const string PlanarFocusGoodAnimalBuff = "16500163-506d-4043-9ed9-05fd0ec902dd";
        // Planar Focus Lawful
        internal const string PlanarFocusLawful = "9db5c2d0-1910-4da6-ac3c-a6c57d64fd7c";
        internal const string PlanarFocusLawfulBuff = "d8cef07b-85f8-416b-80e9-da08e98f14f3";
        internal const string PlanarFocusLawfulAnimalBuffEffect = "92b8a842-5176-4d3d-9fb9-7a3a9100d80d";
        internal const string PlanarFocusLawfulEffect = "0963ac0b-d3a5-4609-9755-1c85208309a9";
        internal const string PlanarFocusLawfulAnimalBuff = "984434d3-991b-4f80-a522-3ffc949f2906";
        // Planar Focus Shadow
        internal const string PlanarFocusShadow = "4389de8f-407c-43fe-88fe-3acbd3de4d79";
        internal const string PlanarFocusShadowBuff = "caa05043-9cea-48e3-94ea-01e223abfdfb";
        internal const string PlanarFocusShadowAnimalBuffEffect = "0c40850d-e56d-4cbe-98af-536287e3d742";
        internal const string PlanarFocusShadowEffect = "b1269d4f-1ae6-4d8e-8257-03fa1fc86fdb";
        internal const string PlanarFocusShadowAnimalBuff = "275b8ffc-475a-41a7-aeab-f41379cb2c73";
        // Planar Focus Water
        internal const string PlanarFocusWater = "b1b7951d-6c39-4b4b-9848-907436cacb1f";
        internal const string PlanarFocusWaterBuff = "b47bab02-098a-4b50-a244-dd4e62711658";
        internal const string PlanarFocusWaterAnimalBuffEffect = "6c912f1a-16e6-4870-b0d8-a3cb881bbfaa";
        internal const string PlanarFocusWaterEffect = "4ca8f08f-124d-4cd6-a04c-8164192f0d87";
        internal const string PlanarFocusWaterAnimalBuff = "736fd667-b68a-4e65-bee2-78cd55f3c27f";
        #endregion
        #region Improved Natural Armor (lvls 1-20)
        //Improved Natural Armor
        internal const string ImprovedNaturalArmor = "5f91ffea-81a3-4743-894b-e76e39c9567c";
        internal const string ImprovedNaturalArmor2 = "2291ffea-81a3-4743-894b-e76e39c9567c";
        internal const string ImprovedNaturalArmor3 = "3391ffea-81a3-4743-894b-e76e39c9567c";
        internal const string ImprovedNaturalArmor4 = "4491ffea-81a3-4743-894b-e76e39c9567c";
        internal const string ImprovedNaturalArmor5 = "5591ffea-81a3-4743-894b-e76e39c9567c";
        internal const string ImprovedNaturalArmor6 = "6691ffea-81a3-4743-894b-e76e39c9567c";
        internal const string ImprovedNaturalArmor7 = "7791ffea-81a3-4743-894b-e76e39c9567c";
        internal const string ImprovedNaturalArmor8 = "8891ffea-81a3-4743-894b-e76e39c9567c";
        internal const string ImprovedNaturalArmor9 = "9991ffea-81a3-4743-894b-e76e39c9567c";
        internal const string ImprovedNaturalArmor10 = "1091ffea-81a3-4743-894b-e76e39c9567c";
        #endregion
        #region Improved Natural Attack (Bite, Claw, Hoof, Gore, Talon, Tail, Slam)
        //Improved Natural Attack
        internal const string ImprovedNaturalAttack = "6d20775b-4347-479c-a5fe-aae3ddc35231";
        internal const string ImprovedNaturalAttackBite = "5aab99a6-0133-4d0a-849d-e78505a56b76";
        internal const string ImprovedNaturalAttackClaw = "56ebf0c0-cccf-471b-9366-b4e7fca5120c";
        internal const string ImprovedNaturalAttackHoof = "7bca3185-fafa-40f9-84bc-1a7b162516ed";
        internal const string ImprovedNaturalAttackGore = "dba99824-1cae-4520-af17-3797991909e5";
        internal const string ImprovedNaturalAttackTalon = "6ca96d19-9a41-4e93-a6d0-ec7b187a1c3a";
        internal const string ImprovedNaturalAttackTail = "6be0ab7c-34b7-4d29-bd8d-2c9146ff6788";
        internal const string ImprovedNaturalAttackSlam = "cfffbb0c-5479-4eca-9394-4c38a0ac0e0c";
        #endregion
        #region Totem Beast
        //Totem Beast
        internal const string TotemBeastSelection = "f3dea40e-9536-4fec-8f53-25031ef360c5";
        internal const string TotemBeastBull = "6270e7eb-eab4-492e-85cf-0794b87ab78a";
        internal const string TotemBeastBear = "1c516d01-37b1-4652-8e55-8d65f2f22dc8";
        internal const string TotemBeastTiger = "0588e49b-3885-45bf-8322-e6ef0938b875";
        internal const string TotemBeastFalcon = "1ceceb1b-5b34-43e8-9795-f2541e91b2b8";
        internal const string TotemBeastStag = "b28668bc-84ac-43ef-949d-bda568bbadad";
        internal const string TotemBeastMouse = "22406716-3bae-4687-9903-f076a97fa937";
        internal const string TotemBeastOwl = "572d9def-6827-47f9-afb3-ae239fa32457";
        internal const string TotemBeastMonkey = "e46464da-f1f8-4495-b3f0-eaae9a4e366b";

        internal const string TotemBeastBullBuff = "6240e7eb-eab4-492e-85cf-0794b87ab78a";
        internal const string TotemBeastBearBuff = "1c616d01-37b1-4652-8e55-8d65f2f22dc8";
        internal const string TotemBeastTigerBuff = "0558e49b-3885-45bf-8322-e6ef0938b875";
        internal const string TotemBeastFalconBuff = "14eceb1b-5b34-43e8-9795-f2541e91b2b8";
        internal const string TotemBeastStagBuff = "b28468bc-84ac-43ef-949d-bda568bbadad";
        internal const string TotemBeastMouseBuff = "22306716-3bae-4687-9903-f076a97fa937";
        internal const string TotemBeastOwlBuff = "572d5def-6827-47f9-afb3-ae239fa32457";
        internal const string TotemBeastMonkeyBuff = "e46664da-f1f8-4495-b3f0-eaae9a4e366b";

        internal const string TotemBeastBullPet = "5270e7eb-eab4-492e-85cf-0794b87ab78a";
        internal const string TotemBeastBearPet = "2c516d01-37b1-4652-8e55-8d65f2f22dc8";
        internal const string TotemBeastTigerPet = "1588e49b-3885-45bf-8322-e6ef0938b875";
        internal const string TotemBeastFalconPet = "2ceceb1b-5b34-43e8-9795-f2541e91b2b8";
        internal const string TotemBeastStagPet = "c28668bc-84ac-43ef-949d-bda568bbadad";
        internal const string TotemBeastMousePet = "32406716-3bae-4687-9903-f076a97fa937";
        internal const string TotemBeastOwlPet = "672d9def-6827-47f9-afb3-ae239fa32457";
        internal const string TotemBeastMonkeyPet = "a46464da-f1f8-4495-b3f0-eaae9a4e366b";
        #endregion
        #region Evolved Companion
        internal const string EvolvedCompanion = "dc9ac146-7bcd-48ab-b619-fc460641594b";
        #endregion
        #region Evolution: Improved Damage (1-Point)
        internal const string ImprovedDamage = "d79bb9d8-f021-462f-b9af-33744de95e20";
        internal const string ImprovedDamageBitePet = "a19bb9d8-f021-462f-b9af-33744de95e20";
        internal const string ImprovedDamageClawPet = "b29bb9d8-f021-462f-b9af-33744de95e20";
        internal const string ImprovedDamageHoofPet = "c39bb9d8-f021-462f-b9af-33744de95e20";
        internal const string ImprovedDamageGorePet = "d74bb9d8-f021-462f-b9af-33744de95e20";
        internal const string ImprovedDamageTalonPet = "e59bb9d8-f021-462f-b9af-33744de95e20";
        internal const string ImprovedDamageTailPet = "f69bb9d8-f021-462f-b9af-33744de95e20";
        internal const string ImprovedDamageSlamPet = "174bb9d8-f021-462f-b9af-33744de95e20";
        internal const string ImprovedDamageBiteFeat = "a19bb9d8-f021-462f-b9af-33744de95e10";
        internal const string ImprovedDamageClawFeat = "b29bb9d8-f021-462f-b9af-33744de95e10";
        internal const string ImprovedDamageHoofFeat = "c39bb9d8-f021-462f-b9af-33744de95e10";
        internal const string ImprovedDamageGoreFeat = "d74bb9d8-f021-462f-b9af-33744de95e10";
        internal const string ImprovedDamageTalonFeat = "e59bb9d8-f021-462f-b9af-33744de95e10";
        internal const string ImprovedDamageTailFeat = "f69bb9d8-f021-462f-b9af-33744de95e10";
        internal const string ImprovedDamageSlamFeat = "174bb9d8-f021-462f-b9af-33744de95e10";
        #endregion
        #region Evolution: Claw (1-Point)
        internal const string Claw = "44fc4faa-6964-4dee-9918-b2d0eecd7596";
        internal const string ClawPet = "6bc428d0-42fe-4155-80fa-ba88db385786";
        #endregion
        #region Evolution: Skilled (1-Point)
        internal const string Skilled = "1e590d90-7bff-4eae-aa51-bf2b7b290846";
        internal const string SkilledAthleticsFeat = "df2e0632-6236-44b2-9276-1abc4b158a4a";
        internal const string SkilledAthleticsPet = "4e7fbe05-8e57-49a7-8a7b-b6522678c54f";
        internal const string SkilledMobilityFeat = "463cf9d5-30c7-4766-b3d0-e10325a6204b";
        internal const string SkilledMobilityPet = "1fb4fd93-d493-4fbd-9567-9a83136e056b";
        internal const string SkilledTrickeryFeat = "93b53ac7-496c-48ac-9c3b-c7d710939532";
        internal const string SkilledTrickeryPet = "2111245d-f576-4565-8b71-4dda317e2f2c";
        internal const string SkilledStealthFeat = "c43e2c79-40e3-4600-b9fa-13fa86f76217";
        internal const string SkilledStealthPet = "e2142a40-4adf-41cf-b6be-3ed4ccd96d07";
        internal const string SkilledArcanaFeat = "42f8e400-79d9-4663-bb06-5da8236264d0";
        internal const string SkilledArcanaPet = "4842c47c-e93a-4a68-8f8d-5fdff9aec9f4";
        internal const string SkilledWorldFeat = "64cf5019-1980-4e7b-81fa-fe2cafc65580";
        internal const string SkilledWorldPet = "77d77350-94ee-4760-9056-12babbee6b9b";
        internal const string SkilledNatureFeat = "3c4d4434-d328-422d-a152-26aef27382cd";
        internal const string SkilledNaturePet = "7c3a3e64-d271-4408-b64f-4b3d79b4dac2";
        internal const string SkilledReligionFeat = "197a973d-c3f8-4267-8b48-3ebf7b20a26b";
        internal const string SkilledReligionPet = "7253d867-6017-42d1-88ed-f9fa9916c2ac";
        internal const string SkilledPerceptionFeat = "de7956f5-81e0-46ea-928d-8f0296aa8c6d";
        internal const string SkilledPerceptionPet = "d42dd01a-7745-4431-b5c7-890c3145c890";
        internal const string SkilledPersuasionFeat = "0ac3b6b1-236b-406d-b553-015af1ae18f4";
        internal const string SkilledPersuasionPet = "868b208d-c95e-4c37-87ab-003c01d7d936";
        internal const string SkilledUMDFeat = "74f248f0-d898-4c17-bd33-c068028d94f8";
        internal const string SkilledUMDPet = "0cd03586-72d1-4eb6-acc8-399fad2782dc";
        #endregion
        #region Evolution: Improved Natural Armoro (1-Point)
        internal const string EvolutionImprovedNaturalArmor1 = "d62a6dbc-a86a-47f0-b734-2b23cdd882f0";
        internal const string EvolutionImprovedNaturalArmorPet1 = "b42c7b6c-2eee-4f49-8519-168843dedbda";
        internal const string EvolutionImprovedNaturalArmor2 = "8ecacba2-5a6b-440b-9e1d-3fe18e8faaeb";
        internal const string EvolutionImprovedNaturalArmorPet2 = "f8e61a86-1bfd-40e8-bc33-626eb40c45b5";
        internal const string EvolutionImprovedNaturalArmor3 = "8d218165-7f3b-4d71-a96f-f9185825f228";
        internal const string EvolutionImprovedNaturalArmorPet3 = "d383aee2-7a35-4776-9beb-8a750bf62ee8";
        internal const string EvolutionImprovedNaturalArmor4 = "7821d431-38e7-4fc0-8232-a085c40b4562";
        internal const string EvolutionImprovedNaturalArmorPet4 = "a17d1a1a-820f-4dc9-b7c2-bc48da902e79";
        internal const string EvolutionImprovedNaturalArmor5 = "199b9195-e077-4401-b55a-f9b71cf1e88a";
        internal const string EvolutionImprovedNaturalArmorPet5 = "ef70d29a-48ac-4232-baa7-a67118770c4c";
        #endregion
        #region Vampiric Companion
        internal const string VampiricCompanionFeat = "52283e17-9213-4aee-8fc5-06c28ec0fbe8";
        #endregion
        #region Spirits Gift
        internal const string SpiritsGiftResource = "bf9b0218-b437-44f1-805f-cff756385d65";
        internal const string SpiritsGiftCompanion = "dba197da-7b4a-45d5-ad7b-ae26fdc7807c";
        internal const string SpiritsGiftCompanionBuff = "eba197da-7b4a-45d5-ad7b-ae26fdc7807c";
        internal const string SpiritsGift = "7f8e20a4-4c67-4e7f-bf8d-c4769e2f5145";
        internal const string SpiritsGiftAbility = "7f8e20a4-4c67-4111-bf1d-c4769e2f5145";

        internal const string SpiritFocusBattleBuff = "5d628248-9300-4688-92f4-d082598bd7ea";
        internal const string SpiritFocusBattle = "e3918d34-de74-4057-b434-e2a2e6b85a37";
        internal const string CustomSpiritFocusBattleBuff = "5d628248-1000-4688-92f4-d082598bd7ea";


        internal const string SpiritFocusBonesBuff = "a4fbac75-b80a-4b4c-8ceb-1d035668da1a";
        internal const string SpiritFocusBones = "a3918d34-de74-4057-b434-e2a2e6b85a37";
        internal const string CustomSpiritFocusBonesBuff = "70be7d66-be60-1000-8ea1-e5b886b8c7bb";

        internal const string SpiritFocusFlameBuff = "d4fbac75-b80a-4b4c-8ceb-1d035668da1a";
        internal const string SpiritFocusFlame = "ad628248-9300-4688-92f4-d082598bd7ea";
        internal const string CustomSpiritFocusFlameBuff = "70be7d66-be60-45fb-8ea1-e5b886b8c7bb";

        internal const string SpiritFocusFrostBuff = "0666c320-c827-4978-856a-dce86890d879";
        internal const string SpiritFocusFrost = "022ed006-6950-4d4c-91de-a0926b3c0939";
        internal const string CustomSpiritFocusFrostBuff = "6feb5f55-759e-4cb7-9dc2-301c271c4e8b";

        internal const string SpiritFocusLifeBuff = "33231c15-183b-4907-9598-a9afbf98cc8a";
        internal const string SpiritFocusLife = "551cd35f-71a7-4093-8ecd-3c3642a842b5";
        internal const string CustomSpiritFocusLifeBuff = "6bdeae8f-c06e-485e-8042-f15fb2c49e00";

        internal const string SpiritFocusLoreBuff = "fa36e4f8-6cf7-49f0-aeb3-6b3fa3993f92";
        internal const string SpiritFocusLore = "7284447c-d2e2-48cc-b587-4f7fcbc52acb";
        internal const string CustomSpiritFocusLoreBuff = "74333127-95f1-4f1c-af4d-abd1bb1276b1";

        internal const string SpiritFocusMammothBuff = "573b35be-345c-4d9e-b5b9-3694d7ba18f5";
        internal const string SpiritFocusMammoth = "83ef9ad1-4a78-41d7-bbf7-668ecdd0b566";
        internal const string CustomSpiritFocusMammothBuff = "99327593-e88b-45b6-b39d-33190655b185";

        internal const string SpiritFocusNatureBuff = "b293d887-70ab-43fa-8e06-5b6b8114357d";
        internal const string SpiritFocusNature = "da39cfa1-6af8-41d7-ba90-4f1d902ee2d0";
        internal const string CustomSpiritFocusNatureBuff = "154cfc48-bbd7-4a22-940b-40a5e925fd3d";

        internal const string SpiritFocusSlumsBuff = "c4f25928-9b8f-46ec-ab13-20a9dee760be";
        internal const string SpiritFocusSlums = "8fa88a6d-3cde-46e7-bf60-d78b1043fc29";
        internal const string CustomSpiritFocusSlumsBuff = "0f9e580e-2c17-4537-ba6c-d36622ed5033";

        internal const string SpiritFocusStoneBuff = "db313b2e-7ac4-4d30-8cf2-8dfd2469de71";
        internal const string SpiritFocusStone = "16d30365-5730-4d43-9321-58a04ada387c";
        internal const string CustomSpiritFocusStoneBuff = "f7a40c91-c8aa-4219-ae4d-8b039badac47";

        internal const string SpiritFocusWavesBuff = "c9f029f3-94a4-454e-89fc-c362e02e3b7c";
        internal const string SpiritFocusWaves = "d66fafcf-bf1a-4aeb-b7fe-33166bd976b2";
        internal const string CustomSpiritFocusWavesBuff = "d4d69af2-1a29-4cda-af4f-c9a384f2e995";
        
        internal const string SpiritFocusWindBuff = "e5c769ae-4146-4b5c-bd2c-5356da7dabc4";
        internal const string SpiritFocusWind = "2cde4a02-3e12-4207-80f4-17fdfa08ae18";
        internal const string CustomSpiritFocusWindBuff = "35d6696c-828a-4a87-89e2-5124684ba4be";

        #endregion
        #region Share Spells
        internal const string ImprovedSpellSharing = "44974dd6-2ce9-4e86-8faf-e6a2f886ceb8";
        internal const string ImprovedSpellSharingBuff = "44974dd6-2345-3e86-8faf-e6a2f886ceb8";
        internal const string ImprovedSpellSharingBuffCheck = "44334dd6-2345-3e86-8faf-e6a2f886ceb8";
        internal const string ImprovedSpellSharingBuffEffect = "42974dd6-2345-3e86-8faf-e6a2f776ceb8";
        internal const string ImprovedSpellSharingActiveAbility = "e0fd06e7-1d02-41a0-a202-5ec1162ff716";

        internal const string ImprovedSpellSharingCavalier = "7bfdd789-d0aa-4443-91ed-0ead187ddf0a";
        internal const string ImprovedSpellSharingVanguardBuff = "706d4e5f-703e-4ac7-b0bc-2e27e27cd91c";
        internal const string ImprovedSpellSharingVanguardAbility = "c340a5c5-0e70-4703-8b45-6a9f66d3b17a";
        internal const string ImprovedSpellSharingRagerBuff = "9ddd7a39-29ab-4cd6-9620-8bcf6c0084aa";
        internal const string ImprovedSpellSharingRagerArea = "fe784813-e347-4f36-807d-28d3edf5e079";
        internal const string ImprovedSpellSharingRagerAreaBuff = "49ced93c-c5fd-467c-9be4-78c0855b5f8b";
        internal const string ImprovedSpellSharingRagerToggleBuff = "d25691a6-008e-41b7-b28c-c494084a4b43";
        internal const string ImprovedSpellSharingRagerToggle = "1de18e8d-f5d9-4ae4-8cb4-5cbccdd753b9";
        #endregion
        //***********//
        internal static readonly (string guid, string displayName)[] Features =
          new (string, string)[]
          {
              (PlanarFocus, Feats.PlanarFocus.DisplayName),
              (ForcefulCharge, Feats.ForcefulCharge.DisplayName),
              (FavoredAnimalFocusSelection, Feats.FavoredAnimalFocusSelection.DisplayName),
              (ImprovedNaturalArmor, Feats.ImprovedNaturalArmor.DisplayName),
              (ImprovedNaturalAttack, Feats.ImprovedNaturalAttack.DisplayName),
              (EvolvedCompanion, Feats.EvolvedCompanion.DisplayName),
              (TotemBeastSelection, Feats.TotemBeast.DisplayName),
              (VampiricCompanionFeat, Feats.VampiricCompanion.DisplayName),
              (SpiritsGift, Feats.SpiritsGift.DisplayName),
              (ImprovedSpellSharing, Feats.ShareSpells.DisplayName)
          };
        #endregion

        #region Spells
        // Strong Jaw (Spell)
        internal const string StrongJawSpell = "7cd44ce1-3575-4ceb-b81b-dc71d66415c0";
        internal const string StrongJawSpellBuff = "6cd44ce1-3575-4ceb-b81b-dc71d66415c0";
        internal const string AtavismSpell = "d247af76-1159-46d8-84b0-3f6a0f2b75e5";
        internal const string AtavismSpellBuff = "dacda3da-964a-4bf8-aed2-3de9725934cf";
        internal static readonly (string guid, string displayName)[] Spells =
          new (string, string)[]
          {
              (StrongJawSpell, StrongJaw.DisplayName),
              (AtavismSpell, Atavism.DisplayName),
          };
        #endregion

        #region Homebrew
        internal const string MythicAnimalFocus = "f15fc8d6-b2cd-495d-8977-bf99e6176d1d";
        internal static readonly (string guid, string displayName)[] Homebrews =
          new (string, string)[]
          {
              (MythicAnimalFocus, Homebrew.MythicAnimalFocus.DisplayName),
          };
        #endregion

        #region Classes
        internal const string MediumClass = "16286dce-e3f1-443d-8115-01b4eec9e573";
        internal const string MediumProgression = "44225dce-e4a1-323d-8115-01b4eec9e573";
        internal const string MediumSpellbook = "dca485bf-acbe-43e0-b663-f352f4cf9f8b";
        internal const string MediumSpellbookSpellSlotsTable = "ba018348-49fc-4586-a304-bd551c0ed758";
        internal const string MediumSpellbookSpellsKnownTable = "0a5f9292-b59b-4f11-8366-ba02eed686dd";
        internal const string MediumSpellbookSpellSlotsTableSpirit = "85e9b5cf-a40b-418c-aaa4-32e3ce26a03f";
        internal const string MediumSpellList = "79f93e7c-bc52-46d3-9256-c5d271d570d8";
        #region ClassFeatures
        internal const string MediumProficiencies = "dff857a6-a36a-4157-b03d-c215c27e4453";
        // These are the checked facts we'll use to specify what spirits give
        internal const string SpiritBonusFeat = "6a980493-120b-4fc5-b815-6745ac1a2591";
        internal const string SpiritPowerFeat = "928fad09-830c-45bf-9592-432c8a90dba9";
        internal const string SpiritPowerLesser = "2b0b15b3-3239-478e-ac3d-bc68ce92422e";
        internal const string SpiritPowerIntermediate = "f35312b6-35fa-4539-93dc-16f40e9869c9";
        internal const string SpiritPowerGreater = "4e1d1a41-f1e9-47ef-9f37-8b207d6a285b";
        internal const string SpiritPowerSupreme = "e0fdbd93-9065-4154-a5a0-d9626ec3fb91";

        internal const string Spirit = "83526df9-0098-4033-9fee-4024c3d98b42";
        internal const string SpiritResource = "8736afac-b620-4c94-8f55-a7210b150f59";
        internal const string SpiritSurge = "a9b28d81-e097-4abe-8a2a-8ac324df75e2";
        internal const string SpiritSurgeProgression = "b9b28d81-e097-4abe-8a2a-8ac324df75e2";
        internal const string SpiritSurgeAbility = "21cb8367-480a-4884-ab72-8c322def6b9e";
        internal const string SpiritSurgeBuff = "8fe3a357-5f25-4729-b3b7-c53212cf1e25";

        internal const string Influence = "ae0805ec-035a-4ddf-8deb-15a9c448b7b5";
        internal const string InfluenceAbility = "f7642df8-8a73-467b-af80-d03e851d18ed";

        internal const string Archmage = "6fbf6bc5-644c-4fb7-83d6-455b05e44647";
        internal const string ArchmageProgression = "3171d721-2058-489d-8c9f-224dbaa72b87";
        internal const string ArchmageSeance = "5d38425a-21c1-403f-8033-a50f918fa5db";
        internal const string ArchmageSpiritBonus = "eb27b743-578f-424f-a06c-3ee5bb2ac5ad";
        internal const string ArchmageSpiritPowers = "6eb13ba8-94af-4a2c-80c9-228f2206a3f4";
        internal const string ArchmageSpiritPowerLesser = "578ff166-f46b-4789-af49-aa4141ffb820";
        internal const string ArchmageSpiritPowerIntermediate = "4835e8e8-ca56-4fc8-85a0-2cb41ef01406";
        internal const string ArchmageSpiritPowersGreater = "f60817f1-65e8-4a7e-bee7-0738842f23a0";
        internal const string ArchmageSpiritPowersSupreme = "bf24acce-1c48-4ea1-9770-91684ec357f7";
        internal const string ArchmageSpiritInfluencePenalty = "493bd8da-c8d9-43cd-bac5-a05289eb5eb2";
        internal const string ArchmageTaboo = "d5eafaf8-df45-4990-aeff-2a2b5ed36360";

        internal const string ArchmageWildArcana = "2f65e8f8-733f-43e1-a9ae-b1bec95713ef";
        internal const string ArchmageWildArcanaAbility = "ac33e36d-a429-4e5d-8c67-b899694226af";

        internal const string ArchmageSpellbook = "63a67612-db66-487e-ad25-04bf84034f12";
        internal const string ArchmageSpellbookFeat = "e452d83c-24cb-4c18-9373-a2b59b70e280";
        internal const string ArchmageSpellSlotsTable = "3fb737f5-2800-403a-8b2b-78e0b9c70342";
        internal const string ArchmageSpellPerDayTable = "dacc2bf7-7721-46a4-b86b-64bcb5433789";        

        internal const string Champion = "ecbb07f4-5d48-40e5-a69a-6f02d57ac5c6";
        internal const string ChampionSeance = "c20d10ea-0982-47b3-a11d-120bb1ef2e6b";
        internal const string ChampionSpiritBonus = "08bb818b-81d9-4116-8812-fb52e7ca28b6";
        internal const string ChampionSpiritPowers = "f3d707c6-0c64-4377-b4fe-eaa48d777fa2";
        internal const string ChampionSpiritPowerLesser = "80472009-c1db-46d5-878c-98cef0860f98";
        internal const string ChampionSpiritPowerIntermediate = "94a8f296-9690-42f5-9210-26b97befcaee";
        internal const string ChampionSpiritPowersGreater = "b7982265-6bf0-4e26-bc7a-aafec7f28e86";
        internal const string ChampionSpiritPowersSupreme = "2f755d30-747a-464a-b672-65a91b211a69";
        internal const string ChampionSpiritInfluencePenalty = "60956fcc-ae0e-4e40-afd3-d59c1d546cf9";
        internal const string ChampionTaboo = "e207d624-11f0-4eb3-80d4-9c33d0ab62ed";

        internal const string Guardian = "e3682110-f38a-4583-9317-564dbbf44439";
        internal const string GuardianSeance = "a2ba9126-859b-4d8a-bea5-849646542831";
        internal const string GuardianSpiritBonus = "136658fc-868d-4bf0-a1db-f8f67243787d";
        internal const string GuardianSpiritPowers = "435b6c17-bb04-4be4-8de7-2c2aecd02b21";
        internal const string GuardianSpiritPowerLesser = "bcc2b789-805b-436e-9527-77fd3f8b8d75";
        internal const string GuardianSpiritPowerIntermediate = "d3763788-4530-45b2-b40b-297ae47a1c9e";
        internal const string GuardianSpiritPowersGreater = "05098285-c6dd-41b6-ba86-8357d475059d";
        internal const string GuardianSpiritPowersSupreme = "87ea7c10-79ed-420a-9791-ac1ac29bd18d";
        internal const string GuardianSpiritInfluencePenalty = "c93cbdbd-f244-4f78-8024-01554c118dd8";
        internal const string GuardianTaboo = "c8a6d284-1b90-4b2e-9c94-66f9a7c832d3";

        internal const string Hierophant = "644c5fc7-e37e-42fe-a4bc-bf08dc2fa01f";
        internal const string HierophantProgression = "63caa530-07be-45cb-b7d9-6958df73e5e7";
        internal const string HierophantSeance = "22605cbf-44d2-44dd-bedb-9f2107df6f7c";
        internal const string HierophantSpiritBonus = "44cf0ea3-d54a-4a32-a22d-f6dcfe5c68c1";
        internal const string HierophantSpiritPowers = "efb5b595-f127-4d07-ac94-6efa36dabe0a";
        internal const string HierophantSpiritPowerLesser = "20743ff1-5c8a-431d-a8f5-0bda91a81b5f";
        internal const string HierophantSpiritPowerIntermediate = "05a129be-2da9-401c-b3d6-b4bfea6db458";
        internal const string HierophantSpiritPowersGreater = "40e4c0b5-6581-4aec-9d60-f8fcb356009b";
        internal const string HierophantSpiritPowersSupreme = "9ad1326b-171a-4efd-8a0f-4c84998a80ab";
        internal const string HierophantSpiritInfluencePenalty = "762c1d05-f24d-4472-b4b2-916da84bfa61";
        internal const string HierophantTaboo = "987ff22c-87a1-494b-a246-8e67cc4f2080";
        internal const string HierophantChannelEnergy = "3248edfa-f99b-449f-8ab9-60d61f0b8235";
        internal const string HierophantChannelEnergyPositiveHarm = "e5196fcf-7efe-4c30-b08f-707e063e4f6a";
        internal const string HierophantChannelNegativeEnergy = "482df247-9562-4208-94fb-8640fb8b9a6e";
        internal const string HierophantChannelNegativeEnergyHeal = "ecb49539-72b3-4539-aa06-17a63a8af57d";
        internal const string HierophantChannelEnergyFeature = "bb83ee27-d225-4b74-87fb-9b46abae64ee";
        internal const string HierophantChannelEnergyResource = "4358edfa-f99b-449f-8ab9-60d61f0b8235";

        internal const string HierophantOverflowingGrace = "492d1c25-2c3d-4013-a049-92802295ebdc";
        internal const string HierophantOverflowingGraceBuff = "8dcdf05f-8251-4df1-9822-628cf7b6dace";
        internal const string HierophantOverflowingGraceBuffProfane = "f99a90e1-c56c-4b1f-b234-31a510e5360d";

        internal const string HierophantSpellbook = "146e523e-ed26-414a-bc52-0598935caef4";
        internal const string HierophantSpellbookFeat = "91af1e89-0d7d-488f-8a53-4ebba4d63acc";
        internal const string HierophantSpellSlotsTable = "d9116d75-2af2-4dbd-a707-dc58ef84e637";
        internal const string HierophantSpellPerDayTable = "570e72ad-34bd-48ae-9b74-729c2dc09c85";

        internal const string Marshal = "b81e9bee-bab7-4fa7-8b5d-92c214dcf553";
        internal const string MarshalSeance = "2a886c23-3c35-4861-9c41-f83ef7010fe5";
        internal const string MarshalSpiritBonus = "71f5135e-e7c4-4c51-a2cd-f0da58ce80e9";
        internal const string MarshalSpiritPowers = "5aec6b40-edd9-473d-90eb-65ca3fe80efd";
        internal const string MarshalSpiritPowerLesser = "2dfa6298-f5f6-4626-a7ae-af055577191c";
        internal const string MarshalSpiritPowerIntermediate = "f8d0da23-e0e5-4b29-bfea-850e051f8f71";
        internal const string MarshalSpiritPowersGreater = "7227c103-261d-4edb-8656-da401a9bbdb8";
        internal const string MarshalSpiritPowersSupreme = "ef9431bd-92bf-40f6-b42a-a73b97cc1b8b";
        internal const string MarshalSpiritInfluencePenalty = "56988226-9ea1-4997-8e50-92e0ab2e99d3";
        internal const string MarshalTaboo = "51824956-52c4-49e7-a7ab-09edc0593ef1";

        internal const string Trickster = "856499e9-37af-4896-a250-fb2793e3ec0b";
        internal const string TricksterSeance = "d7f89ebb-23e8-4dbc-b12e-09be1257a33b";
        internal const string TricksterSpiritBonus = "cb0aef0f-af43-424e-a6da-4ee147faef7a";
        internal const string TricksterSpiritPowers = "9d39c747-74c8-40d8-ad8a-e5b3aea53c51";
        internal const string TricksterSpiritPowerLesser = "dc907001-c837-47f0-9289-de37153a5f64";
        internal const string TricksterSpiritPowerIntermediate = "32fa73e7-9c39-4b8c-8199-27ba0a1fde86";
        internal const string TricksterSpiritPowersGreater = "b28ffeeb-c942-4b74-980e-a9a070eae947";
        internal const string TricksterSpiritPowersSupreme = "9af14132-a973-4d60-8eaa-108996cdbbe3";
        internal const string TricksterSpiritInfluencePenalty = "530ba9b1-f966-42d2-a202-9af6ff6b86bf";
        internal const string TricksterTaboo = "33cfdc8e-c0ba-4262-a6f5-d04032c3948d";

        #endregion

        internal static readonly (string guid, string displayName)[] Archetypes =
          new (string, string)[]
          {
              (MediumClass, NewClasses.MediumClass.DisplayName),
          };
        #endregion

    }
}

