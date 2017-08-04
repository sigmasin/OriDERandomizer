using System;
using Game;
using Sein.World;

public static class RandomizerBonus
{
	public static void UpgradeID(int ID)
	{
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
			Randomizer.showHint("Spirit Light Efficiency");
			break;
		case 13:
			Randomizer.showHint("Charge Flame Efficiency");
			break;
		case 14:
			Randomizer.showHint("Extra Air Dash");
			break;
		case 15:
			Randomizer.showHint("Charge Dash Efficiency");
			break;
		case 16:
			Randomizer.showHint("Extra Double Jump");
			break;
		case 17:
			Randomizer.showHint("Health Regeneration");
			break;
		case 19:
			Randomizer.showHint("Energy Regeneration");
			break;
        case 21:
            if (RandomizerBonus.WaterVeinShards() >= 2)
            {
                Randomizer.showHint("Water Vein Shard (3/3)");
                Keys.GinsoTree = true;
            }
            else 
            {
                Characters.Sein.Inventory.SkillPointsCollected += 1 << ID;
                Randomizer.showHint("Water Vein Shard (" + RandomizerBonus.WaterVeinShards().ToString() + "/3)");
            }
            break;
        case 23:
            if (RandomizerBonus.GumonSealShards() >= 2)
            {
                Randomizer.showHint("Gumon Seal Shard (3/3)");
                Keys.ForlornRuins = true;
            }
            else 
            {
                Characters.Sein.Inventory.SkillPointsCollected += 1 << ID;
                Randomizer.showHint("Gumon Seal Shard (" + RandomizerBonus.GumonSealShards().ToString() + "/3)");
            }
            break;
        case 25:
            if (RandomizerBonus.SunstoneShards() >= 2)
            {
                Randomizer.showHint("Sunstone Shard (3/3)");
                Keys.MountHoru = true;
            }
            else 
            {
                Characters.Sein.Inventory.SkillPointsCollected += 1 << ID;
                Randomizer.showHint("Sunstone Shard (" + RandomizerBonus.SunstoneShards().ToString() + "/3)");
            }
            break;
		}
		if (ID > 1 && ID < 21)
		{
			Characters.Sein.Inventory.SkillPointsCollected += 1 << ID;
		}
	}

	public static int SpiritFlameStrength()
	{
		return ((Characters.Sein.Inventory.SkillPointsCollected & 0x000000c0) >> 6) * 2;
	}

	public static int SpiritFlameTargets()
	{
        int value = (Characters.Sein.Inventory.SkillPointsCollected & 0x00000300) >> 8;
        if (value == 3)
        {
            return 4;
        }
        return value;
	}

	public static float GrenadePower()
	{
		return (float)((Characters.Sein.Inventory.SkillPointsCollected & 0x00000c00) >> 10) * 2f;
	}

	public static bool ExpEfficiency()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00001000) >> 12 == 1;
	}

	public static bool ChargeFlameEfficiency()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00002000) >> 13 == 1;
	}

	public static bool DoubleAirDash()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00004000) >> 14 == 1;
	}
    
    public static bool DoubleAirDashUsed = false;

	public static bool ChargeDashEfficiency()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00008000) >> 15 == 1;
	}

	public static bool DoubleJumpUpgrade()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00010000) >> 16 == 1;
	}

	public static int HealthRegeneration()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00060000) >> 17;
	}

	public static int EnergyRegeneration()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00180000) >> 19;
	}
    
    public static int WaterVeinShards()
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x00600000) >> 21;
    }
    
    public static int GumonSealShards()
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x01800000) >> 23;
    } 
    
    public static int SunstoneShards()
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x06000000) >> 25;
    }
    

}