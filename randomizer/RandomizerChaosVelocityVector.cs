using System;
using Game;
using UnityEngine;

// Token: 0x020009FC RID: 2556
public class RandomizerChaosVelocityVector : RandomizerChaosEffect
{
	// Token: 0x0600381A RID: 14362
	public override void Clear()
	{
		this.Countdown = 0;
		this.Pushing = false;
	}

	// Token: 0x0600381B RID: 14363
	public override void Start()
	{
		this.Countdown = UnityEngine.Random.Range(1, 300);
		this.Pushing = false;
		int num = UnityEngine.Random.Range(0, 8);
		if (num <= 6)
		{
			Randomizer.showChaosEffect("Throw");
			Characters.Sein.PlatformBehaviour.PlatformMovement.LocalSpeedX = UnityEngine.Random.Range(-100f, 100f);
			Characters.Sein.PlatformBehaviour.PlatformMovement.LocalSpeedY = UnityEngine.Random.Range(-100f, 100f);
			return;
		}
		if (num <= 7)
		{
			Randomizer.showChaosEffect("Push");
			this.Pushing = true;
			this.Push = new Vector2(UnityEngine.Random.Range(-40f, 40f), UnityEngine.Random.Range(-40f, 40f));
		}
	}

	// Token: 0x0600381C RID: 14364
	public override void Update()
	{
		if (this.Countdown > 0)
		{
			this.Countdown--;
			if (this.Countdown == 0)
			{
				this.Clear();
			}
			if (this.Pushing)
			{
				Characters.Sein.PlatformBehaviour.PlatformMovement.LocalSpeedX = this.Push.x;
				Characters.Sein.PlatformBehaviour.PlatformMovement.LocalSpeedY = this.Push.y;
			}
		}
	}

	// Token: 0x040032D4 RID: 13012
	public int Countdown;

	// Token: 0x040032D5 RID: 13013
	public bool Pushing;

	// Token: 0x040032D6 RID: 13014
	public Vector2 Push;
}
