using System;
using System.IO;
using UnityEngine;

// Token: 0x020009FE RID: 2558
public static class RandomizerRebinding
{
	// Token: 0x06003795 RID: 14229 RVA: 0x000E2C88 File Offset: 0x000E0E88
	public static void WriteDefaultFile()
	{
		StreamWriter streamWriter = new StreamWriter("RandomizerRebinding.txt");
		streamWriter.WriteLine("All binds are Alt + the input given here. Syntax errors will load default binds.");
		streamWriter.WriteLine("Functions are unbound if there is no key after the colon. Only single binds are supported.");
		streamWriter.WriteLine("ReplayMessage: T");
		streamWriter.WriteLine("ReturnToStart: R");
		streamWriter.WriteLine("ReloadSeed: L");
		streamWriter.WriteLine("ToggleChaos: K");
		streamWriter.WriteLine("ChaosVerbosity: V");
		streamWriter.WriteLine("ForceChaosEffect: F");
		streamWriter.WriteLine("ShowProgress: P");
		streamWriter.WriteLine("ColorShift: C");
		streamWriter.WriteLine("BonusSwitch: Q");
		streamWriter.WriteLine("BonusToggle: E");
		streamWriter.Flush();
		streamWriter.Close();
	}

	// Token: 0x06003796 RID: 14230 RVA: 0x000E2D18 File Offset: 0x000E0F18
	public static void ParseRebinding()
	{
		if (!File.Exists("RandomizerRebinding.txt"))
		{
			RandomizerRebinding.WriteDefaultFile();
		}
		try
		{
			string[] array = File.ReadAllLines("RandomizerRebinding.txt");
			RandomizerRebinding.ReplayMessage = RandomizerRebinding.StringToKeyBinding(array[2]);
			RandomizerRebinding.ReturnToStart = RandomizerRebinding.StringToKeyBinding(array[3]);
			RandomizerRebinding.ReloadSeed = RandomizerRebinding.StringToKeyBinding(array[4]);
			RandomizerRebinding.ToggleChaos = RandomizerRebinding.StringToKeyBinding(array[5]);
			RandomizerRebinding.ChaosVerbosity = RandomizerRebinding.StringToKeyBinding(array[6]);
			RandomizerRebinding.ForceChaosEffect = RandomizerRebinding.StringToKeyBinding(array[7]);
			RandomizerRebinding.ShowProgress = RandomizerRebinding.StringToKeyBinding(array[8]);
			RandomizerRebinding.ColorShift = RandomizerRebinding.StringToKeyBinding(array[9]);
			RandomizerRebinding.BonusSwitch = RandomizerRebinding.StringToKeyBinding(array[10]);
			RandomizerRebinding.BonusToggle  = RandomizerRebinding.StringToKeyBinding(array[11]);
		}
		catch (Exception)
		{
			File.Delete("RandomizerRebinding.txt");
			Randomizer.showHint("Bindings reset to default");
			RandomizerRebinding.WriteDefaultFile();
			RandomizerRebinding.LoadDefaultBinds();
		}
	}

	// Token: 0x06003797 RID: 14231 RVA: 0x000E2DC4 File Offset: 0x000E0FC4
	public static KeyCode StringToKeyBinding(string s)
	{
		string[] array = s.Split(new char[]
		{
			':'
		});
		if (array[1].Trim() != "")
		{
			return (KeyCode)((int)Enum.Parse(typeof(KeyCode), array[1].Trim()));
		}
		return KeyCode.None;
	}

	// Token: 0x06003798 RID: 14232 RVA: 0x0002B70D File Offset: 0x0002990D
	public static void LoadDefaultBinds()
	{
		RandomizerRebinding.ReplayMessage = KeyCode.T;
		RandomizerRebinding.ReturnToStart = KeyCode.R;
		RandomizerRebinding.ReloadSeed = KeyCode.L;
		RandomizerRebinding.ToggleChaos = KeyCode.K;
		RandomizerRebinding.ChaosVerbosity = KeyCode.V;
		RandomizerRebinding.ForceChaosEffect = KeyCode.F;
		RandomizerRebinding.ShowProgress = KeyCode.P;
		RandomizerRebinding.ColorShift = KeyCode.C;
		RandomizerRebinding.BonusSwitch = KeyCode.Q;
		RandomizerRebinding.BonusToggle = KeyCode.E;
	}

	// Token: 0x04003262 RID: 12898
	public static KeyCode ReplayMessage;

	// Token: 0x04003263 RID: 12899
	public static KeyCode ReturnToStart;

	// Token: 0x04003264 RID: 12900
	public static KeyCode ReloadSeed;

	// Token: 0x04003265 RID: 12901
	public static KeyCode ToggleChaos;

	// Token: 0x04003266 RID: 12902
	public static KeyCode ChaosVerbosity;

	// Token: 0x04003267 RID: 12903
	public static KeyCode ForceChaosEffect;

	// Token: 0x04003268 RID: 12904
	public static KeyCode ShowProgress;

	// Token: 0x04003269 RID: 12905
	public static KeyCode ColorShift;

	public static KeyCode BonusSwitch;

	public static KeyCode BonusToggle;
}
