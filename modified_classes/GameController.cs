using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Core;
using Frameworks;
using Game;
using UnityEngine;

// Token: 0x02000948 RID: 2376
public class GameController : SaveSerialize, ISuspendable
{
	// Token: 0x17000810 RID: 2064
	// (get) Token: 0x060033EE RID: 13294 RVA: 0x00028F15 File Offset: 0x00027115
	// (set) Token: 0x060033EF RID: 13295 RVA: 0x00028F1D File Offset: 0x0002711D
	public bool MainMenuCanBeOpened
	{
		get;
		set;
	}

	// Token: 0x17000811 RID: 2065
	// (get) Token: 0x060033F0 RID: 13296 RVA: 0x00028F26 File Offset: 0x00027126
	public int GameTimeInSeconds
	{
		get
		{
			return Mathf.RoundToInt(this.Timer.CurrentTime);
		}
	}

	// Token: 0x060033F1 RID: 13297 RVA: 0x00028F38 File Offset: 0x00027138
	public void PerformSaveGameSequence()
	{
		if (this.GameSaveSequence)
		{
			this.GameSaveSequence.Perform(null);
		}
	}

	// Token: 0x17000812 RID: 2066
	// (get) Token: 0x060033F2 RID: 13298 RVA: 0x00028F56 File Offset: 0x00027156
	public bool IsPackageFullyInstalled
	{
		get
		{
			return !DebugMenuB.IsFullyInstalledDebugOverride;
		}
	}

	// Token: 0x17000813 RID: 2067
	// (get) Token: 0x060033F3 RID: 13299 RVA: 0x00028F65 File Offset: 0x00027165
	public bool IsTrial
	{
		get
		{
			return this.PCTrialValue;
		}
	}

	// Token: 0x17000814 RID: 2068
	// (get) Token: 0x060033F4 RID: 13300 RVA: 0x000D55E4 File Offset: 0x000D37E4
	public bool IsDemo
	{
		get
		{
			WorldEventsRuntime worldEventsRuntime = World.Events.Find(this.DebugWorldEvents);
			return worldEventsRuntime.Value == this.DebugWorldEvents.GetIDFromName("Demo");
		}
	}

	// Token: 0x060033F5 RID: 13301 RVA: 0x00028F6D File Offset: 0x0002716D
	public void ExitGame()
	{
		if (this.IsTrial)
		{
			GameController.Instance.GoToEndTrialScreen();
		}
		else
		{
			GameController.Instance.QuitApplication();
		}
	}

	// Token: 0x060033F6 RID: 13302 RVA: 0x00004EE5 File Offset: 0x000030E5
	public void ExitTrial()
	{
		GameController.Instance.RestartGame();
	}

	// Token: 0x060033F7 RID: 13303 RVA: 0x0001DFE4 File Offset: 0x0001C1E4
	public void QuitApplication()
	{
		Application.Quit();
	}

	// Token: 0x060033F8 RID: 13304 RVA: 0x000D5618 File Offset: 0x000D3818
	public void GoToEndTrialScreen()
	{
		this.MainMenuCanBeOpened = false;
		GameStateMachine.Instance.SetToTrialEnd();
		RuntimeSceneMetaData sceneInformation = Scenes.Manager.GetSceneInformation("trialEndScreen");
		GoToSceneController.Instance.GoToScene(sceneInformation, new Action(this.OnFinishedLoadingTrialEndScene), false);
	}

	// Token: 0x060033F9 RID: 13305 RVA: 0x00028F93 File Offset: 0x00027193
	public void OnFinishedLoadingTrialEndScene()
	{
		this.RemoveGameplayObjects();
	}

	// Token: 0x060033FA RID: 13306 RVA: 0x00028F9B File Offset: 0x0002719B
	public void OnGameReset()
	{
		SaveSlotsManager.BackupIndex = -1;
		TriggerByString.OnGameReset();
		SeinLevel.HasSpentSkillPoint = false;
		WorldEventsManager.Instance.OnGameReset();
		SoundPlayer.DestroyAll();
	}

	// Token: 0x060033FB RID: 13307 RVA: 0x000D5660 File Offset: 0x000D3860
	public void RemoveGameplayObjects()
	{
		CharacterFactory.Instance.DestroyCharacter();
		if (Characters.Sein)
		{
			InstantiateUtility.Destroy(Characters.Sein.gameObject);
		}
		if (Characters.Naru)
		{
			InstantiateUtility.Destroy(Characters.Naru.gameObject);
		}
		if (Characters.BabySein)
		{
			InstantiateUtility.Destroy(Characters.BabySein.gameObject);
		}
		if (Characters.Ori)
		{
			InstantiateUtility.Destroy(Characters.Ori.gameObject);
		}
		if (UI.SeinUI)
		{
			InstantiateUtility.Destroy(UI.SeinUI.gameObject);
		}
		Core.SoundComposition.Manager.StopMusic();
		UI.Cameras.Current.Target = null;
		if (UI.MainMenuVisible)
		{
			UI.Menu.HideMenuScreen(false);
		}
		UI.Menu.RemoveGameplayObjects();
		WorldMapUI.CancelLoading();
	}

	// Token: 0x060033FC RID: 13308 RVA: 0x00028FBD File Offset: 0x000271BD
	public void ResetStateForDebugMenuGoToScene()
	{
		this.RemoveGameplayObjects();
		this.RequireInitialValues = true;
	}

	// Token: 0x060033FD RID: 13309 RVA: 0x000D5748 File Offset: 0x000D3948
	public void RestartGame()
	{
		if (this.m_isRestartingGame)
		{
			return;
		}
		RuntimeSceneMetaData sceneInformation = Scenes.Manager.GetSceneInformation("titleScreenSwallowsNest");
		if (sceneInformation == null)
		{
			return;
		}
		this.Timer.Reset();
		this.MainMenuCanBeOpened = false;
		this.RequireInitialValues = true;
		GameController.Instance.IsLoadingGame = false;
		InstantLoadScenesController.Instance.OnGameReset();
		GoToSceneController.Instance.GoToScene(sceneInformation, new Action(this.OnFinishedRestarting), false);
	}

	// Token: 0x060033FE RID: 13310 RVA: 0x00028FCC File Offset: 0x000271CC
	private void OnFinishedRestarting()
	{
		base.StartCoroutine(this.RestartingCleanupNextFrame());
	}

	// Token: 0x060033FF RID: 13311 RVA: 0x000D57C0 File Offset: 0x000D39C0
	[DebuggerHidden]
	public IEnumerator RestartingCleanupNextFrame()
	{
		GameController.<RestartingCleanupNextFrame>c__Iterator43 <RestartingCleanupNextFrame>c__Iterator = new GameController.<RestartingCleanupNextFrame>c__Iterator43();
		<RestartingCleanupNextFrame>c__Iterator.<>f__this = this;
		return <RestartingCleanupNextFrame>c__Iterator;
	}

	// Token: 0x17000815 RID: 2069
	// (get) Token: 0x06003400 RID: 13312 RVA: 0x00028FDB File Offset: 0x000271DB
	// (set) Token: 0x06003401 RID: 13313 RVA: 0x00028FE3 File Offset: 0x000271E3
	public bool GameplaySuspended
	{
		get;
		set;
	}

	// Token: 0x17000816 RID: 2070
	// (get) Token: 0x06003402 RID: 13314 RVA: 0x00028FEC File Offset: 0x000271EC
	// (set) Token: 0x06003403 RID: 13315 RVA: 0x00028FF4 File Offset: 0x000271F4
	public bool GameplaySuspendedForUI
	{
		get;
		set;
	}

	// Token: 0x17000817 RID: 2071
	// (get) Token: 0x06003404 RID: 13316 RVA: 0x00028FFD File Offset: 0x000271FD
	public bool InputLocked
	{
		get
		{
			return this.LockInput || this.LockInputByAction;
		}
	}

	// Token: 0x17000818 RID: 2072
	// (get) Token: 0x06003405 RID: 13317 RVA: 0x00029013 File Offset: 0x00027213
	// (set) Token: 0x06003406 RID: 13318 RVA: 0x0002901B File Offset: 0x0002721B
	public bool LockInputByAction
	{
		get;
		set;
	}

	// Token: 0x17000819 RID: 2073
	// (get) Token: 0x06003407 RID: 13319 RVA: 0x00029024 File Offset: 0x00027224
	// (set) Token: 0x06003408 RID: 13320 RVA: 0x0002902C File Offset: 0x0002722C
	public bool LockInput
	{
		get;
		set;
	}

	// Token: 0x06003409 RID: 13321 RVA: 0x000D57DC File Offset: 0x000D39DC
	[ContextMenu("Print out sizes of SaveSlot")]
	public void PrintOutSizesOfSaveSlot()
	{
		int num = 0;
		foreach (KeyValuePair<MoonGuid, SaveScene> current in Game.Checkpoint.SaveGameData.Scenes)
		{
			foreach (SaveObject current2 in current.Value.SaveObjects)
			{
				num += current2.Data.MemoryStream.Capacity;
			}
			num += 16;
		}
	}

	// Token: 0x0600340A RID: 13322 RVA: 0x000D5898 File Offset: 0x000D3A98
	public override void Awake()
	{
		if (GameController.Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		GameController.Instance = this;
		this.HandleTrialData();
		this.WarmUpResources();
		base.Awake();
		if (LoadingBootstrap.Instance)
		{
			UnityEngine.Object.Destroy(LoadingBootstrap.Instance.gameObject);
		}
		this.GameScheduler.OnGameAwake.Add(new Action(this.OnGameAwake));
		this.GameScheduler.OnGameAwake.Call();
		this.GameScheduler.OnGameReset.Add(new Action(this.OnGameReset));
		UberGCManager.OnGameStart();
		this.m_systemsGameObject = new GameObject("systems");
		Utility.DontAssociateWithAnyScene(this.m_systemsGameObject);
		base.transform.parent = this.m_systemsGameObject.transform;
		foreach (GameObject current in this.Systems)
		{
			try
			{
				if (current)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(current);
					gameObject.name = current.name;
					gameObject.transform.SetParentMaintainingLocalTransform(this.m_systemsGameObject.transform);
				}
			}
			catch (Exception var_3_127)
			{
			}
		}
		new Telemetry();
		UI.LoadMessageController();
		this.Systems.Clear();
		Application.targetFrameRate = 60;
		UberGCManager.CollectProactiveFull();
	}

	// Token: 0x0600340B RID: 13323 RVA: 0x000D5A30 File Offset: 0x000D3C30
	private void OnGameAwake()
	{
		this.m_restoreCheckpointController = new RestoreCheckpointController();
		Frameworks.Shader.Globals.FogGradientRange = 100f;
		Frameworks.Shader.Globals.FogGradientTexture = Frameworks.Shader.DefaultTextures.Transparent;
		FixedRandom.UpdateValues();
		if (ScenesToSkip.Instance == null)
		{
			new ScenesToSkip();
		}
		SaveSceneManager.Master = base.GetComponent<SaveSceneManager>();
	}

	// Token: 0x0600340C RID: 13324 RVA: 0x000D5A7C File Offset: 0x000D3C7C
	[DebuggerHidden]
	public IEnumerator Start()
	{
		GameController.<Start>c__Iterator44 <Start>c__Iterator = new GameController.<Start>c__Iterator44();
		<Start>c__Iterator.<>f__this = this;
		return <Start>c__Iterator;
	}

	// Token: 0x0600340D RID: 13325 RVA: 0x000D5A98 File Offset: 0x000D3C98
	private void OnApplicationFocus(bool focusStatus)
	{
		this.m_setRunInBackgroundToFalse = false;
		Application.runInBackground = true;
		GameController.IsFocused = true;
	}

	// Token: 0x0600340E RID: 13326 RVA: 0x000D5AFC File Offset: 0x000D3CFC
	[DebuggerHidden]
	private IEnumerator SetRunInBackgroundToTrue()
	{
		GameController.<SetRunInBackgroundToTrue>c__Iterator45 <SetRunInBackgroundToTrue>c__Iterator = new GameController.<SetRunInBackgroundToTrue>c__Iterator45();
		<SetRunInBackgroundToTrue>c__Iterator.<>f__this = this;
		return <SetRunInBackgroundToTrue>c__Iterator;
	}

	// Token: 0x0600340F RID: 13327 RVA: 0x000D5B18 File Offset: 0x000D3D18
	[DebuggerHidden]
	private IEnumerator LoadAssets(List<string> assetsToLoad)
	{
		GameController.<LoadAssets>c__Iterator46 <LoadAssets>c__Iterator = new GameController.<LoadAssets>c__Iterator46();
		<LoadAssets>c__Iterator.assetsToLoad = assetsToLoad;
		<LoadAssets>c__Iterator.<$>assetsToLoad = assetsToLoad;
		return <LoadAssets>c__Iterator;
	}

	// Token: 0x06003410 RID: 13328 RVA: 0x00029035 File Offset: 0x00027235
	public override void OnDestroy()
	{
		InstantiateUtility.Destroy(this.m_systemsGameObject);
		SuspensionManager.Unregister(this);
		base.OnDestroy();
	}

	// Token: 0x06003411 RID: 13329 RVA: 0x0002904E File Offset: 0x0002724E
	public void ResetInputLocks()
	{
		this.LockInputByAction = false;
		this.LockInput = false;
	}

	// Token: 0x06003412 RID: 13330 RVA: 0x000D5B3C File Offset: 0x000D3D3C
	public override void Serialize(Archive ar)
	{
		if (ar.Reading)
		{
			this.ResetInputLocks();
		}
		WorldEventsManager.Instance.Serialize(ar);
		TriggerByString.SerializeStringTriggers(ar);
		ar.Serialize(0f);
		ar.Serialize(ref this.GameTime);
		ar.Serialize(0);
		ar.Serialize(0);
		ar.Serialize(ref this.RequireInitialValues);
		if (ar.Reading)
		{
			this.RequireInitialValues = false;
		}
		Game.Objectives.Serialize(ar);
	}

	// Token: 0x06003413 RID: 13331 RVA: 0x000D5BB8 File Offset: 0x000D3DB8
	public void WarmUpResources()
	{
		Timer arg_32_0 = new Timer();
		UI.LoadMessageController();
		Orbs.OrbDisplayText.LoadOrbText();
		Attacking.DamageDisplayText.LoadDamageText();
		Sound.LoadAudioParent();
		UberGhostTrail.WarmUpResource();
		MixerManager.WarmUpResource();
		InteractionRotationModifier.WarmUpResource();
		Randomizer.initialize();
		arg_32_0.Report("Warming resources");
		this.Resources.Clear();
	}

	// Token: 0x06003414 RID: 13332 RVA: 0x0002905E File Offset: 0x0002725E
	public void SetupGameplay(SceneRoot sceneRoot, WorldEventsOnAwake worldEventsOnAwake)
	{
		sceneRoot.MetaData.InitialValues.ApplyInitialValues();
		this.WarmUpResources();
		if (worldEventsOnAwake != null)
		{
			worldEventsOnAwake.Apply();
		}
		LateStartHook.AddLateStartMethod(new Action(this.CreateCheckpoint));
	}

	// Token: 0x06003415 RID: 13333 RVA: 0x00029099 File Offset: 0x00027299
	public void OnApplicationQuit()
	{
		GameController.IsClosing = true;
		if (this.m_logCallbackHandler != null)
		{
			this.m_logCallbackHandler.FlushEntriesToFile(this.m_logOutputFile);
		}
		MoonDebug.OnApplicationQuit();
	}

	// Token: 0x06003416 RID: 13334
	public void Update()
	{
		Randomizer.Update();
		if (MoonInput.GetKey(KeyCode.LeftAlt) || MoonInput.GetKey(KeyCode.RightAlt))
		{
			if (MoonInput.GetKeyDown(KeyCode.U))
			{
				SeinUI.DebugHideUI = !SeinUI.DebugHideUI;
				return;
			}
			if (MoonInput.GetKeyDown(KeyCode.T))
			{
				Randomizer.playLastMessage();
				return;
			}
			if (MoonInput.GetKeyDown(KeyCode.R))
			{
				Randomizer.returnToStart();
				return;
			}
			if ((MoonInput.GetKeyDown(KeyCode.LeftControl) || MoonInput.GetKeyDown(KeyCode.RightControl)) && MoonInput.GetKeyDown(KeyCode.L))
			{
				Randomizer.showHint("Reloading");
				Randomizer.initialize();
			}
		}
	}

	// Token: 0x06003417 RID: 13335 RVA: 0x000028E7 File Offset: 0x00000AE7
	private static void CheckPackageFullyInstalled()
	{
	}

	// Token: 0x06003418 RID: 13336 RVA: 0x000D5C88 File Offset: 0x000D3E88
	public void FixedUpdate()
	{
		if (Scenes.Manager)
		{
			Scenes.Manager.CheckForScenesFinishedLoading();
		}
		if (!GameController.FreezeFixedUpdate)
		{
			FixedRandom.FixedUpdateIndex++;
			FixedRandom.UpdateValues();
		}
		Music.UpdateMusic();
		Ambience.UpdateAmbience();
		this.GameScheduler.OnGameFixedUpdate.Call();
		Respawner.UpdateRespawners();
		if (!GameStateMachine.Instance.IsInExtendedTitleScreen() && !UI.MainMenuVisible && (Screen.width != this.m_previousScreenWidth || Screen.height != this.m_previousScreenHeight))
		{
			UI.Menu.ShowResumeScreen();
		}
		this.m_previousScreenWidth = Screen.width;
		this.m_previousScreenHeight = Screen.height;
		if (this.m_lastDebugControlsEnabledValue != DebugMenuB.DebugControlsEnabled)
		{
			this.m_lastDebugControlsEnabledValue = DebugMenuB.DebugControlsEnabled;
		}
		if (!this.IsSuspended)
		{
			this.GameTime += Time.deltaTime;
		}
	}

	// Token: 0x06003419 RID: 13337 RVA: 0x000290C2 File Offset: 0x000272C2
	public Objective GetObjectiveFromIndex(int index)
	{
		if (this.Objectives.Count > index && index >= 0)
		{
			return this.Objectives[index];
		}
		return null;
	}

	// Token: 0x0600341A RID: 13338 RVA: 0x000290EA File Offset: 0x000272EA
	public int GetObjectiveIndex(Objective objective)
	{
		return this.Objectives.IndexOf(objective);
	}

	// Token: 0x0600341B RID: 13339 RVA: 0x000D5D7C File Offset: 0x000D3F7C
	public void SuspendGameplay()
	{
		if (!this.GameplaySuspended)
		{
			Component[] suspendables = Characters.Sein.Controller.Suspendables;
			this.m_suspendablesToIgnoreForGameplay = new HashSet<ISuspendable>(suspendables.Cast<ISuspendable>());
			SuspensionManager.SuspendExcluding(this.m_suspendablesToIgnoreForGameplay);
			this.GameplaySuspended = true;
		}
	}

	// Token: 0x0600341C RID: 13340 RVA: 0x000290F8 File Offset: 0x000272F8
	public void ResumeGameplay()
	{
		if (this.GameplaySuspended)
		{
			SuspensionManager.ResumeExcluding(this.m_suspendablesToIgnoreForGameplay);
			this.m_suspendablesToIgnoreForGameplay.Clear();
			this.GameplaySuspended = false;
		}
	}

	// Token: 0x0600341D RID: 13341 RVA: 0x00029122 File Offset: 0x00027322
	public void SuspendGameplayForUI()
	{
		if (!this.GameplaySuspendedForUI)
		{
			SuspensionManager.SuspendAll();
			this.GameplaySuspendedForUI = true;
		}
	}

	// Token: 0x0600341E RID: 13342 RVA: 0x0002913B File Offset: 0x0002733B
	public void ResumeGameplayForUI()
	{
		if (this.GameplaySuspendedForUI)
		{
			SuspensionManager.ResumeAll();
			this.GameplaySuspendedForUI = false;
		}
	}

	// Token: 0x0600341F RID: 13343 RVA: 0x000D5DC8 File Offset: 0x000D3FC8
	public void CreateCheckpoint()
	{
		SaveGameData saveGameData = Game.Checkpoint.SaveGameData;
		SaveSceneManager.Master.SaveWithoutClearing(saveGameData.Master);
		saveGameData.ApplyPendingScenes();
		if (Scenes.Manager)
		{
			foreach (SceneManagerScene current in Scenes.Manager.ActiveScenes)
			{
				if (current.IsVisible && current.HasStartBeenCalled && current.SceneRoot.SaveSceneManager)
				{
					current.SceneRoot.SaveSceneManager.Save(saveGameData.InsertScene(current.MetaData.SceneMoonGuid));
				}
			}
		}
		Game.Checkpoint.Events.OnPostCreate.Call();
	}

	// Token: 0x06003420 RID: 13344 RVA: 0x00029154 File Offset: 0x00027354
	public void ClearCheckpointData()
	{
		Game.Checkpoint.SaveGameData.ClearAllData();
	}

	// Token: 0x06003421 RID: 13345 RVA: 0x00029160 File Offset: 0x00027360
	public void RestoreCheckpoint(Action onFinished = null)
	{
		this.IsLoadingGame = true;
		this.m_onRestoreCheckpointFinished = onFinished;
		LateStartHook.AddLateStartMethod(new Action(this.RestoreCheckpointImmediate));
	}

	// Token: 0x06003422 RID: 13346 RVA: 0x00029181 File Offset: 0x00027381
	public void RestoreCheckpointImmediate()
	{
		this.m_restoreCheckpointController.RestoreCheckpoint();
		if (this.m_onRestoreCheckpointFinished != null)
		{
			this.m_onRestoreCheckpointFinished();
			this.m_onRestoreCheckpointFinished = null;
		}
	}

	// Token: 0x06003423 RID: 13347 RVA: 0x000D5EA0 File Offset: 0x000D40A0
	private void HandleTrialData()
	{
		if (this.IsTrial)
		{
			return;
		}
		if (OutputFolder.PlayerTrialDataFolderPath == OutputFolder.PlayerDataFolderPath)
		{
			return;
		}
		if (!Directory.Exists(OutputFolder.PlayerTrialDataFolderPath))
		{
			return;
		}
		string[] files = Directory.GetFiles(OutputFolder.PlayerTrialDataFolderPath);
		for (int i = 0; i < files.Length; i++)
		{
			string fileName = Path.GetFileName(files[i]);
			string path = Path.Combine(OutputFolder.PlayerDataFolderPath, fileName);
			if (!File.Exists(path))
			{
				File.Move(files[i], Path.Combine(OutputFolder.PlayerDataFolderPath, fileName));
			}
		}
		if (Directory.GetFiles(OutputFolder.PlayerTrialDataFolderPath).Length == 0)
		{
			Directory.Delete(OutputFolder.PlayerTrialDataFolderPath);
		}
	}

	// Token: 0x06003424 RID: 13348 RVA: 0x000028E7 File Offset: 0x00000AE7
	[Conditional("NOT_FINAL_BUILD")]
	private void HandleBuildName()
	{
	}

	// Token: 0x06003425 RID: 13349 RVA: 0x000028E7 File Offset: 0x00000AE7
	[Conditional("NOT_FINAL_BUILD")]
	private void HandleCommands()
	{
	}

	// Token: 0x06003426 RID: 13350 RVA: 0x000028E7 File Offset: 0x00000AE7
	[Conditional("NOT_FINAL_BUILD")]
	private void HandleBuildIDString()
	{
	}

	// Token: 0x1700081A RID: 2074
	// (get) Token: 0x06003427 RID: 13351 RVA: 0x000291AB File Offset: 0x000273AB
	public bool GameInTitleScreen
	{
		get
		{
			return GameStateMachine.Instance.CurrentState == GameStateMachine.State.TitleScreen || GameStateMachine.Instance.CurrentState == GameStateMachine.State.StartScreen;
		}
	}

	// Token: 0x1700081B RID: 2075
	// (get) Token: 0x06003428 RID: 13352 RVA: 0x000291CD File Offset: 0x000273CD
	// (set) Token: 0x06003429 RID: 13353 RVA: 0x000291D5 File Offset: 0x000273D5
	public bool IsSuspended
	{
		get;
		set;
	}

	// Token: 0x1700081C RID: 2076
	// (get) Token: 0x0600342A RID: 13354 RVA: 0x000291DE File Offset: 0x000273DE
	// (set) Token: 0x0600342B RID: 13355 RVA: 0x000291E6 File Offset: 0x000273E6
	public bool PreventFocusPause
	{
		get;
		set;
	}

	// Token: 0x04002EC0 RID: 11968
	public const string TitleScreenSceneName = "titleScreenSwallowsNest";

	// Token: 0x04002EC1 RID: 11969
	public const string TrialEndScreenSceneName = "trialEndScreen";

	// Token: 0x04002EC2 RID: 11970
	public const string IntroLogosSceneName = "introLogos";

	// Token: 0x04002EC3 RID: 11971
	public const string TrailerSceneName = "trailerScene";

	// Token: 0x04002EC4 RID: 11972
	public const string WorldMapSceneName = "worldMapScene";

	// Token: 0x04002EC5 RID: 11973
	public const string EmptyTestSceneName = "emptyTestScene";

	// Token: 0x04002EC6 RID: 11974
	public const string BootLoadSceneName = "loadBootstrap";

	// Token: 0x04002EC7 RID: 11975
	public const string GameStartScene = "sunkenGladesRunaway";

	// Token: 0x04002EC8 RID: 11976
	public GameTimer Timer;

	// Token: 0x04002EC9 RID: 11977
	public static GameController Instance;

	// Token: 0x04002ECA RID: 11978
	public static bool FreezeFixedUpdate;

	// Token: 0x04002ECB RID: 11979
	public static bool IsClosing;

	// Token: 0x04002ECC RID: 11980
	public SaveGameController SaveGameController = new SaveGameController();

	// Token: 0x04002ECD RID: 11981
	public List<GameObject> Systems = new List<GameObject>();

	// Token: 0x04002ECE RID: 11982
	public GameScheduler GameScheduler = new GameScheduler();

	// Token: 0x04002ECF RID: 11983
	public AllContainer<Objective> ActiveObjectives = new AllContainer<Objective>();

	// Token: 0x04002ED0 RID: 11984
	public List<Objective> Objectives = new List<Objective>();

	// Token: 0x04002ED1 RID: 11985
	public string BuildIDString = string.Empty;

	// Token: 0x04002ED2 RID: 11986
	public string BuildName = string.Empty;

	// Token: 0x04002ED3 RID: 11987
	public UberAtlassingPlatform AtlasPlatform;

	// Token: 0x04002ED4 RID: 11988
	private HashSet<ISuspendable> m_suspendablesToIgnoreForGameplay = new HashSet<ISuspendable>();

	// Token: 0x04002ED5 RID: 11989
	private GameObject m_systemsGameObject;

	// Token: 0x04002ED6 RID: 11990
	private LogCallbackHandler m_logCallbackHandler;

	// Token: 0x04002ED7 RID: 11991
	private RestoreCheckpointController m_restoreCheckpointController = new RestoreCheckpointController();

	// Token: 0x04002ED8 RID: 11992
	public int VSyncCount = 1;

	// Token: 0x04002ED9 RID: 11993
	private string m_logOutputFile = string.Empty;

	// Token: 0x04002EDA RID: 11994
	public float GameTime;

	// Token: 0x04002EDB RID: 11995
	public ActionSequence GameSaveSequence;

	// Token: 0x04002EDC RID: 11996
	public static bool IsFocused = true;

	// Token: 0x04002EDD RID: 11997
	private static volatile bool m_isPackageFullyInstalled;

	// Token: 0x04002EDE RID: 11998
	public bool PCTrialValue;

	// Token: 0x04002EDF RID: 11999
	public bool EditorTrialValue;

	// Token: 0x04002EE0 RID: 12000
	public WorldEvents DebugWorldEvents;

	// Token: 0x04002EE1 RID: 12001
	private bool m_isRestartingGame;

	// Token: 0x04002EE2 RID: 12002
	private bool m_setRunInBackgroundToFalse;

	// Token: 0x04002EE3 RID: 12003
	public bool RequireInitialValues = true;

	// Token: 0x04002EE4 RID: 12004
	public bool IsLoadingGame;

	// Token: 0x04002EE5 RID: 12005
	public List<UnityEngine.Object> Resources;

	// Token: 0x04002EE6 RID: 12006
	private bool m_lastDebugControlsEnabledValue;

	// Token: 0x04002EE7 RID: 12007
	private int m_previousScreenWidth;

	// Token: 0x04002EE8 RID: 12008
	private int m_previousScreenHeight;

	// Token: 0x04002EE9 RID: 12009
	private float m_isPackageFullyInstalledTimer;

	// Token: 0x04002EEA RID: 12010
	private Action m_onRestoreCheckpointFinished;
}
