using System;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class SeinHealthController : SaveSerialize, ISeinReceiver
{
	// Token: 0x0600116A RID: 4458 RVA: 0x0000F556 File Offset: 0x0000D756
	public void SetAmount(float amount)
	{
		this.Amount = amount;
		this.VisualMinAmount = amount;
		this.VisualMaxAmount = amount;
	}

	// Token: 0x0600116B RID: 4459 RVA: 0x00066444 File Offset: 0x00064644
	public void FixedUpdate()
	{
		this.VisualMinAmount = Mathf.MoveTowards(this.VisualMinAmount, this.Amount, Time.deltaTime * 4f);
		this.VisualMaxAmount = Mathf.MoveTowards(this.VisualMaxAmount, this.Amount, Time.deltaTime * 4f);
	}

	// Token: 0x170002EA RID: 746
	// (get) Token: 0x0600116C RID: 4460 RVA: 0x0000F56D File Offset: 0x0000D76D
	public float VisualMinAmountNormalized
	{
		get
		{
			return this.VisualMinAmount / (float)this.MaxHealth;
		}
	}

	// Token: 0x170002EB RID: 747
	// (get) Token: 0x0600116D RID: 4461 RVA: 0x0000F57D File Offset: 0x0000D77D
	public float VisualMaxAmountNormalized
	{
		get
		{
			return this.VisualMaxAmount / (float)this.MaxHealth;
		}
	}

	// Token: 0x170002EC RID: 748
	// (get) Token: 0x0600116E RID: 4462 RVA: 0x0000F58D File Offset: 0x0000D78D
	public int HealthUpgradesCollected
	{
		get
		{
			return this.MaxHealth / 4 - 3;
		}
	}

	// Token: 0x0600116F RID: 4463 RVA: 0x0000F599 File Offset: 0x0000D799
	public void OnRespawn()
	{
		InstantiateUtility.Instantiate(this.RespawnEffect, this.m_sein.Transform.position, Quaternion.identity);
		this.m_sein.Mortality.DamageReciever.MakeInvincible(1f);
	}

	// Token: 0x06001170 RID: 4464 RVA: 0x0000F5D6 File Offset: 0x0000D7D6
	public void LoseHealth(int amount)
	{
		this.Amount -= (float)amount;
		if (this.Amount < 0f)
		{
			this.Amount = 0f;
		}
		this.VisualMinAmount = this.Amount;
	}

	// Token: 0x06001171 RID: 4465 RVA: 0x00066498 File Offset: 0x00064698
	public void GainHealth(int amount)
	{
		if (this.Amount > (float)this.MaxHealth)
		{
			return;
		}
		this.Amount += (float)amount;
		this.Amount = Mathf.Min((float)this.MaxHealth, this.Amount);
		this.VisualMaxAmount = this.Amount;
	}

	// Token: 0x06001172 RID: 4466 RVA: 0x0000F60B File Offset: 0x0000D80B
	public void GainMaxHeartContainer()
	{
		this.MaxHealth += 4;
		this.RestoreAllHealth();
	}

	// Token: 0x06001173 RID: 4467
	public void RestoreAllHealth()
	{
		if (this.Amount < (float)this.MaxHealth)
		{
			this.Amount = (float)this.MaxHealth;
			this.VisualMaxAmount = this.Amount;
		}
	}

	// Token: 0x06001174 RID: 4468 RVA: 0x0000F63C File Offset: 0x0000D83C
	public void TakeDamage(int amount)
	{
		this.Amount -= (float)amount;
		this.Amount = Mathf.Max(0f, this.Amount);
		this.VisualMinAmount = this.Amount;
	}

	// Token: 0x06001175 RID: 4469 RVA: 0x000664E8 File Offset: 0x000646E8
	public override void Serialize(Archive ar)
	{
		ar.Serialize(ref this.Amount);
		ar.Serialize(ref this.MaxHealth);
		if (ar.Reading)
		{
			this.VisualMaxAmount = (this.VisualMinAmount = this.Amount);
		}
	}

	// Token: 0x170002ED RID: 749
	// (get) Token: 0x06001176 RID: 4470 RVA: 0x0000F66F File Offset: 0x0000D86F
	public bool IsFull
	{
		get
		{
			return this.Amount == (float)this.MaxHealth;
		}
	}

	// Token: 0x06001177 RID: 4471 RVA: 0x0000F680 File Offset: 0x0000D880
	public void SetReferenceToSein(SeinCharacter sein)
	{
		this.m_sein = sein;
	}

	// Token: 0x06001178 RID: 4472 RVA: 0x0006652C File Offset: 0x0006472C
	public void GainHealth(float amount)
	{
		if (this.Amount > (float)this.MaxHealth)
		{
			return;
		}
		this.Amount += amount;
		this.Amount = Mathf.Min((float)this.MaxHealth, this.Amount);
		this.VisualMaxAmount = this.Amount;
	}

	// Token: 0x04001088 RID: 4232
	public float Amount;

	// Token: 0x04001089 RID: 4233
	public int MaxHealth;

	// Token: 0x0400108A RID: 4234
	public float VisualMinAmount;

	// Token: 0x0400108B RID: 4235
	public float VisualMaxAmount;

	// Token: 0x0400108C RID: 4236
	public GameObject RespawnEffect;

	// Token: 0x0400108D RID: 4237
	private SeinCharacter m_sein;
}
