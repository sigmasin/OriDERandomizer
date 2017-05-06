using System;
using Sein.World;

// Token: 0x0200098A RID: 2442
public class SetSeinWorldStateAction : ActionMethod
{
	// Token: 0x06003575 RID: 13685 RVA: 0x000DA54C File Offset: 0x000D874C
	public override void Perform(IContext context)
	{
		switch (this.State)
		{
		case WorldState.WaterPurified:
			Randomizer.getEvent(1);
			return;
		case WorldState.GumoFree:
			Events.GumoFree = this.IsTrue;
			return;
		case WorldState.SpiritTreeReached:
			Events.SpiritTreeReached = this.IsTrue;
			return;
		case WorldState.GinsoTreeKey:
			Randomizer.getEvent(0);
			return;
		case (WorldState)4:
		case (WorldState)6:
			return;
		case WorldState.GinsoTreeEntered:
			Events.GinsoTreeEntered = this.IsTrue;
			return;
		case WorldState.WindRestored:
			Randomizer.getEvent(3);
			return;
		case WorldState.GravityActivated:
			Events.GravityActivated = this.IsTrue;
			return;
		case WorldState.MistLifted:
			Events.MistLifted = this.IsTrue;
			return;
		case WorldState.ForlornRuinsKey:
			Randomizer.getEvent(2);
			return;
		case WorldState.MountHoruKey:
			Randomizer.getEvent(4);
			return;
		case WorldState.WarmthReturned:
			Randomizer.getEvent(5);
			return;
		case WorldState.DarknessLifted:
			Events.DarknessLifted = this.IsTrue;
			return;
		default:
			return;
		}
	}

	// Token: 0x06003576 RID: 13686 RVA: 0x0002A047 File Offset: 0x00028247
	public override string GetNiceName()
	{
		return "Set " + ActionHelper.GetName(this.State.ToString()) + " to " + ActionHelper.GetName(this.IsTrue.ToString());
	}

	// Token: 0x04003009 RID: 12297
	public WorldState State;

	// Token: 0x0400300A RID: 12298
	public bool IsTrue;
}
