using System;
using System.IO;

// Token: 0x02000A0A RID: 2570
public static class RandomizerSettings
{
	// Token: 0x060037D0 RID: 14288
	public static void WriteDefaultFile()
	{
		StreamWriter streamWriter = new StreamWriter("RandomizerSettings.txt");
		streamWriter.WriteLine("Controller Bash Deadzone: 0.5");
		streamWriter.Flush();
		streamWriter.Close();
	}

	// Token: 0x060037D1 RID: 14289
	public static void ParseSettings()
	{
		if (!File.Exists("RandomizerSettings.txt"))
		{
			RandomizerSettings.WriteDefaultFile();
		}
		try
		{
			if (!float.TryParse(File.ReadAllLines("RandomizerSettings.txt")[0].Split(new char[]
			{
				':'
			})[1], out RandomizerSettings.BashDeadzone))
			{
				RandomizerSettings.LoadDefaultSettings();
			}
			RandomizerSettings.BashDeadzone = Math.Max(0f, Math.Min(1f, RandomizerSettings.BashDeadzone));
		}
		catch (Exception)
		{
			RandomizerSettings.LoadDefaultSettings();
		}
	}

	// Token: 0x060037D2 RID: 14290
	public static void LoadDefaultSettings()
	{
		RandomizerSettings.BashDeadzone = 0.5f;
	}

	// Token: 0x040032A7 RID: 12967
	public static float BashDeadzone;
}
