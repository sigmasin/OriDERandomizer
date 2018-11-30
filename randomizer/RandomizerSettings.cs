using System;
using System.IO;
using UnityEngine;

// Token: 0x02000A15 RID: 2581
public static class RandomizerSettings
{
	// Token: 0x0600381B RID: 14363 RVA: 0x000E7DB8 File Offset: 0x000E5FB8
	public static void WriteDefaultFile()
	{
		StreamWriter streamWriter = new StreamWriter("RandomizerSettings.txt");
		streamWriter.WriteLine("Controller Bash Deadzone: 0.5");
		streamWriter.WriteLine("Ability Menu Opacity: 0.5");
		streamWriter.WriteLine("Instant Grenade Aim: False");
		streamWriter.WriteLine("Grenade Aim Speed: 1.0");
		streamWriter.WriteLine("Cold Color: 0, 255, 255, 255");
		streamWriter.WriteLine("Hot Color: 255, 85, 0, 255");
		streamWriter.WriteLine("Invert Swim: False");
		streamWriter.WriteLine("Dev: False");
		streamWriter.Flush();
		streamWriter.Close();
	}

	// Token: 0x0600381C RID: 14364 RVA: 0x000E7E28 File Offset: 0x000E6028
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
			try
			{
				RandomizerSettings.InvertSwim = (array[6].Split(new char[]
				{
					':'
				})[1].Trim().ToLower() == "true");

				RandomizerSettings.Dev = (array[7].Split(new char[]
				{
					':'
				})[1].Trim().ToLower() == "true");
			}
			catch (Exception)
			{
				RandomizerSettings.InvertSwim = false;
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

	public static bool IsSwimBoosting()
	{
		if(RandomizerSettings.InvertSwim)
			return !Core.Input.Jump.IsPressed;
		else
			return Core.Input.Jump.IsPressed;
	}

	// Token: 0x0600381D RID: 14365 RVA: 0x000E7FCC File Offset: 0x000E61CC
	public static void LoadDefaultSettings()
	{
		RandomizerSettings.BashDeadzone = 0.5f;
		RandomizerSettings.AbilityMenuOpacity = 0.5f;
		RandomizerSettings.FastGrenadeAim = false;
		RandomizerSettings.GrenadeAimSpeed = 1f;
		RandomizerSettings.ColdColor = new Color(0f, 0.5f, 0.5f, 0.5f);
		RandomizerSettings.HotColor = new Color(0.5f, 0.1666f, 0f, 0.5f);
	}

	// Token: 0x0600381E RID: 14366 RVA: 0x000E803C File Offset: 0x000E623C
	private static Color ParseColor(string input)
	{
		string[] array = input.Split(new char[]
		{
			','
		});
		return new Color(float.Parse(array[0]) / 511f, float.Parse(array[1]) / 511f, float.Parse(array[2]) / 511f, float.Parse(array[3]) / 511f);
	}

	// Token: 0x040032EB RID: 13035
	public static float BashDeadzone;

	// Token: 0x040032EC RID: 13036
	public static float AbilityMenuOpacity;

	// Token: 0x040032ED RID: 13037
	public static bool FastGrenadeAim;

	// Token: 0x040032EE RID: 13038
	public static float GrenadeAimSpeed;

	// Token: 0x040032EF RID: 13039
	public static Color ColdColor;

	// Token: 0x040032F0 RID: 13040
	public static Color HotColor;

	public static bool InvertSwim;

	// Token: 0x040032F1 RID: 13041
	public static bool Dev;
}
