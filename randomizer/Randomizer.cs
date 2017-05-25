using System;
using System.Collections;
using System.IO;
using Game;
using Sein.World;
using UnityEngine;

// Token: 0x020009EE RID: 2542
public static class Randomizer
{
	// Token: 0x06003737 RID: 14135
	public static void initialize()
	{
		Randomizer.OHKO = false;
		Randomizer.ZeroXP = false;
		Randomizer.GiveAbility = false;
		Randomizer.BonusActive = true;
		Randomizer.Table = new Hashtable();
		Randomizer.GridFactor = 4.0;
		Randomizer.MessageProvider = new RandomizerMessageProvider();
		if (File.Exists("randomizer.dat"))
		{
			string[] array = File.ReadAllLines("randomizer.dat");
			string[] flags = array[0].Split(new char[]
			{
				','
			});
			for (int i = 0; i < flags.Length; i++)
			{
				if (flags[i].ToLower() == "ohko")
				{
					Randomizer.OHKO = true;
				}
				if (flags[i].ToLower() == "0xp")
				{
					Randomizer.ZeroXP = true;
				}
				if (flags[i].ToLower() == "nobonus")
				{
					Randomizer.BonusActive = false;
				}
			}
			for (int j = 1; j < array.Length; j++)
			{
				string[] array2 = array[j].Split(new char[]
				{
					'|'
				});
				int num;
				int.TryParse(array2[0], out num);
				int num2;
				int.TryParse(array2[2], out num2);
				Randomizer.Table[num] = new RandomizerAction(array2[1], num2);
			}
		}
	}

	// Token: 0x06003738 RID: 14136
	public static void getPickup()
	{
		RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[Randomizer.resolvePosition()]);
	}

	// Token: 0x06003739 RID: 14137
	public static void returnToStart()
	{
		Characters.Sein.Position = new Vector3(189f, -189f);
	}

	// Token: 0x0600373A RID: 14138
	public static void getEvent(int ID)
	{
		RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[ID * 4]);
	}

	// Token: 0x0600373B RID: 14139
	public static void showHint(string message)
	{
		Randomizer.MessageProvider.SetMessage(message);
		UI.Hints.Show(Randomizer.MessageProvider, HintLayer.GameSaved, 3f);
	}

	// Token: 0x0600373C RID: 14140
	public static int resolvePosition()
	{
		int num = (int)(Math.Floor((double)Characters.Sein.Position.x / Randomizer.GridFactor) * Randomizer.GridFactor * 10000.0 + Math.Floor((double)Characters.Sein.Position.y / Randomizer.GridFactor) * Randomizer.GridFactor);
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				if (Randomizer.Table.ContainsKey(num + (int)Randomizer.GridFactor * (10000 * i + j)))
				{
					return num + (int)Randomizer.GridFactor * (10000 * i + j);
				}
			}
		}
		RandomizerMessageProvider arg_AE_0 = Randomizer.MessageProvider;
		Vector3 position = Characters.Sein.Position;
		string str = position.x.ToString();
		string str2 = ", ";
		position = Characters.Sein.Position;
		Randomizer.showHint("Error finding pickup at " + str + str2 + position.y.ToString());
		return num;
	}

	// Token: 0x0600373D RID: 14141
	public static void playLastMessage()
	{
		UI.Hints.Show(Randomizer.MessageProvider, HintLayer.GameSaved, 3f);
	}

	// Token: 0x0600373E RID: 14142
	public static void log(string message)
	{
		StreamWriter expr_0A = File.AppendText("randomizer.log");
		expr_0A.WriteLine(message);
		expr_0A.Flush();
	}

	// Token: 0x0600373F RID: 14143
	public static bool WindRestored()
	{
		return Sein.World.Events.WindRestored && (Characters.Sein.Position.x >= -700f || Characters.Sein.Position.y >= -230f);
	}

	// Token: 0x06003740 RID: 14144
	public static void getSkill()
	{
		Randomizer.getPickup();
	}

	// Token: 0x06003741 RID: 14145
	public static void hintAndLog(float x, float y)
	{
		string expr_1E = ((int)x).ToString() + " " + ((int)y).ToString();
		Randomizer.showHint(expr_1E);
		Randomizer.log(expr_1E);
	}

	// Token: 0x06003742 RID: 14146
	public static void getPickup(Vector3 position)
	{
		int num = (int)(Math.Floor((double)((int)position.x) / Randomizer.GridFactor) * Randomizer.GridFactor) * 10000 + (int)(Math.Floor((double)((int)position.y) / Randomizer.GridFactor) * Randomizer.GridFactor);
		if (Randomizer.Table.ContainsKey(num))
		{
			RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[num]);
			return;
		}
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				if (Randomizer.Table.ContainsKey(num + (int)Randomizer.GridFactor * (10000 * i + j)))
				{
					RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[num + (int)Randomizer.GridFactor * (10000 * i + j)]);
					return;
				}
			}
		}
		Randomizer.showHint("Error finding pickup at " + ((int)position.x).ToString() + ", " + ((int)position.y).ToString());
	}

	// Token: 0x06003743 RID: 14147
	public static void Update()
	{
		if (!Characters.Sein.IsSuspended)
		{
			Characters.Sein.Mortality.Health.GainHealth((float)RandomizerBonus.HealthRegeneration() * 0.0008f);
			Characters.Sein.Energy.Gain((float)RandomizerBonus.EnergyRegeneration() * 0.0002f);
		}
	}

	// Token: 0x04003223 RID: 12835
	public static Hashtable Table;

	// Token: 0x04003224 RID: 12836
	public static bool GiveAbility;

	// Token: 0x04003225 RID: 12837
	public static double GridFactor;

	// Token: 0x04003226 RID: 12838
	public static RandomizerMessageProvider MessageProvider;

	// Token: 0x04003236 RID: 12854
	public static bool OHKO;

	// Token: 0x04003237 RID: 12855
	public static bool ZeroXP;

	// Token: 0x04003244 RID: 12868
	public static bool BonusActive;
}
