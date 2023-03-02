using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using BlueprintCore.Actions.Builder.BasicEx;
using AddedFeats.NewComponents;
using AddedFeats.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace AddedFeats.Feats.PlanarFoci
{
    /// <summary>
    /// Creates a feat that does nothing but show up.
    /// </summary>
    public class PlanarFocusEarth
    {
        private static readonly string FeatName = "PlanarFocusEarth";
        private static readonly string DisplayName = "PlanarFocusEarth.Name";
        private static readonly string Description = "PlanarFocusEarth.Description";
        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);
        public static void ConfigureDisabled()
        {
            BuffConfigurator.New(FeatName + "AnimalBuff", Guids.PlanarFocusEarthAnimalBuff).Configure();
            FeatureConfigurator.New(FeatName + "Effect", Guids.PlanarFocusEarthEffect).Configure();
            BuffConfigurator.New(FeatName + "AnimalBuffEffect", Guids.PlanarFocusEarthAnimalBuffEffect).Configure();
            BuffConfigurator.New(FeatName + "Buff", Guids.PlanarFocusEarthBuff).Configure();
            ActivatableAbilityConfigurator.New(FeatName, Guids.PlanarFocusEarth).Configure();
        }
        public static (BlueprintActivatableAbility, BlueprintBuff, BlueprintBuff) Configure()
        {
            /************************* Adds +2 Nat armor & Bullrush *************************/

            BlueprintBuff EarthAnimalBuff = PlanarFunctions.CreatePlanarFocusAnimalBuff(
                FeatName+"AnimalBuff", Guids.PlanarFocusEarthAnimalBuff, DisplayName, Description, AbilityRefs.Stoneskin.Reference.Get().Icon);


            BlueprintFeature EarthEffect = PlanarFunctions.CreatePlanarFocusEffect(
                FeatName+"Effect", Guids.PlanarFocusEarthEffect, DisplayName, EarthAnimalBuff);

            FeatureConfigurator.For(EarthEffect)
                .AddStatBonus(descriptor: ModifierDescriptor.NaturalArmorEnhancement, stat: StatType.AC, value: 2)
                .AddManeuverBonus(2, descriptor: ModifierDescriptor.Other, false, false, CombatManeuver.BullRush)
                .AddManeuverDefenceBonus(2, descriptor: ModifierDescriptor.Other, CombatManeuver.BullRush)
                .Configure();

            BlueprintBuff EarthAnimalBuffEffect = PlanarFunctions.CreatePlanarFocusBuffEffect(
                FeatName+"AnimalBuffEffect", Guids.PlanarFocusEarthAnimalBuffEffect, DisplayName, EarthEffect);

            BlueprintBuff EarthBuff = PlanarFunctions.CreatePlanarFocusBuff(
                FeatName+"Buff", Guids.PlanarFocusEarthBuff, DisplayName, AbilityRefs.Stoneskin.Reference.Get().Icon, EarthEffect, EarthAnimalBuffEffect);


            BlueprintActivatableAbility PF_Earth = PlanarFunctions.CreatePlanarFocusAbility(
                FeatName, Guids.PlanarFocusEarth, DisplayName, Description, AbilityRefs.Stoneskin.Reference.Get().Icon, EarthBuff);

            return (PF_Earth, EarthBuff, EarthAnimalBuffEffect);
        }
    }
}

