using System;
using Game;
using UnityEngine;

// Token: 0x020009F5 RID: 2549
public class RandomizerChaosGravity : RandomizerChaosEffect
{
	// Token: 0x0600376F RID: 14191
	public override void Clear()
	{
		this.Countdown = 0;
		this.WellActive = false;
		Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 0f;
		this.ApplyGravityMultiplier(1f);
	}

	// Token: 0x06003770 RID: 14192
	public override void Start()
	{
		this.Countdown = UnityEngine.Random.Range(600, 1200);
		this.WellActive = false;
		int type = UnityEngine.Random.Range(0, 16);
		if (type <= 7)
		{
			float multiplier = UnityEngine.Random.Range(0.5f, 2f);
			if (multiplier < 1f)
			{
				Randomizer.showChaosEffect("Gravity increase");
			}
			else
			{
				Randomizer.showChaosEffect("Gravity decrease");
			}
			this.ApplyGravityMultiplier(1f / multiplier);
			return;
		}
		if (type <= 11)
		{
			Randomizer.showChaosEffect("Gravity shift");
			Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = UnityEngine.Random.Range(45f, 315f);
			return;
		}
		if (type <= 13)
		{
			Randomizer.showChaosEffect("Weird gravity");
			Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = UnityEngine.Random.Range(0f, 360f);
			this.ApplyGravityMultiplier(1f / UnityEngine.Random.Range(0.5f, 2f));
			return;
		}
		if (type <= 15)
		{
			this.WellActive = true;
			this.WellPosition = new Vector2(Characters.Sein.Position.x + UnityEngine.Random.Range(-20f, 20f), Characters.Sein.Position.y + UnityEngine.Random.Range(-20f, 20f));
			Randomizer.showChaosEffect("Gravity well");
			this.ApplyGravityMultiplier(1f / UnityEngine.Random.Range(0.5f, 2f));
		}
	}

	// Token: 0x06003771 RID: 14193
	public override void Update()
	{
		if (this.Countdown > 0)
		{
			this.Countdown--;
			if (this.Countdown == 0)
			{
				this.Clear();
			}
			if (this.WellActive)
			{
				float x = Characters.Sein.Position.x - this.WellPosition.x;
				float y = Characters.Sein.Position.y - this.WellPosition.y;
				if (Math.Abs(x) > Math.Abs(y))
				{
					if (x > 0f)
					{
						Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 270f;
						return;
					}
					Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 90f;
					return;
				}
				else
				{
					if (y > 0f)
					{
						Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 0f;
						return;
					}
					Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 180f;
				}
			}
		}
	}

	// Token: 0x06003806 RID: 14342
	public void ApplyGravityMultiplier(float multiplier)
	{
		Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityStrength = 26f * multiplier;
		Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.MaxFallSpeed = 32f * multiplier;
		Characters.Sein.Abilities.Jump.BackflipJumpHeight = 3f / multiplier;
		Characters.Sein.Abilities.Jump.CrouchJumpHeight = 4.5f / multiplier;
		Characters.Sein.Abilities.Jump.FirstJumpHeight = 3f / multiplier;
		Characters.Sein.Abilities.Jump.JumpIdleHeight = 3f / multiplier;
		Characters.Sein.Abilities.Jump.SecondJumpHeight = 3.75f / multiplier;
		Characters.Sein.Abilities.Jump.ThirdJumpHeight = 4.5f / multiplier;
	}

	// Token: 0x04003235 RID: 12853
	public int Countdown;

	// Token: 0x04003250 RID: 12880
	public bool WellActive;

	// Token: 0x04003271 RID: 12913
	public Vector2 WellPosition;
}
