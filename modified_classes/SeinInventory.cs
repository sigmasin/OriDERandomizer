using System;
using System.Collections.Generic;

// Token: 0x0200032C RID: 812
public class SeinInventory : SaveSerialize
{
	// Token: 0x06001186 RID: 4486
	public SeinInventory()
	{
		this.RandomizerItems = new Dictionary<int, int>();
		this.ItemsAtLastSave = new Dictionary<int, int>();
	}

	// Token: 0x14000015 RID: 21
	// (add) Token: 0x06001187 RID: 4487
	// (remove) Token: 0x06001188 RID: 4488
	public event Action OnCollectKeystones = delegate()
	{
	};

	// Token: 0x14000016 RID: 22
	// (add) Token: 0x06001189 RID: 4489
	// (remove) Token: 0x0600118A RID: 4490
	public event Action OnCollectMapstone = delegate()
	{
	};

	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x0600118B RID: 4491
	public bool HasKeystones
	{
		get
		{
			return this.Keystones != 0;
		}
	}

	// Token: 0x170002F7 RID: 759
	// (get) Token: 0x0600118C RID: 4492
	public bool HasMapstones
	{
		get
		{
			return this.MapStones != 0;
		}
	}

	// Token: 0x0600118D RID: 4493
	public bool CanAfford(int cost)
	{
		return this.Keystones >= cost;
	}

	// Token: 0x0600118E RID: 4494
	public void SpendKeystones(int cost)
	{
		this.Keystones -= cost;
		if (this.Keystones < 0)
		{
			this.Keystones = 0;
		}
	}

	// Token: 0x0600118F RID: 4495
	public void SpendMapstone(int cost)
	{
		this.MapStones -= cost;
		if (this.MapStones < 0)
		{
			this.MapStones = 0;
		}
	}

	// Token: 0x06001190 RID: 4496
	public void CollectKeystones(int amount)
	{
		this.Keystones += amount;
		this.OnCollectKeystones();
	}

	// Token: 0x06001191 RID: 4497
	public void CollectMapstone(int amount)
	{
		this.MapStones += amount;
		this.OnCollectMapstone();
	}

	// Token: 0x06001192 RID: 4498
	public void RestoreKeystones(int amount)
	{
		this.CollectKeystones(amount);
	}

	// Token: 0x06001193 RID: 4499
	public override void Serialize(Archive ar)
	{
		ar.Serialize(ref this.Keystones);
		ar.Serialize(ref this.MapStones);
		ar.Serialize(ref this.SkillPointsCollected);
		ar.Serialize(ref this.RandomizerItems);
	}

	// Token: 0x060037DB RID: 14299
	public void SetRandomizerItem(int code, int value)
	{
		this.RandomizerItems[code] = value;
	}

	// Token: 0x060037DD RID: 14301
	public int GetRandomizerItem(int code)
	{
		if (this.RandomizerItems.ContainsKey(code))
		{
			return this.RandomizerItems[code];
		}
		return 0;
	}

	// Token: 0x06003842 RID: 14402
	public void IncRandomizerItem(int code, int value)
	{
		this.RandomizerItems[code] = this.GetRandomizerItem(code) + value;
	}

	public void OnSave() {
		 this.ItemsAtLastSave = new Dictionary<int,int>(this.RandomizerItems);
	}
	public void OnDeath() {
		 this.RandomizerItems = new Dictionary<int,int>(this.ItemsAtLastSave);
	}

	// Token: 0x04001098 RID: 4248
	public int Keystones;

	// Token: 0x04001099 RID: 4249
	public int MapStones;

	// Token: 0x0400109A RID: 4250
	public int SkillPointsCollected;

	// Token: 0x040032A3 RID: 12963
	public Dictionary<int, int> ItemsAtLastSave;

	// Token: 0x040032A3 RID: 12963
	public Dictionary<int, int> RandomizerItems;
}
