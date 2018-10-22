using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

public static class RandomizerTrackedDataManager
{
	public static void Initialize()
	{
		TreeNames = new Dictionary<int, string>();
		TreeNames.Add(0, "Spirit Flame");
		TreeNames.Add(1, "Wall Jump");
		TreeNames.Add(2, "Charge Flame");
		TreeNames.Add(3, "Double Jump");
		TreeNames.Add(4, "Bash");
		TreeNames.Add(5, "Stomp");
		TreeNames.Add(6, "Glide");
		TreeNames.Add(7, "Climb");
		TreeNames.Add(8, "Charge Jump");
		TreeNames.Add(9, "Grenade");
		TreeNames.Add(10, "Dash");

		RelicBits = new Dictionary<string, int>();
		RelicBits.Add("Glades", 0);
		RelicBits.Add("Grove", 1);
		RelicBits.Add("Grotto", 2);
		RelicBits.Add("Blackroot", 3);
		RelicBits.Add("Swamp", 4);
		RelicBits.Add("Ginso", 5);
		RelicBits.Add("Valley", 6);
		RelicBits.Add("Misty", 7);
		RelicBits.Add("Forlorn", 8);
		RelicBits.Add("Sorrow", 9);
		RelicBits.Add("Horu", 10);

		MapstoneInfos = new Dictionary<string, MapstoneData>();
		MapstoneInfos.Add("sunkenGlades", new MapstoneData("Glades", 0));
		MapstoneInfos.Add("mangrove", new MapstoneData("Blackroot", 1));
		MapstoneInfos.Add("hollowGrove", new MapstoneData("Grove", 2));
		MapstoneInfos.Add("moonGrotto", new MapstoneData("Grotto", 3));
		MapstoneInfos.Add("thornfeltSwamp", new MapstoneData("Swamp", 4));
		MapstoneInfos.Add("valleyOfTheWind", new MapstoneData("Valley", 5));
		MapstoneInfos.Add("forlornRuins", new MapstoneData("Forlorn", 6));
		MapstoneInfos.Add("sorrowPass", new MapstoneData("Sorrow", 7));
		MapstoneInfos.Add("mountHoru", new MapstoneData("Horu", 8));

		TeleporterBits = new Dictionary<string, int>();

		TeleporterBits.Add("Grove", 0);
		TeleporterBits.Add("Swamp", 1);
		TeleporterBits.Add("Grotto", 2);
		TeleporterBits.Add("Valley", 3);
		TeleporterBits.Add("Forlorn", 4);
		TeleporterBits.Add("Sorrow", 5);
		TeleporterBits.Add("Ginso", 6);
		TeleporterBits.Add("Horu", 7);

	}

	public static void UpdateBitmaps() {
		if(Characters.Sein)
		{
			TreeBitmap = Characters.Sein.Inventory.GetRandomizerItem(1001);
			RelicBitmap = Characters.Sein.Inventory.GetRandomizerItem(1002);
			MapstoneBitmap = Characters.Sein.Inventory.GetRandomizerItem(1003);
			TeleporterBitmap = GetTeleporters();
		}
	}

	public static int GetTeleporters() {
		int bf = 0;
		List<string> unlockedTPids = new List<string>();
		foreach (GameMapTeleporter gameMapTP in TeleporterController.Instance.Teleporters)
		{
			unlockedTPids.Add(gameMapTP.Identifier);
		}
		foreach(KeyValuePair<string, int> tp in TeleporterBits) {
			if(unlockedTPids.Contains(Randomizer.TeleportTable[tp.Key].ToString())) {
				bf += 1 << tp.Value;
			}
		}
		return bf;
	}

	public static void ListTeleporters() {
		UpdateBitmaps();
		List<string> owned = new List<string>();
		List<string> unowned = new List<string>();
		foreach(KeyValuePair<string, int> tp in TeleporterBits) {
			if((TeleporterBitmap >> tp.Value) % 2 == 1) {
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
		UpdateBitmaps();
		List<string> owned = new List<string>();
		List<string> unowned = new List<string>();
		foreach(KeyValuePair<int, string> tree in TreeNames) {
			if(tree.Key == 0) {
				continue;
			}
			if((TreeBitmap >> tree.Key) % 2 == 1) {
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
		UpdateBitmaps();
		List<string> owned = new List<string>();
		List<string> unowned = new List<string>();
		foreach(KeyValuePair<string, int> relic in RelicBits) {
			if((RelicBitmap >> relic.Value) % 2 == 1) {
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
		UpdateBitmaps();
		List<string> owned = new List<string>();
		List<string> unowned = new List<string>();
		foreach(MapstoneData data in MapstoneInfos.Values) {
			if((MapstoneBitmap >> data.Bit) % 2 == 1) {
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
			TreeBitmap = Characters.Sein.Inventory.IncRandomizerItem(1001, 1 << treeNum);
		}
	}

	public static bool GetTree(int treeNum) {
		return (TreeBitmap >> treeNum) % 2 == 1;
	}

	public static void SetRelic(string zone) {
		if(!GetRelic(zone)) {
			RelicBitmap = Characters.Sein.Inventory.IncRandomizerItem(1002, 1 << RelicBits[zone]);
		}
	}

	public static bool GetRelic(string zone) {
		return (RelicBitmap >> RelicBits[zone]) % 2 == 1;
	}

	public static void SetMapstone(string areaIdentifier) {
		try {
			MapstoneData data = MapstoneInfos[areaIdentifier];
			if(!GetMapstone(data)) {
				MapstoneBitmap = Characters.Sein.Inventory.IncRandomizerItem(1003, (1 << data.Bit));
			} 
		} 
		catch(Exception e) {
			Randomizer.showHint("@SetMapstone:@ area " + areaIdentifier + ": " + e.Message);
		}
	}

	public static bool GetMapstone(MapstoneData data) {
		return (MapstoneBitmap >> data.Bit) % 2 == 1;
	}


	public static int TreeBitmap;

	public static int MapstoneBitmap;

	public static int TeleporterBitmap;

	public static int RelicBitmap;

	// Token: 0x040032E2 RID: 13026
	public static Dictionary<int, string> TreeNames;

	public static Dictionary<string, int> RelicBits;

	public static Dictionary<string, int> TeleporterBits;

	public static Dictionary<string, MapstoneData> MapstoneInfos;
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
