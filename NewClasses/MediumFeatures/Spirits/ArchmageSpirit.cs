using AddedFeats.Utils;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
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
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace AddedFeats.NewClasses.MediumFeatures.Spirits
{
    class ArchmageSpirit : IBaseSpirit
    {
        private static readonly string FeatName = "ArchmageSpirit";
        private static readonly string DisplayName = "Archmage.Name";
        private static readonly string Description = "Archmage.Description";

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

        private BlueprintCharacterClass _medium = BlueprintTool.Get<BlueprintCharacterClass>(Guids.MediumClass);

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        public void ConfigureDisabled() { return; }

        public void ConfigureEnabled()
        {
            this.SpiritBonus();
            this.SeanceBoon();
            this.SpiritPowers();
            //this.InfluencePenalty();
            //this.Taboo();

            BuffConfigurator.For(spiritpowers)
                .SetFxOnStart("a68e191c519cae741b6c4177b4d13ef6")
                .AddFeatureIfHasFact(checkedFact: BlueprintTool.Get<BlueprintFeature>(Guids.SpiritPowerLesser), feature: lesserpower)
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

        public void SpiritPowers()
        {
            BuffConfigurator.For(lesserpower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                //Placeholders
                .AddSpellKnownTemporary(_medium, 0, true, AbilityRefs.Jolt.Reference.Get())
                .AddSpellKnownTemporary(_medium, 1, true, AbilityRefs.MageArmor.Reference.Get())
                .AddSpellKnownTemporary(_medium, 2, true, AbilityRefs.SenseVitals.Reference.Get())
                .AddSpellKnownTemporary(_medium, 3, true, AbilityRefs.Haste.Reference.Get())
                .AddSpellKnownTemporary(_medium, 4, true, AbilityRefs.Heal.Reference.Get())
                .AddSpellKnownTemporary(_medium, 5, true, AbilityRefs.CatsGraceMass.Reference.Get())
                .AddSpellKnownTemporary(_medium, 6, true, AbilityRefs.Shapechange.Reference.Get())
                .Configure();

            BuffConfigurator.For(intermediatepower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
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
    }
}
