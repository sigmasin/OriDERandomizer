using System;
using System.Collections.Generic;
using Game;
using Sein.World;

// Token: 0x02000829 RID: 2089
public class GetWorldEventCondition : Condition
{
	// Token: 0x06002D27 RID: 11559
	public override bool Validate(IContext context)
	{
		if (this.WorldEvents.UniqueID == 26 && Sein.World.Events.WarmthReturned)
		{
			return this.State != 21;
		}
		int value = World.Events.Find(this.WorldEvents).Value;
		if (this.States.Count == 0)
		{
			return this.State == value;
		}
		for (int i = 0; i < this.States.Count; i++)
		{
			int num = this.States[i];
			if (value == num)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x040028AB RID: 10411
	public WorldEvents WorldEvents;

	// Token: 0x040028AC RID: 10412
	public int State;

	// Token: 0x040028AD RID: 10413
	public List<int> States;
}
