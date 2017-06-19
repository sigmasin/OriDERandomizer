using System;
using Game;
using UnityEngine;

// Token: 0x020009F7 RID: 2551
public class RandomizerChaosZoom : RandomizerChaosEffect
{
	// Token: 0x0600376F RID: 14191 RVA: 0x000E1448 File Offset: 0x000DF648
	public override void Clear()
	{
		this.Countdown = 0;
		this.Zooming = false;
		UI.Cameras.Current.OffsetController.AdditiveDefaultOffset = new Vector3(UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.x, UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.y, this.InitialOffset);
	}

	// Token: 0x06003770 RID: 14192 RVA: 0x000E14A8 File Offset: 0x000DF6A8
	public override void Start()
	{
		this.Zooming = false;
		if (this.Countdown == 0)
		{
			this.InitialOffset = UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.z;
		}
		this.Countdown = UnityEngine.Random.Range(360, 1200);
		int num = UnityEngine.Random.Range(0, 16);
		if (num <= 5)
		{
			Randomizer.showChaosEffect("Zoom in");
			float z = UnityEngine.Random.Range(-20f, -1f);
			UI.Cameras.Current.OffsetController.AdditiveDefaultOffset = new Vector3(UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.x, UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.y, z);
			return;
		}
		if (num <= 11)
		{
			Randomizer.showChaosEffect("Zoom out");
			float z2 = UnityEngine.Random.Range(1f, 100f);
			UI.Cameras.Current.OffsetController.AdditiveDefaultOffset = new Vector3(UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.x, UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.y, z2);
			return;
		}
		if (num <= 13)
		{
			Randomizer.showChaosEffect("Zoom in");
			this.Zooming = true;
			this.ZoomRate = UnityEngine.Random.Range(-20f, -1f) / (float)this.Countdown;
			return;
		}
		if (num <= 15)
		{
			Randomizer.showChaosEffect("Zoom out");
			this.Zooming = true;
			this.ZoomRate = UnityEngine.Random.Range(1f, 100f) / (float)this.Countdown;
		}
	}

	// Token: 0x06003771 RID: 14193 RVA: 0x000E161C File Offset: 0x000DF81C
	public override void Update()
	{
		if (this.Countdown > 0)
		{
			if (this.Zooming)
			{
				UI.Cameras.Current.OffsetController.AdditiveDefaultOffset = new Vector3(UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.x, UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.y, UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.z + this.ZoomRate);
			}
			this.Countdown--;
			if (this.Countdown == 0)
			{
				this.Clear();
			}
		}
	}

	// Token: 0x0400323A RID: 12858
	public int Countdown;

	// Token: 0x0400323B RID: 12859
	public float InitialOffset;

	// Token: 0x0400323C RID: 12860
	public bool Zooming;

	// Token: 0x0400323D RID: 12861
	public float ZoomRate;
}
