using System;
using Game;

// Token: 0x0200082A RID: 2090
public class SetWorldEventAction : ActionMethod
{
	// Token: 0x06002D29 RID: 11561
	public override void Perform(IContext context)
	{
		if (this.WorldEvents.UniqueID == 16)
		{
			Randomizer.MistyRuntimePtr = World.Events.Find(this.WorldEvents);
		}
		World.Events.Find(this.WorldEvents).Value = this.State;
	}

	// Token: 0x040028AE RID: 10414
	public WorldEvents WorldEvents;

	// Token: 0x040028AF RID: 10415
	public int State;
}
