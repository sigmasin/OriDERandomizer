using System;
using System.Collections.Generic;
using Game;

// Token: 0x02000A0D RID: 2573
public static class RandomizerBonusSkill
{
    // Token: 0x060038B2 RID: 14514
    public static void SwitchBonusSkill()
    {
        if (RandomizerBonusSkill.UnlockedBonusSkills.Count < 1)
        {
            RandomizerBonusSkill.PlayMessage(false);
            return;
        }
        RandomizerBonusSkill.ActiveBonus = (RandomizerBonusSkill.ActiveBonus + 1) % RandomizerBonusSkill.UnlockedBonusSkills.Count;
        RandomizerBonusSkill.PlayMessage(false);
    }

    // Token: 0x060038B3 RID: 14515
    public static void PlayMessage(bool history)
    {
        RandomizerBonusSkill.PlayMessage(RandomizerBonusSkill.UnlockedBonusSkills[RandomizerBonusSkill.ActiveBonus], history);
    }

    // Token: 0x060038B4 RID: 14516
    public static void ActivateBonusSkill()
    {
        if (RandomizerBonusSkill.UnlockedBonusSkills.Count == 0)
        {
            return;
        }
        int current = RandomizerBonusSkill.UnlockedBonusSkills[RandomizerBonusSkill.ActiveBonus];
        switch (current)
        {
        case 101:
            if (Characters.Sein.Energy.Current > 0f)
            {
                float temp = Characters.Sein.Energy.Current * 4f;
                Characters.Sein.Energy.SetCurrent(Characters.Sein.Mortality.Health.Amount / 4f);
                Characters.Sein.Mortality.Health.SetAmount(temp);
                return;
            }
            break;
        case 102:
            if (RandomizerBonusSkill.ActiveDrainSkills.Contains(current))
            {
                RandomizerBonusSkill.ActiveDrainSkills.Remove(current);
                Randomizer.showHint("Gravity Shift off");
                Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 0f;
                RandomizerBonusSkill.EnergyDrainRate -= 0.001f;
                return;
            }
            RandomizerBonusSkill.ActiveDrainSkills.Add(current);
            Randomizer.showHint("Gravity Shift on");
            Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 180f;
            RandomizerBonusSkill.EnergyDrainRate += 0.001f;
            return;
        case 103:
            if (RandomizerBonusSkill.ActiveDrainSkills.Contains(current))
            {
                RandomizerBonusSkill.ActiveDrainSkills.Remove(current);
                Randomizer.showHint("Drag Racer off");
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f;
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f;
                RandomizerBonusSkill.EnergyDrainRate -= 0.002f;
                return;
            }
            RandomizerBonusSkill.ActiveDrainSkills.Add(current);
            Randomizer.showHint("Drag Racer on");
            Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 35f;
            Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 35f;
            RandomizerBonusSkill.EnergyDrainRate += 0.002f;
            return;
        case 104:
            if (Characters.Sein.Energy.Current >= 0.25f)
            {
                Characters.Sein.Energy.SetCurrent(Characters.Sein.Energy.Current - 0.25f);
                Characters.Sein.PlatformBehaviour.PlatformMovement.LocalSpeedX = 0f;
                Characters.Sein.PlatformBehaviour.PlatformMovement.LocalSpeedY = 0f;
                Characters.Sein.PlatformBehaviour.InstantStop.Enter();
                return;
            }
            break;
        default:
            return;
        }
    }

    // Token: 0x060038B5 RID: 14517
    static RandomizerBonusSkill()
    {
        RandomizerBonusSkill.ActiveDrainSkills = new HashSet<int>();
    }

    // Token: 0x06003910 RID: 14608
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

    // Token: 0x06003911 RID: 14609
    public static void DisableAllPersistant()
    {
        RandomizerBonusSkill.ActiveDrainSkills.Clear();
        RandomizerBonusSkill.EnergyDrainRate = 0f;
        Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f;
        Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f;
        Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 0f;
    }

    // Token: 0x06003AA2 RID: 15010
    public static void PlayMessage(int code, bool history)
    {
        string message = "No bonus skill";
            switch (code)
            {
            case 101:
                message = "Polarity Shift";
                break;
            case 102:
                message = "Gravity Swap";
                break;
            case 103:
                message = "Drag Racer";
                break;
            case 104:
                message = "Airbrake";
                break;
            }
            if(history)
            {
                Randomizer.showHint(message);
            } else {
                Randomizer.MessageQueue.Enqueue(message);
            }

    }

    // Token: 0x06003AE8 RID: 15080
    public static void OnSave()
    {
        RandomizerBonusSkill.BonusSkillsLastSave = new List<int>(RandomizerBonusSkill.UnlockedBonusSkills);
    }

    // Token: 0x06003AE9 RID: 15081
    public static void OnDeath()
    {
        RandomizerBonusSkill.DisableAllPersistant();
        RandomizerBonusSkill.UnlockedBonusSkills = new List<int>(RandomizerBonusSkill.BonusSkillsLastSave);
    }

    // Token: 0x0400333E RID: 13118
    public static int ActiveBonus = 0;

    // Token: 0x0400333F RID: 13119
    public static List<int> UnlockedBonusSkills = new List<int>();

    // Token: 0x04003374 RID: 13172
    public static float EnergyDrainRate;

    // Token: 0x04003383 RID: 13187
    public static HashSet<int> ActiveDrainSkills;

    // Token: 0x04003492 RID: 13458
    public static List<int> BonusSkillsLastSave = new List<int>();
}
