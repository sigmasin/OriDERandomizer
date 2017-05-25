using System;
using Core;
using Game;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class SeinEnergy : SaveSerialize
{
	// Token: 0x06001301 RID: 4865 RVA: 0x00010B43 File Offset: 0x0000ED43
	public void SetCurrent(float current)
	{
		this.Current = current;
		this.MinVisual = this.Current;
		this.MaxVisual = this.Current;
	}

	// Token: 0x06001302 RID: 4866 RVA: 0x00010B64 File Offset: 0x0000ED64
	public void NotifyOutOfEnergy()
	{
		UI.SeinUI.ShakeEnergyOrbBar();
		Sound.Play(this.OutOfEnergySound.GetSound(null), base.transform.position, null);
	}

	// Token: 0x06001303 RID: 4867 RVA: 0x00010B8E File Offset: 0x0000ED8E
	public bool CanAfford(float amount)
	{
		return this.Current >= amount;
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06001304 RID: 4868 RVA: 0x00010B9C File Offset: 0x0000ED9C
	public float VisualMin
	{
		get
		{
			return this.MinVisual / this.Max;
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06001305 RID: 4869 RVA: 0x00010BAB File Offset: 0x0000EDAB
	public float VisualMax
	{
		get
		{
			return this.MaxVisual / this.Max;
		}
	}

	// Token: 0x06001306 RID: 4870 RVA: 0x0006B814 File Offset: 0x00069A14
	public void Gain(float amount)
	{
		if (this.Current > this.Max)
		{
			return;
		}
		this.Current += amount;
		if (this.Current > this.Max)
		{
			this.Current = this.Max;
		}
		this.MaxVisual = this.Current;
	}

	// Token: 0x06001307 RID: 4871 RVA: 0x00010BBA File Offset: 0x0000EDBA
	public void Spend(float amount)
	{
		this.Current -= amount;
		if (this.Current < 0f)
		{
			this.Current = 0f;
		}
		this.MinVisual = this.Current;
	}

	// Token: 0x06001308 RID: 4872 RVA: 0x0006B864 File Offset: 0x00069A64
	public override void Serialize(Archive ar)
	{
		ar.Serialize(ref this.Current);
		ar.Serialize(ref this.Max);
		if (ar.Reading)
		{
			this.MinVisual = (this.MaxVisual = this.Current);
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06001309 RID: 4873 RVA: 0x00010BF1 File Offset: 0x0000EDF1
	public bool EnergyActive
	{
		get
		{
			return this.Max > 0f;
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x0600130A RID: 4874 RVA: 0x00010BAB File Offset: 0x0000EDAB
	public float VisualMaxNormalized
	{
		get
		{
			return this.MaxVisual / this.Max;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x0600130B RID: 4875 RVA: 0x00010B9C File Offset: 0x0000ED9C
	public float VisualMinNormalized
	{
		get
		{
			return this.MinVisual / this.Max;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x0600130C RID: 4876 RVA: 0x00010C00 File Offset: 0x0000EE00
	public object EnergyUpgradesCollected
	{
		get
		{
			return this.Max;
		}
	}

	// Token: 0x0600130D RID: 4877 RVA: 0x00010C0D File Offset: 0x0000EE0D
	public void Update()
	{
		this.MinVisual = Mathf.MoveTowards(this.MinVisual, this.Current, Time.deltaTime);
		this.MaxVisual = Mathf.MoveTowards(this.MaxVisual, this.Current, Time.deltaTime);
	}

	// Token: 0x0600130E RID: 4878
	public void RestoreAllEnergy()
	{
		if (this.Current < this.Max)
		{
			this.Current = this.Max;
		}
	}

	// Token: 0x04001202 RID: 4610
	public float MinVisual;

	// Token: 0x04001203 RID: 4611
	public float MaxVisual;

	// Token: 0x04001204 RID: 4612
	public float Current;

	// Token: 0x04001205 RID: 4613
	public float Max = 3f;

	// Token: 0x04001206 RID: 4614
	public SoundProvider OutOfEnergySound;
}
