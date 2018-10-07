using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

// Token: 0x02000A0F RID: 2575
public static class RandomizerBonusSkill
{
    // Token: 0x060037F8 RID: 14328 RVA: 0x000E5A10 File Offset: 0x000E3C10
    public static void SwitchBonusSkill()
    {
        if (RandomizerBonusSkill.UnlockedBonusSkills.Count < 1)
        {
            RandomizerBonusSkill.Reset();
            if (RandomizerBonusSkill.UnlockedBonusSkills.Count < 1)
            {
                Randomizer.MessageQueue.Enqueue("No bonus skills unlocked!");
                return;                
            }
        }
        RandomizerBonusSkill.ActiveBonus = (RandomizerBonusSkill.ActiveBonus + 1) % RandomizerBonusSkill.UnlockedBonusSkills.Count;
        Randomizer.MessageQueue.Enqueue("Active Bonus Skill: " + RandomizerBonusSkill.CurrentBonusName());
    }

    // Token: 0x060037F9 RID: 14329 RVA: 0x000E5A60 File Offset: 0x000E3C60
    public static void ActivateBonusSkill()
    {
        if (RandomizerBonusSkill.UnlockedBonusSkills.Count == 0)
        {
            return;
        }
        int item = RandomizerBonusSkill.CurrentBonus();
        switch (item)
        {
        case 101:
            if (Characters.Sein.Energy.Current > 0f)
            {
                float amount = Characters.Sein.Energy.Current * 4f;
                Characters.Sein.Energy.SetCurrent(Characters.Sein.Mortality.Health.Amount / 4f);
                Characters.Sein.Mortality.Health.SetAmount(amount);
            } else {
                UI.SeinUI.ShakeEnergyOrbBar();
                Characters.Sein.Energy.NotifyOutOfEnergy();
            }
            break;
        case 102:
            if (RandomizerBonusSkill.ActiveDrainSkills.Contains(item))
            {
                RandomizerBonusSkill.ActiveDrainSkills.Remove(item);
                Randomizer.MessageQueue.Enqueue("Gravity Shift off");
                Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 0f;
                RandomizerBonusSkill.EnergyDrainRate -= 0.001f;
            }
            else if(Characters.Sein.Energy.Current > 0f) {
                RandomizerBonusSkill.ActiveDrainSkills.Add(item);
                Randomizer.MessageQueue.Enqueue("Gravity Shift on");
                Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 180f;
                RandomizerBonusSkill.EnergyDrainRate += 0.001f;
            } else {
                UI.SeinUI.ShakeEnergyOrbBar();
                Characters.Sein.Energy.NotifyOutOfEnergy();
            }
            break;
        case 103:
            if (RandomizerBonusSkill.ActiveDrainSkills.Contains(item))
            {
                RandomizerBonusSkill.ActiveDrainSkills.Remove(item);
                Randomizer.MessageQueue.Enqueue("ExtremeSpeed off");
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f;
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f;
                RandomizerBonusSkill.EnergyDrainRate -= 0.001f;
            }
            else if(Characters.Sein.Energy.Current > 0f) {
                RandomizerBonusSkill.ActiveDrainSkills.Add(item);
                Randomizer.MessageQueue.Enqueue("ExtremeSpeed on");
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 40f;
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 40f;
                RandomizerBonusSkill.EnergyDrainRate += 0.001f;
            } else {
                    UI.SeinUI.ShakeEnergyOrbBar();
                    Characters.Sein.Energy.NotifyOutOfEnergy();
            }
            break;
        case 104:
            if (Characters.Sein.Abilities.Carry.IsCarrying || !Characters.Sein.Controller.CanMove || !Characters.Sein.Active ||  (Randomizer.LastReturnPoint.x == 0 && Randomizer.LastReturnPoint.y == 0) )
                return;
            if (Characters.Sein.Energy.Current >= 0.5f)
            {
                Characters.Sein.Energy.SetCurrent(Characters.Sein.Energy.Current - 0.5f);
                Randomizer.Warping = 5;
                Randomizer.WarpTarget = Randomizer.LastReturnPoint;
                Characters.Sein.Position = Randomizer.LastReturnPoint;
                Characters.Sein.Speed = new Vector3(0, 0);
                Characters.Ori.Position = Randomizer.LastReturnPoint;
                return;
            } else {
                    UI.SeinUI.ShakeEnergyOrbBar();
                    Characters.Sein.Energy.NotifyOutOfEnergy();
            }
            break;
        case 105:
            if (Characters.Sein.Abilities.Carry.IsCarrying || !Characters.Sein.Controller.CanMove || !Characters.Sein.Active ||  (Randomizer.LastSoulLink.x == 0 && Randomizer.LastSoulLink.y == 0))
                return;
            if (Characters.Sein.Energy.Current >= 0.5f)
            {
                Characters.Sein.Energy.SetCurrent(Characters.Sein.Energy.Current - 0.5f);
                Randomizer.Warping = 5;
                Randomizer.WarpTarget = Randomizer.LastSoulLink;
                Characters.Sein.Position = Randomizer.LastSoulLink;
                Characters.Sein.Speed = new Vector3(0, 0);
                Characters.Ori.Position = Randomizer.LastSoulLink;
                return;
            } else {
                    UI.SeinUI.ShakeEnergyOrbBar();
                    Characters.Sein.Energy.NotifyOutOfEnergy();
            }
            break;
        default:
            return;
        }
    }

    // Token: 0x060037FA RID: 14330 RVA: 0x000E5CF0 File Offset: 0x000E3EF0
    static RandomizerBonusSkill()
    {
        RandomizerBonusSkill.UnlockedBonusSkills = new List<int>();
        RandomizerBonusSkill.BonusSkillsLastSave = new List<int>();
        RandomizerBonusSkill.Reset();
    }

    // Token: 0x060037FB RID: 14331 RVA: 0x000E5D5C File Offset: 0x000E3F5C
    public static void Update()
    {
        if (RandomizerBonusSkill.EnergyDrainRate > 0f)
        {
            if (RandomizerBonusSkill.EnergyDrainRate > Characters.Sein.Energy.Current)
            {
                RandomizerBonusSkill.EnergyDrainRate = 0f;
                RandomizerBonusSkill.DisableAllPersistant();
                return;
            }
            Characters.Sein.Energy.SetCurrent(Characters.Sein.Energy.Current - RandomizerBonusSkill.EnergyDrainRate);
        }
    }

    // Token: 0x060037FC RID: 14332 RVA: 0x000E5DC0 File Offset: 0x000E3FC0
    public static void DisableAllPersistant()
    {
        RandomizerBonusSkill.ActiveDrainSkills.Clear();
        RandomizerBonusSkill.EnergyDrainRate = 0f;
        Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f;
        Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f;
        Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 0f;
    }

    // Token: 0x060037FD RID: 14333 RVA: 0x0002BF6B File Offset: 0x0002A16B
    public static void OnSave()
    {
        RandomizerBonusSkill.BonusSkillsLastSave = new List<int>(RandomizerBonusSkill.UnlockedBonusSkills);
    }

    // Token: 0x060037FE RID: 14334 RVA: 0x0002BF7C File Offset: 0x0002A17C
    public static void OnDeath()
    {
        RandomizerBonusSkill.DisableAllPersistant();
        RandomizerBonusSkill.UnlockedBonusSkills = new List<int>(RandomizerBonusSkill.BonusSkillsLastSave);
    }

    // Token: 0x060037FF RID: 14335 RVA: 0x0002BF92 File Offset: 0x0002A192
    public static int CurrentBonus()
    {
        if (RandomizerBonusSkill.UnlockedBonusSkills.Count > RandomizerBonusSkill.ActiveBonus)
        {
            return RandomizerBonusSkill.UnlockedBonusSkills[RandomizerBonusSkill.ActiveBonus];
        }
        return 0;
    }

    // Token: 0x06003800 RID: 14336 RVA: 0x0002BFB6 File Offset: 0x0002A1B6
    public static string CurrentBonusName()
    {
        if (RandomizerBonusSkill.UnlockedBonusSkills.Count > RandomizerBonusSkill.ActiveBonus)
        {
            return RandomizerBonusSkill.BonusSkillNames[RandomizerBonusSkill.CurrentBonus()];
        }
        return "None";
    }

    // Token: 0x06003801 RID: 14337 RVA: 0x000E5E48 File Offset: 0x000E4048
    public static void FoundBonusSkill(int ID)
    {
        Randomizer.showHint("Unlocked Bonus Skill: " + RandomizerBonusSkill.BonusSkillNames[ID]);
        Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
        if (!RandomizerBonusSkill.UnlockedBonusSkills.Contains(ID))
        {
            RandomizerBonusSkill.UnlockedBonusSkills.Add(ID);
            RandomizerBonusSkill.ActiveBonus = RandomizerBonusSkill.UnlockedBonusSkills.Count - 1;
        }
    }

    // Token: 0x06003802 RID: 14338 RVA: 0x000E5EA0 File Offset: 0x000E40A0
    public static void Reset()
    {
        RandomizerBonusSkill.UnlockedBonusSkills = new List<int>();
        RandomizerBonusSkill.BonusSkillsLastSave = new List<int>();
        RandomizerBonusSkill.ActiveDrainSkills = new HashSet<int>();
        RandomizerBonusSkill.EnergyDrainRate = 0f;
        foreach (int num in RandomizerBonusSkill.BonusSkillNames.Keys)
        {
            if (Characters.Sein && num >= 100 && Characters.Sein.Inventory.GetRandomizerItem(num) > 0)
            {
                RandomizerBonusSkill.UnlockedBonusSkills.Add(num);
            }
        }
        RandomizerBonusSkill.ActiveBonus = 0;
    }

    // Token: 0x040032C0 RID: 12992
    public static int ActiveBonus = 0;

    // Token: 0x040032C1 RID: 12993
    public static List<int> UnlockedBonusSkills;

    // Token: 0x040032C2 RID: 12994
    public static float EnergyDrainRate;

    // Token: 0x040032C3 RID: 12995
    public static HashSet<int> ActiveDrainSkills;

    // Token: 0x040032C4 RID: 12996
    public static List<int> BonusSkillsLastSave;

    // Token: 0x040032C5 RID: 12997
    public static Dictionary<int, string> BonusSkillNames = new Dictionary<int, string>
    {
        {
            101,
            "Polarity Shift"
        },
        {
            102,
            "Gravity Swap"
        },
        {
            103,
            "ExtremeSpeed"
        },
        {
            104,
            "Roose's Wind"
        },
        {
            105,
            "Respawn Without Dying"
        },

    };
}
