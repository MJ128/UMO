
using System.Collections.Generic;
using XeApp.Game.Menu;
using XeSys;

public class LGMEPLIJLNB
{
	public MFDJIFIIPJD GOOIIPFHOIG; // 0x8
	public int LGADCGFMLLD; // 0xC
	public int CCDPNBJMKDI_StartPoint; // 0x10
	public int DNBFMLBNAEE_TotalPoint; // 0x14
	public int OJELCGDDAOM_MissingPoint; // 0x18
	public bool HMEOAKCLKJE_IsReceived; // 0x1C

	//public bool EGKODECGHNM { get; }

	//// RVA: 0x17F4BC8 Offset: 0x17F4BC8 VA: 0x17F4BC8
	//public bool DGCPCNOFLHP() { }

	//// RVA: 0x17F4BDC Offset: 0x17F4BDC VA: 0x17F4BDC
	public static List<LGMEPLIJLNB> FKDIMODKKJD_GetEpisodeRewards(int KELFCMEOPPM)
	{
		List<LGMEPLIJLNB> res = new List<LGMEPLIJLNB>();
        HMGPODKEFBA_EpisodeInfo NDFIEMPPMLF = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM - 1];
        OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveEp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM - 1];
		FMLIFJBPFNA_Step f = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step GHPLINIACBB) => {
			//0x17F58C0
			return GHPLINIACBB.IOFHEGJPHKG_SId == NDFIEMPPMLF.IOFHEGJPHKG_StepId;
		});
		int startPoint = 0;
		for(int i = 0; i < NDFIEMPPMLF.FGOGPCMHPIN_Count; i++)
		{
            short FCEJJEPFIPH = NDFIEMPPMLF.HHJGBJCIFON_Rewards[i];
			JNIKPOIKFAC_Reward r = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards.Find((JNIKPOIKFAC_Reward GHPLINIACBB) => {
				//0x17F590C
				return FCEJJEPFIPH == GHPLINIACBB.EIHOBHDKCDB_RewardId;
			});
			LGMEPLIJLNB data = new LGMEPLIJLNB();
			data.GOOIIPFHOIG = new MFDJIFIIPJD();
			data.GOOIIPFHOIG.KHEKNNFCAOI(r.KIJAPOFAGPN_Item, r.JDLJPNMLFID_Count);
			data.CCDPNBJMKDI_StartPoint = startPoint;
			data.DNBFMLBNAEE_TotalPoint = f.JENFHJDFFAD_Pt[i];
			startPoint = data.DNBFMLBNAEE_TotalPoint;
			int c = data.DNBFMLBNAEE_TotalPoint - saveEp.OGDBKJKIGAJ_CurrentPoint;
			if(c < 1)
				c = 0;
			data.OJELCGDDAOM_MissingPoint = c;
			data.HMEOAKCLKJE_IsReceived = saveEp.MCIHDIBHHBI_IsRewardReceived(i);
			res.Add(data);
        }
		return res;
    }

	//// RVA: 0x17F5250 Offset: 0x17F5250 VA: 0x17F5250
	public static LGMEPLIJLNB BMFKMFNPGPC(int KELFCMEOPPM, bool MPCFDBHLOGM)
	{
		if(KELFCMEOPPM != 0)
		{
			HMGPODKEFBA_EpisodeInfo NDFIEMPPMLF = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM - 1];
			OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM - 1];
			FMLIFJBPFNA_Step step = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step GHPLINIACBB) =>
			{
				//0x17F5944
				return GHPLINIACBB.IOFHEGJPHKG_SId == NDFIEMPPMLF.IOFHEGJPHKG_StepId;
			});
			int a = 1;
			if (MPCFDBHLOGM)
				a = 2;
			a = NDFIEMPPMLF.FGOGPCMHPIN_Count - a;
			int pt = 0;
			for(int i = 0; i < NDFIEMPPMLF.FGOGPCMHPIN_Count; i++)
			{
				int rewardId = NDFIEMPPMLF.HHJGBJCIFON_Rewards[i];
				JNIKPOIKFAC_Reward reward = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards.Find((JNIKPOIKFAC_Reward GHPLINIACBB) =>
				{
					//0x17F5990
					return rewardId == GHPLINIACBB.EIHOBHDKCDB_RewardId;
				});
				if(a == i)
				{
					LGMEPLIJLNB l = new LGMEPLIJLNB();
					l.GOOIIPFHOIG = new MFDJIFIIPJD();
					l.GOOIIPFHOIG.KHEKNNFCAOI(reward.KIJAPOFAGPN_Item, reward.JDLJPNMLFID_Count);
					l.CCDPNBJMKDI_StartPoint = pt;
					l.DNBFMLBNAEE_TotalPoint = step.JENFHJDFFAD_Pt[a];
					l.OJELCGDDAOM_MissingPoint = 0;
					if (pt - saveInfo.OGDBKJKIGAJ_CurrentPoint > 0)
						l.OJELCGDDAOM_MissingPoint = pt - saveInfo.OGDBKJKIGAJ_CurrentPoint;
					l.HMEOAKCLKJE_IsReceived = saveInfo.MCIHDIBHHBI_IsRewardReceived(a);
					return l;
				}
				pt = step.JENFHJDFFAD_Pt[i];
			}
		}
		return null;
	}
}

public class PIGBBNDPPJC
{
	public string OPFGFINHFCE_Name; // 0x8
	public string KLMPFGOCBHC_Description; // 0xC
	public int KELFCMEOPPM_EpId; // 0x10
	public int EAHPLCJMPHD; // 0x14
	public bool CADENLBDAEB_IsNew; // 0x18
	public int FKMAEKNOLJB_EpisodeNo; // 0x1C
	public int FGOGPCMHPIN_Count; // 0x20
	public int JJJNKGBCFMI_Step; // 0x24
	public int ABLHIAEDJAI_CurrentPoint; // 0x28
	public int DMHDNKILKGI_MaxPoint; // 0x2C
	public int LEGAKDFPPHA_AvaiablePoint; // 0x30
	public int KIJAPOFAGPN_UnlockItemId; // 0x34
	public bool CCBKMCLDGAD_HasReward; // 0x38
	public bool JBCIDDKDJMM; // 0x39
	public long BEBJKJKBOGH_Date; // 0x40
	public LGMEPLIJLNB JBFLCHFEIGL; // 0x48

	//public bool OJOLGGKILFL { get; } 0x16D0300 KKEOAGANMNA
	public bool DKMLDEDKPBA_HasEpisode { get { return KELFCMEOPPM_EpId > 0; } } //0x16D0314 PCIINKJELKK
	public bool IIEAILCOPDB { get { return DMHDNKILKGI_MaxPoint <= LEGAKDFPPHA_AvaiablePoint; } } //0x16D0328 EMKGOLJAJBG

	//// RVA: 0x16D0340 Offset: 0x16D0340 VA: 0x16D0340
	public void LEHDLBJJBNC()
	{
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpId - 1].LHMOAJAIJCO_IsNew = false;
	}

	//// RVA: 0x16D0470 Offset: 0x16D0470 VA: 0x16D0470
	public void KHEKNNFCAOI(int KELFCMEOPPM)
	{
		this.KELFCMEOPPM_EpId = KELFCMEOPPM;
		if(KELFCMEOPPM == 0)
		{
			ABLHIAEDJAI_CurrentPoint = 0;
			DMHDNKILKGI_MaxPoint = 0;
			LEGAKDFPPHA_AvaiablePoint = 0;
			KIJAPOFAGPN_UnlockItemId = 0;
			FKMAEKNOLJB_EpisodeNo = 0;
			FGOGPCMHPIN_Count = 0;
			JJJNKGBCFMI_Step = 0;
			OPFGFINHFCE_Name = "";
			KLMPFGOCBHC_Description = "";
			EAHPLCJMPHD = 0;
			CADENLBDAEB_IsNew = false;
			BEBJKJKBOGH_Date = 0;
			JBFLCHFEIGL = null;
			JBCIDDKDJMM = false;
		}
		else
		{
			HMGPODKEFBA_EpisodeInfo NDFIEMPPMLF_epInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM - 1];
			OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo serverEpInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM - 1];
			ABLHIAEDJAI_CurrentPoint = serverEpInfo.OGDBKJKIGAJ_CurrentPoint;
			JJJNKGBCFMI_Step = serverEpInfo.EBIIIAELNAA_Step;
			BEBJKJKBOGH_Date = serverEpInfo.BEBJKJKBOGH_Date;
			FGOGPCMHPIN_Count = NDFIEMPPMLF_epInfo.FGOGPCMHPIN_Count;
			FKMAEKNOLJB_EpisodeNo = NDFIEMPPMLF_epInfo.EILKGEADKGH;
			CADENLBDAEB_IsNew = serverEpInfo.LHMOAJAIJCO_IsNew;
			OPFGFINHFCE_Name = EJOJNFDHDHN_GetEpName(KELFCMEOPPM);
			KLMPFGOCBHC_Description = FKKHNDDGKJB_GetEpDesc(KELFCMEOPPM);
			JBFLCHFEIGL = new LGMEPLIJLNB();
			if(JJJNKGBCFMI_Step < FGOGPCMHPIN_Count)
			{
				short EIHOBHDKCDB = NDFIEMPPMLF_epInfo.HHJGBJCIFON_Rewards[JJJNKGBCFMI_Step];
				FMLIFJBPFNA_Step st = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step GHPLINIACBB) =>
				{
					//0x16D369C
					return NDFIEMPPMLF_epInfo.IOFHEGJPHKG_StepId == GHPLINIACBB.IOFHEGJPHKG_SId;
				});
				JNIKPOIKFAC_Reward rw = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards.Find((JNIKPOIKFAC_Reward GHPLINIACBB) =>
				{
					//0x16D3734
					return EIHOBHDKCDB == GHPLINIACBB.EIHOBHDKCDB_RewardId;
				});
				if(st != null && rw != null)
				{
					JBFLCHFEIGL = new LGMEPLIJLNB();
					JBFLCHFEIGL.GOOIIPFHOIG = new MFDJIFIIPJD();
					JBFLCHFEIGL.GOOIIPFHOIG.KHEKNNFCAOI(rw.KIJAPOFAGPN_Item, rw.JDLJPNMLFID_Count);
					JBFLCHFEIGL.DNBFMLBNAEE_TotalPoint = st.JENFHJDFFAD_Pt[JJJNKGBCFMI_Step];
					JBFLCHFEIGL.OJELCGDDAOM_MissingPoint = JBFLCHFEIGL.DNBFMLBNAEE_TotalPoint - ABLHIAEDJAI_CurrentPoint;
					if (JBFLCHFEIGL.OJELCGDDAOM_MissingPoint < 0)
						JBFLCHFEIGL.OJELCGDDAOM_MissingPoint = 0;
					JBFLCHFEIGL.HMEOAKCLKJE_IsReceived = serverEpInfo.MCIHDIBHHBI_IsRewardReceived(JJJNKGBCFMI_Step);
				}
			}
			int cosItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume, 0);
			int valkItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie, 0);
			int homeBgItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg, 0);
			foreach (var GKJBHCKCKIA in NDFIEMPPMLF_epInfo.HHJGBJCIFON_Rewards)
			{
				JNIKPOIKFAC_Reward rw = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards.Find((JNIKPOIKFAC_Reward GHPLINIACBB) =>
				{
					//0x16D376C
					return GKJBHCKCKIA == GHPLINIACBB.EIHOBHDKCDB_RewardId;
				});
				if((rw.KIJAPOFAGPN_Item >= cosItemId && rw.KIJAPOFAGPN_Item < cosItemId + 10000) ||
					(rw.KIJAPOFAGPN_Item >= valkItemId && rw.KIJAPOFAGPN_Item < valkItemId + 10000) ||
					(rw.KIJAPOFAGPN_Item >= homeBgItemId && rw.KIJAPOFAGPN_Item < homeBgItemId + 10000))
				{
					KIJAPOFAGPN_UnlockItemId = rw.KIJAPOFAGPN_Item;
				}
			}
			FMLIFJBPFNA_Step step = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step GHPLINIACBB) =>
			{
				//0x16D36E8
				return NDFIEMPPMLF_epInfo.IOFHEGJPHKG_StepId == GHPLINIACBB.IOFHEGJPHKG_SId;
			});
			DMHDNKILKGI_MaxPoint = step.JENFHJDFFAD_Pt[FGOGPCMHPIN_Count - 2];
			CCBKMCLDGAD_HasReward = true;
			for(int i = 0; i < FGOGPCMHPIN_Count - 1; i++)
			{
				if(!serverEpInfo.MCIHDIBHHBI_IsRewardReceived(i))
				{
					CCBKMCLDGAD_HasReward = false;
				}
			}
			if(KELFCMEOPPM > 0)
			{
				LEGAKDFPPHA_AvaiablePoint = GMDHJBGLBEI(KELFCMEOPPM);
			}
			JBCIDDKDJMM = FIBLGPNEKEM(KELFCMEOPPM);
		}
	}

	//// RVA: 0x16D18D4 Offset: 0x16D18D4 VA: 0x16D18D4
	public void FBANBDCOEJL()
	{
		if(KELFCMEOPPM_EpId > 0)
		{
			HMGPODKEFBA_EpisodeInfo epInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpId - 1];
			OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveEpInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpId - 1];
			ABLHIAEDJAI_CurrentPoint = saveEpInfo.OGDBKJKIGAJ_CurrentPoint;
			JJJNKGBCFMI_Step = saveEpInfo.EBIIIAELNAA_Step;
			BEBJKJKBOGH_Date = saveEpInfo.BEBJKJKBOGH_Date;
			FGOGPCMHPIN_Count = epInfo.FGOGPCMHPIN_Count;
			FKMAEKNOLJB_EpisodeNo = epInfo.EILKGEADKGH;
			CADENLBDAEB_IsNew = saveEpInfo.LHMOAJAIJCO_IsNew;
			JBFLCHFEIGL = new LGMEPLIJLNB();
			if(JJJNKGBCFMI_Step < FGOGPCMHPIN_Count)
			{
				int EIHOBHDKCDB = epInfo.HHJGBJCIFON_Rewards[JJJNKGBCFMI_Step];
				FMLIFJBPFNA_Step step = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step GHPLINIACBB) =>
				{
					//0x16D37A4
					return GHPLINIACBB.IOFHEGJPHKG_SId == epInfo.IOFHEGJPHKG_StepId;
				});
				JNIKPOIKFAC_Reward reward = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards.Find((JNIKPOIKFAC_Reward GHPLINIACBB) =>
				{
					//0x16D383C
					return EIHOBHDKCDB == GHPLINIACBB.EIHOBHDKCDB_RewardId;
				});
				if(step != null && reward != null)
				{
					LGMEPLIJLNB data = new LGMEPLIJLNB();
					data.GOOIIPFHOIG = new MFDJIFIIPJD();
					data.GOOIIPFHOIG.KHEKNNFCAOI(reward.KIJAPOFAGPN_Item, reward.JDLJPNMLFID_Count);
					data.DNBFMLBNAEE_TotalPoint = step.JENFHJDFFAD_Pt[JJJNKGBCFMI_Step];
					data.OJELCGDDAOM_MissingPoint = data.DNBFMLBNAEE_TotalPoint - ABLHIAEDJAI_CurrentPoint;
					data.HMEOAKCLKJE_IsReceived = saveEpInfo.MCIHDIBHHBI_IsRewardReceived(JJJNKGBCFMI_Step);
					JBFLCHFEIGL = data;
				}
			}
			FMLIFJBPFNA_Step step2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step GHPLINIACBB) =>
			{
				//0x16D37F0
				return GHPLINIACBB.IOFHEGJPHKG_SId == epInfo.IOFHEGJPHKG_StepId;
			});
			DMHDNKILKGI_MaxPoint = step2.JENFHJDFFAD_Pt[epInfo.FGOGPCMHPIN_Count - 2];
			CCBKMCLDGAD_HasReward = true;
			for(int i = 0; i < FGOGPCMHPIN_Count - 1; i++)
			{
				if (!saveEpInfo.MCIHDIBHHBI_IsRewardReceived(i))
					CCBKMCLDGAD_HasReward = false;
			}
			if(KELFCMEOPPM_EpId > 0)
			{
				LEGAKDFPPHA_AvaiablePoint = GMDHJBGLBEI(KELFCMEOPPM_EpId);
			}
			JBCIDDKDJMM = FIBLGPNEKEM(KELFCMEOPPM_EpId);
		}
	}

	//// RVA: 0x16D11AC Offset: 0x16D11AC VA: 0x16D11AC
	public void AFGOBPPKFBF()
	{
		if (KELFCMEOPPM_EpId < 1)
			return;
		LEGAKDFPPHA_AvaiablePoint = GMDHJBGLBEI(KELFCMEOPPM_EpId);
	}

	//// RVA: 0x16D2190 Offset: 0x16D2190 VA: 0x16D2190
	public static List<PIGBBNDPPJC> FKDIMODKKJD_GetAvaiableEpisodes(bool DHFLBNAHGDF = false)
	{
		List<PIGBBNDPPJC> res = new List<PIGBBNDPPJC>(500);
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList.Count; i++)
		{
			HMGPODKEFBA_EpisodeInfo dbEp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[i];
			OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveEp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[i];
			if(dbEp.PPEGAKEIEGM == 2)
			{
				if(!DHFLBNAHGDF)
				{
					if (saveEp.BEBJKJKBOGH_Date == 0)
						continue;
				}
				PIGBBNDPPJC data = new PIGBBNDPPJC();
				data.KHEKNNFCAOI(i + 1);
				res.Add(data);
			}
		}
		CEAIGKOGLIN(res);
		return res;
	}

	//// RVA: 0x16D24CC Offset: 0x16D24CC VA: 0x16D24CC
	public static void CEAIGKOGLIN(List<PIGBBNDPPJC> NNDGIAEFMOG)
	{
		NNDGIAEFMOG.Sort((PIGBBNDPPJC HKICMNAACDA, PIGBBNDPPJC BNKHBCBJBKI) =>
		{
			//0x16D365C
			return HKICMNAACDA.FKMAEKNOLJB_EpisodeNo - BNKHBCBJBKI.FKMAEKNOLJB_EpisodeNo;
		});
	}

	//// RVA: 0x16D2620 Offset: 0x16D2620 VA: 0x16D2620
	public int HADPDBAGEIB(int BNGHLLCONJM, int HMFFHLPNMPH)
	{
		OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo info = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpId - 1];
		if(info.HPLMMKHBKIG_Id == KELFCMEOPPM_EpId)
		{
			KIICLPJJBNL_EpiItem.NKGPGMOHAFM info2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGGMILDEEF_EpiItem.CDENCMNHNGA[BNGHLLCONJM - 1];
			EGOLBAPFHHD_Common.AMCANGCIBEG info3 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GJODJNIHKKF_EpiItem[BNGHLLCONJM - 1];
			if(HMFFHLPNMPH != 0 && BNGHLLCONJM == info2.PPFNGGCBJKC_Id)
			{
				return HMFFHLPNMPH <= info3.BFINGCJHOHI_Cnt ? 1 : 0;
			}
		}
		return -1;
	}

	//// RVA: 0x16D2950 Offset: 0x16D2950 VA: 0x16D2950
	public int PFMLAOPEAMJ(int BNGHLLCONJM, int HMFFHLPNMPH, IMCBBOAFION BHFHGFKBOHH)
	{
		int res = HADPDBAGEIB(BNGHLLCONJM, HMFFHLPNMPH);
		if (res > 0)
		{
			FENCAJJBLBH f = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(true);
			if(f == null)
			{
				JDDGPJDKHNE.HHCJCDFCLOB.BGDOBGFECOB();
				OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo ep = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpId - 1];
				KIICLPJJBNL_EpiItem.NKGPGMOHAFM info2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGGMILDEEF_EpiItem.CDENCMNHNGA[BNGHLLCONJM - 1];
				EGOLBAPFHHD_Common.AMCANGCIBEG info3 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GJODJNIHKKF_EpiItem[BNGHLLCONJM - 1];
				info3.BFINGCJHOHI_Cnt -= HMFFHLPNMPH;
				if(info3.BFINGCJHOHI_Cnt < 0)
					info3.BFINGCJHOHI_Cnt = 0;
				int a = ep.OGDBKJKIGAJ_CurrentPoint;
				ep.MOACIBEKLEN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode, HMFFHLPNMPH * info2.JBGEEPFKIGG_Value, false);
				int a2 = ep.OGDBKJKIGAJ_CurrentPoint;
				ILCCJNDFFOB.HHCJCDFCLOB.BBDKHAMANCB(KELFCMEOPPM_EpId, a, a2, ep.EBIIIAELNAA_Step, JpStringLiterals.StringLiteral_13085, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem, BNGHLLCONJM), HMFFHLPNMPH);
			}
			MenuScene.SaveWithAchievement(2, () =>
			{
				//0x16D3874
				BHFHGFKBOHH();
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
			}, null);
			return 1;
		}
		return res;
	}

	//// RVA: 0x16D20E4 Offset: 0x16D20E4 VA: 0x16D20E4
	private int GMDHJBGLBEI(int KELFCMEOPPM)
	{
		return GMDHJBGLBEI(KELFCMEOPPM, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
	}

	//// RVA: 0x16D11D0 Offset: 0x16D11D0 VA: 0x16D11D0
	private bool FIBLGPNEKEM(int KELFCMEOPPM)
	{
		for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count; i++)
		{
			MMPBPOIFDAF_Scene.PMKOFEIONEG serverScene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[i];
			if (serverScene.IHIAFIHAAPO_Unlocked)
			{
				MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[serverScene.PPFNGGCBJKC_Id - 1];
				if (dbScene.KELFCMEOPPM_Ep == KELFCMEOPPM)
				{
					if(dbScene.MCCIFLKCNKO_Feed)
					{
						if(GCIJNCFDNON_SceneInfo.CGJCEHGFHMA(serverScene.PPFNGGCBJKC_Id) <
							GCIJNCFDNON_SceneInfo.JLNGOOGHCNA(serverScene.PPFNGGCBJKC_Id, dbScene.EKLIPGELKCL_Rarity, serverScene.JPIPENJGGDD_Mlt > 0, serverScene.JPIPENJGGDD_Mlt))
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	//// RVA: 0x16D2FD4 Offset: 0x16D2FD4 VA: 0x16D2FD4
	public static int GMDHJBGLBEI(int KELFCMEOPPM, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveEp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM - 1];
		MLIBEPGADJH_Scene sceneDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene;
		List<MMPBPOIFDAF_Scene.PMKOFEIONEG> sceneList = AHEFHIMGIBI.PNLOINMCCKH_Scene.OPIBAPEGCLA;
		int l30 = 0;
		int l2c = 0;
		for(int i = 0; i < sceneList.Count; i++)
		{
			MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = sceneList[i];
			if(saveScene.IHIAFIHAAPO_Unlocked)
			{
				if(sceneDb.CDENCMNHNGA_SceneList[saveScene.PPFNGGCBJKC_Id - 1].KELFCMEOPPM_Ep == KELFCMEOPPM)
				{
					int rar = sceneDb.CDENCMNHNGA_SceneList[saveScene.PPFNGGCBJKC_Id - 1].EKLIPGELKCL_Rarity;
					l30 += GCIJNCFDNON_SceneInfo.JLNGOOGHCNA(saveScene.PPFNGGCBJKC_Id, rar, saveScene.JPIPENJGGDD_Mlt > 0, saveScene.JPIPENJGGDD_Mlt);
					l2c += GCIJNCFDNON_SceneInfo.CGJCEHGFHMA(saveScene.PPFNGGCBJKC_Id);
				}
			}
		}
		return l30 - l2c + saveEp.OGDBKJKIGAJ_CurrentPoint;
	}

	//// RVA: 0x16D0FEC Offset: 0x16D0FEC VA: 0x16D0FEC
	public static string EJOJNFDHDHN_GetEpName(int KELFCMEOPPM)
	{
		return MessageManager.Instance.GetMessage("master", "ep_nm_" + KELFCMEOPPM.ToString("D4"));
	}

	//// RVA: 0x16D10C4 Offset: 0x16D10C4 VA: 0x16D10C4
	public static string FKKHNDDGKJB_GetEpDesc(int KELFCMEOPPM)
	{
		return MessageManager.Instance.GetMessage("master", "ep_dsc_" + KELFCMEOPPM.ToString("D4"));
	}
}
