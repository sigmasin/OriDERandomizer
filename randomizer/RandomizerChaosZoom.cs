using System;
using Game;
using UnityEngine;

// Token: 0x020009F7 RID: 2551
public class RandomizerChaosZoom : RandomizerChaosEffect
{
	// Token: 0x06003783 RID: 14211
	public override void Clear()
	{
		this.Countdown = 0;
		this.Zooming = false;
		UI.Cameras.Current.OffsetController.AdditiveDefaultOffset = new Vector3(UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.x, UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.y, this.InitialOffset);
	}

	// Token: 0x06003784 RID: 14212
	public override void Start()
	{
		this.Zooming = false;
		if (this.Countdown == 0)
		{
			this.InitialOffset = UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.z;
		}
		this.Countdown = UnityEngine.Random.Range(360, 1200);
		int type = UnityEngine.Random.Range(0, 16);
		if (type <= 5)
		{
			Randomizer.showChaosEffect("Zoom in");
			float zoom = UnityEngine.Random.Range(1f, this.InitialOffset);
			UI.Cameras.Current.OffsetController.AdditiveDefaultOffset = new Vector3(UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.x, UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.y, zoom);
			return;
		}
		if (type <= 11)
		{
			Randomizer.showChaosEffect("Zoom out");
			float zoom = UnityEngine.Random.Range(this.InitialOffset, 100f);
			UI.Cameras.Current.OffsetController.AdditiveDefaultOffset = new Vector3(UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.x, UI.Cameras.Current.OffsetController.AdditiveDefaultOffset.y, zoom);
			return;
		}
		if (type <= 13)
		{
			Randomizer.showChaosEffect("Zoom in");
			this.Zooming = true;
			this.ZoomRate = UnityEngine.Random.Range(-this.InitialOffset, -1f) / (float)this.Countdown;
			return;
		}
		if (type <= 15)
		{
			Randomizer.showChaosEffect("Zoom out");
			this.Zooming = true;
			this.ZoomRate = UnityEngine.Random.Range(1f, 100f) / (float)this.Countdown;
		}
	}

	// Token: 0x06003785 RID: 14213
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

	// Token: 0x040032BC RID: 12988
	public float InitialOffset;

	// Token: 0x040032BD RID: 12989
	public bool Zooming;

	// Token: 0x040032BE RID: 12990
	public float ZoomRate;
}
