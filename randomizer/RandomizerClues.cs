using System;
using System.Collections.Generic;
using Sein.World;

// Token: 0x020009FD RID: 2557
public static class RandomizerClues
{
	// Token: 0x060037CF RID: 14287
	public static void initialize()
	{
		RandomizerClues.RevealOrder = new int[3];
		RandomizerClues.Clues = new List<string>();
	}

	// Token: 0x060037D0 RID: 14288
	public static void AddClue(string clue, int order)
	{
		RandomizerClues.Clues.Add(clue);
		RandomizerClues.RevealOrder[order] = RandomizerClues.Clues.Count;
	}

	// Token: 0x060037D1 RID: 14289
	public static string GetClues()
	{
		string blue = "";
		string yellow = "";
		string red = "";
		string[] revealedClues = new string[]
		{
			"????",
			"????",
			"????"
		};
		if (Keys.GinsoTree)
		{
			revealedClues[0] = RandomizerClues.Clues[RandomizerClues.RevealOrder[0] - 1];
			blue = "*";
		}
		if (Keys.ForlornRuins)
		{
			revealedClues[1] = RandomizerClues.Clues[RandomizerClues.RevealOrder[1] - 1];
			yellow = "#";
		}
		if (Keys.MountHoru)
		{
			revealedClues[2] = RandomizerClues.Clues[RandomizerClues.RevealOrder[2] - 1];
			red = "@";
		}
		for (int i = 0; i < 3; i++)
		{
			if (RandomizerBonus.SkillTreeProgression() >= RandomizerClues.RevealOrder[i] * 3)
			{
				revealedClues[i] = RandomizerClues.Clues[RandomizerClues.RevealOrder[i] - 1];
			}
		}
		return string.Concat(new string[]
		{
			blue,
			"Water Vein: ",
			revealedClues[0],
			blue,
			"\n",
			yellow,
			"Gumon Seal: ",
			revealedClues[1],
			yellow,
			"  ",
			red,
			"Sunstone: ",
			revealedClues[2],
			red
		});
	}
	public static void FinishClues()
	{
		for (int i = 0; i < 3; i++)
		{
			if (RandomizerClues.RevealOrder[i] == 0)
			{
				RandomizerClues.Clues.Add("The Void");
				RandomizerClues.RevealOrder[i] = RandomizerClues.Clues.Count;
			}
		}
	}

	// Token: 0x040032A4 RID: 12964
	public static List<string> Clues;

	// Token: 0x040032A5 RID: 12965
	public static int[] RevealOrder;
}
