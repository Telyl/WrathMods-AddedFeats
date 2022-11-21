using AddedFeats.Utils;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddedFeats.NewClasses.MediumFeatures
{
    class Influence
    {
        private static readonly string FeatName = "Influence";

        private BlueprintAbility _influenceability = AbilityConfigurator.New(FeatName + "Ability", Guids.InfluenceAbility).Configure();
        public BlueprintAbility influenceability => this._influenceability;
    }
}
