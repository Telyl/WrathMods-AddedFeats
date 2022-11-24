using AddedFeats.NewComponents;
using AddedFeats.Utils;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UI.AbilityTarget;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;
using AbilityRange = Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange;

namespace AddedFeats.NewClasses.MediumFeatures.Spirits
{
    class ArchmageSpirit : IBaseSpirit, ICasterSpirit
    {
        private static readonly string FeatName = "ArchmageSpirit";
        private static readonly string DisplayName = "Archmage.Name";
        private static readonly string Description = "Archmage.Description";
        private static readonly string SpellbookName = "ArchmageSpellbook.Name";

        private UnityEngine.Sprite _icon = AbilityRefs.DismissAreaEffect.Reference.Get().Icon;
        
        private BlueprintActivatableAbility _ability = ActivatableAbilityConfigurator.New(FeatName, Guids.Archmage).Configure();
        public BlueprintActivatableAbility ability => this._ability;

        private BlueprintBuff _seanceboon = BuffConfigurator.New(FeatName + "Seance", Guids.ArchmageSeance).Configure();
        public BlueprintBuff seanceboon=> this._seanceboon;

        private BlueprintBuff _spiritbonus = BuffConfigurator.New(FeatName + "Bonus", Guids.ArchmageSpiritBonus).Configure();
        public BlueprintBuff spiritbonus => this._spiritbonus;

        private BlueprintBuff _spiritpowers = BuffConfigurator.New(FeatName + "Powers", Guids.ArchmageSpiritPowers).Configure();
        public BlueprintBuff spiritpowers => this._spiritpowers;

        private BlueprintBuff _lesserpower = BuffConfigurator.New(FeatName + "Lesser", Guids.ArchmageSpiritPowerLesser).Configure();
        public BlueprintBuff lesserpower => this._lesserpower;

        private BlueprintBuff _intermediatepower = BuffConfigurator.New(FeatName + "Intermediate", Guids.ArchmageSpiritPowerIntermediate).Configure();
        public BlueprintBuff intermediatepower => this._intermediatepower;

        private BlueprintBuff _greaterpower = BuffConfigurator.New(FeatName + "Greater", Guids.ArchmageSpiritPowersGreater).Configure();
        public BlueprintBuff greaterpower => this._greaterpower;

        private BlueprintBuff _supremepower = BuffConfigurator.New(FeatName + "Supreme", Guids.ArchmageSpiritPowersSupreme).Configure();
        public BlueprintBuff supremepower => this._supremepower;

        private BlueprintBuff _influencepenalty = BuffConfigurator.New(FeatName + "InfluencePenalty", Guids.ArchmageSpiritInfluencePenalty).Configure();
        public BlueprintBuff influencepenalty => this._influencepenalty;

        private BlueprintSpellbook _spellbook = SpellbookConfigurator.New(FeatName + "SpellBook", Guids.ArchmageSpellbook).Configure();
        public BlueprintSpellbook spellbook => this._spellbook;

        private BlueprintFeature _spellbookfeat = FeatureConfigurator.New(FeatName + "SpellBookFeature", Guids.ArchmageSpellbookFeat).Configure();
        public BlueprintFeature spellbookfeat => this._spellbookfeat;

        private BlueprintProgression _progression = ProgressionConfigurator.New(FeatName + "Progression", Guids.ArchmageProgression).Configure();
        public BlueprintProgression progression => this._progression;

        private BlueprintCharacterClass _medium = BlueprintTool.Get<BlueprintCharacterClass>(Guids.MediumClass);

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        public void ConfigureDisabled() { return; }

        public void ConfigureEnabled()
        {
            this.SpiritBonus();
            this.SeanceBoon();
            this.ConfigureWildArcana();
            this.SpiritPowers();
            this.SpellBook();
            this.SpellBookFeature();
            //this.InfluencePenalty();
            //this.Taboo();

            BuffConfigurator.For(spiritpowers)
                .SetFxOnStart("a68e191c519cae741b6c4177b4d13ef6")
                .AddFeatureIfHasFact(checkedFact: BlueprintTool.Get<BlueprintFeature>(Guids.SpiritPowerLesser), feature: lesserpower)
                .AddFeatureIfHasFact(checkedFact: BlueprintTool.Get<BlueprintFeature>(Guids.SpiritPowerLesser), feature: spellbookfeat)
                .AddFeatureIfHasFact(checkedFact: BlueprintTool.Get<BlueprintFeature>(Guids.SpiritPowerIntermediate), feature: intermediatepower)
                .AddFeatureIfHasFact(checkedFact: BlueprintTool.Get<BlueprintFeature>(Guids.SpiritPowerGreater), feature: greaterpower)
                .AddFeatureIfHasFact(checkedFact: BlueprintTool.Get<BlueprintFeature>(Guids.SpiritPowerSupreme), feature: supremepower)
                .AddFeatureIfHasFact(checkedFact: BlueprintTool.Get<BlueprintFeature>(Guids.SpiritBonusFeat), feature: spiritbonus)
                .AddFeatureIfHasFact(checkedFact: BlueprintTool.Get<BlueprintFeature>(Guids.SpiritBonusFeat), feature: seanceboon)
                .Configure();

            ActivatableAbilityConfigurator.For(Guids.Archmage)
                .SetIcon(_icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetBuff(spiritpowers)
                .SetGroup((ActivatableAbilityGroup)677)
                .Configure();
        }

        /// <summary>
        /// Archmage Influence Penalty
        /// Your body begins to respond as if you were a frail, aged scholar. 
        /// You take a penalty equal to your spirit bonus on Strength checks, Strength-based skill checks, Constitution checks, attack rolls, and non-spell damage rolls.
        /// </summary>
        public void InfluencePenalty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Archmage Seance Boon
        /// Your damaging spells deal an additional 2 points of damage of the same type that they would normally deal to each target.
        /// </summary>
        public void SeanceBoon()
        {
            BuffConfigurator.For(seanceboon)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Arcane, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Acid, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Fire, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Cold, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Electricity, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Force, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.Sonic, spellsOnly: true, useContextBonus: true)
                .AddDraconicBloodlineArcana(value: 2, spellDescriptor: SpellDescriptor.None, spellsOnly: true, useContextBonus: true)
                .Configure();
        }

        /// <summary>
        /// Archmage Spirit Bonus
        /// When you channel an archmage, your spirit bonus applies on concentration checks, Intelligence checks, and Intelligence-based skill checks.
        /// </summary>
        public void SpiritBonus()
        {
            BuffConfigurator.For(spiritbonus)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .AddContextStatBonus(StatType.SkillKnowledgeArcana, value: new ContextValue()
                {
                    ValueType = ContextValueType.Rank
                }, ModifierDescriptor.Other)
                .AddContextStatBonus(StatType.SkillKnowledgeWorld, value: new ContextValue()
                {
                    ValueType = ContextValueType.Rank
                }, ModifierDescriptor.Other)
                .AddConcentrationBonus(value: new ContextValue() { ValueType = ContextValueType.Rank })
                .AddContextRankConfig(
                    ContextRankConfigs.FeatureRank(Guids.SpiritBonusFeat, max: 20, min: 1))
                .Configure();
        }

        /// <summary>
        /// Archmage Spirit Powers
        /// Lesser: 1 new spell per day and more spell levels
        /// Intermediate: Gain 1 influence to cast one of your medium spells known without expending a spell slot. When you do so, the caster level and DC of the spell increase by 1, and you can’t apply metamagic to the spell.
        /// Greater: Gain 1 influence to cast any sorcerer/wizard spell of a level you can cast. You must expend a spell slot of the appropriate level, and you can’t apply metamagic to the spell.
        /// Supreme: Once per day, cast any spell from the sorcerer/wizard spell list you can cast as if using wild arcana (greater). Doesn't require influence or spell slots.
        /// </summary>
        public void SpiritPowers()
        {

            BuffConfigurator.For(lesserpower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .Configure();

            BuffConfigurator.For(intermediatepower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .AddTemporaryFeat(Guids.ArchmageWildArcana)
                .Configure();

            BuffConfigurator.For(greaterpower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .Configure();

            BuffConfigurator.For(supremepower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .Configure();
        }

        /// <summary>
        /// Archmage Taboo
        /// You eschew all faith in the divine, so you must not be the willing target of divine spells or abilities and you must attempt a Will saving throw against even harmless divine spells and abilities;
        /// </summary>
        public void Taboo()
        {
            throw new NotImplementedException();
        }

        public void ConfigureWildArcana()
        {

            var ability = AbilityConfigurator.New(FeatName + "WildArcanaAbility", Guids.ArchmageWildArcanaAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.BloodlineArcaneItemBondAbility.Reference.Get().Icon)
                .SetRange(AbilityRange.Personal)
                .SetCanTargetSelf(true)
                .SetType(AbilityType.Supernatural)
                .SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Omni)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .SetIsFullRoundAction(false)
                .AddComponent<LegendaryArchmageComponent>(c =>
                {
                    c.AnySpellLevel = true;
                    c.CharacterClass = new BlueprintCharacterClassReference[]
                    {
                        BlueprintTool.GetRef<BlueprintCharacterClassReference>(Guids.MediumClass),
                    };
                })
                .Configure();

            FeatureConfigurator.New(FeatName + "WildArcana", Guids.ArchmageWildArcana)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { ability })
                .Configure();
        }

        public void ConfigureSpellSlotsTable()
        {
            SpellsTableConfigurator.New(FeatName + "SpellSlotsTable", Guids.ArchmageSpellSlotsTable)
                .SetLevels(new SpellsLevelEntry[] {
                    new SpellsLevelEntry{ Count = new int[] { 0 } },//0
                    new SpellsLevelEntry{ Count = new int[] { 0, 1 } },//1
                    new SpellsLevelEntry{ Count = new int[] { 0, 1 } },//2
                    new SpellsLevelEntry{ Count = new int[] { 0, 1 } },//3
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1 } },//4
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1 } },//5
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1 } },//6
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1 } },//7
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1 } },//8
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1 } },//9
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1 } },//10
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1 } },//11
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1 } },//12
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1 } },//13
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1 } },//14
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1 } },//15
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1 } },//16
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1 } },//17
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1 } },//18
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1 } },//19
                    new SpellsLevelEntry{ Count = new int[] { 0, 1, 1, 1, 1, 1, 1 } },//20
                    })
                .Configure();
        }

        public void ConfigureSpellsPerDayTable()
        {
            SpellsTableConfigurator.New(FeatName + "SpellPerDayTable", Guids.ArchmageSpellPerDayTable)
                .SetLevels(new SpellsLevelEntry[] {
                    new SpellsLevelEntry{ Count = new int[] { 0 } },//0
                    new SpellsLevelEntry{ Count = new int[] { 0, 1 } },//1
                    new SpellsLevelEntry{ Count = new int[] { 0, 2 } },//2
                    new SpellsLevelEntry{ Count = new int[] { 0, 3 } },//3
                    new SpellsLevelEntry{ Count = new int[] { 0, 3, 1 } },//4
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 2 } },//5
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 3 } },//6
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 3, 1 } },//7
                    new SpellsLevelEntry{ Count = new int[] { 0, 4, 4, 2 } },//8
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 4, 3 } },//9
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 4, 3, 1 } },//10
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 4, 4, 2 } },//11
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 4, 3 } },//12
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 4, 3, 1 } },//13
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 4, 4, 2 } },//14
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 4, 3 } },//15
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 4, 3, 1 } },//16
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 4, 4, 2 } },//17
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 5, 4, 3 } },//18
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 5, 5, 4 } },//19
                    new SpellsLevelEntry{ Count = new int[] { 0, 5, 5, 5, 5, 5, 5 } },//20
                    })
                .Configure();
        }

        public void SpellBook()
        {
            ConfigureSpellsPerDayTable();
            ConfigureSpellSlotsTable();

            SpellbookConfigurator.For(spellbook)
                .SetName(SpellbookName)
                .SetSpellsPerDay(BlueprintTool.GetRef<BlueprintSpellsTableReference>(Guids.ArchmageSpellPerDayTable))
                .SetSpellSlots(BlueprintTool.GetRef<BlueprintSpellsTableReference>(Guids.ArchmageSpellSlotsTable))
                .SetSpellList(SpellListRefs.WizardSpellList.Reference.Get())
                .SetCastingAttribute(StatType.Charisma)
                .SetAllSpellsKnown(true)
                .SetIsMythic(false)
                .SetSpontaneous(true)
                .SetCantripsType(CantripsType.Cantrips)
                .SetIsArcane(true)
                .SetIsArcanist(true)
                .SetCanCopyScrolls(false)
                .SetCasterLevelModifier(0)
                .Configure();
        }

        public void SpellBookFeature()
        {
            FeatureConfigurator.For(spellbookfeat)
                .AddSpellbook(casterLevel: new ContextValue()
                {
                    ValueType = ContextValueType.Rank,

                }, spellbook: spellbook)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { Guids.MediumClass }))
                .SetIsClassFeature(true)
                .SetHideInUI(true)
                .Configure();                
        }

        public void ConfigureProgression()
        {
            ProgressionConfigurator.For(progression)
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(false)
                .AddToClasses(Guids.MediumClass)
                .SetForAllOtherClasses(false)
                .Configure();
        }
    }
}
