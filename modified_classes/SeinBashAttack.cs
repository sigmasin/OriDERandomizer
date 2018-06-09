using System;
using System.Collections.Generic;
using Core;
using Game;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class SeinBashAttack : CharacterState, ISeinReceiver
{
	// Token: 0x06000F88 RID: 3976 RVA: 0x0005EA74 File Offset: 0x0005CC74
	public SeinBashAttack()
	{
	}

	// Token: 0x06000F89 RID: 3977 RVA: 0x0005EAEC File Offset: 0x0005CCEC
	static SeinBashAttack()
	{
		SeinBashAttack.OnBashAttackEvent = delegate(Vector2 A_0)
		{
		};
		SeinBashAttack.OnBashBegin = delegate()
		{
		};
		SeinBashAttack.OnBashEnemy = delegate(EntityTargetting A_0)
		{
		};
	}

	// Token: 0x1400000E RID: 14
	// (add) Token: 0x06000F8A RID: 3978 RVA: 0x0000DA13 File Offset: 0x0000BC13
	// (remove) Token: 0x06000F8B RID: 3979 RVA: 0x0000DA2A File Offset: 0x0000BC2A
	public static event Action<Vector2> OnBashAttackEvent;

	// Token: 0x1400000F RID: 15
	// (add) Token: 0x06000F8C RID: 3980 RVA: 0x0000DA41 File Offset: 0x0000BC41
	// (remove) Token: 0x06000F8D RID: 3981 RVA: 0x0000DA58 File Offset: 0x0000BC58
	public static event Action OnBashBegin;

	// Token: 0x14000010 RID: 16
	// (add) Token: 0x06000F8E RID: 3982 RVA: 0x0000DA6F File Offset: 0x0000BC6F
	// (remove) Token: 0x06000F8F RID: 3983 RVA: 0x0000DA86 File Offset: 0x0000BC86
	public static event Action<EntityTargetting> OnBashEnemy;

	// Token: 0x17000271 RID: 625
	// (get) Token: 0x06000F90 RID: 3984 RVA: 0x0000DA9D File Offset: 0x0000BC9D
	public Component TargetAsComponent
	{
		get
		{
			return this.Target as Component;
		}
	}

	// Token: 0x17000272 RID: 626
	// (get) Token: 0x06000F91 RID: 3985 RVA: 0x0000DAAA File Offset: 0x0000BCAA
	public CharacterAirNoDeceleration AirNoDeceleration
	{
		get
		{
			return this.Sein.PlatformBehaviour.AirNoDeceleration;
		}
	}

	// Token: 0x17000273 RID: 627
	// (get) Token: 0x06000F92 RID: 3986 RVA: 0x0000DABC File Offset: 0x0000BCBC
	public SeinDoubleJump DoubleJump
	{
		get
		{
			return this.Sein.Abilities.DoubleJump;
		}
	}

	// Token: 0x17000274 RID: 628
	// (get) Token: 0x06000F93 RID: 3987 RVA: 0x0000DACE File Offset: 0x0000BCCE
	public CharacterApplyFrictionToSpeed ApplyFrictionToSpeed
	{
		get
		{
			return this.Sein.PlatformBehaviour.ApplyFrictionToSpeed;
		}
	}

	// Token: 0x17000275 RID: 629
	// (get) Token: 0x06000F94 RID: 3988 RVA: 0x0000DAE0 File Offset: 0x0000BCE0
	public CharacterGravity Gravity
	{
		get
		{
			return this.Sein.PlatformBehaviour.Gravity;
		}
	}

	// Token: 0x17000276 RID: 630
	// (get) Token: 0x06000F95 RID: 3989 RVA: 0x0000DAF2 File Offset: 0x0000BCF2
	public CharacterLeftRightMovement CharacterLeftRightMovement
	{
		get
		{
			return this.Sein.PlatformBehaviour.LeftRightMovement;
		}
	}

	// Token: 0x17000277 RID: 631
	// (get) Token: 0x06000F96 RID: 3990 RVA: 0x0000DB04 File Offset: 0x0000BD04
	public PlayerAbilities PlayerAbilities
	{
		get
		{
			return this.Sein.PlayerAbilities;
		}
	}

	// Token: 0x17000278 RID: 632
	// (get) Token: 0x06000F97 RID: 3991 RVA: 0x0000DB11 File Offset: 0x0000BD11
	public PlatformMovement PlatformMovement
	{
		get
		{
			return this.Sein.PlatformBehaviour.PlatformMovement;
		}
	}

	// Token: 0x17000279 RID: 633
	// (get) Token: 0x06000F98 RID: 3992 RVA: 0x0000DB23 File Offset: 0x0000BD23
	public SeinController SeinController
	{
		get
		{
			return this.Sein.Controller;
		}
	}

	// Token: 0x1700027A RID: 634
	// (get) Token: 0x06000F99 RID: 3993 RVA: 0x0005EB60 File Offset: 0x0005CD60
	public TextureAnimationWithTransitions BashChargeAnimation
	{
		get
		{
			Vector2 v = this.m_directionToTarget;
			float num = Mathf.Cos(0.3926991f);
			SeinBashAttack.DirectionalAnimationSet directionalAnimationSet = (!this.Sein.Controller.IsSwimming) ? this.BashChargeAnimationSet : this.SwimBashChargeAnimationSet;
			v.x = Mathf.Abs(v.x);
			if (Vector3.Dot(Vector3.up, v) > num)
			{
				return directionalAnimationSet.Up;
			}
			Vector3 vector = new Vector3(1f, 1f);
			if (Vector3.Dot(vector.normalized, v) > num)
			{
				return directionalAnimationSet.UpDiagonal;
			}
			if (Vector3.Dot(Vector3.right, v) > num)
			{
				return directionalAnimationSet.Horizontal;
			}
			Vector3 vector2 = new Vector3(1f, -1f);
			if (Vector3.Dot(vector2.normalized, v) > num)
			{
				return directionalAnimationSet.DownDiagonal;
			}
			if (Vector3.Dot(Vector3.down, v) > num)
			{
				return directionalAnimationSet.Down;
			}
			return directionalAnimationSet.Up;
		}
	}

	// Token: 0x1700027B RID: 635
	// (get) Token: 0x06000F9A RID: 3994 RVA: 0x0005EC7C File Offset: 0x0005CE7C
	public TextureAnimationWithTransitions BashJumpAnimation
	{
		get
		{
			float angle = this.m_bashAngle + 90f;
			Vector2 v = MoonMath.Angle.VectorFromAngle(angle);
			float num = Mathf.Cos(0.3926991f);
			SeinBashAttack.DirectionalAnimationSet directionalAnimationSet = (!this.Sein.Controller.IsSwimming) ? this.BashJumpAnimationSet : this.SwimBashJumpAnimationSet;
			v.x = Mathf.Abs(v.x);
			if (Vector3.Dot(Vector3.up, v) > num)
			{
				return directionalAnimationSet.Up;
			}
			Vector3 vector = new Vector3(1f, 1f);
			if (Vector3.Dot(vector.normalized, v) > num)
			{
				return directionalAnimationSet.UpDiagonal;
			}
			if (Vector3.Dot(Vector3.right, v) > num)
			{
				return directionalAnimationSet.Horizontal;
			}
			Vector3 vector2 = new Vector3(1f, -1f);
			if (Vector3.Dot(vector2.normalized, v) > num)
			{
				return directionalAnimationSet.DownDiagonal;
			}
			if (Vector3.Dot(Vector3.down, v) > num)
			{
				return directionalAnimationSet.Down;
			}
			return directionalAnimationSet.Up;
		}
	}

	// Token: 0x1700027C RID: 636
	// (get) Token: 0x06000F9B RID: 3995 RVA: 0x0000DB30 File Offset: 0x0000BD30
	// (set) Token: 0x06000F9C RID: 3996 RVA: 0x0005EDA0 File Offset: 0x0005CFA0
	public bool SpriteMirrorLock
	{
		get
		{
			return this.m_spriteMirrorLock;
		}
		set
		{
			if (this.m_spriteMirrorLock != value)
			{
				this.m_spriteMirrorLock = value;
				if (value)
				{
					this.Sein.PlatformBehaviour.Visuals.SpriteMirror.Lock++;
				}
				else
				{
					this.Sein.PlatformBehaviour.Visuals.SpriteMirror.Lock--;
				}
			}
		}
	}

	// Token: 0x1700027D RID: 637
	// (get) Token: 0x06000F9D RID: 3997 RVA: 0x0005EE10 File Offset: 0x0005D010
	public bool CanBash
	{
		get
		{
			return this.PlayerAbilities.Bash.HasAbility && !(this.TargetAsComponent == null) && this.TargetAsComponent.gameObject.activeInHierarchy && (!(this.Sein != null) || this.Sein.Active) && !SeinAbilityRestrictZone.IsInside(SeinAbilityRestrictZoneMode.AllAbilities);
		}
	}

	// Token: 0x06000F9E RID: 3998 RVA: 0x0000DB38 File Offset: 0x0000BD38
	public void SetReferenceToSein(SeinCharacter sein)
	{
		this.Sein = sein;
		this.m_seinTransform = this.Sein.transform;
		this.Sein.Abilities.Bash = this;
	}

	// Token: 0x06000F9F RID: 3999 RVA: 0x0005EE90 File Offset: 0x0005D090
	public void Start()
	{
		this.m_hasStarted = true;
		Game.Checkpoint.Events.OnPostRestore.Add(new Action(this.OnRestoreCheckpoint));
		this.CharacterLeftRightMovement.ModifyHorizontalPlatformMovementSettingsEvent += this.ModifyHorizontalPlatformMovementSettings;
		this.Gravity.ModifyGravityPlatformMovementSettingsEvent += this.ModifyGravityPlatformMovementSettings;
	}

	// Token: 0x06000FA0 RID: 4000 RVA: 0x0005EEE8 File Offset: 0x0005D0E8
	public new void OnDestroy()
	{
		base.OnDestroy();
		if (this.m_hasStarted)
		{
			Game.Checkpoint.Events.OnPostRestore.Remove(new Action(this.OnRestoreCheckpoint));
			this.CharacterLeftRightMovement.ModifyHorizontalPlatformMovementSettingsEvent -= this.ModifyHorizontalPlatformMovementSettings;
			this.Gravity.ModifyGravityPlatformMovementSettingsEvent -= this.ModifyGravityPlatformMovementSettings;
		}
	}

	// Token: 0x06000FA1 RID: 4001 RVA: 0x0000DB63 File Offset: 0x0000BD63
	public void ModifyGravityPlatformMovementSettings(GravityPlatformMovementSettings settings)
	{
		if (this.IsBashing)
		{
			settings.GravityStrength = 0f;
		}
	}

	// Token: 0x06000FA2 RID: 4002 RVA: 0x0000DB7B File Offset: 0x0000BD7B
	public void ModifyHorizontalPlatformMovementSettings(HorizontalPlatformMovementSettings settings)
	{
		if (this.IsBashing)
		{
			settings.LockInput = true;
		}
	}

	// Token: 0x06000FA3 RID: 4003 RVA: 0x0000DB8F File Offset: 0x0000BD8F
	public void OnRestoreCheckpoint()
	{
		if (this.IsBashing)
		{
			this.ExitBash();
		}
		this.ApplyFrictionToSpeed.SpeedFactor = 0f;
		this.m_spriteMirrorLock = false;
	}

	// Token: 0x06000FA4 RID: 4004 RVA: 0x0000DBB9 File Offset: 0x0000BDB9
	public void OnDisable()
	{
		if (this.IsBashing)
		{
			this.ExitBash();
		}
	}

	// Token: 0x06000FA5 RID: 4005 RVA: 0x0000DBCC File Offset: 0x0000BDCC
	public void ExitBash()
	{
		if (GameController.Instance)
		{
			GameController.Instance.ResumeGameplay();
		}
		this.ApplyFrictionToSpeed.SpeedFactor = 0f;
		this.IsBashing = false;
	}

	// Token: 0x06000FA6 RID: 4006 RVA: 0x0005EF4C File Offset: 0x0005D14C
	public void MovePlayerToTargetAndCreateEffect()
	{
		Component component = this.Target as Component;
		Vector3 vector = (!InstantiateUtility.IsDestroyed(component)) ? component.transform.position : this.PlatformMovement.Position;
		GameObject gameObject = (GameObject)InstantiateUtility.Instantiate(this.BashFromFx);
		gameObject.transform.position = vector;
		Vector3 localScale = gameObject.transform.localScale;
		localScale.x = (vector - this.PlatformMovement.Position).magnitude;
		gameObject.transform.localScale = localScale;
		gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, MoonMath.Angle.AngleFromVector(this.PlatformMovement.Position - vector));
		if (!this.PlatformMovement.IsOnGround)
		{
			this.PlatformMovement.Position2D = vector;
		}
	}

	// Token: 0x06000FA7 RID: 4007 RVA: 0x0005F038 File Offset: 0x0005D238
	public void BeginBash()
	{
		this.m_timeRemainingOfBashButtonPress = 0f;
		this.IsBashing = true;
		this.Target.OnEnterBash();
		Transform transform = this.TargetAsComponent.transform;
		Sound.Play((!this.Sein.PlayerAbilities.BashBuff.HasAbility) ? this.BashStartSound.GetSound(null) : this.UpgradedBashStartSound.GetSound(null), this.m_seinTransform.position, null);
		if (GameController.Instance)
		{
			GameController.Instance.SuspendGameplay();
		}
		if (UI.Cameras.Current != null)
		{
			SuspensionManager.GetSuspendables(this.m_bashSuspendables, UI.Cameras.Current.GameObject);
			SuspensionManager.Resume(this.m_bashSuspendables);
			this.m_bashSuspendables.Clear();
		}
		this.PlatformMovement.LocalSpeed = Vector2.zero;
		GameObject gameObject = (GameObject)InstantiateUtility.Instantiate(this.BashAttackGamePrefab);
		this.m_bashAttackGame = gameObject.GetComponent<BashAttackGame>();
		this.m_bashAttackGame.SendDirection(transform.position - this.PlatformMovement.Position);
		this.m_bashAttackGame.BashGameComplete += this.BashGameComplete;
		this.m_bashAttackGame.transform.position = transform.position;
		Vector3 b = Vector3.ClampMagnitude(transform.position - this.PlatformMovement.Position, 2f);
		this.m_playerTargetPosition = transform.position - b;
		this.m_directionToTarget = b.normalized;
		SeinBashAttack.OnBashBegin();
		this.Sein.PlatformBehaviour.Visuals.Animation.PlayLoop(this.BashChargeAnimation, 10, new Func<bool>(this.ShouldBashChargeAnimationKeepPlaying), false);
	}

	// Token: 0x06000FA8 RID: 4008 RVA: 0x0000DBFE File Offset: 0x0000BDFE
	public void BashGameComplete(float angle)
	{
		this.JumpOffTarget(angle);
		this.AttackTarget();
		this.ExitBash();
	}

	// Token: 0x06000FA9 RID: 4009 RVA: 0x0005F208 File Offset: 0x0005D408
	public void JumpOffTarget(float angle)
	{
		if (GameController.Instance)
		{
			GameController.Instance.ResumeGameplay();
		}
		Vector2 vector = Quaternion.Euler(0f, 0f, angle) * Vector2.up;
		Vector2 vector2 = vector * this.BashVelocity;
		this.PlatformMovement.WorldSpeed = vector2;
		this.AirNoDeceleration.NoDeceleration = true;
		this.Sein.ResetAirLimits();
		this.m_frictionTimeRemaining = this.FrictionDuration;
		this.ApplyFrictionToSpeed.SpeedToSlowDown = this.PlatformMovement.LocalSpeed;
		this.MovePlayerToTargetAndCreateEffect();
		Component component = this.Target as Component;
		Vector3 position = (!InstantiateUtility.IsDestroyed(component)) ? component.transform.position : this.Sein.Position;
		GameObject gameObject = (GameObject)InstantiateUtility.Instantiate(this.BashOffFx);
		gameObject.transform.position = position;
		Vector3 localScale = gameObject.transform.localScale;
		localScale.x = vector2.magnitude * 0.1f;
		gameObject.transform.localScale = localScale;
		gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, MoonMath.Angle.AngleFromVector(vector));
		if (this.BashReleaseEffect)
		{
			GameObject gameObject2 = (GameObject)InstantiateUtility.Instantiate(this.BashReleaseEffect);
			gameObject2.transform.position = position;
		}
		SeinBashAttack.OnBashAttackEvent(vector2);
		this.m_timeRemainingTillNextBash = this.DelayTillNextBash;
		CharacterAnimationSystem.CharacterAnimationState characterAnimationState = this.Sein.PlatformBehaviour.Visuals.Animation.Play(this.BashJumpAnimation, 10, new Func<bool>(this.ShouldBashJumpAnimationKeepPlaying));
		characterAnimationState.OnStartPlaying = new Action(this.OnAnimationStart);
		characterAnimationState.OnStopPlaying = new Action(this.OnAnimationEnd);
		this.Sein.PlatformBehaviour.Visuals.SpriteMirror.FaceLeft = (vector2.x > 0f);
		if (this.Sein.Abilities.Swimming)
		{
			this.Sein.Abilities.Swimming.OnBash(angle);
		}
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x0000DC13 File Offset: 0x0000BE13
	public void OnAnimationStart()
	{
		this.SpriteMirrorLock = true;
	}

	// Token: 0x06000FAB RID: 4011 RVA: 0x0005F448 File Offset: 0x0005D648
	public void AttackTarget()
	{
		Component component = this.Target as Component;
		if (!InstantiateUtility.IsDestroyed(component))
		{
			Vector2 force = -MoonMath.Angle.VectorFromAngle(this.m_bashAngle + 90f) * 4f;
			Damage damage = new Damage((!this.Sein.PlayerAbilities.BashBuff.HasAbility) ? this.Damage : this.UpgradedDamage, force, Characters.Sein.Position, DamageType.Bash, base.gameObject);
			damage.DealToComponents(component.gameObject);
			EntityTargetting component2 = component.gameObject.GetComponent<EntityTargetting>();
			if (component2 && component2.Entity is Enemy)
			{
				SeinBashAttack.OnBashEnemy(component2);
			}
			if (this.Sein.PlayerAbilities.BashBuff.HasAbility)
			{
				this.BeginBashThroughEnemies();
			}
		}
	}

	// Token: 0x06000FAC RID: 4012 RVA: 0x0000DC1C File Offset: 0x0000BE1C
	private void BeginBashThroughEnemies()
	{
		this.m_bashThroughEnemiesRemainingTime = 0.5f;
		this.Sein.Mortality.DamageReciever.MakeInvincibleToEnemies(this.m_bashThroughEnemiesRemainingTime);
		this.m_enemiesBashedThrough.Clear();
	}

	// Token: 0x06000FAD RID: 4013 RVA: 0x0005F530 File Offset: 0x0005D730
	public void UpdateBashThroughEnemies()
	{
		if (this.m_bashThroughEnemiesRemainingTime > 0f)
		{
			this.m_bashThroughEnemiesRemainingTime -= Time.deltaTime;
			for (int i = 0; i < Targets.Attackables.Count; i++)
			{
				IAttackable attackable = Targets.Attackables[i];
				if (attackable.CanBeSpiritFlamed())
				{
					if (!this.m_enemiesBashedThrough.Contains(attackable))
					{
						Vector3 vector = attackable.Position - this.Sein.PlatformBehaviour.PlatformMovement.Position;
						float magnitude = vector.magnitude;
						if (magnitude < 3f && Vector2.Dot(vector.normalized, this.PlatformMovement.LocalSpeed.normalized) > 0f)
						{
							Damage damage = new Damage(this.UpgradedDamage, this.PlatformMovement.WorldSpeed.normalized, this.Sein.Position, DamageType.SpiritFlame, base.gameObject);
							GameObject gameObject = ((Component)attackable).gameObject;
							damage.DealToComponents(gameObject);
							this.m_enemiesBashedThrough.Add(attackable);
							break;
						}
					}
				}
			}
			if (this.m_bashThroughEnemiesRemainingTime <= 0f)
			{
				this.m_bashThroughEnemiesRemainingTime = 0f;
				this.FinishBashThroughEnemies();
			}
		}
	}

	// Token: 0x06000FAE RID: 4014 RVA: 0x0000DC4F File Offset: 0x0000BE4F
	private void FinishBashThroughEnemies()
	{
		this.m_enemiesBashedThrough.Clear();
	}

	// Token: 0x06000FAF RID: 4015 RVA: 0x0005F68C File Offset: 0x0005D88C
	public void UpdateBashingState()
	{
		this.HandleBashAngle();
		this.Sein.Mortality.DamageReciever.MakeInvincibleToEnemies(0.2f);
		this.HandleMovingTowardsBashTarget();
		this.Sein.PlatformBehaviour.Visuals.SpriteMirror.FaceLeft = (this.m_directionToTarget.x < 0f);
	}

	// Token: 0x06000FB0 RID: 4016 RVA: 0x0005F6EC File Offset: 0x0005D8EC
	public void BashFailed()
	{
		if (this.NoBashTargetEffect)
		{
			GameObject gameObject = (GameObject)InstantiateUtility.Instantiate(this.NoBashTargetEffect, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.m_seinTransform;
		}
	}

	// Token: 0x06000FB1 RID: 4017 RVA: 0x0005F73C File Offset: 0x0005D93C
	public void UpdateNormalState()
	{
		Randomizer.BashWasQueued = Randomizer.QueueBash;
		if (Core.Input.Bash.OnPressed || Randomizer.QueueBash)
		{
			Randomizer.QueueBash = false;
			this.m_timeRemainingOfBashButtonPress = 0.5f;
			if (this.Sein.IsOnGround && this.Sein.Speed.x == 0f && !SeinAbilityRestrictZone.IsInside(SeinAbilityRestrictZoneMode.AllAbilities) && !this.Sein.Abilities.Carry.IsCarrying)
			{
				this.Sein.Animation.Play(this.BackFlipAnimation, 10, null);
				this.Sein.PlatformBehaviour.PlatformMovement.LocalSpeedY = this.BackFlipSpeed;
				if ((!this.Sein.PlayerAbilities.BashBuff.HasAbility) ? this.StationaryBashSound : this.UpgradedStationaryBashSound)
				{
					Sound.Play((!this.Sein.PlayerAbilities.BashBuff.HasAbility) ? this.StationaryBashSound.GetSound(null) : this.UpgradedStationaryBashSound.GetSound(null), base.transform.position, null);
				}
			}
		}
		if (this.m_timeRemainingOfBashButtonPress > 0f)
		{
			this.m_timeRemainingOfBashButtonPress -= Time.deltaTime;
			if ((Core.Input.Bash.OnReleased || ((double)this.m_timeRemainingOfBashButtonPress <= 0.4 && (double)this.m_timeRemainingOfBashButtonPress >= 0.4 - (double)Time.deltaTime)) && !SeinAbilityRestrictZone.IsInside(SeinAbilityRestrictZoneMode.AllAbilities) && !this.Sein.Abilities.Carry.IsCarrying)
			{
				this.BashFailed();
			}
			if (Core.Input.Bash.Released || this.m_timeRemainingOfBashButtonPress <= 0f)
			{
				this.m_timeRemainingOfBashButtonPress = 0f;
			}
		}
		if ((this.m_timeRemainingOfBashButtonPress > 0f || Randomizer.BashWasQueued) && this.CanBash)
		{
			this.BeginBash();
		}
		this.HandleFindingTarget();
		this.UpdateTargetHighlight(this.Target);
	}

	// Token: 0x06000FB2 RID: 4018 RVA: 0x0005F944 File Offset: 0x0005DB44
	public override void UpdateCharacterState()
	{
		if (this.Sein.IsSuspended)
		{
			return;
		}
		if (!this.Sein.PlayerAbilities.Bash.HasAbility)
		{
			return;
		}
		if (!this.Sein.Active)
		{
			this.ExitBash();
			return;
		}
		if (this.m_timeRemainingTillNextBash > 0f)
		{
			this.m_timeRemainingTillNextBash -= Time.deltaTime;
		}
		this.UpdateBashThroughEnemies();
		if (this.m_frictionTimeRemaining > 0f)
		{
			this.m_frictionTimeRemaining -= Time.deltaTime;
			float time = this.FrictionDuration - this.m_frictionTimeRemaining;
			this.ApplyFrictionToSpeed.SpeedFactor = this.FrictionCurve.Evaluate(time);
		}
		if (this.m_frictionTimeRemaining + this.NoAirDecelerationDuration - this.FrictionDuration > 0f)
		{
			this.AirNoDeceleration.NoDeceleration = true;
		}
		if (this.IsBashing)
		{
			this.UpdateBashingState();
		}
		else
		{
			this.UpdateNormalState();
		}
	}

	// Token: 0x06000FB3 RID: 4019 RVA: 0x0005FA4C File Offset: 0x0005DC4C
	public void HandleMovingTowardsBashTarget()
	{
		Vector3 a = this.m_playerTargetPosition - this.PlatformMovement.Position;
		this.PlatformMovement.WorldSpeed = a / Time.deltaTime * 0.1f;
	}

	// Token: 0x06000FB4 RID: 4020 RVA: 0x0000DC5C File Offset: 0x0000BE5C
	private void HandleBashAngle()
	{
		if (!InstantiateUtility.IsDestroyed(this.m_bashAttackGame))
		{
			this.m_bashAngle = this.m_bashAttackGame.Angle;
		}
	}

	// Token: 0x06000FB5 RID: 4021 RVA: 0x0005FA98 File Offset: 0x0005DC98
	private void HandleFindingTarget()
	{
		if (this.Sein.Controller.IsCarrying)
		{
			this.Target = null;
		}
		else if (this.m_timeRemainingTillNextBash > 0f)
		{
			this.Target = null;
		}
		else if (this.PlayerAbilities.Bash.HasAbility)
		{
			this.Target = this.FindClosestAttackHandler();
		}
		else
		{
			this.Target = null;
		}
	}

	// Token: 0x06000FB6 RID: 4022 RVA: 0x0005FB10 File Offset: 0x0005DD10
	private void UpdateTargetHighlight(IBashAttackable target)
	{
		if (this.m_lastTarget == target)
		{
			return;
		}
		if (!InstantiateUtility.IsDestroyed(this.m_lastTarget as Component))
		{
			this.m_lastTarget.OnBashDehighlight();
		}
		this.m_lastTarget = target;
		if (!InstantiateUtility.IsDestroyed(this.m_lastTarget as Component))
		{
			this.m_lastTarget.OnBashHighlight();
		}
	}

	// Token: 0x06000FB7 RID: 4023 RVA: 0x0005FB74 File Offset: 0x0005DD74
	private IBashAttackable FindClosestAttackHandler()
	{
		IBashAttackable result = null;
		float num = float.MaxValue;
		int num2 = int.MinValue;
		Vector3 position = this.Sein.Position;
		for (int i = 0; i < Targets.Attackables.Count; i++)
		{
			IAttackable attackable = Targets.Attackables[i];
			if (attackable.CanBeBashed())
			{
				float magnitude = (attackable.Position - position).magnitude;
				if (magnitude <= this.Range)
				{
					IBashAttackable bashAttackable = attackable as IBashAttackable;
					if (bashAttackable != null)
					{
						int bashPriority = bashAttackable.BashPriority;
						if (bashPriority > num2 || (magnitude <= num && bashPriority == num2))
						{
							if (this.Sein.Controller.RayTest(((Component)bashAttackable).gameObject))
							{
								num = magnitude;
								num2 = bashPriority;
								result = bashAttackable;
							}
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000FB8 RID: 4024 RVA: 0x0000DC7F File Offset: 0x0000BE7F
	private bool ShouldBashChargeAnimationKeepPlaying()
	{
		return this.IsBashing;
	}

	// Token: 0x06000FB9 RID: 4025 RVA: 0x0000DC87 File Offset: 0x0000BE87
	private bool ShouldBashJumpAnimationKeepPlaying()
	{
		return !this.PlatformMovement.IsOnGround;
	}

	// Token: 0x06000FBA RID: 4026 RVA: 0x0000DC97 File Offset: 0x0000BE97
	private void OnAnimationEnd()
	{
		this.SpriteMirrorLock = false;
	}

	// Token: 0x06000FBB RID: 4027 RVA: 0x0005FC6C File Offset: 0x0005DE6C
	public override void Serialize(Archive ar)
	{
		ar.Serialize(ref this.m_timeRemainingOfBashButtonPress);
		ar.Serialize(ref this.m_frictionTimeRemaining);
		ar.Serialize(ref this.m_timeRemainingTillNextBash);
		ar.Serialize(ref this.m_spriteMirrorLock);
		base.Serialize(ar);
		if (ar.Reading && !InstantiateUtility.IsDestroyed(this.m_bashAttackGame))
		{
			InstantiateUtility.Destroy(this.m_bashAttackGame.gameObject);
		}
	}

	// Token: 0x04000EE7 RID: 3815
	public SeinBashAttack.DirectionalAnimationSet BashChargeAnimationSet;

	// Token: 0x04000EE8 RID: 3816
	public SeinBashAttack.DirectionalAnimationSet BashJumpAnimationSet;

	// Token: 0x04000EE9 RID: 3817
	public SeinBashAttack.DirectionalAnimationSet SwimBashChargeAnimationSet;

	// Token: 0x04000EEA RID: 3818
	public SeinBashAttack.DirectionalAnimationSet SwimBashJumpAnimationSet;

	// Token: 0x04000EEB RID: 3819
	public TextureAnimationWithTransitions BackFlipAnimation;

	// Token: 0x04000EEC RID: 3820
	public GameObject BashAttackGamePrefab;

	// Token: 0x04000EED RID: 3821
	public SoundProvider BashEndSound;

	// Token: 0x04000EEE RID: 3822
	public SoundProvider BashLoopSound;

	// Token: 0x04000EEF RID: 3823
	public SoundProvider BashStartSound;

	// Token: 0x04000EF0 RID: 3824
	public SoundProvider StationaryBashSound;

	// Token: 0x04000EF1 RID: 3825
	public SoundProvider UpgradedBashEndSound;

	// Token: 0x04000EF2 RID: 3826
	public SoundProvider UpgradedBashLoopSound;

	// Token: 0x04000EF3 RID: 3827
	public SoundProvider UpgradedBashStartSound;

	// Token: 0x04000EF4 RID: 3828
	public SoundProvider UpgradedStationaryBashSound;

	// Token: 0x04000EF5 RID: 3829
	public GameObject BashFromFx;

	// Token: 0x04000EF6 RID: 3830
	public GameObject BashOffFx;

	// Token: 0x04000EF7 RID: 3831
	public GameObject BashReleaseEffect;

	// Token: 0x04000EF8 RID: 3832
	public float BashVelocity = 56.568f;

	// Token: 0x04000EF9 RID: 3833
	public float Damage = 2f;

	// Token: 0x04000EFA RID: 3834
	public float UpgradedDamage = 5f;

	// Token: 0x04000EFB RID: 3835
	public float DelayTillNextBash = 0.2f;

	// Token: 0x04000EFC RID: 3836
	public AnimationCurve FrictionCurve;

	// Token: 0x04000EFD RID: 3837
	public float FrictionDuration;

	// Token: 0x04000EFE RID: 3838
	public float NoAirDecelerationDuration = 0.2f;

	// Token: 0x04000EFF RID: 3839
	public float Range = 4f;

	// Token: 0x04000F00 RID: 3840
	public SeinCharacter Sein;

	// Token: 0x04000F01 RID: 3841
	public IBashAttackable Target;

	// Token: 0x04000F02 RID: 3842
	private Vector3 m_directionToTarget;

	// Token: 0x04000F03 RID: 3843
	private float m_bashAngle;

	// Token: 0x04000F04 RID: 3844
	private Vector3 m_playerTargetPosition;

	// Token: 0x04000F05 RID: 3845
	private BashAttackGame m_bashAttackGame;

	// Token: 0x04000F06 RID: 3846
	private float m_frictionTimeRemaining;

	// Token: 0x04000F07 RID: 3847
	private IBashAttackable m_lastTarget;

	// Token: 0x04000F08 RID: 3848
	private Transform m_seinTransform;

	// Token: 0x04000F09 RID: 3849
	private bool m_spriteMirrorLock;

	// Token: 0x04000F0A RID: 3850
	private float m_timeRemainingTillNextBash;

	// Token: 0x04000F0B RID: 3851
	private float m_timeRemainingOfBashButtonPress;

	// Token: 0x04000F0C RID: 3852
	private readonly HashSet<ISuspendable> m_bashSuspendables = new HashSet<ISuspendable>();

	// Token: 0x04000F0D RID: 3853
	public GameObject NoBashTargetEffect;

	// Token: 0x04000F0E RID: 3854
	public bool IsBashing;

	// Token: 0x04000F0F RID: 3855
	private float m_bashThroughEnemiesRemainingTime;

	// Token: 0x04000F10 RID: 3856
	private HashSet<IAttackable> m_enemiesBashedThrough = new HashSet<IAttackable>();

	// Token: 0x04000F11 RID: 3857
	private bool m_hasStarted;

	// Token: 0x04000F12 RID: 3858
	public float BackFlipSpeed = 5f;

	// Token: 0x0200030A RID: 778
	[Serializable]
	public class DirectionalAnimationSet
	{
		// Token: 0x06000FBF RID: 4031 RVA: 0x000024FF File Offset: 0x000006FF
		public DirectionalAnimationSet()
		{
		}

		// Token: 0x04000F19 RID: 3865
		public TextureAnimationWithTransitions Down;

		// Token: 0x04000F1A RID: 3866
		public TextureAnimationWithTransitions DownDiagonal;

		// Token: 0x04000F1B RID: 3867
		public TextureAnimationWithTransitions Horizontal;

		// Token: 0x04000F1C RID: 3868
		public TextureAnimationWithTransitions Up;

		// Token: 0x04000F1D RID: 3869
		public TextureAnimationWithTransitions UpDiagonal;
	}
}
