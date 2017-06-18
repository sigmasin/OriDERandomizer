using System;
using Game;
using UnityEngine;

// Token: 0x020009F9 RID: 2553
public class RandomizerChaosPoison : RandomizerChaosEffect
{
	// Token: 0x0600378B RID: 14219
	public override void Clear()
	{
		this.Countdown = 0;
	}

	// Token: 0x0600378C RID: 14220
	public override void Start()
	{
		Randomizer.showChaosEffect("Poison");
		this.Countdown = UnityEngine.Random.Range(1200, 3600);
		this.DamageRate = UnityEngine.Random.Range(0.5f, 2f) * (float)Characters.Sein.Mortality.Health.MaxHealth / (float)this.Countdown;
	}

	// Token: 0x0600378D RID: 14221
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

	// Token: 0x0400323C RID: 12860
	public int Countdown;

	// Token: 0x040032C3 RID: 12995
	public float DamageRate;
}
