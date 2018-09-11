using System;
using System.Collections;
using System.IO;
using Core;
using UnityEngine;

// Token: 0x02000A02 RID: 2562
public static class RandomizerRebinding
{
	// Token: 0x060037B3 RID: 14259 RVA: 0x000E4190 File Offset: 0x000E2390
	public static void WriteDefaultFile()
	{
		StreamWriter streamWriter = new StreamWriter("RandomizerRebinding.txt");
		streamWriter.WriteLine("Bind syntax: Key1+Key2, Key1+Key3+Key4, ... Syntax errors will load default binds.");
		streamWriter.WriteLine("Functions are unbound if there is no binding specified.");
		streamWriter.WriteLine("Supported binds are Unity KeyCodes (https://docs.unity3d.com/ScriptReference/KeyCode.html) and the following actions:");
		streamWriter.WriteLine("Jump, SpiritFlame, Bash, SoulFlame, ChargeJump, Glide, Dash, Grenade, Left, Right, Up, Down, LeftStick, RightStick, Start, Select");
		streamWriter.WriteLine("");
		streamWriter.WriteLine("Replay Message: LeftAlt+T, RightAlt+T");
		streamWriter.WriteLine("Return to Start: LeftAlt+R, RightAlt+R");
		streamWriter.WriteLine("Reload Seed: LeftAlt+L, RightAlt+L");
		streamWriter.WriteLine("Toggle Chaos: LeftAlt+K, RightAlt+K");
		streamWriter.WriteLine("Chaos Verbosity: LeftAlt+V, RightAlt+V");
		streamWriter.WriteLine("Force Chaos Effect: LeftAlt+F, RightAlt+F");
		streamWriter.WriteLine("Show Progress: LeftAlt+P, RightAlt+P");
		streamWriter.WriteLine("Color Shift: LeftAlt+C, RightAlt+C");
		streamWriter.WriteLine("Double Bash: Grenade");
		streamWriter.WriteLine("Bonus Switch: LeftAlt+Q, RightAlt+Q");
		streamWriter.WriteLine("Bonus Toggle: LeftAlt+Mouse1, RightAlt+Mouse1");
		streamWriter.Flush();
		streamWriter.Close();
	}

	// Token: 0x060037B4 RID: 14260
	public static void ParseRebinding()
	{
		RandomizerRebinding.ActionMap = new Hashtable();
		RandomizerRebinding.ActionMap.Add("Jump", Core.Input.Jump);
		RandomizerRebinding.ActionMap.Add("SpiritFlame", Core.Input.SpiritFlame);
		RandomizerRebinding.ActionMap.Add("Bash", Core.Input.Bash);
		RandomizerRebinding.ActionMap.Add("SoulFlame", Core.Input.SoulFlame);
		RandomizerRebinding.ActionMap.Add("ChargeJump", Core.Input.ChargeJump);
		RandomizerRebinding.ActionMap.Add("Glide", Core.Input.Glide);
		RandomizerRebinding.ActionMap.Add("Dash", Core.Input.RightShoulder);
		RandomizerRebinding.ActionMap.Add("Grenade", Core.Input.LeftShoulder);
		RandomizerRebinding.ActionMap.Add("Left", Core.Input.Left);
		RandomizerRebinding.ActionMap.Add("Right", Core.Input.Right);
		RandomizerRebinding.ActionMap.Add("Up", Core.Input.Up);
		RandomizerRebinding.ActionMap.Add("Down", Core.Input.Down);
		RandomizerRebinding.ActionMap.Add("LeftStick", Core.Input.LeftStick);
		RandomizerRebinding.ActionMap.Add("RightStick", Core.Input.RightStick);
		RandomizerRebinding.ActionMap.Add("Start", Core.Input.Start);
		RandomizerRebinding.ActionMap.Add("Select", Core.Input.Select);
		if (!File.Exists("RandomizerRebinding.txt"))
		{
			RandomizerRebinding.WriteDefaultFile();
		}
		try
		{
			string[] array = File.ReadAllLines("RandomizerRebinding.txt");
			RandomizerRebinding.ReplayMessage = RandomizerRebinding.ParseLine(array[5]);
			RandomizerRebinding.ReturnToStart = RandomizerRebinding.ParseLine(array[6]);
			RandomizerRebinding.ReloadSeed = RandomizerRebinding.ParseLine(array[7]);
			RandomizerRebinding.ToggleChaos = RandomizerRebinding.ParseLine(array[8]);
			RandomizerRebinding.ChaosVerbosity = RandomizerRebinding.ParseLine(array[9]);
			RandomizerRebinding.ForceChaosEffect = RandomizerRebinding.ParseLine(array[10]);
			RandomizerRebinding.ShowProgress = RandomizerRebinding.ParseLine(array[11]);
			RandomizerRebinding.ColorShift = RandomizerRebinding.ParseLine(array[12]);
			RandomizerRebinding.DoubleBash = RandomizerRebinding.ParseLine(array[13]);
			RandomizerRebinding.BonusSwitch = RandomizerRebinding.ParseLine(array[14]);
			RandomizerRebinding.BonusToggle = RandomizerRebinding.ParseLine(array[15]);
		}
		catch (Exception)
		{
			Randomizer.showHint("Syntax error, loading default binds");
			RandomizerRebinding.LoadDefaultBinds();
		}
	}

	// Token: 0x060037B5 RID: 14261 RVA: 0x0002BCFE File Offset: 0x00029EFE
	public static KeyCode StringToKeyBinding(string s)
	{
		if (s != "")
		{
			return (KeyCode)((int)Enum.Parse(typeof(KeyCode), s));
		}
		return KeyCode.None;
	}

	// Token: 0x060037B6 RID: 14262 RVA: 0x000E44A0 File Offset: 0x000E26A0
	public static void LoadDefaultBinds()
	{
		RandomizerRebinding.ReplayMessage = RandomizerRebinding.ParseLine("Replay Message: LeftAlt+T, RightAlt+T");
		RandomizerRebinding.ReturnToStart = RandomizerRebinding.ParseLine("Return to Start: LeftAlt+R, RightAlt+R");
		RandomizerRebinding.ReloadSeed = RandomizerRebinding.ParseLine("Reload Seed: LeftAlt+L, RightAlt+L");
		RandomizerRebinding.ToggleChaos = RandomizerRebinding.ParseLine("Toggle Chaos: LeftAlt+K, RightAlt+K");
		RandomizerRebinding.ChaosVerbosity = RandomizerRebinding.ParseLine("Chaos Verbosity: LeftAlt+V, RightAlt+V");
		RandomizerRebinding.ForceChaosEffect = RandomizerRebinding.ParseLine("Force Chaos Effect: LeftAlt+F, RightAlt+F");
		RandomizerRebinding.ShowProgress = RandomizerRebinding.ParseLine("Show Progress: LeftAlt+P, RightAlt+P");
		RandomizerRebinding.ColorShift = RandomizerRebinding.ParseLine("Color Shift: LeftAlt+C, RightAlt+C");
		RandomizerRebinding.DoubleBash = RandomizerRebinding.ParseLine("Double Bash: Grenade");
		RandomizerRebinding.BonusSwitch = RandomizerRebinding.ParseLine("BonusSwitch: LeftAlt+Q, RightAlt+Q");
		RandomizerRebinding.BonusToggle = RandomizerRebinding.ParseLine("BonusToggle: LeftAlt+Mouse1, RightAlt+Mouse1");
	}

	// Token: 0x060037B7 RID: 14263
	public static RandomizerRebinding.BindSet ParseLine(string line)
	{
		string[] array3 = line.Split(new char[]
		{
			':'
		})[1].Split(new char[]
		{
			','
		});
		ArrayList arrayList = new ArrayList();
		string[] array2 = array3;
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array4 = array2[i].Split(new char[]
			{
				'+'
			});
			ArrayList arrayList2 = new ArrayList();
			foreach (string text in array4)
			{
				if (text.Trim().ToLower() == "tap")
				{
					Randomizer.BashTap = true;
				}
				else
				{
					arrayList2.Add(new RandomizerRebinding.Bind(text));
				}
			}
			if (arrayList2.Count > 0)
			{
				arrayList.Add(arrayList2);
			}
		}
		return new RandomizerRebinding.BindSet(arrayList);
	}

	// Token: 0x04003278 RID: 12920
	public static Hashtable ActionMap;

	// Token: 0x04003279 RID: 12921
	public static RandomizerRebinding.BindSet ReplayMessage;

	// Token: 0x0400327A RID: 12922
	public static RandomizerRebinding.BindSet ReturnToStart;

	// Token: 0x0400327B RID: 12923
	public static RandomizerRebinding.BindSet ReloadSeed;

	// Token: 0x0400327C RID: 12924
	public static RandomizerRebinding.BindSet ToggleChaos;

	// Token: 0x0400327D RID: 12925
	public static RandomizerRebinding.BindSet ChaosVerbosity;

	// Token: 0x0400327E RID: 12926
	public static RandomizerRebinding.BindSet ForceChaosEffect;

	// Token: 0x0400327F RID: 12927
	public static RandomizerRebinding.BindSet ShowProgress;

	// Token: 0x04003280 RID: 12928
	public static RandomizerRebinding.BindSet ColorShift;

	// Token: 0x04003281 RID: 12929
	public static RandomizerRebinding.BindSet DoubleBash;

	// Token: 0x04003282 RID: 12930
	public static RandomizerRebinding.BindSet BonusSwitch;

	// Token: 0x04003283 RID: 12931
	public static RandomizerRebinding.BindSet BonusToggle;

	// Token: 0x02000A03 RID: 2563
	public class Bind
	{
		// Token: 0x060037B8 RID: 14264 RVA: 0x000E4610 File Offset: 0x000E2810
		public Bind(string input)
		{
			input = input.Trim();
			if (RandomizerRebinding.ActionMap.ContainsKey(input))
			{
				this.Action = (Core.Input.InputButtonProcessor)RandomizerRebinding.ActionMap[input];
				this.ActionBind = true;
				return;
			}
			this.ActionBind = false;
			this.Key = RandomizerRebinding.StringToKeyBinding(input);
		}

		// Token: 0x060037B9 RID: 14265 RVA: 0x0002BD24 File Offset: 0x00029F24
		public bool IsPressed()
		{
			if (this.ActionBind)
			{
				return this.Action.Pressed;
			}
			return MoonInput.GetKey(this.Key);
		}

		// Token: 0x04003284 RID: 12932
		public KeyCode Key;

		// Token: 0x04003285 RID: 12933
		public Core.Input.InputButtonProcessor Action;

		// Token: 0x04003286 RID: 12934
		public bool ActionBind;
	}

	// Token: 0x02000A04 RID: 2564
	public class BindSet
	{
		// Token: 0x060037BA RID: 14266 RVA: 0x0002BD45 File Offset: 0x00029F45
		public BindSet(ArrayList binds)
		{
			this.binds = binds;
			this.wasPressed = true;
		}

		// Token: 0x060037BB RID: 14267 RVA: 0x000E466C File Offset: 0x000E286C
		public bool IsPressed()
		{
			foreach (object obj in this.binds)
			{
				ArrayList arrayList = (ArrayList)obj;
				bool flag = true;
				using (IEnumerator enumerator2 = arrayList.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (!((RandomizerRebinding.Bind)enumerator2.Current).IsPressed())
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					if (this.wasPressed)
					{
						return false;
					}
					this.wasPressed = true;
					return true;
				}
			}
			this.wasPressed = false;
			return false;
		}

		// Token: 0x04003287 RID: 12935
		public ArrayList binds;

		// Token: 0x04003288 RID: 12936
		public bool wasPressed;
	}
}
