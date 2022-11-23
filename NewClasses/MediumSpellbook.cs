using AddedFeats.Utils;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace AddedFeats.NewClasses
{
    class MediumSpellbook
    {
        private static readonly string SpellbookName = "MediumSpellbook";
        internal const string DisplayName = "MediumClass.Name";
        private static readonly ModLogger Logger = Logging.GetLogger("MediumSpellBook");
        public static void ConfigureDisabled()
        {

        }
        
        // Taken from TTT-Core by Vek17
        public static SpellsLevelEntry CreateSpellLevelEntry(params int[] count)
        {
            var entry = new SpellsLevelEntry
            {
                Count = count
            };
            return entry;
        }

        public static void ConfigureSpellSlotsTable()
        {
            SpellsTableConfigurator.New(SpellbookName + "SpellSlotsTable", Guids.MediumSpellbookSpellSlotsTable)
                .SetLevels(new SpellsLevelEntry[] {
                        CreateSpellLevelEntry(0),
                        CreateSpellLevelEntry(0),
                        CreateSpellLevelEntry(0),
                        CreateSpellLevelEntry(0),
                        CreateSpellLevelEntry(0,1),
                        CreateSpellLevelEntry(0,1),
                        CreateSpellLevelEntry(0,1),
                        CreateSpellLevelEntry(0,1,1),
                        CreateSpellLevelEntry(0,1,1),
                        CreateSpellLevelEntry(0,2,1),
                        CreateSpellLevelEntry(0,2,1,1),
                        CreateSpellLevelEntry(0,2,1,1),
                        CreateSpellLevelEntry(0,2,2,1),
                        CreateSpellLevelEntry(0,3,2,1,1),
                        CreateSpellLevelEntry(0,3,2,1,1),
                        CreateSpellLevelEntry(0,3,2,2,1),
                        CreateSpellLevelEntry(0,3,3,2,1),
                        CreateSpellLevelEntry(0,4,3,2,1),
                        CreateSpellLevelEntry(0,4,3,2,2),
                        CreateSpellLevelEntry(0,4,3,3,2),
                        CreateSpellLevelEntry(0,4,4,3,2) 
                })
                .Configure();

            SpellsTableConfigurator.New("SpiritChanneledSpellSlotsTable", Guids.MediumSpellbookSpellSlotsTableSpirit)
                .SetLevels(new SpellsLevelEntry[] {
                        CreateSpellLevelEntry(1),
                        CreateSpellLevelEntry(2),
                        CreateSpellLevelEntry(3),
                        CreateSpellLevelEntry(3,1),
                        CreateSpellLevelEntry(4,2),
                        CreateSpellLevelEntry(4,3),
                        CreateSpellLevelEntry(4,3,1),
                        CreateSpellLevelEntry(4,4,2),
                        CreateSpellLevelEntry(5,4,3),
                        CreateSpellLevelEntry(5,4,3),
                        CreateSpellLevelEntry(5,4,4,2),
                        CreateSpellLevelEntry(5,5,4,3),
                        CreateSpellLevelEntry(5,5,4,3,1),
                        CreateSpellLevelEntry(5,5,4,3,1),
                        CreateSpellLevelEntry(5,5,4,4,2),
                        CreateSpellLevelEntry(5,5,5,4,3),
                        CreateSpellLevelEntry(5,5,5,4,3,1),
                        CreateSpellLevelEntry(5,5,5,4,4,2),
                        CreateSpellLevelEntry(5,5,5,5,4,3),
                        CreateSpellLevelEntry(5,5,5,5,5,4),
                        CreateSpellLevelEntry(5,5,5,5,5,5)
                })
                .Configure();


        }

        public static void ConfigureSpellsKnownTable()
        {
            SpellsTableConfigurator.New(SpellbookName + "SpellKnownTable", Guids.MediumSpellbookSpellsKnownTable)
                .SetLevels(new SpellsLevelEntry[] {
                        CreateSpellLevelEntry(0),
                        CreateSpellLevelEntry(0),
                        CreateSpellLevelEntry(0),
                        CreateSpellLevelEntry(0),
                        CreateSpellLevelEntry(0,2),
                        CreateSpellLevelEntry(0,3),
                        CreateSpellLevelEntry(0,4),
                        CreateSpellLevelEntry(0,4,2),
                        CreateSpellLevelEntry(0,4,3),
                        CreateSpellLevelEntry(0,5,4),
                        CreateSpellLevelEntry(0,5,4,2),
                        CreateSpellLevelEntry(0,5,4,3),
                        CreateSpellLevelEntry(0,6,5,4),
                        CreateSpellLevelEntry(0,6,5,4,2),
                        CreateSpellLevelEntry(0,6,5,4,3),
                        CreateSpellLevelEntry(0,6,6,5,4),
                        CreateSpellLevelEntry(0,6,6,5,4),
                        CreateSpellLevelEntry(0,6,6,5,4),
                        CreateSpellLevelEntry(0,6,6,6,5),
                        CreateSpellLevelEntry(0,6,6,6,5),
                        CreateSpellLevelEntry(0,6,6,6,5)
                    })
                .Configure();
        }

        public static SpellLevelList Create0thLevelSpells()
        {
            var spelllist = new SpellLevelList(0);
            spelllist.m_Spells = new() {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Daze.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Flare.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Guidance.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.MageLight.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Resistance.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Stabilize.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Virtue.ToString()),

            };
            return spelllist;
        }
        public static SpellLevelList Create1stLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(1);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Command.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CauseFear.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.EarPiercingScream.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.EnlargePerson.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ExpeditiousRetreat.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ReducePerson.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.RemoveFear.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SummonMonsterISingle.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.TrueStrike.ToString())
            };
            if (Settings.IsTTTBaseEnabled())
            {
                Logger.Log("I am in TTTBaseEnabled"); 
                string LongArmBuff = "d6a18709-af1b-4600-89c3-ce336373c4f7";
                var TTTSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(LongArmBuff);
                spelllist.m_Spells.Append<BlueprintAbilityReference>(TTTSpell);
            }
            return spelllist;
        }
        public static SpellLevelList Create2ndLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(2);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Aid.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BearsEndurance.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BestowCurse.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Blur.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BullsStrength.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CatsGrace.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.EaglesSplendor.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.FalseLife.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.FindTraps.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.FoxsCunning.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Haste.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Heroism.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.HideousLaughter.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Invisibility.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.MirrorImage.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.OwlsWisdom.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Slow.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SummonMonsterIIBase.ToString())
            };
            return spelllist;
        }
        public static SpellLevelList Create3rdLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(3);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DimensionDoor.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DispelMagic.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Displacement.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.FalseLifeGreater.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.InvisibilityGreater.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.PhantasmalKiller.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.RemoveCurse.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SummonMonsterIVBase.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.VampiricTouch.ToString()),
            };
            return spelllist;
        }
        public static SpellLevelList Create4thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(4);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BreakEnchantment.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CommandGreater.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DeathWard.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Dismissal.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Fear.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.FreedomOfMovement.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.PhantasmalPutrefaction.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SummonMonsterVBase.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.TrueSeeing.ToString())
            };
            return spelllist;
        }


        public static void CreateSpellList()
        {
            SpellListConfigurator.New(SpellbookName + "SpellsList", Guids.MediumSpellList)
                .AddToSpellsByLevel(Create0thLevelSpells(), 
                Create1stLevelSpells(), 
                Create2ndLevelSpells(), 
                Create3rdLevelSpells(), 
                Create4thLevelSpells())
                .Configure();
        }

        public static BlueprintSpellbook ConfigureEnabled()
        {
            ConfigureSpellSlotsTable();
            ConfigureSpellsKnownTable();
            CreateSpellList();
            return SpellbookConfigurator.New(SpellbookName, Guids.MediumSpellbook)
                .SetName(DisplayName)
                .SetCharacterClass(Guids.MediumClass)
                .SetSpellsPerDay(Guids.MediumSpellbookSpellSlotsTable)
                .SetSpellsKnown(Guids.MediumSpellbookSpellsKnownTable)
                .SetSpellList(Guids.MediumSpellList)
                .SetCastingAttribute(Kingmaker.EntitySystem.Stats.StatType.Charisma)
                .SetIsMythic(false)
                .SetSpontaneous(true)
                .SetCantripsType(CantripsType.Orisions)
                .SetIsArcane(false)
                .SetIsArcanist(false)
                .SetCanCopyScrolls(false)
                .SetAllSpellsKnown(false)
                .SetCasterLevelModifier(0)
                .Configure();
        }
    }   
}
