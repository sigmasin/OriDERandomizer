using System;
using System.Collections;
using System.IO;
using Core;
using Game;
using Sein.World;
using UnityEngine;

// Token: 0x020009EE RID: 2542
public static class Randomizer
{
	// Token: 0x06003738 RID: 14136 RVA: 0x000E02D4 File Offset: 0x000DE4D4
	public static void initialize()
	{
		Randomizer.OHKO = false;
		Randomizer.ZeroXP = false;
		Randomizer.BonusActive = true;
		Randomizer.GiveAbility = false;
		Randomizer.Chaos = false;
		Randomizer.ChaosVerbose = false;
		RandomizerChaosManager.initialize();
		Randomizer.DamageModifier = 1f;
		Randomizer.Table = new Hashtable();
		Randomizer.GridFactor = 4.0;
		Randomizer.Message = "Good luck on your rando!";
		Randomizer.MessageProvider = new RandomizerMessageProvider();
		Randomizer.ProgressiveMapStones = true;
		Randomizer.ForceTrees = false;
		RandomizerRebinding.ParseRebinding();
		if (File.Exists("randomizer.dat"))
		{
			string[] array = File.ReadAllLines("randomizer.dat");
			string[] array2 = array[0].Split(new char[]
			{
				','
			});
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].ToLower() == "ohko")
				{
					Randomizer.OHKO = true;
				}
				if (array2[i].ToLower() == "0xp")
				{
					Randomizer.ZeroXP = true;
				}
				if (array2[i].ToLower() == "nobonus")
				{
					Randomizer.BonusActive = false;
				}
				if (array2[i].ToLower() == "nonprogressivemapstones")
				{
					Randomizer.ProgressiveMapStones = false;
				}
				if (array2[i].ToLower() == "forcetrees")
				{
					Randomizer.ForceTrees = true;
				}
			}
			for (int j = 1; j < array.Length; j++)
			{
				string[] array3 = array[j].Split(new char[]
				{
					'|'
				});
				int num;
				int.TryParse(array3[0], out num);
				int num2;
				int.TryParse(array3[2], out num2);
				Randomizer.Table[num] = new RandomizerAction(array3[1], num2);
			}
		}
	}

	// Token: 0x06003739 RID: 14137 RVA: 0x0002B449 File Offset: 0x00029649
	public static void getPickup()
	{
		Randomizer.getPickup(Characters.Sein.Position);
	}

	// Token: 0x0600373A RID: 14138
	public static void returnToStart()
	{
		if (Characters.Sein.Abilities.Carry.IsCarrying || !Characters.Sein.Controller.CanMove || !Characters.Sein.Active)
		{
			return;
		}
		Characters.Sein.Position = new Vector3(189f, -189f);
		if (Randomizer.MistyRuntimePtr != null)
		{
			Randomizer.MistyRuntimePtr.Value = 10;
		}
	}

	// Token: 0x0600373B RID: 14139 RVA: 0x0002B488 File Offset: 0x00029688
	public static void getEvent(int ID)
	{
		RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[ID * 4]);
	}

	// Token: 0x0600373C RID: 14140 RVA: 0x0002B4A6 File Offset: 0x000296A6
	public static void showHint(string message)
	{
		Randomizer.Message = message;
		Randomizer.MessageProvider.SetMessage(message);
		UI.Hints.Show(Randomizer.MessageProvider, HintLayer.GameSaved, 3f);
	}

	// Token: 0x0600373D RID: 14141 RVA: 0x0002B4CA File Offset: 0x000296CA
	public static void playLastMessage()
	{
		Randomizer.MessageProvider.SetMessage(Randomizer.Message);
		UI.Hints.Show(Randomizer.MessageProvider, HintLayer.GameSaved, 3f);
	}

	// Token: 0x0600373E RID: 14142 RVA: 0x0002B4EC File Offset: 0x000296EC
	public static void log(string message)
	{
		StreamWriter expr_0A = File.AppendText("randomizer.log");
		expr_0A.WriteLine(message);
		expr_0A.Flush();
	}

	// Token: 0x0600373F RID: 14143 RVA: 0x0002B504 File Offset: 0x00029704
	public static bool WindRestored()
	{
		return Sein.World.Events.WindRestored && Scenes.Manager.CurrentScene.Scene != "forlornRuinsResurrection" && Scenes.Manager.CurrentScene.Scene != "forlornRuinsRotatingLaserFlipped";
	}

	// Token: 0x06003740 RID: 14144 RVA: 0x0002B543 File Offset: 0x00029743
	public static void getSkill()
	{
		Characters.Sein.Inventory.SkillPointsCollected += 134217728;
		Randomizer.getPickup();
	}

	// Token: 0x06003741 RID: 14145 RVA: 0x000E0474 File Offset: 0x000DE674
	public static void hintAndLog(float x, float y)
	{
		string expr_1E = ((int)x).ToString() + " " + ((int)y).ToString();
		Randomizer.showHint(expr_1E);
		Randomizer.log(expr_1E);
	}

	// Token: 0x06003742 RID: 14146 RVA: 0x000E04AC File Offset: 0x000DE6AC
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
		for (int k = -2; k <= 2; k += 4)
		{
			for (int l = -1; l <= 1; l++)
			{
				if (Randomizer.Table.ContainsKey(num + (int)Randomizer.GridFactor * (10000 * k + l)))
				{
					RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[num + (int)Randomizer.GridFactor * (10000 * k + l)]);
					return;
				}
			}
		}
		Randomizer.showHint("Error finding pickup at " + ((int)position.x).ToString() + ", " + ((int)position.y).ToString());
	}

	// Token: 0x06003743 RID: 14147 RVA: 0x000E062C File Offset: 0x000DE82C
	public static void Update()
	{
		if (!Characters.Sein.IsSuspended)
		{
			Characters.Sein.Mortality.Health.GainHealth((float)RandomizerBonus.HealthRegeneration() * (Characters.Sein.PlayerAbilities.HealthEfficiency.HasAbility ? 0.0016f : 0.0008f));
			Characters.Sein.Energy.Gain((float)RandomizerBonus.EnergyRegeneration() * (Characters.Sein.PlayerAbilities.EnergyEfficiency.HasAbility ? 0.0003f : 0.0002f));
			if (Randomizer.ForceTrees && Scenes.Manager.CurrentScene.Scene == "catAndMouseResurrectionRoom" && RandomizerBonus.SkillTreeProgression() < 10)
			{
				Characters.Sein.Position = new Vector3(20f, 105f);
			}
			if (Randomizer.Chaos)
			{
				RandomizerChaosManager.Update();
			}
		}
		if (MoonInput.GetKey(KeyCode.LeftAlt) || MoonInput.GetKey(KeyCode.RightAlt))
		{
			if (MoonInput.GetKeyDown(RandomizerRebinding.ReplayMessage))
			{
				Randomizer.playLastMessage();
				return;
			}
			if (MoonInput.GetKeyDown(RandomizerRebinding.ReturnToStart))
			{
				Randomizer.returnToStart();
				return;
			}
			if (MoonInput.GetKeyDown(RandomizerRebinding.ReloadSeed))
			{
				Randomizer.initialize();
				return;
			}
			if (MoonInput.GetKeyDown(RandomizerRebinding.ShowProgress))
			{
				Randomizer.showProgress();
				return;
			}
			if (MoonInput.GetKeyDown(RandomizerRebinding.ToggleChaos))
			{
				if (Randomizer.Chaos)
				{
					Randomizer.showChaosMessage("Chaos deactivated");
					Randomizer.Chaos = false;
					RandomizerChaosManager.ClearEffects();
					return;
				}
				Randomizer.showChaosMessage("Chaos activated");
				Randomizer.Chaos = true;
				return;
			}
			else if (MoonInput.GetKeyDown(RandomizerRebinding.ChaosVerbosity) && Randomizer.Chaos)
			{
				Randomizer.ChaosVerbose = !Randomizer.ChaosVerbose;
				if (Randomizer.ChaosVerbose)
				{
					Randomizer.showChaosMessage("Chaos messages enabled");
					return;
				}
				Randomizer.showChaosMessage("Chaos messages disabled");
				return;
			}
			else if (MoonInput.GetKeyDown(RandomizerRebinding.ForceChaosEffect) && Randomizer.Chaos)
			{
				RandomizerChaosManager.SpawnEffect();
				return;
			}
		}
	}

	// Token: 0x06003744 RID: 14148 RVA: 0x0002B565 File Offset: 0x00029765
	public static void showChaosEffect(string message)
	{
		if (Randomizer.ChaosVerbose)
		{
			Randomizer.MessageProvider.SetMessage(message);
			UI.Hints.Show(Randomizer.MessageProvider, HintLayer.Gameplay, 3f);
		}
	}

	// Token: 0x06003745 RID: 14149 RVA: 0x0002B58A File Offset: 0x0002978A
	public static void showChaosMessage(string message)
	{
		Randomizer.MessageProvider.SetMessage(message);
		UI.Hints.Show(Randomizer.MessageProvider, HintLayer.GameSaved, 3f);
	}

	// Token: 0x06003746 RID: 14150 RVA: 0x000E0800 File Offset: 0x000DEA00
	public static void getMapStone()
	{
		if (!Randomizer.ProgressiveMapStones)
		{
			Randomizer.getPickup();
			return;
		}
		Characters.Sein.Inventory.SkillPointsCollected += 8388608;
		RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[20 + RandomizerBonus.MapStoneProgression() * 4]);
	}

	// Token: 0x06003747 RID: 14151 RVA: 0x000E0858 File Offset: 0x000DEA58
	public static void showProgress()
	{
		string text = "Trees (" + RandomizerBonus.SkillTreeProgression().ToString() + "/10) ";
		text += " Water Vein (";
		if (Keys.GinsoTree)
		{
			text += "3";
		}
		else
		{
			text += RandomizerBonus.WaterVeinShards().ToString();
		}
		text += "/3)\nGumon Seal (";
		if (Keys.ForlornRuins)
		{
			text += "3";
		}
		else
		{
			text += RandomizerBonus.GumonSealShards().ToString();
		}
		text += "/3)  Sunstone (";
		if (Keys.MountHoru)
		{
			text += "3";
		}
		else
		{
			text += RandomizerBonus.SunstoneShards().ToString();
		}
		text += "/3)";
		Randomizer.MessageProvider.SetMessage(text);
		UI.Hints.Show(Randomizer.MessageProvider, HintLayer.GameSaved, 3f);
	}

	// Token: 0x04003223 RID: 12835
	public static Hashtable Table;

	// Token: 0x04003224 RID: 12836
	public static bool GiveAbility;

	// Token: 0x04003225 RID: 12837
	public static double GridFactor;

	// Token: 0x04003226 RID: 12838
	public static RandomizerMessageProvider MessageProvider;

	// Token: 0x04003227 RID: 12839
	public static bool OHKO;

	// Token: 0x04003228 RID: 12840
	public static bool ZeroXP;

	// Token: 0x04003229 RID: 12841
	public static bool BonusActive;

	// Token: 0x0400322A RID: 12842
	public static string Message;

	// Token: 0x0400322B RID: 12843
	public static bool Chaos;

	// Token: 0x0400322C RID: 12844
	public static bool ChaosVerbose;

	// Token: 0x0400322D RID: 12845
	public static float DamageModifier;

	// Token: 0x0400322E RID: 12846
	public static WorldEventsRuntime MistyRuntimePtr;

	// Token: 0x0400322F RID: 12847
	public static bool ProgressiveMapStones;

	// Token: 0x04003230 RID: 12848
	public static bool ForceTrees;
}
