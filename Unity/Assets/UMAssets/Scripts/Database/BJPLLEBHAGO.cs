using System.Collections.Generic;

[System.Obsolete("Use EPPOHFLMDBC_DivaStats", true)]
public class EPPOHFLMDBC { }

[UMOClass(ReaderClass = "DCHENGJKOKI")]
public class EPPOHFLMDBC_DivaStats
{
	public int FBGGEFFJJHB_Key = 0x1a915b; // 0x8
	public int MBCPMFPKNBA_LevelCrypted; // 0xC
	public int DBJFLJIMONP_LifeCrypted; // 0x10
	public int NDKJOJLCJBI_SoulCrypted; // 0x14
	public int GLMAGOANCLM_VocalCrypted; // 0x18
	public int CHINMGJCEDH_CharmCrypted; // 0x1C
	public int EAJBBFLFDHI_FoldCrypted; // 0x20
	public int EHDLPKCCJIA_SupportCrypted; // 0x24

	[UMOMember(ReaderMember = "", ReaderDisplay = "DivaStat")]
	public int ANAJIAENLNB_Level { get { return FBGGEFFJJHB_Key ^ MBCPMFPKNBA_LevelCrypted; } set { MBCPMFPKNBA_LevelCrypted = FBGGEFFJJHB_Key ^ value; } } //0xFC14D4 MMOMNMBKHJF 0xFC14E4 FEHNFGPFINK
	[UMOMember(ReaderMember = "BCCOMAODPJI|OEOIHIIIMCK", ReaderDisplay = "DivaStat_1")]
	public int HFIDCMNFBJG_Life { get { return FBGGEFFJJHB_Key ^ DBJFLJIMONP_LifeCrypted; } set { DBJFLJIMONP_LifeCrypted = FBGGEFFJJHB_Key ^ value; } } //0xFC14F4 CMDOHPBAFCO 0xFC1504 BJBDGCMJNEO
	[UMOMember(ReaderMember = "LJELGFAFGAB|OEOIHIIIMCK", ReaderDisplay = "DivaStat_2")]
	public int PFJCOCPKABN_Soul { get { return FBGGEFFJJHB_Key ^ NDKJOJLCJBI_SoulCrypted; } set { NDKJOJLCJBI_SoulCrypted = FBGGEFFJJHB_Key ^ value; } } //0xFC1514 EJPPLFNLAAO 0xFC1524 NEMMJEJENFD
	[UMOMember(ReaderMember = "KNEDJFLCCLN|OEOIHIIIMCK", ReaderDisplay = "DivaStat_3")]
	public int JFJDLEMNKFE_Vocal { get { return FBGGEFFJJHB_Key ^ GLMAGOANCLM_VocalCrypted; } set { GLMAGOANCLM_VocalCrypted = FBGGEFFJJHB_Key ^ value; } }// 0xFC1534 GCMPLDKECFM 0xFC1544 CEHKELOHIBD
	[UMOMember(ReaderMember = "MBAMIOJNGBD|OEOIHIIIMCK", ReaderDisplay = "DivaStat_4")]
	public int GDOLPGBLMEA_Charm { get { return FBGGEFFJJHB_Key ^ CHINMGJCEDH_CharmCrypted; } set { CHINMGJCEDH_CharmCrypted = FBGGEFFJJHB_Key ^ value; } } //0xFC1554 LEHDODJMICA 0xFC1564 IKPOCJDOOGA
	[UMOMember(ReaderMember = "ADLGKMBIPCA|OEOIHIIIMCK", ReaderDisplay = "DivaStat_5")]
	public int ONDFNOOICLE_Fold { get { return FBGGEFFJJHB_Key ^ EAJBBFLFDHI_FoldCrypted; } set { EAJBBFLFDHI_FoldCrypted = FBGGEFFJJHB_Key ^ value; } } //0xFC1574 OGGOHKCANFG 0xFC1584 BKMHMPEBNPE
	[UMOMember(ReaderMember = "PIPCIMIALOO|OEOIHIIIMCK", ReaderDisplay = "DivaStat_6")]
	public int HCFOMFDPGEC_Support { get { return FBGGEFFJJHB_Key ^ EHDLPKCCJIA_SupportCrypted; } set { EHDLPKCCJIA_SupportCrypted = FBGGEFFJJHB_Key ^ value; } } //0xFC1594 GGIDKCOMCJL 0xFC15A4 LAIHOHGICJD

	// // RVA: 0xFC15B4 Offset: 0xFC15B4 VA: 0xFC15B4
	public void DOMFHDPMCCO_Init(int ANAJIAENLNB_Level, int FBGGEFFJJHB_Key, short JKPPKAHPPKH_Life, short MKMIEGPOKGG_Soul, short MELGGCAIONF_Vocal, short LDLHPACIIAB_Charm, short JNNDFGPMEDA_Fold, short IDOIMLGLPAB_Support)
	{
		this.FBGGEFFJJHB_Key = FBGGEFFJJHB_Key;
		this.ANAJIAENLNB_Level = ANAJIAENLNB_Level;
		HFIDCMNFBJG_Life = JKPPKAHPPKH_Life;
		PFJCOCPKABN_Soul = MKMIEGPOKGG_Soul;
		JFJDLEMNKFE_Vocal = MELGGCAIONF_Vocal;
		GDOLPGBLMEA_Charm = LDLHPACIIAB_Charm;
		ONDFNOOICLE_Fold = JNNDFGPMEDA_Fold;
		HCFOMFDPGEC_Support = IDOIMLGLPAB_Support;
	}

	// // RVA: 0xFC160C Offset: 0xFC160C VA: 0xFC160C
	public void ANIJHEBLMGB_AddStat(int INDDJNMPONH_Type, short JBGEEPFKIGG_Value)
	{
		switch(INDDJNMPONH_Type)
		{
			case 1:
				HFIDCMNFBJG_Life += JBGEEPFKIGG_Value;
			break;
			case 2:
				PFJCOCPKABN_Soul += JBGEEPFKIGG_Value;
			break;
			case 3:
				JFJDLEMNKFE_Vocal += JBGEEPFKIGG_Value;
			break;
			case 4:
				GDOLPGBLMEA_Charm += JBGEEPFKIGG_Value;
			break;
			case 5:
				ONDFNOOICLE_Fold += JBGEEPFKIGG_Value;
			break;
			case 6:
				HCFOMFDPGEC_Support += JBGEEPFKIGG_Value;
			break;
			default:
			break;
		}
	}

	// // RVA: 0xFC1698 Offset: 0xFC1698 VA: 0xFC1698
	public void ODDIHGPONFL_CopyValues(EPPOHFLMDBC_DivaStats GPBJHKLFCEP)
	{
		ANAJIAENLNB_Level = GPBJHKLFCEP.ANAJIAENLNB_Level;
		HFIDCMNFBJG_Life = GPBJHKLFCEP.HFIDCMNFBJG_Life;
		PFJCOCPKABN_Soul = GPBJHKLFCEP.PFJCOCPKABN_Soul;
		JFJDLEMNKFE_Vocal = GPBJHKLFCEP.JFJDLEMNKFE_Vocal;
		GDOLPGBLMEA_Charm = GPBJHKLFCEP.GDOLPGBLMEA_Charm;
		ONDFNOOICLE_Fold = GPBJHKLFCEP.ONDFNOOICLE_Fold;
		HCFOMFDPGEC_Support = GPBJHKLFCEP.HCFOMFDPGEC_Support;
	}

	// // RVA: 0xFC1800 Offset: 0xFC1800 VA: 0xFC1800
	// public uint CAOGDCBPBAN() { }
}

[System.Obsolete("Use BJPLLEBHAGO_DivaInfo", true)]
public class BJPLLEBHAGO { }

[UMOClass(ReaderClass = "MALFJMBMCLG")]
public class BJPLLEBHAGO_DivaInfo
{
	[UMOMember(ReaderMember = "KLCMKLPIDDJ", Name = "Birthday month")]
	public sbyte DOAJJALOKLI_Month; // 0xD
	[UMOMember(ReaderMember = "BAOFEFFADPD", Name = "Birthday day")]
	public sbyte PKNONBBKCCP_Day; // 0xE
	[UMOMember(ReaderMemberChild = "DFEDIAPLFHN", ReaderDisplay = "PropagateReader", Name = "Stats by level", Desc = "Diva stat for each level.\nLevel 0 has the base value, then for each level, add a stat.\nAdditional values are stored in alternative type/value. Types are : \n* 1:Life\n* 2:Sould\n* 3:Vocal\n* 4:Charm\n* 5:Fold\n* 6:Support")]
	public List<EPPOHFLMDBC_DivaStats> CMCKNKKCNDK_StatsByLevel = new List<EPPOHFLMDBC_DivaStats>(); // 0x14

	[UMOMember(ReaderMember = "JPFMJHLCMJL", Name = "Attribute", Desc = "Refer to the series where the diva belongs.")]
	public sbyte AIHCEGFANAM_Attr { get; set; } // 0x8 FJOGAAMLJMA ANEJPLENMAL HEHDOGFEIOL
	[UMOMember(ReaderMember = "PPFNGGCBJKC", Name = "Diva Id", Desc = "Id of the diva, used to reference it from other data.")]
	public sbyte AHHJLDLAPAN_DivaId { get; set; } // 0x9 AMALMGIALDF IPKDLMIDMHH IENNENMKEFO
	[UMOMember(ReaderMember = "JIBNPJCIALH", Name = "Body Id")]
	public sbyte IDDHKOEFJFB_BodyId { get; set; }  // 0xA KEOMNKLLNFJ // ADCMNNJMGKO KOFCMDMLAHC 
	[UMOMember(ReaderMember = "OKADDOIJGNB", Name = "Personality Id")]
	public sbyte FPMGHDKACOF_PersonalityId { get; set; } // 0xB AJHJBOKOPAJ // ALJDJOFDKDJ FPFJHHIANFD
	[UMOMember(ReaderMember = "IJEKNCDIIAE|PLALNIIBLOF", Desc = "Availabe in game if value = 2")]
	public sbyte PPEGAKEIEGM_Enabled { get; set; } // 0xC NEKLJCCBECB KPOEEPIMMJP NCIEAFEDPBH
	[UMOMember(ReaderMember = "LIOGKHIGJKN", Name = "Free Music Id")]
	public ushort LIOGKHIGJKN_FreeMusicId { get; set; } // 0x10 DGLBKOGGKHO JNBPCHKDNMD MLPEHHGEEIB
	[UMOMember(ReaderMember = "CMBCBNEODPD", Name = "Home Bg Id", Desc = "Default home background for the diva")]
	public ushort CMBCBNEODPD_HomeBgId { get; set; } // 0x12 CLHDIBCIJBB EIMFDHBOECI OJMIHHIIBPI

	// // RVA: 0xC85E00 Offset: 0xC85E00 VA: 0xC85E00
	// public uint CAOGDCBPBAN() { }
}
