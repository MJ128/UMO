
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use FNCFHIEELGO_DecoVisit", true)]
public class FNCFHIEELGO { }
public class FNCFHIEELGO_DecoVisit : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 1;
	public List<NDBFKHKMMCE_DecoItem.FKIMJLOFONM> MPPKMEIEGFE_VisitList; // 0x24
	public List<NDBFKHKMMCE_DecoItem.FKIMJLOFONM> MHPDCGNOBHH_PresentSentList; // 0x28
	private long ENOBDCFHELD; // 0x30
	private long FCEJCHGLFGN; // 0x38
	private long CGMLKDKILPG; // 0x40
	private long DBDOIAONKMK; // 0x48
	private long EKFOHMMFPBI; // 0x50
	private long IBPGECMMELK; // 0x58
	private int HPNAEFLIFGD; // 0x60
	private int POEDGHHLBCC; // 0x64
	private int FNNIPOFDCFB; // 0x68
	private int AGJAFDKABFI; // 0x6C
	private int IDFIKBHHLNN; // 0x70
	private int KCAJLAACCKN; // 0x74
	private long OHCKMGGLMPB; // 0x78
	private long MCCBJMKHPCP; // 0x80
	private int IIKOHDBHLPI; // 0x88
	private int CMPBMCDNBLN; // 0x8C

	public long LIDCDBKAAFL_VisitAcquiredAt { get { return CGMLKDKILPG ^ ENOBDCFHELD; } set { CGMLKDKILPG = value ^ ENOBDCFHELD; DBDOIAONKMK = value ^ FCEJCHGLFGN; } } //CGCJBJJKIEL 0x13E4760 HDLMMMEKNMC 0x13E4774
	public long KAIOEKJJAKH_VisitedAt { get { return EKFOHMMFPBI ^ ENOBDCFHELD; } set { EKFOHMMFPBI = value ^ ENOBDCFHELD; IBPGECMMELK = value ^ FCEJCHGLFGN; } } //LGENFPJEOEN 0x13E4798 KBDKDFAMOMC 0x13E47AC
	public int HFJADCMLFAN_VisitPrevCntFriend { get { return HPNAEFLIFGD ^ (int)ENOBDCFHELD; } set { HPNAEFLIFGD = value ^ (int)ENOBDCFHELD; POEDGHHLBCC = value ^ (int)FCEJCHGLFGN; } } //OLMDECNACBA 0x13E47D0 BDFGHCBOBFM 0x13E47E0
	public int FBINJFGCIOI_VisitPrevCntFan { get { return FNNIPOFDCFB ^ (int)ENOBDCFHELD; } set { FNNIPOFDCFB = value ^ (int)ENOBDCFHELD; AGJAFDKABFI = value ^ (int)FCEJCHGLFGN; } } //JMAKOIDGMCM 0x13E47F8 BNMCNDEFHFG 0x13E4808
	public int IAOOCOKEECB_VisitPrevCntOther { get { return IDFIKBHHLNN ^ (int)ENOBDCFHELD; } set { IDFIKBHHLNN = value ^ (int)ENOBDCFHELD; KCAJLAACCKN = value ^ (int)FCEJCHGLFGN; } } //HKCHBKHDOLK 0x13E4820 OKPAIAMOBHI 0x13E4830
	public long EILGNIEGDOI_PresentAcquiredAt { get { return OHCKMGGLMPB ^ ENOBDCFHELD; } set { OHCKMGGLMPB = value ^ ENOBDCFHELD; MCCBJMKHPCP = value ^ FCEJCHGLFGN; } } //FHPOOMLLOCL 0x13E4848 MOFBHEJEGPK 0x13E485C
	public int GHEBKKHAAPM_PresentPrevCnt { get { return IIKOHDBHLPI ^ (int)ENOBDCFHELD; } set { IIKOHDBHLPI = value ^ (int)ENOBDCFHELD; CMPBMCDNBLN = value ^ (int)FCEJCHGLFGN; } } //KODNPBIFNBI 0x13E4880 BCLOKNHJDNJ 0x13E4890
	public override bool DMICHEJIAJL { get { return true; } } // 0x13E5E3C NFKFOODCJJB

	// // RVA: 0x13E48A8 Offset: 0x13E48A8 VA: 0x13E48A8
	public FNCFHIEELGO_DecoVisit()
	{
		MPPKMEIEGFE_VisitList = new List<NDBFKHKMMCE_DecoItem.FKIMJLOFONM>(16);
		MHPDCGNOBHH_PresentSentList = new List<NDBFKHKMMCE_DecoItem.FKIMJLOFONM>();
		KMBPACJNEOF();
	}

	// // RVA: 0x13E4974 Offset: 0x13E4974 VA: 0x13E4974 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}

	// // RVA: 0x13E4BC0 Offset: 0x13E4BC0 VA: 0x13E4BC0
	// private FENCAJJBLBH JJPAJEBBFOB(string OPFGFINHFCE) { }

	// // RVA: 0x13E4C6C Offset: 0x13E4C6C VA: 0x13E4C6C Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data["visit_acquired_at"] = LIDCDBKAAFL_VisitAcquiredAt;
		data["visited_at"] = KAIOEKJJAKH_VisitedAt;
		data["visit_prev_cnt_friend"] = HFJADCMLFAN_VisitPrevCntFriend;
		data["visit_prev_cnt_fan"] = FBINJFGCIOI_VisitPrevCntFan;
		data["visit_prev_cnt_other"] = IAOOCOKEECB_VisitPrevCntOther;
		data["present_acquired_at"] = EILGNIEGDOI_PresentAcquiredAt;
		data["present_prev_cnt"] = GHEBKKHAAPM_PresentPrevCnt;
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < MPPKMEIEGFE_VisitList.Count; i++)
			{
				data2.Add(MPPKMEIEGFE_VisitList[i].NANNGLGOFKH);
			}
			data["visit_list"] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < MHPDCGNOBHH_PresentSentList.Count; i++)
			{
				data2.Add(MHPDCGNOBHH_PresentSentList[i].NANNGLGOFKH);
			}
			data["present_sent_list"] = data2;
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 1;
			data2[JIKKNHIAEKG_BlockName] = data;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x13E53F4 Offset: 0x13E53F4 VA: 0x13E53F4 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 1);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				LIDCDBKAAFL_VisitAcquiredAt = DKMPHAPBDLH_ReadLong(block, "visit_acquired_at", 0, ref isInvalid);
				KAIOEKJJAKH_VisitedAt = DKMPHAPBDLH_ReadLong(block, "visited_at", 0, ref isInvalid);
				HFJADCMLFAN_VisitPrevCntFriend = CJAENOMGPDA_ReadInt(block, "visit_prev_cnt_friend", 0, ref isInvalid);
				FBINJFGCIOI_VisitPrevCntFan = CJAENOMGPDA_ReadInt(block, "visit_prev_cnt_fan", 0, ref isInvalid);
				IAOOCOKEECB_VisitPrevCntOther = CJAENOMGPDA_ReadInt(block, "visit_prev_cnt_other", 0, ref isInvalid);
				EILGNIEGDOI_PresentAcquiredAt = DKMPHAPBDLH_ReadLong(block, "present_acquired_at", 0, ref isInvalid);
				GHEBKKHAAPM_PresentPrevCnt = CJAENOMGPDA_ReadInt(block, "present_prev_cnt", 0, ref isInvalid);
				int k = (int)Utility.GetCurrentUnixTime();
				EDOHBJAPLPF_JsonData b = block["visit_list"];
				for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
				{
					MPPKMEIEGFE_VisitList.Add(new NDBFKHKMMCE_DecoItem.FKIMJLOFONM((int)b[i], k ^ 0xf2b));
				}
				b = block["present_sent_list"];
				for (int i = 0; i < b.HNBFOAJIIAL_Count; i++)
				{
					MHPDCGNOBHH_PresentSentList.Add(new NDBFKHKMMCE_DecoItem.FKIMJLOFONM((int)b[i], k ^ 0xc64));
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x13E5900 Offset: 0x13E5900 VA: 0x13E5900 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FNCFHIEELGO_DecoVisit d = GPBJHKLFCEP as FNCFHIEELGO_DecoVisit;
		LIDCDBKAAFL_VisitAcquiredAt = d.LIDCDBKAAFL_VisitAcquiredAt;
		KAIOEKJJAKH_VisitedAt = d.KAIOEKJJAKH_VisitedAt;
		HFJADCMLFAN_VisitPrevCntFriend = d.HFJADCMLFAN_VisitPrevCntFriend;
		FBINJFGCIOI_VisitPrevCntFan = d.FBINJFGCIOI_VisitPrevCntFan;
		IAOOCOKEECB_VisitPrevCntOther = d.IAOOCOKEECB_VisitPrevCntOther;
		EILGNIEGDOI_PresentAcquiredAt = d.EILGNIEGDOI_PresentAcquiredAt;
		GHEBKKHAAPM_PresentPrevCnt = d.GHEBKKHAAPM_PresentPrevCnt;
		MPPKMEIEGFE_VisitList.Clear();
		MPPKMEIEGFE_VisitList.Capacity = d.MPPKMEIEGFE_VisitList.Count;
		for(int i = 0; i < d.MPPKMEIEGFE_VisitList.Count; i++)
		{
			MPPKMEIEGFE_VisitList.Add(d.MPPKMEIEGFE_VisitList[i]);
		}
		MHPDCGNOBHH_PresentSentList.Clear();
		MHPDCGNOBHH_PresentSentList.Capacity = d.MHPDCGNOBHH_PresentSentList.Count;
		for(int i = 0; i < d.MHPDCGNOBHH_PresentSentList.Count; i++)
		{
			MHPDCGNOBHH_PresentSentList.Add(d.MHPDCGNOBHH_PresentSentList[i]);
		}
	}

	// // RVA: 0x13E5E44 Offset: 0x13E5E44 VA: 0x13E5E44 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0x13E6738 Offset: 0x13E6738 VA: 0x13E6738
	// private void EANKOKOGMMI(BHBONAHFKHD JBBHNIACMFJ, string HDBEJBBPPBK, string PKLPKMLGFGK, List<NDBFKHKMMCE.FKIMJLOFONM> LKCCMBEOLLA, List<NDBFKHKMMCE.FKIMJLOFONM> GJLFANGDGCL) { }

	// // RVA: 0x13E6B7C Offset: 0x13E6B7C VA: 0x13E6B7C Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FNCFHIEELGO_DecoVisit other = GPBJHKLFCEP as FNCFHIEELGO_DecoVisit;
		if(LIDCDBKAAFL_VisitAcquiredAt != other.LIDCDBKAAFL_VisitAcquiredAt ||
			KAIOEKJJAKH_VisitedAt != other.KAIOEKJJAKH_VisitedAt ||
			HFJADCMLFAN_VisitPrevCntFriend != other.HFJADCMLFAN_VisitPrevCntFriend ||
			FBINJFGCIOI_VisitPrevCntFan != other.FBINJFGCIOI_VisitPrevCntFan ||
			IAOOCOKEECB_VisitPrevCntOther != other.IAOOCOKEECB_VisitPrevCntOther ||
			EILGNIEGDOI_PresentAcquiredAt != other.EILGNIEGDOI_PresentAcquiredAt ||
			GHEBKKHAAPM_PresentPrevCnt != other.GHEBKKHAAPM_PresentPrevCnt ||
			MPPKMEIEGFE_VisitList.Count != other.MPPKMEIEGFE_VisitList.Count)
			return false;
		for(int i = 0; i < MPPKMEIEGFE_VisitList.Count; i++)
		{
			if(MPPKMEIEGFE_VisitList[i].NANNGLGOFKH != other.MPPKMEIEGFE_VisitList[i].NANNGLGOFKH)
				return false;
		}
		if(MHPDCGNOBHH_PresentSentList.Count != other.MHPDCGNOBHH_PresentSentList.Count)
			return false;
		for(int i = 0; i < MHPDCGNOBHH_PresentSentList.Count; i++)
		{
			if(MHPDCGNOBHH_PresentSentList[i].NANNGLGOFKH != other.MHPDCGNOBHH_PresentSentList[i].NANNGLGOFKH)
				return false;
		}
		return true;
	}

	// // RVA: 0x13E707C Offset: 0x13E707C VA: 0x13E707C Slot: 4
	public override void KMBPACJNEOF()
	{
		long k = Utility.GetCurrentUnixTime();
		ENOBDCFHELD = k ^ 0x4892f2b;
		FCEJCHGLFGN = k ^ 0xc0ff758a;
		LIDCDBKAAFL_VisitAcquiredAt = 0;
		KAIOEKJJAKH_VisitedAt = 0;
		HFJADCMLFAN_VisitPrevCntFriend = 0;
		FBINJFGCIOI_VisitPrevCntFan = 0;
		IAOOCOKEECB_VisitPrevCntOther = 0;
		EILGNIEGDOI_PresentAcquiredAt = 0;
		GHEBKKHAAPM_PresentPrevCnt = 0;
		MPPKMEIEGFE_VisitList.Clear();
		MHPDCGNOBHH_PresentSentList.Clear();
	}
}
