using System;
using Game;
using UnityEngine;

// Token: 0x020009F9 RID: 2553
public class RandomizerChaosPoison : RandomizerChaosEffect
{
	// Token: 0x06003777 RID: 14199 RVA: 0x0002B7A0 File Offset: 0x000299A0
	public override void Clear()
	{
		this.Countdown = 0;
	}

	// Token: 0x06003778 RID: 14200 RVA: 0x000E171C File Offset: 0x000DF91C
	public override void Start()
	{
		Randomizer.showChaosEffect("Poison");
		this.Countdown = UnityEngine.Random.Range(1200, 3600);
		this.DamageRate = UnityEngine.Random.Range(0.5f, 2f) * (float)Characters.Sein.Mortality.Health.MaxHealth / (float)this.Countdown;
	}

	// Token: 0x06003779 RID: 14201 RVA: 0x000E177C File Offset: 0x000DF97C
	public override void Update()
	{
		if (this.Countdown > 0)
		{
			this.Countdown--;
			Characters.Sein.Mortality.Health.LoseHealth(this.DamageRate);
			if (Characters.Sein.Mortality.Health.Amount <= 0f)
			{
				Characters.Sein.Mortality.DamageReciever.OnRecieveDamage(new Damage(1f, default(Vector2), default(Vector3), DamageType.Water, null));
			}
			if (this.Countdown == 0)
			{
				this.Clear();
			}
		}
	}

	// Token: 0x0400323F RID: 12863
	public int Countdown;

	// Token: 0x04003240 RID: 12864
	public float DamageRate;
}
