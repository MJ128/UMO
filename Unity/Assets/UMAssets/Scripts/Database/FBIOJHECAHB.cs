
using System.Collections.Generic;

[System.Obsolete("Use FBIOJHECAHB_EventStory", true)]
public class FBIOJHECAHB { }
public class FBIOJHECAHB_EventStory : DIHHCBACKGG_DbSection
{
	public class GIEHECAKIFC
	{
		public int PPFNGGCBJKC; // 0x8
		public int PPEGAKEIEGM; // 0xC
		public int OAFJONPIFGM_EventId; // 0x10
		public byte MGBDCFIKBPM; // 0x14
		public long PDBPFJJCADD; // 0x18
		public long FDBNFFNFOND; // 0x20
	}

	public class ENDMMNNOAIL
	{
		public int PPFNGGCBJKC; // 0x8
		public int PPEGAKEIEGM; // 0xC
		public int OAFJONPIFGM_EventId; // 0x10
		public NMIGMCJHAIE JDJNNJEJDAJ; // 0x14
		public int LOHMKCPKBON_AdvId; // 0x18
		public int CHOFDPDFPDC; // 0x1C
		public int PFGAKEDKOPD_UnlockSpCost; // 0x20
	}

	public class CHCCGPMJFEL
	{
		public int PPFNGGCBJKC; // 0x8
		public int PPEGAKEIEGM; // 0xC
		public int BCCHOBPJJKE; // 0x10
		public int BPNKGDGBBFG; // 0x14
	}

	public enum NMIGMCJHAIE
	{
		JFEDIMKFDNH_Prologue = 1,
		GBECNPANBEA_2_Sns = 2,
		OEDCONLFLHD_Epilogue = 3,
		DCDEBCIMEMM_Opening = 4,
		MOPAEGFEGCB_5_EpisodeStory = 5,
	}

	public enum CHMHPDHPDCD
	{
		FCPAKJFNKPG = 0,
		MOKIALDCAGP = 1,
		JJCGGAFJLGM = 2,
		FDBFJFDIKPE = 3,
		GCLFEJGEIPL = 4,
		MKNOPGIJNID = 5,
	}

	public List<GIEHECAKIFC> ILEJEJKNOBN = new List<GIEHECAKIFC>(); // 0x20
	public List<ENDMMNNOAIL> JPIGOBGOMON = new List<ENDMMNNOAIL>(); // 0x24

	// RVA: 0xFC6448 Offset: 0xFC6448 VA: 0xFC6448
	public FBIOJHECAHB_EventStory()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 43;
	}

	// RVA: 0xFC6570 Offset: 0xFC6570 VA: 0xFC6570 Slot: 8
	protected override void KMBPACJNEOF()
	{
		ILEJEJKNOBN.Clear();
		JPIGOBGOMON.Clear();
	}

	// RVA: 0xFC6614 Offset: 0xFC6614 VA: 0xFC6614 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		BLOHGJIKLAK parser = BLOHGJIKLAK.HEGEKFMJNCC(DBBGALAPFGC);
		ILEJEJKNOBN.Clear();
		JPIGOBGOMON.Clear();
		{
			BCCFAPDAFOE[] array = parser.MLJNCEIFECL;
			for(int i = 0; i < array.Length; i++)
			{
				GIEHECAKIFC data = new GIEHECAKIFC();
				data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
				data.PPEGAKEIEGM = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
				data.OAFJONPIFGM_EventId = array[i].BCKCEEMNKCH;
				data.MGBDCFIKBPM = (byte)array[i].BDJMFDKLHPM;
				data.PDBPFJJCADD = array[i].PDBPFJJCADD;
				data.FDBNFFNFOND = array[i].FDBNFFNFOND;
				ILEJEJKNOBN.Add(data);
			}
		}
		{
			MCCFOKHKJIC[] array = parser.FGAOKKECNIH;
			for(int i = 0; i < array.Length; i++)
			{
				ENDMMNNOAIL data = new ENDMMNNOAIL();
				data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
				data.PPEGAKEIEGM = array[i].PLALNIIBLOF;
				data.OAFJONPIFGM_EventId = array[i].BCKCEEMNKCH;
				data.JDJNNJEJDAJ = (NMIGMCJHAIE)array[i].PIDAAPMCAML;
				data.LOHMKCPKBON_AdvId = array[i].OIAAFFHGBBD;
				data.CHOFDPDFPDC = array[i].ODNOJKHHEOP;
				data.PFGAKEDKOPD_UnlockSpCost = array[i].DFMOIKJOCGH;
				JPIGOBGOMON.Add(data);
			}
		}
		return true;
	}

	// RVA: 0xFC6B30 Offset: 0xFC6B30 VA: 0xFC6B30 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	// RVA: 0xFC6B38 Offset: 0xFC6B38 VA: 0xFC6B38 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "FBIOJHECAHB_EventStory.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0xFC7070 Offset: 0xFC7070 VA: 0xFC7070
	public ENDMMNNOAIL GIBIMCOLLNN(int AIPLIEMLHGC)
	{
		ENDMMNNOAIL e = JPIGOBGOMON.Find((ENDMMNNOAIL GHPLINIACBB) =>
		{
			//0xFC7200
			if(GHPLINIACBB.PPEGAKEIEGM == 2 && GHPLINIACBB.JDJNNJEJDAJ == NMIGMCJHAIE.GBECNPANBEA_2_Sns)
				return GHPLINIACBB.LOHMKCPKBON_AdvId == AIPLIEMLHGC;
			return false;
		});
		if(e != null)
		{
			if(ILEJEJKNOBN.Find((GIEHECAKIFC GHPLINIACBB) =>
			{
				//0xFC7254
				if(GHPLINIACBB.PPEGAKEIEGM != 2)
					return false;
				return GHPLINIACBB.OAFJONPIFGM_EventId == e.OAFJONPIFGM_EventId;
			}) != null)
			{
				return e;
			}
		}
		return null;
	}
}
