using System;
using System.Collections;
using System.IO;
using UnityEngine;

// Token: 0x020009EF RID: 2543
public static partial class Randomizer
{
	// Token: 0x0600373A RID: 14138 RVA: 0x000E0750 File Offset: 0x000DE950
	public static void initialize()
	{
		Randomizer.OHKO = false;
		Randomizer.ZeroXP = false;
		Randomizer.Sync = false;
		Randomizer.SyncMode = 1;
		Randomizer.ShareParams = "";
		Randomizer.BonusActive = true;
		Randomizer.GiveAbility = false;
		Randomizer.Chaos = false;
		Randomizer.ChaosVerbose = false;
		Randomizer.Returning = false;
		RandomizerChaosManager.initialize();
		RandomizerSyncManager.Initialize();
		Randomizer.DamageModifier = 1f;
		Randomizer.Table = new Hashtable();
		Randomizer.GridFactor = 4.0;
		Randomizer.Message = "Good luck on your rando!";
		Randomizer.MessageProvider = (RandomizerMessageProvider)ScriptableObject.CreateInstance(typeof(RandomizerMessageProvider));
		Randomizer.ProgressiveMapStones = true;
		Randomizer.ForceTrees = false;
		Randomizer.CluesMode = false;
		Randomizer.SeedMeta = "";
		Randomizer.MistySim = new WorldEvents();
		Randomizer.MistySim.MoonGuid = new MoonGuid(1061758509, 1206015992, 824243626, -2026069462);
		Randomizer.TeleportTable = new Hashtable();
		Randomizer.TeleportTable["Forlorn"] = "forlorn";
		Randomizer.TeleportTable["Grotto"] = "moonGrotto";
		Randomizer.TeleportTable["Sorrow"] = "valleyOfTheWind";
		Randomizer.TeleportTable["Grove"] = "spiritTree";
		Randomizer.TeleportTable["Swamp"] = "swamp";
		Randomizer.TeleportTable["Valley"] = "sorrowPass";
		Randomizer.ColorShift = false;
		Randomizer.MessageQueue = new Queue();
		Randomizer.MessageQueueTime = 0;
		RandomizerRebinding.ParseRebinding();
		if (File.Exists("randomizer.dat"))
		{
			string[] array = File.ReadAllLines("randomizer.dat");
			string[] array2 = array[0].Split(new char[]
			{
				'|'
			})[0].Split(new char[]
			{
				','
			});
			Randomizer.SeedMeta = array[0];
			foreach (string text2 in array2)
			{
				if (text2.ToLower() == "ohko")
				{
					Randomizer.OHKO = true;
				}
				if (text2.ToLower().StartsWith("sync"))
				{
					Randomizer.Sync = true;
					Randomizer.SyncId = text2.Substring(4);
				}
				if (text2.ToLower().StartsWith("mode="))
				{
					Randomizer.SyncMode = int.Parse(text2.Substring(5));
				}
				if (text2.ToLower().StartsWith("shared="))
				{
					Randomizer.ShareParams = text2.Substring(7);
				}
				if (text2.ToLower() == "0xp")
				{
					Randomizer.ZeroXP = true;
				}
				if (text2.ToLower() == "nobonus")
				{
					Randomizer.BonusActive = false;
				}
				if (text2.ToLower() == "nonprogressivemapstones")
				{
					Randomizer.ProgressiveMapStones = false;
				}
				if (text2.ToLower() == "forcetrees")
				{
					Randomizer.ForceTrees = true;
				}
				if (text2.ToLower() == "clues")
				{
					Randomizer.CluesMode = true;
					RandomizerClues.initialize();
				}
			}
			for (int j = 1; j < array.Length; j++)
			{
				string[] array4 = array[j].Split(new char[]
				{
					'|'
				});
				int num;
				int.TryParse(array4[0], out num);
				if (array4[1] == "TP")
				{
					Randomizer.Table[num] = new RandomizerAction(array4[1], array4[2]);
				}
				else
				{
					int num2;
					int.TryParse(array4[2], out num2);
					Randomizer.Table[num] = new RandomizerAction(array4[1], num2);
					if (Randomizer.CluesMode && array4[1] == "EV" && num2 % 2 == 0)
					{
						RandomizerClues.AddClue(array4[3], num2 / 2);
					}
				}
			}
		}
	}
}
