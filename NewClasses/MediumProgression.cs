using AddedFeats.NewClasses.MediumFeatures;
using AddedFeats.Utils;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace AddedFeats.NewClasses
{
    class MediumProgression
    {
        private static readonly string ProgressionName = "MediumProgression";
        private static readonly ModLogger Logger = Logging.GetLogger(ProgressionName);

        public static void ConfigureDisabled()
        {
            ProgressionConfigurator.New(ProgressionName, Guids.MediumProgression)
                .Configure();
            MediumProficiencies.ConfigureDisabled();
            SpiritBonus.ConfigureDisabled();
            Spirit.ConfigureDisabled();

        }

        public static BlueprintProgression Configure()
        {
            BlueprintFeature mediumproficiencies = MediumProficiencies.ConfigureEnabled();
            BlueprintFeature spiritbonus = SpiritBonus.ConfigureEnabled();
            BlueprintFeature spiritpower = SpiritPower.ConfigureEnabled();
            BlueprintFeature spirit = Spirit.ConfigureEnabled();
            BlueprintFeature spiritsurge = SpiritSurge.ConfigureEnabled();

            var entries = LevelEntryBuilder.New()
                .AddEntry(1, spiritbonus, mediumproficiencies, spirit, spiritpower, spiritsurge)
                .AddEntry(4, spiritbonus)
                .AddEntry(6, spiritpower)
                .AddEntry(8, spiritbonus)
                .AddEntry(10, spiritsurge)
                .AddEntry(11, spiritpower)
                .AddEntry(12, spiritbonus)
                .AddEntry(16, spiritbonus)
                .AddEntry(17, spiritpower)
                .AddEntry(20, spiritbonus, spiritsurge);

            return ProgressionConfigurator.New(ProgressionName, Guids.MediumProgression)
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(false)
                .AddToClasses(Guids.MediumClass)
                .SetForAllOtherClasses(false)
                .SetLevelEntries(entries)
                .Configure();
        }
    }
}
