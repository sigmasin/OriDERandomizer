using System;
using System.IO;
using UnityEngine;

// Token: 0x020009FE RID: 2558
public static class RandomizerRebinding
{
	// Token: 0x060039A9 RID: 14761
	public static void WriteDefaultFile()
	{
		StreamWriter expr_0A = new StreamWriter("RandomizerRebinding.txt");
		expr_0A.WriteLine("All binds are Alt + the input given here. Syntax errors will load default binds.");
		expr_0A.WriteLine("Functions are unbound if there is no key after the colon. Only single binds are supported.");
		expr_0A.WriteLine("ReplayMessage: T");
		expr_0A.WriteLine("ReturnToStart: R");
		expr_0A.WriteLine("ReloadSeed: L");
		expr_0A.WriteLine("ToggleChaos: C");
		expr_0A.WriteLine("ChaosVerbosity: V");
		expr_0A.WriteLine("ForceChaosEffect: F");
		expr_0A.WriteLine("ShowProgress: P");
		expr_0A.Flush();
		expr_0A.Close();
	}

	// Token: 0x060039AA RID: 14762
	public static void ParseRebinding()
	{
		if (!File.Exists("RandomizerRebinding.txt"))
		{
			RandomizerRebinding.WriteDefaultFile();
		}
		try
		{
			string[] expr_1C = File.ReadAllLines("RandomizerRebinding.txt");
			RandomizerRebinding.ReplayMessage = RandomizerRebinding.StringToKeyBinding(expr_1C[2]);
			RandomizerRebinding.ReturnToStart = RandomizerRebinding.StringToKeyBinding(expr_1C[3]);
			RandomizerRebinding.ReloadSeed = RandomizerRebinding.StringToKeyBinding(expr_1C[4]);
			RandomizerRebinding.ToggleChaos = RandomizerRebinding.StringToKeyBinding(expr_1C[5]);
			RandomizerRebinding.ChaosVerbosity = RandomizerRebinding.StringToKeyBinding(expr_1C[6]);
			RandomizerRebinding.ForceChaosEffect = RandomizerRebinding.StringToKeyBinding(expr_1C[7]);
			RandomizerRebinding.ShowProgress = RandomizerRebinding.StringToKeyBinding(expr_1C[8]);
		}
		catch (Exception)
		{
			RandomizerRebinding.LoadDefaultBinds();
		}
	}

	// Token: 0x060039AB RID: 14763
	public static KeyCode StringToKeyBinding(string s)
	{
		string[] line = s.Split(new char[]
		{
			':'
		});
		if (line.Length >= 2)
		{
			return (KeyCode)((int)Enum.Parse(typeof(KeyCode), line[1].Trim()));
		}
		return KeyCode.None;
	}

	// Token: 0x060039AC RID: 14764
	public static void LoadDefaultBinds()
	{
		RandomizerRebinding.ReplayMessage = KeyCode.T;
		RandomizerRebinding.ReturnToStart = KeyCode.R;
		RandomizerRebinding.ReloadSeed = KeyCode.L;
		RandomizerRebinding.ToggleChaos = KeyCode.C;
		RandomizerRebinding.ChaosVerbosity = KeyCode.V;
		RandomizerRebinding.ForceChaosEffect = KeyCode.F;
		RandomizerRebinding.ShowProgress = KeyCode.P;
	}

	// Token: 0x040033A3 RID: 13219
	public static KeyCode ReplayMessage;

	// Token: 0x040033A4 RID: 13220
	public static KeyCode ReturnToStart;

	// Token: 0x040033A5 RID: 13221
	public static KeyCode ReloadSeed;

	// Token: 0x040033A6 RID: 13222
	public static KeyCode ToggleChaos;

	// Token: 0x040033A7 RID: 13223
	public static KeyCode ChaosVerbosity;

	// Token: 0x040033A8 RID: 13224
	public static KeyCode ForceChaosEffect;

	// Token: 0x040033A9 RID: 13225
	public static KeyCode ShowProgress;
}
