using System.Collections.Generic;
using Core;
using Game;
using Sein.World;
using UnityEngine;

public static class RandomizerCreditsManager {
	public static void Initialize() 
	{
		CreditsDone = false;
		Credits = new List<KeyValuePair<string, int>>();
		Credits.Add(new KeyValuePair<string, int>(
@"ANCHORTOPPARAMS_20_7.5_2_Ori DE Randomizer (3.0)

Developed by:
Sigmasin
*Eiko*  #Meldon#  @Vulajin@", 15));
		Credits.Add(new KeyValuePair<string, int>(
@"ANCHORTOPPARAMS_20_7.5_2_Major contributions by:
DevilSquirrel

Community Contributions by:
GreeZ  Hydra  Jitaenow  LusTher
Phant  Skulblaka  Terra  xaviershay", 15));
		Credits.Add(new KeyValuePair<string, int>(
@"ANCHORTOPPARAMS_20_9_2_Additional community contributions by:
Athos213    AvengedRuler    Cereberon
CovertMuffin    Grimelios    iRobin    JHobz
Jitaenow    Kirefel    madinsane    Mattermonkey
RainbowPoogle    Roryrai    UncleRonny

Ori DE Randomizer inspired by:
Chicken_Supreme's 'remix' system
Link to the Past Randomizer", 15));
		Credits.Add(new KeyValuePair<string, int>(
@"ALIGNLEFTANCHORTOPPARAMS_20_10_2_        Ori Randomizer Tournament Champions

		2017
Singles:	CovertMuffin
Doubles:	That Is Faster (Sigma and Raziel)

		2018
Singles:	Test
Doubles:	That Is Still Faster (Sigma and Raziel)
", 15));

		Credits.Add(new KeyValuePair<string, int>(
@"ANCHORTOPPARAMS_20_10_2_Thanks for playing! 
find us at orirando.com/discord", 15));

		// Credits.Add(new KeyValuePair<string, int>("In memory of Grandma", 5));
		Credits.Add(new KeyValuePair<string, int>(RandomizerStatsManager.GetStatsPage(0), 60));
		Credits.Add(new KeyValuePair<string, int>(RandomizerStatsManager.GetStatsPage(1), 60));

		NextCreditCountdown = 0;
	}

	public static void Tick() {
		NextCreditCountdown--;
		if(Scenes.Manager.CurrentScene.Scene != "creditsScreen") {
			End();
			return;
		}
		if(NextCreditCountdown <= 0) {
		if(Credits.Count == 0) {
			End();
			return;
		}
			KeyValuePair<string, int> nextCredits = Credits[0];
			Credits.RemoveAt(0);
			NextCreditCountdown = nextCredits.Value;
			Randomizer.showCredits(nextCredits.Key, nextCredits.Value);
		}
	}

	public static void End() {
		if(!CreditsDone)
		{
			CreditsDone = true;
			Credits.Clear();
			Randomizer.CreditsActive = false;
		}
	}

	public static int NextCreditCountdown;
	public static bool CreditsDone;
	public static List<KeyValuePair<string, int>> Credits;
}