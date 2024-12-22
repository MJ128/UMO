
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use DHOJHGODBAB_Quest", true)]
public class DHOJHGODBAB { }
public class DHOJHGODBAB_Quest : DIHHCBACKGG_DbSection
{
	public List<CNLPPCFJEID_QuestInfo> BEGCHDHHEKC_DailyQuests { get; private set; } // 0x20 FGGBICBDOEN DEBOJOHHPPB CFINEIEEJGN
	public List<CNLPPCFJEID_QuestInfo> GPMKFMFEKLN_NormalQuests { get; private set; } // 0x24 LKPJIEOOENM HDOHKBOJCDK CDNIDJPOHDJ
	public List<LCKMNLOLDPD> LFAAEPAAEMB { get; private set; } // 0x28 LGPNBHKGMEA CBMPDJKIIOF EFCJGLJJBNA

	// RVA: 0x1988E24 Offset: 0x1988E24 VA: 0x1988E24
	public DHOJHGODBAB_Quest()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		BEGCHDHHEKC_DailyQuests = new List<CNLPPCFJEID_QuestInfo>();
		GPMKFMFEKLN_NormalQuests = new List<CNLPPCFJEID_QuestInfo>();
		LFAAEPAAEMB = new List<LCKMNLOLDPD>();
		LMHMIIKCGPE = 67;
	}

	// RVA: 0x1988F64 Offset: 0x1988F64 VA: 0x1988F64 Slot: 8
	protected override void KMBPACJNEOF()
	{
		BEGCHDHHEKC_DailyQuests.Clear();
		GPMKFMFEKLN_NormalQuests.Clear();
		LFAAEPAAEMB.Clear();
		int t = (int)Utility.GetCurrentUnixTime();
		t *= 7;
		int v = t;
		for(int i = 1; i < 21; i++)
		{
			CNLPPCFJEID_QuestInfo data = new CNLPPCFJEID_QuestInfo();
			data.LHPDDGIJKNB(i, v);
			BEGCHDHHEKC_DailyQuests.Add(data);
			v += 3;
		}
		for(int i = 0; i < 1700; i++)
		{
			CNLPPCFJEID_QuestInfo data = new CNLPPCFJEID_QuestInfo();
			data.LHPDDGIJKNB(i + 1, t);
			GPMKFMFEKLN_NormalQuests.Add(data);
			t += 7;
		}
	}

	// RVA: 0x1989194 Offset: 0x1989194 VA: 0x1989194 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		GEDOHHLGKCG parser = GEDOHHLGKCG.HEGEKFMJNCC(DBBGALAPFGC);
		if(EELEJILKBIM_LoadDailyQuest(parser) && GBNIHKOIMFO_LoadNormalQuest(parser))
		{
			IHJNKFOJPKM(parser);
			return true;
		}
		return false;
	}

	//// RVA: 0x19891F4 Offset: 0x19891F4 VA: 0x19891F4
	private bool EELEJILKBIM_LoadDailyQuest(GEDOHHLGKCG ENCJBKPHGAL)
	{
		EKMJAONFHDF[] array = ENCJBKPHGAL.HGMBJPLPHJJ;
		if (array.Length < 21)
		{
			for (int i = 0; i < array.Length; i++)
			{
				CNLPPCFJEID_QuestInfo data = BEGCHDHHEKC_DailyQuests[i];
				data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
				data.INDDJNMPONH_Type = (int)array[i].MAPNDFCJFLJ;
				data.CHOFDPDFPDC_ConfigValue = (int)array[i].JBFLEDKDFCO;
				data.FCDKJAKLGMB = (int)array[i].PMDLBHLNIDP;
				data.AKBHPFBDDOL_DayOfWeek = (int)array[i].JIMJHIDEHNM;
				data.EIHOBHDKCDB_RewardId = (int)array[i].JGOHPDKCJKB;
				data.HHIBBHFHENH_LinkQuestId = 0;
				data.EILKGEADKGH = (int)array[i].FPOMEEJFBIG;
				data.KJBGCLPMLCG = array[i].FNEIADJMHHO;
				data.GJFPFFBAKGK = array[i].EICJBAEDMNM;
				data.DEPGBBJMFED = data.PPFNGGCBJKC;
			}
			return true;
		}
		else
		{
			HDIDJNCGICK_LoadError = "daily quest limit over";
			return false;
		}
	}

	//// RVA: 0x1989628 Offset: 0x1989628 VA: 0x1989628
	private bool GBNIHKOIMFO_LoadNormalQuest(GEDOHHLGKCG ENCJBKPHGAL)
	{
		GBGCDLGBMEF[] array = ENCJBKPHGAL.MECOBEMIHDG;
		if (array.Length < 1701)
		{
			for (int i = 0; i < array.Length; i++)
			{
				CNLPPCFJEID_QuestInfo data = GPMKFMFEKLN_NormalQuests[i];
				data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
				data.INDDJNMPONH_Type = (int)array[i].MAPNDFCJFLJ;
				data.CHOFDPDFPDC_ConfigValue = (int)array[i].JBFLEDKDFCO;
				data.FCDKJAKLGMB = (int)array[i].PMDLBHLNIDP;
				data.AKBHPFBDDOL_DayOfWeek = 0;
				data.EIHOBHDKCDB_RewardId = (int)array[i].JGOHPDKCJKB;
				data.EILKGEADKGH = (int)array[i].FPOMEEJFBIG;
				data.KJBGCLPMLCG = array[i].FNEIADJMHHO;
				data.GJFPFFBAKGK = array[i].EICJBAEDMNM;
				data.OAPCHMHAJID = array[i].HPGNBPIBAOM != 0;
				data.DEPGBBJMFED = (int)array[i].DMEDKJPOLCH;
				data.HDBFCIOCNPA_AchievementId = (int)array[i].ADOJHHMMNIN;
				data.LMPPENOILPF = (int)array[i].ADCKKAFCIAC;
				data.EKANGPODCEP = array[i].JMMEGKGCIIL;
				if(JKAECBCNHAN_IsEnabled((int)array[i].IJEKNCDIIAE, data.INDDJNMPONH_Type != 0 ? 2 : data.INDDJNMPONH_Type, 0) != 2)
				{
					data.INDDJNMPONH_Type = 0;
				}
			}
			return true;
		}
		else
		{
			HDIDJNCGICK_LoadError = "normal quest limit over";
			return false;
		}
	}

	//// RVA: 0x1989B7C Offset: 0x1989B7C VA: 0x1989B7C
	private bool IHJNKFOJPKM(GEDOHHLGKCG ENCJBKPHGAL)
	{
		KLPHKNHEKPM[] array = ENCJBKPHGAL.APHNKNGKKFC;
		for(int i = 0; i < array.Length; i++)
		{
			LCKMNLOLDPD data = new LCKMNLOLDPD();
			data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
			data.GLCLFMGPMAN_ItemFullId = (int)array[i].CLDDAEMKHOG;
			data.HMFFHLPNMPH_Cnt = (int)array[i].PIMBMBIICMK;
			data.BGFPPGPJONG_QuestKeyId = (int)array[i].LJNAKDMILMC;
			data.APNMKLJMPMD_Type = (int)array[i].OILNNGPCLGD;
			LFAAEPAAEMB.Add(data);
		}
		return true;
	}

	// RVA: 0x1989F28 Offset: 0x1989F28 VA: 0x1989F28 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "DHOJHGODBAB_Quest.CAOGDCBPBAN");
		return 0;
	}
}

[System.Obsolete("Use CNLPPCFJEID_QuestInfo", true)]
public class CNLPPCFJEID { }
public class CNLPPCFJEID_QuestInfo
{
	public int FBGGEFFJJHB; // 0x8
	private int EHOIENNDEDH; // 0xC
	private int MKENMKMJFKP; // 0x10
	private int ICLBAMBDKNI; // 0x14
	private int NILLPINGIIP; // 0x18
	private int FKKHMCINELD; // 0x1C
	private int IOAGHJGBNLC; // 0x20
	private int APJGMOJDPAK; // 0x24
	private int HNEHIJCAOJM; // 0x28
	private long IBCNABKLHHH; // 0x30
	private long MABPKDKBJAG; // 0x38
	private int HHPFFPINGAA; // 0x40
	private int ELFADCBHPCD; // 0x44
	private int EGCMPELNLKP; // 0x48
	public bool OAPCHMHAJID; // 0x4C
	public int HDBFCIOCNPA_AchievementId; // 0x50

	public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x175CD9C DEMEPMAEJOO 0x175CCD4 HIGKAIDMOKN
	public int INDDJNMPONH_Type { get { return MKENMKMJFKP ^ FBGGEFFJJHB; } set { MKENMKMJFKP = value ^ FBGGEFFJJHB; } } //0x175CDA8 GHAILOLPHPF 0x175CCE4 BACGOKIGMBC
	public int CHOFDPDFPDC_ConfigValue { get { return ICLBAMBDKNI ^ FBGGEFFJJHB; } set { ICLBAMBDKNI = value ^ FBGGEFFJJHB; } } //0x175CDB8 IBCDKHDLOKG 0x175CCF4 ICHJGBKDCGM
	public int FCDKJAKLGMB { get { return NILLPINGIIP ^ FBGGEFFJJHB; } set { NILLPINGIIP = value ^ FBGGEFFJJHB; } } //0x175CDC8 IJPJEEOLPIG 0x175CDD8 EDECEGOKICK
	public int HHIBBHFHENH_LinkQuestId { get { return IOAGHJGBNLC ^ FBGGEFFJJHB; } set { IOAGHJGBNLC = value ^ FBGGEFFJJHB; } } //0x175CDE8 MEHBABCCHOO 0x175CD14 FBCMDNCLBDC
	public int DEPGBBJMFED { get { return HNEHIJCAOJM ^ FBGGEFFJJHB; } set { HNEHIJCAOJM = value ^ FBGGEFFJJHB; } } //0x175CDF8 FNMFOBJIIIC 0x175CD6C OBEDPJLBBEG
	public int AKBHPFBDDOL_DayOfWeek { get { return APJGMOJDPAK ^ FBGGEFFJJHB; } set { APJGMOJDPAK = value ^ FBGGEFFJJHB; } } //0x175CE08 ANBHKALCHDJ 0x175CD24 GDANPNDMDCC
	public int EIHOBHDKCDB_RewardId { get { return FKKHMCINELD ^ FBGGEFFJJHB; } set { FKKHMCINELD = value ^ FBGGEFFJJHB; } } //0x175CE18 EALKEGPNHGK 0x175CD04 LNFEIPOKKNG
	public int EILKGEADKGH { get { return HHPFFPINGAA ^ FBGGEFFJJHB; } set { HHPFFPINGAA = value ^ FBGGEFFJJHB; } } //0x175CE28 NPDDACIHBKD 0x175CD34 BJJMCKHBPNH
	public int LMPPENOILPF { get { return ELFADCBHPCD ^ FBGGEFFJJHB; } set { ELFADCBHPCD = value ^ FBGGEFFJJHB; } } //0x175CE38 JAOMCMFJPDJ 0x175CD7C LINHGODPPMB
	public long KJBGCLPMLCG { get { return IBCNABKLHHH ^ FBGGEFFJJHB; } set { IBCNABKLHHH = value ^ FBGGEFFJJHB; } } //0x175CE48 IDLJOCDJJOC 0x175CD44 ODIEKGPKOAC
	public long GJFPFFBAKGK { get { return MABPKDKBJAG ^ FBGGEFFJJHB; } set { MABPKDKBJAG = value ^ FBGGEFFJJHB; } } //0x175CE60 KPBMCJKFEGN 0x175CD58 IEFCDGKGICA
	public int EKANGPODCEP { get { return EGCMPELNLKP ^ FBGGEFFJJHB; } set { EGCMPELNLKP = value ^ FBGGEFFJJHB; } } //0x175CE78 EBLAFEMDFGD 0x175CD8C AHEFELNFBDM

	//// RVA: 0x175CC78 Offset: 0x175CC78 VA: 0x175CC78
	public void LHPDDGIJKNB(int PPFNGGCBJKC, int KNEFBLHBDBG)
	{
		FBGGEFFJJHB = PPFNGGCBJKC * KNEFBLHBDBG * 11;
		OAPCHMHAJID = false;
		EILKGEADKGH = 0;
		LMPPENOILPF = 0;
		EKANGPODCEP = 0;
		this.PPFNGGCBJKC = PPFNGGCBJKC;
		INDDJNMPONH_Type = 0;
		CHOFDPDFPDC_ConfigValue = 0;
		EIHOBHDKCDB_RewardId = 0;
		HHIBBHFHENH_LinkQuestId = 0;
		AKBHPFBDDOL_DayOfWeek = 0;
		DEPGBBJMFED = 0;
		KJBGCLPMLCG = 0;
		GJFPFFBAKGK = 0;
	}

	//// RVA: 0x175CE88 Offset: 0x175CE88 VA: 0x175CE88
	//public uint CAOGDCBPBAN() { }
}

public class LCKMNLOLDPD
{
	public int FBGGEFFJJHB = 0x340f8ed5; // 0x8
	public int EHOIENNDEDH; // 0xC
	public int AHGCGHAAHOO; // 0x10
	public int HLMAFFLCCKD; // 0x14
	public int IPFBMBMNAGL; // 0x18
	public int OHDDANALELB; // 0x1C

	public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD9A97C DEMEPMAEJOO 0xD9A98C HIGKAIDMOKN
	public int GLCLFMGPMAN_ItemFullId { get { return AHGCGHAAHOO ^ FBGGEFFJJHB; } set { AHGCGHAAHOO = value ^ FBGGEFFJJHB; } } //0xD9A99C LNJAENEGDEL 0xD9A9AC JHIDBGCHOKL
	public int HMFFHLPNMPH_Cnt { get { return HLMAFFLCCKD ^ FBGGEFFJJHB; } set { HLMAFFLCCKD = value ^ FBGGEFFJJHB; } } //0xD9A9BC NJOGDDPICKG 0xD9A9CC NBBGMMBICNA
	public int BGFPPGPJONG_QuestKeyId { get { return IPFBMBMNAGL ^ FBGGEFFJJHB; } set { IPFBMBMNAGL = value ^ FBGGEFFJJHB; } } //0xD9A9DC LBMNPGFFCJN 0xD9A9EC NDNCLLKIJHA
	public int APNMKLJMPMD_Type { get { return OHDDANALELB ^ FBGGEFFJJHB; } set { OHDDANALELB = value ^ FBGGEFFJJHB; } } //0xD9A9FC ICCFOKKODOH 0xD9AA0C CBPDLNBEJAE

	//// RVA: 0xD9AA1C Offset: 0xD9AA1C VA: 0xD9AA1C
	//public uint CAOGDCBPBAN() { }
}
