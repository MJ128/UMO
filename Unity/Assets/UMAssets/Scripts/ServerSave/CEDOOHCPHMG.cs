
using System.Collections.Generic;

[System.Obsolete("Use CEDOOHCPHMG_UnitGoDiva", true)]
public class CEDOOHCPHMG { }
public class CEDOOHCPHMG_UnitGoDiva : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	private List<MPBEHHIAGOI> GFPFBJDPHLJ; // 0x24
	public List<CIFHILOJJFC> PKMMBKHODDM_Saved = new List<CIFHILOJJFC>(); // 0x28

	public override bool DMICHEJIAJL { get { return true; } } // 0x12B4DD8 NFKFOODCJJB

	// // RVA: 0x12B2A3C Offset: 0x12B2A3C VA: 0x12B2A3C
	public CIFHILOJJFC ALDOJAEAMCJ(int AHHJLDLAPAN, int PPFNGGCBJKC_Id)
	{
		for(int i = 0; i < GFPFBJDPHLJ.Count; i++)
		{
			if(GFPFBJDPHLJ[i].AHHJLDLAPAN_divaId == AHHJLDLAPAN)
			{
				return GFPFBJDPHLJ[i].GCINIJEMHFK(PPFNGGCBJKC_Id);
			}
		}
		return null;
	}

	// // RVA: 0x12B2B88 Offset: 0x12B2B88 VA: 0x12B2B88
	public CIFHILOJJFC IGKLKPIEEEH(int AHHJLDLAPAN)
	{
		return ALDOJAEAMCJ(AHHJLDLAPAN, 0);
	}

	// // RVA: 0x12B2B90 Offset: 0x12B2B90 VA: 0x12B2B90
	public CEDOOHCPHMG_UnitGoDiva()
	{
		GFPFBJDPHLJ = new List<MPBEHHIAGOI>(1);
		KMBPACJNEOF();
	}

	// // RVA: 0x12B2C68 Offset: 0x12B2C68 VA: 0x12B2C68 Slot: 4
	public override void KMBPACJNEOF()
	{
		GFPFBJDPHLJ.Clear();
		PKMMBKHODDM_Saved.Clear();
		for(int i = 0; i < 10; i++)
		{
			MPBEHHIAGOI data = new MPBEHHIAGOI(i + 1);
			GFPFBJDPHLJ.Add(data);
			CIFHILOJJFC data2 = new CIFHILOJJFC();
			CIFHILOJJFC c = ALDOJAEAMCJ(i + 1, 0);
			data2.ODDIHGPONFL_Copy(c, false);
			PKMMBKHODDM_Saved.Add(data2);
		}
	}

	// // RVA: 0x12B2E08 Offset: 0x12B2E08 VA: 0x12B2E08 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < GFPFBJDPHLJ.Count; i++)
		{
			data.Add(GFPFBJDPHLJ[i].NOJCMGAFAAC());
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x12B3180 Offset: 0x12B3180 VA: 0x12B3180 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool notValid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref notValid, 2);
		if(!blockMissing)
		{
			if(block == null || !block.EPNGJLOKGIF_IsArray)
			{
				notValid = true;
			}
			else
			{
				if (block.HNBFOAJIIAL_Count != 6)
					notValid = true;
				OKGLGHCBCJP_Database db = null;
				if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
				{
					db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
				}
				PKMMBKHODDM_Saved.Clear();
				for(int i = 0; i < block.HNBFOAJIIAL_Count; i++)
				{
					MPBEHHIAGOI data = GFPFBJDPHLJ[i];
					data.AHHJLDLAPAN_divaId = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.DIPKCALNIII_diva_id, 1, ref notValid);
					EDOHBJAPLPF_JsonData array = block[i][AFEHLCGHAEE_Strings.MEFHDDNABLM_unit];
					for (int j = 0; j < array.HNBFOAJIIAL_Count; j++)
					{
						CIFHILOJJFC MEFHDDNABLM = ALDOJAEAMCJ(i + 1, j);
						if(MEFHDDNABLM != null)
						{
							MEFHDDNABLM.FODKKJIDDKN_VfId = CJAENOMGPDA_ReadInt(array[j], AFEHLCGHAEE_Strings.FODKKJIDDKN_vf_id, 1, ref notValid);
							if(db != null)
							{
								if(!db.PEOALFEGNDH_Valkyrie.PILGJJCABME_IsValkyrieAvaiable(MEFHDDNABLM.FODKKJIDDKN_VfId))
								{
									MEFHDDNABLM.FODKKJIDDKN_VfId = 1;
								}
							}
							MEFHDDNABLM.OPFGFINHFCE_Name = CEDHHAGBIBA.KJFAGPBALNO(FGCNMLBACGO_ReadString(array[j], AFEHLCGHAEE_Strings.OPFGFINHFCE_name, CIFHILOJJFC.CBELJGBFLGA, ref notValid));
							if(array[j].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FDBOPFEOENF_diva))
							{
								EDOHBJAPLPF_JsonData array2 = array[j][AFEHLCGHAEE_Strings.FDBOPFEOENF_diva];
								for(int k = 0; k < array2.HNBFOAJIIAL_Count; k++)
								{
									AMCGONHBGGF a = MEFHDDNABLM.FDBOPFEOENF_MainDivas[k];
									a.DIPKCALNIII_Id = CJAENOMGPDA_ReadInt(array2[k], AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, 0, ref notValid);
									a.BEEAIAAJOHD_CId = CJAENOMGPDA_ReadInt(array2[k], AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id, 0, ref notValid);
									a.AFNIOJHODAG_ColId = CJAENOMGPDA_ReadInt(array2[k], "c_col", 0, ref notValid);
									IBCGPBOGOGP_ReadIntArray(array2[k], AFEHLCGHAEE_Strings.EBDNICPAFLB_s_slot, 0, 3, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
									{
										//0x12B4DE0
										a.EBDNICPAFLB_SSlot[OIPCCBHIKIA] = JBGEEPFKIGG;
									}, ref notValid);
									if(db != null)
									{
										for(int l = 0; l < 3; l++)
										{
											if(!db.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(a.EBDNICPAFLB_SSlot[l]))
											{
												a.EBDNICPAFLB_SSlot[l] = 0;
											}
										}
										if(a.DIPKCALNIII_Id == 0)
										{
											a.BEEAIAAJOHD_CId = 0;
											a.AFNIOJHODAG_ColId = 0;
										}
										else
										{
											if(!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(a.BEEAIAAJOHD_CId, a.DIPKCALNIII_Id))
											{
												a.BEEAIAAJOHD_CId = 0;
												a.AFNIOJHODAG_ColId = 0;
											}
											if(!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(a.BEEAIAAJOHD_CId, a.DIPKCALNIII_Id))
											{
												a.BEEAIAAJOHD_CId = 0;
												a.AFNIOJHODAG_ColId = 0;
											}
										}
									}
								}
							}
						}
					}
					CIFHILOJJFC c = new CIFHILOJJFC();
					c.ODDIHGPONFL_Copy(ALDOJAEAMCJ(i + 1, 0));
					PKMMBKHODDM_Saved.Add(c);
				}
			}
			KFKDMBPNLJK_BlockInvalid = notValid;
			return true;
		}
		return false;
	}

	// // RVA: 0x12B4594 Offset: 0x12B4594 VA: 0x12B4594 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		CEDOOHCPHMG_UnitGoDiva u = GPBJHKLFCEP as CEDOOHCPHMG_UnitGoDiva;
		for(int i = 0; i < GFPFBJDPHLJ.Count; i++)
		{
			GFPFBJDPHLJ[i].ODDIHGPONFL(u.GFPFBJDPHLJ[i]);
		}
	}

	// // RVA: 0x12B4768 Offset: 0x12B4768 VA: 0x12B4768 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		CEDOOHCPHMG_UnitGoDiva other = GPBJHKLFCEP as CEDOOHCPHMG_UnitGoDiva;
		if (GFPFBJDPHLJ.Count != other.GFPFBJDPHLJ.Count)
			return false;
		for(int i = 0; i < GFPFBJDPHLJ.Count; i++)
		{
			if (!GFPFBJDPHLJ[i].AGBOGBEOFME(other.GFPFBJDPHLJ[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x12B49C4 Offset: 0x12B49C4 VA: 0x12B49C4 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);
}

public class MPBEHHIAGOI
{
	public int AHHJLDLAPAN_divaId; // 0x8
	private List<CIFHILOJJFC> AHBBMJANGHE = new List<CIFHILOJJFC>(6); // 0xC

	public CIFHILOJJFC JKNGLJNEEPO { get { return AHBBMJANGHE[0]; } } //0x17BB12C FJDDNKGHPHN

	//// RVA: 0x17BB0AC Offset: 0x17BB0AC VA: 0x17BB0AC
	public CIFHILOJJFC GCINIJEMHFK(int PPFNGGCBJKC)
	{
		return AHBBMJANGHE[PPFNGGCBJKC];
	}

	//// RVA: 0x17BB1A8 Offset: 0x17BB1A8 VA: 0x17BB1A8
	public MPBEHHIAGOI(int AHHJLDLAPAN)
	{
		KMBPACJNEOF(AHHJLDLAPAN);
	}

	//// RVA: 0x17BB248 Offset: 0x17BB248 VA: 0x17BB248
	public void KMBPACJNEOF(int AHHJLDLAPAN)
	{
		this.AHHJLDLAPAN_divaId = AHHJLDLAPAN;
		AHBBMJANGHE.Clear();
		for(int i = 0; i < 6; i++)
		{
			CIFHILOJJFC data = new CIFHILOJJFC();
			data.GIDKKHFHALL = i;
			data.OPFGFINHFCE_Name = CIFHILOJJFC.CBELJGBFLGA;
			AHBBMJANGHE.Add(data);
		}
		FBFHJCNNPAK(AHHJLDLAPAN);
	}

	//// RVA: 0x17BB3A4 Offset: 0x17BB3A4 VA: 0x17BB3A4
	public void FBFHJCNNPAK(int AHHJLDLAPAN)
	{
		CIFHILOJJFC data = JKNGLJNEEPO;
		data.FODKKJIDDKN_VfId = 1;
		data.OPFGFINHFCE_Name = CIFHILOJJFC.CBELJGBFLGA;
		data.GCCNMFHELCB_Form = 0;
		for(int i = 0; i < data.FDBOPFEOENF_MainDivas.Count; i++)
		{
			data.FDBOPFEOENF_MainDivas[i].DIPKCALNIII_Id = AHHJLDLAPAN;
			data.FDBOPFEOENF_MainDivas[i].BEEAIAAJOHD_CId = 0;
			data.FDBOPFEOENF_MainDivas[i].AFNIOJHODAG_ColId = 0;
			for(int j = 0; j < data.FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot.Length; j++)
			{
				data.FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot[j] = 0;
			}
		}
	}

	//// RVA: 0x17BB6C0 Offset: 0x17BB6C0 VA: 0x17BB6C0
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < AHBBMJANGHE.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.GIDKKHFHALL_unit_id] = AHBBMJANGHE[i].GIDKKHFHALL;
				data3[AFEHLCGHAEE_Strings.FODKKJIDDKN_vf_id] = AHBBMJANGHE[i].FODKKJIDDKN_VfId;
				data3[AFEHLCGHAEE_Strings.OPFGFINHFCE_name] = AHBBMJANGHE[i].OPFGFINHFCE_Name;
				EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
				data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for(int j = 0; j < AHBBMJANGHE[i].FDBOPFEOENF_MainDivas.Count; j++)
				{
					data4.Add(AHBBMJANGHE[i].FDBOPFEOENF_MainDivas[j].NOJCMGAFAAC());
				}
				data3[AFEHLCGHAEE_Strings.FDBOPFEOENF_diva] = data4;
				data2.Add(data3);
			}
			data[AFEHLCGHAEE_Strings.MEFHDDNABLM_unit] = data2;
		}
		data[AFEHLCGHAEE_Strings.DIPKCALNIII_diva_id] = AHHJLDLAPAN_divaId;
		return data;
	}

	//// RVA: 0x17BBC34 Offset: 0x17BBC34 VA: 0x17BBC34
	public bool AGBOGBEOFME(MPBEHHIAGOI GPBJHKLFCEP)
	{
		if (AHBBMJANGHE.Count != GPBJHKLFCEP.AHBBMJANGHE.Count)
			return false;
		for(int i = 0; i < AHBBMJANGHE.Count; i++)
		{
			if (!AHBBMJANGHE[i].AGBOGBEOFME(GPBJHKLFCEP.AHBBMJANGHE[i]))
				return false;
		}
		return true;
	}

	//// RVA: 0x17BBDF8 Offset: 0x17BBDF8 VA: 0x17BBDF8
	public void ODDIHGPONFL(MPBEHHIAGOI GPBJHKLFCEP)
	{
		for(int i = 0; i < AHBBMJANGHE.Count; i++)
		{
			AHBBMJANGHE[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.AHBBMJANGHE[i]);
		}
	}

	//// RVA: 0x17BBF34 Offset: 0x17BBF34 VA: 0x17BBF34
	//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, MPBEHHIAGOI OHMCIEMIKCE, bool EFOEPDLNLJG) { }
}
