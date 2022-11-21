using BlueprintCore.Utils;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.ResourceLinks;
using System;
using Kingmaker.Utility;
using Kingmaker.Enums;
using Kingmaker.Blueprints.Facts;
using static UnityModManagerNet.UnityModManager.ModEntry;
using AddedFeats.Utils;


namespace AddedFeats.NewComponents
{
    [TypeId("cb6f3cb3cc1f45909e5eab27177c1668")]
    public class SpiritSurge : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCanApplyBuff>, IRulebookHandler<RuleCanApplyBuff>, ISubscriber, IInitiatorRulebookSubscriber, IResourcesHolder
    {
        private static readonly ModLogger Logger = Logging.GetLogger("Spirit");
        // The spirit buffs tell us which one is active.
        private static BlueprintUnitFact _archmageBuff, _championBuff, _guardianBuff, hierophantBuff, marshalBuff;
        // Get the spirit bonus we have.
        private static BlueprintUnitFact _spiritBonus;
        private static BlueprintUnitFact ArchmageBuff
        {
            get
            {
                _archmageBuff ??= BlueprintTool.Get<BlueprintUnitFact>(Guids.ArchmageSpiritBonus);
                return _archmageBuff;
            }
        }
        public void OnEventDidTrigger(RuleCanApplyBuff evt)
        {

        }

        public void OnEventAboutToTrigger(RuleCanApplyBuff evt)
        {
            UnitEntityData caster = evt.Reason.Caster;
            Logger.Log(evt.Reason.Ability.Name);

            // Check if it's an Archmage Spirit
            if (caster.Descriptor.HasFact(ArchmageBuff))
            {
                //caster.Descriptor.AddBuff(
            }
        }
    }
}

