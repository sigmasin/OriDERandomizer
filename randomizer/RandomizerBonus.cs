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
			Randomizer.showHint("Spirit Flame Upgrade");
			break;
		case 8:
			Randomizer.showHint("Explosion Power Upgrade");
			break;
		case 9:
			Randomizer.showHint("Spirit Light Efficiency");
			break;
		case 10:
			Randomizer.showHint("Extra Air Dash");
			break;
		case 11:
			Randomizer.showHint("Charge Dash Efficiency");
			break;
		case 12:
			Randomizer.showHint("Extra Double Jump");
			break;
		case 13:
			Randomizer.showHint("Health Regeneration");
			break;
		case 15:
			Randomizer.showHint("Energy Regeneration");
			break;
        case 17:
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
        case 19:
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
        case 21:
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
		if (ID > 1 && ID < 17)
		{
			Characters.Sein.Inventory.SkillPointsCollected += 1 << ID;
		}
	}

    public static int SpiritFlameLevel()
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x000000c0) >> 6;
    }
    
    public static bool ExplosionPower() 
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x00000100) >> 8 == 1;
    }
    
    public static bool ExpEfficiency() 
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x00000200) >> 9 == 1;
    }
    
    //remove
    public static bool GrenadePower()
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x00000100) >> 8 == 1;
    }

    //remove
    public static bool ChargeFlameUpgrade()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00000200) >> 9 == 1;
	}
    
	public static bool DoubleAirDash()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00000400) >> 10 == 1;
	}
    
    public static bool DoubleAirDashUsed = false;

	public static bool ChargeDashEfficiency()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00000800) >> 11 == 1;
	}

	public static bool DoubleJumpUpgrade()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00001000) >> 12 == 1;
	}

	public static int HealthRegeneration()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00006000) >> 13;
	}

	public static int EnergyRegeneration()
	{
		return (Characters.Sein.Inventory.SkillPointsCollected & 0x00018000) >> 15;
	}
    
    public static int WaterVeinShards()
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x00060000) >> 17;
    }
    
    public static int GumonSealShards()
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x00180000) >> 19;
    } 
    
    public static int SunstoneShards()
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x00600000) >> 21;
    }
    
    public static int MapStoneProgression()
    {
        return (Characters.Sein.Inventory.SkillPointsCollected & 0x07800000) >> 23;
    }
    
    public static int SkillTreeProgression()
    {
        return (int)(Characters.Sein.Inventory.SkillPointsCollected & 0x78000000) >> 27;
    }
    

}