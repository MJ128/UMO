
using System.Collections;
using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Menu;

public class AODFBGCCBPE
{
	public enum NJMPLEENNPO
	{
		HJNNKCMLGFL_0 = 0,
		AOMIBCNBBOD_1_Vc = 1,
		BDMFENCIPEB_2_Medal = 2,
		FNLODOLMLML_3 = 3,
		NCFFHDNEEIF_4_Uc = 4,
		BJNAMAANNMB_5 = 5,
		FNJAOJBICJD_6_SuperGalaxyMedal = 6,
		MGEGNNJLJII_7_EpisodePlate1_4 = 7,
		ACFEDNPIJKM_8_EpisodePlate5_6 = 8,
	}

	public long GJFPFFBAKGK; // 0x8
	public long GIOIPNIMAIG; // 0x10
	public string NEMKDKDIIDK_ShopName; // 0x18
	public int OPKDAIMPJBH; // 0x1C
	public int IBAKPKKEDJM; // 0x20
	public int JPGALGPNJAI_VcId; // 0x24
	public int EAHPLCJMPHD_PayItemId; // 0x28
	public NJMPLEENNPO INDDJNMPONH_Type; // 0x2C
	public bool FPJBMCDMAMO; // 0x30
	public bool HKKPNKOIOKL; // 0x31
	public int EILKGEADKGH; // 0x34
	public int OCGCPJHDJEN; // 0x38
	public bool CADENLBDAEB; // 0x3C
	public List<FJGOKILCBJA> MHKCPJDNJKI; // 0x40
	public IGCPCHNCJCF GLHFDCKOJDN; // 0x44

	//// RVA: 0xD57ACC Offset: 0xD57ACC VA: 0xD57ACC
	public int JJPAFPIOBCK_GetCount()
	{
		if(OCGCPJHDJEN == 0)
			return 0;
        List<EGOLBAPFHHD_Common.GLBBNDKGEOC> saveMedal = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal;
        switch (INDDJNMPONH_Type)
		{
			case NJMPLEENNPO.AOMIBCNBBOD_1_Vc:
				return CIOECGOMILE.HHCJCDFCLOB.NOJDLFKKMDD_GetCurrencyTotal(JPGALGPNJAI_VcId);
			case NJMPLEENNPO.BDMFENCIPEB_2_Medal:
			{
				int index = IBAKPKKEDJM - 1;
				if(index < saveMedal.Count)
				{
					int fullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, saveMedal[index].PPFNGGCBJKC_Id);
					if(fullId == OCGCPJHDJEN)
					{
						return saveMedal[index].BFINGCJHOHI_Cnt;
					}
				}
				return 0;
			}
			default:
				return 0;
			case NJMPLEENNPO.NCFFHDNEEIF_4_Uc:
				return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NFHLDFJIBKI_HaveUc;
			case NJMPLEENNPO.BJNAMAANNMB_5:
				return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(null, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 8, null);
			case NJMPLEENNPO.FNJAOJBICJD_6_SuperGalaxyMedal:
				return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(null, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 7, null);
			case NJMPLEENNPO.MGEGNNJLJII_7_EpisodePlate1_4:
			case NJMPLEENNPO.ACFEDNPIJKM_8_EpisodePlate5_6:
				return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(null, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 15, null);
		}
	}

	//// RVA: 0xD57EC0 Offset: 0xD57EC0 VA: 0xD57EC0
	public void NBJNKFPEFGC()
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().PFOMECFACLL_Shop.POAFHAHACEL(OPKDAIMPJBH, BGDCMGOPCGE());
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	//// RVA: 0xD58134 Offset: 0xD58134 VA: 0xD58134
	public void KHEKNNFCAOI(int OPKDAIMPJBH, long JHNMKKNEENE)
	{
		BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA[OPKDAIMPJBH - 1];
		GJFPFFBAKGK = dbShop.GJFPFFBAKGK;
		GIOIPNIMAIG = dbShop.GJFPFFBAKGK;
		NEMKDKDIIDK_ShopName = dbShop.NEMKDKDIIDK_ShopName;
		this.OPKDAIMPJBH = dbShop.OPKDAIMPJBH_ShopId;
		IBAKPKKEDJM = dbShop.IBAKPKKEDJM_Month;
		EAHPLCJMPHD_PayItemId = dbShop.EAHPLCJMPHD_PayItemId;
		INDDJNMPONH_Type = (NJMPLEENNPO)dbShop.HCCEFDMGPEA;
		FPJBMCDMAMO = dbShop.FPJBMCDMAMO != 0;
		HKKPNKOIOKL = dbShop.FPJBMCDMAMO != 0;
		EILKGEADKGH = dbShop.EILKGEADKGH;
		JPGALGPNJAI_VcId = dbShop.JPGALGPNJAI_VcId;
		switch(INDDJNMPONH_Type)
		{
			case NJMPLEENNPO.AOMIBCNBBOD_1_Vc/*1*/:
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH h = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.NPOALOFHFPN(JPGALGPNJAI_VcId);
				if (h == null)
					break;
				GIOIPNIMAIG = h.JDANEOJCLBB;
				HKKPNKOIOKL = true;
				OCGCPJHDJEN = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, h.PPFNGGCBJKC_Id);
				break;
			case NJMPLEENNPO.BDMFENCIPEB_2_Medal/*2*/:
				GIOIPNIMAIG = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.OEMKKJBNIFA(IBAKPKKEDJM);
				HKKPNKOIOKL = true;
				OCGCPJHDJEN = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, IBAKPKKEDJM);
				break;
			default:
				break;
			case NJMPLEENNPO.NCFFHDNEEIF_4_Uc/*4*/:
				OCGCPJHDJEN = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit, 1);
				break;
			case NJMPLEENNPO.BJNAMAANNMB_5/*5*/:
				OCGCPJHDJEN = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 8);
				break;
			case NJMPLEENNPO.FNJAOJBICJD_6_SuperGalaxyMedal/*6*/:
				OCGCPJHDJEN = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 7);
				break;
			case NJMPLEENNPO.MGEGNNJLJII_7_EpisodePlate1_4/*7*/:
			case NJMPLEENNPO.ACFEDNPIJKM_8_EpisodePlate5_6/*8*/:
				OCGCPJHDJEN = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, IBAKPKKEDJM);
				break;
		}
		MHKCPJDNJKI = FJGOKILCBJA.FKDIMODKKJD(dbShop.OPKDAIMPJBH_ShopId, dbShop.EFNMDPKEJIM_LineupId, JHNMKKNEENE);
		CADENLBDAEB = false;
		if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().PFOMECFACLL_Shop.BGDCMGOPCGE(OPKDAIMPJBH) != BGDCMGOPCGE())
		{
			CADENLBDAEB = !QuestUtility.IsBeginnerQuest();
		}
	}

	//// RVA: 0xD58868 Offset: 0xD58868 VA: 0xD58868
	public static List<AODFBGCCBPE> FKDIMODKKJD(bool DKLOGCOPPKJ)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		List<AODFBGCCBPE> res = new List<AODFBGCCBPE>();
		List<BKPAPCMJKHE_Shop.DNOENEKHGMI> dbShopList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA;
		for(int i = 0; i < dbShopList.Count; i++)
		{
			if(dbShopList[i].PPEGAKEIEGM_Enabled == 2)
			{
				if (!DKLOGCOPPKJ)
				{
					if (time >= dbShopList[i].KJBGCLPMLCG && dbShopList[i].GJFPFFBAKGK >= time && dbShopList[i].HCCEFDMGPEA == 1)
					{
						HHJHIFJIKAC_BonusVc.MNGJPJBCMBH bonus = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.NPOALOFHFPN(EKLNMHFCAOI.DEACAHNLMNI_getItemId(dbShopList[i].EAHPLCJMPHD_PayItemId));
						if (bonus == null || time < bonus.PDBPFJJCADD_OpenAt || bonus.EGBOHDFBAPB_ClosedAt < time)
							continue;
					}
				}
				//LAB_00d58ae8
				AODFBGCCBPE data = new AODFBGCCBPE();
				data.KHEKNNFCAOI(dbShopList[i].OPKDAIMPJBH_ShopId, time);
				res.Add(data);
			}
		}
		res.Sort((AODFBGCCBPE HKICMNAACDA, AODFBGCCBPE BNKHBCBJBKI) => {
			//0xD5937C
			return HKICMNAACDA.EILKGEADKGH.CompareTo(BNKHBCBJBKI.EILKGEADKGH);
		});
		return res;
	}

	//// RVA: 0xD58E54 Offset: 0xD58E54 VA: 0xD58E54
	public static bool PLKKMHBFDCJ()
	{
		bool res = false;
		if(!QuestUtility.IsBeginnerQuest())
		{
			List<AODFBGCCBPE> l = FKDIMODKKJD(false);
			for(int i = 0; i < l.Count; i++)
			{
				res |= l[i].CADENLBDAEB;
			}
		}
		return res;
	}

	//// RVA: 0xD58028 Offset: 0xD58028 VA: 0xD58028
	private long BGDCMGOPCGE()
	{
		if (MHKCPJDNJKI.Count < 1)
			return 0;
		long res = 0;
		for(int i = 0; i < MHKCPJDNJKI.Count; i++)
		{
			res += MHKCPJDNJKI[i].EAPILIMHDNP_BuyLimitDate ^ MHKCPJDNJKI.Count;
		}
		return res;
	}

	//// RVA: 0xD58F80 Offset: 0xD58F80 VA: 0xD58F80
	public void GKHAMEAMKCN(IMCBBOAFION CFHALLLJAOP, DJBHIFLHJLK AOCANKOMKFG)
	{
		if(INDDJNMPONH_Type != NJMPLEENNPO.AOMIBCNBBOD_1_Vc)
		{
			CFHALLLJAOP();
			return;
		}
		if (GLHFDCKOJDN == null)
			GLHFDCKOJDN = new IGCPCHNCJCF();
		HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[JPGALGPNJAI_VcId - 1];
		GLHFDCKOJDN.COAIAEOOELG(dbVc.CPGFOBNKKBF_CurrencyId, () =>
		{
			//0xD593C4
			for(int i = 0; i < MHKCPJDNJKI.Count; i++)
			{
				MHKCPJDNJKI[i].EOJNOOHFOKA(GLHFDCKOJDN);
			}
			CFHALLLJAOP();
		}, () =>
		{
			//0xD59504
			AOCANKOMKFG();
		});
	}

	//[IteratorStateMachineAttribute] // RVA: 0x7414BC Offset: 0x7414BC VA: 0x7414BC
	//// RVA: 0xD59220 Offset: 0xD59220 VA: 0xD59220
	public static IEnumerator OMBGMOFMCLD_Coroutine_UpdateViewShopList(List<AODFBGCCBPE> NNDGIAEFMOG, DJBHIFLHJLK BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		//0xD59554
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].INDDJNMPONH_Type == NJMPLEENNPO.AOMIBCNBBOD_1_Vc)
			{
				bool BEKAMBBOLBO = false;
				bool CNAIDEAFAAM = false;
				NNDGIAEFMOG[i].GKHAMEAMKCN(() =>
				{
					//0xD59538
					BEKAMBBOLBO = true;
				}, () =>
				{
					//0xD59544
					BEKAMBBOLBO = true;
					CNAIDEAFAAM = true;
				});
				while (!BEKAMBBOLBO)
					yield return null;
				if(CNAIDEAFAAM)
				{
					AOCANKOMKFG();
					yield break;
				}
			}
		}
		BHFHGFKBOHH();
	}
}
