using System;
using Game;

// Token: 0x020009F1 RID: 2545
public static class RandomizerBonus
{
	// Token: 0x06003748 RID: 14152
	public static void UpgradeID(int ID)
	{
		if (!Randomizer.BonusActive)
		{
			Randomizer.showHint("Nothing");
			return;
		}
		switch (ID)
		{
		case 0:
			Characters.Sein.Mortality.Health.SetAmount((float)(Characters.Sein.Mortality.Health.MaxHealth + 20));
			Randomizer.showHint("Mega Health");
			break;
		case 1:
			Characters.Sein.Energy.SetCurrent(Characters.Sein.Energy.Max + 5f);
			Randomizer.showHint("Mega Energy");
			break;
		case 6:
			Randomizer.showHint("Spirit Flame Damage Upgrade");
			break;
		case 8:
			Randomizer.showHint("Split Flame Upgrade");
			break;
		case 10:
			Randomizer.showHint("Grenade Power Upgrade");
			break;
		case 12:
			Randomizer.showHint("Health Efficiency");
			break;
		case 13:
			Randomizer.showHint("Energy Efficiency");
			break;
		case 14:
			Randomizer.showHint("Spirit Light Efficiency");
			break;
		case 15:
			Randomizer.showHint("Spirit Link Heal Upgrade");
			break;
		case 16:
			Randomizer.showHint("Charge Flame Efficiency");
			break;
		case 17:
			Randomizer.showHint("Extra Air Dash");
			break;
		case 18:
			Randomizer.showHint("Charge Dash Efficiency");
			break;
		case 19:
			Randomizer.showHint("Extra Double Jump");
			break;
		case 20:
			Randomizer.showHint("Health Regeneration");
			break;
		case 22:
			Randomizer.showHint("Energy Regeneration");
			break;
		}
		if (ID > 1)
		{
			Characters.Sein.Inventory.SkillPointsCollected += 1 << ID;
		}
	}

	// Token: 0x06003749 RID: 14153 RVA: 0x0002B489 File Offset: 0x00029689
	public static int SpiritFlameStrength()
	{
		return ((Characters.Sein.Inventory.SkillPointsCollected & 192) >> 6) * 2;
	}

	// Token: 0x0600374A RID: 14154 RVA: 0x000E0714 File Offset: 0x000DE914
	public static int SpiritFlameTargets()
	{
		int num = (Characters.Sein.Inventory.SkillPointsCollected & 768) >> 8;
		if (num == 3)
		{
			return 4;
		}
		return num;
	}

	// Token: 0x0600374B RID: 14155 RVA: 0x0002B4A4 File Offset: 0x000296A4
	public static bool HealthEfficiency()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 4096) >> 12 == 1;
	}

	// Token: 0x0600374C RID: 14156 RVA: 0x0002B4C1 File Offset: 0x000296C1
	public static bool EnergyEfficiency()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 8192) >> 13 == 1;
	}

	// Token: 0x0600374D RID: 14157 RVA: 0x0002B4DE File Offset: 0x000296DE
	public static bool ExpEfficiency()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 16384) >> 14 == 1;
	}

	// Token: 0x0600374E RID: 14158 RVA: 0x0002B4FB File Offset: 0x000296FB
	public static bool SoulLinkHeal()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 32768) >> 15 == 1;
	}

	// Token: 0x0600374F RID: 14159 RVA: 0x0002B518 File Offset: 0x00029718
	public static bool ChargeFlameEfficiency()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 65536) >> 16 == 1;
	}

	// Token: 0x06003750 RID: 14160 RVA: 0x0002B535 File Offset: 0x00029735
	public static bool DoubleAirDash()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 131072) >> 17 == 1;
	}

	// Token: 0x06003751 RID: 14161 RVA: 0x0002B552 File Offset: 0x00029752
	public static bool ChargeDashEfficiency()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 262144) >> 18 == 1;
	}

	// Token: 0x06003752 RID: 14162 RVA: 0x0002B56F File Offset: 0x0002976F
	public static bool DoubleJumpUpgrade()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 524288) >> 19 == 1;
	}

	// Token: 0x06003753 RID: 14163 RVA: 0x0002B58C File Offset: 0x0002978C
	public static int HealthRegeneration()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 3145728) >> 20;
	}

	// Token: 0x06003754 RID: 14164 RVA: 0x0002B5A6 File Offset: 0x000297A6
	public static int EnergyRegeneration()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 12582912) >> 22;
	}

	// Token: 0x06003755 RID: 14165 RVA: 0x0002B5C0 File Offset: 0x000297C0
	public static float GrenadePower()
	{
		return (float)((Characters.Sein.Inventory.SkillPointsCollected & 3072) >> 10) * 5f;
	}

	// Token: 0x04003229 RID: 12841
	public static bool DoubleAirDashUsed;
}
