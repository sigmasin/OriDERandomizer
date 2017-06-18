using System;
using Game;
using UnityEngine;

// Token: 0x020009F6 RID: 2550
public class RandomizerChaosTeleport : RandomizerChaosEffect
{
	// Token: 0x0600377F RID: 14207
	public override void Clear()
	{
		this.Countdown = 0;
	}

	// Token: 0x06003780 RID: 14208
	public override void Start()
	{
		this.Countdown = UnityEngine.Random.Range(360, 3600);
		this.TeleportCount = UnityEngine.Random.Range(1, 10);
		Randomizer.showChaosEffect("Teleportation");
	}

	// Token: 0x06003781 RID: 14209
	public override void Update()
	{
		if (this.Countdown > 0)
		{
			if (UnityEngine.Random.Range(0f, 1f) < (float)this.TeleportCount / (float)this.Countdown)
			{
				this.Teleport();
			}
			this.Countdown--;
			if (this.Countdown == 0)
			{
				this.Clear();
			}
		}
	}

	// Token: 0x06003851 RID: 14417
	public void Teleport()
	{
		Characters.Sein.Position = new Vector3(Characters.Sein.Position.x + UnityEngine.Random.Range(-10f, 10f), Characters.Sein.Position.y + UnityEngine.Random.Range(-10f, 10f));
		this.TeleportCount--;
	}

	// Token: 0x04003239 RID: 12857
	public int Countdown;

	// Token: 0x040032BA RID: 12986
	public int TeleportCount;
}
