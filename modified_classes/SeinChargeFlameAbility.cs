using System;
using System.Collections.Generic;
using Core;
using fsm;
using Game;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class SeinChargeFlameAbility : CharacterState, ISeinReceiver
{
	// Token: 0x17000022 RID: 34
	// (get) Token: 0x060000CE RID: 206 RVA: 0x00002CC1 File Offset: 0x00000EC1
	public float ChargeDuration
	{
		get
		{
			return this.ChargeFlameSettings.ChargeDuration;
		}
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x060000CF RID: 207
	public bool HasEnoughEnergy
	{
		get
		{
			float reduction = RandomizerBonus.ChargeFlameEfficiency() ? 0.5f : 0f;
			return this.m_sein.Energy.CanAfford(this.EnergyCost * ((!this.m_sein.PlayerAbilities.ChargeFlameEfficiency.HasAbility) ? (1f - reduction) : (0.5f - reduction)));
		}
	}

	// Token: 0x060000D0 RID: 208
	public void SpendEnergy()
	{
		float reduction = RandomizerBonus.ChargeFlameEfficiency() ? 0.5f : 0f;
		this.m_sein.Energy.Spend(this.EnergyCost * ((!this.m_sein.PlayerAbilities.ChargeFlameEfficiency.HasAbility) ? (1f - reduction) : (0.5f - reduction)));
	}

	// Token: 0x060000D1 RID: 209
	public void RestoreEnergy()
	{
		float reduction = RandomizerBonus.ChargeFlameEfficiency() ? 0.5f : 0f;
		this.m_sein.Energy.Gain(this.EnergyCost * ((!this.m_sein.PlayerAbilities.ChargeFlameEfficiency.HasAbility) ? (1f - reduction) : (0.5f - reduction)));
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x0002DD24 File Offset: 0x0002BF24
	public override void Awake()
	{
		base.Awake();
		this.State.Start = new State
		{
			UpdateStateEvent = new Action(this.UpdateStartState),
			OnEnterEvent = new Action(this.OnEnterStartState)
		};
		this.State.Precharging = new State
		{
			UpdateStateEvent = new Action(this.UpdatePrechargingState)
		};
		this.State.Charging = new State
		{
			UpdateStateEvent = new Action(this.UpdateChargingState)
		};
		this.State.Charged = new State
		{
			UpdateStateEvent = new Action(this.UpdateChargedState)
		};
		this.Logic.RegisterStates(new IState[]
		{
			this.State.Start,
			this.State.Precharging,
			this.State.Charging,
			this.State.Charged
		});
		this.Logic.ChangeState(this.State.Start);
		Game.Checkpoint.Events.OnPostRestore.Add(new Action(this.OnRestoreCheckpoint));
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x0002DE50 File Offset: 0x0002C050
	public void OnRestoreCheckpoint()
	{
		if (this.m_chargeFlameChargeEffect)
		{
			InstantiateUtility.Destroy(this.m_chargeFlameChargeEffect);
		}
		if (this.CurrentChargingSound())
		{
			this.CurrentChargingSound().StopAndFadeOut(0.5f);
		}
		this.Logic.ChangeState(this.State.Start);
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00002CCE File Offset: 0x00000ECE
	public void OnEnterStartState()
	{
		if (this.m_chargeFlameChargeEffect)
		{
			InstantiateUtility.Destroy(this.m_chargeFlameChargeEffect);
		}
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x0002DEB0 File Offset: 0x0002C0B0
	public void UpdateStartState()
	{
		if (this.m_chargeFlameChargeEffect)
		{
			InstantiateUtility.Destroy(this.m_chargeFlameChargeEffect);
		}
		if (this.m_sein.Controller.IsBashing)
		{
			return;
		}
		if (this.ChargeFlameButton.OnPressed && !this.ChargeFlameButton.Used && this.m_sein.PlayerAbilities.ChargeFlame.HasAbility && !this.m_sein.Controller.InputLocked && !this.m_sein.Abilities.SpiritFlame.LockShootingSpiritFlame)
		{
			this.Logic.ChangeState(this.State.Precharging);
		}
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x0002DF70 File Offset: 0x0002C170
	public void UpdatePrechargingState()
	{
		if (this.Logic.CurrentStateTime > 0.3f)
		{
			this.m_chargeFlameChargeEffect = (GameObject)InstantiateUtility.Instantiate(this.ChargeFlameSettings.ChargeFlameChargeEffectPrefab);
			this.m_chargeFlameChargeEffect.transform.position = Characters.Ori.transform.position;
			this.m_chargeFlameChargeEffect.transform.parent = Characters.Ori.transform;
			this.m_chargeFlameChargeEffect.GetComponentsInChildren<LegacyAnimator>(SeinChargeFlameAbility.s_legacyAnimatorList);
			for (int i = 0; i < SeinChargeFlameAbility.s_legacyAnimatorList.Count; i++)
			{
				LegacyAnimator legacyAnimator = SeinChargeFlameAbility.s_legacyAnimatorList[i];
				legacyAnimator.Speed = 1f / this.ChargeDuration;
			}
			SeinChargeFlameAbility.s_legacyAnimatorList.Clear();
			if (this.CurrentChargingSound())
			{
				this.CurrentChargingSound().Play();
			}
			this.Logic.ChangeState(this.State.Charging);
			return;
		}
		if (this.ChargeFlameButton.Released)
		{
			this.Logic.ChangeState(this.State.Start);
		}
		else if (this.m_sein.Abilities.SpiritFlame.LockShootingSpiritFlame)
		{
			this.Logic.ChangeState(this.State.Start);
		}
		else if (this.m_sein.Controller.InputLocked)
		{
			this.Logic.ChangeState(this.State.Start);
		}
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x0002E0F8 File Offset: 0x0002C2F8
	public void UpdateChargingState()
	{
		if (this.ChargeFlameButton.Released || this.m_sein.Controller.InputLocked || this.m_sein.Abilities.SpiritFlame.LockShootingSpiritFlame)
		{
			if (this.CurrentChargingSound())
			{
				this.CurrentChargingSound().StopAndFadeOut(0.5f);
			}
			this.Logic.ChangeState(this.State.Start);
			return;
		}
		if (this.Logic.CurrentStateTime >= this.ChargeDuration)
		{
			if (this.HasEnoughEnergy)
			{
				this.Logic.ChangeState(this.State.Charged);
				this.SpendEnergy();
			}
			else
			{
				if (this.CurrentChargingSound())
				{
					this.CurrentChargingSound().StopAndFadeOut(0.5f);
				}
				this.Logic.ChangeState(this.State.Start);
				UI.SeinUI.ShakeEnergyOrbBar();
				if (this.NotEnoughEnergySound)
				{
					Sound.Play(this.NotEnoughEnergySound.GetSound(null), base.transform.position, null);
				}
			}
		}
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x0002E22C File Offset: 0x0002C42C
	public void ReleaseChargeBurst()
	{
		if (this.CurrentChargingSound())
		{
			this.CurrentChargingSound().StopAndFadeOut(0.5f);
		}
		if (this.m_sein.PlayerAbilities.ChargeFlameBlast.HasAbility)
		{
			InstantiateUtility.Instantiate(this.ChargeFlameSettings.ChargeFlameBurstC, Characters.Ori.Position, Quaternion.identity);
		}
		else if (this.m_sein.PlayerAbilities.ChargeFlameBurn.HasAbility)
		{
			InstantiateUtility.Instantiate(this.ChargeFlameSettings.ChargeFlameBurstB, Characters.Ori.Position, Quaternion.identity);
		}
		else
		{
			InstantiateUtility.Instantiate(this.ChargeFlameSettings.ChargeFlameBurstA, Characters.Ori.Position, Quaternion.identity);
		}
		this.Logic.ChangeState(this.State.Start);
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x0002E310 File Offset: 0x0002C510
	public void UpdateChargedState()
	{
		if (this.ChargeFlameButton.Released)
		{
			this.ReleaseChargeBurst();
		}
		else if (Core.Input.SoulFlame.OnPressed)
		{
			Core.Input.SoulFlame.Used = true;
			if (this.CurrentChargingSound())
			{
				this.CurrentChargingSound().StopAndFadeOut(0.5f);
			}
			this.Logic.ChangeState(this.State.Start);
			this.RestoreEnergy();
			UI.SeinUI.ShakeEnergyOrbBar();
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x060000DA RID: 218 RVA: 0x00002CEB File Offset: 0x00000EEB
	public Core.Input.InputButtonProcessor ChargeFlameButton
	{
		get
		{
			return Core.Input.SpiritFlame;
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x060000DB RID: 219 RVA: 0x00002CF2 File Offset: 0x00000EF2
	public bool IsCharging
	{
		get
		{
			return this.Logic.CurrentState != this.State.Start;
		}
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00002D0F File Offset: 0x00000F0F
	public override void UpdateCharacterState()
	{
		this.Logic.UpdateState(Time.deltaTime);
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00002D21 File Offset: 0x00000F21
	public void SetReferenceToSein(SeinCharacter sein)
	{
		this.m_sein = sein;
		this.m_sein.Abilities.ChargeFlame = this;
	}

	// Token: 0x060000DE RID: 222 RVA: 0x0002E398 File Offset: 0x0002C598
	public override void OnExit()
	{
		if (this.Logic.CurrentState == this.State.Precharging)
		{
			this.Logic.ChangeState(this.State.Start);
		}
		if (this.Logic.CurrentState == this.State.Charging)
		{
			if (this.CurrentChargingSound())
			{
				this.CurrentChargingSound().StopAndFadeOut(0.5f);
			}
			this.Logic.ChangeState(this.State.Start);
		}
		if (this.Logic.CurrentState == this.State.Charged)
		{
			this.ReleaseChargeBurst();
		}
		base.OnExit();
	}

	// Token: 0x060000DF RID: 223 RVA: 0x0002E450 File Offset: 0x0002C650
	private SoundSource CurrentChargingSound()
	{
		if (this.m_sein.PlayerAbilities.ChargeFlameBlast.HasAbility)
		{
			return this.ChargingSoundLevelC;
		}
		if (this.m_sein.PlayerAbilities.ChargeFlameBurn.HasAbility)
		{
			return this.ChargingSoundLevelB;
		}
		return this.ChargingSoundLevelA;
	}

	// Token: 0x040000FF RID: 255
	public SoundSource ChargingSoundLevelA;

	// Token: 0x04000100 RID: 256
	public SoundSource ChargingSoundLevelB;

	// Token: 0x04000101 RID: 257
	public SoundSource ChargingSoundLevelC;

	// Token: 0x04000102 RID: 258
	public AchievementAsset KillEnemiesSimultaneouslyAchievement;

	// Token: 0x04000103 RID: 259
	public SoundProvider NotEnoughEnergySound;

	// Token: 0x04000104 RID: 260
	public SeinChargeFlameAbility.ChargeFlameDefinitions ChargeFlameSettings;

	// Token: 0x04000105 RID: 261
	public SeinChargeFlameAbility.States State = new SeinChargeFlameAbility.States();

	// Token: 0x04000106 RID: 262
	private StateMachine Logic = new StateMachine();

	// Token: 0x04000107 RID: 263
	private GameObject m_chargeFlameChargeEffect;

	// Token: 0x04000108 RID: 264
	public float EnergyCost = 1f;

	// Token: 0x04000109 RID: 265
	private static readonly List<LegacyAnimator> s_legacyAnimatorList = new List<LegacyAnimator>();

	// Token: 0x0400010A RID: 266
	private SeinCharacter m_sein;

	// Token: 0x02000024 RID: 36
	[Serializable]
	public class ChargeFlameDefinitions
	{
		// Token: 0x0400010B RID: 267
		public float ChargeDuration = 1f;

		// Token: 0x0400010C RID: 268
		public GameObject ChargeFlameBurstA;

		// Token: 0x0400010D RID: 269
		public GameObject ChargeFlameBurstB;

		// Token: 0x0400010E RID: 270
		public GameObject ChargeFlameBurstC;

		// Token: 0x0400010F RID: 271
		public GameObject ChargeFlameChargeEffectPrefab;
	}

	// Token: 0x02000025 RID: 37
	public class States
	{
		// Token: 0x04000110 RID: 272
		public State Start;

		// Token: 0x04000111 RID: 273
		public State Precharging;

		// Token: 0x04000112 RID: 274
		public State Charging;

		// Token: 0x04000113 RID: 275
		public State Charged;
	}
}
