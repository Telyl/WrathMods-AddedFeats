using AddedFeats.NewClasses.MediumFeatures.Spirits;
using AddedFeats.Utils;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;


// This will be an activatable ability similar to hunter foci. This way I can add "Legendary Spirits" if I want to later.
namespace AddedFeats.NewClasses.MediumFeatures
{
    class Spirit
    {
        private static readonly string FeatName = "Spirit";
        private static readonly string DisplayName = "Spirit.Name";
        private static readonly string Description = "Spirit.Description";

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);
        public static void ConfigureDisabled()
        {
            new ArchmageSpirit();
            new ChampionSpirit();
            new GuardianSpirit();
            new HierophantSpirit();
            new MarshalSpirit();
            new TricksterSpirit();
            FeatureConfigurator.New(FeatName, Guids.Spirit).Configure();
        }

        public static BlueprintFeature ConfigureEnabled()
        {

            BlueprintAbilityResource resources = AbilityResourceConfigurator.New(FeatName + "Resource", Guids.SpiritResource)
                .SetMaxAmount(ResourceAmountBuilder.New(2).Build())
                .SetMin(0)
                .Configure();

            var ArchmageSpirit = new ArchmageSpirit();
            ArchmageSpirit.ConfigureEnabled();
            var ChampionSpirit = new ChampionSpirit();
            ChampionSpirit.ConfigureEnabled();
            var GuardianSpirit = new GuardianSpirit();
            GuardianSpirit.ConfigureEnabled();
            var HierophantSpirit = new HierophantSpirit();
            HierophantSpirit.ConfigureEnabled();
            var MarshalSpirit = new MarshalSpirit();
            MarshalSpirit.ConfigureEnabled();
            var TricksterSpirit = new TricksterSpirit();
            TricksterSpirit.ConfigureEnabled();

            return FeatureConfigurator.New(FeatName, Guids.Spirit)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .AddAbilityResources(amount: 0, resource: resources, restoreAmount: true)
                .AddFacts(new() { ArchmageSpirit.ability, ChampionSpirit.ability, GuardianSpirit.ability, HierophantSpirit.ability, MarshalSpirit.ability, TricksterSpirit.ability})
                .Configure();
        }
    }
}
