using System;
using Game;
using UnityEngine;

// Token: 0x020009F4 RID: 2548
public class RandomizerChaosMovementSpeed : RandomizerChaosEffect
{
	// Token: 0x06003761 RID: 14177 RVA: 0x000E0B54 File Offset: 0x000DED54
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

	// Token: 0x06003762 RID: 14178 RVA: 0x000E0C3C File Offset: 0x000DEE3C
	public override void Start()
	{
		this.Countdown = UnityEngine.Random.Range(360, 3600);
		int num = UnityEngine.Random.Range(0, 16);
		if (num <= 7)
		{
			float num2 = UnityEngine.Random.Range(0.5f, 2f);
			if (num2 < 1f)
			{
				Randomizer.showChaosEffect("Slow movement");
			}
			else
			{
				Randomizer.showChaosEffect("Fast movement");
			}
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Acceleration = 60f * num2;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Decceleration = 30f * num2;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f * num2;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.Acceleration = 26f * num2;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.Decceleration = 26f * num2;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f * num2;
			return;
		}
		if (num <= 12)
		{
			float num3 = UnityEngine.Random.Range(8f, 16f);
			Randomizer.showChaosEffect("Icy ground");
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Acceleration = 60f / num3;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.Decceleration = 30f / num3;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f * num3 / 8f;
			return;
		}
		if (num <= 14)
		{
			float num4 = UnityEngine.Random.Range(1.5f, 3f);
			Randomizer.showChaosEffect("Drag racer Ori");
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f * num4;
			Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f * num4;
			return;
		}
		if (num == 15)
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

	// Token: 0x06003763 RID: 14179 RVA: 0x0002B6F4 File Offset: 0x000298F4
	public override void Update()
	{
		if (this.Countdown == 0)
		{
			this.Clear();
		}
		this.Countdown--;
		if (this.Countdown < -600)
		{
			this.Countdown = 0;
		}
	}

	// Token: 0x04003233 RID: 12851
	public int Countdown;
}
