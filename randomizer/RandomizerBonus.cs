using System;
using Game;
using Sein.World;
using UnityEngine;

// Token: 0x020009F7 RID: 2551
public static class RandomizerBonus
{
    // Token: 0x06003769 RID: 14185 RVA: 0x000E1BD8 File Offset: 0x000DFDD8
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
        case 22:
        case 23:
        case 24:
        case 25:
        case 26:
        case 27:
        case 28:
            if (!flag)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                int frags = RandomizerBonus.WarmthFrags();
                Randomizer.showHint(@"Warmth Fragment (" + frags .ToString() + "/" + Randomizer.fragKeyFinish + ")@");
                if(Randomizer.fragDungeon)
                {
                    if(frags == Randomizer.fragKey1) {
                            RandomizerBonus.GrantDungeonKey(Randomizer.fragDungeonOrder[0]);
                    }
                    if(frags == Randomizer.fragKey2) {
                            RandomizerBonus.GrantDungeonKey(Randomizer.fragDungeonOrder[1]);
                    }
                    if(frags == Randomizer.fragKey3) {
                            RandomizerBonus.GrantDungeonKey(Randomizer.fragDungeonOrder[2]);
                    }

                }
                return;
            }
            if (RandomizerBonus.WarmthFrags() > 0)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                Randomizer.showHint(@"Warmth Fragment (" + RandomizerBonus.WarmthFrags().ToString() + "/" + Randomizer.fragKeyFinish + ")@");
                return;
            }
            break;
        case 29:
            return;
        case 30:
            if (!flag)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Bleeding x" + RandomizerBonus.Bleeding().ToString());
                return;
            }
            if (RandomizerBonus.Bleeding() > 0)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                Randomizer.showHint("Bleeding x" + RandomizerBonus.Bleeding().ToString());
                return;
            }
            break;
        case 31:
            if (!flag)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Lifesteal x" + RandomizerBonus.Lifesteal().ToString());
                return;
            }
            if (RandomizerBonus.Lifesteal() > 0)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                Randomizer.showHint("Lifesteal x" + RandomizerBonus.Lifesteal().ToString());
                return;
            }
            break;
        case 32:
            if (!flag)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Manavamp x" + RandomizerBonus.Manavamp().ToString());
                return;
            }
            if (RandomizerBonus.Manavamp() > 0)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                Randomizer.showHint("Manavamp x" + RandomizerBonus.Manavamp().ToString());
                return;
            }
            break;
        case 33:
            if (!flag)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Skill Velocity Upgrade x" + RandomizerBonus.Velocity().ToString());
                return;
            }
            if (RandomizerBonus.Velocity() > 0)
            {
                Characters.Sein.Inventory.IncRandomizerItem(ID, -1);
                Randomizer.showHint("Skill Velocity Upgrade x" + RandomizerBonus.Velocity().ToString());
                return;
            }
            break;
        default:
            return;
        }
    }

    // Token: 0x0600376A RID: 14186 RVA: 0x0002B52C File Offset: 0x0002972C
    public static bool DoubleAirDash()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(10) > 0;
    }

    // Token: 0x0600376B RID: 14187 RVA: 0x0002B542 File Offset: 0x00029742
    public static bool ChargeDashEfficiency()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(11) > 1;
    }

    // Token: 0x0600376C RID: 14188 RVA: 0x0002B558 File Offset: 0x00029758
    public static bool DoubleJumpUpgrade()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(12) > 0;
    }

    // Token: 0x0600376D RID: 14189 RVA: 0x0002B56E File Offset: 0x0002976E
    public static int HealthRegeneration()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(13);
    }

    // Token: 0x0600376E RID: 14190 RVA: 0x0002B581 File Offset: 0x00029781
    public static int EnergyRegeneration()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(15);
    }

    // Token: 0x0600376F RID: 14191 RVA: 0x000028E7 File Offset: 0x00000AE7
    static RandomizerBonus()
    {
    }

    // Token: 0x06003770 RID: 14192 RVA: 0x0002B594 File Offset: 0x00029794
    public static int WaterVeinShards()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(17);
    }

    // Token: 0x06003771 RID: 14193 RVA: 0x0002B5A7 File Offset: 0x000297A7
    public static int SunstoneShards()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(21);
    }

    // Token: 0x06003772 RID: 14194 RVA: 0x0002B5BA File Offset: 0x000297BA
    public static int GumonSealShards()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(19);
    }

    // Token: 0x06003773 RID: 14195 RVA: 0x0002B5CD File Offset: 0x000297CD
    public static int SpiritFlameLevel()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(6);
    }

    // Token: 0x06003774 RID: 14196 RVA: 0x0002B5DF File Offset: 0x000297DF
    public static int MapStoneProgression()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(23);
    }

    // Token: 0x06003775 RID: 14197 RVA: 0x0002B5F2 File Offset: 0x000297F2
    public static int SkillTreeProgression()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(27);
    }

    // Token: 0x06003776 RID: 14198 RVA: 0x0002B605 File Offset: 0x00029805
    public static bool ExplosionPower()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(8) > 0;
    }

    // Token: 0x06003777 RID: 14199 RVA: 0x0002B61A File Offset: 0x0002981A
    public static bool ExpEfficiency()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(9) > 0;
    }

    // Token: 0x06003778 RID: 14200 RVA: 0x0002B630 File Offset: 0x00029830
    public static void CollectPickup()
    {
        Characters.Sein.Inventory.IncRandomizerItem(0, 1);
    }

    // Token: 0x06003779 RID: 14201 RVA: 0x0002B643 File Offset: 0x00029843
    public static int GetPickupCount()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(0);
    }

    // Token: 0x0600377A RID: 14202 RVA: 0x0002B655 File Offset: 0x00029855
    public static int DoubleJumpUpgrades()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(12);
    }

    // Token: 0x0600377B RID: 14203 RVA: 0x0002B668 File Offset: 0x00029868
    public static int UpgradeCount(int ID)
    {
        return Characters.Sein.Inventory.GetRandomizerItem(ID);
    }

    // Token: 0x0600377C RID: 14204 RVA: 0x0002B67A File Offset: 0x0002987A
    public static void CollectMapstone()
    {
        Characters.Sein.Inventory.IncRandomizerItem(23, 1);
        Characters.Sein.Inventory.SkillPointsCollected += 8388608;
        RandomizerBonus.CollectPickup();
    }

    // Token: 0x0600377D RID: 14205 RVA: 0x0002B6AE File Offset: 0x000298AE
    public static bool GinsoEscapeDone()
    {
        return RandomizerBonus.UpgradeCount(300) > 0;
    }

    // Token: 0x0600377E RID: 14206 RVA: 0x0002B6BD File Offset: 0x000298BD
    public static bool ForlornEscapeDone()
    {
        return RandomizerBonus.UpgradeCount(301) > 0;
    }

    // Token: 0x0600377F RID: 14207 RVA: 0x000E2368 File Offset: 0x000E0568
    public static void Update()
    {
        Characters.Sein.Mortality.Health.GainHealth((float)RandomizerBonus.HealthRegeneration() * (Characters.Sein.PlayerAbilities.HealthEfficiency.HasAbility ? 0.0016f : 0.0008f));
        Characters.Sein.Mortality.Health.LoseHealth((float)RandomizerBonus.Bleeding() * 0.0008f);
        if (RandomizerBonus.Bleeding() > 0 && Characters.Sein.Mortality.Health.Amount <= 0f)
        {
            Characters.Sein.Mortality.DamageReciever.OnRecieveDamage(new Damage(1f, default(Vector2), default(Vector3), DamageType.Water, null));
        }
        Characters.Sein.Energy.Gain((float)RandomizerBonus.EnergyRegeneration() * (Characters.Sein.PlayerAbilities.EnergyEfficiency.HasAbility ? 0.0003f : 0.0002f));
        RandomizerBonusSkill.Update();
    }

    // Token: 0x06003780 RID: 14208 RVA: 0x000E2464 File Offset: 0x000E0664
    public static void DamageDealt(float damage)
    {
        if (Characters.Sein)
        {
            if (damage > 20f)
            {
                damage = 20f;
            }
            Characters.Sein.Mortality.Health.GainHealth((float)RandomizerBonus.Lifesteal() * 0.2f * damage);
            Characters.Sein.Energy.Gain((float)RandomizerBonus.Manavamp() * 0.2f * damage);
        }
    }
    public static int WarmthFrags()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(28);
    }

    // Token: 0x06003781 RID: 14209 RVA: 0x0002B6CC File Offset: 0x000298CC
    public static int Bleeding()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(30);
    }

    // Token: 0x06003782 RID: 14210 RVA: 0x0002B6DF File Offset: 0x000298DF
    public static int Lifesteal()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(31);
    }

    // Token: 0x06003783 RID: 14211 RVA: 0x0002B6F2 File Offset: 0x000298F2
    public static int Manavamp()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(32);
    }

    // Token: 0x06003784 RID: 14212 RVA: 0x0002B705 File Offset: 0x00029905
    public static int Velocity()
    {
        return Characters.Sein.Inventory.GetRandomizerItem(33);
    }
    public static void GrantDungeonKey(int dungeonId) 
    {
        if(dungeonId == 0)
        {
            Keys.GinsoTree = true;
            Randomizer.showHint("*Ginso Tree Unlocked*");
        }
        else if(dungeonId == 1)
        {
            Keys.ForlornRuins = true;
            Randomizer.showHint("%Forlorn Ruins Unlocked%");
        }
        else if(dungeonId == 2)
        {
            Keys.MountHoru = true;
            Randomizer.showHint("@Mount Horu Unlocked@");
        }
    }

    // Token: 0x04003251 RID: 12881
    public static bool DoubleAirDashUsed;
}
