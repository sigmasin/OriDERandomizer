using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

// Token: 0x0200032E RID: 814
public class SeinLevel : SaveSerialize, ISeinReceiver
{
	// Token: 0x170002FD RID: 765
	// (get) Token: 0x060011C0 RID: 4544 RVA: 0x0000FA62 File Offset: 0x0000DC62
	public int TotalExperience
	{
		get
		{
			return this.Experience + this.ConsumedExperience;
		}
	}

	// Token: 0x170002FE RID: 766
	// (get) Token: 0x060011C1 RID: 4545 RVA: 0x0000FA71 File Offset: 0x0000DC71
	public int TotalExperienceForNextLevel
	{
		get
		{
			return this.ExperienceForNextLevel + this.ConsumedExperience;
		}
	}

	// Token: 0x170002FF RID: 767
	// (get) Token: 0x060011C2 RID: 4546 RVA: 0x0000FA80 File Offset: 0x0000DC80
	public int ExperienceNeedForNextLevel
	{
		get
		{
			return this.ExperienceForNextLevel - this.Experience;
		}
	}

	// Token: 0x17000300 RID: 768
	// (get) Token: 0x060011C3 RID: 4547 RVA: 0x0000FA8F File Offset: 0x0000DC8F
	public float ExperienceVisualMinNormalized
	{
		get
		{
			return this.ExperienceVisualMin / (float)this.ExperienceForNextLevel;
		}
	}

	// Token: 0x17000301 RID: 769
	// (get) Token: 0x060011C4 RID: 4548 RVA: 0x0000FA9F File Offset: 0x0000DC9F
	public float ExperienceVisualMaxNormalized
	{
		get
		{
			return this.ExperienceVisualMax / (float)this.ExperienceForNextLevel;
		}
	}

	// Token: 0x17000302 RID: 770
	// (get) Token: 0x060011C5 RID: 4549
	public int ExperienceForNextLevel
	{
		get
		{
			return Mathf.RoundToInt(this.ExperienceRequiredPerLevel.Evaluate((float)(this.Current % 128)));
		}
	}

	// Token: 0x17000303 RID: 771
	// (get) Token: 0x060011C6 RID: 4550
	public int ConsumedExperience
	{
		get
		{
			int num = 0;
			for (int i = this.Current % 128 - 1; i >= 0; i--)
			{
				num += Mathf.RoundToInt(this.ExperienceRequiredPerLevel.Evaluate((float)i));
			}
			return num;
		}
	}

	// Token: 0x060011C7 RID: 4551 RVA: 0x0000FAC8 File Offset: 0x0000DCC8
	public void GainExperience(int amount)
	{
		this.Experience += amount;
		this.ExperienceVisualMax = (float)this.Experience;
	}

	// Token: 0x060011C8 RID: 4552 RVA: 0x000028E7 File Offset: 0x00000AE7
	public void Update()
	{
	}

	// Token: 0x060011C9 RID: 4553 RVA: 0x00067AA8 File Offset: 0x00065CA8
	public void FixedUpdate()
	{
		if (this.m_sein.IsSuspended)
		{
			return;
		}
		float maxDelta = Time.deltaTime * this.ExperienceGainPerSecond * (float)this.ExperienceForNextLevel;
		this.ExperienceVisualMax = Mathf.MoveTowards(this.ExperienceVisualMax, (float)this.Experience, maxDelta);
		this.ExperienceVisualMin = Mathf.MoveTowards(this.ExperienceVisualMin, (float)this.Experience, maxDelta);
		if (this.ExperienceVisualMin >= (float)this.ExperienceForNextLevel)
		{
			this.LevelUp();
		}
	}

	// Token: 0x060011CA RID: 4554
	public void LevelUp()
	{
		this.Experience -= this.ExperienceForNextLevel;
		this.ExperienceVisualMin = 0f;
		this.ExperienceVisualMax = (float)this.Experience;
		if (this.Current % 128 < 99)
		{
			this.Current++;
			this.SkillPoints++;
		}
		if (this.OnLevelUpGameObject)
		{
			((GameObject)InstantiateUtility.Instantiate(this.OnLevelUpGameObject, Characters.Sein.Position, Quaternion.identity)).GetComponent<TargetPositionFollower>().Target = Characters.Sein.Transform;
		}
	}

	// Token: 0x060011CB RID: 4555 RVA: 0x0000FAE5 File Offset: 0x0000DCE5
	public void LoseExperience(int amount)
	{
		this.Experience -= amount;
		this.ExperienceVisualMin = (float)this.Experience;
		if (this.Experience < 0)
		{
			this.Experience = 0;
		}
	}

	// Token: 0x060011CC RID: 4556 RVA: 0x00067BD0 File Offset: 0x00065DD0
	public override void Serialize(Archive ar)
	{
		ar.Serialize(ref this.Current);
		ar.Serialize(ref this.Experience);
		ar.Serialize(ref this.SkillPoints);
		ar.Serialize(ref SeinLevel.HasSpentSkillPoint);
		if (ar.Reading)
		{
			this.ExperienceVisualMax = (this.ExperienceVisualMin = (float)this.Current);
		}
	}

	// Token: 0x060011CD RID: 4557 RVA: 0x0000FB15 File Offset: 0x0000DD15
	public float ApplyLevelingToDamage(float damage)
	{
		return damage + damage * (float)this.m_sein.PlayerAbilities.OriStrength * 0.5f;
	}

	// Token: 0x060011CE RID: 4558 RVA: 0x0000FB32 File Offset: 0x0000DD32
	public float CalculateLevelBasedMaxHealth(int level, float health)
	{
		return (float)Mathf.RoundToInt(health * this.DamageMultiplierPerOriStrength.Evaluate((float)level));
	}

	// Token: 0x060011CF RID: 4559 RVA: 0x0000FB49 File Offset: 0x0000DD49
	public void SetReferenceToSein(SeinCharacter sein)
	{
		this.m_sein = sein;
	}

	// Token: 0x060011D0 RID: 4560 RVA: 0x0000FB52 File Offset: 0x0000DD52
	public void GainSkillPoint()
	{
		this.SkillPoints++;
	}

	// Token: 0x040010BD RID: 4285
	public int SkillPoints;

	// Token: 0x040010BE RID: 4286
	public int Current;

	// Token: 0x040010BF RID: 4287
	public AnimationCurve DamageMultiplierPerOriStrength;

	// Token: 0x040010C0 RID: 4288
	public int Experience;

	// Token: 0x040010C1 RID: 4289
	public float ExperienceVisualMin;

	// Token: 0x040010C2 RID: 4290
	public float ExperienceVisualMax;

	// Token: 0x040010C3 RID: 4291
	public AnimationCurve ExperienceRequiredPerLevel;

	// Token: 0x040010C4 RID: 4292
	public GameObject OnLevelUpGameObject;

	// Token: 0x040010C5 RID: 4293
	public static bool HasSpentSkillPoint = false;

	// Token: 0x040010C6 RID: 4294
	public float ExperienceGainPerSecond = 30f;

	// Token: 0x040010C7 RID: 4295
	private static readonly HashSet<string> CollectablesToSerialize = new HashSet<string>
	{
		"largeExpOrbPlaceholder",
		"mediumExpOrbPlaceholder",
		"smallExpOrbPlaceholder"
	};

	// Token: 0x040010C8 RID: 4296
	private static HashSet<Type> TypesToSerialize = new HashSet<Type>
	{
		typeof(ExpOrbPickup)
	};

	// Token: 0x040010C9 RID: 4297
	private SeinCharacter m_sein;
}
