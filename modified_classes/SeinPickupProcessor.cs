using System;
using Game;
using UnityEngine;

// Token: 0x02000919 RID: 2329
public class SeinPickupProcessor : SaveSerialize, ISeinReceiver, IPickupCollector, ICheckpointZoneReciever
{
	// Token: 0x06003320 RID: 13088 RVA: 0x000286A2 File Offset: 0x000268A2
	public void OnCollectSkillPointPickup(SkillPointPickup skillPointPickup)
	{
		skillPointPickup.Collected();
		Randomizer.getPickup();
		if (GameWorld.Instance.CurrentArea != null)
		{
			GameWorld.Instance.CurrentArea.DirtyCompletionAmount();
		}
	}

	// Token: 0x06003321 RID: 13089 RVA: 0x000D3048 File Offset: 0x000D1248
	public void OnCollectEnergyOrbPickup(EnergyOrbPickup energyOrbPickup)
	{
		float num = (float)energyOrbPickup.Amount;
		if (this.Sein.PlayerAbilities.EnergyEfficiency.HasAbility)
		{
			num *= 1.5f;
		}
		bool canAffordSoulFlame = this.Sein.SoulFlame.CanAffordSoulFlame;
		AchievementsLogic.Instance.OnCollectedEnergyShard();
		this.Sein.Energy.Gain(num);
		energyOrbPickup.Collected();
		if (!canAffordSoulFlame && this.Sein.SoulFlame.CanAffordSoulFlame)
		{
			UI.SeinUI.ShakeSoulFlame();
		}
		if (!this.Sein.PlayerAbilities.WallJump.HasAbility)
		{
			this.EnergyOrbInfo.RunActionIfFirstTime();
		}
		UI.SeinUI.ShakeEnergyOrbBar();
	}

	// Token: 0x06003322 RID: 13090 RVA: 0x000286A2 File Offset: 0x000268A2
	public void OnCollectMaxEnergyContainerPickup(MaxEnergyContainerPickup energyContainerPickup)
	{
		energyContainerPickup.Collected();
		Randomizer.getPickup();
		if (GameWorld.Instance.CurrentArea != null)
		{
			GameWorld.Instance.CurrentArea.DirtyCompletionAmount();
		}
	}

	// Token: 0x06003323 RID: 13091 RVA: 0x000D3108 File Offset: 0x000D1308
	public void OnCollectExpOrbPickup(ExpOrbPickup expOrbPickup)
	{
		int num = expOrbPickup.Amount * ((!this.Sein.PlayerAbilities.SoulEfficiency.HasAbility) ? 1 : 2);
		expOrbPickup.Collected();
		if (expOrbPickup.MessageType != ExpOrbPickup.ExpOrbMessageType.None)
		{
			Randomizer.getPickup();
			if (GameWorld.Instance.CurrentArea != null)
			{
				GameWorld.Instance.CurrentArea.DirtyCompletionAmount();
			}
			return;
		}
		this.Sein.Level.GainExperience(num);
		if (this.m_expText && this.m_expText.gameObject.activeInHierarchy)
		{
			this.m_expText.Amount += num;
		}
		else
		{
			this.m_expText = Orbs.OrbDisplayText.Create(Characters.Sein.Transform, Vector3.up, num);
		}
		UI.SeinUI.ShakeExperienceBar();
		if (GameWorld.Instance.CurrentArea != null)
		{
			GameWorld.Instance.CurrentArea.DirtyCompletionAmount();
		}
	}

	// Token: 0x06003324 RID: 13092 RVA: 0x000286A2 File Offset: 0x000268A2
	public void OnCollectKeystonePickup(KeystonePickup keystonePickup)
	{
		keystonePickup.Collected();
		Randomizer.getPickup();
		if (GameWorld.Instance.CurrentArea != null)
		{
			GameWorld.Instance.CurrentArea.DirtyCompletionAmount();
		}
	}

	// Token: 0x06003325 RID: 13093 RVA: 0x000286A2 File Offset: 0x000268A2
	public void OnCollectMaxHealthContainerPickup(MaxHealthContainerPickup maxHealthContainerPickup)
	{
		maxHealthContainerPickup.Collected();
		Randomizer.getPickup();
		if (GameWorld.Instance.CurrentArea != null)
		{
			GameWorld.Instance.CurrentArea.DirtyCompletionAmount();
		}
	}

	// Token: 0x06003326 RID: 13094 RVA: 0x000D31EC File Offset: 0x000D13EC
	public void OnCollectRestoreHealthPickup(RestoreHealthPickup restoreHealthPickup)
	{
		int amount = restoreHealthPickup.Amount * ((!this.Sein.PlayerAbilities.HealthEfficiency.HasAbility) ? 1 : 2);
		this.Sein.Mortality.Health.GainHealth(amount);
		restoreHealthPickup.Collected();
		UI.SeinUI.ShakeHealthbar();
		if (!this.Sein.PlayerAbilities.WallJump.HasAbility)
		{
			this.HealthOrbInfo.RunActionIfFirstTime();
		}
	}

	// Token: 0x06003327 RID: 13095 RVA: 0x000286A2 File Offset: 0x000268A2
	public void OnCollectMapStonePickup(MapStonePickup mapStonePickup)
	{
		mapStonePickup.Collected();
		Randomizer.getPickup();
		if (GameWorld.Instance.CurrentArea != null)
		{
			GameWorld.Instance.CurrentArea.DirtyCompletionAmount();
		}
	}

	// Token: 0x06003328 RID: 13096 RVA: 0x000286CA File Offset: 0x000268CA
	public void SetReferenceToSein(SeinCharacter sein)
	{
		this.Sein = sein;
	}

	// Token: 0x06003329 RID: 13097 RVA: 0x000D3270 File Offset: 0x000D1470
	public void OnEnterCheckpoint(InvisibleCheckpoint checkpoint)
	{
		if (this.Sein.IsSuspended)
		{
			return;
		}
		Vector3 position = this.Sein.Position;
		if (checkpoint.RespawnPosition != Vector2.zero)
		{
			this.Sein.Position = checkpoint.RespawnPosition + checkpoint.transform.position;
		}
		GameController.Instance.CreateCheckpoint();
		this.Sein.Position = position;
		checkpoint.OnCheckpointCreated();
	}

	// Token: 0x0600332A RID: 13098 RVA: 0x000D32F8 File Offset: 0x000D14F8
	public override void Serialize(Archive ar)
	{
		ar.Serialize(ref this.ExpOrbInfo.HasBeenCollectedBefore);
		ar.Serialize(ref this.KeystoneInfo.HasBeenCollectedBefore);
		ar.Serialize(ref this.EnergyOrbInfo.HasBeenCollectedBefore);
		ar.Serialize(ref this.HealthOrbInfo.HasBeenCollectedBefore);
		ar.Serialize(ref this.SmallExpOrbInfo.HasBeenCollectedBefore);
		ar.Serialize(ref this.MediumExpOrbInfo.HasBeenCollectedBefore);
		ar.Serialize(ref this.LargeExpOrbInfo.HasBeenCollectedBefore);
		ar.Serialize(ref this.m_collectedMaxEnergySlotsCount);
		ar.Serialize(ref this.m_energySlotsAchievementAwarded);
		ar.Serialize(ref this.m_collectedHealthSlotsCount);
		ar.Serialize(ref this.m_healthSlotsAchievementAwarded);
	}

	// Token: 0x04002E1B RID: 11803
	public SeinCharacter Sein;

	// Token: 0x04002E1C RID: 11804
	public SeinPickupProcessor.CollectableInformation ExpOrbInfo = new SeinPickupProcessor.CollectableInformation();

	// Token: 0x04002E1D RID: 11805
	public SeinPickupProcessor.CollectableInformation KeystoneInfo = new SeinPickupProcessor.CollectableInformation();

	// Token: 0x04002E1E RID: 11806
	public SeinPickupProcessor.CollectableInformation EnergyOrbInfo = new SeinPickupProcessor.CollectableInformation();

	// Token: 0x04002E1F RID: 11807
	public SeinPickupProcessor.CollectableInformation HealthOrbInfo = new SeinPickupProcessor.CollectableInformation();

	// Token: 0x04002E20 RID: 11808
	public SeinPickupProcessor.CollectableInformation SmallExpOrbInfo = new SeinPickupProcessor.CollectableInformation();

	// Token: 0x04002E21 RID: 11809
	public SeinPickupProcessor.CollectableInformation MediumExpOrbInfo = new SeinPickupProcessor.CollectableInformation();

	// Token: 0x04002E22 RID: 11810
	public SeinPickupProcessor.CollectableInformation LargeExpOrbInfo = new SeinPickupProcessor.CollectableInformation();

	// Token: 0x04002E23 RID: 11811
	public ActionMethod HeartContainerSequence;

	// Token: 0x04002E24 RID: 11812
	public ActionMethod SkillPointSequence;

	// Token: 0x04002E25 RID: 11813
	public ActionMethod EnergyContainerSequence;

	// Token: 0x04002E26 RID: 11814
	public ActionMethod MapStoneSequence;

	// Token: 0x04002E27 RID: 11815
	private ExpText m_expText;

	// Token: 0x04002E28 RID: 11816
	public AchievementAsset Collect200EnergyCrystalsAchievementAsset;

	// Token: 0x04002E29 RID: 11817
	public AchievementAsset AllEnergyCellsCollected;

	// Token: 0x04002E2A RID: 11818
	public AchievementAsset AllHealthCellsCollected;

	// Token: 0x04002E2B RID: 11819
	private int m_collectedMaxEnergySlotsCount;

	// Token: 0x04002E2C RID: 11820
	private bool m_energySlotsAchievementAwarded;

	// Token: 0x04002E2D RID: 11821
	private int m_collectedHealthSlotsCount;

	// Token: 0x04002E2E RID: 11822
	private bool m_healthSlotsAchievementAwarded;

	// Token: 0x04002E2F RID: 11823
	public static Action OnCollectMaxEnergyContainer = delegate
	{
	};

	// Token: 0x0200091A RID: 2330
	[Serializable]
	public class CollectableInformation
	{
		// Token: 0x0600332D RID: 13101 RVA: 0x000028E7 File Offset: 0x00000AE7
		public void RunActionIfFirstTime()
		{
		}

		// Token: 0x04002E31 RID: 11825
		public bool HasBeenCollectedBefore;

		// Token: 0x04002E32 RID: 11826
		public ActionMethod FirstTimeCollectedSequence;
	}
}
