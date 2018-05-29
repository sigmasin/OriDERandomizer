using System;
using System.Collections.Generic;
using Game;

// Token: 0x02000A0A RID: 2570
public static class RandomizerBonusSkill
{
    // Token: 0x060037D9 RID: 14297
    public static void SwitchBonusSkill()
    {
        if (RandomizerBonusSkill.UnlockedBonusSkills.Count < 1)
        {
            Randomizer.MessageQueue.Enqueue("No bonus skills unlocked!");
            return;
        }
        RandomizerBonusSkill.ActiveBonus = (RandomizerBonusSkill.ActiveBonus + 1) % RandomizerBonusSkill.UnlockedBonusSkills.Count;
        Randomizer.MessageQueue.Enqueue(RandomizerBonusSkill.CurrentBonusName());
    }

    // Token: 0x060037DB RID: 14299
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
                return;
            }
            break;
        case 102:
            if (RandomizerBonusSkill.ActiveDrainSkills.Contains(item))
            {
                RandomizerBonusSkill.ActiveDrainSkills.Remove(item);
                Randomizer.MessageQueue.Enqueue("Gravity Shift off");
                Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 0f;
                RandomizerBonusSkill.EnergyDrainRate -= 0.001f;
                return;
            }
            RandomizerBonusSkill.ActiveDrainSkills.Add(item);
            Randomizer.MessageQueue.Enqueue("Gravity Shift on");
            Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 180f;
            RandomizerBonusSkill.EnergyDrainRate += 0.001f;
            return;
        case 103:
            if (RandomizerBonusSkill.ActiveDrainSkills.Contains(item))
            {
                RandomizerBonusSkill.ActiveDrainSkills.Remove(item);
                Randomizer.MessageQueue.Enqueue("ExtremeSpeed off");
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f;
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f;
                RandomizerBonusSkill.EnergyDrainRate -= 0.001f;
                return;
            }
            RandomizerBonusSkill.ActiveDrainSkills.Add(item);
            Randomizer.MessageQueue.Enqueue("ExtremeSpeed on");
            Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 40f;
            Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 40f;
            RandomizerBonusSkill.EnergyDrainRate += 0.001f;
            return;
        case 104:
            if (Characters.Sein.Energy.Current >= 0.25f)
            {
                Characters.Sein.Energy.SetCurrent(Characters.Sein.Energy.Current - 0.25f);
                Characters.Sein.PlatformBehaviour.PlatformMovement.LocalSpeedY = 8f;
                return;
            }
            break;
        default:
            return;
        }
    }

    // Token: 0x060037DC RID: 14300
    static RandomizerBonusSkill()
    {
        RandomizerBonusSkill.ActiveDrainSkills = new HashSet<int>();
        foreach (int code in RandomizerBonusSkill.BonusSkillNames.Keys)
        {
            if ((code >= 100) && (Characters.Sein.Inventory.GetRandomizerItem(code) > 0))
            {
                RandomizerBonusSkill.UnlockedBonusSkills.Add(code);
            }
        }
    }

    // Token: 0x060037DD RID: 14301
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

    // Token: 0x060037DE RID: 14302
    public static void DisableAllPersistant()
    {
        RandomizerBonusSkill.ActiveDrainSkills.Clear();
        RandomizerBonusSkill.EnergyDrainRate = 0f;
        Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f;
        Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f;
        Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 0f;
    }

    // Token: 0x060037E0 RID: 14304
    public static void OnSave()
    {
        RandomizerBonusSkill.BonusSkillsLastSave = new List<int>(RandomizerBonusSkill.UnlockedBonusSkills);
    }

    // Token: 0x060037E1 RID: 14305
    public static void OnDeath()
    {
        RandomizerBonusSkill.DisableAllPersistant();
        RandomizerBonusSkill.UnlockedBonusSkills = new List<int>(RandomizerBonusSkill.BonusSkillsLastSave);
    }

    // Token: 0x06003997 RID: 14743
    public static int CurrentBonus()
    {
        if(RandomizerBonusSkill.UnlockedBonusSkills.Count > RandomizerBonusSkill.ActiveBonus)
            return RandomizerBonusSkill.UnlockedBonusSkills[RandomizerBonusSkill.ActiveBonus];
        else
            return 0;
    }

    public static string CurrentBonusName()
    {
        if(RandomizerBonusSkill.UnlockedBonusSkills.Count > RandomizerBonusSkill.ActiveBonus)
            return RandomizerBonusSkill.BonusSkillNames[RandomizerBonusSkill.CurrentBonus()];
        else
            return "None";
    }

    public static void FoundBonusSkill(int ID)
    {
        Randomizer.showHint(RandomizerBonusSkill.BonusSkillNames[ID]);
        Characters.Sein.Inventory.IncRandomizerItem(ID, 1);
        if (!RandomizerBonusSkill.UnlockedBonusSkills.Contains(ID))
        {
            RandomizerBonusSkill.UnlockedBonusSkills.Add(ID);
            RandomizerBonusSkill.ActiveBonus = RandomizerBonusSkill.UnlockedBonusSkills.Count - 1;
        }
    }

    // Token: 0x040032A0 RID: 12960
    public static int ActiveBonus = 0;

    public static Dictionary<int,string> BonusSkillNames = new Dictionary<int, string> () { {101, "Polarity Shift"}, { 102, "Gravity Swap"}, { 103, "ExtremeSpeed"} , {104, "Energy Jump" }};

    // Token: 0x040032A1 RID: 12961
    public static List<int> UnlockedBonusSkills = new List<int>();

    // Token: 0x040032A2 RID: 12962
    public static float EnergyDrainRate;

    // Token: 0x040032A3 RID: 12963
    public static HashSet<int> ActiveDrainSkills;

    // Token: 0x040032A4 RID: 12964
    public static List<int> BonusSkillsLastSave = new List<int>();
}

