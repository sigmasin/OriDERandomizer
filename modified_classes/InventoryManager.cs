using System;
using Core;
using Game;
using UnityEngine;

// Token: 0x02000524 RID: 1316
public class InventoryManager : MenuScreen
{
	// Token: 0x06001BED RID: 7149 RVA: 0x00017F3A File Offset: 0x0001613A
	public override void Show()
	{
		this.NavigationManager.SetVisible(true);
		this.NavigationManager.SetIndexToFirst();
	}

	// Token: 0x06001BEE RID: 7150 RVA: 0x00017F53 File Offset: 0x00016153
	public override void Hide()
	{
		this.NavigationManager.SetVisible(false);
	}

	// Token: 0x06001BEF RID: 7151 RVA: 0x00017F61 File Offset: 0x00016161
	public override void ShowImmediate()
	{
		this.NavigationManager.SetVisibleImmediate(true);
		this.NavigationManager.SetIndexToFirst();
	}

	// Token: 0x06001BF0 RID: 7152 RVA: 0x00017F7A File Offset: 0x0001617A
	public override void HideImmediate()
	{
		this.NavigationManager.SetVisibleImmediate(false);
	}

	// Token: 0x06001BF1 RID: 7153 RVA: 0x00087438 File Offset: 0x00085638
	public void Awake()
	{
		InventoryManager.Instance = this;
		CleverMenuItemSelectionManager expr_0C = this.NavigationManager;
		expr_0C.OptionChangeCallback = (Action)Delegate.Combine(expr_0C.OptionChangeCallback, new Action(this.OnMenuItemChange));
		CleverMenuItemSelectionManager expr_33 = this.NavigationManager;
		expr_33.OptionPressedCallback = (Action)Delegate.Combine(expr_33.OptionPressedCallback, new Action(this.OnMenuItemPressed));
		CleverMenuItemSelectionManager expr_5A = this.NavigationManager;
		expr_5A.OnBackPressedCallback = (Action)Delegate.Combine(expr_5A.OnBackPressedCallback, new Action(this.OnBackPressed));
		DifficultyController expr_80 = DifficultyController.Instance;
		expr_80.OnDifficultyChanged = (Action)Delegate.Combine(expr_80.OnDifficultyChanged, new Action(this.OnDifficultyChanged));
	}

	// Token: 0x06001BF2 RID: 7154 RVA: 0x00004268 File Offset: 0x00002468
	public void OnBackPressed()
	{
		UI.Menu.HideMenuScreen(false);
	}

	// Token: 0x06001BF3 RID: 7155 RVA: 0x000028E7 File Offset: 0x00000AE7
	public void OnMenuItemChange()
	{
	}

	// Token: 0x06001BF4 RID: 7156 RVA: 0x000874E8 File Offset: 0x000856E8
	public void OnMenuItemPressed()
	{
		InventoryAbilityItem component = this.NavigationManager.CurrentMenuItem.GetComponent<InventoryAbilityItem>();
		if (component && !component.HasAbility)
		{
			if (this.PressUngainedAbilityOptionSound)
			{
				Sound.Play(this.PressUngainedAbilityOptionSound.GetSound(null), base.transform.position, null);
			}
			return;
		}
		InventoryItemHelpText component2 = this.NavigationManager.CurrentMenuItem.GetComponent<InventoryItemHelpText>();
		if (component2)
		{
			SuspensionManager.SuspendAll();
			MessageBox messageBox = UI.MessageController.ShowMessageBoxB(this.HelpMessageBox, component2.HelpMessage, Vector3.zero, float.PositiveInfinity);
			if (messageBox)
			{
				messageBox.SetAvatar(component2.Avatar);
				messageBox.OnMessageScreenHide += new Action(this.OnMessageScreenHide);
			}
			else
			{
				SuspensionManager.ResumeAll();
			}
			this.m_currentCloseMessageSound = ((!component) ? this.CloseStatisticsMessageSound : this.CloseAbilityMessageSound);
			if (component && this.PressAbilityOptionSound)
			{
				Sound.Play(this.PressAbilityOptionSound.GetSound(null), base.transform.position, null);
			}
		}
	}

	// Token: 0x06001BF5 RID: 7157 RVA: 0x0008761C File Offset: 0x0008581C
	public void OnMessageScreenHide()
	{
		SuspensionManager.ResumeAll();
		if (this.m_currentCloseMessageSound && base.transform)
		{
			Sound.Play(this.m_currentCloseMessageSound.GetSound(null), base.transform.position, null);
		}
	}

	// Token: 0x06001BF6 RID: 7158 RVA: 0x0008766C File Offset: 0x0008586C
	public void OnDestroy()
	{
		if (InventoryManager.Instance == this)
		{
			InventoryManager.Instance = null;
		}
		CleverMenuItemSelectionManager expr_1C = this.NavigationManager;
		expr_1C.OptionChangeCallback = (Action)Delegate.Remove(expr_1C.OptionChangeCallback, new Action(this.OnMenuItemChange));
		CleverMenuItemSelectionManager expr_43 = this.NavigationManager;
		expr_43.OptionPressedCallback = (Action)Delegate.Remove(expr_43.OptionPressedCallback, new Action(this.OnMenuItemPressed));
		CleverMenuItemSelectionManager expr_6A = this.NavigationManager;
		expr_6A.OnBackPressedCallback = (Action)Delegate.Remove(expr_6A.OnBackPressedCallback, new Action(this.OnBackPressed));
		DifficultyController expr_90 = DifficultyController.Instance;
		expr_90.OnDifficultyChanged = (Action)Delegate.Remove(expr_90.OnDifficultyChanged, new Action(this.OnDifficultyChanged));
	}

	// Token: 0x06001BF7 RID: 7159 RVA: 0x00017F88 File Offset: 0x00016188
	public void OnDifficultyChanged()
	{
		if (this.Difficulty)
		{
			this.Difficulty.RefreshText();
		}
	}

	// Token: 0x06001BF8 RID: 7160
	public void UpdateItems()
	{
		SeinCharacter sein = Characters.Sein;
		if (sein == null)
		{
			return;
		}
		this.CompletionText.SetMessage(new MessageDescriptor(GameWorld.Instance.CompletionPercentage + "%"));
		this.DeathText.SetMessage(new MessageDescriptor(SeinDeathCounter.Count.ToString()));
		this.HealthUpgradesText.SetMessage(new MessageDescriptor(sein.Mortality.Health.HealthUpgradesCollected + " / " + 12));
		this.EnergyUpgradesText.SetMessage(new MessageDescriptor(sein.Energy.EnergyUpgradesCollected + " / " + 15));
		this.SkillPointUniquesText.SetMessage(new MessageDescriptor((sein.Inventory.SkillPointsCollected & 63) + " / " + 33));
		GameTimer timer = GameController.Instance.Timer;
		this.TimeText.SetMessage(new MessageDescriptor(string.Format("{0:D2}:{1:D2}:{2:D2}", timer.Hours, timer.Minutes, timer.Seconds)));
		InventoryAbilityItem component = this.NavigationManager.CurrentMenuItem.GetComponent<InventoryAbilityItem>();
		if (component)
		{
			this.AbilityNameText.gameObject.SetActive(true);
			this.AbilityItemHighlight.SetActive(true);
			this.AbilityItemHighlight.transform.position = component.transform.position;
			if (component.HasAbility)
			{
				this.AbilityNameText.SetMessageProvider(component.AbilityName);
			}
			else
			{
				this.AbilityNameText.SetMessageProvider(this.LockedMessageProvider);
			}
		}
		else
		{
			this.AbilityNameText.gameObject.SetActive(false);
			this.AbilityItemHighlight.SetActive(false);
		}
		if (this.Difficulty)
		{
			this.Difficulty.RefreshText();
		}
	}

	// Token: 0x06001BF9 RID: 7161 RVA: 0x00017FA5 File Offset: 0x000161A5
	public void FixedUpdate()
	{
		this.UpdateItems();
	}

	// Token: 0x06001BFA RID: 7162 RVA: 0x00017FA5 File Offset: 0x000161A5
	public void OnEnable()
	{
		this.UpdateItems();
	}

	// Token: 0x04001914 RID: 6420
	public const int TotalHealthUpgrades = 12;

	// Token: 0x04001915 RID: 6421
	public const int TotalEnergyUpgrades = 15;

	// Token: 0x04001916 RID: 6422
	public const int TotalSkillPoints = 33;

	// Token: 0x04001917 RID: 6423
	public const int MaxLevel = 20;

	// Token: 0x04001918 RID: 6424
	public static InventoryManager Instance;

	// Token: 0x04001919 RID: 6425
	public CleverMenuItemSelectionManager NavigationManager;

	// Token: 0x0400191A RID: 6426
	public SoundProvider OpenSound;

	// Token: 0x0400191B RID: 6427
	public SoundProvider CloseSound;

	// Token: 0x0400191C RID: 6428
	public SoundProvider PressAbilityOptionSound;

	// Token: 0x0400191D RID: 6429
	public SoundProvider PressUngainedAbilityOptionSound;

	// Token: 0x0400191E RID: 6430
	public SoundProvider CloseAbilityMessageSound;

	// Token: 0x0400191F RID: 6431
	public SoundProvider CloseStatisticsMessageSound;

	// Token: 0x04001920 RID: 6432
	private SoundProvider m_currentCloseMessageSound;

	// Token: 0x04001921 RID: 6433
	public GameObject AbilityItemHighlight;

	// Token: 0x04001922 RID: 6434
	public MessageBox AbilityNameText;

	// Token: 0x04001923 RID: 6435
	public MessageBox TimeText;

	// Token: 0x04001924 RID: 6436
	public MessageBox CompletionText;

	// Token: 0x04001925 RID: 6437
	public MessageBox DeathText;

	// Token: 0x04001926 RID: 6438
	public MessageBox HealthUpgradesText;

	// Token: 0x04001927 RID: 6439
	public MessageBox EnergyUpgradesText;

	// Token: 0x04001928 RID: 6440
	public MessageBox SkillPointUniquesText;

	// Token: 0x04001929 RID: 6441
	public GameObject GinsoTreeKey;

	// Token: 0x0400192A RID: 6442
	public GameObject ForlornRuinsKey;

	// Token: 0x0400192B RID: 6443
	public GameObject MountHoruKey;

	// Token: 0x0400192C RID: 6444
	public GameObject WorldEventsGroup;

	// Token: 0x0400192D RID: 6445
	public MessageBox Difficulty;

	// Token: 0x0400192E RID: 6446
	public MessageProvider LockedMessageProvider;

	// Token: 0x0400192F RID: 6447
	public MessageProvider NotAvailableYetMessageProvider;

	// Token: 0x04001930 RID: 6448
	public MessageProvider DiedZeroTimesMessageProvider;

	// Token: 0x04001931 RID: 6449
	public MessageProvider DiedOneTimeMessagProvider;

	// Token: 0x04001932 RID: 6450
	public MessageProvider DiedMultipleTimesMessageProvider;

	// Token: 0x04001933 RID: 6451
	public GameObject HelpMessageBox;
}
