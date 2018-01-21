using System;
using System.Runtime.CompilerServices;
using Core;
using Game;
using Sein.World;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class SeinSoulFlame : CharacterState, ISeinReceiver
{
	// Token: 0x0600135A RID: 4954 RVA: 0x00010F05 File Offset: 0x0000F105
	static SeinSoulFlame()
	{
		SeinSoulFlame.OnSoulFlameCast = delegate
		{
		};
	}

	// Token: 0x1400001C RID: 28
	// (add) Token: 0x0600135B RID: 4955 RVA: 0x00010F29 File Offset: 0x0000F129
	// (remove) Token: 0x0600135C RID: 4956 RVA: 0x00010F40 File Offset: 0x0000F140
	public static event Action OnSoulFlameCast
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			SeinSoulFlame.OnSoulFlameCast = (Action)Delegate.Combine(SeinSoulFlame.OnSoulFlameCast, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			SeinSoulFlame.OnSoulFlameCast = (Action)Delegate.Remove(SeinSoulFlame.OnSoulFlameCast, value);
		}
	}

	// Token: 0x17000389 RID: 905
	// (get) Token: 0x0600135D RID: 4957 RVA: 0x00010F57 File Offset: 0x0000F157
	public bool SoulFlameExists
	{
		get
		{
			return this.m_checkpointMarkerGameObject;
		}
	}

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x0600135E RID: 4958 RVA: 0x00010F64 File Offset: 0x0000F164
	public Vector3 SoulFlamePosition
	{
		get
		{
			return this.m_checkpointMarkerGameObject.transform.position;
		}
	}

	// Token: 0x0600135F RID: 4959 RVA: 0x00010F76 File Offset: 0x0000F176
	public new void Awake()
	{
		base.Awake();
		Game.Checkpoint.Events.OnPostRestore.Add(new Action(this.OnRestoreCheckpoint));
		Game.Events.Scheduler.OnGameReset.Add(new Action(this.OnGameReset));
	}

	// Token: 0x06001360 RID: 4960 RVA: 0x00010FAF File Offset: 0x0000F1AF
	public void OnGameReset()
	{
		this.m_numberOfSoulFlamesCast = 0;
	}

	// Token: 0x06001361 RID: 4961 RVA: 0x00010FB8 File Offset: 0x0000F1B8
	public void OnRestoreCheckpoint()
	{
		if (this.CanAffordSoulFlame)
		{
			this.m_cooldownRemaining = 0f;
		}
		this.LockSoulFlame = false;
		this.m_nagTimer = this.NagDuration;
	}

	// Token: 0x06001362 RID: 4962 RVA: 0x0006D52C File Offset: 0x0006B72C
	public override void OnDestroy()
	{
		base.OnDestroy();
		Game.Checkpoint.Events.OnPostRestore.Remove(new Action(this.OnRestoreCheckpoint));
		Game.Events.Scheduler.OnGameReset.Remove(new Action(this.OnGameReset));
		if (this.m_checkpointMarkerGameObject)
		{
			InstantiateUtility.Destroy(this.m_checkpointMarkerGameObject);
			this.m_soulFlame = null;
			this.m_checkpointMarkerGameObject = null;
		}
	}

	// Token: 0x06001363 RID: 4963 RVA: 0x00010FE3 File Offset: 0x0000F1E3
	public void FillSoulFlameBar()
	{
		this.m_cooldownRemaining = 0f;
		this.m_nagTimer = 0f;
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x06001364 RID: 4964 RVA: 0x00010FFB File Offset: 0x0000F1FB
	public bool InsideCheckpointMarker
	{
		get
		{
			return this.m_soulFlame && this.m_soulFlame.IsInside;
		}
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x06001365 RID: 4965 RVA: 0x0006D59C File Offset: 0x0006B79C
	public SeinSoulFlame.SoulFlamePlacementSafety IsSafeToCastSoulFlame
	{
		get
		{
			Vector3 position = this.m_sein.Position;
			for (int i = 0; i < NoSoulFlameZone.All.Count; i++)
			{
				NoSoulFlameZone noSoulFlameZone = NoSoulFlameZone.All[i];
				if (noSoulFlameZone.BoundingRect.Contains(position))
				{
					return SeinSoulFlame.SoulFlamePlacementSafety.UnsafeZone;
				}
			}
			if (!Sein.World.Events.DarknessLifted && SpiritLightDarknessZone.IsInsideDarknessZone(position) && !SaveInTheDarkZone.IsInside(position) && !LightSource.TestPosition(position, 0f))
			{
				return SeinSoulFlame.SoulFlamePlacementSafety.UnsafeZone;
			}
			for (int j = 0; j < SavePedestal.All.Count; j++)
			{
				SavePedestal savePedestal = SavePedestal.All[j];
				if (savePedestal.IsInside)
				{
					return SeinSoulFlame.SoulFlamePlacementSafety.SavePedestal;
				}
			}
			for (int k = 0; k < this.m_sein.Abilities.SpiritFlameTargetting.ClosestAttackables.Count; k++)
			{
				ISpiritFlameAttackable spiritFlameAttackable = this.m_sein.Abilities.SpiritFlameTargetting.ClosestAttackables[k];
				EntityTargetting entityTargetting = spiritFlameAttackable as EntityTargetting;
				if (entityTargetting && entityTargetting.Entity is Enemy)
				{
					return SeinSoulFlame.SoulFlamePlacementSafety.UnsafeEnemies;
				}
			}
			for (int l = 0; l < RespawningPlaceholder.All.Count; l++)
			{
				RespawningPlaceholder respawningPlaceholder = RespawningPlaceholder.All[l];
				if (!respawningPlaceholder.EntityIsDead && Vector3.Distance(position, respawningPlaceholder.Position) < 10f)
				{
					return SeinSoulFlame.SoulFlamePlacementSafety.UnsafeEnemies;
				}
			}
			if (this.m_sein.Mortality.DamageReciever.IsInvinsible)
			{
				return SeinSoulFlame.SoulFlamePlacementSafety.UnsafeZone;
			}
			Collider groundCollider = this.m_sein.PlatformBehaviour.PlatformMovementListOfColliders.GroundCollider;
			if (groundCollider)
			{
				if (groundCollider.attachedRigidbody)
				{
					return SeinSoulFlame.SoulFlamePlacementSafety.UnsafeGround;
				}
				if (groundCollider.GetComponent<HeatUpPlatform>())
				{
					return SeinSoulFlame.SoulFlamePlacementSafety.UnsafeGround;
				}
			}
			bool flag = Physics.SphereCast(new Ray(position, Vector3.right), 0.5f, 0.7f, this.UnsafeMask);
			flag |= Physics.SphereCast(new Ray(position, -Vector3.right), 0.5f, 0.7f, this.UnsafeMask);
			if (flag)
			{
				return SeinSoulFlame.SoulFlamePlacementSafety.UnsafeGround;
			}
			return SeinSoulFlame.SoulFlamePlacementSafety.Safe;
		}
	}

	// Token: 0x1700038D RID: 909
	// (get) Token: 0x06001366 RID: 4966 RVA: 0x0001101B File Offset: 0x0000F21B
	public float BarValue
	{
		get
		{
			return (1f - this.CooldownRemaining) * (1f - this.m_holdDownTime);
		}
	}

	// Token: 0x1700038E RID: 910
	// (get) Token: 0x06001367 RID: 4967 RVA: 0x00011036 File Offset: 0x0000F236
	public float CooldownRemaining
	{
		get
		{
			return this.m_cooldownRemaining;
		}
	}

	// Token: 0x1700038F RID: 911
	// (get) Token: 0x06001368 RID: 4968 RVA: 0x0001103E File Offset: 0x0000F23E
	public bool ShowFlameOnUI
	{
		get
		{
			return Mathf.Approximately(this.BarValue, 1f);
		}
	}

	// Token: 0x17000390 RID: 912
	// (get) Token: 0x06001369 RID: 4969 RVA: 0x00011050 File Offset: 0x0000F250
	public float SoulFlameCost
	{
		get
		{
			return (!this.m_sein.PlayerAbilities.SoulFlameEfficiency.HasAbility) ? 1f : 0.5f;
		}
	}

	// Token: 0x17000391 RID: 913
	// (get) Token: 0x0600136A RID: 4970 RVA: 0x0001107B File Offset: 0x0000F27B
	public bool CanAffordSoulFlame
	{
		get
		{
			return this.m_sein.Energy.CanAfford(this.SoulFlameCost);
		}
	}

	// Token: 0x17000392 RID: 914
	// (get) Token: 0x0600136B RID: 4971
	public bool AllowedToAccessSkillTree
	{
		get
		{
			return this.m_sein.Level.Current % 128 > 0 && this.IsSafeToCastSoulFlame == SeinSoulFlame.SoulFlamePlacementSafety.Safe;
		}
	}

	// Token: 0x17000393 RID: 915
	// (get) Token: 0x0600136C RID: 4972 RVA: 0x0006D7EC File Offset: 0x0006B9EC
	public bool PlayerCouldSoulFlame
	{
		get
		{
			return Characters.Sein.Controller.CanMove && !this.m_sein.Controller.IsSwimming && !UI.Fader.IsFadingInOrStay() && !SeinAbilityRestrictZone.IsInside(SeinAbilityRestrictZoneMode.AllAbilities) && !this.LockSoulFlame;
		}
	}

	// Token: 0x0600136D RID: 4973 RVA: 0x0006D848 File Offset: 0x0006BA48
	public void HandleNagging()
	{
		if (this.m_readyForReadySequence && this.PlayerCouldSoulFlame && this.IsSafeToCastSoulFlame == SeinSoulFlame.SoulFlamePlacementSafety.Safe && this.CanAffordSoulFlame)
		{
			this.m_readyForReadySequence = false;
			InstantiateUtility.Instantiate(this.SoulFlameReadyText, Characters.Ori.transform.position, Quaternion.identity);
			UI.SeinUI.OnSoulFlameReady();
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.SoulFlameReadyEffect);
			gameObject.transform.parent = Characters.Ori.transform;
			gameObject.transform.localPosition = Vector3.zero;
			Sound.Play(this.SoulFlameReadySoundProvider.GetSound(null), Characters.Sein.Position, null);
			this.m_nagTimer = this.NagDuration;
		}
		if (this.m_nagTimer > 0f)
		{
			this.m_nagTimer -= Time.deltaTime;
			if (this.m_nagTimer <= 0f)
			{
				if (this.PlayerCouldSoulFlame && this.CanAffordSoulFlame && this.IsSafeToCastSoulFlame == SeinSoulFlame.SoulFlamePlacementSafety.Safe)
				{
					this.m_nagTimer = 0f;
					InstantiateUtility.Instantiate(this.SoulFlameReadyText, Characters.Ori.transform.position, Quaternion.identity);
					UI.SeinUI.OnSoulFlameReady();
					Sound.Play(this.SoulFlameReadySoundProvider.GetSound(null), Characters.Sein.Position, null);
					this.m_nagTimer = this.NagDuration;
				}
				else
				{
					this.m_nagTimer = 2f;
				}
			}
		}
	}

	// Token: 0x0600136E RID: 4974 RVA: 0x000110B7 File Offset: 0x0000F2B7
	private void HandleDelayOnGround()
	{
		if (!this.m_sein.IsOnGround)
		{
			this.m_delayOnGround = 0.1f;
		}
		else
		{
			this.m_delayOnGround = Mathf.Max(0f, this.m_delayOnGround - Time.deltaTime);
		}
	}

	// Token: 0x0600136F RID: 4975 RVA: 0x0006D9D0 File Offset: 0x0006BBD0
	public override void UpdateCharacterState()
	{
		if (this.m_sein.Controller.IsBashing)
		{
			return;
		}
		this.HandleDelayOnGround();
		this.HandleCooldown();
		this.HandleCheckpointMarkerVisibility();
		this.HandleNagging();
		this.HandleSkillTreeHint();
		this.HandleCharging();
		if (this.m_sein.Energy.Max == 0f)
		{
			this.m_cooldownRemaining = 1f;
		}
		if (!UI.Fader.IsFadingInOrStay())
		{
			if (Core.Input.SoulFlame.OnPressed && !Core.Input.SoulFlame.Used && !Core.Input.Cancel.Used)
			{
				this.m_isCasting = true;
				if (this.InsideCheckpointMarker)
				{
					this.m_tapRemainingTime = 0.3f;
				}
				else if (!this.CanAffordSoulFlame)
				{
					this.HideOtherMessages();
					UI.SeinUI.ShakeEnergyOrbBar();
					this.m_sein.Energy.NotifyOutOfEnergy();
				}
				else if (this.m_cooldownRemaining != 0f)
				{
					this.HideOtherMessages();
					this.m_notReadyHint = UI.Hints.Show(this.NotReadyMessage, HintLayer.SoulFlame, 1f);
					Sound.Play(this.NotReadySound.GetSound(null), base.transform.position, null);
				}
				else if (this.IsSafeToCastSoulFlame != SeinSoulFlame.SoulFlamePlacementSafety.Safe)
				{
					this.HideOtherMessages();
					switch (this.IsSafeToCastSoulFlame)
					{
					case SeinSoulFlame.SoulFlamePlacementSafety.UnsafeEnemies:
						this.m_notSafeHint = UI.Hints.Show(this.NotSafeEnemiesMessage, HintLayer.SoulFlame, 1f);
						break;
					case SeinSoulFlame.SoulFlamePlacementSafety.UnsafeGround:
						this.m_notSafeHint = UI.Hints.Show(this.NotSafeGroundMessage, HintLayer.SoulFlame, 1f);
						break;
					case SeinSoulFlame.SoulFlamePlacementSafety.UnsafeZone:
						this.m_notSafeHint = UI.Hints.Show(this.NotSafeZoneMessage, HintLayer.SoulFlame, 1f);
						break;
					case SeinSoulFlame.SoulFlamePlacementSafety.SavePedestal:
						this.m_notSafeHint = UI.Hints.Show(this.SavePedestalZoneMessage, HintLayer.SoulFlame, 1f);
						break;
					}
					Sound.Play(this.NotSafeSound.GetSound(null), base.transform.position, null);
				}
			}
			if (this.m_isCasting && this.m_sein.IsOnGround && this.m_delayOnGround == 0f && this.m_tapRemainingTime > 0f)
			{
				this.m_tapRemainingTime -= Time.deltaTime;
				if (this.m_tapRemainingTime < 0f && this.InsideCheckpointMarker && Characters.Sein.PlayerAbilities.Rekindle.HasAbility && this.IsSafeToCastSoulFlame == SeinSoulFlame.SoulFlamePlacementSafety.Safe)
				{
					SeinSoulFlame.OnSoulFlameCast();
					Vector3 position = Characters.Sein.Position;
					Characters.Sein.Position = this.m_soulFlame.Position;
					SaveSlotBackupsManager.CreateCurrentBackup();
					GameController.Instance.CreateCheckpoint();
					Characters.Sein.Position = position;
					GameController.Instance.SaveGameController.PerformSave();
					this.m_soulFlame.OnRekindle();
					GameController.Instance.PerformSaveGameSequence();
				}
			}
			if (Core.Input.SoulFlame.Released)
			{
				this.m_isCasting = false;
				if (this.m_tapRemainingTime > 0f)
				{
					this.m_tapRemainingTime = 0f;
					if (this.AllowedToAccessSkillTree && this.InsideCheckpointMarker)
					{
						if (this.m_skillTreeHint)
						{
							this.m_skillTreeHint.Visibility.HideImmediately();
						}
						Core.Input.Start.Used = true;
						UI.Menu.ShowSkillTree();
					}
				}
			}
		}
		else
		{
			this.m_tapRemainingTime = 0f;
		}
		if (this.m_holdDownTime == 1f && this.m_sein.IsOnGround && this.m_delayOnGround == 0f)
		{
			this.CastSoulFlame();
		}
	}

	// Token: 0x06001370 RID: 4976 RVA: 0x0006DD94 File Offset: 0x0006BF94
	private void CastSoulFlame()
	{
		if (this.ChargingSound)
		{
			this.ChargingSound.StopAndFadeOut(0.1f);
		}
		this.m_sein.Energy.Spend(this.SoulFlameCost);
		this.m_cooldownRemaining = 1f;
		this.m_holdDownTime = 0f;
		if (this.m_sein.PlayerAbilities.Regroup.HasAbility)
		{
			this.m_sein.Mortality.Health.GainHealth(4);
		}
		if (this.m_sein.PlayerAbilities.UltraSoulFlame.HasAbility)
		{
			this.m_sein.Mortality.Health.GainHealth(4);
		}
		this.m_sceneCheckpoint = new MoonGuid(Scenes.Manager.CurrentScene.SceneMoonGuid);
		if (this.m_checkpointMarkerGameObject)
		{
			this.m_checkpointMarkerGameObject.GetComponent<SoulFlame>().Disappear();
		}
		this.SpawnSoulFlame(Characters.Sein.Position);
		SeinSoulFlame.OnSoulFlameCast();
		SaveSlotBackupsManager.CreateCurrentBackup();
		GameController.Instance.CreateCheckpoint();
		GameController.Instance.SaveGameController.PerformSave();
		this.m_numberOfSoulFlamesCast++;
		if (this.m_numberOfSoulFlamesCast == 50)
		{
			AchievementsController.AwardAchievement(AchievementsLogic.Instance.SoulLinkManyTimesAchievementAsset);
		}
		if (this.CheckpointSequence)
		{
			this.CheckpointSequence.Perform(null);
		}
	}

	// Token: 0x06001371 RID: 4977 RVA: 0x0006DF08 File Offset: 0x0006C108
	private void HandleCharging()
	{
		if (this.m_isCasting && this.CanAffordSoulFlame && this.IsSafeToCastSoulFlame == SeinSoulFlame.SoulFlamePlacementSafety.Safe && this.m_cooldownRemaining == 0f && !this.InsideCheckpointMarker && this.PlayerCouldSoulFlame)
		{
			if (this.m_holdDownTime == 0f && this.ChargingSound)
			{
				this.ChargingSound.Play();
			}
			this.m_holdDownTime += Time.deltaTime / this.HoldDownDuration;
			if (this.m_holdDownTime > 1f)
			{
				this.m_holdDownTime = 1f;
			}
			this.ChargeEffectAnimator.AnimatorDriver.ContinueForward();
		}
		else
		{
			this.ChargeEffectAnimator.AnimatorDriver.ContinueBackwards();
			if (this.ChargingSound && this.ChargingSound.IsPlaying)
			{
				this.ChargingSound.StopAndFadeOut(0.1f);
			}
			if (this.m_holdDownTime > 0f)
			{
				if (this.AbortChargingSound && !this.AbortChargingSound.IsPlaying)
				{
					this.AbortChargingSound.Play();
				}
				this.m_holdDownTime -= Time.deltaTime / this.HoldDownDuration;
				if (this.m_holdDownTime <= 0f)
				{
					this.m_holdDownTime = 0f;
					if (this.AbortChargingSound)
					{
						this.AbortChargingSound.StopAndFadeOut(0.1f);
					}
					if (this.FullyAbortedSound)
					{
						Sound.Play(this.FullyAbortedSound.GetSound(null), base.transform.position, null);
					}
				}
			}
		}
	}

	// Token: 0x06001372 RID: 4978 RVA: 0x0006E0D0 File Offset: 0x0006C2D0
	private void HandleCooldown()
	{
		if (this.m_cooldownRemaining > 0f)
		{
			this.m_nagTimer = 0f;
			if (this.m_sein.PlayerAbilities.Rekindle.HasAbility)
			{
				this.m_cooldownRemaining -= Time.deltaTime / this.RekindleCooldownDuration;
			}
			else
			{
				this.m_cooldownRemaining -= Time.deltaTime / this.CooldownDuration;
			}
			if (this.m_cooldownRemaining <= 0f)
			{
				this.m_cooldownRemaining = 0f;
				this.m_readyForReadySequence = true;
			}
		}
	}

	// Token: 0x06001373 RID: 4979 RVA: 0x0006E16C File Offset: 0x0006C36C
	private void HandleCheckpointMarkerVisibility()
	{
		if (this.m_checkpointMarkerGameObject)
		{
			bool flag = Scenes.Manager.SceneIsEnabled(this.m_sceneCheckpoint);
			bool flag2 = UI.Cameras.Current.IsOnScreenPadded(this.m_soulFlame.Position, 5f);
			if (this.m_checkpointMarkerGameObject.activeSelf)
			{
				if (!flag && !flag2)
				{
					this.m_checkpointMarkerGameObject.SetActive(false);
				}
			}
			else if (flag)
			{
				this.m_checkpointMarkerGameObject.SetActive(true);
			}
		}
	}

	// Token: 0x06001374 RID: 4980 RVA: 0x0006E1F4 File Offset: 0x0006C3F4
	private void HandleSkillTreeHint()
	{
		if (this.AllowedToAccessSkillTree)
		{
			if (this.InsideCheckpointMarker && this.SkillTreeMessage && this.SkillTreeRekindleMessage && this.PlayerCouldSoulFlame)
			{
				if (this.m_skillTreeHint == null)
				{
					MessageProvider messageProvider = (!Characters.Sein.PlayerAbilities.Rekindle.HasAbility || this.IsSafeToCastSoulFlame != SeinSoulFlame.SoulFlamePlacementSafety.Safe) ? this.SkillTreeMessage : this.SkillTreeRekindleMessage;
					this.m_skillTreeHint = UI.Hints.Show(messageProvider, HintLayer.SoulFlame, float.PositiveInfinity);
				}
			}
			else if (this.m_skillTreeHint)
			{
				this.m_skillTreeHint.HideMessageScreen();
			}
		}
	}

	// Token: 0x06001375 RID: 4981 RVA: 0x000110F5 File Offset: 0x0000F2F5
	public void HideOtherMessages()
	{
		if (this.m_notReadyHint)
		{
			this.m_notReadyHint.HideMessageScreen();
		}
		if (this.m_notSafeHint)
		{
			this.m_notSafeHint.HideMessageScreen();
		}
	}

	// Token: 0x06001376 RID: 4982 RVA: 0x0001112D File Offset: 0x0000F32D
	public void SetReferenceToSein(SeinCharacter sein)
	{
		this.m_sein = sein;
		this.m_sein.SoulFlame = this;
	}

	// Token: 0x06001377 RID: 4983 RVA: 0x0006E2BC File Offset: 0x0006C4BC
	public override void Serialize(Archive ar)
	{
		base.Serialize(ar);
		ar.Serialize(ref this.m_cooldownRemaining);
		ar.Serialize(ref this.m_readyForReadySequence);
		ar.Serialize(ref this.m_nagTimer);
		this.m_sceneCheckpoint.Serialize(ar);
		ar.Serialize(ref this.m_numberOfSoulFlamesCast);
		if (ar.Writing)
		{
			ar.Serialize(this.m_soulFlame != null);
			if (this.m_soulFlame)
			{
				ar.Serialize(this.m_soulFlame.Position);
			}
		}
		else
		{
			bool flag = false;
			ar.Serialize(ref flag);
			if (flag)
			{
				Vector3 zero = Vector3.zero;
				ar.Serialize(ref zero);
				if (this.m_soulFlame)
				{
					this.m_soulFlame.Position = zero;
				}
				else
				{
					this.SpawnSoulFlame(zero);
				}
			}
			else
			{
				this.DestroySoulFlame();
			}
		}
	}

	// Token: 0x06001378 RID: 4984 RVA: 0x00011142 File Offset: 0x0000F342
	public void SpawnSoulFlame(Vector3 position)
	{
		this.m_checkpointMarkerGameObject = (GameObject)InstantiateUtility.Instantiate(this.CheckpointMarker, position, Quaternion.identity);
		this.m_soulFlame = this.m_checkpointMarkerGameObject.GetComponent<SoulFlame>();
	}

	// Token: 0x06001379 RID: 4985 RVA: 0x00011171 File Offset: 0x0000F371
	public void DestroySoulFlame()
	{
		if (this.m_soulFlame)
		{
			InstantiateUtility.Destroy(this.m_soulFlame.gameObject);
			this.m_soulFlame = null;
			this.m_checkpointMarkerGameObject = null;
		}
	}

	// Token: 0x04001230 RID: 4656
	public BaseAnimator ChargeEffectAnimator;

	// Token: 0x04001231 RID: 4657
	public GameObject CheckpointMarker;

	// Token: 0x04001232 RID: 4658
	public ActionMethod CheckpointSequence;

	// Token: 0x04001233 RID: 4659
	public AnimationCurve ParticleRateOverSpeed;

	// Token: 0x04001234 RID: 4660
	public AchievementAsset CreateManySoulLinkAchievement;

	// Token: 0x04001235 RID: 4661
	public MessageProvider SkillTreeRekindleMessage;

	// Token: 0x04001236 RID: 4662
	public MessageProvider SkillTreeMessage;

	// Token: 0x04001237 RID: 4663
	public MessageProvider NotSafeZoneMessage;

	// Token: 0x04001238 RID: 4664
	public MessageProvider NotSafeEnemiesMessage;

	// Token: 0x04001239 RID: 4665
	public MessageProvider NotSafeGroundMessage;

	// Token: 0x0400123A RID: 4666
	public MessageProvider SavePedestalZoneMessage;

	// Token: 0x0400123B RID: 4667
	public MessageProvider NotReadyMessage;

	// Token: 0x0400123C RID: 4668
	public LayerMask UnsafeMask;

	// Token: 0x0400123D RID: 4669
	private MessageBox m_notSafeHint;

	// Token: 0x0400123E RID: 4670
	private MessageBox m_notReadyHint;

	// Token: 0x0400123F RID: 4671
	private MessageBox m_skillTreeHint;

	// Token: 0x04001240 RID: 4672
	private GameObject m_checkpointMarkerGameObject;

	// Token: 0x04001241 RID: 4673
	private SoulFlame m_soulFlame;

	// Token: 0x04001242 RID: 4674
	private SeinCharacter m_sein;

	// Token: 0x04001243 RID: 4675
	private int m_numberOfSoulFlamesCast;

	// Token: 0x04001244 RID: 4676
	private float m_holdDownTime;

	// Token: 0x04001245 RID: 4677
	public float HoldDownDuration = 0.7f;

	// Token: 0x04001246 RID: 4678
	private float m_nagTimer;

	// Token: 0x04001247 RID: 4679
	public float NagDuration = 120f;

	// Token: 0x04001248 RID: 4680
	public bool LockSoulFlame;

	// Token: 0x04001249 RID: 4681
	public SoundProvider NotSafeSound;

	// Token: 0x0400124A RID: 4682
	public SoundProvider NotReadySound;

	// Token: 0x0400124B RID: 4683
	public SoundSource ChargingSound;

	// Token: 0x0400124C RID: 4684
	public SoundSource AbortChargingSound;

	// Token: 0x0400124D RID: 4685
	public SoundProvider FullyAbortedSound;

	// Token: 0x0400124E RID: 4686
	public SoundProvider SoulFlameReadySoundProvider;

	// Token: 0x0400124F RID: 4687
	public GameObject SoulFlameReadyEffect;

	// Token: 0x04001250 RID: 4688
	public GameObject SoulFlameReadyText;

	// Token: 0x04001251 RID: 4689
	public float CooldownDuration = 60f;

	// Token: 0x04001252 RID: 4690
	public float RekindleCooldownDuration = 10f;

	// Token: 0x04001253 RID: 4691
	private float m_cooldownRemaining;

	// Token: 0x04001254 RID: 4692
	private bool m_readyForReadySequence;

	// Token: 0x04001255 RID: 4693
	private float m_tapRemainingTime;

	// Token: 0x04001256 RID: 4694
	private MoonGuid m_sceneCheckpoint = new MoonGuid(0, 0, 0, 0);

	// Token: 0x04001257 RID: 4695
	private bool m_isCasting;

	// Token: 0x04001258 RID: 4696
	private float m_delayOnGround;

	// Token: 0x02000362 RID: 866
	public enum SoulFlamePlacementSafety
	{
		// Token: 0x0400125C RID: 4700
		Safe,
		// Token: 0x0400125D RID: 4701
		UnsafeEnemies,
		// Token: 0x0400125E RID: 4702
		UnsafeGround,
		// Token: 0x0400125F RID: 4703
		UnsafeZone,
		// Token: 0x04001260 RID: 4704
		SavePedestal
	}
}
