using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020009F2 RID: 2546
public static class RandomizerChaosManager
{
	// Token: 0x06003759 RID: 14169
	public static void initialize()
	{
		RandomizerChaosManager.Countdown = UnityEngine.Random.Range(300, 1800);
		RandomizerChaosManager.Effects = new List<RandomizerChaosEffect>();
		RandomizerChaosManager.Frequencies = new List<int>();
		RandomizerChaosManager.Effects.Add(new RandomizerChaosMovementSpeed());
		RandomizerChaosManager.Frequencies.Add(18);
		RandomizerChaosManager.Effects.Add(new RandomizerChaosGravity());
		RandomizerChaosManager.Frequencies.Add(13);
		RandomizerChaosManager.Effects.Add(new RandomizerChaosTeleport());
		RandomizerChaosManager.Frequencies.Add(7);
		RandomizerChaosManager.Effects.Add(new RandomizerChaosZoom());
		RandomizerChaosManager.Frequencies.Add(5);
		RandomizerChaosManager.Effects.Add(new RandomizerChaosPoison());
		RandomizerChaosManager.Frequencies.Add(1);
		RandomizerChaosManager.Effects.Add(new RandomizerChaosColor());
		RandomizerChaosManager.Frequencies.Add(6);
		RandomizerChaosManager.Effects.Add(new RandomizerChaosDamageModifier());
		RandomizerChaosManager.Frequencies.Add(8);
		RandomizerChaosManager.Effects.Add(new RandomizerChaosVelocityVector());
		RandomizerChaosManager.Frequencies.Add(6);
	}

	// Token: 0x0600375A RID: 14170
	public static void Update()
	{
		RandomizerChaosManager.Countdown--;
		if (RandomizerChaosManager.Countdown <= 0)
		{
			RandomizerChaosManager.SpawnEffect();
			RandomizerChaosManager.Countdown = UnityEngine.Random.Range(300, 1800);
		}
		for (int i = 0; i < RandomizerChaosManager.Effects.Count; i++)
		{
			RandomizerChaosManager.Effects[i].Update();
		}
	}

	// Token: 0x0600375B RID: 14171
	public static void ClearEffects()
	{
		for (int i = 0; i < RandomizerChaosManager.Effects.Count; i++)
		{
			RandomizerChaosManager.Effects[i].Clear();
		}
	}

	// Token: 0x0600375C RID: 14172
	public static void SpawnEffect()
	{
		int num = 0;
		int num2 = UnityEngine.Random.Range(0, 64);
		for (int i = 0; i < RandomizerChaosManager.Effects.Count; i++)
		{
			num += RandomizerChaosManager.Frequencies[i];
			if (num > num2)
			{
				RandomizerChaosManager.Effects[i].Start();
				return;
			}
		}
	}

	// Token: 0x04003230 RID: 12848
	public static int Countdown;

	// Token: 0x04003231 RID: 12849
	public static List<RandomizerChaosEffect> Effects;

	// Token: 0x04003232 RID: 12850
	public static List<int> Frequencies;
}
