using System;
using Game;
using Sein.World;

// Token: 0x020009F3 RID: 2547
public static class RandomizerBonus
{
    // Token: 0x0600375D RID: 14173
    public static void UpgradeID(int ID)
    {
        bool flag = ID < 0;
        if (flag)
        {
            ID = -ID;
        }
        if (ID >= 100)
        {
            RandomizerBonusSkill.FoundBonusSkill(ID);
            return;
        }
        switch (ID)
        {
        case 0:
            if (!flag)
            {
                Characters.Sein.Mortality.Health.SetAmount((float)(Characters.Sein.Mortality.Health.MaxHealth + 20));
                Randomizer.showHint("Mega Health");
                return;
            }
            break;
        case 1:
            if (!flag)
            {
                Characters.Sein.Energy.SetCurrent(Characters.Sein.Energy.Max + 5f);
                Randomizer.showHint("Mega Energy");
                return;
            }
            break;
        case 2:
            Randomizer.returnToStart();
            Randomizer.showHint("Go Home!");
            return;
        case 3:
        case 4:
        case 5:
        case 7:
        case 14:
        case 16:
        case 18:
        case 20:
            break;
        case 6:
            if (!flag)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Spirit Flame Upgrade x" + RandomizerBonus.SpiritFlameLevel().ToString());
                return;
            }
            if (RandomizerBonus.SpiritFlameLevel() > 0)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                Randomizer.showHint("Spirit Flame Upgrade x" + RandomizerBonus.SpiritFlameLevel().ToString());
                return;
            }
            break;
        case 8:
            Randomizer.showHint("Explosion Power Upgrade");
            if (!RandomizerBonus.ExplosionPower())
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                return;
            }
            break;
        case 9:
            Randomizer.showHint("Spirit Light Efficiency");
            if (!RandomizerBonus.ExpEfficiency())
            {
                Characters.Sein.Inventory.SetRandomizerItem(ID, 1);
                return;
            }
            break;
        case 10:
            Randomizer.showHint("Extra Air Dash");
            if (!RandomizerBonus.DoubleAirDash())
            {
                Characters.Sein.Inventory.SetRandomizerItem(ID, 1);
                return;
            }
            break;
        case 11:
            Randomizer.showHint("Charge Dash Efficiency");
            if (!RandomizerBonus.ChargeDashEfficiency())
            {
                Characters.Sein.Inventory.SetRandomizerItem(ID, 1);
                return;
            }
            break;
        case 12:
            if (!flag)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Extra Double Jump x" + RandomizerBonus.DoubleJumpUpgrades().ToString());
                return;
            }
            if (RandomizerBonus.DoubleJumpUpgrades() > 0)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                Randomizer.showHint("Extra Double Jump x" + RandomizerBonus.DoubleJumpUpgrades().ToString());
                return;
            }
            break;
        case 13:
            if (!flag)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Health Regeneration x" + RandomizerBonus.HealthRegeneration().ToString());
                return;
            }
            if (RandomizerBonus.HealthRegeneration() > 0)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                Randomizer.showHint("Health Regeneration x" + RandomizerBonus.HealthRegeneration().ToString());
                return;
            }
            break;
        case 15:
            if (!flag)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Energy Regeneration x" + RandomizerBonus.EnergyRegeneration().ToString());
                return;
            }
            if (RandomizerBonus.EnergyRegeneration() > 0)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                Randomizer.showHint("Energy Regeneration x" + RandomizerBonus.EnergyRegeneration().ToString());
                return;
            }
            break;
        case 17:
            if (flag)
            {
                if (RandomizerBonus.WaterVeinShards() > 0)
                {
                    Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                    Characters.Sein.Inventory.SkillPointsCollected -= 1 << ID;
                    Randomizer.showHint("*Water Vein Shard (" + RandomizerBonus.WaterVeinShards().ToString() + "/3)*");
                }
            }
            else if (RandomizerBonus.WaterVeinShards() >= 3)
            {
                Randomizer.showHint("*Water Vein Shard (extra)*");
            }
            else
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Characters.Sein.Inventory.SkillPointsCollected += 1 << ID;
                Randomizer.showHint("*Water Vein Shard (" + RandomizerBonus.WaterVeinShards().ToString() + "/3)*");
            }
            Keys.GinsoTree = (RandomizerBonus.WaterVeinShards() >= 3);
            return;
        case 19:
            if (flag)
            {
                if (RandomizerBonus.GumonSealShards() > 0)
                {
                    Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                    Characters.Sein.Inventory.SkillPointsCollected -= 1 << ID;
                    Randomizer.showHint("#Gumon Seal Shard (" + RandomizerBonus.GumonSealShards().ToString() + "/3)#");
                }
            }
            else if (RandomizerBonus.GumonSealShards() >= 3)
            {
                Randomizer.showHint("#Gumon Seal Shard (extra)#");
            }
            else
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Characters.Sein.Inventory.SkillPointsCollected += 1 << ID;
                Randomizer.showHint("#Gumon Seal Shard (" + RandomizerBonus.GumonSealShards().ToString() + "/3)#");
            }
            Keys.ForlornRuins = (RandomizerBonus.GumonSealShards() >= 3);
            return;
        case 21:
            if (flag)
            {
                if (RandomizerBonus.SunstoneShards() > 0)
                {
                    Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                    Characters.Sein.Inventory.SkillPointsCollected -= 1 << ID;
                    Randomizer.showHint("@Sunstone Shard (" + RandomizerBonus.SunstoneShards().ToString() + "/3)@");
                }
            }
            else if (RandomizerBonus.SunstoneShards() >= 3)
            {
                Randomizer.showHint("@Sunstone Shard (extra)@");
            }
            else
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Characters.Sein.Inventory.SkillPointsCollected += 1 << ID;
                Randomizer.showHint("@Sunstone Shard (" + RandomizerBonus.SunstoneShards().ToString() + "/3)@");
            }
            Keys.MountHoru = (RandomizerBonus.SunstoneShards() >= 3);
            return;
        default:
            return;
        }
    }

    // Token: 0x0600375E RID: 14174
    public static bool DoubleAirDash()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(10) > 0;
    }

    // Token: 0x0600375F RID: 14175
    public static bool ChargeDashEfficiency()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(11) > 1;
    }

    // Token: 0x06003760 RID: 14176
    public static bool DoubleJumpUpgrade()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(12) > 0;
    }

    // Token: 0x06003761 RID: 14177
    public static int HealthRegeneration()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(13);
    }

    // Token: 0x06003762 RID: 14178
    public static int EnergyRegeneration()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(15);
    }

    // Token: 0x06003763 RID: 14179
    static RandomizerBonus()
    {
    }

    // Token: 0x06003764 RID: 14180
    public static int WaterVeinShards()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(17);
    }

    // Token: 0x06003765 RID: 14181
    public static int SunstoneShards()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(21);
    }

    // Token: 0x06003766 RID: 14182
    public static int GumonSealShards()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(19);
    }

    // Token: 0x06003767 RID: 14183
    public static int SpiritFlameLevel()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(6);
    }

    // Token: 0x06003768 RID: 14184
    public static int MapStoneProgression()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(23);
    }

    // Token: 0x06003769 RID: 14185
    public static int SkillTreeProgression()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(27);
    }

    // Token: 0x0600376A RID: 14186
    public static bool ExplosionPower()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(8) > 0;
    }

    // Token: 0x0600376B RID: 14187
    public static bool ExpEfficiency()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(9) > 0;
    }

    // Token: 0x0600376C RID: 14188
    public static void CollectPickup()
    {
        Characters.Sein.Inventory.IncRandomizerItem(0, 1);
    }

    // Token: 0x0600376D RID: 14189
    public static int GetPickupCount()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(0);
    }

    // Token: 0x0600376E RID: 14190
    public static int DoubleJumpUpgrades()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(12);
    }

    // Token: 0x0600376F RID: 14191
    public static int UpgradeCount(int ID)
    {
        return Characters.Sein.Inventory.GetRandomizerItem(ID);
    }

    public static bool GinsoEscapeDone()
    {
        return RandomizerBonus.UpgradeCount(300) > 0;
    }

    public static bool ForlornEscapeDone()
    {
        return RandomizerBonus.UpgradeCount(301) > 0;
    }

    // Token: 0x06003770 RID: 14192
    public static void CollectMapstone()
    {
        Characters.Sein.Inventory.IncRandomizerItem(23, 1);
        Characters.Sein.Inventory.SkillPointsCollected += 8388608;
        RandomizerBonus.CollectPickup();
    }

    // Token: 0x0400324A RID: 12874
    public static bool DoubleAirDashUsed;
}
