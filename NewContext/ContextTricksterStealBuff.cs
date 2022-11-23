using System;
using System.Collections.Generic;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.Utility;
using Owlcat.Runtime.Core.Utils;
using UnityEngine;

namespace Kingmaker.UnitLogic.Mechanics.Actions
{

	// Most of this taken directly from ShadowBalorNahindry_Features and Owlcat.
	// Token: 0x02001DA8 RID: 7592
	[TypeId("3ab418e90b104a859d422f7157836f0f")]
	public class ContextActionStealBuffs : ContextAction
	{
		// Token: 0x0600C9BE RID: 51646 RVA: 0x003462C0 File Offset: 0x003444C0
		public override string GetCaption()
		{
			return "Remove all specified buffs and apply them to caster";
		}

		// Token: 0x0600C9BF RID: 51647 RVA: 0x003462C8 File Offset: 0x003444C8
		public override void RunAction()
		{
			if (base.Target.Unit == null)
			{
				PFLog.Default.Error("Target unit is missing", Array.Empty<object>());
				return;
			}
			UnitEntityData maybeCaster = base.Context.MaybeCaster;
			if (maybeCaster == null)
			{
				PFLog.Default.Error("Caster is missing", Array.Empty<object>());
				return;
			}
			List<Buff> list = base.Target.Unit.Buffs.Enumerable.ToTempList<Buff>();
			List<Buff> list2 = TempList.Get<Buff>();
			foreach (Buff buff in list)
			{
				if (buff.Blueprint.SpellDescriptor.HasAnyFlag(this.m_Descriptor))
				{
					list2.Add(buff);
					base.Target.Unit.Buffs.RemoveFact(buff);
				}
			}
			foreach (Buff buff2 in list2)
			{
				if (string.IsNullOrEmpty(buff2.SourceAreaEffectId))
				{
					Buff buff3 = maybeCaster.Buffs.AddBuff(buff2.Blueprint, buff2.Context.ParentContext, (!buff2.IsPermanent) ? new TimeSpan?(buff2.TimeLeft) : null);
					if (buff3 != null && buff2.IsPermanent)
					{
						buff3.MakePermanent();
					}
				}
			}
		}

		// Token: 0x0400866C RID: 34412
		[SerializeField]
		[InfoBox("Target buff should have at least one of the descriptors to be stolen")]
		private SpellDescriptorWrapper m_Descriptor;
	}
}