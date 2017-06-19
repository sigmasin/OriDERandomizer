using System;
using Game;
using UnityEngine;

// Token: 0x020009FA RID: 2554
public class RandomizerChaosColor : RandomizerChaosEffect
{
	// Token: 0x0600377B RID: 14203
	public override void Clear()
	{
		this.Countdown = 0;
		this.Fading = false;
		if (this.Activated)
		{
			Characters.Sein.PlatformBehaviour.Visuals.SpriteRenderer.material.color = new Color(this.InitialColor.r, this.InitialColor.g, this.InitialColor.b, 0.5f);
		}
	}

	// Token: 0x0600377C RID: 14204
	public override void Start()
	{
		this.Activated = true;
		this.Fading = false;
		this.Countdown = UnityEngine.Random.Range(600, 3600);
		this.InitialColor = Characters.Sein.PlatformBehaviour.Visuals.SpriteRenderer.material.color;
		if (UnityEngine.Random.Range(0, 2) == 0)
		{
			Randomizer.showChaosEffect("Invisible Ori");
			Characters.Sein.PlatformBehaviour.Visuals.SpriteRenderer.material.color = new Color(this.InitialColor.r, this.InitialColor.g, this.InitialColor.b, 0f);
			return;
		}
		Randomizer.showChaosEffect("Ghostly Ori");
		this.Fading = true;
		this.FadeRate = UnityEngine.Random.Range(0.5f, 2f) / (float)this.Countdown;
	}

	// Token: 0x0600377D RID: 14205
	public override void Update()
	{
		if (this.Countdown > 0)
		{
			if (this.Fading)
			{
				Characters.Sein.PlatformBehaviour.Visuals.SpriteRenderer.material.color = new Color(this.InitialColor.r, this.InitialColor.g, this.InitialColor.b, Math.Max(0f, Characters.Sein.PlatformBehaviour.Visuals.SpriteRenderer.material.color.a - this.FadeRate));
			}
			this.Countdown--;
			if (this.Countdown == 0)
			{
				this.Clear();
			}
		}
	}

	// Token: 0x04003241 RID: 12865
	public int Countdown;

	// Token: 0x04003242 RID: 12866
	public Color InitialColor;

	// Token: 0x04003243 RID: 12867
	public float FadeRate;

	// Token: 0x04003244 RID: 12868
	public bool Fading;

	// Token: 0x0400327A RID: 12922
	public bool Activated;
}
