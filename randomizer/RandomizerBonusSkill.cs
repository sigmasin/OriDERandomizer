using System;
using Game;
using Sein.World;
using System.Collections.Generic;

public static class RandomizerBonusSkill
{
    public static float EnergyDrainRate = 0f;
    public static int ActiveBonus = 0;
    public static List<int> UnlockedBonusSkills = new List<int>();
    public static HashSet<int> ActiveDrainSkills = new HashSet<int>();  

    public static void Update() 
    {
        if(RandomizerBonusSkill.EnergyDrainRate > 0) 
        {
            if(RandomizerBonusSkill.EnergyDrainRate > Characters.Sein.Energy.Current)
            {
                RandomizerBonusSkill.EnergyDrainRate = 0;
                RandomizerBonusSkill.DisableAllPersistant();
            } else {
                Characters.Sein.Energy.SetCurrent(Characters.Sein.Energy.Current - RandomizerBonusSkill.EnergyDrainRate);
            }
        }
    }

    public static void DisableAllPersistant() 
    {
        RandomizerBonusSkill.ActiveDrainSkills.Clear();
        Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f;
        Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f;
        Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 0f;
    }

    public static void SwitchBonusSkill()
    {   
        if(RandomizerBonusSkill.UnlockedBonusSkills.Count < 1) {
            RandomizerBonusSkill.PlayMessage();
            return;
        }
        RandomizerBonusSkill.ActiveBonus = (RandomizerBonusSkill.ActiveBonus  + 1) % RandomizerBonusSkill.UnlockedBonusSkills.Count;
        RandomizerBonusSkill.PlayMessage();
    }

    public static void PlayMessage() {
        switch (RandomizerBonusSkill.UnlockedBonusSkills[RandomizerBonusSkill.ActiveBonus])
        {
        case 30:
            Randomizer.showHint("Polarity Shift");
        break;
       case 31:
            Randomizer.showHint("Gravity Swap");
        break;
       case 32:
            Randomizer.showHint("Drag Racer");
        break;
        default:
            Randomizer.showHint("No bonus skills unlocked");
        break;
        }
    }


    public static void ActivateBonusSkill()
    {
        if(RandomizerBonusSkill.UnlockedBonusSkills.Count == 0) {
            return;
        }
        int current = RandomizerBonusSkill.UnlockedBonusSkills[RandomizerBonusSkill.ActiveBonus];
        switch (current)
        {
        case 30:
            if (Characters.Sein.Energy.Current > 0f)
            {
                float temp = Characters.Sein.Energy.Current * 4f;
                Characters.Sein.Energy.SetCurrent(Characters.Sein.Mortality.Health.Amount / 4f);
                Characters.Sein.Mortality.Health.SetAmount(temp);
            }
        break;
        case 31:
            if (RandomizerBonusSkill.ActiveDrainSkills.Contains(current))
            {
                RandomizerBonusSkill.ActiveDrainSkills.Remove(current);
                Randomizer.showHint("Gravity Shift off");
                Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 0;
                RandomizerBonusSkill.EnergyDrainRate -= .001f;
            } else {
                RandomizerBonusSkill.ActiveDrainSkills.Add(current);
                Randomizer.showHint("Gravity Shift on");
                Characters.Sein.PlatformBehaviour.Gravity.BaseSettings.GravityAngle = 180;
                RandomizerBonusSkill.EnergyDrainRate += .001f;
            }
        break;
        case 32:
            if (RandomizerBonusSkill.ActiveDrainSkills.Contains(current))
            {
                RandomizerBonusSkill.ActiveDrainSkills.Remove(current);
                Randomizer.showHint("Drag Racer off");
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 11.6666f;
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 11.6666f;
                RandomizerBonusSkill.EnergyDrainRate -= .002f;
            } else {
                RandomizerBonusSkill.ActiveDrainSkills.Add(current);
                Randomizer.showHint("Drag Racer on");
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Ground.MaxSpeed = 35f;
                Characters.Sein.PlatformBehaviour.LeftRightMovement.Settings.Air.MaxSpeed = 35f;
                RandomizerBonusSkill.EnergyDrainRate += .002f;
            }
        break;
        }
    }
}