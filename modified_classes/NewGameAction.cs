using System;
using Game;

// Token: 0x020007CD RID: 1997
public class NewGameAction : ActionMethod
{
	// Token: 0x06002B1D RID: 11037
	public NewGameAction()
	{
	}

	// Token: 0x06002B1E RID: 11038
	public override void Perform(IContext context)
	{
		Game.Checkpoint.SaveGameData = new SaveGameData();
		if (Randomizer.NoLava)
		{
			Game.Checkpoint.SaveGameData.LoadCustomData(Randomizer.HoruData);
			Game.Checkpoint.SaveGameData.LoadCustomData(Randomizer.GinsoData);
		}
		GameController.Instance.RequireInitialValues = true;
		GameStateMachine.Instance.SetToGame();
	}
}
