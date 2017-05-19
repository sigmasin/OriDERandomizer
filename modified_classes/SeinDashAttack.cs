using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Core;
using Game;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class SeinDashAttack : CharacterState, ISeinReceiver
{
	// Token: 0x06001051 RID: 4177 RVA: 0x00061A6C File Offset: 0x0005FC6C
	static SeinDashAttack()
	{
		SeinDashAttack.OnDashEvent = delegate
		{
		};
		SeinDashAttack.OnWallDashEvent = delegate
		{
		};
	}

	// Token: 0x14000012 RID: 18
	// (add) Token: 0x06001052 RID: 4178 RVA: 0x0000E404 File Offset: 0x0000C604
	// (remove) Token: 0x06001053 RID: 4179 RVA: 0x0000E41B File Offset: 0x0000C61B
	public static event Action OnDashEvent
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			SeinDashAttack.OnDashEvent = (Action)Delegate.Combine(SeinDashAttack.OnDashEvent, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			SeinDashAttack.OnDashEvent = (Action)Delegate.Remove(SeinDashAttack.OnDashEvent, value);
		}
	}

	// Token: 0x14000013 RID: 19
	// (add) Token: 0x06001054 RID: 4180 RVA: 0x0000E432 File Offset: 0x0000C632
	// (remove) Token: 0x06001055 RID: 4181 RVA: 0x0000E449 File Offset: 0x0000C649
	public static event Action OnWallDashEvent
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			SeinDashAttack.OnWallDashEvent = (Action)Delegate.Combine(SeinDashAttack.OnWallDashEvent, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			SeinDashAttack.OnWallDashEvent = (Action)Delegate.Remove(SeinDashAttack.OnWallDashEvent, value);
		}
	}

	// Token: 0x170002A9 RID: 681
	// (get) Token: 0x06001056 RID: 4182
	public bool HasEnoughEnergy
	{
		get
		{
			float reduction = RandomizerBonus.ChargeDashEfficiency() ? 0.5f : 0f;
			return this.m_sein.Energy.CanAfford(this.EnergyCost - reduction);
		}
	}

	// Token: 0x06001057 RID: 4183 RVA: 0x0000E478 File Offset: 0x0000C678
	public override void Serialize(Archive ar)
	{
		if (ar.Reading)
		{
			this.ReturnToNormal();
		}
	}

	// Token: 0x06001058 RID: 4184 RVA: 0x0000E48B File Offset: 0x0000C68B
	public override void OnExit()
	{
		this.ReturnToNormal();
		base.OnExit();
	}

	// Token: 0x06001059 RID: 4185 RVA: 0x0000E499 File Offset: 0x0000C699
	public void OnDisable()
	{
		this.Exit();
	}

	// Token: 0x0600105A RID: 4186 RVA: 0x00061AC4 File Offset: 0x0005FCC4
	public void ReturnToNormal()
	{
		if (this.CurrentState != SeinDashAttack.State.Normal)
		{
			if (this.CurrentState == SeinDashAttack.State.Dashing)
			{
				this.m_sein.PlatformBehaviour.PlatformMovement.LocalSpeedX = (float)((!this.m_faceLeft) ? 1 : -1) * this.DashSpeedOverTime.Evaluate((float)this.DashSpeedOverTime.length);
			}
			if (this.CurrentState == SeinDashAttack.State.ChargeDashing)
			{
				this.m_sein.PlatformBehaviour.PlatformMovement.LocalSpeedX = (float)((!this.m_faceLeft) ? 1 : -1) * this.ChargeDashSpeedOverTime.Evaluate((float)this.ChargeDashSpeedOverTime.length);
			}
			UI.Cameras.Current.ChaseTarget.CameraSpeedMultiplier.x = 1f;
			if (this.CurrentState == SeinDashAttack.State.ChargeDashing)
			{
				this.RestoreEnergy();
			}
			this.ChangeState(SeinDashAttack.State.Normal);
		}
	}

	// Token: 0x0600105B RID: 4187
	public void SpendEnergy()
	{
		float reduction = RandomizerBonus.ChargeDashEfficiency() ? 0.5f : 0f;
		this.m_sein.Energy.Spend(this.EnergyCost - reduction);
	}

	// Token: 0x0600105C RID: 4188
	public void RestoreEnergy()
	{
		float reduction = RandomizerBonus.ChargeDashEfficiency() ? 0.5f : 0f;
		this.m_sein.Energy.Gain(this.EnergyCost - reduction);
	}

	// Token: 0x0600105D RID: 4189 RVA: 0x0000E4D1 File Offset: 0x0000C6D1
	public void SetReferenceToSein(SeinCharacter sein)
	{
		this.m_sein = sein;
		sein.Abilities.Dash = this;
	}

	// Token: 0x0600105E RID: 4190 RVA: 0x0000E4E6 File Offset: 0x0000C6E6
	public override void UpdateCharacterState()
	{
		this.UpdateState();
	}

	// Token: 0x170002AA RID: 682
	// (get) Token: 0x0600105F RID: 4191 RVA: 0x0000E4EE File Offset: 0x0000C6EE
	public bool IsDashingOrChangeDashing
	{
		get
		{
			if (this.CurrentState == SeinDashAttack.State.Dashing)
			{
				return this.m_stateCurrentTime < this.DashTime;
			}
			return this.CurrentState == SeinDashAttack.State.ChargeDashing && this.m_stateCurrentTime < this.ChargeDashTime;
		}
	}

	// Token: 0x06001060 RID: 4192 RVA: 0x0000E527 File Offset: 0x0000C727
	public void ChangeState(SeinDashAttack.State state)
	{
		this.CurrentState = state;
		this.m_stateCurrentTime = 0f;
		this.m_attackablesIgnore.Clear();
	}

	// Token: 0x170002AB RID: 683
	// (get) Token: 0x06001061 RID: 4193 RVA: 0x00061BA8 File Offset: 0x0005FDA8
	public IChargeDashAttackable FindClosestAttackable
	{
		get
		{
			IChargeDashAttackable result = null;
			float num = 3.40282347E+38f;
			foreach (IAttackable current in Targets.Attackables)
			{
				if (current as Component && current.CanBeChargeDashed() && current is IChargeDashAttackable)
				{
					IChargeDashAttackable chargeDashAttackable = (IChargeDashAttackable)current;
					if (UI.Cameras.Current.IsOnScreen(current.Position))
					{
						float magnitude = (current.Position - this.m_sein.Position).magnitude;
						if (magnitude < num && magnitude < this.ChargeDashTargetMaxDistance)
						{
							result = chargeDashAttackable;
							num = magnitude;
						}
					}
				}
			}
			return result;
		}
	}

	// Token: 0x06001062 RID: 4194 RVA: 0x00061C88 File Offset: 0x0005FE88
	public void AttackNearbyEnemies()
	{
		for (int i = 0; i < Targets.Attackables.Count; i++)
		{
			IAttackable attackable = Targets.Attackables[i];
			if (!InstantiateUtility.IsDestroyed(attackable as Component))
			{
				if (!this.m_attackablesIgnore.Contains(attackable))
				{
					if (attackable.CanBeChargeFlamed())
					{
						float magnitude = (attackable.Position - this.m_sein.PlatformBehaviour.PlatformMovement.HeadPosition).magnitude;
						if (magnitude <= 3f)
						{
							this.m_attackablesIgnore.Add(attackable);
							Vector3 v = (!this.m_chargeDashAtTarget) ? (((!this.m_faceLeft) ? Vector3.right : Vector3.left) * 3f) : (this.m_chargeDashDirection * 3f);
							Damage damage = new Damage((float)this.Damage, v, this.m_sein.Position, DamageType.ChargeFlame, base.gameObject);
							damage.DealToComponents(((Component)attackable).gameObject);
							this.m_hasHitAttackable = true;
							if (this.ExplosionEffect && Time.time - this.m_timeOfLastExplosionEffect > 0.1f)
							{
								this.m_timeOfLastExplosionEffect = Time.time;
								InstantiateUtility.Instantiate(this.ExplosionEffect, Vector3.Lerp(base.transform.position, attackable.Position, 0.5f), Quaternion.identity);
							}
							break;
						}
					}
				}
			}
		}
	}

	// Token: 0x06001063 RID: 4195
	private void PerformDash(TextureAnimationWithTransitions dashAnimation, SoundProvider dashSound)
	{
		this.m_sein.Mortality.DamageReciever.ResetInviciblity();
		this.m_hasDashed = true;
		if (RandomizerBonus.DoubleAirDash() && !RandomizerBonus.DoubleAirDashUsed)
		{
			this.m_hasDashed = false;
			RandomizerBonus.DoubleAirDashUsed = true;
		}
		this.m_isOnGround = this.m_sein.IsOnGround;
		this.m_lastDashTime = Time.time;
		this.m_lastPressTime = 0f;
		this.SpriteRotation = this.m_sein.PlatformBehaviour.PlatformMovement.GroundAngle;
		this.m_allowNoDecelerationForThisDash = true;
		if (this.m_chargeDashAtTarget)
		{
			this.m_faceLeft = (this.m_chargeDashDirection.x < 0f);
		}
		else if (this.m_sein.PlatformBehaviour.PlatformMovement.HasWallLeft)
		{
			this.m_faceLeft = false;
		}
		else if (this.m_sein.PlatformBehaviour.PlatformMovement.HasWallRight)
		{
			this.m_faceLeft = true;
		}
		else if (this.m_sein.Input.NormalizedHorizontal != 0)
		{
			this.m_faceLeft = (this.m_sein.Input.NormalizedHorizontal < 0);
		}
		else if (!Mathf.Approximately(this.m_sein.Speed.x, 0f))
		{
			this.m_faceLeft = (this.m_sein.Speed.x < 0f);
		}
		else
		{
			this.m_faceLeft = this.m_sein.FaceLeft;
			this.m_allowNoDecelerationForThisDash = false;
		}
		this.m_sein.FaceLeft = this.m_faceLeft;
		this.m_stopAnimation = false;
		if (dashSound)
		{
			Sound.Play(dashSound.GetSound(null), this.m_sein.Position, null);
		}
		this.m_sein.Animation.Play(dashAnimation, 154, new Func<bool>(this.KeepDashAnimationPlaying));
		if (SeinDashAttack.RainbowDashActivated)
		{
			((GameObject)InstantiateUtility.Instantiate(this.DashFollowRainbowEffect, this.m_sein.Position, Quaternion.identity)).transform.parent = this.m_sein.Transform;
		}
		this.m_sein.PlatformBehaviour.PlatformMovement.LocalSpeedY = -this.DashDownwardSpeed;
	}

	// Token: 0x06001064 RID: 4196 RVA: 0x0006205C File Offset: 0x0006025C
	public void PerformDash()
	{
		this.m_chargeDashAtTarget = false;
		SoundProvider dashSound = (!SeinDashAttack.RainbowDashActivated) ? this.DashSound : this.RainbowDashSound;
		bool isGliding = this.m_sein.Controller.IsGliding;
		this.PerformDash((!isGliding) ? this.DashAnimation : this.GlideDashAnimation, dashSound);
		this.ChangeState(SeinDashAttack.State.Dashing);
		this.UpdateDashing();
		SeinDashAttack.OnDashEvent();
	}

	// Token: 0x06001065 RID: 4197 RVA: 0x000620D4 File Offset: 0x000602D4
	public void PerformWallDash()
	{
		this.m_chargeDashAtTarget = false;
		SoundProvider dashSound = (!SeinDashAttack.RainbowDashActivated) ? this.DashSound : this.RainbowDashSound;
		this.PerformDash(this.DashAnimation, dashSound);
		this.ChangeState(SeinDashAttack.State.Dashing);
		this.UpdateDashing();
		SeinDashAttack.OnWallDashEvent();
	}

	// Token: 0x06001066 RID: 4198 RVA: 0x00062128 File Offset: 0x00060328
	public void PerformDashIntoWall()
	{
		this.m_lastPressTime = 0f;
		this.m_lastDashTime = Time.time;
		this.m_sein.Animation.Play(this.DashIntoWallAnimation, 154, new Func<bool>(this.KeepDashIntoWallAnimationPlaying));
		Sound.Play(this.DashIntoWallSound.GetSound(null), this.m_sein.Position, null);
	}

	// Token: 0x06001067 RID: 4199 RVA: 0x0000E546 File Offset: 0x0000C746
	public bool KeepDashIntoWallAnimationPlaying()
	{
		return this.AgainstWall() && this.m_sein.IsOnGround;
	}

	// Token: 0x06001068 RID: 4200 RVA: 0x00062194 File Offset: 0x00060394
	public void PerformChargeDash()
	{
		this.m_hasHitAttackable = false;
		this.m_chargeJumpWasReleased = false;
		this.m_chargeDashAttackTarget = (this.FindClosestAttackable as IAttackable);
		if (this.m_chargeDashAttackTarget != null)
		{
			this.m_chargeDashAtTarget = true;
			this.m_chargeDashDirection = (this.m_chargeDashAttackTarget.Position - this.m_sein.Position).normalized;
			this.m_chargeDashAtTargetPosition = this.m_chargeDashAttackTarget.Position;
		}
		else
		{
			this.m_chargeDashAtTarget = false;
		}
		SoundProvider dashSound = (!SeinDashAttack.RainbowDashActivated) ? this.ChargeDashSound : this.RainbowDashSound;
		this.PerformDash(this.ChargeDashAnimation, dashSound);
		if (this.m_chargeDashAtTarget)
		{
			this.SpriteRotation = Mathf.Atan2(this.m_chargeDashDirection.y, this.m_chargeDashDirection.x) * 57.29578f - (float)((!this.m_faceLeft) ? 0 : 180);
		}
		this.ChangeState(SeinDashAttack.State.ChargeDashing);
		this.CompleteChargeEffect();
		this.UpdateChargeDashing();
	}

	// Token: 0x06001069 RID: 4201 RVA: 0x0000E561 File Offset: 0x0000C761
	private bool HasChargeDashSkill()
	{
		return this.m_sein.PlayerAbilities.ChargeDash.HasAbility;
	}

	// Token: 0x0600106A RID: 4202 RVA: 0x0000E578 File Offset: 0x0000C778
	private bool HasAirDashSkill()
	{
		return this.m_sein.PlayerAbilities.AirDash.HasAbility;
	}

	// Token: 0x0600106B RID: 4203 RVA: 0x0000E58F File Offset: 0x0000C78F
	private bool CanChargeDash()
	{
		return this.HasChargeDashSkill() && Core.Input.ChargeJump.Pressed && this.m_chargeJumpWasReleased;
	}

	// Token: 0x0600106C RID: 4204 RVA: 0x0000E5B4 File Offset: 0x0000C7B4
	public void CompleteChargeEffect()
	{
		if (this.m_sein.Abilities.ChargeJumpCharging)
		{
			this.m_sein.Abilities.ChargeJumpCharging.EndCharge();
		}
	}

	// Token: 0x0600106D RID: 4205 RVA: 0x000622A0 File Offset: 0x000604A0
	private void UpdateTargetHighlight(IChargeDashAttackable target)
	{
		if (this.m_lastTarget == target)
		{
			return;
		}
		if (!InstantiateUtility.IsDestroyed(this.m_lastTarget as Component))
		{
			this.m_lastTarget.OnChargeDashDehighlight();
		}
		this.m_lastTarget = target;
		if (!InstantiateUtility.IsDestroyed(this.m_lastTarget as Component))
		{
			this.m_lastTarget.OnChargeDashHighlight();
		}
	}

	// Token: 0x0600106E RID: 4206 RVA: 0x0000E5E5 File Offset: 0x0000C7E5
	public bool KeepDashAnimationPlaying()
	{
		return !this.m_stopAnimation && !this.m_sein.Abilities.WallSlide.IsOnWall && base.Active;
	}

	// Token: 0x0600106F RID: 4207 RVA: 0x0000E615 File Offset: 0x0000C815
	public bool KeepChargeDashAnimationPlaying()
	{
		return this.KeepDashAnimationPlaying();
	}

	// Token: 0x06001070 RID: 4208 RVA: 0x00062304 File Offset: 0x00060504
	public bool AgainstWall()
	{
		PlatformMovement platformMovement = this.m_sein.PlatformBehaviour.PlatformMovement;
		return (platformMovement.HasWallLeft && this.m_sein.FaceLeft) || (platformMovement.HasWallRight && !this.m_sein.FaceLeft);
	}

	// Token: 0x06001071 RID: 4209 RVA: 0x00062360 File Offset: 0x00060560
	public bool CanPerformNormalDash()
	{
		return (this.HasAirDashSkill() || this.m_sein.IsOnGround) && (!this.AgainstWall() && this.DashHasCooledDown) && !this.m_hasDashed;
	}

	// Token: 0x170002AC RID: 684
	// (get) Token: 0x06001072 RID: 4210 RVA: 0x0000E61D File Offset: 0x0000C81D
	private bool DashHasCooledDown
	{
		get
		{
			return Time.time - this.m_lastDashTime > 0.4f;
		}
	}

	// Token: 0x06001073 RID: 4211 RVA: 0x0000E632 File Offset: 0x0000C832
	public bool CanPerformDashIntoWall()
	{
		return this.m_sein.IsOnGround && this.AgainstWall() && this.DashHasCooledDown;
	}

	// Token: 0x06001074 RID: 4212 RVA: 0x000623AC File Offset: 0x000605AC
	public bool CanWallDash()
	{
		PlatformMovement platformMovement = this.m_sein.PlatformBehaviour.PlatformMovement;
		bool flag = (platformMovement.HasWallLeft && this.m_sein.Input.Horizontal >= 0f) || (platformMovement.HasWallRight && this.m_sein.Input.Horizontal <= 0f);
		return flag && !this.m_sein.IsOnGround && this.m_sein.PlayerAbilities.AirDash.HasAbility;
	}

	// Token: 0x06001075 RID: 4213
	public void UpdateNormal()
	{
		float num = Time.time - this.m_lastPressTime;
		if (this.m_sein.IsOnGround)
		{
			this.m_hasDashed = false;
			RandomizerBonus.DoubleAirDashUsed = false;
		}
		if (Core.Input.Glide.Pressed && this.m_timeWhenDashJumpHappened + 5f > Time.time)
		{
			this.m_timeWhenDashJumpHappened = 0f;
			PlatformMovement platformMovement = this.m_sein.PlatformBehaviour.PlatformMovement;
			float num2 = this.OffGroundSpeed - 2f;
			if (Mathf.Abs(platformMovement.LocalSpeedX) > num2)
			{
				platformMovement.LocalSpeedX = Mathf.Sign(platformMovement.LocalSpeedX) * num2;
			}
		}
		IChargeDashAttackable arg_B0_;
		if (this.CanChargeDash())
		{
			arg_B0_ = this.FindClosestAttackable;
		}
		else
		{
			arg_B0_ = null;
		}
		this.UpdateTargetHighlight(arg_B0_);
		if (Core.Input.RightShoulder.Pressed && num < 0.15f)
		{
			if (this.CanChargeDash())
			{
				if (this.HasEnoughEnergy)
				{
					this.SpendEnergy();
					this.PerformChargeDash();
					return;
				}
				this.ShowNotEnoughEnergy();
				this.m_lastPressTime = 0f;
				return;
			}
			else
			{
				if (this.CanPerformNormalDash())
				{
					this.PerformDash();
					return;
				}
				if (this.CanWallDash())
				{
					this.PerformWallDash();
					return;
				}
				if (this.CanPerformDashIntoWall())
				{
					this.PerformDashIntoWall();
				}
			}
		}
	}

	// Token: 0x06001076 RID: 4214 RVA: 0x0000E658 File Offset: 0x0000C858
	private void ShowNotEnoughEnergy()
	{
		UI.SeinUI.ShakeEnergyOrbBar();
		if (this.NotEnoughEnergySound)
		{
			Sound.Play(this.NotEnoughEnergySound.GetSound(null), base.transform.position, null);
		}
	}

	// Token: 0x06001077 RID: 4215 RVA: 0x000625A4 File Offset: 0x000607A4
	public void UpdateDashing()
	{
		PlatformMovement platformMovement = this.m_sein.PlatformBehaviour.PlatformMovement;
		UI.Cameras.Current.ChaseTarget.CameraSpeedMultiplier.x = Mathf.Clamp01(this.m_stateCurrentTime / this.DashTime);
		platformMovement.LocalSpeedX = (float)((!this.m_faceLeft) ? 1 : -1) * this.DashSpeedOverTime.Evaluate(this.m_stateCurrentTime);
		this.m_sein.FaceLeft = this.m_faceLeft;
		if (this.AgainstWall())
		{
			platformMovement.LocalSpeed = Vector2.zero;
		}
		this.SpriteRotation = Mathf.Lerp(this.SpriteRotation, this.m_sein.PlatformBehaviour.PlatformMovement.GroundAngle, 0.2f);
		if (this.m_sein.IsOnGround)
		{
			if (Core.Input.Horizontal > 0f && this.m_faceLeft)
			{
				this.StopDashing();
			}
			if (Core.Input.Horizontal < 0f && !this.m_faceLeft)
			{
				this.StopDashing();
			}
		}
		if (this.m_stateCurrentTime > this.DashTime)
		{
			if (platformMovement.IsOnGround && Core.Input.Horizontal == 0f)
			{
				platformMovement.LocalSpeedX = 0f;
			}
			this.ChangeState(SeinDashAttack.State.Normal);
		}
		if (Core.Input.Jump.OnPressed || Core.Input.Glide.OnPressed)
		{
			platformMovement.LocalSpeedX = ((!this.m_faceLeft) ? this.OffGroundSpeed : (-this.OffGroundSpeed));
			this.m_sein.PlatformBehaviour.AirNoDeceleration.NoDeceleration = this.m_allowNoDecelerationForThisDash;
			this.m_stopAnimation = true;
			this.ChangeState(SeinDashAttack.State.Normal);
			this.m_timeWhenDashJumpHappened = Time.time;
		}
		if (this.RaycastTest() && this.m_isOnGround)
		{
			this.StickOntoGround();
		}
		else
		{
			this.m_isOnGround = false;
		}
	}

	// Token: 0x06001078 RID: 4216 RVA: 0x00062790 File Offset: 0x00060990
	private void StickOntoGround()
	{
		PlatformMovement platformMovement = this.m_sein.PlatformBehaviour.PlatformMovement;
		Vector3 vector = platformMovement.Position;
		platformMovement.PlaceOnGround(0f, 8f);
		Vector3 vector2 = vector;
		platformMovement.PlaceOnGround(0.5f, 8f);
		Vector3 vector3 = vector;
		vector = vector2;
		if (vector3.y > vector2.y)
		{
			vector = vector3;
		}
		platformMovement.Position = vector;
	}

	// Token: 0x06001079 RID: 4217 RVA: 0x000627F8 File Offset: 0x000609F8
	public void UpdateChargeDashing()
	{
		PlatformMovement platformMovement = this.m_sein.PlatformBehaviour.PlatformMovement;
		this.AttackNearbyEnemies();
		this.m_sein.Mortality.DamageReciever.MakeInvincibleToEnemies(1f);
		if (this.m_chargeDashAtTarget)
		{
			platformMovement.LocalSpeed = this.m_chargeDashDirection * this.ChargeDashSpeedOverTime.Evaluate(this.m_stateCurrentTime);
		}
		else
		{
			platformMovement.LocalSpeedX = (float)((!this.m_faceLeft) ? 1 : -1) * this.ChargeDashSpeedOverTime.Evaluate(this.m_stateCurrentTime);
		}
		if (this.m_hasHitAttackable)
		{
			platformMovement.LocalSpeed *= 0.33f;
		}
		this.m_sein.FaceLeft = this.m_faceLeft;
		this.SpriteRotation = Mathf.Lerp(this.SpriteRotation, this.m_sein.PlatformBehaviour.PlatformMovement.GroundAngle, 0.3f);
		if (this.AgainstWall())
		{
			platformMovement.LocalSpeed = Vector2.zero;
		}
		if (this.m_sein.IsOnGround)
		{
			if (Core.Input.Horizontal > 0f && this.m_faceLeft)
			{
				this.StopDashing();
			}
			if (Core.Input.Horizontal < 0f && !this.m_faceLeft)
			{
				this.StopDashing();
			}
		}
		if (this.m_stateCurrentTime > this.ChargeDashTime)
		{
			this.ChangeState(SeinDashAttack.State.Normal);
		}
		if (Core.Input.Jump.OnPressed || Core.Input.Glide.OnPressed)
		{
			platformMovement.LocalSpeedX = ((!this.m_faceLeft) ? this.OffGroundSpeed : (-this.OffGroundSpeed));
			this.m_sein.PlatformBehaviour.AirNoDeceleration.NoDeceleration = true;
			this.m_stopAnimation = true;
			this.ChangeState(SeinDashAttack.State.Normal);
		}
		if (this.RaycastTest() && this.m_isOnGround && !this.m_chargeDashAtTarget)
		{
			this.StickOntoGround();
		}
		else
		{
			this.m_isOnGround = false;
		}
	}

	// Token: 0x0600107A RID: 4218 RVA: 0x00062A0C File Offset: 0x00060C0C
	public void UpdateState()
	{
		UI.Cameras.Current.ChaseTarget.CameraSpeedMultiplier.x = 1f;
		if (Core.Input.RightShoulder.OnPressed)
		{
			this.m_lastPressTime = Time.time;
		}
		if (Core.Input.ChargeJump.Released)
		{
			this.m_chargeJumpWasReleased = true;
		}
		switch (this.CurrentState)
		{
		case SeinDashAttack.State.Normal:
			this.UpdateNormal();
			break;
		case SeinDashAttack.State.Dashing:
			this.UpdateDashing();
			break;
		case SeinDashAttack.State.ChargeDashing:
			this.UpdateChargeDashing();
			break;
		}
		this.m_stateCurrentTime += Time.deltaTime;
	}

	// Token: 0x0600107B RID: 4219 RVA: 0x00062AB4 File Offset: 0x00060CB4
	public void StopDashing()
	{
		PlatformMovement platformMovement = this.m_sein.PlatformBehaviour.PlatformMovement;
		platformMovement.LocalSpeed = Vector2.zero;
		this.ChangeState(SeinDashAttack.State.Normal);
		this.m_stopAnimation = true;
		this.m_chargeDashAtTarget = false;
	}

	// Token: 0x0600107C RID: 4220 RVA: 0x00062AF4 File Offset: 0x00060CF4
	private bool RaycastTest()
	{
		Vector3 a = Vector3.Cross(this.m_sein.PlatformBehaviour.PlatformMovement.GroundRayNormal, Vector3.forward);
		float num = this.m_sein.Speed.x * Time.deltaTime;
		Vector3 vector = this.m_sein.Position + a * num + Vector3.up;
		Vector3 vector2 = Vector3.down * (1.8f + Mathf.Abs(num));
		Debug.DrawRay(vector, vector2, Color.yellow, 0.5f);
		RaycastHit raycastHit;
		return this.m_sein.Controller.RayTest(vector, vector2, out raycastHit);
	}

	// Token: 0x0600107D RID: 4221
	public void ResetDashLimit()
	{
		this.m_hasDashed = false;
		RandomizerBonus.DoubleAirDashUsed = false;
	}

	// Token: 0x04000F8C RID: 3980
	public AnimationCurve DashSpeedOverTime;

	// Token: 0x04000F8D RID: 3981
	public AnimationCurve ChargeDashSpeedOverTime;

	// Token: 0x04000F8E RID: 3982
	public float DashTime = 0.5f;

	// Token: 0x04000F8F RID: 3983
	public float ChargeDashTime = 0.5f;

	// Token: 0x04000F90 RID: 3984
	public float ChargeTime = 0.2f;

	// Token: 0x04000F91 RID: 3985
	public SoundProvider ChargeSound;

	// Token: 0x04000F92 RID: 3986
	public SoundProvider DoneChargingSound;

	// Token: 0x04000F93 RID: 3987
	public SoundSource ChargedSound;

	// Token: 0x04000F94 RID: 3988
	public SoundProvider UnChargeSound;

	// Token: 0x04000F95 RID: 3989
	public SoundProvider DashSound;

	// Token: 0x04000F96 RID: 3990
	public SoundProvider ChargeDashSound;

	// Token: 0x04000F97 RID: 3991
	public SoundProvider RainbowDashSound;

	// Token: 0x04000F98 RID: 3992
	public SoundProvider DashIntoWallSound;

	// Token: 0x04000F99 RID: 3993
	public GameObject ExplosionEffect;

	// Token: 0x04000F9A RID: 3994
	public SeinDashAttack.State CurrentState;

	// Token: 0x04000F9B RID: 3995
	public float DashDownwardSpeed = 10f;

	// Token: 0x04000F9C RID: 3996
	public float OffGroundSpeed = 15f;

	// Token: 0x04000F9D RID: 3997
	public int Damage = 50;

	// Token: 0x04000F9E RID: 3998
	public float EnergyCost = 1f;

	// Token: 0x04000F9F RID: 3999
	public SoundProvider NotEnoughEnergySound;

	// Token: 0x04000FA0 RID: 4000
	public TextureAnimationWithTransitions DashAnimation;

	// Token: 0x04000FA1 RID: 4001
	public TextureAnimationWithTransitions ChargeDashAnimation;

	// Token: 0x04000FA2 RID: 4002
	public TextureAnimationWithTransitions GlideDashAnimation;

	// Token: 0x04000FA3 RID: 4003
	public TextureAnimationWithTransitions DashIntoWallAnimation;

	// Token: 0x04000FA4 RID: 4004
	public GameObject DashStartEffect;

	// Token: 0x04000FA5 RID: 4005
	public GameObject DashFollowEffect;

	// Token: 0x04000FA6 RID: 4006
	public GameObject DashFollowRainbowEffect;

	// Token: 0x04000FA7 RID: 4007
	private SeinCharacter m_sein;

	// Token: 0x04000FA8 RID: 4008
	private bool m_faceLeft;

	// Token: 0x04000FA9 RID: 4009
	private float m_stateCurrentTime;

	// Token: 0x04000FAA RID: 4010
	private HashSet<IAttackable> m_attackablesIgnore = new HashSet<IAttackable>();

	// Token: 0x04000FAB RID: 4011
	private bool m_stopAnimation;

	// Token: 0x04000FAC RID: 4012
	private float m_lastPressTime;

	// Token: 0x04000FAD RID: 4013
	private float m_lastDashTime;

	// Token: 0x04000FAE RID: 4014
	private bool m_isOnGround;

	// Token: 0x04000FAF RID: 4015
	public static bool RainbowDashActivated = false;

	// Token: 0x04000FB0 RID: 4016
	private bool m_hasDashed;

	// Token: 0x04000FB1 RID: 4017
	public float ChargeDashTargetMaxDistance = 20f;

	// Token: 0x04000FB2 RID: 4018
	private float m_timeOfLastExplosionEffect;

	// Token: 0x04000FB3 RID: 4019
	private float m_timeWhenDashJumpHappened;

	// Token: 0x04000FB4 RID: 4020
	private bool m_allowNoDecelerationForThisDash;

	// Token: 0x04000FB5 RID: 4021
	private IAttackable m_chargeDashAttackTarget;

	// Token: 0x04000FB6 RID: 4022
	private bool m_hasHitAttackable;

	// Token: 0x04000FB7 RID: 4023
	private bool m_chargeJumpWasReleased = true;

	// Token: 0x04000FB8 RID: 4024
	private IChargeDashAttackable m_lastTarget;

	// Token: 0x04000FB9 RID: 4025
	public float SpriteRotation;

	// Token: 0x04000FBA RID: 4026
	private Vector3 m_chargeDashDirection;

	// Token: 0x04000FBB RID: 4027
	private bool m_chargeDashAtTarget;

	// Token: 0x04000FBC RID: 4028
	private Vector3 m_chargeDashAtTargetPosition;

	// Token: 0x02000319 RID: 793
	public enum State
	{
		// Token: 0x04000FC2 RID: 4034
		Normal,
		// Token: 0x04000FC3 RID: 4035
		Dashing,
		// Token: 0x04000FC4 RID: 4036
		ChargeDashing
	}
}
