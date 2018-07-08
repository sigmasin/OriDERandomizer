using System;
using System.Collections;
using System.IO;
using Core;
using UnityEngine;

// Token: 0x020009FC RID: 2556
public static class RandomizerRebinding
{
	// Token: 0x0600378C RID: 14220
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

	// Token: 0x0600378D RID: 14221
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
			File.Delete("RandomizerRebinding.txt");
			Randomizer.showHint("Bindings reset to default");
			RandomizerRebinding.WriteDefaultFile();
			RandomizerRebinding.LoadDefaultBinds();
		}
	}

	// Token: 0x0600378E RID: 14222
	public static KeyCode StringToKeyBinding(string s)
	{
		if (s != "")
		{
			return (KeyCode)((int)Enum.Parse(typeof(KeyCode), s));
		}
		return KeyCode.None;
	}

	// Token: 0x0600378F RID: 14223
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

	// Token: 0x060037F8 RID: 14328
	public static RandomizerRebinding.BindSet ParseLine(string line)
	{
		string[] array3 = line.Split(new char[] { ':' })[1].Split(new char[] { ',' });
		ArrayList bindSet = new ArrayList();
		string[] array2 = array3;
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array4 = array2[i].Split(new char[] { '+' });
			ArrayList bind = new ArrayList();
			foreach (string key in array4)
			{
				if (key.ToLower() == "tap")
				{
					Randomizer.BashTap = true;
				}
				else 
				{
					bind.Add(new RandomizerRebinding.Bind(key));
				}
			}
			if (bind.Count > 0) 
			{
				bindSet.Add(bind);
			}
		}
		return new RandomizerRebinding.BindSet(bindSet);
	}

	// Token: 0x040032AA RID: 12970
	public static Hashtable ActionMap;

	// Token: 0x040032E1 RID: 13025
	public static RandomizerRebinding.BindSet ReplayMessage;
	public static RandomizerRebinding.BindSet ReturnToStart;
	public static RandomizerRebinding.BindSet ReloadSeed;
	public static RandomizerRebinding.BindSet ToggleChaos;
	public static RandomizerRebinding.BindSet ChaosVerbosity;
	public static RandomizerRebinding.BindSet ForceChaosEffect;
	public static RandomizerRebinding.BindSet ShowProgress;
	public static RandomizerRebinding.BindSet ColorShift;
	public static RandomizerRebinding.BindSet DoubleBash;
	public static RandomizerRebinding.BindSet BonusSwitch;
	public static RandomizerRebinding.BindSet BonusToggle;


	// Token: 0x02000A08 RID: 2568
	public class Bind
	{
		// Token: 0x060037CA RID: 14282
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

		// Token: 0x060037CB RID: 14283
		public bool IsPressed()
		{
			if (this.ActionBind)
			{
				return this.Action.Pressed;
			}
			return MoonInput.GetKey(this.Key);
		}

		// Token: 0x0400329F RID: 12959
		public KeyCode Key;

		// Token: 0x040032A0 RID: 12960
		public Core.Input.InputButtonProcessor Action;

		// Token: 0x040032A1 RID: 12961
		public bool ActionBind;
	}

	// Token: 0x02000A09 RID: 2569
	public class BindSet
	{
		// Token: 0x060037F2 RID: 14322
		public BindSet(ArrayList binds)
		{
			this.binds = binds;
			this.wasPressed = true;
		}

		// Token: 0x060037F3 RID: 14323
		public bool IsPressed()
		{
			foreach (object obj in this.binds)
			{
				ArrayList arrayList = (ArrayList)obj;
				bool active = true;
				foreach(Bind bind in arrayList)
				{
					if(!bind.IsPressed()) 
					{
						active=false;
						break;
					}
				}
				if (active)
				{
					if(this.wasPressed)
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

		// Token: 0x040032E0 RID: 13024
		public ArrayList binds;

		// Token: 0x04003459 RID: 13401
		public bool wasPressed;
	}
}
