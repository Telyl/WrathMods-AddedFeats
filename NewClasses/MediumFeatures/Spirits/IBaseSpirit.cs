using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddedFeats.NewClasses.MediumFeatures.Spirits
{
    interface IBaseSpirit
    {
        public abstract BlueprintActivatableAbility ability { get; }
        public abstract BlueprintBuff seanceboon { get; }
        public abstract BlueprintBuff spiritbonus { get; }
        public abstract BlueprintBuff spiritpowers { get; }
        public abstract BlueprintBuff lesserpower { get; }
        public abstract BlueprintBuff intermediatepower { get; }
        public abstract BlueprintBuff greaterpower { get; }
        public abstract BlueprintBuff supremepower { get; }
        public abstract BlueprintBuff influencepenalty { get; }

        public abstract void SpiritBonus();

        public abstract void SpiritPowers();

        public abstract void SeanceBoon();

        public abstract void InfluencePenalty();

        public abstract void Taboo();

        public abstract void ConfigureEnabled();

        public abstract void ConfigureDisabled();
    }

}
