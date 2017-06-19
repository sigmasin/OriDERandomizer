using System;
using Game;
using UnityEngine;

// Token: 0x020009F6 RID: 2550
public class RandomizerChaosTeleport : RandomizerChaosEffect
{
	// Token: 0x0600376A RID: 14186 RVA: 0x0002B767 File Offset: 0x00029967
	public override void Clear()
	{
		this.Countdown = 0;
	}

	// Token: 0x0600376B RID: 14187 RVA: 0x000E1330 File Offset: 0x000DF530
	public override void Start()
	{
		this.Countdown = UnityEngine.Random.Range(360, 3600);
		int num = UnityEngine.Random.Range(0, 16);
		Randomizer.showChaosEffect("Teleportation");
		if (num <= 14)
		{
			this.TeleportCount = UnityEngine.Random.Range(1, 10);
			return;
		}
		if (num <= 15)
		{
			this.Teleport(200f);
		}
	}

	// Token: 0x0600376C RID: 14188 RVA: 0x000E138C File Offset: 0x000DF58C
	public override void Update()
	{
		if (this.Countdown > 0)
		{
			if (UnityEngine.Random.Range(0f, 1f) < (float)this.TeleportCount / (float)this.Countdown)
			{
				this.Teleport(10f);
			}
			this.Countdown--;
			if (this.Countdown == 0)
			{
				this.Clear();
			}
		}
	}

	// Token: 0x0600376E RID: 14190 RVA: 0x000E13EC File Offset: 0x000DF5EC
	public void Teleport(float range)
	{
		Characters.Sein.Position = new Vector3(Characters.Sein.Position.x + UnityEngine.Random.Range(-range, range), Characters.Sein.Position.y + UnityEngine.Random.Range(-range, range));
		this.TeleportCount--;
	}

	// Token: 0x04003238 RID: 12856
	public int Countdown;

	// Token: 0x04003239 RID: 12857
	public int TeleportCount;
}
