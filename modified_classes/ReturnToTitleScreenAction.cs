using System;

// Token: 0x02000092 RID: 146
public class ReturnToTitleScreenAction : ActionMethod
{
	// Token: 0x060003A5 RID: 933
	public override void Perform(IContext context)
	{
		if(Randomizer.NeedGinsoEscapeCleanup) {
			try
			{
				Randomizer.ParseFlags(Randomizer.SeedMeta.Split(new char[] {'|'})[0].Split(new char[] {','}));
			}
			catch (Exception e)
			{
				Randomizer.LogError("ReturnToTitleScreenAction: " + e.Message);
			}
			NeedGinsoEscapeCleanup = false;
		}
		Randomizer.Returning = false;
		Randomizer.Warping = 0;
		RandomizerStatsManager.OnReturnToMenu();
		GameController.Instance.RestartGame();
	}
}
