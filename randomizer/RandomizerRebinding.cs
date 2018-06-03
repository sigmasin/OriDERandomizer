using System;
using System.IO;
using UnityEngine;

// Token: 0x02000A00 RID: 2560
public static class RandomizerRebinding
{
	// Token: 0x060037AA RID: 14250 RVA: 0x000E35C0 File Offset: 0x000E17C0
	public static void WriteDefaultFile()
	{
		StreamWriter streamWriter = new StreamWriter("RandomizerRebinding.txt");
		streamWriter.WriteLine("These bindings are Alt + the input given here. Syntax errors will load default binds.");
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
		streamWriter.WriteLine("BonusToggle: Mouse1");
		streamWriter.WriteLine("These bindings are for easy double bashing. Leave them blank to disable. Hold button while bashing to preform. (No alt required)");
		streamWriter.WriteLine("Mouse Options: as above. Controller Options: LeftShoulder (Grenade), RightShoulder (Dash)... (WIP: Link to full list here).");
		streamWriter.WriteLine("DoubleBashController: RightShoulder");
		streamWriter.WriteLine("DoubleBashKeyboard: R");
		streamWriter.Flush();
		streamWriter.Close();
	}

	// Token: 0x060037AB RID: 14251 RVA: 0x000E3668 File Offset: 0x000E1868
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
			RandomizerRebinding.BonusToggle = RandomizerRebinding.StringToKeyBinding(array[11]);
			RandomizerRebinding.DoubleBashKeyboard = RandomizerRebinding.StringToKeyBinding(array[15]);
			string[] array2 = array[14].Split(new char[]
			{
				':'
			});
			if (array2[1].Trim() != "")
			{
				RandomizerRebinding.DoubleBashController = Core.Input.GetButton((Core.Input.Button)((int)Enum.Parse(typeof(Core.Input.Button), array2[1].Trim())));
			} else {
				RandomizerRebinding.DoubleBashController = null;
			}

		}
		catch (Exception)
		{
			File.Delete("RandomizerRebinding.txt");
			Randomizer.showHint("Bindings reset to default");
			RandomizerRebinding.WriteDefaultFile();
			RandomizerRebinding.LoadDefaultBinds();
		}
	}

	public static bool DoubleBashPressed() {
		return (RandomizerRebinding.DoubleBashKeyboard != KeyCode.None && MoonInput.GetKeyDown(RandomizerRebinding.DoubleBashKeyboard)
			 || (RandomizerRebinding.DoubleBashController != null && RandomizerRebinding.DoubleBashController.IsPressed));
	}

	// Token: 0x060037AC RID: 14252 RVA: 0x000E3748 File Offset: 0x000E1948
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

	// Token: 0x060037AD RID: 14253 RVA: 0x000E379C File Offset: 0x000E199C
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
		RandomizerRebinding.BonusToggle = KeyCode.Mouse1;
		RandomizerRebinding.DoubleBashKeyboard = KeyCode.R;
		RandomizerRebinding.DoubleBashController = Core.Input.RightShoulder;
	}

	// Token: 0x04003269 RID: 12905
	public static KeyCode ReplayMessage;

	// Token: 0x0400326A RID: 12906
	public static KeyCode ReturnToStart;

	// Token: 0x0400326B RID: 12907
	public static KeyCode ReloadSeed;

	// Token: 0x0400326C RID: 12908
	public static KeyCode ToggleChaos;

	// Token: 0x0400326D RID: 12909
	public static KeyCode ChaosVerbosity;

	// Token: 0x0400326E RID: 12910
	public static KeyCode ForceChaosEffect;

	// Token: 0x0400326F RID: 12911
	public static KeyCode ShowProgress;

	// Token: 0x04003270 RID: 12912
	public static KeyCode ColorShift;

	// Token: 0x04003271 RID: 12913
	public static KeyCode BonusSwitch;

	// Token: 0x04003272 RID: 12914
	public static KeyCode BonusToggle;

	public static KeyCode DoubleBashKeyboard;

	public static Core.Input.InputButtonProcessor DoubleBashController;
}
