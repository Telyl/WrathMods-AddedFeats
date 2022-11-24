using AddedFeats.Utils;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.AVEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace AddedFeats.NewClasses.MediumFeatures.Spirits
{
    class HierophantSpirit : IBaseSpirit, ICasterSpirit
    {
        private static readonly string FeatName = "HierophantSpirit";
        private static readonly string DisplayName = "Hierophant.Name";
        private static readonly string Description = "Hierophant.Description";
        private static readonly string SpellbookName = "HierophantSpellbook.Name";
        private static readonly string ChannelEnergy = "HierophantChannelEnergy.Name";
        private static readonly string ChannelEnergyDescription= "HierophantChannelEnergy.Description";
        private static readonly string OverflowingGrace = "HierophantOverflowingGrace.Name";
        private static readonly string OverflowingGraceDescription = "HierophantOverflowingGrace.Description";

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

        private BlueprintSpellbook _spellbook = SpellbookConfigurator.New(FeatName + "SpellBook", Guids.HierophantSpellbook).Configure();
        public BlueprintSpellbook spellbook => this._spellbook;

        private BlueprintFeature _spellbookfeat = FeatureConfigurator.New(FeatName + "SpellBookFeature", Guids.HierophantSpellbookFeat).Configure();
        public BlueprintFeature spellbookfeat => this._spellbookfeat;

        private BlueprintProgression _progression = ProgressionConfigurator.New(FeatName + "Progression", Guids.HierophantProgression).Configure();
        public BlueprintProgression progression => this._progression;

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        public void ConfigureDisabled() { return; }

        public void ConfigureEnabled()
        {
            this.SpiritBonus();
            this.SeanceBoon();
            // Create Lesser Spirit Power
            this.SpellBook();
            this.SpellBookFeature();
            // Create Intermediate Spirit Power
            this.CreateChannelEnergy();
            // Create Greater Spirit Power
            this.CreateOverflowingGrace();
            this.SpiritPowers();
            
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
                .AddContextStatBonus(StatType.SkillLoreNature, value: new ContextValue()
                {
                    ValueType = ContextValueType.Rank
                }, ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.SkillLoreReligion, value: new ContextValue()
                {
                    ValueType = ContextValueType.Rank
                }, ModifierDescriptor.UntypedStackable)
                .AddContextStatBonus(StatType.SkillPerception, value: new ContextValue()
                {
                    ValueType = ContextValueType.Rank
                }, ModifierDescriptor.UntypedStackable)
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
                .Configure();

            BuffConfigurator.For(intermediatepower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)

                .AddTemporaryFeat(Guids.HierophantChannelEnergyFeature)
                .AddSpellKnownTemporary(Guids.MediumClass, 1, true, AbilityRefs.CureLightWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.MediumClass, 1, true, AbilityRefs.InflictLightWounds.Reference.Get())

                .AddSpellKnownTemporary(Guids.MediumClass, 2, true, AbilityRefs.CureModerateWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.MediumClass, 2, true, AbilityRefs.InflictModerateWounds.Reference.Get())

                .AddSpellKnownTemporary(Guids.MediumClass, 3, true, AbilityRefs.CureSeriousWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.MediumClass, 3, true, AbilityRefs.InflictSeriousWounds.Reference.Get())

                .AddSpellKnownTemporary(Guids.MediumClass, 4, true, AbilityRefs.CureCriticalWounds.Reference.Get())
                .AddSpellKnownTemporary(Guids.MediumClass, 4, true, AbilityRefs.InflictCriticalWounds.Reference.Get())
                .Configure();

            BuffConfigurator.For(greaterpower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .AddTemporaryFeat(Guids.HierophantOverflowingGrace)
                .Configure();

            BuffConfigurator.For(supremepower)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
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


        /// <summary>
        /// Support function to configure spell slots.
        /// </summary>
        public void ConfigureSpellSlotsTable()
        {
            SpellsTableConfigurator.New(FeatName + "SpellSlotsTable", Guids.HierophantSpellSlotsTable)
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

        /// <summary>
        /// Support function to configure spells per day.
        /// </summary>
        public void ConfigureSpellsPerDayTable()
        {
            SpellsTableConfigurator.New(FeatName + "SpellPerDayTable", Guids.HierophantSpellPerDayTable)
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

        /// <summary>
        /// Intermediate Spirit Power (Hierophant)
        /// You can channel energy a number of times per day equal to 1 + your Charisma modifier. 
        /// Choose whether you channel positive or negative energy each time you contact a hierophant spirit; this choice must match the spirit’s faith. 
        /// If you choose positive energy, add cure spells of each level you can cast from the cleric list to your medium spell list and spells known. 
        /// Otherwise, add inflict spells in the same way. These spells count as divine, as in the divine surge spirit power.
        /// 
        /// TODO: SELECTABLE CHANNEL ENERGY. CURRENTLY GIVES BOTH.
        /// </summary>
        private void CreateChannelEnergy()
        {
            // The resource for our channel energy, because we're fancy.
            var resource = AbilityResourceConfigurator.New(FeatName + "ChannelEnergyResource", Guids.HierophantChannelEnergyResource)
                .SetMaxAmount(new BlueprintAbilityResource.Amount {
                    BaseValue = 1,
                    IncreasedByLevel = false,
                    IncreasedByLevelStartPlusDivStep = false,
                    StartingLevel = 0,
                    StartingIncrease = 0,
                    LevelStep = 0,
                    PerStepIncrease = 0,
                    MinClassLevelIncrease = 0,
                    IncreasedByStat = true,
                    ResourceBonusStat = StatType.Charisma
            })
                .SetMax(10)
                .SetUseMax(false)
                .Configure();


            var posability = AbilityConfigurator.New(FeatName + "ChannelEnergy", Guids.HierophantChannelEnergy)
                .AddAbilityResourceLogic(amount: 1, requiredResource: Guids.HierophantChannelEnergyResource, isSpendResource: true, costIsCustom: false)
                .CopyFrom(AbilityRefs.ChannelEnergy, c => c is not (ContextRankConfig or AbilityResourceLogic))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { Guids.MediumClass }, type: default, max: 20, min: 0).WithDiv2Progression())
                .AddContextRankConfig(ContextRankConfigs.CustomProperty(type: AbilityRankType.DamageBonus, property: UnitPropertyRefs.MythicChannelProperty.ToString(), max: 20, min: 0))
                .Configure();

            var posharmability = AbilityConfigurator.New(FeatName + "ChannelEnergyPositiveHarm", Guids.HierophantChannelEnergyPositiveHarm)
                .AddAbilityResourceLogic(amount: 1, requiredResource: Guids.HierophantChannelEnergyResource, isSpendResource: true, costIsCustom: false)
                .CopyFrom(AbilityRefs.ChannelPositiveHarm, c => c is not (ContextRankConfig or AbilityResourceLogic))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { Guids.MediumClass }, type: default, max: 20, min: 0).WithDiv2Progression())
                .AddContextRankConfig(ContextRankConfigs.CustomProperty(type: AbilityRankType.DamageBonus, property: UnitPropertyRefs.MythicChannelProperty.ToString(), max: 20, min: 0))
                .Configure();

            var negability = AbilityConfigurator.New(FeatName + "ChannelNegativeEnergy", Guids.HierophantChannelNegativeEnergy)
                .AddAbilityResourceLogic(amount: 1, requiredResource: Guids.HierophantChannelEnergyResource, isSpendResource: true, costIsCustom: false)
                .CopyFrom(AbilityRefs.ChannelNegativeEnergy, c => c is not (ContextRankConfig or AbilityResourceLogic))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { Guids.MediumClass }, type: default, max: 20, min: 0).WithDiv2Progression())
                .AddContextRankConfig(ContextRankConfigs.CustomProperty(type: AbilityRankType.DamageBonus, property: UnitPropertyRefs.MythicChannelProperty.ToString(), max: 20, min: 0))
                .Configure();

            var neghealability = AbilityConfigurator.New(FeatName + "ChannelNegativeEnergyHeal", Guids.HierophantChannelNegativeEnergyHeal)
                .AddAbilityResourceLogic(amount: 1, requiredResource: Guids.HierophantChannelEnergyResource, isSpendResource: true, costIsCustom: false)
                .CopyFrom(AbilityRefs.ChannelNegativeHeal, c => c is not (ContextRankConfig or AbilityResourceLogic))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { Guids.MediumClass }, type: default, max: 20, min: 0).WithDiv2Progression())
                .AddContextRankConfig(ContextRankConfigs.CustomProperty(type: AbilityRankType.DamageBonus, property: UnitPropertyRefs.MythicChannelProperty.ToString(), max: 20, min: 0))
                .Configure();

            FeatureConfigurator.New(FeatName + "ChannelEnergyFeature", Guids.HierophantChannelEnergyFeature)
                .SetDisplayName(ChannelEnergy)
                .SetDescription(ChannelEnergyDescription)
                .AddToIsPrerequisiteFor(FeatureRefs.SelectiveChannel.Reference.Get())
                .AddAbilityResources(amount: 0, resource: resource, restoreAmount: true, restoreOnLevelUp: false, useThisAsResource: false)
                .AddFacts(new() { posability, posharmability, negability, neghealability })
                .Configure();
        }
        
        /// <summary>
        /// Greater Spirit Power (Hierophant)
        /// When you heal a creature to full hit points or a creature already at full hit points with your positive or negative energy, 
        /// that creature gains a +1 sacred bonus on attack rolls, skill checks, ability checks, and saving throws for 1 round. 
        /// The bonus is sacred if you use positive energy and profane if you use negative energy. 
        /// If you destroy or kill one or more creatures with positive or negative energy, 
        /// you gain a +1 bonus of the same type on attack rolls, skill checks, ability checks, and saving throws for 1 round.
        /// </summary>
        private void CreateOverflowingGrace()
        {

            BlueprintBuff overflowingbuff = BuffConfigurator.New(FeatName + "OverflowingGraceBuff", Guids.HierophantOverflowingGraceBuff)
                .SetDisplayName(OverflowingGrace)
                .SetDescription(OverflowingGraceDescription)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.AdditionalAttackBonus, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillAthletics, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillKnowledgeArcana, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillKnowledgeWorld, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillLoreNature, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillLoreReligion, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillMobility, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillPerception, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillPersuasion, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillStealth, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillThievery, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SkillUseMagicDevice, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SaveFortitude, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SaveReflex, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Sacred, stat: StatType.SaveWill, value: 1)
                .Configure();

            BlueprintBuff overflowingprofane = BuffConfigurator.New(FeatName + "OverflowingGraceBuffProfane", Guids.HierophantOverflowingGraceBuffProfane)
                .SetDisplayName(OverflowingGrace)
                .SetDescription(OverflowingGraceDescription)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.AdditionalAttackBonus, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillAthletics, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillKnowledgeArcana, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillKnowledgeWorld, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillLoreNature, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillLoreReligion, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillMobility, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillPerception, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillPersuasion, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillStealth, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillThievery, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SkillUseMagicDevice, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SaveFortitude, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SaveReflex, value: 1)
                .AddStatBonus(descriptor: ModifierDescriptor.Profane, stat: StatType.SaveWill, value: 1)
                .Configure();

            FeatureConfigurator.New(FeatName + "OverflowingGrace", Guids.HierophantOverflowingGrace)
                .SetDisplayName(OverflowingGrace)
                .SetDescription(OverflowingGraceDescription)
                .AddOverHealTrigger(maxValue: new ContextValue()
                {
                    Value = 1,
                }, limitMaximum: true, actionOnTarget: ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsAlly().HasFact(FeatureRefs.NegativeEnergyAffinity.Reference.Get(), true),
                    ifTrue: ActionsBuilder.New().ApplyBuff(buff: overflowingbuff, asChild: true, isFromSpell: false, isNotDispelable: true, toCaster: true, durationValue: ContextDuration.Fixed(1, DurationRate.Rounds))))
                .AddOverHealTrigger(maxValue: new ContextValue()
                {
                    Value = 1,
                }, limitMaximum: true, actionOnTarget: ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsAlly().HasFact(FeatureRefs.LifeDominantSoul.Reference.Get()),
                    ifTrue: ActionsBuilder.New().ApplyBuff(buff: overflowingbuff, asChild: true, isFromSpell: false, isNotDispelable: true, toCaster: true, durationValue: ContextDuration.Fixed(1, DurationRate.Rounds))))
                .AddOverHealTrigger(maxValue: new ContextValue()
                {
                    Value = 1,
                }, limitMaximum: true, actionOnTarget: ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsAlly().HasFact(FeatureRefs.NegativeEnergyAffinity.Reference.Get()), 
                    ifTrue: ActionsBuilder.New().ApplyBuff(buff: overflowingprofane, asChild: true, isFromSpell: false, isNotDispelable: true, toCaster: true, durationValue: ContextDuration.Fixed(1, DurationRate.Rounds))))
                .Configure();
        }

        /// <summary>
        /// Creates the spirit spellbook.
        /// </summary>
        public void SpellBook()
        {
            ConfigureSpellsPerDayTable();
            ConfigureSpellSlotsTable();

            SpellbookConfigurator.For(spellbook)
                .SetName(SpellbookName)
                .SetSpellsPerDay(BlueprintTool.GetRef<BlueprintSpellsTableReference>(Guids.HierophantSpellPerDayTable))
                .SetSpellSlots(BlueprintTool.GetRef<BlueprintSpellsTableReference>(Guids.HierophantSpellSlotsTable))
                .SetSpellList(SpellListRefs.ClericSpellList.Reference.Get())
                .SetCastingAttribute(StatType.Charisma)
                .SetAllSpellsKnown(true)
                .SetIsMythic(false)
                .SetSpontaneous(true)
                .SetCantripsType(CantripsType.Cantrips)
                .SetIsArcane(false)
                .SetIsArcanist(true)
                .SetCanCopyScrolls(false)
                .SetCasterLevelModifier(0)
                .Configure();
        }

        /// <summary>
        /// Creates a spellbook feature with the medium class level as the caster level for context rank config.
        /// This gives us the ability to dynamically update our spirit's spellbook.
        /// </summary>
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
    }
}