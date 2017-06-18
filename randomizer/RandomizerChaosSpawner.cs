using System;

// Token: 0x020009F8 RID: 2552
public class RandomizerChaosSpawner : RandomizerChaosEffect
{
	// Token: 0x06003787 RID: 14215
	public override void Clear()
	{
		this.Countdown = 0;
	}

	// Token: 0x06003788 RID: 14216
	public override void Start()
	{
	}

	// Token: 0x06003789 RID: 14217
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

	// Token: 0x0400323B RID: 12859
	public int Countdown;
}
