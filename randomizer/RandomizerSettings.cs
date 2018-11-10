using System;
using System.IO;
using UnityEngine;

// Token: 0x02000A12 RID: 2578
public static class RandomizerSettings
{
	// Token: 0x06003807 RID: 14343
	public static void WriteDefaultFile()
	{
		StreamWriter streamWriter = new StreamWriter("RandomizerSettings.txt");
		streamWriter.WriteLine("Controller Bash Deadzone: 0.5");
		streamWriter.WriteLine("Ability Menu Opacity: 0.5");
		streamWriter.WriteLine("Instant Grenade Aim: False");
		streamWriter.WriteLine("Grenade Aim Speed: 1.0");
		streamWriter.WriteLine("Cold Color: 0, 255, 255, 255");
		streamWriter.WriteLine("Hot Color: 255, 85, 0, 255");
		streamWriter.WriteLine("Dev: False");
		streamWriter.Flush();
		streamWriter.Close();
	}

	// Token: 0x06003808 RID: 14344
	public static void ParseSettings()
	{
		if (!File.Exists("RandomizerSettings.txt"))
		{
			RandomizerSettings.WriteDefaultFile();
		}
		try
		{
			string[] array = File.ReadAllLines("RandomizerSettings.txt");
			RandomizerSettings.BashDeadzone = float.Parse(array[0].Split(new char[]
			{
				':'
			})[1]);
			RandomizerSettings.AbilityMenuOpacity = float.Parse(array[1].Split(new char[]
			{
				':'
			})[1]);
			RandomizerSettings.FastGrenadeAim = (array[2].Split(new char[]
			{
				':'
			})[1].Trim() == "True");
			RandomizerSettings.GrenadeAimSpeed = float.Parse(array[3].Split(new char[]
			{
				':'
			})[1]);
			RandomizerSettings.ColdColor = RandomizerSettings.ParseColor(array[4].Split(new char[]
			{
				':'
			})[1]);
			RandomizerSettings.HotColor = RandomizerSettings.ParseColor(array[5].Split(new char[]
			{
				':'
			})[1]);
			try {
				RandomizerSettings.Dev = (array[6].Split(new char[]
				{
					':'
				})[1].Trim().ToLower() == "true");
			}
			catch(Exception) {
				RandomizerSettings.Dev = false;
			}
			RandomizerSettings.BashDeadzone = Math.Max(0f, Math.Min(1f, RandomizerSettings.BashDeadzone));
			RandomizerSettings.AbilityMenuOpacity = Math.Max(0f, Math.Min(1f, RandomizerSettings.AbilityMenuOpacity));
		}
		catch (Exception)
		{
			RandomizerSettings.LoadDefaultSettings();
		}
	}

	// Token: 0x06003809 RID: 14345
	public static void LoadDefaultSettings()
	{
		RandomizerSettings.BashDeadzone = 0.5f;
		RandomizerSettings.AbilityMenuOpacity = 0.5f;
		RandomizerSettings.FastGrenadeAim = false;
		RandomizerSettings.GrenadeAimSpeed = 1f;
		RandomizerSettings.ColdColor = new Color(0f, 0.5f, 0.5f, 0.5f);
		RandomizerSettings.HotColor = new Color(0.5f, 0.1666f, 0f, 0.5f);
	}

	// Token: 0x06003887 RID: 14471
	private static Color ParseColor(string input)
	{
		string[] components = input.Split(new char[]
		{
			','
		});
		return new Color(float.Parse(components[0]) / 511f, float.Parse(components[1]) / 511f, float.Parse(components[2]) / 511f, float.Parse(components[3]) / 511f);
	}

	// Token: 0x040032D0 RID: 13008
	public static float BashDeadzone;

	// Token: 0x040032D1 RID: 13009
	public static float AbilityMenuOpacity;

	// Token: 0x040032D2 RID: 13010
	public static bool FastGrenadeAim;

	// Token: 0x040032D3 RID: 13011
	public static float GrenadeAimSpeed;

	// Token: 0x040033A6 RID: 13222
	public static Color ColdColor;

	// Token: 0x040033A7 RID: 13223
	public static Color HotColor;

	public static bool Dev;
}
