using System;
using System.Collections;
using System.IO;
using Core;
using Game;
using OriDERandoDecoder;
using Sein.World;
using UnityEngine;

// Token: 0x020009EF RID: 2543
public static class Randomizer
{
	// Token: 0x0600373C RID: 14140
	public static void initialize()
	{
		Randomizer.OHKO = false;
		Randomizer.ZeroXP = false;
		Randomizer.BonusActive = true;
		Randomizer.GiveAbility = false;
		Randomizer.Chaos = false;
		Randomizer.ChaosVerbose = false;
		Randomizer.Returning = false;
		Randomizer.Sync = false;
		Randomizer.SyncMode = 1;
		Randomizer.ShareParams = "";
		RandomizerChaosManager.initialize();
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
		Randomizer.Entrance = false;
		Randomizer.DoorTable = new Hashtable();
		Randomizer.ColorShift = false;
		Randomizer.MessageQueue = new Queue();
		Randomizer.MessageQueueTime = 0;
		Randomizer.QueueBash = false;
		Randomizer.BashWasQueued = false;
		Randomizer.BashTap = false;
		bool flag = false;
		Randomizer.NoLava = false;
		Randomizer.LoadHoruLavaData();
		Randomizer.LoadGinsoData();
		RandomizerRebinding.ParseRebinding();
		RandomizerSettings.ParseSettings();
		if (File.Exists("randomizer.dat"))
		{
			string[] array15 = File.ReadAllLines("randomizer.dat");
			string[] array17 = array15[0].Split(new char[]
			{
				'|'
			})[0].Split(new char[]
			{
				','
			});
			Randomizer.SeedMeta = array15[0];
			foreach (string text in array17)
			{
				if (text.ToLower() == "ohko")
				{
					Randomizer.OHKO = true;
				}
				if (text.ToLower().StartsWith("sync"))
				{
					Randomizer.Sync = true;
					Randomizer.SyncId = text.Substring(4);
					RandomizerSyncManager.Initialize();
				}
				if (text.ToLower().StartsWith("mode="))
				{
					string text2 = text.Substring(5).ToLower();
					int syncMode;
					if (text2 == "shared")
					{
						syncMode = 1;
					}
					else if (text2 == "swap")
					{
						syncMode = 2;
					}
					else if (text2 == "split")
					{
						syncMode = 3;
					}
					else if (text2 == "none")
					{
						syncMode = 4;
					}
					else
					{
						syncMode = int.Parse(text2);
					}
					Randomizer.SyncMode = syncMode;
				}
				if (text.ToLower().StartsWith("shared="))
				{
					Randomizer.ShareParams = text.Substring(7);
				}
				if (text.ToLower() == "0xp")
				{
					Randomizer.ZeroXP = true;
				}
				if (text.ToLower() == "nobonus")
				{
					Randomizer.BonusActive = false;
				}
				if (text.ToLower() == "nonprogressivemapstones")
				{
					Randomizer.ProgressiveMapStones = false;
				}
				if (text.ToLower() == "forcetrees")
				{
					Randomizer.ForceTrees = true;
				}
				if (text.ToLower() == "clues")
				{
					Randomizer.CluesMode = true;
					RandomizerClues.initialize();
				}
				if (text.ToLower() == "entrance")
				{
					Randomizer.Entrance = true;
				}
				if (text.ToLower() == "nolava")
				{
					Randomizer.NoLava = true;
				}
				if (text.ToLower() == "encrypted")
				{
					flag = true;
				}
			}
			if (Randomizer.NoLava)
			{
				Game.Checkpoint.SaveGameData.LoadCustomData(Randomizer.HoruData);
				Game.Checkpoint.SaveGameData.LoadCustomData(Randomizer.GinsoData);
			}
			if (flag)
			{
				array15 = Decoder.Decode(array15[1]);
			}
			for (int i = 1; i < array15.Length; i++)
			{
				if (!(array15[i].Trim() == ""))
				{
					string[] array16 = array15[i].Split(new char[]
					{
						'|'
					});
					int num8;
					int.TryParse(array16[0], out num8);
					if (array16[1] == "TP")
					{
						Randomizer.Table[num8] = new RandomizerAction(array16[1], array16[2]);
					}
					else
					{
						int num9;
						int.TryParse(array16[2], out num9);
						if (array16[1] == "EN")
						{
							int num10;
							int.TryParse(array16[3], out num10);
							Randomizer.DoorTable[num8] = new Vector3((float)num9, (float)num10);
						}
						else
						{
							Randomizer.Table[num8] = new RandomizerAction(array16[1], num9);
							if (Randomizer.CluesMode && array16[1] == "EV" && num9 % 2 == 0)
							{
								RandomizerClues.AddClue(array16[3], num9 / 2);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0600373D RID: 14141
	public static void getPickup()
	{
		Randomizer.getPickup(Characters.Sein.Position);
	}

	// Token: 0x0600373E RID: 14142
	public static void returnToStart()
	{
		if (Characters.Sein.Abilities.Carry.IsCarrying || !Characters.Sein.Controller.CanMove || !Characters.Sein.Active)
		{
			return;
		}
		if (Items.NightBerry != null)
		{
			Items.NightBerry.transform.position = new Vector3(-755f, -400f);
		}
		Randomizer.Returning = true;
		Characters.Sein.Position = new Vector3(189f, -215f);
		Characters.Ori.Position = new Vector3(190f, -210f);
		int value = World.Events.Find(Randomizer.MistySim).Value;
		if (value != 1 && value != 8)
		{
			World.Events.Find(Randomizer.MistySim).Value = 10;
		}
	}

	// Token: 0x0600373F RID: 14143
	public static void getEvent(int ID)
	{
		RandomizerBonus.CollectPickup();
		if (Randomizer.ColorShift)
		{
			Randomizer.changeColor();
		}
		RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[ID * 4], ID * 4, true);
	}

	// Token: 0x06003740 RID: 14144
	public static void showHint(string message)
	{
		Randomizer.Message = message;
		Randomizer.MessageQueue.Enqueue(message);
	}

	// Token: 0x06003741 RID: 14145
	public static void playLastMessage()
	{
		Randomizer.MessageQueue.Enqueue(Randomizer.Message);
	}

	// Token: 0x06003742 RID: 14146
	public static void log(string message)
	{
		StreamWriter streamWriter = File.AppendText("randomizer.log");
		streamWriter.WriteLine(message);
		streamWriter.Flush();
		streamWriter.Dispose();
	}

	// Token: 0x06003743 RID: 14147
	public static bool WindRestored()
	{
		return Sein.World.Events.WindRestored && Scenes.Manager.CurrentScene != null && Scenes.Manager.CurrentScene.Scene != "forlornRuinsResurrection" && Scenes.Manager.CurrentScene.Scene != "forlornRuinsRotatingLaserFlipped";
	}

	// Token: 0x06003744 RID: 14148
	public static void getSkill()
	{
		Characters.Sein.Inventory.SkillPointsCollected += 134217728;
		Randomizer.getPickup();
		Randomizer.showProgress();
	}

	// Token: 0x06003745 RID: 14149
	public static void hintAndLog(float x, float y)
	{
		string message = ((int)x).ToString() + " " + ((int)y).ToString();
		Randomizer.showHint(message);
		Randomizer.log(message);
	}

	// Token: 0x06003746 RID: 14150
	public static void getPickup(Vector3 position)
	{
		RandomizerBonus.CollectPickup();
		if (Randomizer.ColorShift)
		{
			Randomizer.changeColor();
		}
		int num = (int)(Math.Floor((double)((int)position.x) / Randomizer.GridFactor) * Randomizer.GridFactor) * 10000 + (int)(Math.Floor((double)((int)position.y) / Randomizer.GridFactor) * Randomizer.GridFactor);
		if (Randomizer.Table.ContainsKey(num))
		{
			RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[num], num, true);
			return;
		}
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				if (Randomizer.Table.ContainsKey(num + (int)Randomizer.GridFactor * (10000 * i + j)))
				{
					RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[num + (int)Randomizer.GridFactor * (10000 * i + j)], num + (int)Randomizer.GridFactor * (10000 * i + j), true);
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
					RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[num + (int)Randomizer.GridFactor * (10000 * k + l)], num + (int)Randomizer.GridFactor * (10000 * k + l), true);
					return;
				}
			}
		}
		Randomizer.showHint("Error finding pickup at " + ((int)position.x).ToString() + ", " + ((int)position.y).ToString());
	}

	// Token: 0x06003747 RID: 14151
	public static void Update()
	{
		Randomizer.UpdateMessages();
		if (Characters.Sein && !Characters.Sein.IsSuspended)
		{
			Characters.Sein.Mortality.Health.GainHealth((float)RandomizerBonus.HealthRegeneration() * (Characters.Sein.PlayerAbilities.HealthEfficiency.HasAbility ? 0.0016f : 0.0008f));
			Characters.Sein.Energy.Gain((float)RandomizerBonus.EnergyRegeneration() * (Characters.Sein.PlayerAbilities.EnergyEfficiency.HasAbility ? 0.0003f : 0.0002f));
			if (Randomizer.ForceTrees && Scenes.Manager.CurrentScene != null && Scenes.Manager.CurrentScene.Scene == "catAndMouseResurrectionRoom" && RandomizerBonus.SkillTreeProgression() < 10)
			{
				Randomizer.MessageQueue.Enqueue("Trees (" + RandomizerBonus.SkillTreeProgression().ToString() + "/10)");
				if (Randomizer.Entrance)
				{
					Randomizer.EnterDoor(new Vector3(-242f, 489f));
				}
				else
				{
					Characters.Sein.Position = new Vector3(20f, 105f);
				}
			}
			if (Randomizer.Chaos)
			{
				RandomizerChaosManager.Update();
			}
			if (Randomizer.Sync)
			{
				RandomizerSyncManager.Update();
			}
			if (Randomizer.Returning)
			{
				Characters.Sein.Position = new Vector3(189f, -215f);
				Characters.Ori.Position = new Vector3(190f, -210f);
				Randomizer.Returning = false;
			}
		}
		if (RandomizerRebinding.ReplayMessage.IsPressed())
		{
			Randomizer.playLastMessage();
			return;
		}
		if (RandomizerRebinding.ReturnToStart.IsPressed() && Characters.Sein)
		{
			Randomizer.returnToStart();
			return;
		}
		if (RandomizerRebinding.ReloadSeed.IsPressed())
		{
			Randomizer.initialize();
			Randomizer.showSeedInfo();
			return;
		}
		if (RandomizerRebinding.ShowProgress.IsPressed() && Characters.Sein)
		{
			Randomizer.showProgress();
			return;
		}
		if (RandomizerRebinding.ColorShift.IsPressed())
		{
			string obj = "Color shift enabled";
			if (Randomizer.ColorShift)
			{
				obj = "Color shift disabled";
			}
			Randomizer.ColorShift = !Randomizer.ColorShift;
			Randomizer.MessageQueue.Enqueue(obj);
		}
		if (RandomizerRebinding.ToggleChaos.IsPressed() && Characters.Sein)
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
		else if (RandomizerRebinding.ChaosVerbosity.IsPressed() && Randomizer.Chaos)
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
		else
		{
			if (RandomizerRebinding.ForceChaosEffect.IsPressed() && Randomizer.Chaos && Characters.Sein)
			{
				RandomizerChaosManager.SpawnEffect();
				return;
			}
			return;
		}
	}

	// Token: 0x06003748 RID: 14152
	public static void showChaosEffect(string message)
	{
		if (Randomizer.ChaosVerbose)
		{
			Randomizer.MessageQueue.Enqueue(message);
		}
	}

	// Token: 0x06003749 RID: 14153
	public static void showChaosMessage(string message)
	{
		Randomizer.MessageQueue.Enqueue(message);
	}

	// Token: 0x0600374A RID: 14154
	public static void getMapStone()
	{
		if (!Randomizer.ProgressiveMapStones)
		{
			Randomizer.getPickup();
			return;
		}
		RandomizerBonus.CollectPickup();
		if (Randomizer.ColorShift)
		{
			Randomizer.changeColor();
		}
		Characters.Sein.Inventory.SkillPointsCollected += 8388608;
		RandomizerSwitch.GivePickup((RandomizerAction)Randomizer.Table[20 + RandomizerBonus.MapStoneProgression() * 4], 20 + RandomizerBonus.MapStoneProgression() * 4, true);
	}

	// Token: 0x0600374B RID: 14155
	public static void showProgress()
	{
		string text = "";
		if (RandomizerBonus.SkillTreeProgression() < 10)
		{
			text = text + "Trees (" + RandomizerBonus.SkillTreeProgression().ToString() + "/10)  ";
		}
		else
		{
			text += "$Trees (10/10)$  ";
		}
		text = text + "Maps (" + RandomizerBonus.MapStoneProgression().ToString() + "/9)  ";
		text = text + "Total (" + RandomizerBonus.GetPickupCount().ToString() + "/248)\n";
		if (Randomizer.CluesMode)
		{
			text += RandomizerClues.GetClues();
		}
		else
		{
			if (Keys.GinsoTree)
			{
				text += "*WV (3/3)*  ";
			}
			else
			{
				text = text + " *WV* (" + RandomizerBonus.WaterVeinShards().ToString() + "/3)  ";
			}
			if (Keys.ForlornRuins)
			{
				text += "#GS (3/3)#  ";
			}
			else
			{
				text = text + "#GS# (" + RandomizerBonus.GumonSealShards().ToString() + "/3)  ";
			}
			if (Keys.MountHoru)
			{
				text += "@SS (3/3)@";
			}
			else
			{
				text = text + " @SS@ (" + RandomizerBonus.SunstoneShards().ToString() + "/3)";
			}
		}
		Randomizer.MessageQueue.Enqueue(text);
	}

	// Token: 0x0600374C RID: 14156
	public static void showSeedInfo()
	{
		string obj = "v2.6 - seed loaded: " + Randomizer.SeedMeta;
		Randomizer.MessageQueue.Enqueue(obj);
	}

	// Token: 0x0600374D RID: 14157
	public static void changeColor()
	{
		if (Characters.Sein)
		{
			Characters.Sein.PlatformBehaviour.Visuals.SpriteRenderer.material.color = new Color(FixedRandom.Values[0], FixedRandom.Values[1], FixedRandom.Values[2], 0.5f);
		}
	}

	// Token: 0x0600374E RID: 14158
	public static void UpdateMessages()
	{
		if (Randomizer.MessageQueueTime == 0)
		{
			if (Randomizer.MessageQueue.Count == 0)
			{
				return;
			}
			Randomizer.MessageProvider.SetMessage((string)Randomizer.MessageQueue.Dequeue());
			UI.Hints.Show(Randomizer.MessageProvider, HintLayer.GameSaved, 3f);
			Randomizer.MessageQueueTime = 90;
		}
		Randomizer.MessageQueueTime--;
	}

	// Token: 0x0600374F RID: 14159
	public static void EnterDoor(Vector3 position)
	{
		if (!Randomizer.Entrance)
		{
			return;
		}
		int num = (int)(Math.Floor((double)((int)position.x) / Randomizer.GridFactor) * Randomizer.GridFactor) * 10000 + (int)(Math.Floor((double)((int)position.y) / Randomizer.GridFactor) * Randomizer.GridFactor);
		if (Randomizer.DoorTable.ContainsKey(num))
		{
			Characters.Sein.Position = (Vector3)Randomizer.DoorTable[num];
			return;
		}
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				if (Randomizer.DoorTable.ContainsKey(num + (int)Randomizer.GridFactor * (10000 * i + j)))
				{
					Characters.Sein.Position = (Vector3)Randomizer.DoorTable[num + (int)Randomizer.GridFactor * (10000 * i + j)];
					return;
				}
			}
		}
		for (int k = -2; k <= 2; k += 4)
		{
			for (int l = -1; l <= 1; l++)
			{
				if (Randomizer.DoorTable.ContainsKey(num + (int)Randomizer.GridFactor * (10000 * k + l)))
				{
					Characters.Sein.Position = (Vector3)Randomizer.DoorTable[num + (int)Randomizer.GridFactor * (10000 * k + l)];
					return;
				}
			}
		}
		Randomizer.showHint("Error using door at " + ((int)position.x).ToString() + ", " + ((int)position.y).ToString());
	}

	// Token: 0x06003829 RID: 14377
	public static void LoadHoruLavaData()
	{
		Randomizer.HoruData = new ArrayList();
		Randomizer.HoruData.Add(new MoonGuid(1174226403, -1289471298, -20779974, -149801993));
		Randomizer.HoruData.Add(new object[]
		{
			new MoonGuid(1080329339, 1302332310, 997858217, -1469178753),
			new byte[256]
		});
		Randomizer.HoruData.Add(new object[]
		{
			new MoonGuid(-1986835227, 1148497250, 1774981778, -341693584),
			new byte[256]
		});
		Randomizer.HoruData.Add(new object[]
		{
			new MoonGuid(-1914403931, 1340852204, -1427003988, -1275885270),
			new byte[256]
		});
		Randomizer.HoruData.Add(new object[]
		{
			new MoonGuid(1195046299, 1104194907, -91023438, -1960550170),
			new byte[256]
		});
		Randomizer.HoruData.Add(new object[]
		{
			new MoonGuid(1830640752, 1138663465, 465415606, 1194710081),
			new byte[256]
		});
		Randomizer.HoruData.Add(new object[]
		{
			new MoonGuid(474831249, 1150619186, -1835199831, 1753869200),
			new byte[256]
		});
		Randomizer.HoruData.Add(new object[]
		{
			new MoonGuid(-693646328, 1189415106, 886443144, -618934573),
			new byte[256]
		});
		ArrayList horuData = Randomizer.HoruData;
		object[] array = new object[2];
		array[0] = new MoonGuid(1383380092, 1339453148, 41555390, 2136907469);
		int num = 1;
		byte[] array2 = new byte[256];
		array2[3] = 128;
		array2[4] = 64;
		array[num] = array2;
		horuData.Add(array);
		Randomizer.HoruData.Add(new object[]
		{
			new MoonGuid(924649609, 1244424682, -1334463316, 1549855571),
			new byte[]
			{
				0,
				103,
				102,
				150,
				64,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}
		});
		ArrayList horuData2 = Randomizer.HoruData;
		object[] array3 = new object[2];
		array3[0] = new MoonGuid(-1402173694, 1299423500, 1804027269, 1017599821);
		int num2 = 1;
		byte[] array4 = new byte[256];
		array4[3] = 128;
		array4[4] = 64;
		array3[num2] = array4;
		horuData2.Add(array3);
		ArrayList horuData3 = Randomizer.HoruData;
		object[] array5 = new object[2];
		array5[0] = new MoonGuid(-680939306, 1295367481, -376876104, -1744906711);
		int num3 = 1;
		byte[] array6 = new byte[256];
		array6[3] = 192;
		array6[4] = 64;
		array5[num3] = array6;
		horuData3.Add(array5);
		ArrayList horuData4 = Randomizer.HoruData;
		object[] array7 = new object[2];
		array7[0] = new MoonGuid(-996043504, 1245827845, 459586237, 422546073);
		int num4 = 1;
		byte[] array8 = new byte[256];
		array8[3] = 128;
		array8[4] = 64;
		array7[num4] = array8;
		horuData4.Add(array7);
		ArrayList horuData5 = Randomizer.HoruData;
		object[] array9 = new object[2];
		array9[0] = new MoonGuid(2118314447, 1335917205, -744314961, 209622932);
		int num5 = 1;
		byte[] array10 = new byte[256];
		array10[3] = 128;
		array10[4] = 64;
		array9[num5] = array10;
		horuData5.Add(array9);
		Randomizer.HoruData.Add(new object[]
		{
			new MoonGuid(844679839, 1270988107, -265306192, -1530626037),
			new byte[]
			{
				0,
				103,
				102,
				150,
				64,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}
		});
		ArrayList horuData6 = Randomizer.HoruData;
		object[] array11 = new object[2];
		array11[0] = new MoonGuid(-1282946185, 1268760771, -1657185898, 636602458);
		int num6 = 1;
		byte[] array12 = new byte[256];
		array12[3] = 128;
		array12[4] = 64;
		array11[num6] = array12;
		horuData6.Add(array11);
		ArrayList horuData7 = Randomizer.HoruData;
		object[] array13 = new object[2];
		array13[0] = new MoonGuid(1881578213, 1232349697, -73649234, -1986038739);
		int num7 = 1;
		byte[] array14 = new byte[256];
		array14[3] = 192;
		array14[4] = 64;
		array13[num7] = array14;
		horuData7.Add(array13);
	}

	// Token: 0x0600384D RID: 14413
	public static void LoadGinsoData()
	{
		Randomizer.GinsoData = new ArrayList();
		Randomizer.GinsoData.Add(new MoonGuid(-621650313, -674963838, -832550168, 489134658));
		ArrayList ginsoData = Randomizer.GinsoData;
		object[] array = new object[2];
		array[0] = new MoonGuid(-879418902, 1319388701, -1755139450, 1851185350);
		int num = 1;
		byte[] array2 = new byte[256];
		array2[4] = 1;
		array2[5] = 1;
		array[num] = array2;
		ginsoData.Add(array);
		Randomizer.GinsoData.Add(new object[]
		{
			new MoonGuid(1324518397, 1149015201, -342925943, -1484855282),
			new byte[256]
		});
		Randomizer.GinsoData.Add(new object[]
		{
			new MoonGuid(-1222076681, 1097457951, 624111247, 1604299134),
			new byte[]
			{
				0,
				0,
				64,
				64,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}
		});
		Randomizer.GinsoData.Add(new object[]
		{
			new MoonGuid(-991392970, 1255782968, -2024499810, 1164929613),
			new byte[]
			{
				0,
				0,
				32,
				64,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			}
		});
	}

	// Token: 0x0400322B RID: 12843
	public static Hashtable Table;

	// Token: 0x0400322C RID: 12844
	public static bool GiveAbility;

	// Token: 0x0400322D RID: 12845
	public static double GridFactor;

	// Token: 0x0400322E RID: 12846
	public static RandomizerMessageProvider MessageProvider;

	// Token: 0x0400322F RID: 12847
	public static bool OHKO;

	// Token: 0x04003230 RID: 12848
	public static bool ZeroXP;

	// Token: 0x04003231 RID: 12849
	public static bool BonusActive;

	// Token: 0x04003232 RID: 12850
	public static string Message;

	// Token: 0x04003233 RID: 12851
	public static bool Chaos;

	// Token: 0x04003234 RID: 12852
	public static bool ChaosVerbose;

	// Token: 0x04003235 RID: 12853
	public static float DamageModifier;

	// Token: 0x04003236 RID: 12854
	public static bool ProgressiveMapStones;

	// Token: 0x04003237 RID: 12855
	public static bool ForceTrees;

	// Token: 0x04003238 RID: 12856
	public static string SeedMeta;

	// Token: 0x04003239 RID: 12857
	public static Hashtable TeleportTable;

	// Token: 0x0400323A RID: 12858
	public static WorldEvents MistySim;

	// Token: 0x0400323B RID: 12859
	public static bool Returning;

	// Token: 0x0400323C RID: 12860
	public static bool CluesMode;

	// Token: 0x0400323D RID: 12861
	public static bool ColorShift;

	// Token: 0x0400323E RID: 12862
	public static Queue MessageQueue;

	// Token: 0x0400323F RID: 12863
	public static int MessageQueueTime;

	// Token: 0x04003240 RID: 12864
	public static bool Sync;

	// Token: 0x04003241 RID: 12865
	public static string SyncId;

	// Token: 0x04003242 RID: 12866
	public static int SyncMode;

	// Token: 0x04003243 RID: 12867
	public static string ShareParams;

	// Token: 0x04003244 RID: 12868
	public static bool Entrance;

	// Token: 0x04003245 RID: 12869
	public static Hashtable DoorTable;

	// Token: 0x04003246 RID: 12870
	public static bool QueueBash;

	// Token: 0x04003247 RID: 12871
	public static bool BashWasQueued;

	// Token: 0x04003248 RID: 12872
	public static bool BashTap;

	// Token: 0x04003249 RID: 12873
	public static ArrayList HoruData;

	// Token: 0x0400324A RID: 12874
	public static bool NoLava;

	// Token: 0x0400330D RID: 13069
	public static ArrayList GinsoData;
}
