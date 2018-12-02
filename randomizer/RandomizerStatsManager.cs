using System;
using System.IO;
using System.Collections.Generic;
using Game;
using Core;
public static class RandomizerStatsManager {

	public static void Initialize() {
		Offsets = new Dictionary<string, int>();
		Offsets.Add("sunkenGlades", 1);
		Offsets.Add("hollowGrove", 2);
		Offsets.Add("moonGrotto", 3);
		Offsets.Add("mangrove", 4);
		Offsets.Add("thornfeltSwamp", 5);
		Offsets.Add("ginsoTree", 6);
		Offsets.Add("valleyOfTheWind", 7);
		Offsets.Add("mistyWoods", 8);
		Offsets.Add("forlornRuins", 9);
		Offsets.Add("sorrowPass", 10);
		Offsets.Add("mountHoru", 11);
		Offsets.Add("unknown", 12);
		Offsets.Add("total", 0);

		ZonePrettyNames = new Dictionary<string, string>();
		ZonePrettyNames.Add("sunkenGlades", "Glades");
		ZonePrettyNames.Add("hollowGrove", "Grove");
		ZonePrettyNames.Add("moonGrotto", "Grotto");
		ZonePrettyNames.Add("mangrove", "Blackroot");
		ZonePrettyNames.Add("thornfeltSwamp", "Swamp");
		ZonePrettyNames.Add("ginsoTree", "Ginso");
		ZonePrettyNames.Add("valleyOfTheWind", "Valley");
		ZonePrettyNames.Add("mistyWoods", "Misty");
		ZonePrettyNames.Add("forlornRuins", "Forlorn");
		ZonePrettyNames.Add("sorrowPass", "Sorrow");
		ZonePrettyNames.Add("mountHoru", "Horu\t");
		ZonePrettyNames.Add("unknown", "Misc\t");
		ZonePrettyNames.Add("total", "Total\t");

		PickupCounts = new Dictionary<string, int>();
		PickupCounts.Add("sunkenGlades", 28);
		PickupCounts.Add("hollowGrove", 27);
		PickupCounts.Add("moonGrotto", 34);
		PickupCounts.Add("mangrove", 20);
		PickupCounts.Add("thornfeltSwamp", 21);
		PickupCounts.Add("ginsoTree", 23);
		PickupCounts.Add("valleyOfTheWind", 19);
		PickupCounts.Add("mistyWoods", 16);
		PickupCounts.Add("forlornRuins", 11);
		PickupCounts.Add("sorrowPass", 26);
		PickupCounts.Add("mountHoru", 22);
		PickupCounts.Add("unknown", 9);
		PickupCounts.Add("total", 256);

		SceneToZone = new Dictionary<string, string>();
		SceneToZone.Add("sunkenGladesOriRoom", "sunkenGlades");
		SceneToZone.Add("sunkenGladesSpiritCavernsPushBlockIntroduction", "sunkenGlades");
		SceneToZone.Add("sunkenGladesSpiritCavernWalljumpB", "sunkenGlades");
		SceneToZone.Add("sunkenGladesSpiritCavernSaveRoomB", "sunkenGlades");
		SceneToZone.Add("sunkenGladesWaterhole", "sunkenGlades");
		SceneToZone.Add("sunkenGladesRunning", "sunkenGlades");
		SceneToZone.Add("sunkenGladesIntroSplitB", "sunkenGlades");
		SceneToZone.Add("sunkenGladesSpiritCavernLaser", "sunkenGlades");
		SceneToZone.Add("sunkenGladesSpiritB", "sunkenGlades");
		SceneToZone.Add("sunkenGladesObstaclesIntroductionStreamlined", "sunkenGlades");

		SceneToZone.Add("horuFieldsB", "hollowGrove");
		SceneToZone.Add("moonGrottoShortcutA", "hollowGrove");
		SceneToZone.Add("spiritTreeRefined", "hollowGrove");
		SceneToZone.Add("worldMapSpiritTree", "hollowGrove");
		SceneToZone.Add("upperGladesSwarmIntroduction", "hollowGrove");
		SceneToZone.Add("upperGladesSpiderCavernPuzzle", "hollowGrove");
		SceneToZone.Add("upperGladesHollowTreeSplitC", "hollowGrove");
		SceneToZone.Add("horuFieldsSlopeTransition", "hollowGrove");
		SceneToZone.Add("upperGladesSpiderIntroduction", "hollowGrove");
		SceneToZone.Add("sunkenGladesLaserStomp", "hollowGrove");

		SceneToZone.Add("moonGrottoLaserIntroduction", "moonGrotto");
		SceneToZone.Add("moonGrottoGumosHideoutB", "moonGrotto");
		SceneToZone.Add("moonGrottoBasin", "moonGrotto");
		SceneToZone.Add("moonGrottoLaserPuzzleB", "moonGrotto");

		SceneToZone.Add("ginsoTreeSprings", "ginsoTree");
		SceneToZone.Add("ginsoTreeSaveRoom", "ginsoTree");
		SceneToZone.Add("ginsoTreePuzzles", "ginsoTree");
		SceneToZone.Add("ginsoTreeBashRedirectArt", "ginsoTree");
		SceneToZone.Add("ginsoTreeWaterRisingBtm", "ginsoTree");
		SceneToZone.Add("ginsoTreeWaterRisingMid", "ginsoTree");
		SceneToZone.Add("ginsoTreeWaterRisingEnd", "ginsoTree");
		SceneToZone.Add("kuroMomentTreeDuplicate", "ginsoTree");

		SceneToZone.Add("upperGladesSwampCliffs", "thornfeltSwamp");
		SceneToZone.Add("thornfeltSwampA", "thornfeltSwamp");
		SceneToZone.Add("thornfeltSwampB", "thornfeltSwamp");
		SceneToZone.Add("thornfeltSwampE", "thornfeltSwamp");
		SceneToZone.Add("thornfeltSwampStompAbility", "thornfeltSwamp");
		SceneToZone.Add("thornfeltSwampActTwoStart", "thornfeltSwamp");
		SceneToZone.Add("thornfeltSwampMoonGrottoTransition", "thornfeltSwamp");

		SceneToZone.Add("sorrowPassForestB", "mistyWoods");
		SceneToZone.Add("mistyWoodsIntro", "mistyWoods");
		SceneToZone.Add("mistyWoodsGlideMazeA", "mistyWoods");
		SceneToZone.Add("mistyWoodsGetClimb", "mistyWoods");
		SceneToZone.Add("mistyWoodsCeilingClimbing", "mistyWoods");
		SceneToZone.Add("mistyWoodsGlideMazeB", "mistyWoods");
		SceneToZone.Add("mistyWoodsMortarBashBlockerA", "mistyWoods");
		SceneToZone.Add("mistyWoodsMortarBash", "mistyWoods");
		SceneToZone.Add("mistyWoodsProjectileBashing", "mistyWoods");
		SceneToZone.Add("mistyWoodsBashUp", "mistyWoods");
		SceneToZone.Add("mistyWoodsConnector", "mistyWoods");
		SceneToZone.Add("mistyWoodsLaserFlipPlatforms", "mistyWoods");
		SceneToZone.Add("mistyWoodsCrissCross", "mistyWoods");
		SceneToZone.Add("mistyWoodsTIntersection", "mistyWoods");
		SceneToZone.Add("mistyWoodsDocks", "mistyWoods");
		SceneToZone.Add("mistyWoodsDocksB", "mistyWoods");
		SceneToZone.Add("mistyWoodsRopeBridge", "mistyWoods");
		SceneToZone.Add("mistyWoodsJumpProjectile", "mistyWoods");

		SceneToZone.Add("sorrowPassEntranceA", "valleyOfTheWind");
		SceneToZone.Add("sorrowPassEntranceB", "valleyOfTheWind");
		SceneToZone.Add("westGladesShaftToBridgeB", "valleyOfTheWind");
		SceneToZone.Add("westGladesMistyWoodsCaveTransition", "valleyOfTheWind");
		SceneToZone.Add("westGladesRollingSootIntroduction", "valleyOfTheWind");
		SceneToZone.Add("forlornRuinsKuroHideStreamlined", "valleyOfTheWind");

		SceneToZone.Add("sorrowPassValleyD", "sorrowPass");
		SceneToZone.Add("valleyOfTheWindGetChargeJump", "sorrowPass");
		SceneToZone.Add("valleyOfTheWindIcePuzzle", "sorrowPass");
		SceneToZone.Add("valleyOfTheWindHubL", "sorrowPass");
		SceneToZone.Add("valleyOfTheWindWideLeft", "sorrowPass");
		SceneToZone.Add("valleyOfTheWindGauntlet", "sorrowPass");
		SceneToZone.Add("valleyOfTheWindLaserShaft", "sorrowPass");

		SceneToZone.Add("forlornRuinsGravityRoomA", "forlornRuins");
		SceneToZone.Add("forlornRuinsGetIceB", "forlornRuins");
		SceneToZone.Add("forlornRuinsNestC", "forlornRuins");
		SceneToZone.Add("forlornRuinsWindShaftMockupB", "forlornRuins");
		SceneToZone.Add("forlornRuinsWindShaftMockupC", "forlornRuins");
		SceneToZone.Add("forlornRuinsGravityFreeFall", "forlornRuins");
		SceneToZone.Add("forlornRuinsGetNightberry", "forlornRuins");
		SceneToZone.Add("forlornRuinsResurrectionAfter", "forlornRuins");
		SceneToZone.Add("forlornRuinsC", "forlornRuins");

		SceneToZone.Add("mangroveFallsDashEscalation", "mangrove");
		SceneToZone.Add("northMangroveFallsIntro", "mangrove");
		SceneToZone.Add("southMangroveFallsGrenadeEscalationBR", "mangrove");

		SceneToZone.Add("mountHoruMovingPlatform", "mountHoru");
		SceneToZone.Add("mountHoruStomperSystemsL", "mountHoru");
		SceneToZone.Add("mountHoruStomperSystemsR", "mountHoru");
		SceneToZone.Add("catAndMouseRight", "mountHoru");
		SceneToZone.Add("catAndMouseMid", "mountHoru");
		SceneToZone.Add("catAndMouseLeft", "mountHoru");
		SceneToZone.Add("catAndMouseResurrectionRoom", "mountHoru");
		SceneToZone.Add("mountHoruHubBottom", "mountHoru");
	}

	public static string CurrentZone() {
		if(GameWorld.Instance && Characters.Sein)
		{
			GameWorldArea area = GameWorld.Instance.WorldAreaAtPosition(Characters.Sein.Position);
			if(area != null)
				return area.AreaIdentifier;
		}
		if(Scenes.Manager.CurrentScene != null)
		{
			string scene = Scenes.Manager.CurrentScene.Scene;
			if(SceneToZone.ContainsKey(scene))
				return SceneToZone[scene];
		}
		return "unknown";
	}

	public static void UpdateAndReset(int counter, int max) {
		int _counter = get(counter);
		int _max = get(max);
		if(_counter > _max)
			set(max, _counter);
		set(counter, 0);
	}

	public static void OnDeath() {
		if(!Active)
			return;
		try {
			inc(shoof_sum, get(TSLDOS));
			UpdateAndReset(TSLDOS, TSLDOS_max);
			UpdateAndReset(PSLDOS, PSLDOS_max);
			UpdateAndReset(TSLD, TSLD_max);
			inc(DSLS, 1);
			inc(Deaths, 1);
			inc(Deaths + Offsets[CurrentZone()], 1);
		}
		catch(Exception e)
		{
			Randomizer.LogError("OnDeath: " + e.Message);
		}
	}

	public static void OnReturnToMenu() {
		try {
			inc(Reloads, 1);
			MenuCache = new Dictionary<int, int>();
			foreach(int single in new int[] {DSLS, TSLD, Reloads, AltRCount, shoof_sum, PPM_max, PPM_max_time, PPM_max_count, Saves})
				MenuCache[single] = get(single);

			foreach(int group in new int[] {Time, Deaths}) 
				foreach(int offset in Offsets.Values)
					MenuCache[group + offset] = get(group + offset);
			WriteFromCache = true;			
		}
		catch(Exception e) {
//			Randomizer.LogError("OnReturnToMenu:" e.Message);
		}
	}

	public static void OnSave() {
		OnSave(true);
	}

	public static void OnSave(bool userInitiated) {
		if(!Active)
			return;
		set(TSLDOS, 0);

		set(PSLDOS, 0);
		UpdateAndReset(DSLS, DSLS_max);
		if(userInitiated)
			inc(Saves, 1);
	}

	public static void IncTime() {
		if(!Active)
			return;
		CachedTime++;
		if(Characters.Sein)
		{
			try {
				if(WriteFromCache) {
					WriteFromCache = false;
					foreach(int key in MenuCache.Keys)
						set(key, MenuCache[key]);
				}
				inc(TSLDOS, CachedTime);
				inc(TSLD, CachedTime);
				inc(Time, CachedTime);
				inc(Time + Offsets[CurrentZone()], CachedTime);
				CachedTime = 0;
			}
			catch(Exception e)
			{
				Randomizer.LogError("IncTime: " + e.Message);
			}
		}
	}

	public static void IncPickup () {
		if(!Active)
			return;
		try {
			inc(PSLDOS, 1);
			int count = inc(Pickups, 1);

			int time  = get(Time);
			if(count >= 10) {			
				int ppm = (int)(Math.Round((float)count / ((float)time / 60f), 2) * 100);
				if(ppm > get(PPM_max))
				{
					set(PPM_max, ppm);
					set(PPM_max_time, time);
					set(PPM_max_count, count);
				}
			}

			inc(Pickups + Offsets[CurrentZone()], 1);
		}
		catch(Exception e)
		{
			Randomizer.LogError("IncPickup: " + e.Message);
		}
	}

	public static void ShowStats(int duration) {
		if(CurrentPage < PageCount)
		{
			string stats = GetStatsPage(CurrentPage);
			Randomizer.PrintImmediately(stats, duration, false, false, false);
			CurrentPage++;
			StatsTimer = duration;
		} else {
			CurrentPage = 0;
			if(StatsTimer > 0) 
			{
				Randomizer.PrintImmediately("", 1, false, false, false);
				WriteStatsFile();
			}
			 else 
				ShowStats(duration);
		}
	}

	public static string GetStatsPage(int page) {
		string statsPage = "";
		switch(page) {
			case 0:
				 statsPage += "ALIGNLEFTANCHORTOPPARAMS_12_14_1_Zone		Deaths	Time			Pickups		PPM";
				foreach(string zone in Offsets.Keys)
				{
					int offset = Offsets[zone];
					string line = ZonePrettyNames[zone];
					if(zone == "unknown") {
						line += "\t\tN/A";
					} else {
						line += "\t\t" + get(Deaths+offset).ToString();
					}
					int time = get(Time+offset);
					string timestr = FormatTime(time);
					line += "\t\t" + timestr;
					if(timestr.Length < 4)
						line += "\t";
					if(PickupCounts.ContainsKey(zone))
					{
						int count = get(Pickups+offset);
						string pickupstr = count.ToString()+"/"+PickupCounts[zone];
						line += "\t\t" + pickupstr;
						if(pickupstr.Length < 5)
							line += "\t";
						float ppm = (float)count / ((float)time / 60f);
						if(time == 0 || ppm > 256 || zone == "unknown"){
							line += "\t\tN/A";
						} else {
							line += "\t\t"+ Math.Round(ppm,2).ToString();
						}
					} else {
						line += "\t\tN/A\t\t\tN/A";
					}
					statsPage += "\n" + line;
				}
			break;
				case 1:
					float ppm_max = (float)get(PPM_max) / 100f;
					statsPage = "ALIGNLEFTANCHORTOPPADDING_0_2_0_0_PARAMS_16_12_1_\nSaves:					" + get(Saves).ToString();
					statsPage += "\nReloads:					" + (get(Reloads)).ToString();
					statsPage += "\nAlt+Rs Used:				" + get(AltRCount).ToString();
					statsPage += "\nTeleporters Used:			" + get(TeleporterCount).ToString();
					statsPage += "\nPeak Pickups Per Minute:		" + ppm_max.ToString() + " ("+get(PPM_max_count).ToString() +" / " + FormatTime(get(PPM_max_time), false)+")";
					statsPage += "\nWorst death (time lost):		" + FormatTime(get(TSLDOS_max), false);
					statsPage += "\nWorst death (pickups lost):	" + get(PSLDOS_max).ToString();
					statsPage += "\nMost deaths at one save:		" + Math.Max(get(DSLS_max), get(DSLS)).ToString();
					statsPage += "\nTotal time lost to deaths:		" + FormatTime(get(shoof_sum), false);
					statsPage += "\nLongest time without dying:	" + FormatTime(Math.Max(get(TSLD_max), get(TSLD)), false);
					statsPage += "\nFound Wall Interaction at:		" + FormatTime(get(FoundWITime), false);
					statsPage += "\nFound Cflame/Grenade at:		" + FormatTime(get(FoundBlueBreakTime), false);
					statsPage += "\nFound Bash at:				" + FormatTime(get(FoundBashTime), false);
					statsPage += "\nFound Dash at:				" + FormatTime(get(FoundDashTime), false);
				break;
			default:
			break;
		}
		return statsPage;
	}

	private static int get(int item) { return Characters.Sein.Inventory.GetRandomizerItem(item); }
	private static int set(int item, int value) { return Characters.Sein.Inventory.SetRandomizerItem(item, value); }
	private static int inc(int item, int value) { return Characters.Sein.Inventory.IncRandomizerItem(item, value); }

	public static void Activate() {
		Active = true;
		MenuCache = new Dictionary<int, int>();
		CachedTime = 0;
		WriteFromCache = false;
	}

	public static void Finish() {
		Active = false;
		WriteStatsFile();
	}


	public static void WriteStatsFile() {
		try {
			string flagLine = File.ReadAllLines("randomizer.dat")[0];
			string zonePart = GetStatsPage(0).Substring(33);
			// formatting is garbage
			zonePart = zonePart.Replace("   ", "");
			zonePart = zonePart.Replace("				", "	");
			zonePart = zonePart.Replace("			", "	");
			zonePart = zonePart.Replace("		", "	");
			zonePart = zonePart.Replace("	", " ");
			List<string> zoneLines = new List<string>(zonePart.Split('\n'));
			List<int> zoneLineSpacing = new List<int> {0, 0, 0, 0, 0};
			foreach(string line in zoneLines) {
				int col = 0;
				int lastStart = 0;
				for(int i = 0; i < line.Length; i++) {
					if(line[i] == ' '){
						int spacing = i-lastStart + 2;
						if(zoneLineSpacing[col] < spacing)
							zoneLineSpacing[col] = spacing;
						col++;
						lastStart = i;
					}
				}
			}
			zonePart = "";
			foreach(string line in zoneLines) {
				int col = 0;
				string paddedLine = "";
				foreach(string linePart in line.Split(' ')) {
					string lpc = linePart;
					while(lpc.Length < zoneLineSpacing[col]) 
						lpc += " ";
					paddedLine += lpc;
					col++;
				}
				zonePart += paddedLine + "\n";
			}

			string miscPart = GetStatsPage(1).Substring(49);
			miscPart = miscPart.Replace("Saves:", "Saves:  ");
			miscPart = miscPart.Replace("Minute:	", "Minute:");
			miscPart = miscPart.Replace("(time lost):	", "(time lost):");
			miscPart = miscPart.Replace("(pickups lost):	", "(pickups lost): ");
			miscPart = miscPart.Replace("save:	", "save:");
			miscPart = miscPart.Replace("Grenade at:	", "Grenade at:");
			miscPart = miscPart.Replace("deaths:		", "deaths:  ");
			miscPart = miscPart.Replace("dying:	", "dying: ");
			miscPart = miscPart.Replace("tion at:		", "tion at:  ");
			miscPart = miscPart.Replace("ash at:	","ash at:  ");
			miscPart = miscPart.Replace("Teleporters Used:	","Teleporters Used:   ");
			miscPart = miscPart.Replace("	","    ");
			string statsFile = flagLine+"\n\n"+ zonePart + miscPart;
			statsFile = statsFile.Replace("\n", "\r\n");
			File.WriteAllText("stats.txt", statsFile);
		} catch(Exception e)
		{
			Randomizer.LogError("WriteStatsFile: " + e.Message);
		}

	}	
	public static string FormatTime(int seconds, bool padding)
	{
		if(padding)
			return FormatTime(seconds);
		else
			return FormatTime(seconds).Trim();
	}

	public static string FormatTime(int seconds)
	{
		if(seconds == 0) {
			return "   N/A";
		}
		string secondsPart = (seconds % 60).ToString();
		if(secondsPart.Length < 2)
			secondsPart = "0"+secondsPart;
		int minutes = seconds / 60;
		string minutesPart = (minutes % 60).ToString();
		if(minutesPart.Length < 2)
		if(minutes >= 60)
			minutesPart = "0"+minutesPart;
		else
			minutesPart = "   "+minutesPart;
		if(minutes >= 60)
		{
			int hours = minutes / 60;
			return hours.ToString()+":"+minutesPart+":"+secondsPart;
		}
		return minutesPart+":"+secondsPart;
	}
	public static void WarpedToStart() { inc(AltRCount, 1); }
	public static void UsedTeleporter() { inc(TeleporterCount, 1); }
	public static void FoundMapstone() { inc(Pickups, 1); inc(Pickups + 12, 1); }
	public static void FoundSkill(int skillID) {
		switch(skillID) {
			case 51:
			case 2:
				if(get(FoundBlueBreakTime) == 0)
					set(FoundBlueBreakTime, get(Time));
				break;
			case 12:
			case 3:
				if(get(FoundWITime) == 0)
					set(FoundWITime, get(Time));
				break;
			case 0:
				if(get(FoundBashTime) == 0)
					set(FoundBashTime, get(Time));
				break;
			case 50:
				if(get(FoundDashTime) == 0)
					set(FoundDashTime, get(Time));
				break;
			default:
				break;
		}
	}

	public static int Deaths = 1500;

	public static int DSLS = 1515;
	public static int TSLD = 1516;
	public static int TSLDOS = 1517;
	public static int PSLDOS = 1518;

	public static int Time = 1520;

	public static int DSLS_max = 1535;
	public static int TSLD_max = 1536;
	public static int TSLDOS_max = 1537;
	public static int PSLDOS_max = 1538;

	public static int Pickups = 1600;

	public static int Saves = 1570;
	public static int shoof_sum = 1571;
	public static int PPM_max = 1575;
	public static int PPM_max_time = 1576;
	public static int PPM_max_count = 1577;
	public static int Reloads = 1578;
	public static int AltRCount = 1579;
	public static int TeleporterCount = 1580;
	public static int FoundWITime = 1581;
	public static int FoundBashTime = 1582;
	public static int FoundDashTime = 1583;
	public static int FoundBlueBreakTime = 1584;

	public static int CurrentPage;
	public static int PageCount = 2;
	public static int CachedTime;
	public static bool Active;
	public static bool WriteFromCache;
	public static Dictionary<string, int> Offsets;
	public static Dictionary<string, int> PickupCounts;
	public static Dictionary<string, string> ZonePrettyNames;
	public static Dictionary<string, string> SceneToZone;
	public static Dictionary<int, int> MenuCache;
	public static int StatsTimer = 0;
}
