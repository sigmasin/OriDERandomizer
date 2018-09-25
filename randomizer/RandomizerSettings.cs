using System;
using System.IO;

// Token: 0x02000A11 RID: 2577
public static class RandomizerSettings
{
	// Token: 0x06003803 RID: 14339
	public static void WriteDefaultFile()
	{
		StreamWriter streamWriter = new StreamWriter("RandomizerSettings.txt");
		streamWriter.WriteLine("Controller Bash Deadzone: 0.5");
		streamWriter.WriteLine("Ability Menu Opacity: 0.5");
		streamWriter.Flush();
		streamWriter.Close();
	}

	// Token: 0x06003804 RID: 14340
	public static void ParseSettings()
	{
		if (!File.Exists("RandomizerSettings.txt"))
		{
			RandomizerSettings.WriteDefaultFile();
		}
		try
		{
			string[] lines = File.ReadAllLines("RandomizerSettings.txt");
			RandomizerSettings.BashDeadzone = float.Parse(lines[0].Split(new char[]
			{
				':'
			})[1]);
			RandomizerSettings.AbilityMenuOpacity = float.Parse(lines[1].Split(new char[]
			{
				':'
			})[1]);
			RandomizerSettings.BashDeadzone = Math.Max(0f, Math.Min(1f, RandomizerSettings.BashDeadzone));
			RandomizerSettings.AbilityMenuOpacity = Math.Max(0f, Math.Min(1f, RandomizerSettings.AbilityMenuOpacity));
		}
		catch (Exception)
		{
			RandomizerSettings.LoadDefaultSettings();
		}
	}

	// Token: 0x06003805 RID: 14341
	public static void LoadDefaultSettings()
	{
		RandomizerSettings.BashDeadzone = 0.5f;
		RandomizerSettings.AbilityMenuOpacity = 0.5f;
	}

	// Token: 0x040032C2 RID: 12994
	public static float BashDeadzone;

	// Token: 0x040032E5 RID: 13029
	public static float AbilityMenuOpacity;
}
