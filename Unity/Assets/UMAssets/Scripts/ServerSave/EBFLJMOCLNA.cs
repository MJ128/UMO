using System;
using System.Collections.Generic;
using XeApp.Game.Common;

[System.Obsolete("Use EBFLJMOCLNA_Costume", true)]
public class EBFLJMOCLNA { }
public class EBFLJMOCLNA_Costume : KLFDBFMNLBL_ServerSaveBlock
{
	public class ILFJDCICIKN // TypeDefIndex: 9373
	{ 
		public class PIHKHAKGNCN
		{
			public int DNLHENCICKD; // 0x8
			public int MBCPMFPKNBA; // 0xC
			public int AADPAJOLEEF; // 0x10
			public List<int> EHABLECCLLF; // 0x14

			public int ACGLMKEBMDL_UcCost { get { return DNLHENCICKD ^ FCEJCHGLFGN; } set { DNLHENCICKD = value ^ FCEJCHGLFGN; } } //0x14FDD90 ALOLFIJOOHG 0x14FDA6C JDPCOMJIMHG
			public int ANAJIAENLNB_Level { get { return MBCPMFPKNBA ^ FCEJCHGLFGN; } set { MBCPMFPKNBA = value ^ FCEJCHGLFGN; } } //0x14FDD0C MMOMNMBKHJF 0x14FDA44 FEHNFGPFINK
			public int DNBFMLBNAEE_Point { get { return AADPAJOLEEF ^ FCEJCHGLFGN; } set { AADPAJOLEEF = value ^ FCEJCHGLFGN; } } //0x14FDCF8 JKHIIAEMMDE 0x14FDA58 PFFKLBLEPKB

			// RVA: 0x14FDA18 Offset: 0x14FDA18 VA: 0x14FDA18
			public PIHKHAKGNCN()
			{
				ACGLMKEBMDL_UcCost = 0;
				ANAJIAENLNB_Level = 0;
				DNBFMLBNAEE_Point = 0;
			}
		}

		public int FBGGEFFJJHB; // 0x8
		private const sbyte CNECJGKECHK = 31;
		private const sbyte JFOFMKBJBBE = 56;
		public int BJHHOBEMBJG; // 0x10
		public long KLAPHOKNEDG; // 0x18
		public int MBCPMFPKNBA; // 0x20
		public int JJBEDMKNPFF; // 0x24
		public int AADPAJOLEEF; // 0x28
		public int LPNLLCCFHEI_IsNewColorFlags_Crypted; // 0x2C
		public long JMFGGKLPKOM; // 0x30
		public int DKOGOBKOGBM; // 0x38
		public int BFLIINDAAAA; // 0x3C
		public int IOJOBGHPLIE; // 0x40
		public int BHOGOHAILFM; // 0x44
		private int MDFMOFABGKL; // 0x48
		public List<int> LDPGNKBFJOM_Levels; // 0x4C

		public int BEEAIAAJOHD_CostumeId { get { return BJHHOBEMBJG ^ FBGGEFFJJHB; } set { BJHHOBEMBJG = FBGGEFFJJHB ^ value; } } //0x14F81D4 DIIBIOEMHAI 0x14F9084 JIHEDMEFKAF
		public bool CADENLBDAEB_IsNew { get; set; } // 0xC HMFLCAALEKM KJGFPPLHLAB ILJHLPMDHPO
		public long BEBJKJKBOGH_Date { get { return KLAPHOKNEDG ^ FBGGEFFJJHB; } set { KLAPHOKNEDG = value ^ FBGGEFFJJHB; JMFGGKLPKOM = value ^ FCEJCHGLFGN; } } //0x14F98EC DIAPHCJBPFD 0x14F9EEC IHAIKPNEEJE
		public int ANAJIAENLNB_Level { get { return MBCPMFPKNBA ^ FBGGEFFJJHB; } set { MBCPMFPKNBA = value ^ FBGGEFFJJHB; DKOGOBKOGBM = value ^ FCEJCHGLFGN; } } //0x14F8710 MMOMNMBKHJF 0x14F9F20 FEHNFGPFINK
		public int KBOLNIBLIND_Unlock { get { return JJBEDMKNPFF ^ FBGGEFFJJHB; } set { JJBEDMKNPFF = value ^ FBGGEFFJJHB; BFLIINDAAAA = value ^ FCEJCHGLFGN; } } //0x14F81E4 HEOJHPJAPJC 0x14F9F40 AGMKOELJHLC
		 public int DNBFMLBNAEE_Point { get { return AADPAJOLEEF ^ FBGGEFFJJHB; } set { AADPAJOLEEF = value ^ FBGGEFFJJHB; IOJOBGHPLIE = value ^ FCEJCHGLFGN; } } //0x14F991C JKHIIAEMMDE 0x14F9F60 PFFKLBLEPKB
		 public int MKEHNGNEFMM_IsNewColorFlags { get { return LPNLLCCFHEI_IsNewColorFlags_Crypted ^ FBGGEFFJJHB; } set { LPNLLCCFHEI_IsNewColorFlags_Crypted = value ^ FBGGEFFJJHB; BHOGOHAILFM = value ^ FCEJCHGLFGN; } } //0x14F992C BLHDBHOBDIM 0x14F9F80 HLBGPACOLCD
		 public int FOENNFDGCIC_TrsNew { get { return MDFMOFABGKL ^ FBGGEFFJJHB; } set { MDFMOFABGKL = value ^ FBGGEFFJJHB; } } //0x14F9904 KFANFPLGMAM 0x14F9FA0 OLIMMBABBFI
		// public bool FJODMPGPDDD { get; }

		// RVA: 0x14FD494 Offset: 0x14FD494 VA: 0x14FD494
		public bool GPOJCDOEDFD(int HEHKNMCDBJJ)
		{
			return (FOENNFDGCIC_TrsNew & (1 << HEHKNMCDBJJ)) == 0;
		}

		// // RVA: 0x14FD4B8 Offset: 0x14FD4B8 VA: 0x14FD4B8
		public void HBNNIHCGEOG(int HEHKNMCDBJJ, bool OAFPGJLCNFM)
		{
			if(OAFPGJLCNFM)
				FOENNFDGCIC_TrsNew &= ~(1 << HEHKNMCDBJJ);
			else
				FOENNFDGCIC_TrsNew |= 1 << HEHKNMCDBJJ;
		}

		// RVA: 0x14F9064 Offset: 0x14F9064 VA: 0x14F9064
		public ILFJDCICIKN()
		{
			LHPDDGIJKNB();
		}

		// // RVA: 0x14FD4F0 Offset: 0x14FD4F0 VA: 0x14FD4F0
		public void LHPDDGIJKNB()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BEEAIAAJOHD_CostumeId = 0;
			CADENLBDAEB_IsNew = false;
			FOENNFDGCIC_TrsNew = 0;
			BEBJKJKBOGH_Date = 0;
			ANAJIAENLNB_Level = 0;
			KBOLNIBLIND_Unlock = -1;
			DNBFMLBNAEE_Point = 0;
			MKEHNGNEFMM_IsNewColorFlags = 0;
		}

		// // RVA: 0x14F7038 Offset: 0x14F7038 VA: 0x14F7038
		public bool CGKAEMGLHNK_Possessed()
		{
			//if (RuntimeSettings.CurrentSettings.ForceCostumeUnlock)
			//	return true;
			return BEBJKJKBOGH_Date != 0;
		}

		// // RVA: 0x14FA198 Offset: 0x14FA198 VA: 0x14FA198
		public void ODDIHGPONFL(ILFJDCICIKN GPBJHKLFCEP)
		{
			BEEAIAAJOHD_CostumeId = GPBJHKLFCEP.BEEAIAAJOHD_CostumeId;
			CADENLBDAEB_IsNew = GPBJHKLFCEP.CADENLBDAEB_IsNew;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
			ANAJIAENLNB_Level = GPBJHKLFCEP.ANAJIAENLNB_Level;
			KBOLNIBLIND_Unlock = GPBJHKLFCEP.KBOLNIBLIND_Unlock;
			DNBFMLBNAEE_Point = GPBJHKLFCEP.DNBFMLBNAEE_Point;
			MKEHNGNEFMM_IsNewColorFlags = GPBJHKLFCEP.MKEHNGNEFMM_IsNewColorFlags;
			FOENNFDGCIC_TrsNew = GPBJHKLFCEP.FOENNFDGCIC_TrsNew;
		}

		// // RVA: 0x14FA540 Offset: 0x14FA540 VA: 0x14FA540
		public bool AGBOGBEOFME(ILFJDCICIKN OIKJFMGEICL)
		{
			if(BEEAIAAJOHD_CostumeId != OIKJFMGEICL.BEEAIAAJOHD_CostumeId ||
				CADENLBDAEB_IsNew != OIKJFMGEICL.CADENLBDAEB_IsNew ||
				BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date ||
				ANAJIAENLNB_Level != OIKJFMGEICL.ANAJIAENLNB_Level ||
				KBOLNIBLIND_Unlock != OIKJFMGEICL.KBOLNIBLIND_Unlock ||
				DNBFMLBNAEE_Point != OIKJFMGEICL.DNBFMLBNAEE_Point ||
				MKEHNGNEFMM_IsNewColorFlags != OIKJFMGEICL.MKEHNGNEFMM_IsNewColorFlags ||
				FOENNFDGCIC_TrsNew != OIKJFMGEICL.FOENNFDGCIC_TrsNew)
				return false;
			return true;
		}

		// // RVA: 0x14FAAD0 Offset: 0x14FAAD0 VA: 0x14FAAD0
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, EBFLJMOCLNA.ILFJDCICIKN OHMCIEMIKCE, bool KFCGIKHEEMB) { }

		// // RVA: 0x14FC9EC Offset: 0x14FC9EC VA: 0x14FC9EC
		// public FENCAJJBLBH PFAKPFKJJKA() { }

		// // RVA: 0x14FD5D0 Offset: 0x14FD5D0 VA: 0x14FD5D0
		public bool EAMPKNCDCFM(LCLCCHLDNHJ_Costume DALAFJJBBFH, int GNDJCANPLDJ, out PIHKHAKGNCN HBODCMLFDOB)
		{
            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = DALAFJJBBFH.EEOADCECNOM_GetCostumeInfo(BEEAIAAJOHD_CostumeId);
			int[] ints = DALAFJJBBFH.MBLNIECELNK_UnlockPoints[cos.AGBPBDODKBK_UnlockPointIdx];
			int[] ints2 = DALAFJJBBFH.AKKDOIJNMBH_UcCostByPoint[cos.HMCOGDICFNB_UcCostByPointIdx];
			List<int> l = new List<int>(cos.BJGNGNPHCBA_LevelsInfo.Length);
			int level = ANAJIAENLNB_Level;
			int point = DNBFMLBNAEE_Point;
			bool br = false;
			int a2 = 0;
			do
			{
				int a1 = GNDJCANPLDJ;
				GNDJCANPLDJ = point;
				int a4 = 0;
				int a5 = 0;
				while(true)
				{
					int a3 = a1;
					if(a1 < 1)
					{
						br = true;
						break;
					}
					a4 = ints[level];
					a5 = GNDJCANPLDJ + a3;
					if(a4 <= a5)
						break;
					a1 = 0;
					GNDJCANPLDJ = a5;
					if(a2 < 1)
					{
						a2 = ints2[level] * a3;
						a1 = 0;
					}
				}
				if(br)
					break;
				l.Add(level);
				if(a2 < 1)
				{
					a2 = ints2[level] * (a4 - GNDJCANPLDJ);
				}
				GNDJCANPLDJ = a5 - a4;
				level++;
				point = 0;
			} while(level < ints.Length && !br);
			HBODCMLFDOB = new PIHKHAKGNCN();
			HBODCMLFDOB.ANAJIAENLNB_Level = level;
			HBODCMLFDOB.DNBFMLBNAEE_Point = GNDJCANPLDJ;
			HBODCMLFDOB.ACGLMKEBMDL_UcCost = a2;
			HBODCMLFDOB.EHABLECCLLF = l;
			return l.Count > 0;
        }

		// // RVA: 0x14FDA80 Offset: 0x14FDA80 VA: 0x14FDA80
		public void MOACIBEKLEN(PIHKHAKGNCN HBODCMLFDOB)
		{
			DNBFMLBNAEE_Point = HBODCMLFDOB.DNBFMLBNAEE_Point;
			ANAJIAENLNB_Level = HBODCMLFDOB.ANAJIAENLNB_Level;
			if(BEBJKJKBOGH_Date == 0)
			{
				BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			}
			if(HBODCMLFDOB.EHABLECCLLF.Count > 0)
			{
				if(LDPGNKBFJOM_Levels == null)
				{
					LDPGNKBFJOM_Levels = HBODCMLFDOB.EHABLECCLLF;
				}
				else
				{
					for(int i = 0; i < HBODCMLFDOB.EHABLECCLLF.Count; i++)
					{
						LDPGNKBFJOM_Levels.Add(HBODCMLFDOB.EHABLECCLLF[i]);
					}
				}
			}
		}

		// // RVA: 0x14F83A0 Offset: 0x14F83A0 VA: 0x14F83A0
		public void GLHANCMGNDM_SetUnlockLevel(int ANAJIAENLNB)
		{
			KBOLNIBLIND_Unlock = ANAJIAENLNB;
			if (BEBJKJKBOGH_Date != 0)
				return;
			BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}

		// // RVA: 0x14FDD20 Offset: 0x14FDD20 VA: 0x14FDD20
		public bool EJODLFBKFDK_IsNewColor(int HEHKNMCDBJJ_ColorId)
		{
			return (MKEHNGNEFMM_IsNewColorFlags & (1 << (HEHKNMCDBJJ_ColorId - 1))) != 0;
		}

		// // RVA: 0x14FDD48 Offset: 0x14FDD48 VA: 0x14FDD48
		public void PDADHMIODCA(int HEHKNMCDBJJ, bool JKDJCFEBDHC)
		{
			if(JKDJCFEBDHC)
				MKEHNGNEFMM_IsNewColorFlags |= 1 << (HEHKNMCDBJJ - 1);
			else
				MKEHNGNEFMM_IsNewColorFlags &= ~(1 << (HEHKNMCDBJJ - 1));
		}
	}

	
	public enum NDOPBOCEPJO
	{
		NHIOLMNADIO_0 = 0,
		CAPLNONHNCO = 1,
		LEHHJINPFHA = 2,
	}

	private class NMAPBJMLMPM
	{
		public LCLCCHLDNHJ_Costume.JMEHNBGDEBD KBOLNIBLIND; // 0x8
		public int AHHJLDLAPAN_DivaId; // 0xC

		//// RVA: 0x14F81F4 Offset: 0x14F81F4 VA: 0x14F81F4
		public bool OHIADCDNJPB(NMAPBJMLMPM GJLFANGDGCL)
		{
			for(int i = 0; i < GJLFANGDGCL.KBOLNIBLIND.NKNBKLHCAFD_UnlocksConditions.Length; i++)
			{
				if(GJLFANGDGCL.KBOLNIBLIND.NKNBKLHCAFD_UnlocksConditions[i].INDDJNMPONH_Condition != 0)
				{
					if(GJLFANGDGCL.KBOLNIBLIND.NKNBKLHCAFD_UnlocksConditions[i].INDDJNMPONH_Condition == 2)
					{
						return false;
					}
					if (GJLFANGDGCL.KBOLNIBLIND.NKNBKLHCAFD_UnlocksConditions[i].INDDJNMPONH_Condition == 3 && AHHJLDLAPAN_DivaId != GJLFANGDGCL.AHHJLDLAPAN_DivaId)
						return false;
					for(int j = 0; j < KBOLNIBLIND.NKNBKLHCAFD_UnlocksConditions.Length; j++)
					{
						if (KBOLNIBLIND.NKNBKLHCAFD_UnlocksConditions[j].OHIADCDNJPB(GJLFANGDGCL.KBOLNIBLIND.NKNBKLHCAFD_UnlocksConditions[i]))
							break;
					}
					return false;
				}
			}
			return true;
		}

		//// RVA: 0x14FDDA4 Offset: 0x14FDDA4 VA: 0x14FDDA4 Slot: 0
		public override bool Equals(object LMNBBOIJBBL)
		{
			NMAPBJMLMPM b = LMNBBOIJBBL as NMAPBJMLMPM;
			return KBOLNIBLIND.PPFNGGCBJKC_Id == b.KBOLNIBLIND.PPFNGGCBJKC_Id && AHHJLDLAPAN_DivaId == b.AHHJLDLAPAN_DivaId;
		}
	}

	public class AEGPJOENNML
	{
		public int JPIDIENBGKH_CostumeId; // 0x8
		public int ANAJIAENLNB_Level; // 0xC
		public LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo.FBKPFMKPMAF_LevelInfo HGNBPGDIFGH_LevelInfo; // 0x10
	}

	public const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0
	public const int FCEJCHGLFGN = 0x6871471; //109515889;
	public const int PADPOGKDNDP = 500;
	private int JLFONLABECA_ShowTuto; // 0x28

	public List<ILFJDCICIKN> FABAGMLEKIB_List { get; private set; } = new List<ILFJDCICIKN>(500); // 0x24 PICMGGDAMCD NGJACJFHBKM NEHGIPDDKNG
	public override bool DMICHEJIAJL { get { return true; } } // 0x14FCB14 NFKFOODCJJB

	// // RVA: 0x14F6B90 Offset: 0x14F6B90 VA: 0x14F6B90
	public ILFJDCICIKN EEOADCECNOM_GetCostume(int PPFNGGCBJKC)
	{
		return FABAGMLEKIB_List[PPFNGGCBJKC - 1];
	}

	// // RVA: 0x14F6C10 Offset: 0x14F6C10 VA: 0x14F6C10
	public bool MLBBKNLPBBD_IsTutoDone(int OIPCCBHIKIA)
	{
		return (JLFONLABECA_ShowTuto & (1 << (OIPCCBHIKIA & 0x1f))) != 0;
	}

	// // RVA: 0x14F6C2C Offset: 0x14F6C2C VA: 0x14F6C2C
	public void ILMPHFPFLJE_SetTutoStatus(int OIPCCBHIKIA, bool OAFPGJLCNFM)
	{
		if (OAFPGJLCNFM)
			JLFONLABECA_ShowTuto |= (1 << (OIPCCBHIKIA & 0x1f));
		else
			JLFONLABECA_ShowTuto &= ~(1 << (OIPCCBHIKIA & 0x1f));
	}

	// // RVA: 0x14F6C54 Offset: 0x14F6C54 VA: 0x14F6C54
	private void JEDBIGLCMBC_ForEachUnlockedCostume(LCLCCHLDNHJ_Costume MFPNGNMFEAL_DbCos, DEKKMGAFJCG_Diva DGCJCAHIAPP_SaveDiva, bool NHMPDLNPBJD, Action<ILFJDCICIKN> KBCBGIGOLHP)
	{
		for (int i = 0; i < MFPNGNMFEAL_DbCos.CDENCMNHNGA_Costumes.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo c = MFPNGNMFEAL_DbCos.CDENCMNHNGA_Costumes[i];
			if(c.PPEGAKEIEGM_Enabled == 2)
			{
				if(NHMPDLNPBJD)
				{
					if (c.EODICFLJAKO)
						continue;
				}
				if(c.DAJGPBLEEOB_PrismCostumeModelId == 1)
				{
					if(DGCJCAHIAPP_SaveDiva.LGKFMLIOPKL_GetDivaInfo(c.AHHJLDLAPAN_PrismDivaId).CPGFPEDMDEH_Have != 0)
					{
						KBCBGIGOLHP(FABAGMLEKIB_List[i]);
					}
				}
				else
				{
					ILFJDCICIKN sc = FABAGMLEKIB_List[i];
					if(sc.BEBJKJKBOGH_Date != 0)
					{
						KBCBGIGOLHP(sc);
					}
				}
			}
		}
	}

	// // RVA: 0x14F1D78 Offset: 0x14F1D78 VA: 0x14F1D78
	public int EFFKJGEDONM_GetNumUnlockedCostume(LCLCCHLDNHJ_Costume MFPNGNMFEAL, DEKKMGAFJCG_Diva DGCJCAHIAPP, bool NHMPDLNPBJD)
	{
		int CPGFPEDMDEH = 0;
		JEDBIGLCMBC_ForEachUnlockedCostume(MFPNGNMFEAL, DGCJCAHIAPP, NHMPDLNPBJD, (EBFLJMOCLNA_Costume.ILFJDCICIKN JPAEDJJFFOI) =>
		{
			//0x14FCFAC
			CPGFPEDMDEH++;
		});
		return CPGFPEDMDEH;
	}

	// // RVA: 0x14F7060 Offset: 0x14F7060 VA: 0x14F7060
	public void BEEJCDHCONE(int JPIDIENBGKH, int ANAJIAENLNB)
	{
        LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostumeInfo(JPIDIENBGKH);
		LCLCCHLDNHJ_Costume.JMEHNBGDEBD j = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH_UnlocksConditions[cos.BJGNGNPHCBA_LevelsInfo[ANAJIAENLNB].KBOLNIBLIND_UnlockCondIdx];
		if(j.IJPCKNNNFHI() != LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.BCJHILDCONA_2_UseItems)
		{
			NMAPBJMLMPM d = new NMAPBJMLMPM();
			d.KBOLNIBLIND = j;
			d.AHHJLDLAPAN_DivaId = cos.AHHJLDLAPAN_PrismDivaId;
			List<NMAPBJMLMPM> GJFECKHFKLK = new List<NMAPBJMLMPM>(1);
			GJFECKHFKLK.Add(d);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.JEDBIGLCMBC_ForEachUnlockedCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva, true, (ILFJDCICIKN LDEGEHAEALK) =>
			{
				//0x14FCFBC
				if(LDEGEHAEALK.BEEAIAAJOHD_CostumeId == JPIDIENBGKH)
					return;
				HNLMNKFJHLK(LDEGEHAEALK, GJFECKHFKLK);
			});
		}
    }

	// // RVA: 0x14F7440 Offset: 0x14F7440 VA: 0x14F7440
	public void BJGLMIDBKKB(int JPIDIENBGKH)
	{
		List<NMAPBJMLMPM> l = PHMAHDDGICC();
		if(l.Count > 0)
		{
			HNLMNKFJHLK(EEOADCECNOM_GetCostume(JPIDIENBGKH), l);
		}
	}

	// // RVA: 0x14F7E20 Offset: 0x14F7E20 VA: 0x14F7E20
	public void AGEAPKNODHO()
	{
		List<NMAPBJMLMPM> l = PHMAHDDGICC();
		if(l.Count > 0)
		{
			JEDBIGLCMBC_ForEachUnlockedCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva, true, (ILFJDCICIKN LDEGEHAEALK) =>
			{
				//0x14FD01C
				HNLMNKFJHLK(LDEGEHAEALK, l);
			});
		}
	}

	// // RVA: 0x14F8070 Offset: 0x14F8070 VA: 0x14F8070
	public void CGBCFBGJHKC(int AHHJLDLAPAN)
	{
		List<NMAPBJMLMPM> l = PHMAHDDGICC();
		if (l.Count < 1)
			return;
		HNLMNKFJHLK(EEOADCECNOM_GetCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.MGENBBDAONJ(AHHJLDLAPAN).JPIDIENBGKH_CostumeId), l);
	}

	// // RVA: 0x14F74E4 Offset: 0x14F74E4 VA: 0x14F74E4
	private List<NMAPBJMLMPM> PHMAHDDGICC()
	{
		LCLCCHLDNHJ_Costume NDFIEMPPMLF = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
		Dictionary<int, LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition> KMECJBPCDDD = new Dictionary<int, LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition>(NDFIEMPPMLF.FDNBEPCEHBH_UnlocksConditions.Count);
		foreach(var k in NDFIEMPPMLF.FDNBEPCEHBH_UnlocksConditions)
		{
			LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition d = k.Value.IJPCKNNNFHI();
			KMECJBPCDDD.Add(k.Key, d);
		}
		List<NMAPBJMLMPM> GJFECKHFKLK = new List<NMAPBJMLMPM>(FABAGMLEKIB_List.Count * 6);
		JEDBIGLCMBC_ForEachUnlockedCostume(NDFIEMPPMLF, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva, true, (ILFJDCICIKN LDEGEHAEALK) =>
		{
			//0x14FD050
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo c = NDFIEMPPMLF.EEOADCECNOM_GetCostumeInfo(LDEGEHAEALK.BEEAIAAJOHD_CostumeId);
			for (int i = 0; i < LDEGEHAEALK.KBOLNIBLIND_Unlock + 1; i++)
			{
				if (c.BJGNGNPHCBA_LevelsInfo[i].KBOLNIBLIND_UnlockCondIdx != 0)
				{
					if (KMECJBPCDDD[c.BJGNGNPHCBA_LevelsInfo[i].KBOLNIBLIND_UnlockCondIdx] != LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.BCJHILDCONA_2_UseItems)
					{
						NMAPBJMLMPM ACGLMKEBMDL = new NMAPBJMLMPM();
						ACGLMKEBMDL.KBOLNIBLIND = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH_UnlocksConditions[c.BJGNGNPHCBA_LevelsInfo[i].KBOLNIBLIND_UnlockCondIdx];
						if(KMECJBPCDDD[c.BJGNGNPHCBA_LevelsInfo[i].KBOLNIBLIND_UnlockCondIdx] == LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.CALCHKAMIDB_3_DivaIntimacy)
						{
							ACGLMKEBMDL.AHHJLDLAPAN_DivaId = c.AHHJLDLAPAN_PrismDivaId;
						}
						else
						{
							ACGLMKEBMDL.AHHJLDLAPAN_DivaId = 0;
						}
						NMAPBJMLMPM m = GJFECKHFKLK.Find((NMAPBJMLMPM JPAEDJJFFOI) =>
						{
							//0x14FD458
							return JPAEDJJFFOI.Equals(ACGLMKEBMDL);
						});
						if(m == null)
						{
							GJFECKHFKLK.Add(ACGLMKEBMDL);
						}
					}
				}
			}
		});
		return GJFECKHFKLK;
	}

	// // RVA: 0x14F7A78 Offset: 0x14F7A78 VA: 0x14F7A78
	private void HNLMNKFJHLK(ILFJDCICIKN LDEGEHAEALK_SaveCostume, List<NMAPBJMLMPM> GJFECKHFKLK)
	{
		LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostumeInfo(LDEGEHAEALK_SaveCostume.BEEAIAAJOHD_CostumeId);
		int level = -1;
		for(int i = LDEGEHAEALK_SaveCostume.KBOLNIBLIND_Unlock; i < c.LLLCMHENKKN_LevelMax; i++)
		{
			if (c.BJGNGNPHCBA_LevelsInfo[i + 1].KBOLNIBLIND_UnlockCondIdx != 0)
			{
				NMAPBJMLMPM data = new NMAPBJMLMPM();
				data.KBOLNIBLIND = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH_UnlocksConditions[c.BJGNGNPHCBA_LevelsInfo[i + 1].KBOLNIBLIND_UnlockCondIdx];
				data.AHHJLDLAPAN_DivaId = c.AHHJLDLAPAN_PrismDivaId;
				for(int j = 0; j < GJFECKHFKLK.Count; j++)
				{
					level = i + 1;
					if (GJFECKHFKLK[j].OHIADCDNJPB(data))
						break;
				}
			}
		}
		if (level < 0)
			return;
		LDEGEHAEALK_SaveCostume.GLHANCMGNDM_SetUnlockLevel(level);
	}

	// // RVA: 0x14F84D4 Offset: 0x14F84D4 VA: 0x14F84D4
	public StatusData NNIKNCGNDHK_GetStatForDiva(int MCDINKAKFGG_DivaId)
	{
		StatusData res = new StatusData();
		for (int i = 0; i < FABAGMLEKIB_List.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCostume = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostumeInfo(FABAGMLEKIB_List[i].BEEAIAAJOHD_CostumeId);
			if(FABAGMLEKIB_List[i].BEBJKJKBOGH_Date != 0 && dbCostume.AHHJLDLAPAN_PrismDivaId == MCDINKAKFGG_DivaId)
			{
				dbCostume.NNIKNCGNDHK_AddStatsAtLevel(FABAGMLEKIB_List[i].ANAJIAENLNB_Level, res);
			}
		}
		return res;
	}

	// // RVA: 0x14F8720 Offset: 0x14F8720 VA: 0x14F8720
	public int[,] GODGHFDMAHF_GetRateBySupportPlate()
	{
		int[,] res = new int[LCLCCHLDNHJ_Costume.GFIKOEEBIJP, 3];
		for (int i = 0; i < FABAGMLEKIB_List.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostumeInfo(FABAGMLEKIB_List[i].BEEAIAAJOHD_CostumeId);
			if(FABAGMLEKIB_List[i].BEBJKJKBOGH_Date != 0)
			{
				dbCos.LEFFFKJFCFH_AddNumSupportPlate(FABAGMLEKIB_List[i].ANAJIAENLNB_Level, res);
			}
		}
		bool found = false;
		for (int i = 0; i < res.GetLength(0); i++)
		{
			for(int j = 0; j < res.GetLength(1); j++)
			{
				if(res[i, j] > 0)
				{
					res[i, j] = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.OLNFADCCMIG_RateBySupportPlate[res[i, j] - 1];
					found = true;
				}
			}
		}
		return found ? res : null;
	}

	// // RVA: 0x14F8ADC Offset: 0x14F8ADC VA: 0x14F8ADC
	public int AAKEPLHPLPL(LCLCCHLDNHJ_Costume MFPNGNMFEAL, int NDKJCDGHPLD_MasterVersion, int IIELLEPEEFH_TrsVersion)
	{
		int res = 0;
		for(int i = 0; i < MFPNGNMFEAL.CDENCMNHNGA_Costumes.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCostume = MFPNGNMFEAL.CDENCMNHNGA_Costumes[i];
			if(dbCostume.PPEGAKEIEGM_Enabled == 2)
			{
				if(LMLGEDEJCJO(dbCostume.JPIDIENBGKH_CostumeId, MFPNGNMFEAL, false) > 0)
				{
					if (IIELLEPEEFH_TrsVersion < dbCostume.IIELLEPEEFH_TrsVersion && NDKJCDGHPLD_MasterVersion >= dbCostume.IIELLEPEEFH_TrsVersion && res < dbCostume.IIELLEPEEFH_TrsVersion)
						res = dbCostume.IIELLEPEEFH_TrsVersion;
				}
			}
		}
		return res;
	}

	// // RVA: 0x14F8C6C Offset: 0x14F8C6C VA: 0x14F8C6C
	public int LMLGEDEJCJO(int PPFNGGCBJKC, LCLCCHLDNHJ_Costume MFPNGNMFEAL, bool HGIKOKNMMDH = true)
	{
		if(PPFNGGCBJKC > 0)
		{
			if (PPFNGGCBJKC < FABAGMLEKIB_List.Count)
			{
				if(HGIKOKNMMDH)
				{
					if (!MFPNGNMFEAL.JAHFLLONDCN(PPFNGGCBJKC, 0))
						return 0;
				}
				if(MFPNGNMFEAL.EEOADCECNOM_GetCostumeInfo(PPFNGGCBJKC).DAJGPBLEEOB_PrismCostumeModelId == 1)
				{
					DEKKMGAFJCG_Diva sDivas = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva;
					if (sDivas != null)
					{
						DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo sDiva = sDivas.LGKFMLIOPKL_GetDivaInfo(MFPNGNMFEAL.EEOADCECNOM_GetCostumeInfo(PPFNGGCBJKC).AHHJLDLAPAN_PrismDivaId);
						if (sDiva != null)
						{
							return sDiva.CPGFPEDMDEH_Have == 1 ? 1 : 0;
						}
					}
				}
				else
				{
					return FABAGMLEKIB_List[PPFNGGCBJKC - 1].BEBJKJKBOGH_Date != 0 ? 1 : 0;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x14F8EB0 Offset: 0x14F8EB0 VA: 0x14F8EB0
	public EBFLJMOCLNA_Costume()
	{
		KMBPACJNEOF();
	}

	// // RVA: 0x14F8F54 Offset: 0x14F8F54 VA: 0x14F8F54 Slot: 4
	public override void KMBPACJNEOF()
	{
		FABAGMLEKIB_List.Clear();
		for(int i = 1; i < 501; i++)
		{
			ILFJDCICIKN data = new ILFJDCICIKN();
			data.BEEAIAAJOHD_CostumeId = i;
			FABAGMLEKIB_List.Add(data);
		}
		JLFONLABECA_ShowTuto = 0;
	}

	// // RVA: 0x14F9094 Offset: 0x14F9094 VA: 0x14F9094 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP] = "";
		for(int i = 0; i < FABAGMLEKIB_List.Count; i++)
		{
			if(FABAGMLEKIB_List[i].BEBJKJKBOGH_Date != 0 || FABAGMLEKIB_List[i].FOENNFDGCIC_TrsNew != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = FABAGMLEKIB_List[i].BEEAIAAJOHD_CostumeId;
				data2[AFEHLCGHAEE_Strings.KLJGEHBKMMG_new] = FABAGMLEKIB_List[i].CADENLBDAEB_IsNew;
				data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = FABAGMLEKIB_List[i].BEBJKJKBOGH_Date;
				data2["lv"] = FABAGMLEKIB_List[i].ANAJIAENLNB_Level;
				data2["unlock"] = FABAGMLEKIB_List[i].KBOLNIBLIND_Unlock;
				data2["point"] = FABAGMLEKIB_List[i].DNBFMLBNAEE_Point;
				data2["col_new"] = FABAGMLEKIB_List[i].MKEHNGNEFMM_IsNewColorFlags;
				data2[AFEHLCGHAEE_Strings.DLMDINBHGBG_trs_new] = FABAGMLEKIB_List[i].FOENNFDGCIC_TrsNew;
				data[POFDDFCGEGP + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.FFKMJNHFFFL_costume] = data;
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data2["show_tuto"] = JLFONLABECA_ShowTuto;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x14F993C Offset: 0x14F993C VA: 0x14F993C Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				LCLCCHLDNHJ_Costume costumeDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
				for (int i = 0; i < costumeDb.CDENCMNHNGA_Costumes.Count; i++)
				{
					LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo item = costumeDb.CDENCMNHNGA_Costumes[i];
					if(item.PPEGAKEIEGM_Enabled == 2)
					{
						string str = POFDDFCGEGP + (i + 1).ToString();
						if(block.BBAJPINMOEP_Contains(str))
						{
							EDOHBJAPLPF_JsonData b = block[str];
							ILFJDCICIKN data = FABAGMLEKIB_List[i];
							data.BEEAIAAJOHD_CostumeId = i + 1;
							data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) != 0;
							data.BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
							data.ANAJIAENLNB_Level = CJAENOMGPDA_ReadInt(b, "lv", 0, ref isInvalid);
							data.KBOLNIBLIND_Unlock = CJAENOMGPDA_ReadInt(b, "unlock", -1, ref isInvalid);
							data.DNBFMLBNAEE_Point = CJAENOMGPDA_ReadInt(b, "point", 0, ref isInvalid);
							data.MKEHNGNEFMM_IsNewColorFlags = CJAENOMGPDA_ReadInt(b, "col_new", 0, ref isInvalid);
							data.FOENNFDGCIC_TrsNew = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.DLMDINBHGBG_trs_new, 0, ref isInvalid);
						}
					}
				}
				EDOHBJAPLPF_JsonData b2 = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
				JLFONLABECA_ShowTuto = CJAENOMGPDA_ReadInt(b2, "show_tuto", 0, ref isInvalid);
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x14F9FB0 Offset: 0x14F9FB0 VA: 0x14F9FB0 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		EBFLJMOCLNA_Costume c = GPBJHKLFCEP as EBFLJMOCLNA_Costume;
		for(int i = 0; i < FABAGMLEKIB_List.Count; i++)
		{
			FABAGMLEKIB_List[i].ODDIHGPONFL(c.FABAGMLEKIB_List[i]);
		}
		JLFONLABECA_ShowTuto = c.JLFONLABECA_ShowTuto;
	}

	// // RVA: 0x14FA2E8 Offset: 0x14FA2E8 VA: 0x14FA2E8 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		EBFLJMOCLNA_Costume other = GPBJHKLFCEP as EBFLJMOCLNA_Costume;
		if(FABAGMLEKIB_List.Count != other.FABAGMLEKIB_List.Count)
			return false;
		for(int i = 0; i < FABAGMLEKIB_List.Count; i++)
		{
			if(!FABAGMLEKIB_List[i].AGBOGBEOFME(other.FABAGMLEKIB_List[i]))
				return false;
		}
		return JLFONLABECA_ShowTuto == other.JLFONLABECA_ShowTuto;
	}

	// // RVA: 0x14FA654 Offset: 0x14FA654 VA: 0x14FA654 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0x14FC8B4 Offset: 0x14FC8B4 VA: 0x14FC8B4 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}

	// // RVA: 0x14FCB1C Offset: 0x14FCB1C VA: 0x14FCB1C
	public List<AEGPJOENNML> POEDIMMMLME(LCLCCHLDNHJ_Costume DALAFJJBBFH, ref bool AJFHCEEKPPA)
	{
		List<AEGPJOENNML> res = new List<AEGPJOENNML>();
		for(int i = 0; i < FABAGMLEKIB_List.Count; i++)
		{
			if(FABAGMLEKIB_List[i].LDPGNKBFJOM_Levels != null)
			{
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = DALAFJJBBFH.EEOADCECNOM_GetCostumeInfo(FABAGMLEKIB_List[i].BEEAIAAJOHD_CostumeId);
				if(cos.PPEGAKEIEGM_Enabled != 0)
				{
					for(int j = 0; j < FABAGMLEKIB_List[i].LDPGNKBFJOM_Levels.Count; j++)
					{
						AEGPJOENNML data = new AEGPJOENNML();
						data.JPIDIENBGKH_CostumeId = FABAGMLEKIB_List[i].BEEAIAAJOHD_CostumeId;
						data.ANAJIAENLNB_Level = FABAGMLEKIB_List[i].LDPGNKBFJOM_Levels[j];
						data.HGNBPGDIFGH_LevelInfo = cos.BJGNGNPHCBA_LevelsInfo[data.ANAJIAENLNB_Level];
						AJFHCEEKPPA = true;
						res.Add(data);
					}
				}
			}
		}
		if(res.Count == 0)
			res = null;
		return res;
	}

	// // RVA: 0x14FCE60 Offset: 0x14FCE60 VA: 0x14FCE60
	// public void CLADPCMBMMO() { }
}
