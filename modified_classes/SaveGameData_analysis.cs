/*

This class contains a modified load method which logs all saved objects when a
file is loaded. To be used for investigation purposes only (this code should
never be present in a release).

*/

using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public partial class SaveGameData
{
	public bool LoadFromReader(BinaryReader reader)
	{

		this.Scenes.Clear();
		this.PendingScenes.Clear();
		if (reader.ReadString() != "SaveGameData")
		{
			return false;
		}
		SaveGameData.CurrentSaveFileVersion = reader.ReadInt32();

		bool logging = true;
		bool reading = true;
		Hashtable DifferentDataMap = new Hashtable();
		if (reading)
		{
			string[] array = File.ReadAllLines("datamap.dat");
			for (int i = 0; i < array.Length; i += 2)
			{
				DifferentDataMap[array[i]] = array[i + 1];
			}
		}

		int num = reader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			SaveScene saveScene = new SaveScene();
			saveScene.SceneGUID = new MoonGuid(reader.ReadBytes(16));
			Randomizer.log("SCENE");
			Randomizer.log(saveScene.SceneGUID.ToString());
			this.Scenes.Add(saveScene.SceneGUID, saveScene);
			int num2 = reader.ReadInt32();
			for (int j = 0; j < num2; j++)
			{
				SaveObject saveObject = new SaveObject(new MoonGuid(reader.ReadBytes(16)));
				if (logging)
				{
					Randomizer.log(saveObject.Id.ToString());
				}
				saveObject.Data.ReadMemoryStreamFromBinaryReader(reader);
				if (logging)
				{
					string str = "";
					for (int k = 0; k < saveObject.Data.MemoryStream.GetBuffer().Length; k++)
					{
						str = str + saveObject.Data.MemoryStream.GetBuffer()[k].ToString() + " ";
					}
					Randomizer.log(str);
				}
				if (reading && DifferentDataMap.ContainsKey(saveObject.Id.ToString()))
				{
					saveObject.Data = new Archive();
					string[] array = ((string)DifferentDataMap[saveObject.Id.ToString()]).Split(' ');
					byte[] bytes = new byte[array.Length];
					for (int k = 0; k < array.Length; k++)
					{
						bytes[k] = Convert.ToByte(array[k]);
					}					
					BinaryReader binaryReader = new BinaryReader(new MemoryStream(bytes));
					saveObject.Data.MemoryStream.SetLength((long)bytes.Length);
					binaryReader.Read(saveObject.Data.MemoryStream.GetBuffer(), 0, bytes.Length);
				}

				saveScene.SaveObjects.Add(saveObject);
			}
		}
		return true;
	}
}
