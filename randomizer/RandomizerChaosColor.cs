using System;
using Game;
using UnityEngine;

// Token: 0x020009FA RID: 2554
public class RandomizerChaosColor : RandomizerChaosEffect
{
	// Token: 0x0600378F RID: 14223
	public override void Clear()
	{
		this.Countdown = 0;
		Characters.Sein.PlatformBehaviour.Visuals.SpriteRenderer.material.color = new Color(this.InitialColor.r, this.InitialColor.g, this.InitialColor.b, 0.5f);
	}

	// Token: 0x06003790 RID: 14224
	public override void Start()
	{
		this.Countdown = UnityEngine.Random.Range(600, 3600);
		this.InitialColor = Characters.Sein.PlatformBehaviour.Visuals.SpriteRenderer.material.color;
		if (UnityEngine.Random.Range(0, 2) == 0)
		{
			Randomizer.showChaosEffect("Invisible Ori");
			Characters.Sein.PlatformBehaviour.Visuals.SpriteRenderer.material.color = new Color(this.InitialColor.r, this.InitialColor.g, this.InitialColor.b, 0f);
			return;
		}
		Randomizer.showChaosEffect("Ghostly Ori");
		Characters.Sein.PlatformBehaviour.Visuals.SpriteRenderer.material.color = new Color(this.InitialColor.r, this.InitialColor.g, this.InitialColor.b, UnityEngine.Random.Range(0f, 0.5f));
	}

	// Token: 0x06003791 RID: 14225
	public override void Update()
	{
		if (this.Countdown > 0)
		{
			this.Countdown--;
			if (this.Countdown == 0)
			{
				this.Clear();
			}
		}
	}

	// Token: 0x0400323D RID: 12861
	public int Countdown;

	// Token: 0x040032CF RID: 13007
	public Color InitialColor;
}
