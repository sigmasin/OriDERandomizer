using System;
using Game;
using Sein.World;

public static class RandomizerSwitch
{

    public static void SkillPointPickup()
    {
        Randomizer.MessageProvider.SetMessage("Ability Cell");
        if(Randomizer.ZeroXP)
        {
            return;
        }
        Characters.Sein.Level.GainSkillPoint();
        Characters.Sein.Inventory.SkillPointsCollected++;
    }
    
    public static void MaxEnergyContainerPickup() 
    {
        Randomizer.MessageProvider.SetMessage("Energy Cell");
        if (Characters.Sein.Energy.Max == 0f)
		{
			Characters.Sein.SoulFlame.FillSoulFlameBar();
		}
		Characters.Sein.Energy.Max += 1.0f;
		Characters.Sein.Energy.Current = Characters.Sein.Energy.Max;
    }
    
    public static void ExpOrbPickup(int Value)
    {
        Randomizer.MessageProvider.SetMessage(Value.ToString() + " experience");
        if(Randomizer.ZeroXP)
        {
            return;
        }
        int num = Value * ((!Characters.Sein.PlayerAbilities.SoulEfficiency.HasAbility) ? 1 : 2);
        if (RandomizerBonus.ExpEfficiency())
		{
			num *= 2;
		}
		Characters.Sein.Level.GainExperience(num);
    }
    
    public static void KeystonePickup() {
        Randomizer.MessageProvider.SetMessage("Keystone");
        Characters.Sein.Inventory.CollectKeystones(1);     
    }
    
    public static void MaxHealthContainerPickup() 
    {
        Randomizer.MessageProvider.SetMessage("Health Cell");
        Characters.Sein.Mortality.Health.GainMaxHeartContainer();
    }
    
    public static void MapStonePickup() 
    {
        Randomizer.MessageProvider.SetMessage("Map Stone");
        Characters.Sein.Inventory.MapStones++;
    }
    
    public static void AbilityPickup(int Ability) {
        Randomizer.GiveAbility = true;
        switch (Ability)
		{
		case 0:
            Randomizer.MessageProvider.SetMessage("Bash");
			Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Bash, true);
			break;
		case 2:
            Randomizer.MessageProvider.SetMessage("Charge Flame");
			Characters.Sein.PlayerAbilities.SetAbility(AbilityType.ChargeFlame, true);
			break;
		case 3:
            Randomizer.MessageProvider.SetMessage("Wall Jump");
			Characters.Sein.PlayerAbilities.SetAbility(AbilityType.WallJump, true);
			break;
		case 4:
            Randomizer.MessageProvider.SetMessage("Stomp");
			Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Stomp, true);
			break;
		case 5:
            Randomizer.MessageProvider.SetMessage("Double Jump");
			Characters.Sein.PlayerAbilities.SetAbility(AbilityType.DoubleJump, true);
			break;
		case 8:
            Randomizer.MessageProvider.SetMessage("Charge Jump");
			Characters.Sein.PlayerAbilities.SetAbility(AbilityType.ChargeJump, true);
			break;
		case 12:
            Randomizer.MessageProvider.SetMessage("Climb");
			Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Climb, true);
			break;
		case 14:
            Randomizer.MessageProvider.SetMessage("Glide");
			Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Glide, true);
			break;
		case 50:
            Randomizer.MessageProvider.SetMessage("Dash");
			Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Dash, true);
			break;
		case 51:
            Randomizer.MessageProvider.SetMessage("Grenade");
			Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Grenade, true);
			break;
        }
        Randomizer.GiveAbility = false;

    }
    public static void EventPickup(Object Value) 
    {
        switch (Value)
        {
            case 0:
                Randomizer.MessageProvider.SetMessage("Water Vein");
                Keys.GinsoTree = true;
                break;
            case 1:
                Randomizer.MessageProvider.SetMessage("Clean Water");
                Sein.World.Events.WarmthReturned = true;
                break;
            case 2:
                Randomizer.MessageProvider.SetMessage("Gumon Seal");
                Keys.ForlornRuins = true;
                break;
            case 3:
                Randomizer.MessageProvider.SetMessage("Wind Restored");
                Sein.World.Events.WindRestored = true;
                break;
            case 4:
                Randomizer.MessageProvider.SetMessage("Sunstone");
                Keys.MountHoru = true;
                break;
            case 5:
                Randomizer.MessageProvider.SetMessage("Warmth Returned");
                break;
        }
    }
    
    
    
    
    public static void GivePickup(RandomizerAction Action)
    {
        switch (Action.Action) {
            case "AC":                
                SkillPointPickup();
                break;
            case "EC":                
                MaxEnergyContainerPickup();
                break;
            case "EX":                
                ExpOrbPickup((int)Action.Value);
                break;
            case "KS":                
                KeystonePickup();
                break;
            case "HC":                
                MaxHealthContainerPickup();
                break;
            case "MS":
                MapStonePickup();
                break;
            case "SK":
                AbilityPickup((int)Action.Value);
                break;
            case "EV":
                EventPickup(Action.Value);
                break;
            case "RB":
                RandomizerBonus.UpgradeID((int)Action.Value);
                break;
            case "NO":
                Randomizer.showHint("Nothing");
                return;
        }
        Game.UI.Hints.Show(Randomizer.MessageProvider, HintLayer.GameSaved);
             
    }
        
}