using AddedFeats.Feats;
using AddedFeats.NewSpells;
using BlueprintCore.Blueprints.Configurators.Root;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using System;
using UnityModManagerNet;
using static UnityModManagerNet.UnityModManager.ModEntry;
using AddedFeats.Utils;
using Kingmaker.PubSubSystem;
using AddedFeats.Homebrew;
using AddedFeats.NewClasses;

namespace AddedFeats
{
    [EnableReloading]
    public static class Main
    {
        public static bool Enabled;
        private static readonly ModLogger Logger = Logging.GetLogger(nameof(Main));
        //        private static readonly LogWrapper Logger = LogWrapper.Get("AddedFeats");

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                modEntry.OnUnload = Unload;
                var harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll();

                EventBus.Subscribe(new BlueprintCacheInitHandler());

                Logger.Log("Finished patching.");
            }
            catch (Exception e)
            {
                Logger.LogException("Failed to patch", e);
            }
            return true;
        }

        static bool Unload(UnityModManager.ModEntry modEntry)
        {
            try
            {
                var harmony = new Harmony(modEntry.Info.Id);
                harmony.UnpatchAll();
            }
            catch (Exception e)
            {
                Logger.LogException("Failed to unload.", e);
            }
            return true;
        }

        class BlueprintCacheInitHandler : IBlueprintCacheInitHandler
        {
            private static bool Initialized = false;
            private static bool InitializeDelayed = false;

            public void AfterBlueprintCachePatches()
            {
                try
                {
                    if (InitializeDelayed)
                    {
                        Logger.Log("Already initialized blueprints cache.");
                        return;
                    }
                    InitializeDelayed = true;

                    ConfigureFeatsDelayed();
                    ConfigureClassDelayed();

                    RootConfigurator.ConfigureDelayedBlueprints();
                }
                catch (Exception e)
                {
                    Logger.LogException("Delayed blueprint configuration failed.", e);
                }
            }

            public void BeforeBlueprintCachePatches()
            {

            }

            public void BeforeBlueprintCacheInit()
            {

            }

            public void AfterBlueprintCacheInit()
            {
                try
                {
                    if (Initialized)
                    {
                        Logger.Log("Already initialized blueprints cache.");
                        return;
                    }
                    Initialized = true;

                    // First strings
                    LocalizationTool.LoadEmbeddedLocalizationPacks(
                      "AddedFeats.Strings.Homebrew.json",
                      "AddedFeats.Strings.Archetypes.json",
                      "AddedFeats.Strings.ClassFeatures.json",
                      "AddedFeats.Strings.Features.json",
                      "AddedFeats.Strings.Settings.json",
                      "AddedFeats.Strings.Spells.json");

                    // Then settings
                    Settings.Init();

                    ConfigureHomebrew();
                    ConfigureFeats();
                    ConfigureSpells();
                }
                catch (Exception e)
                {
                    Logger.LogException("Failed to initialize.", e);
                }
            }
            private static void ConfigureHomebrew()
            {
                Logger.Log("Configuring homebrew.");
                MythicAnimalFocus.Configure();
            }
            private static void ConfigureClassDelayed()
            {
                Logger.Log("Configuring archetypes.");
                MediumClass.Configure();
            }
            private static void ConfigureClassFeats()
            {
                Logger.Log("Configuring class features.");
            }
            private static void ConfigureFeats()
            {
                Logger.Log("Configuring features.");
                PlanarFocus.Configure();
                FavoredAnimalFocusSelection.Configure();
                ForcefulCharge.Configure();
                ImprovedNaturalAttack.Configure();
                ImprovedNaturalArmor.Configure();
                EvolvedCompanion.Configure();
                VampiricCompanion.Configure();
                SpiritsGift.Configure();
                ShareSpells.Configure();
            }
            private static void ConfigureSpells()
            {
                Logger.Log("Configuring spells.");
                StrongJaw.Configure();
                Atavism.Configure();
            }
            private static void ConfigureFeatsDelayed()
            {
                Logger.Log("Configuring delayed.");
                TotemBeast.Configure();
            }
        }
    }
}

