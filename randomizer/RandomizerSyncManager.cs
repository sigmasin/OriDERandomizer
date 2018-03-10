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
		RandomizerSyncManager.getClient = new WebClient();
		RandomizerSyncManager.UnsavedPickups = new List<RandomizerSyncManager.Pickup>();
		RandomizerSyncManager.PickupQueue = new Queue<RandomizerSyncManager.Pickup>();
		RandomizerSyncManager.getClient.DownloadStringCompleted += RandomizerSyncManager.CheckPickups;
		RandomizerSyncManager.LoseOnDeath = new HashSet<RandomizerSyncManager.Pickup>();
		foreach (int i in new int[]
		{
			6,
			13,
			15,
			17,
			19,
			21
		})
		{
			RandomizerSyncManager.LoseOnDeath.Add(new RandomizerSyncManager.Pickup("upgrade", i.ToString()));
		}
	}

	// Token: 0x06003794 RID: 14228
	public static void Update()
	{
		if (RandomizerSyncManager.PickupQueue.Count > 0 && !RandomizerSyncManager.webClient.IsBusy)
		{
			RandomizerSyncManager.Pickup pickup = RandomizerSyncManager.PickupQueue.Dequeue();
			string uriString = string.Concat(new object[]
			{
				RandomizerSyncManager.SERVER_ROOT,
				Randomizer.SyncId,
				"/",
				pickup.type,
				"/",
				pickup.id
			});
			RandomizerSyncManager.webClient.DownloadStringAsync(new Uri(uriString));
		}
		RandomizerSyncManager.Countdown--;
		if (RandomizerSyncManager.Countdown <= 0 && !RandomizerSyncManager.getClient.IsBusy)
		{
			RandomizerSyncManager.Countdown = 60 * RandomizerSyncManager.PERIOD;
			RandomizerSyncManager.getClient.DownloadStringAsync(new Uri(RandomizerSyncManager.SERVER_ROOT + Randomizer.SyncId.ToString()));
		}
	}

	// Token: 0x06003795 RID: 14229
	static RandomizerSyncManager()
	{
	}

	// Token: 0x06003797 RID: 14231
	public static bool getBit(int bf, int bit)
	{
		return 1 == (bf >> bit & 1);
	}

	// Token: 0x06003798 RID: 14232
	public static int getTaste(int bf, int taste)
	{
		return bf >> 2 * taste & 3;
	}

	// Token: 0x0600379B RID: 14235
	public static void CheckPickups(object sender, DownloadStringCompletedEventArgs e)
	{
		if (!e.Cancelled && e.Error == null)
		{
			string[] array = e.Result.Split(new char[]
			{
				','
			});
			int bf4 = int.Parse(array[0]);
			if (RandomizerSyncManager.getBit(bf4, 0) && !Characters.Sein.PlayerAbilities.HasAbility(AbilityType.Bash))
			{
				RandomizerSwitch.AbilityPickup(0);
			}
			if (RandomizerSyncManager.getBit(bf4, 1) && !Characters.Sein.PlayerAbilities.HasAbility(AbilityType.ChargeFlame))
			{
				RandomizerSwitch.AbilityPickup(2);
			}
			if (RandomizerSyncManager.getBit(bf4, 2) && !Characters.Sein.PlayerAbilities.HasAbility(AbilityType.WallJump))
			{
				RandomizerSwitch.AbilityPickup(3);
			}
			if (RandomizerSyncManager.getBit(bf4, 3) && !Characters.Sein.PlayerAbilities.HasAbility(AbilityType.Stomp))
			{
				RandomizerSwitch.AbilityPickup(4);
			}
			if (RandomizerSyncManager.getBit(bf4, 4) && !Characters.Sein.PlayerAbilities.HasAbility(AbilityType.DoubleJump))
			{
				RandomizerSwitch.AbilityPickup(5);
			}
			if (RandomizerSyncManager.getBit(bf4, 5) && !Characters.Sein.PlayerAbilities.HasAbility(AbilityType.ChargeJump))
			{
				RandomizerSwitch.AbilityPickup(8);
			}
			if (RandomizerSyncManager.getBit(bf4, 6) && !Characters.Sein.PlayerAbilities.HasAbility(AbilityType.Climb))
			{
				RandomizerSwitch.AbilityPickup(12);
			}
			if (RandomizerSyncManager.getBit(bf4, 7) && !Characters.Sein.PlayerAbilities.HasAbility(AbilityType.Glide))
			{
				RandomizerSwitch.AbilityPickup(14);
			}
			if (RandomizerSyncManager.getBit(bf4, 8) && !Characters.Sein.PlayerAbilities.HasAbility(AbilityType.Dash))
			{
				RandomizerSwitch.AbilityPickup(50);
			}
			if (RandomizerSyncManager.getBit(bf4, 9) && !Characters.Sein.PlayerAbilities.HasAbility(AbilityType.Grenade))
			{
				RandomizerSwitch.AbilityPickup(51);
			}
			int bf5 = int.Parse(array[1]);
			if (RandomizerSyncManager.getBit(bf5, 0) && !Keys.GinsoTree)
			{
				RandomizerSwitch.EventPickup(0);
			}
			if (RandomizerSyncManager.getBit(bf5, 1) && !Sein.World.Events.WaterPurified)
			{
				RandomizerSwitch.EventPickup(1);
			}
			if (RandomizerSyncManager.getBit(bf5, 2) && !Keys.ForlornRuins)
			{
				RandomizerSwitch.EventPickup(2);
			}
			if (RandomizerSyncManager.getBit(bf5, 3) && !Sein.World.Events.WindRestored)
			{
				RandomizerSwitch.EventPickup(3);
			}
			if (RandomizerSyncManager.getBit(bf5, 4) && !Keys.MountHoru)
			{
				RandomizerSwitch.EventPickup(4);
			}
			int bf3 = int.Parse(array[2]);
			int i = RandomizerSyncManager.getTaste(bf3, 0);
			while (i > RandomizerBonus.WaterVeinShards())
			{
				RandomizerBonus.UpgradeID(17);
			}
			i = RandomizerSyncManager.getTaste(bf3, 1);
			while (i > RandomizerBonus.GumonSealShards())
			{
				RandomizerBonus.UpgradeID(19);
			}
			i = RandomizerSyncManager.getTaste(bf3, 2);
			while (i > RandomizerBonus.SunstoneShards())
			{
				RandomizerBonus.UpgradeID(21);
			}
			i = RandomizerSyncManager.getTaste(bf3, 3);
			while (i > RandomizerBonus.SpiritFlameLevel())
			{
				RandomizerBonus.UpgradeID(6);
			}
			i = RandomizerSyncManager.getTaste(bf3, 4);
			while (i > RandomizerBonus.HealthRegeneration())
			{
				RandomizerBonus.UpgradeID(13);
			}
			i = RandomizerSyncManager.getTaste(bf3, 5);
			while (i > RandomizerBonus.EnergyRegeneration())
			{
				RandomizerBonus.UpgradeID(15);
			}
			if (RandomizerSyncManager.getBit(bf3, 12) && !RandomizerBonus.ExplosionPower())
			{
				RandomizerBonus.UpgradeID(8);
			}
			if (RandomizerSyncManager.getBit(bf3, 13) && !RandomizerBonus.ExpEfficiency())
			{
				RandomizerBonus.UpgradeID(9);
			}
			if (RandomizerSyncManager.getBit(bf3, 14) && !RandomizerBonus.DoubleAirDash())
			{
				RandomizerBonus.UpgradeID(10);
			}
			if (RandomizerSyncManager.getBit(bf3, 15) && !RandomizerBonus.ChargeDashEfficiency())
			{
				RandomizerBonus.UpgradeID(11);
			}
			if (RandomizerSyncManager.getBit(bf3, 16) && !RandomizerBonus.DoubleJumpUpgrade())
			{
				RandomizerBonus.UpgradeID(12);
			}
			int bf6 = int.Parse(array[3]);
			if (RandomizerSyncManager.getBit(bf6, 0))
			{
				TeleporterController.Activate(Randomizer.TeleportTable["Grove"].ToString());
			}
			if (RandomizerSyncManager.getBit(bf6, 1))
			{
				TeleporterController.Activate(Randomizer.TeleportTable["Swamp"].ToString());
			}
			if (RandomizerSyncManager.getBit(bf6, 2))
			{
				TeleporterController.Activate(Randomizer.TeleportTable["Grotto"].ToString());
			}
			if (RandomizerSyncManager.getBit(bf6, 3))
			{
				TeleporterController.Activate(Randomizer.TeleportTable["Valley"].ToString());
			}
			if (RandomizerSyncManager.getBit(bf6, 4))
			{
				TeleporterController.Activate(Randomizer.TeleportTable["Forlorn"].ToString());
			}
			if (RandomizerSyncManager.getBit(bf6, 5))
			{
				TeleporterController.Activate(Randomizer.TeleportTable["Sorrow"].ToString());
			}
			return;
		}
	}

	// Token: 0x060037AA RID: 14250
	public static void onSave()
	{
		foreach (RandomizerSyncManager.Pickup p in RandomizerSyncManager.UnsavedPickups)
		{
			RandomizerSyncManager.PickupQueue.Enqueue(p);
		}
		RandomizerSyncManager.UnsavedPickups.Clear();
	}

	// Token: 0x060037C2 RID: 14274
	public static void FoundPickup(string type, string id)
	{
		RandomizerSyncManager.Pickup p = new RandomizerSyncManager.Pickup(type, id);
		if (RandomizerSyncManager.LoseOnDeath.Contains(p))
		{
			RandomizerSyncManager.UnsavedPickups.Add(p);
			return;
		}
		RandomizerSyncManager.PickupQueue.Enqueue(p);
	}

	// Token: 0x06003826 RID: 14374
	public static void onDeath()
	{
		RandomizerSyncManager.UnsavedPickups.Clear();
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

	// Token: 0x0400329E RID: 12958
	public static List<RandomizerSyncManager.Pickup> UnsavedPickups;

	// Token: 0x0400329F RID: 12959
	public static Queue<RandomizerSyncManager.Pickup> PickupQueue;

	// Token: 0x04003308 RID: 13064
	public static HashSet<RandomizerSyncManager.Pickup> LoseOnDeath;

	// Token: 0x02000A02 RID: 2562
	public class Pickup
	{
		// Token: 0x060037C5 RID: 14277
		public Pickup(string _type, string _id)
		{
			this.type = _type;
			this.id = _id;
		}

		// Token: 0x06003873 RID: 14451
		public override bool Equals(object obj)
		{
			if (obj == null || base.GetType() != obj.GetType())
			{
				return false;
			}
			RandomizerSyncManager.Pickup p = (RandomizerSyncManager.Pickup)obj;
			return this.type == p.type && this.id == p.id;
		}

		// Token: 0x06003874 RID: 14452
		public override int GetHashCode()
		{
			return this.type.GetHashCode() ^ this.id.GetHashCode();
		}

		// Token: 0x04003295 RID: 12949
		public string id;

		// Token: 0x04003296 RID: 12950
		public string type;
	}
}
