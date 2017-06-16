using System;
using Game;
using UnityEngine;

// Token: 0x02000058 RID: 88
public class MessageControllerB : MonoBehaviour
{
	// Token: 0x1700005D RID: 93
	// (get) Token: 0x0600021A RID: 538 RVA: 0x00003B6E File Offset: 0x00001D6E
	public bool AnyAbilityPickupStoryMessagesVisible
	{
		get
		{
			return this.m_currentMessageBox;
		}
	}

	// Token: 0x0600021B RID: 539
	public GameObject ShowMessageBox(GameObject messageBoxPrefab, MessageProvider messageProvider, Vector3 position, float duration = 3f)
	{
		if (messageProvider == null)
		{
			return null;
		}
		if (SeinUI.DebugHideUI)
		{
			return null;
		}
		GameObject expr_25 = InstantiateUtility.Instantiate(messageBoxPrefab, position, Quaternion.identity) as GameObject;
		MessageBox componentInChildren = expr_25.GetComponentInChildren<MessageBox>();
		if (componentInChildren.Visibility)
		{
			componentInChildren.SetWaitDuration(duration);
		}
		componentInChildren.SetMessageProvider(messageProvider);
		return expr_25;
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00034988 File Offset: 0x00032B88
	public MessageBox ShowHintMessage(MessageProvider messageProvider, Vector3 position, float duration = 3f)
	{
		GameObject gameObject = this.ShowMessageBox(this.HintMessage, messageProvider, position, duration);
		return (!gameObject) ? null : gameObject.GetComponentInChildren<MessageBox>();
	}

	// Token: 0x0600021D RID: 541
	public MessageBox ShowMessageBoxB(GameObject messageBoxPrefab, MessageProvider messageProvider, Vector3 position, float duration = 3f)
	{
		if (!Characters.Sein.IsSuspended)
		{
			return null;
		}
		GameObject gameObject = this.ShowMessageBox(messageBoxPrefab, messageProvider, position, duration);
		if (gameObject)
		{
			return gameObject.GetComponentInChildren<MessageBox>();
		}
		return null;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x00003B7B File Offset: 0x00001D7B
	public MessageBox ShowAreaMessage(MessageProvider messageProvider)
	{
		this.m_currentMessageBox = this.ShowMessageBoxB(this.AreaMessage, messageProvider, Vector3.zero, 3f);
		return this.m_currentMessageBox;
	}

	// Token: 0x0600021F RID: 543 RVA: 0x000349EC File Offset: 0x00032BEC
	public MessageBox ShowAbilityMessage(MessageProvider messageProvider, GameObject avatar)
	{
		UI.Hints.HideExistingHint();
		MessageBox messageBox = this.ShowMessageBoxB(this.AbilityMessage, messageProvider, new Vector3(0f, 2f), float.PositiveInfinity);
		if (messageBox && avatar)
		{
			messageBox.SetAvatar(avatar);
		}
		this.m_currentMessageBox = messageBox;
		return messageBox;
	}

	// Token: 0x06000220 RID: 544 RVA: 0x00034A48 File Offset: 0x00032C48
	public MessageBox ShowPickupMessage(MessageProvider messageProvider, GameObject avatar)
	{
		UI.Hints.HideExistingHint();
		MessageBox messageBox = this.ShowMessageBoxB(this.PickupMessage, messageProvider, new Vector3(0f, 2f), float.PositiveInfinity);
		if (messageBox && avatar)
		{
			messageBox.SetAvatar(avatar);
		}
		this.m_currentMessageBox = messageBox;
		return messageBox;
	}

	// Token: 0x06000221 RID: 545 RVA: 0x00034AA4 File Offset: 0x00032CA4
	public MessageBox ShowStoryMessage(MessageProvider messageProvider)
	{
		UI.Hints.HideExistingHint();
		MessageBox messageBox = this.ShowMessageBoxB(this.StoryMessage, messageProvider, Vector3.zero, float.PositiveInfinity);
		this.m_currentMessageBox = messageBox;
		return messageBox;
	}

	// Token: 0x06000222 RID: 546 RVA: 0x00034AD8 File Offset: 0x00032CD8
	public MessageBox ShowHelpMessage(MessageProvider messageProvider, GameObject avatar)
	{
		UI.Hints.HideExistingHint();
		MessageBox messageBox = this.ShowMessageBoxB(this.HelpMessage, messageProvider, Vector3.zero, float.PositiveInfinity);
		if (messageBox && avatar)
		{
			messageBox.SetAvatar(avatar);
		}
		return messageBox;
	}

	// Token: 0x06000223 RID: 547 RVA: 0x00003BA0 File Offset: 0x00001DA0
	public GameObject ShowSpiritTreeTextMessage(MessageProvider messageProvider, Vector3 position)
	{
		return this.ShowMessageBox(this.SpiritTreeText, messageProvider, position, 0f);
	}

	// Token: 0x04000289 RID: 649
	public float DefaultDuration;

	// Token: 0x0400028A RID: 650
	public GameObject AreaMessage;

	// Token: 0x0400028B RID: 651
	public GameObject AbilityMessage;

	// Token: 0x0400028C RID: 652
	public GameObject HintMessage;

	// Token: 0x0400028D RID: 653
	public GameObject PickupMessage;

	// Token: 0x0400028E RID: 654
	public GameObject StoryMessage;

	// Token: 0x0400028F RID: 655
	public GameObject HelpMessage;

	// Token: 0x04000290 RID: 656
	public GameObject SpiritTreeText;

	// Token: 0x04000291 RID: 657
	private MessageBox m_currentMessageBox;
}
