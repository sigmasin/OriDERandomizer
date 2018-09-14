using System;
using System.Collections;
using System.IO;
using Core;
using UnityEngine;

// Token: 0x02000A02 RID: 2562
public static class RandomizerRebinding
{
	// Token: 0x060037B5 RID: 14261 RVA: 0x000E4410 File Offset: 0x000E2610
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

	// Token: 0x060037B6 RID: 14262 RVA: 0x000E44E4 File Offset: 0x000E26E4
	public static void ParseRebinding()
	{
		RandomizerRebinding.ActionMap = new Hashtable();
		RandomizerRebinding.ActionMap.Add("Jump", Input.Jump);
		RandomizerRebinding.ActionMap.Add("SpiritFlame", Input.SpiritFlame);
		RandomizerRebinding.ActionMap.Add("Bash", Input.Bash);
		RandomizerRebinding.ActionMap.Add("SoulFlame", Input.SoulFlame);
		RandomizerRebinding.ActionMap.Add("ChargeJump", Input.ChargeJump);
		RandomizerRebinding.ActionMap.Add("Glide", Input.Glide);
		RandomizerRebinding.ActionMap.Add("Dash", Input.RightShoulder);
		RandomizerRebinding.ActionMap.Add("Grenade", Input.LeftShoulder);
		RandomizerRebinding.ActionMap.Add("Left", Input.Left);
		RandomizerRebinding.ActionMap.Add("Right", Input.Right);
		RandomizerRebinding.ActionMap.Add("Up", Input.Up);
		RandomizerRebinding.ActionMap.Add("Down", Input.Down);
		RandomizerRebinding.ActionMap.Add("LeftStick", Input.LeftStick);
		RandomizerRebinding.ActionMap.Add("RightStick", Input.RightStick);
		RandomizerRebinding.ActionMap.Add("Start", Input.Start);
		RandomizerRebinding.ActionMap.Add("Select", Input.Select);
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

	// Token: 0x060037B7 RID: 14263 RVA: 0x0002BCFE File Offset: 0x00029EFE
	public static KeyCode StringToKeyBinding(string s)
	{
		if (s != "")
		{
			return (int)Enum.Parse(typeof(KeyCode), s);
		}
		return 0;
	}

	// Token: 0x060037B8 RID: 14264 RVA: 0x000E4710 File Offset: 0x000E2910
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

	// Token: 0x060037B9 RID: 14265 RVA: 0x000E47C4 File Offset: 0x000E29C4
	public static RandomizerRebinding.BindSet ParseLine(string line)
	{
		string[] array = line.Split(new char[]
		{
			':'
		})[1].Split(new char[]
		{
			','
		});
		ArrayList arrayList = new ArrayList();
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array3 = array2[i].Split(new char[]
			{
				'+'
			});
			ArrayList arrayList2 = new ArrayList();
			foreach (string text in array3)
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

	// Token: 0x0400327C RID: 12924
	public static Hashtable ActionMap;

	// Token: 0x0400327D RID: 12925
	public static RandomizerRebinding.BindSet ReplayMessage;

	// Token: 0x0400327E RID: 12926
	public static RandomizerRebinding.BindSet ReturnToStart;

	// Token: 0x0400327F RID: 12927
	public static RandomizerRebinding.BindSet ReloadSeed;

	// Token: 0x04003280 RID: 12928
	public static RandomizerRebinding.BindSet ToggleChaos;

	// Token: 0x04003281 RID: 12929
	public static RandomizerRebinding.BindSet ChaosVerbosity;

	// Token: 0x04003282 RID: 12930
	public static RandomizerRebinding.BindSet ForceChaosEffect;

	// Token: 0x04003283 RID: 12931
	public static RandomizerRebinding.BindSet ShowProgress;

	// Token: 0x04003284 RID: 12932
	public static RandomizerRebinding.BindSet ColorShift;

	// Token: 0x04003285 RID: 12933
	public static RandomizerRebinding.BindSet DoubleBash;

	// Token: 0x04003286 RID: 12934
	public static RandomizerRebinding.BindSet BonusSwitch;

	// Token: 0x04003287 RID: 12935
	public static RandomizerRebinding.BindSet BonusToggle;

	// Token: 0x02000A03 RID: 2563
	public class Bind
	{
		// Token: 0x060037BA RID: 14266 RVA: 0x000E4884 File Offset: 0x000E2A84
		public Bind(string input)
		{
			input = input.Trim();
			if (RandomizerRebinding.ActionMap.ContainsKey(input))
			{
				this.Action = (Input.InputButtonProcessor)RandomizerRebinding.ActionMap[input];
				this.ActionBind = true;
				return;
			}
			this.ActionBind = false;
			this.Key = RandomizerRebinding.StringToKeyBinding(input);
		}

		// Token: 0x060037BB RID: 14267 RVA: 0x0002BD24 File Offset: 0x00029F24
		public bool IsPressed()
		{
			if (this.ActionBind)
			{
				return this.Action.Pressed;
			}
			return MoonInput.GetKey(this.Key);
		}

		// Token: 0x04003288 RID: 12936
		public KeyCode Key;

		// Token: 0x04003289 RID: 12937
		public Input.InputButtonProcessor Action;

		// Token: 0x0400328A RID: 12938
		public bool ActionBind;
	}

	// Token: 0x02000A04 RID: 2564
	public class BindSet
	{
		// Token: 0x060037BC RID: 14268 RVA: 0x0002BD45 File Offset: 0x00029F45
		public BindSet(ArrayList binds)
		{
			this.binds = binds;
			this.wasPressed = true;
		}

		// Token: 0x060037BD RID: 14269 RVA: 0x000E48E0 File Offset: 0x000E2AE0
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

		// Token: 0x0400328B RID: 12939
		public ArrayList binds;

		// Token: 0x0400328C RID: 12940
		public bool wasPressed;
	}
}
