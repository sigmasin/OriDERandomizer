using System;
using Game;
using UnityEngine;

// Token: 0x020009F4 RID: 2548
public class RandomizerChaosMovementSpeed : RandomizerChaosEffect
{
	// Token: 0x0600375F RID: 14175
	public override void Clear()
	{
		this.Countdown = 0;
		Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Acceleration = 60f;
		Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Decceleration = 30f;
		Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f;
		Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.Acceleration = 26f;
		Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.Decceleration = 26f;
		Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f;
	}

	// Token: 0x06003760 RID: 14176
	public override void Start()
	{
		this.Countdown = UnityEngine.Random.Range(360, 3600);
		int type = UnityEngine.Random.Range(0, 16);
		if (type <= 7)
		{
			float multiplier = UnityEngine.Random.Range(0.5f, 2f);
			if (multiplier < 1f)
			{
				Randomizer.showChaosEffect("Slow movement");
			}
			else
			{
				Randomizer.showChaosEffect("Fast movement");
			}
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Acceleration = 60f * multiplier;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Decceleration = 30f * multiplier;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f * multiplier;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.Acceleration = 26f * multiplier;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.Decceleration = 26f * multiplier;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f * multiplier;
			return;
		}
		if (type <= 12)
		{
			float multiplier2 = UnityEngine.Random.Range(10f, 20f);
			Randomizer.showChaosEffect("Icy ground");
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Acceleration = 60f / multiplier2;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Decceleration = 30f / multiplier2;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f * multiplier2 / 10f;
			return;
		}
		if (type <= 14)
		{
			float multiplier3 = UnityEngine.Random.Range(1.5f, 3f);
			Randomizer.showChaosEffect("Drag racer Ori");
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f * multiplier3;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f * multiplier3;
			return;
		}
		if (type == 15)
		{
			Randomizer.showChaosEffect("Strange movement");
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Acceleration = 60f * UnityEngine.Random.Range(0.05f, 4f);
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Decceleration = 30f * UnityEngine.Random.Range(0.05f, 4f);
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f * UnityEngine.Random.Range(0.25f, 4f);
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.Acceleration = 26f * UnityEngine.Random.Range(0.05f, 4f);
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.Decceleration = 26f * UnityEngine.Random.Range(0.05f, 4f);
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f * UnityEngine.Random.Range(0.25f, 4f);
		}
	}

	// Token: 0x06003761 RID: 14177
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

	// Token: 0x04003231 RID: 12849
	public int Countdown;
}
