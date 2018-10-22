using System;
using System.Collections.Generic;
using Game;
using UnityEngine;
using Sein.World;

public static class RandomizerTrackedDataManager
{
	public static void Initialize()
	{
		AllTrees = new Dictionary<int, string>();
		AllTrees.Add(0, "Spirit Flame");
		AllTrees.Add(1, "Wall Jump");
		AllTrees.Add(2, "Charge Flame");
		AllTrees.Add(3, "Double Jump");
		AllTrees.Add(4, "Bash");
		AllTrees.Add(5, "Stomp");
		AllTrees.Add(6, "Glide");
		AllTrees.Add(7, "Climb");
		AllTrees.Add(8, "Charge Jump");
		AllTrees.Add(9, "Grenade");
		AllTrees.Add(10, "Dash");

		AllRelics = new Dictionary<string, int>();
		AllRelics.Add("Glades", 0);
		AllRelics.Add("Grove", 1);
		AllRelics.Add("Grotto", 2);
		AllRelics.Add("Blackroot", 3);
		AllRelics.Add("Swamp", 4);
		AllRelics.Add("Ginso", 5);
		AllRelics.Add("Valley", 6);
		AllRelics.Add("Misty", 7);
		AllRelics.Add("Forlorn", 8);
		AllRelics.Add("Sorrow", 9);
		AllRelics.Add("Horu", 10);

		AllPedistals = new Dictionary<string, MapstoneData>();
		AllPedistals.Add("sunkenGlades", new MapstoneData("Glades", 0));
		AllPedistals.Add("mangrove", new MapstoneData("Blackroot", 1));
		AllPedistals.Add("hollowGrove", new MapstoneData("Grove", 2));
		AllPedistals.Add("moonGrotto", new MapstoneData("Grotto", 3));
		AllPedistals.Add("thornfeltSwamp", new MapstoneData("Swamp", 4));
		AllPedistals.Add("valleyOfTheWind", new MapstoneData("Valley", 5));
		AllPedistals.Add("forlornRuins", new MapstoneData("Forlorn", 6));
		AllPedistals.Add("sorrowPass", new MapstoneData("Sorrow", 7));
		AllPedistals.Add("mountHoru", new MapstoneData("Horu", 8));

		AllTeleporters = new Dictionary<string, int>();

		AllTeleporters.Add("Grove", 0);
		AllTeleporters.Add("Swamp", 1);
		AllTeleporters.Add("Grotto", 2);
		AllTeleporters.Add("Valley", 3);
		AllTeleporters.Add("Forlorn", 4);
		AllTeleporters.Add("Sorrow", 5);
		AllTeleporters.Add("Ginso", 6);
		AllTeleporters.Add("Horu", 7);

	}

	public static void UpdateBitfields() {
		if(Characters.Sein)
		{
			TreeBitfield = Characters.Sein.Inventory.GetRandomizerItem(1001);
			RelicBitfield = Characters.Sein.Inventory.GetRandomizerItem(1002);
			MapstoneBitfield = Characters.Sein.Inventory.GetRandomizerItem(1003);
			TeleporterBitfield = GetTeleporters();
			KeyEventBitfield = GetKeyEvents();
		}
	}

	public static int GetKeyEvents() {
		int bf = 0;
		int wvShards = RandomizerBonus.WaterVeinShards();
		int gsShards = RandomizerBonus.GumonSealShards();
		int ssShards = RandomizerBonus.SunstoneShards();
		if(wvShards > 0)
			bf += 1 << 0;
		if(wvShards > 1)
			bf += 1 << 1;
		if(Keys.GinsoTree)
			bf += 1 << 2;
		if(gsShards > 0)
			bf += 1 << 3;
		if(gsShards > 1)
			bf += 1 << 4;
		if(Keys.ForlornRuins)
			bf += 1 << 5;
		if(ssShards > 0)
			bf += 1 << 6;
		if(ssShards > 1)
			bf += 1 << 7;
		if(Keys.MountHoru)
			bf += 1 << 8;
		if(Sein.World.Events.WaterPurified)
			bf += 1 << 9;
		if(Sein.World.Events.WindRestored)
			bf += 1 << 10;
		bf += RandomizerBonus.WarmthFrags() << 11;
		return bf;
	}

	public static int GetTeleporters() {
		int bf = 0;
		List<string> unlockedTPids = new List<string>();
		foreach (GameMapTeleporter gameMapTP in TeleporterController.Instance.Teleporters)
		{
			unlockedTPids.Add(gameMapTP.Identifier);
		}
		foreach(KeyValuePair<string, int> tp in AllTeleporters) {
			if(unlockedTPids.Contains(Randomizer.TeleportTable[tp.Key].ToString())) {
				bf += 1 << tp.Value;
			}
		}
		return bf;
	}

	public static void ListTeleporters() {
		UpdateBitfields();
		List<string> owned = new List<string>();
		List<string> unowned = new List<string>();
		foreach(KeyValuePair<string, int> tp in AllTeleporters) {
			if((TeleporterBitfield >> tp.Value) % 2 == 1) {
				owned.Add(tp.Key);
			} else {
				unowned.Add(tp.Key);
			}
		}
		string ownedLine   = "TPs active: " + string.Join(",", owned.ToArray());
		string unownedLine = "remaining: " + string.Join(",", unowned.ToArray());
		Randomizer.showHint(ownedLine + "\n" + unownedLine);
	}

	public static void ListTrees() {
		UpdateBitfields();
		List<string> owned = new List<string>();
		List<string> unowned = new List<string>();
		foreach(KeyValuePair<int, string> tree in AllTrees) {
			if(tree.Key == 0) {
				continue;
			}
			if((TreeBitfield >> tree.Key) % 2 == 1) {
				owned.Add(tree.Value);
			} else {
				unowned.Add(tree.Value);
			}
		}
		string ownedLine = "Trees active: " + string.Join(",", owned.ToArray());
		string unownedLine = "remaining: " + string.Join(",", unowned.ToArray());
		Randomizer.showHint(ownedLine + "\n" + unownedLine);
	}

	public static void ListRelics() {
		UpdateBitfields();
		List<string> owned = new List<string>();
		List<string> unowned = new List<string>();
		foreach(KeyValuePair<string, int> relic in AllRelics) {
			if((RelicBitfield >> relic.Value) % 2 == 1) {
				owned.Add(relic.Key);
			} else {
				unowned.Add(relic.Key);
			}
		}
		string ownedLine = "Relics collected: " + string.Join(",", owned.ToArray());
		string unownedLine = "remaining: " + string.Join(",", unowned.ToArray());
		Randomizer.showHint(ownedLine + "\n" + unownedLine);
	}

	public static void ListMapstones() {
		UpdateBitfields();
		List<string> owned = new List<string>();
		List<string> unowned = new List<string>();
		foreach(MapstoneData data in AllPedistals.Values) {
			if((MapstoneBitfield >> data.Bit) % 2 == 1) {
				owned.Add(data.Zone);
			} else {
				unowned.Add(data.Zone);
			}
		}
		string ownedLine = "Altars active: " + string.Join(",", owned.ToArray());
		string unownedLine = "remaining: " + string.Join(",", unowned.ToArray());
		Randomizer.showHint(ownedLine + "\n" + unownedLine);
	}


	public static void SetTree(int treeNum) {
		if(!GetTree(treeNum)) {
			TreeBitfield = Characters.Sein.Inventory.IncRandomizerItem(1001, 1 << treeNum);
		}
	}

	public static bool GetTree(int treeNum) {
		return (TreeBitfield >> treeNum) % 2 == 1;
	}

	public static void SetRelic(string zone) {
		if(!GetRelic(zone)) {
			RelicBitfield = Characters.Sein.Inventory.IncRandomizerItem(1002, 1 << AllRelics[zone]);
		}
	}

	public static bool GetRelic(string zone) {
		return (RelicBitfield >> AllRelics[zone]) % 2 == 1;
	}

	public static void SetMapstone(string areaIdentifier) {
		try {
			MapstoneData data = AllPedistals[areaIdentifier];
			if(!GetMapstone(data)) {
				MapstoneBitfield = Characters.Sein.Inventory.IncRandomizerItem(1003, (1 << data.Bit));
			} 
		} 
		catch(Exception e) {
			Randomizer.showHint("@SetMapstone:@ area " + areaIdentifier + ": " + e.Message);
		}
	}

	public static bool GetMapstone(MapstoneData data) {
		return (MapstoneBitfield >> data.Bit) % 2 == 1;
	}

	public static int TreeBitfield;
	public static int MapstoneBitfield;
	public static int TeleporterBitfield;
	public static int RelicBitfield;
	public static int KeyEventBitfield;

	// Token: 0x040032E2 RID: 13026
	public static Dictionary<int, string> AllTrees;

	public static Dictionary<string, int> AllRelics;

	public static Dictionary<string, int> AllTeleporters;

	public static Dictionary<string, MapstoneData> AllPedistals;
	// Token: 0x02000A1B RID: 2587
	public class MapstoneData
	{
		// Token: 0x06003815 RID: 14357 RVA: 0x0002C10D File Offset: 0x0002A30D
		public MapstoneData(string zone, int bit)
		{
			this.Bit = bit;
			this.Zone = zone;
		}

		public int Bit;
		public string Zone;
	}
}
