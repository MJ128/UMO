using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public abstract class FriendListSceneBase : TransitionRoot
	{
		protected enum NetType
		{
			FriendRequest = 0,
			FriendRequestCancel = 1,
			FriendAccept = 2,
			FriendReject = 3,
			FriendRelease = 4,
		}

		private const float m_statusChangeSec = 3;
		protected GeneralListButtonRuntime m_buttonRuntime; // 0x48
		protected GuestListWindow m_windowUi; // 0x4C
		protected List<FriendListElem> m_elems = new List<FriendListElem>(); // 0x50
		protected SwapScrollList m_scrollList; // 0x54
		protected List<DivaIconDecoration> m_divaDecos = new List<DivaIconDecoration>(); // 0x58
		protected List<SceneIconDecoration> m_sceneDecos = new List<SceneIconDecoration>(); // 0x5C
		protected SortItem m_sortType; // 0x60
		protected GeneralList.SortOrder m_sortOrder; // 0x64
		protected uint m_rarityFilter; // 0x68
		protected uint m_attrFilter; // 0x6C
		protected uint m_seriesFilter; // 0x70
		private bool m_saveDataDirty; // 0x74
		private bool m_holdFriendInfo; // 0x75
		private int m_connectCount; // 0x78
		protected List<EAJCBFGKKFA_FriendInfo> friends = new List<EAJCBFGKKFA_FriendInfo>(); // 0x7C
		protected List<FriendListInfo> m_friendInfoAllList = new List<FriendListInfo>(); // 0x80
		protected List<FriendListInfo> m_friendInfoList = new List<FriendListInfo>(); // 0x84
		private Action m_decorationUpdater; // 0x88
		private CompatibleLayoutAnimeParam animParam; // 0x8C
		private ElemStatusChange m_statusChange = new ElemStatusChange(); // 0xA0

		protected string friendNotFoundMessage { get; set; } // 0x98
		protected string friendAllFilteredMessage { get; set; } // 0x9C
		//protected abstract SortItem[] sortTypeList { get; } // RVA: -1 Offset: -1 Slot: 31
		protected abstract SortItem defaultSortType { get; } // RVA: -1 Offset: -1 Slot: 32
		protected abstract PopupSortMenu.SortPlace sortPlace { get; } // RVA: -1 Offset: -1 Slot: 33
		protected abstract ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList sortSaveData { get; } // RVA: -1 Offset: -1 Slot: 34
		protected abstract GuestListWindow.CounterStyle listCounterSyle { get; } // RVA: -1 Offset: -1 Slot: 35
		protected virtual int listCounterCount { get { return 0; } } //0xBAC8C0 Slot: 36
		protected virtual int listCounterMax { get { return 0; } } //0xBAC8C8 Slot: 37
		//protected virtual bool listCounterLimitOver { get; } 0xBAC8D0 Slot: 38
		protected virtual bool emptyButtonLock { get { return true; } } //0xBAC8D8 Slot: 39
		protected virtual string cautionMessage { get { return ""; } } //0xBAC8E0 Slot: 40
		protected NetType lastNetType { get; set; } // 0xA4
		protected PIGBKEIAMPE_FriendManager friendManager { get { return CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager; } } //0xBA1AA8

		// RVA: 0xBAC084 Offset: 0xBAC084 VA: 0xBAC084 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_statusChange.Setup(3);
			m_statusChange.onChangeEvent = () =>
			{
				//0xBAF1C8
				for(int i = 0; i < m_elems.Count; i++)
				{
					m_elems[i].SwapStatus(false);
				}
			};
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0xBAC200 Offset: 0xBAC200 VA: 0xBAC200 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_windowUi.SetCount("");
			m_windowUi.SetMax("");
			UpdateCautionMessage();
			m_windowUi.Hide();
			m_buttonRuntime.Hide();
			Initialize();
		}

		// RVA: 0xBAC3C0 Offset: 0xBAC3C0 VA: 0xBAC3C0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !m_windowUi.IsPlaying() && !m_buttonRuntime.IsPlaying() && base.IsEndPreSetCanvas();
		}

		// RVA: 0xBAC434 Offset: 0xBAC434 VA: 0xBAC434 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			m_windowUi.transform.SetAsLastSibling();
			m_buttonRuntime.transform.SetAsLastSibling();
			return base.IsEndPostSetCanvas();
		}

		// RVA: 0xBAC4D0 Offset: 0xBAC4D0 VA: 0xBAC4D0 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(m_friendInfoAllList.IsEmpty())
			{
				m_buttonRuntime.SetFriendButtonLock(emptyButtonLock);
			}
			else
			{
				m_buttonRuntime.SetFriendButtonLock(false);
			}
			m_buttonRuntime.Enter();
			m_windowUi.Enter();
		}

		// RVA: 0xBAC5D4 Offset: 0xBAC5D4 VA: 0xBAC5D4 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_buttonRuntime.IsPlaying() && !m_windowUi.IsPlaying();
		}

		// RVA: 0xBAC634 Offset: 0xBAC634 VA: 0xBAC634
		private void Update()
		{
			m_statusChange.Update();
			if (m_decorationUpdater != null)
				m_decorationUpdater();
		}

		// RVA: 0xBAC678 Offset: 0xBAC678 VA: 0xBAC678 Slot: 14
		protected override void OnDestoryScene()
		{
			Release();
		}

		// RVA: 0xBAC688 Offset: 0xBAC688 VA: 0xBAC688 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_statusChange.Deactivate();
			m_buttonRuntime.Leave();
			m_windowUi.Leave();
		}

		// RVA: 0xBAC6F8 Offset: 0xBAC6F8 VA: 0xBAC6F8 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			if(!m_buttonRuntime.IsPlaying() && !m_windowUi.IsPlaying())
			{
				if (!m_holdFriendInfo)
				{
					friends.Clear();
					m_friendInfoAllList.Clear();
					m_friendInfoList.Clear();
				}
				m_holdFriendInfo = false;
				if(m_saveDataDirty)
				{
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				}
				return base.IsEndExitAnimation();
			}
			return false;
		}
		
		//// RVA: -1 Offset: -1 Slot: 41
		protected abstract void Initialize();

		//// RVA: -1 Offset: -1 Slot: 42
		protected abstract void Release();

		//// RVA: 0xBA2880 Offset: 0xBA2880 VA: 0xBA2880
		protected bool CheckTransitByReturn()
		{
			return PrevTransition == TransitionList.Type.PROFIL;
		}

		//// RVA: 0xBA2100 Offset: 0xBA2100 VA: 0xBA2100
		protected void InitializeDecos()
		{
			m_divaDecos.Capacity = m_elems.Count;
			m_sceneDecos.Capacity = m_elems.Count;
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_divaDecos.Add(new DivaIconDecoration(m_elems[i].GetDivaIconObject(), DivaIconDecoration.Size.S, true, true, null, null));
				m_sceneDecos.Add(new SceneIconDecoration(m_elems[i].GetSceneIconObject(), SceneIconDecoration.Size.M, null, null));
			}
			animParam.Initialize(0, 0);
			m_decorationUpdater = () =>
			{
				//0xBAF2B4
				int f = animParam.UpdateFrame(Time.deltaTime);
				for(int i = 0; i < m_divaDecos.Count; i++)
				{
					m_divaDecos[i].FadeFrienFanAnimationSetFrame(f);
				}
			};
		}

		//// RVA: 0xBA2E5C Offset: 0xBA2E5C VA: 0xBA2E5C
		protected void ReleaseDecos()
		{
			for(int i = 0; i < m_divaDecos.Count; i++)
			{
				m_divaDecos[i].Release();
			}
			m_divaDecos.Clear();
			for(int i = 0; i < m_sceneDecos.Count; i++)
			{
				m_sceneDecos[i].Release();
			}
			m_sceneDecos.Clear();
		}

		//// RVA: 0xBA28A4 Offset: 0xBA28A4 VA: 0xBA28A4
		protected void InitializeStatusChange()
		{
			m_statusChange.Activate(false);
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].ChangeStatus(true, true);
			}
		}

		//// RVA: 0xBA246C Offset: 0xBA246C VA: 0xBA246C
		protected void InitializeSortSetting()
		{
			m_sortType = (SortItem)sortSaveData.LHPDCGNKPHD_sortItem;
			m_sortOrder = (GeneralList.SortOrder)sortSaveData.EILKGEADKGH_order;
			m_rarityFilter = (uint)sortSaveData.ACCHOFLOOEC_filter;
			m_attrFilter = (uint)sortSaveData.BOFFOHHLLFG_attributeFilter;
			m_seriesFilter = (uint)sortSaveData.BBIIHLNBHDE_seriaseFilter;
		}

		//// RVA: 0xBA2520 Offset: 0xBA2520 VA: 0xBA2520
		protected void OnChangeSortType()
		{
			m_buttonRuntime.SetSortType(m_sortType);
			SortItem sortType = m_sortType;
			if (m_sortType < SortItem.Request && ((1 << (int)m_sortType) & 0x20060U) != 0) // 0010 0000 0000 0110 0000
				sortType = defaultSortType;
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetParamTable(sortType);
			}
		}

		//// RVA: 0xBA265C Offset: 0xBA265C VA: 0xBA265C
		protected void OnChangeSortOrder()
		{
			m_buttonRuntime.SetSortOrder(m_sortOrder);
		}

		//// RVA: 0xBAC944 Offset: 0xBAC944 VA: 0xBAC944
		protected void OnClickSortButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowSortWindow(sortPlace, (PopupSortMenu popup) =>
			{
				//0xBAF3B0
				m_sortType = popup.SortItem;
				m_rarityFilter = popup.GetRarityFilter();
				m_attrFilter = popup.GetAttributeFilter();
				m_seriesFilter = popup.GetSeriaseFilter();
				OnChangeSortType();
				SortFriendList();
			}, null);
		}

		//// RVA: 0xBACAA4 Offset: 0xBACAA4 VA: 0xBACAA4
		protected void OnClickOrderButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_sortOrder = m_sortOrder == GeneralList.SortOrder.Ascend ? GeneralList.SortOrder.Descend : GeneralList.SortOrder.Ascend;
			m_saveDataDirty = true;
			sortSaveData.EILKGEADKGH_order = (int)m_sortOrder;
			OnChangeSortOrder();
			SortFriendList();
		}

		//// RVA: 0xBA4B40 Offset: 0xBA4B40 VA: 0xBA4B40
		protected void SortFriendList()
		{
			m_friendInfoAllList.Sort(SortDelegate);
			m_friendInfoList.Clear();
			m_friendInfoList.Capacity = m_friendInfoAllList.Count;
			for(int i = 0; i < m_friendInfoAllList.Count; i++)
			{
				if (PopupSortMenu.IsRarityFilterOn(m_friendInfoAllList[i].sceneRarity, m_rarityFilter) &&
					PopupSortMenu.IsAttributeFilterOn((int)m_friendInfoAllList[i].sceneAttr, m_attrFilter) &&
					PopupSortMenu.IsSerializeFilterOn((int)m_friendInfoAllList[i].sceneSeries, m_seriesFilter))
				{
					m_friendInfoList.Add(m_friendInfoAllList[i]);
				}
			}
			if(m_friendInfoList.IsEmpty())
			{
				m_windowUi.SetMessageVisible(true);
				if(m_friendInfoAllList.IsEmpty())
				{
					m_buttonRuntime.SetFriendButtonLock(emptyButtonLock);
					m_windowUi.SetMessage(friendNotFoundMessage);
				}
				else
				{
					m_buttonRuntime.SetFriendButtonLock(false);
					m_windowUi.SetMessage(friendAllFilteredMessage);
				}
			}
			else
			{
				m_windowUi.SetMessageVisible(false);
				m_buttonRuntime.SetFriendButtonLock(false);
			}
			UpdateCautionMessage();
			UpdateListCounter();
			m_scrollList.SetItemCount(m_friendInfoList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0xBAF470
				OnUpdateListItem(index, content as GeneralListContent, m_friendInfoList[index]);
			});
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		//// RVA: 0xBACB5C Offset: 0xBACB5C VA: 0xBACB5C
		private int SortDelegate(FriendListInfo a, FriendListInfo b)
		{
			int res = 0;
			switch(m_sortType)
			{
				case SortItem.Total:
					res = a.total.CompareTo(b.total);
					break;
				case SortItem.Soul:
					res = a.soul.CompareTo(b.soul);
					break;
				case SortItem.Voice:
					res = a.voice.CompareTo(b.voice);
					break;
				case SortItem.Charm:
					res = a.charm.CompareTo(b.charm);
					break;
				default:
					break;
				case SortItem.Rarity:
					res = a.sceneRarity.CompareTo(b.sceneRarity);
					break;
				case SortItem.Level:
					res = a.sceneLevel.CompareTo(b.sceneLevel);
					break;
				case SortItem.Life:
					res = a.life.CompareTo(b.life);
					break;
				case SortItem.Luck:
					res = a.luck.CompareTo(b.luck);
					break;
				case SortItem.Support:
					res = a.support.CompareTo(b.support);
					break;
				case SortItem.Fold:
					res = a.fold.CompareTo(b.fold);
					break;
				case SortItem.LastPlayDate:
					res = a.lastLogin.CompareTo(b.lastLogin);
					break;
				case SortItem.PlayerRunk:
					res = a.playerRank.CompareTo(b.playerRank);
					break;
				case SortItem.Request:
					res = a.requestDate.CompareTo(b.requestDate);
					break;
				case SortItem.HighScoreRating:
					res = a.musicRatio.CompareTo(b.musicRatio);
					break;
			}
			if(res == 0)
			{
				res = GetBaseRaritySortValue(a, b);
				if(res == 0)
				{
					res = b.sceneId.CompareTo(a.sceneId);
					if (res != 0)
						return res;
					return a.ListIndex.CompareTo(b.ListIndex);
				}
			}
			if (m_sortOrder == GeneralList.SortOrder.Descend)
				res = -res;
			return res;
		}

		//// RVA: 0xBACF50 Offset: 0xBACF50 VA: 0xBACF50
		private int GetBaseRaritySortValue(FriendListInfo a, FriendListInfo b)
		{
			int rarA = 0;
			if (a.friend.AFBMEMCHJCL_MainScene != null)
				rarA = a.friend.AFBMEMCHJCL_MainScene.JKGFBFPIMGA_Rarity;
			int rarB = 0;
			if (b.friend.AFBMEMCHJCL_MainScene != null)
				rarB = b.friend.AFBMEMCHJCL_MainScene.JKGFBFPIMGA_Rarity;
			int res = rarA - rarB;
			if (res != 0)
				return res;

			rarA = 0;
			if (a.friend.AFBMEMCHJCL_MainScene != null)
				rarA = a.friend.AFBMEMCHJCL_MainScene.EKLIPGELKCL_SceneRarity;
			rarB = 0;
			if (b.friend.AFBMEMCHJCL_MainScene != null)
				rarB = b.friend.AFBMEMCHJCL_MainScene.EKLIPGELKCL_SceneRarity;
			return rarA - rarB;
		}

		//// RVA: 0xBAD0E0 Offset: 0xBAD0E0 VA: 0xBAD0E0
		private void OnUpdateListItem(int index, GeneralListContent content, FriendListInfo info)
		{
			FriendListElem elem = content.GetElemUI<FriendListElem>();
			elem.SetName(info.name);
			elem.SetLevel(info.playerRank.ToString());
			elem.SetLoginDate(info.login);
			elem.SetRequestDate(info.request);
			elem.SetTotal(info.total.ToString());
			elem.SetSoul(info.soul.ToString());
			elem.SetVoice(info.voice.ToString());
			elem.SetCharm(info.charm.ToString());
			elem.SetLife(info.life.ToString());
			elem.SetSupport(info.support.ToString());
			elem.SetFold(info.fold.ToString());
			elem.SetLuck(UnitWindowConstant.MakeLuckText(info.luck));
			elem.SetSceneStarNum(info.sceneRarity);
			elem.SetComment(info.comment);
			elem.SetSkill(info.skill);
			elem.SetSkillLevel(info.skillLevel);
			elem.SetSkillRank(info.skillRank);
			elem.SetMusicRatio(info.musicRatio.ToString());
			elem.SetMusicRank(info.scoreRatingRank);
			elem.SetMusicRateRank(info.friend.PCEGKKLKFNO);
			elem.SetKira(info.isKira);
			elem.SetDivaIconDelegate(info.GetFriendDivaIconTex);
			elem.SetSceneIconDelegate(info.GetFriendSceneIconTex);
			int idx = m_elems.IndexOf(elem);
			m_divaDecos[idx].SetActive(true);
			m_divaDecos[idx].Change(info.friend.JIGONEMPPNP_Diva, info.friend, DisplayType.Level, info.friend.AFBMEMCHJCL_MainScene);
			m_sceneDecos[idx].SetActive(true);
			m_sceneDecos[idx].Change(info.friend.AFBMEMCHJCL_MainScene, DisplayType.Level);
		}

		//// RVA: 0xBA38F8 Offset: 0xBA38F8 VA: 0xBA38F8
		protected void JumpToProfile(EAJCBFGKKFA_FriendInfo friendData, ProfilMenuLayout.ButtonType btnType = 0)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			m_holdFriendInfo = true;
			ProfilDateArgs arg = new ProfilDateArgs();
			arg.data = friendData;
			arg.infoType = ProfilMenuLayout.InfoType.PLAYER;
			arg.btnType = btnType;
			MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
		}

		//// RVA: 0xBA29A8 Offset: 0xBA29A8 VA: 0xBA29A8
		protected void UpdateListCounter()
		{
			m_windowUi.SetCounterStyle(listCounterSyle);
			if(listCounterSyle != GuestListWindow.CounterStyle.None)
			{
				StringBuilder str = new StringBuilder(32);
				if(listCounterSyle == GuestListWindow.CounterStyle.Fraction)
				{
					str.SetFormat("<color={0}>{1}+</color>", SystemTextColor.ImportantColor, listCounterCount);
				}
				else
				{
					str.SetFormat("{0}", listCounterCount);
				}
				m_windowUi.SetCount(str.ToString());
				if (listCounterSyle == GuestListWindow.CounterStyle.Fraction)
				{
					str.SetFormat("/{0}", listCounterMax);
					m_windowUi.SetMax(str.ToString());
				}
			}
		}

		//// RVA: 0xBAC32C Offset: 0xBAC32C VA: 0xBAC32C
		private void UpdateCautionMessage()
		{
			string msg = cautionMessage;
			if(string.IsNullOrEmpty(msg))
			{
				m_windowUi.SetCautionVisible(false);
			}
			else
			{
				m_windowUi.SetCautionVisible(true);
				m_windowUi.SetCaution(msg);
			}
		}

		//// RVA: 0xBA3A70 Offset: 0xBA3A70 VA: 0xBA3A70
		protected void ConnectStart()
		{
			m_connectCount++;
		}

		//// RVA: 0xBA3F14 Offset: 0xBA3F14 VA: 0xBA3F14
		protected void ConnectEnd()
		{
			if (m_connectCount > 0)
				m_connectCount--;
		}

		//// RVA: 0xBABFC8 Offset: 0xBABFC8 VA: 0xBABFC8
		protected bool IsConnecting()
		{
			return m_connectCount > 0;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E00E4 Offset: 0x6E00E4 VA: 0x6E00E4
		//// RVA: 0xBAC178 Offset: 0xBAC178 VA: 0xBAC178
		private IEnumerator Co_LoadResources()
		{
			//0xED4EA4
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E015C Offset: 0x6E015C VA: 0x6E015C
		//// RVA: 0xBAD6F0 Offset: 0xBAD6F0 VA: 0xBAD6F0
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName;
			XeSys.FontInfo systemFont;
			int bundleLoadCount;
			AssetBundleLoadLayoutOperationBase operation;
			int i;

			//0xED41A0
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/039.xab");
			bundleLoadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GeneralListButton");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xBAF5A8
				instance.transform.SetParent(transform, false);
				m_buttonRuntime = instance.GetComponent<GeneralListButtonRuntime>();
			}));
			bundleLoadCount++;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GuestListWindow");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xBAF678
				instance.transform.SetParent(transform, false);
				m_windowUi = instance.GetComponent<GuestListWindow>();
				m_scrollList = instance.GetComponentInChildren<SwapScrollList>(true);
			}));
			bundleLoadCount++;
			yield return Co.R(Co_LoadListElem(bundleName.ToString(), "UI_FriendListElem", systemFont, m_scrollList.ScrollObjectCount, "FriendListElem {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0xBAF790
				m_scrollList.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
				m_elems.Add(instance.GetComponent<FriendListElem>());
			}));
			yield return Co.R(Co_LoadBothLayout(bundleName.ToString()));
			for(i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			while (!m_buttonRuntime.IsLoaded())
				yield return null;
			while (!m_windowUi.IsLoaded())
				yield return null;
			for (i = 0; i < m_elems.Count; i++)
			{
				while (!m_elems[i].IsLoaded())
					yield return null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E01D4 Offset: 0x6E01D4 VA: 0x6E01D4
		//// RVA: 0xBAD778 Offset: 0xBAD778 VA: 0xBAD778 Slot: 43
		protected virtual IEnumerator Co_LoadBothLayout(string bundleName)
		{
			//0xED40CC
			yield break;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E024C Offset: 0x6E024C VA: 0x6E024C
		//// RVA: 0xBAD7E8 Offset: 0xBAD7E8 VA: 0xBAD7E8
		protected static IEnumerator Co_LoadListElem(string bundleName, string assetName, XeSys.FontInfo font, int elemCount, string elemNameFormat, Action<LayoutUGUIRuntime> onLoadedElem)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xED49A0
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xED3798
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format(elemNameFormat, 0);
				onLoadedElem(baseRuntime);
			}));
			for(int i = 1; i < elemCount; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format(elemNameFormat, i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				onLoadedElem(r);
			}
		}

		//// RVA: 0xBAB1D4 Offset: 0xBAB1D4 VA: 0xBAB1D4
		protected void ShowFriendReleasePopup(FriendListInfo info)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_friend_release_title"), SizeType.Small, string.Format(bk.GetMessageByLabel("popup_friend_release_msg"), info.name), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.FriendRemove, Type = PopupButton.ButtonType.Positive }
			}, false, true);
			MenuScene.Instance.RaycastDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xED38B4
				if (type == PopupButton.ButtonType.Positive)
				{
					DoFriendRelease(info);
				}
				MenuScene.Instance.RaycastEnable();
			}, null, null, null);
		}

		//// RVA: 0xBAD8F4 Offset: 0xBAD8F4 VA: 0xBAD8F4
		protected void ShowFriendRequestPopup(FriendListInfo info)
		{
			TodoLogger.LogNotImplemented("ShowFriendRequestPopup");
		}

		//// RVA: 0xBADCF0 Offset: 0xBADCF0 VA: 0xBADCF0
		protected void ShowFriendRequestCancelPopup(FriendListInfo info)
		{
			TodoLogger.LogNotImplemented("ShowFriendRequestCancelPopup");
		}

		//// RVA: 0xBA3100 Offset: 0xBA3100 VA: 0xBA3100
		protected void ShowFriendAcceptPopup(FriendListInfo info)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_friend_accept_title"), SizeType.Small, string.Format(bk.GetMessageByLabel("popup_friend_accept_msg"), info.name), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Accept, Type = PopupButton.ButtonType.Positive }
			}, false, true);
			MenuScene.Instance.RaycastDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xED3B48
				if (type == PopupButton.ButtonType.Positive)
				{
					DoFriendAccept(info);
				}
				MenuScene.Instance.RaycastEnable();
			}, null, null, null);
		}

		//// RVA: 0xBA34FC Offset: 0xBA34FC VA: 0xBA34FC
		protected void ShowFriendRejectPopup(FriendListInfo info)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_friend_reject_title"), SizeType.Small, string.Format(bk.GetMessageByLabel("popup_friend_reject_msg"), info.name), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Reject, Type = PopupButton.ButtonType.Positive }
			}, false, true);
			MenuScene.Instance.RaycastDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xED3C24
				if(type == PopupButton.ButtonType.Positive)
				{
					DoFriendReject(info);
				}
				MenuScene.Instance.RaycastEnable();
			}, null, null, null);
		}

		//// RVA: 0xBAE0EC Offset: 0xBAE0EC VA: 0xBAE0EC
		private void ShowNetRequestSuccessPopup(string title, string message)
		{
			TextPopupSetting s = PopupWindowManager.CrateTextContent(title, SizeType.Small, message, new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true);
			MenuScene.Instance.RaycastDisable();
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xBAF88C
				OnNetRequestSuccess();
				MenuScene.Instance.RaycastEnable();
			}, null, null, null);
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6E02C4 Offset: 0x6E02C4 VA: 0x6E02C4
		//// RVA: 0xBA3B40 Offset: 0xBA3B40 VA: 0xBA3B40
		//protected FriendListSceneBase.NetType get_lastNetType() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E02D4 Offset: 0x6E02D4 VA: 0x6E02D4
		//// RVA: 0xBAE300 Offset: 0xBAE300 VA: 0xBAE300
		//private void set_lastNetType(FriendListSceneBase.NetType value) { }
		
		//// RVA: 0xBAE308 Offset: 0xBAE308 VA: 0xBAE308
		//protected void DoFriendRequest(FriendListInfo info) { }

		//// RVA: 0xBAE5BC Offset: 0xBAE5BC VA: 0xBAE5BC
		//protected void DoFriendRequestCancel(FriendListInfo info) { }

		//// RVA: 0xBAE864 Offset: 0xBAE864 VA: 0xBAE864
		protected void DoFriendAccept(FriendListInfo info)
		{
			MessageBank msgBank = MessageManager.Instance.GetBank("menu");
			string messageFormat = msgBank.GetMessageByLabel("popup_friend_accepted_msg");
			lastNetType = NetType.FriendAccept;
			MenuScene.Instance.RaycastDisable();
			friendManager.ADOIKCJALGM(info.playerId, info.name, info.playerRank, () =>
			{
				//0xED3F80
				ShowNetRequestSuccessPopup(msgBank.GetMessageByLabel("popup_friend_accepted_title"), string.Format(messageFormat, info.name));
				MenuScene.Instance.RaycastEnable();
			}, OnNetRequestError, OnNetRequestErrorToTitle);
		}

		//// RVA: 0xBAEB0C Offset: 0xBAEB0C VA: 0xBAEB0C
		protected void DoFriendReject(FriendListInfo info)
		{
			MessageBank msgBank = MessageManager.Instance.GetBank("menu");
			string messageFormat = msgBank.GetMessageByLabel("popup_friend_rejected_msg");
			lastNetType = NetType.FriendReject;
			MenuScene.Instance.RaycastDisable();
			friendManager.CCBALBLFNDN(info.playerId, info.name, info.playerRank, () =>
			{
				//0xED3538
				ShowNetRequestSuccessPopup(msgBank.GetMessageByLabel("popup_friend_rejected_title"), string.Format(messageFormat, info.name));
				MenuScene.Instance.RaycastEnable();
			}, OnNetRequestError, OnNetRequestErrorToTitle);
		}

		//// RVA: 0xBAEDB4 Offset: 0xBAEDB4 VA: 0xBAEDB4
		protected void DoFriendRelease(FriendListInfo info)
		{
			MessageBank msgBank = MessageManager.Instance.GetBank("menu");
			string messageFormat = msgBank.GetMessageByLabel("popup_friend_released_msg");
			int lastNetType = 4;
			MenuScene.Instance.RaycastDisable();
			friendManager.PBEDDFMFDKB(info.playerId, info.name, info.playerRank, () =>
			{
				//0xED3668
				ShowNetRequestSuccessPopup(msgBank.GetMessageByLabel("popup_friend_released_title"), string.Format(messageFormat, info.name));
				MenuScene.Instance.RaycastEnable();
			}, OnNetRequestError, OnNetRequestErrorToTitle);
		}

		//// RVA: 0xBAF05C Offset: 0xBAF05C VA: 0xBAF05C Slot: 44
		protected virtual void OnNetRequestSuccess()
		{
			return;
		}

		//// RVA: 0xBAF060 Offset: 0xBAF060 VA: 0xBAF060 Slot: 45
		protected virtual void OnNetRequestError(CACGCMBKHDI_Request error)
		{
			ConnectEnd();
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xBAF110 Offset: 0xBAF110 VA: 0xBAF110 Slot: 46
		protected virtual void OnNetRequestErrorToTitle(CACGCMBKHDI_Request error)
		{
			ConnectEnd();
			MenuScene.Instance.RaycastEnable();
			NetErrorToTitle();
		}

		//// RVA: 0xBA4090 Offset: 0xBA4090 VA: 0xBA4090
		protected void NetErrorToTitle()
		{
			if (MenuScene.Instance.IsTransition())
				GotoTitle();
			else
				MenuScene.Instance.GotoTitle();
		}
	}
}
