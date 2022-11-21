using AddedFeats.Utils;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
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
    class HierophantSpirit : IBaseSpirit
    {
        private static readonly string FeatName = "HierophantSpirit";
        private static readonly string DisplayName = "Hierophant.Name";
        private static readonly string Description = "Hierophant.Description";

        private UnityEngine.Sprite _icon = AbilityRefs.CavalierForTheFaithAbility.Reference.Get().Icon;
        
        private BlueprintActivatableAbility _ability = ActivatableAbilityConfigurator.New(FeatName, Guids.Hierophant).Configure();
        public BlueprintActivatableAbility ability => this._ability;

        private BlueprintBuff _seanceboon = BuffConfigurator.New(FeatName + "Seance", Guids.HierophantSeance).Configure();
        public BlueprintBuff seanceboon=> this._seanceboon;

        private BlueprintBuff _spiritbonus = BuffConfigurator.New(FeatName + "Bonus", Guids.HierophantSpiritBonus).Configure();
        public BlueprintBuff spiritbonus => this._spiritbonus;

        private BlueprintBuff _spiritpowers = BuffConfigurator.New(FeatName + "Powers", Guids.HierophantSpiritPowers).Configure();
        public BlueprintBuff spiritpowers => this._spiritpowers;

        private BlueprintBuff _lesserpower = BuffConfigurator.New(FeatName + "Lesser", Guids.HierophantSpiritPowerLesser).Configure();
        public BlueprintBuff lesserpower => this._lesserpower;

        private BlueprintBuff _intermediatepower = BuffConfigurator.New(FeatName + "Intermediate", Guids.HierophantSpiritPowerIntermediate).Configure();
        public BlueprintBuff intermediatepower => this._intermediatepower;

        private BlueprintBuff _greaterpower = BuffConfigurator.New(FeatName + "Greater", Guids.HierophantSpiritPowersGreater).Configure();
        public BlueprintBuff greaterpower => this._greaterpower;

        private BlueprintBuff _supremepower = BuffConfigurator.New(FeatName + "Supreme", Guids.HierophantSpiritPowersSupreme).Configure();
        public BlueprintBuff supremepower => this._supremepower;

        private BlueprintBuff _influencepenalty = BuffConfigurator.New(FeatName + "InfluencePenalty", Guids.HierophantSpiritInfluencePenalty).Configure();
        public BlueprintBuff influencepenalty => this._influencepenalty;

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

            ActivatableAbilityConfigurator.For(Guids.Hierophant)
                .SetIcon(_icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetBuff(spiritpowers)
                .SetGroup((ActivatableAbilityGroup)677)
                .Configure();
        }

        /// <summary>
        /// Hierophant Influence Penalty
        /// 
        /// </summary>
        public void InfluencePenalty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Hierophant Seance Boon
        /// Your healing spells and abilities heal an additional 2 points of damage to each target. This does not affect healing conferred by magic items, nor does it add to fast healing or similar effects.
        /// </summary>
        public void SeanceBoon()
        {
            //Any other seancebuff = seance for Marshal.
            BuffConfigurator.For(seanceboon)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .AddIncreaseSpellHealing(2)
                .Configure();
        }

        /// <summary>
        /// Hierophant Spirit Bonus
        /// When you channel a Hierophant, your spirit bonus applies on attack rolls, non-spell damage rolls, Strength checks, Strength-based skill checks, and Fortitude saves.
        /// </summary>
        public void SpiritBonus()
        {
            BuffConfigurator.For(spiritbonus)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .AddContextStatBonus(StatType.SkillPersuasion, value: new ContextValue()
                {
                    ValueType = ContextValueType.Rank
                }, ModifierDescriptor.Other)
                .AddContextStatBonus(StatType.SkillUseMagicDevice, value: new ContextValue()
                {
                    ValueType = ContextValueType.Rank
                }, ModifierDescriptor.Other)
                // ADD SPIRIT SURGE COMPONENT Later
                //.AddComponent<SpiritSurge>()
                .AddContextRankConfig(
                    ContextRankConfigs.FeatureRank(Guids.SpiritBonusFeat, max: 20, min: 1))
                .Configure();
        }

        public void SpiritPowers()
        {
            BuffConfigurator.For(lesserpower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .AddTemporaryFeat(FeatureRefs.MartialWeaponProficiency.Reference.Get())
                .AddTemporaryFeat(FeatureRefs.StarknifeProficiency.Reference.Get())
                .Configure();

            BuffConfigurator.For(intermediatepower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .AddBuffExtraAttack(false, number: 1, penalized: false) // May need to create my own component on this to not work with greaterpower.
                .Configure();

            BuffConfigurator.For(greaterpower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .AddTemporaryFeat(FeatureRefs.Pounce.Reference.Get())
                .Configure();

            BuffConfigurator.For(supremepower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                //.AddTemporaryFeat()
                //.AddTemporaryFeat()
                .Configure();
        }

        /// <summary>
        /// Hierophant Taboo
        /// you are superstitious about arcane spellcasting, so you must not be the willing target of arcane spells or
        /// abilities and you must attempt a Will saving throw against even harmless arcane spells and abilities.
        /// </summary>
        public void Taboo()
        {
            throw new NotImplementedException();
        }       
    }
}
