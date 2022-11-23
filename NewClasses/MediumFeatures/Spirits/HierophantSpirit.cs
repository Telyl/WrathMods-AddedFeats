using AddedFeats.Utils;
using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
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

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        public void ConfigureDisabled() { return; }

        public void ConfigureEnabled()
        {
            this.SpiritBonus();
            this.SeanceBoon();
            //this.CreateChannelEnergy();
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
                .AddTemporaryFeat(FeatureRefs.ChannelEnergyFeature.Reference.Get())
                .AddTemporaryFeat(FeatureRefs.ChannelNegativeFeature.Reference.Get())
                //.AddTemporaryFeat(Guids.HierophantChannelEnergy)
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

        private BlueprintAbility CreateChannelEnergy()
        {
            return AbilityConfigurator.New(FeatName + "ChannelEnergy", Guids.HierophantChannelEnergy)
                .CopyFrom(AbilityRefs.ChannelEnergy.Reference.Get(),
                typeof(AbilityTargetsAround),
                typeof(AbilityEffectRunAction),
                typeof(AbilitySpawnFx),
                typeof(AbilityUseOnRest),
                typeof(SpellDescriptorComponent))
                .AddContextRankConfig(component: ContextRankConfigs.ClassLevel(new string[] { Guids.MediumClass }, type: default, max: 20, min: 0).WithOnePlusDiv2Progression())
                .AddContextRankConfig(component: ContextRankConfigs.CustomProperty(property: BlueprintTool.Get<BlueprintUnitProperty>("152e61de154108d489ff34b98066c25c").ToString(),
                type: AbilityRankType.DamageBonus, max: 20, min: 0))
                .AddContextCalculateSharedValue(modifier: 0.5, valueType: AbilitySharedValue.StatBonus, value: new ContextDiceValue()
                {
                    DiceType = DiceType.D6,
                    DiceCountValue =
                    {
                        ValueShared = AbilitySharedValue.Damage,
                        Value = 0,
                        ValueType = ContextValueType.Simple,
                        ValueRank = AbilityRankType.Default
                    },
                    BonusValue =
                    {
                        ValueType = ContextValueType.Shared,
                        Value = 0,
                        ValueRank = AbilityRankType.StatBonus,
                        ValueShared = AbilitySharedValue.Heal
                    }

                })
                .AddContextCalculateSharedValue(modifier: 1.0, valueType: AbilitySharedValue.Heal, value: new ContextDiceValue()
                {
                    DiceType = DiceType.D6,
                    DiceCountValue =
                    {
                        ValueShared = AbilitySharedValue.Damage,
                        Value = 0,
                        ValueType = ContextValueType.Rank,
                        ValueRank = AbilityRankType.Default
                    },
                    BonusValue =
                    {
                        ValueType = ContextValueType.Rank,
                        Value = 0,
                        ValueRank = AbilityRankType.DamageBonus,
                        ValueShared = AbilitySharedValue.Damage
                    }

                })
                .SetRange(AbilityRange.Personal)
                .SetType(AbilityType.Supernatural)
                .SetOnlyForAllyCaster(false)
                .SetCanTargetPoint(false)
                .SetCanTargetEnemies(false)
                .SetCanTargetFriends(true)
                .SetCanTargetSelf(true)
                .SetSpellResistance(false)
                .SetEffectOnAlly(AbilityEffectOnUnit.None)
                .SetEffectOnEnemy(AbilityEffectOnUnit.Harmful)
                .SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Omni)
                .SetHasFastAnimation(false)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .SetIsFullRoundAction(false)
                .Configure();
        }

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