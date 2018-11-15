using System;
using Game;

// Token: 0x02000189 RID: 393
public class SeinAbilityCondition : Condition
{
	// Token: 0x0600086D RID: 2157 RVA: 0x00004BC2 File Offset: 0x00002DC2
	public SeinAbilityCondition()
	{
	}

	// Token: 0x0600086E RID: 2158
	public override bool Validate(IContext context)
	{
		return !(Characters.Sein == null) && (Characters.Sein.PlayerAbilities.HasAbility(this.Ability) || (this.Ability == AbilityType.Stomp && !Randomizer.OpenWorld)) && (this.Ability != AbilityType.Stomp || !Randomizer.OpenWorld);
	}

	// Token: 0x0400083D RID: 2109
	public AbilityType Ability;
}
