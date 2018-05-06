    using System;
    using Game;
    using Sein.World;
    using System.Collections.Generic;

    public static class RandomizerBonus
    {
        public static int UpgradeCount(int ID) 
        {
               return Characters.Sein.Inventory.GetRandomizerItem(ID);
        }
        public static void UpgradeID(int ID)
        {
            bool remove = ID < 0; 
            if(remove) {
                ID = -ID;
            }
            if(ID >= 100) 
            {
                if(!RandomizerBonusSkill.UnlockedBonusSkills.Contains(ID))
                {
                    RandomizerBonusSkill.UnlockedBonusSkills.Add(ID);
                    RandomizerBonusSkill.ActiveBonus = ID;
                    RandomizerBonusSkill.PlayMessage();
                }
                return;
            }
            switch (ID)
            {
            case 0:
                if(remove) {
                    break;
                }
                Characters.Sein.Mortality.Health.SetAmount((float)(Characters.Sein.Mortality.Health.MaxHealth + 20));
                Randomizer.showHint("Mega Health");
                break;
            case 1:
                if(remove) {
                    break;
                }
                Characters.Sein.Energy.SetCurrent(Characters.Sein.Energy.Max + 5f);
                Randomizer.showHint("Mega Energy");
                break;
            case 2:
                Randomizer.returnToStart();
                Randomizer.showHint("Go Home!");
                break;
            case 6:
                if(remove) {
                     if(RandomizerBonus.SpiritFlameLevel() > 0) {
                            Characters.Sein.Inventory.IncRandomizerItem(-ID, 1);
                            Randomizer.showHint("Spirit Flame Upgrade x" + RandomizerBonus.SpiritFlameLevel().ToString());                
                    }
                    break;
                }
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Spirit Flame Upgrade x" + RandomizerBonus.SpiritFlameLevel().ToString());
                break;
            case 8:
                Randomizer.showHint("Explosion Power Upgrade");
                if (!RandomizerBonus.ExplosionPower()) 
                {
                    Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                }
                break;
            case 9:
                Randomizer.showHint("Spirit Light Efficiency");
                if (!RandomizerBonus.ExpEfficiency()) 
                {
                    Characters.Sein.Inventory.SetRandomizerItem(ID, 1);
                }
                break;
            case 10:
                if (!RandomizerBonus.DoubleAirDash()) 
                {
                    Randomizer.showHint("Extra Air Dash");
                    Characters.Sein.Inventory.SetRandomizerItem(ID, 1);
                }
                break;
            case 11:
                if (!RandomizerBonus.ChargeDashEfficiency()) 
                {
                    Randomizer.showHint("Charge Dash Efficiency");
                    Characters.Sein.Inventory.SetRandomizerItem(ID, 1);
                }
                break;
            case 12:
                if(remove)
                    {
                    if (RandomizerBonus.DoubleJumpUpgrades() > 0) 
                    {
                        Characters.Sein.Inventory.IncRandomizerItem(-ID, -1);                
                        Randomizer.showHint("Extra Double Jump x" + RandomizerBonus.DoubleJumpUpgrades().ToString());
                    }
                    break;                
                }
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Extra Double Jump x" + RandomizerBonus.DoubleJumpUpgrades().ToString());
                break;
            case 13:
                if(remove) {
                    if (RandomizerBonus.HealthRegeneration() > 0) 
                    {
                        Characters.Sein.Inventory.IncRandomizerItem(-ID, -1);
                        Randomizer.showHint("Health Regeneration x" + RandomizerBonus.HealthRegeneration().ToString());
                    }
                    break;                
                }
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Health Regeneration x" + RandomizerBonus.HealthRegeneration().ToString());
                break;
            case 15:
                if(remove) {
                    if (RandomizerBonus.EnergyRegeneration() > 0)
                    {
                        Characters.Sein.Inventory.IncRandomizerItem(-ID, -1);
                        Randomizer.showHint("Energy Regeneration x" + RandomizerBonus.EnergyRegeneration().ToString());
                    }
                    break;
                }
                Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                Randomizer.showHint("Energy Regeneration x" + RandomizerBonus.EnergyRegeneration().ToString());
                break;
            case 17:
                if(remove) {
                    if(RandomizerBonus.WaterVeinShards() > 0)
                    {
                        Characters.Sein.Inventory.IncRandomizerItem(-ID, -1);
                        Keys.GinsoTree = false;
                        Randomizer.showHint("*Water Vein Shard (" + RandomizerBonus.WaterVeinShards().ToString() + "/3)*");
                    }
                    break;                
                }
                if (RandomizerBonus.WaterVeinShards() >= 3)
                {
                    Randomizer.showHint("*Water Vein Shard (extra)*");
                }
                else 
                {
                    Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                    Randomizer.showHint("*Water Vein Shard (" + RandomizerBonus.WaterVeinShards().ToString() + "/3)*");
                    if (RandomizerBonus.WaterVeinShards() == 3)
                    {
                        Keys.GinsoTree = true;
                        Randomizer.showHint("*Water Vein Shard (3/3)*");
                    }
                }
                break;
            case 19:
                if(remove)
                {
                    if(RandomizerBonus.GumonSealShards() > 0)
                    {
                        Characters.Sein.Inventory.IncRandomizerItem(-ID, -1);
                        Keys.ForlornRuins = false;
                        Randomizer.showHint("#Gumon Seal Shard (" + RandomizerBonus.GumonSealShards().ToString() + "/3)#");
                    }
                    break;                
                }
                if (RandomizerBonus.GumonSealShards() >= 3)
                {
                    Randomizer.showHint("#Gumon Seal Shard (extra)#");
                }
                else 
                {
                    Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                    Randomizer.showHint("#Gumon Seal Shard (" + RandomizerBonus.GumonSealShards().ToString() + "/3)#");
                    if (RandomizerBonus.GumonSealShards() == 3)
                    {
                        Keys.ForlornRuins = true;
                    }
                }
                break;
            case 21:
                if(remove) {
                    if(RandomizerBonus.GumonSealShards() > 0)
                    {
                        Characters.Sein.Inventory.IncRandomizerItem(-ID, -1);
                        Keys.MountHoru = false;
                        Randomizer.showHint("@Sunstone Shard (" + RandomizerBonus.SunstoneShards().ToString() + "/3)@");
                    }                    
                }
                if (RandomizerBonus.SunstoneShards() >= 3)
                {
                    Randomizer.showHint("@Sunstone Shard (extra)@");
                }
                else 
                {
                    Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
                    Randomizer.showHint("@Sunstone Shard (" + RandomizerBonus.SunstoneShards().ToString() + "/3)@");
                    if (RandomizerBonus.SunstoneShards() == 3)
                    {
                        Keys.MountHoru = true;
                    }
                }
                break;
            break;
        }
    }

        public static int SpiritFlameLevel()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(6);
        }
        
        public static bool ExplosionPower() 
        {
            return Characters.Sein.Inventory.GetRandomizerItem(8) > 0;
        }
        
        public static bool ExpEfficiency() 
        {
            return Characters.Sein.Inventory.GetRandomizerItem(9) > 0;
        }
        
        public static bool DoubleAirDash()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(10) > 0;
        }
        
        public static bool DoubleAirDashUsed = false;

        public static bool ChargeDashEfficiency()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(11) > 1;
        }

        public static bool DoubleJumpUpgrade()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(12) > 0;
        }

        public static int DoubleJumpUpgrades()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(12);
        }

        public static int HealthRegeneration()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(13);
        }

        public static int EnergyRegeneration()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(15);
        }
        
        public static int WaterVeinShards()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(17);
        }
        
        public static int GumonSealShards()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(19);
        } 
        
        public static int SunstoneShards()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(21);
        }
        
        public static int MapStoneProgression()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(23);
        }
        
        public static int SkillTreeProgression()
        {
            return Characters.Sein.Inventory.GetRandomizerItem(27);
        }

        public static void CollectMapstone() {
            Characters.Sein.Inventory.IncRandomizerItem(23, 1);
            CollectPickup();
        }
        
        public static void CollectPickup() {
            Characters.Sein.Inventory.IncRandomizerItem(0, 1);
        }
        
        public static int GetPickupCount() {
            return Characters.Sein.Inventory.GetRandomizerItem(0);
        }

    }