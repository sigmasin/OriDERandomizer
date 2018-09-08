using System;
using Game;

// Token: 0x020007CD RID: 1997
public class NewGameAction : ActionMethod
{
	// Token: 0x06002B1C RID: 11036 RVA: 0x00003817 File Offset: 0x00001A17
	public NewGameAction()
	{
	}

	// Token: 0x06002B1D RID: 11037
	public override void Perform(IContext context)
	{
		Game.Checkpoint.SaveGameData = new SaveGameData();
		if (Randomizer.NoLava)
		{
			Game.Checkpoint.SaveGameData.DrainLava();
		}
		GameController.Instance.RequireInitialValues = true;
		GameStateMachine.Instance.SetToGame();
	}
}
