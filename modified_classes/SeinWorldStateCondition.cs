using System;
using Sein.World;

// Token: 0x02000989 RID: 2441
public class SeinWorldStateCondition : Condition
{
	// Token: 0x06003573 RID: 13683
	public override bool Validate(IContext context)
	{
		switch (this.State)
		{
		case WorldState.WaterPurified:
			return Events.WaterPurified == this.IsTrue;
		case WorldState.GumoFree:
			return Events.GumoFree == this.IsTrue;
		case WorldState.SpiritTreeReached:
			return Events.SpiritTreeReached == this.IsTrue;
		case WorldState.GinsoTreeKey:
			return Keys.GinsoTree == this.IsTrue;
		case WorldState.WindRestored:
			return Randomizer.WindRestored() == this.IsTrue;
		case WorldState.GravityActivated:
			return Events.GravityActivated == this.IsTrue;
		case WorldState.MistLifted:
			return Events.MistLifted == this.IsTrue;
		case WorldState.ForlornRuinsKey:
			return Keys.ForlornRuins == this.IsTrue;
		case WorldState.MountHoruKey:
			return Keys.MountHoru == this.IsTrue;
		case WorldState.WarmthReturned:
			return Events.WarmthReturned == this.IsTrue;
		case WorldState.DarknessLifted:
			return Events.DarknessLifted == this.IsTrue;
		}
		return false;
	}

	// Token: 0x04003007 RID: 12295
	public WorldState State;

	// Token: 0x04003008 RID: 12296
	public bool IsTrue = true;
}
