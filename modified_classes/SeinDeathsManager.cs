using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

// Token: 0x0200031B RID: 795
public class SeinDeathsManager : SaveSerialize
{
	// Token: 0x06001087 RID: 4231 RVA: 0x0000E6DE File Offset: 0x0000C8DE
	public SeinDeathsManager()
	{
	}

	// Token: 0x06001088 RID: 4232 RVA: 0x0000E6F1 File Offset: 0x0000C8F1
	[ContextMenu("Fake a death here")]
	public void FakeADeathHere()
	{
		this.RecordDeath();
	}

	// Token: 0x06001089 RID: 4233 RVA: 0x0000E6F9 File Offset: 0x0000C8F9
	public override void Awake()
	{
		base.Awake();
		SeinDeathsManager.Instance = this;
		Events.Scheduler.OnGameReset.Add(new Action(this.OnGameReset));
	}

	// Token: 0x0600108A RID: 4234 RVA: 0x0000E722 File Offset: 0x0000C922
	public override void OnDestroy()
	{
		base.OnDestroy();
		if (SeinDeathsManager.Instance == this)
		{
			SeinDeathsManager.Instance = null;
		}
		Events.Scheduler.OnGameReset.Remove(new Action(this.OnGameReset));
	}

	// Token: 0x0600108B RID: 4235 RVA: 0x0000E75B File Offset: 0x0000C95B
	public void OnGameReset()
	{
		this.Deaths.Clear();
	}

	// Token: 0x0600108C RID: 4236 RVA: 0x00062F1C File Offset: 0x0006111C
	public override void Serialize(Archive ar)
	{
		if (ar.Reading)
		{
			int num = ar.Serialize(0);
			this.Deaths.Clear();
			for (int i = 0; i < num; i++)
			{
				DeathInformation deathInformation = new DeathInformation();
				deathInformation.Serialize(ar);
				this.Deaths.Add(deathInformation);
			}
			DeathWispsManager.Refresh();
		}
		else
		{
			int count = this.Deaths.Count;
			ar.Serialize(count);
			for (int j = 0; j < count; j++)
			{
				this.Deaths[j].Serialize(ar);
			}
		}
	}

	// Token: 0x0600108D RID: 4237 RVA: 0x0000E768 File Offset: 0x0000C968
	public static void OnDeath()
	{
		RandomizerSyncManager.onDeath();
		if (SeinDeathsManager.Instance && DifficultyController.Instance.Difficulty == DifficultyMode.OneLife)
		{
			SeinDeathsManager.Instance.Deaths.Clear();
			SeinDeathsManager.Instance.RecordDeath();
		}
	}

	// Token: 0x0600108E RID: 4238 RVA: 0x00062FBC File Offset: 0x000611BC
	public void RecordDeath()
	{
		Vector3 position = Characters.Sein.Position;
		int gameTimeInSeconds = GameController.Instance.GameTimeInSeconds;
		int completionPercentage = GameWorld.Instance.CompletionPercentage;
		int count = this.Deaths.Count;
		this.Deaths.Add(new DeathInformation(position, gameTimeInSeconds, completionPercentage, count));
		SaveSceneManager.Master.Save(Game.Checkpoint.SaveGameData.Master, SeinDeathsManager.Instance);
	}

	// Token: 0x04000FC7 RID: 4039
	public static SeinDeathsManager Instance;

	// Token: 0x04000FC8 RID: 4040
	public List<DeathInformation> Deaths = new List<DeathInformation>();
}
