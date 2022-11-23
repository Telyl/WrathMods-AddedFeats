using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddedFeats.NewClasses.MediumFeatures.Spirits
{
    interface ICasterSpirit
    {
        public abstract BlueprintSpellbook spellbook { get; }
        public abstract BlueprintFeature spellbookfeat { get; }

        public abstract void ConfigureSpellsPerDayTable();
        
        public abstract void ConfigureSpellSlotsTable();

        public abstract void SpellBook();

        public abstract void SpellBookFeature();
    }

}
