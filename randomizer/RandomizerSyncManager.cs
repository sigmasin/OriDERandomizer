using System;
using System.Collections.Generic;
using System.Net;
using Game;
using Sein.World;

// Token: 0x020009FF RID: 2559
public static class RandomizerSyncManager
{
	// Token: 0x06003793 RID: 14227
	public static void Initialize()
	{
		RandomizerSyncManager.Countdown = 60 * RandomizerSyncManager.PERIOD;
		RandomizerSyncManager.webClient = new WebClient();
		RandomizerSyncManager.webClient.DownloadStringCompleted += RandomizerSyncManager.RetryOnFail;
		RandomizerSyncManager.getClient = new WebClient();
		RandomizerSyncManager.getClient.DownloadStringCompleted += RandomizerSyncManager.CheckPickups;
		RandomizerSyncManager.SendingPickup = null;
		if (RandomizerSyncManager.UnsavedPickups == null)
		{
			RandomizerSyncManager.UnsavedPickups = new List<RandomizerSyncManager.Pickup>();
		}
		if (RandomizerSyncManager.PickupQueue == null)
		{
			RandomizerSyncManager.PickupQueue = new Queue<RandomizerSyncManager.Pickup>();
		}
		RandomizerSyncManager.LoseOnDeath = new HashSet<string>();
		RandomizerSyncManager.SkillInfos = new List<RandomizerSyncManager.SkillInfoLine>();
		RandomizerSyncManager.EventInfos = new List<RandomizerSyncManager.EventInfoLine>();
		RandomizerSyncManager.UpgradeInfos = new List<RandomizerSyncManager.UpgradeInfoLine>();
		RandomizerSyncManager.TeleportInfos = new List<RandomizerSyncManager.TeleportInfoLine>();
		RandomizerSyncManager.TeleportInfos.Add(new RandomizerSyncManager.TeleportInfoLine("Grove", 0));
		RandomizerSyncManager.TeleportInfos.Add(new RandomizerSyncManager.TeleportInfoLine("Swamp", 1));
		RandomizerSyncManager.TeleportInfos.Add(new RandomizerSyncManager.TeleportInfoLine("Grotto", 2));
		RandomizerSyncManager.TeleportInfos.Add(new RandomizerSyncManager.TeleportInfoLine("Valley", 3));
		RandomizerSyncManager.TeleportInfos.Add(new RandomizerSyncManager.TeleportInfoLine("Forlorn", 4));
		RandomizerSyncManager.TeleportInfos.Add(new RandomizerSyncManager.TeleportInfoLine("Sorrow", 5));
		RandomizerSyncManager.SkillInfos.Add(new RandomizerSyncManager.SkillInfoLine(0, 0, AbilityType.Bash));
		RandomizerSyncManager.SkillInfos.Add(new RandomizerSyncManager.SkillInfoLine(2, 1, AbilityType.ChargeFlame));
		RandomizerSyncManager.SkillInfos.Add(new RandomizerSyncManager.SkillInfoLine(3, 2, AbilityType.WallJump));
		RandomizerSyncManager.SkillInfos.Add(new RandomizerSyncManager.SkillInfoLine(4, 3, AbilityType.Stomp));
		RandomizerSyncManager.SkillInfos.Add(new RandomizerSyncManager.SkillInfoLine(5, 4, AbilityType.DoubleJump));
		RandomizerSyncManager.SkillInfos.Add(new RandomizerSyncManager.SkillInfoLine(8, 5, AbilityType.ChargeJump));
		RandomizerSyncManager.SkillInfos.Add(new RandomizerSyncManager.SkillInfoLine(12, 6, AbilityType.Climb));
		RandomizerSyncManager.SkillInfos.Add(new RandomizerSyncManager.SkillInfoLine(14, 7, AbilityType.Glide));
		RandomizerSyncManager.SkillInfos.Add(new RandomizerSyncManager.SkillInfoLine(50, 8, AbilityType.Dash));
		RandomizerSyncManager.SkillInfos.Add(new RandomizerSyncManager.SkillInfoLine(51, 9, AbilityType.Grenade));
		RandomizerSyncManager.EventInfos.Add(new RandomizerSyncManager.EventInfoLine(0, 0, () => Keys.GinsoTree));
		RandomizerSyncManager.EventInfos.Add(new RandomizerSyncManager.EventInfoLine(1, 1, () => Sein.World.Events.WaterPurified));
		RandomizerSyncManager.EventInfos.Add(new RandomizerSyncManager.EventInfoLine(2, 2, () => Keys.ForlornRuins));
		RandomizerSyncManager.EventInfos.Add(new RandomizerSyncManager.EventInfoLine(3, 3, () => Sein.World.Events.WindRestored));
		RandomizerSyncManager.EventInfos.Add(new RandomizerSyncManager.EventInfoLine(4, 4, () => Keys.MountHoru));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(17, 0, true, () => RandomizerBonus.WaterVeinShards()));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(19, 1, true, () => RandomizerBonus.GumonSealShards()));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(21, 2, true, () => RandomizerBonus.SunstoneShards()));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(6, 3, true, () => RandomizerBonus.SpiritFlameLevel()));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(13, 4, true, () => RandomizerBonus.HealthRegeneration()));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(15, 5, true, () => RandomizerBonus.EnergyRegeneration()));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(8, 12, false, delegate
		{
			if (!RandomizerBonus.ExplosionPower())
			{
				return 0;
			}
			return 1;
		}));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(9, 13, false, delegate
		{
			if (!RandomizerBonus.ExpEfficiency())
			{
				return 0;
			}
			return 1;
		}));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(10, 14, false, delegate
		{
			if (!RandomizerBonus.DoubleAirDash())
			{
				return 0;
			}
			return 1;
		}));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(11, 15, false, delegate
		{
			if (!RandomizerBonus.ChargeDashEfficiency())
			{
				return 0;
			}
			return 1;
		}));
		RandomizerSyncManager.UpgradeInfos.Add(new RandomizerSyncManager.UpgradeInfoLine(12, 16, false, delegate
		{
			if (!RandomizerBonus.DoubleJumpUpgrade())
			{
				return 0;
			}
			return 1;
		}));
	}

	// Token: 0x06003794 RID: 14228
	public static void Update()
	{
		if (RandomizerSyncManager.SendingPickup == null && RandomizerSyncManager.PickupQueue.Count > 0 && !RandomizerSyncManager.webClient.IsBusy)
		{
			RandomizerSyncManager.SendingPickup = RandomizerSyncManager.PickupQueue.Dequeue();
			RandomizerSyncManager.webClient.DownloadStringAsync(new Uri(RandomizerSyncManager.SendingPickup.GetURL()));
		}
		RandomizerSyncManager.Countdown--;
		if (RandomizerSyncManager.Countdown <= 0 && !RandomizerSyncManager.getClient.IsBusy)
		{
			RandomizerSyncManager.Countdown = 60 * RandomizerSyncManager.PERIOD;
			RandomizerSyncManager.getClient.DownloadStringAsync(new Uri(RandomizerSyncManager.SERVER_ROOT + Randomizer.SyncId));
		}
	}

	// Token: 0x06003795 RID: 14229
	static RandomizerSyncManager()
	{
	}

	// Token: 0x06003796 RID: 14230
	public static bool getBit(int bf, int bit)
	{
		return 1 == (bf >> bit & 1);
	}

	// Token: 0x06003797 RID: 14231
	public static int getTaste(int bf, int taste)
	{
		return bf >> 2 * taste & 3;
	}

	// Token: 0x06003798 RID: 14232
	public static void CheckPickups(object sender, DownloadStringCompletedEventArgs e)
	{
		if (!e.Cancelled && e.Error == null)
		{
			string[] array = e.Result.Split(new char[]
			{
				','
			});
			int bf = int.Parse(array[0]);
			foreach (RandomizerSyncManager.SkillInfoLine skillInfoLine in RandomizerSyncManager.SkillInfos)
			{
				if (RandomizerSyncManager.getBit(bf, skillInfoLine.bit) && !Characters.Sein.PlayerAbilities.HasAbility(skillInfoLine.skill))
				{
					RandomizerSwitch.GivePickup(new RandomizerAction("SK", skillInfoLine.id), 0, false);
				}
			}
			int bf2 = int.Parse(array[1]);
			foreach (RandomizerSyncManager.EventInfoLine eventInfoLine in RandomizerSyncManager.EventInfos)
			{
				if (RandomizerSyncManager.getBit(bf2, eventInfoLine.bit) && !eventInfoLine.checker())
				{
					RandomizerSwitch.GivePickup(new RandomizerAction("EV", eventInfoLine.id), 0, false);
				}
			}
			int bf3 = int.Parse(array[2]);
			foreach (RandomizerSyncManager.UpgradeInfoLine upgradeInfoLine in RandomizerSyncManager.UpgradeInfos)
			{
				if (upgradeInfoLine.stacks)
				{
					if (RandomizerSyncManager.getTaste(bf3, upgradeInfoLine.bit) > upgradeInfoLine.counter())
					{
						RandomizerSwitch.GivePickup(new RandomizerAction("RB", upgradeInfoLine.id), 0, false);
					}
				}
				else if (RandomizerSyncManager.getBit(bf3, upgradeInfoLine.bit) && 1 != upgradeInfoLine.counter())
				{
					RandomizerSwitch.GivePickup(new RandomizerAction("RB", upgradeInfoLine.id), 0, false);
				}
			}
			int bf4 = int.Parse(array[3]);
			foreach (RandomizerSyncManager.TeleportInfoLine teleportInfoLine in RandomizerSyncManager.TeleportInfos)
			{
				if (RandomizerSyncManager.getBit(bf4, teleportInfoLine.bit) && !RandomizerSyncManager.isTeleporterActivated(teleportInfoLine.id))
				{
					RandomizerSwitch.GivePickup(new RandomizerAction("TP", teleportInfoLine.id), 0, false);
				}
			}
			if (array.Length > 4)
			{
				foreach (string signal in array[4].Split(new char[]
				{
					'|'
				}))
				{
					if (!(signal == "haha"))
					{
						if (signal == "stop")
						{
							RandomizerChaosManager.ClearEffects();
						}
					}
					else
					{
						RandomizerChaosManager.SpawnEffect();
					}
					RandomizerSyncManager.webClient.DownloadStringAsync(new Uri(RandomizerSyncManager.SERVER_ROOT + Randomizer.SyncId + "/signalCallback/" + signal));
				}
			}
			return;
		}
	}

	// Token: 0x06003799 RID: 14233
	public static void onSave()
	{
		foreach (RandomizerSyncManager.Pickup item in RandomizerSyncManager.UnsavedPickups)
		{
			RandomizerSyncManager.PickupQueue.Enqueue(item);
		}
		RandomizerSyncManager.UnsavedPickups.Clear();
	}

	// Token: 0x0600379A RID: 14234
	public static void onDeath()
	{
		RandomizerSyncManager.UnsavedPickups.Clear();
	}

	// Token: 0x0600379B RID: 14235
	public static void RetryOnFail(object sender, DownloadStringCompletedEventArgs e)
	{
		if (!e.Cancelled && e.Error == null)
		{
			RandomizerSyncManager.SendingPickup = null;
			return;
		}
		if (e.Error.GetType().Name == "WebException")
		{
			HttpStatusCode statusCode = ((HttpWebResponse)((WebException)e.Error).Response).StatusCode;
			if (statusCode == HttpStatusCode.NotAcceptable)
			{
				RandomizerSyncManager.SendingPickup = null;
				return;
			}
			if (statusCode == HttpStatusCode.PreconditionFailed)
			{
				if (!Randomizer.SyncId.Contains("."))
				{
					Random rnd = new Random();
					Randomizer.showHint("@NO PID FOUND.@");
					Randomizer.showHint("@NEW ONE RANDOMLY BEING GENERATED@");
					Randomizer.showHint("@FIND YOUR GAME (ID " + Randomizer.SyncId + ")@");
					Randomizer.showHint("@GET THE NUMBER THERE@");
					Randomizer.showHint("@PUT IT IN THE SEED LIKE THIS@");
					Randomizer.showHint("SYNC<GID>.<PID> @");
					Randomizer.showHint("@DON'T ALT+L UNTIL YOU DO@");
					Randomizer.showHint("@OR YOU'LL SEE ALL THIS AGAIN ;)@");
					Randomizer.SyncId = Randomizer.SyncId + "." + rnd.Next(1000000, 100000000).ToString();
				}
				string url = string.Concat(new string[]
				{
					RandomizerSyncManager.SERVER_ROOT,
					"getNewGame?mode=",
					Randomizer.SyncMode.ToString(),
					"&shared=",
					Randomizer.ShareParams
				});
				Randomizer.SyncId = RandomizerSyncManager.webClient.DownloadString(new Uri(url));
			}
			if (statusCode == HttpStatusCode.Gone)
			{
				if (RandomizerSyncManager.SendingPickup.type == "RB")
				{
					RandomizerBonus.UpgradeID(-int.Parse(RandomizerSyncManager.SendingPickup.id));
				}
				RandomizerSyncManager.SendingPickup = null;
			}
		}
		RandomizerSyncManager.webClient.DownloadStringAsync(new Uri(RandomizerSyncManager.SendingPickup.GetURL()));
	}

	// Token: 0x0600379C RID: 14236
	public static void FoundPickup(RandomizerAction action, int coords)
	{
		RandomizerSyncManager.Pickup pickup = new RandomizerSyncManager.Pickup(action, coords);
		if (RandomizerSyncManager.LoseOnDeath.Contains(pickup.type + pickup.id))
		{
			RandomizerSyncManager.UnsavedPickups.Add(pickup);
			return;
		}
		RandomizerSyncManager.PickupQueue.Enqueue(pickup);
	}

	// Token: 0x0600379D RID: 14237
	public static bool isTeleporterActivated(string identifier)
	{
		foreach (GameMapTeleporter gameMapTeleporter in TeleporterController.Instance.Teleporters)
		{
			if (gameMapTeleporter.Identifier == Randomizer.TeleportTable[identifier].ToString())
			{
				return gameMapTeleporter.Activated;
			}
		}
		return false;
	}

	// Token: 0x04003268 RID: 12904
	public static int Countdown;

	// Token: 0x04003269 RID: 12905
	public static int PERIOD = 1;

	// Token: 0x0400326A RID: 12906
	public static WebClient webClient;

	// Token: 0x0400326B RID: 12907
	public static string SERVER_ROOT = "http://orirandocoopserver.appspot.com/";

	// Token: 0x0400326C RID: 12908
	public static string lastRaw;

	// Token: 0x0400326D RID: 12909
	public static bool canRun;

	// Token: 0x0400326E RID: 12910
	public static WebClient getClient;

	// Token: 0x0400326F RID: 12911
	public static List<RandomizerSyncManager.Pickup> UnsavedPickups;

	// Token: 0x04003270 RID: 12912
	public static Queue<RandomizerSyncManager.Pickup> PickupQueue;

	// Token: 0x04003271 RID: 12913
	public static List<RandomizerSyncManager.SkillInfoLine> SkillInfos;

	// Token: 0x04003272 RID: 12914
	public static List<RandomizerSyncManager.EventInfoLine> EventInfos;

	// Token: 0x04003273 RID: 12915
	public static List<RandomizerSyncManager.UpgradeInfoLine> UpgradeInfos;

	// Token: 0x04003274 RID: 12916
	public static HashSet<string> LoseOnDeath;

	// Token: 0x04003275 RID: 12917
	public static RandomizerSyncManager.Pickup SendingPickup;

	// Token: 0x04003276 RID: 12918
	public static List<RandomizerSyncManager.TeleportInfoLine> TeleportInfos;

	// Token: 0x02000A00 RID: 2560
	public class Pickup
	{
		// Token: 0x0600379E RID: 14238
		public override bool Equals(object obj)
		{
			if (obj == null || base.GetType() != obj.GetType())
			{
				return false;
			}
			RandomizerSyncManager.Pickup pickup = (RandomizerSyncManager.Pickup)obj;
			return this.type == pickup.type && this.id == pickup.id && this.coords == pickup.coords;
		}

		// Token: 0x0600379F RID: 14239
		public override int GetHashCode()
		{
			return (this.type + this.id).GetHashCode() ^ this.coords.GetHashCode();
		}

		// Token: 0x060037A0 RID: 14240
		public Pickup(string _type, string _id, int _coords)
		{
			this.type = _type;
			this.id = _id;
			this.coords = _coords;
		}

		// Token: 0x060037A1 RID: 14241
		public Pickup(RandomizerAction action, int _coords)
		{
			this.type = action.Action;
			this.id = ((this.type == "TP") ? ((string)action.Value) : ((int)action.Value).ToString());
			this.coords = _coords;
		}

		// Token: 0x060037A2 RID: 14242
		public string GetURL()
		{
			return string.Concat(new object[]
			{
				RandomizerSyncManager.SERVER_ROOT,
				Randomizer.SyncId,
				"/",
				RandomizerSyncManager.SendingPickup.coords,
				"/",
				RandomizerSyncManager.SendingPickup.type,
				"/",
				RandomizerSyncManager.SendingPickup.id
			});
		}

		// Token: 0x04003277 RID: 12919
		public string id;

		// Token: 0x04003278 RID: 12920
		public string type;

		// Token: 0x04003279 RID: 12921
		public int coords;
	}

	// Token: 0x02000A01 RID: 2561
	public class SkillInfoLine
	{
		// Token: 0x060037A3 RID: 14243
		public SkillInfoLine(int _id, int _bit, AbilityType _skill)
		{
			this.bit = _bit;
			this.id = _id;
			this.skill = _skill;
		}

		// Token: 0x060037A4 RID: 14244
		public override bool Equals(object obj)
		{
			if (obj == null || base.GetType() != obj.GetType())
			{
				return false;
			}
			RandomizerSyncManager.SkillInfoLine skillInfoLine = (RandomizerSyncManager.SkillInfoLine)obj;
			return this.bit == skillInfoLine.bit && this.id == skillInfoLine.id && this.skill == skillInfoLine.skill;
		}

		// Token: 0x060037A5 RID: 14245
		public override int GetHashCode()
		{
			return this.skill.GetHashCode() ^ this.id.GetHashCode() ^ this.bit.GetHashCode();
		}

		// Token: 0x0400327A RID: 12922
		public int id;

		// Token: 0x0400327B RID: 12923
		public int bit;

		// Token: 0x0400327C RID: 12924
		public AbilityType skill;
	}

	// Token: 0x02000A02 RID: 2562
	// (Invoke) Token: 0x060037A7 RID: 14247
	public delegate int UpgradeCounter();

	// Token: 0x02000A03 RID: 2563
	public class UpgradeInfoLine
	{
		// Token: 0x060037AA RID: 14250
		public UpgradeInfoLine(int _id, int _bit, bool _stacks, RandomizerSyncManager.UpgradeCounter _counter)
		{
			this.bit = _bit;
			this.id = _id;
			this.stacks = _stacks;
			this.counter = _counter;
		}

		// Token: 0x060037AB RID: 14251
		public override bool Equals(object obj)
		{
			if (obj == null || base.GetType() != obj.GetType())
			{
				return false;
			}
			RandomizerSyncManager.UpgradeInfoLine upgradeInfoLine = (RandomizerSyncManager.UpgradeInfoLine)obj;
			return this.bit == upgradeInfoLine.bit && this.id == upgradeInfoLine.id;
		}

		// Token: 0x060037AC RID: 14252
		public override int GetHashCode()
		{
			return this.bit.GetHashCode() ^ this.id.GetHashCode();
		}

		// Token: 0x0400327D RID: 12925
		public int id;

		// Token: 0x0400327E RID: 12926
		public int bit;

		// Token: 0x0400327F RID: 12927
		public bool stacks;

		// Token: 0x04003280 RID: 12928
		public RandomizerSyncManager.UpgradeCounter counter;
	}

	// Token: 0x02000A04 RID: 2564
	// (Invoke) Token: 0x060037AE RID: 14254
	public delegate bool EventChecker();

	// Token: 0x02000A05 RID: 2565
	public class EventInfoLine
	{
		// Token: 0x060037B1 RID: 14257
		public EventInfoLine(int _id, int _bit, RandomizerSyncManager.EventChecker _checker)
		{
			this.bit = _bit;
			this.id = _id;
			this.checker = _checker;
		}

		// Token: 0x060037B2 RID: 14258
		public override bool Equals(object obj)
		{
			if (obj == null || base.GetType() != obj.GetType())
			{
				return false;
			}
			RandomizerSyncManager.EventInfoLine eventInfoLine = (RandomizerSyncManager.EventInfoLine)obj;
			return this.bit == eventInfoLine.bit && this.id == eventInfoLine.id;
		}

		// Token: 0x060037B3 RID: 14259
		public override int GetHashCode()
		{
			return this.bit.GetHashCode() ^ this.id.GetHashCode();
		}

		// Token: 0x04003281 RID: 12929
		public int id;

		// Token: 0x04003282 RID: 12930
		public RandomizerSyncManager.EventChecker checker;

		// Token: 0x04003283 RID: 12931
		public int bit;
	}

	// Token: 0x02000A07 RID: 2567
	public class TeleportInfoLine
	{
		// Token: 0x060037C6 RID: 14278
		public TeleportInfoLine(string _id, int _bit)
		{
			this.bit = _bit;
			this.id = _id;
		}

		// Token: 0x060037C7 RID: 14279
		public override bool Equals(object obj)
		{
			if (obj == null || base.GetType() != obj.GetType())
			{
				return false;
			}
			RandomizerSyncManager.TeleportInfoLine teleportInfoLine = (RandomizerSyncManager.TeleportInfoLine)obj;
			return this.bit == teleportInfoLine.bit && this.id == teleportInfoLine.id;
		}

		// Token: 0x060037C8 RID: 14280
		public override int GetHashCode()
		{
			return this.bit.GetHashCode() ^ this.id.GetHashCode();
		}

		// Token: 0x04003295 RID: 12949
		public string id;

		// Token: 0x04003296 RID: 12950
		public int bit;
	}
}
