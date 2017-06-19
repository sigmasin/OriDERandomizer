using System;
using UnityEngine;

// Token: 0x020009FB RID: 2555
public class RandomizerChaosDamageModifier : RandomizerChaosEffect
{
	// Token: 0x0600377F RID: 14207
	public override void Clear()
	{
		this.Countdown = 0;
		Randomizer.DamageModifier = 1f;
	}

	// Token: 0x06003780 RID: 14208
	public override void Start()
	{
		this.Countdown = UnityEngine.Random.Range(360, 3600);
		int num = UnityEngine.Random.Range(0, 8);
		if (num <= 3)
		{
			Randomizer.showChaosEffect("Damage vulnerability");
			Randomizer.DamageModifier = UnityEngine.Random.Range(1.5f, 4f);
			return;
		}
		if (num <= 6)
		{
			Randomizer.showChaosEffect("Damage reduction");
			Randomizer.DamageModifier = UnityEngine.Random.Range(0.25f, 0.8f);
			return;
		}
		if (num <= 7)
		{
			Randomizer.showChaosEffect("Invulnerability");
			Randomizer.DamageModifier = 0f;
		}
	}

	// Token: 0x06003781 RID: 14209
	public override void Update()
	{
		if (this.Countdown > 0)
		{
			this.Countdown--;
			if (this.Countdown == 0)
			{
				this.Clear();
			}
		}
	}

	// Token: 0x04003245 RID: 12869
	public int Countdown;
}
