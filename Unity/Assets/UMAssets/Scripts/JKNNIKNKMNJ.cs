using XeSys;

public class JKNNIKNKMNJ
{
	private int FBGGEFFJJHB; // 0x8
	private long DDPGLABEIEM; // 0x10
	private int PINPIHODOKP; // 0x18
	private int BPADHGOCPIH; // 0x1C
	private long OPDBPKLCEFO; // 0x20
	private long MKMBHBOGFHM; // 0x28
	private long EHCBKLCHFHE; // 0x30
	private int HICKJFPDBEG; // 0x38
	private int EMGIAPOEKLL; // 0x3C
	private long JCGIEJGOEIM; // 0x40
	private long HFMOEKIBNKA; // 0x48
	private int MNJAPFEIOKD; // 0x50
	public const int BFIFOLEKEAF = 5;

	public long DLPEEDCCNMJ_CntSaveTime { get
		{
			if ((EHCBKLCHFHE ^ FBGGEFFJJHB) != DDPGLABEIEM)
				MNJAPFEIOKD |= 1;
			return EHCBKLCHFHE ^ FBGGEFFJJHB;
		}
		set
		{
			DDPGLABEIEM = value;
			EHCBKLCHFHE = value ^ FBGGEFFJJHB;
		} } //0x1472734 IPMOLPGCIIB 0x1472488 POJLMKDPBHI
	public int NEPIPMPAFIE_CntVal { get
		{
			if (PINPIHODOKP != HICKJFPDBEG)
				MNJAPFEIOKD |= 2;
			return FBGGEFFJJHB ^ HICKJFPDBEG;
		}
		set
		{
			PINPIHODOKP = value;
			if (value < 1)
				PINPIHODOKP = 0;
			if (value > GPBGFJONHPB_GetMaxIntimacy())
				PINPIHODOKP = GPBGFJONHPB_GetMaxIntimacy();
			HICKJFPDBEG = PINPIHODOKP ^ FBGGEFFJJHB;
		} } //0x1472770 DNNADJLKBPC 0x14724A8 BJOJAFDBOBL
	public int DCBENCMNOGO_MaxCount { get
		{
			if ((EMGIAPOEKLL ^ FBGGEFFJJHB) != BPADHGOCPIH)
				MNJAPFEIOKD |= 4;
			return EMGIAPOEKLL ^ FBGGEFFJJHB;
		}
		set
		{
			BPADHGOCPIH = value;
			if (value < 1)
				BPADHGOCPIH = 0;
			if (value > GPBGFJONHPB_GetMaxIntimacy())
				BPADHGOCPIH = GPBGFJONHPB_GetMaxIntimacy();
			EMGIAPOEKLL = BPADHGOCPIH ^ FBGGEFFJJHB;
		}
	} //0x1472798 HHBCMCGODFP 0x14724E4 NPANKNNLDOB
	public long FLJGHBLEDDB_UpdateInterval { get
		{
			if ((JCGIEJGOEIM ^ FBGGEFFJJHB) != OPDBPKLCEFO)
				MNJAPFEIOKD |= 8;
			return JCGIEJGOEIM ^ FBGGEFFJJHB;
		}
		set
		{
			OPDBPKLCEFO = value;
			if (value == 0)
				OPDBPKLCEFO = 1;
			JCGIEJGOEIM = OPDBPKLCEFO ^ FBGGEFFJJHB;
		} } //0x14727C0 DEOLPKEGHFP 0x1472520 OCIMIINBMAD
	public long FJDBNGEPKHL_Time { get { 
			long val = FBGGEFFJJHB ^ HFMOEKIBNKA; 
			if((val ^ MKMBHBOGFHM) != 0)
				MNJAPFEIOKD = MNJAPFEIOKD | 0x10;
			return val;
		} set {
			MKMBHBOGFHM = value;
			HFMOEKIBNKA = value ^ FBGGEFFJJHB;
		} 
		} //0x14727FC FIIMIGEKDCM 0x1472568 JFIOOGMDBJD

	// RVA: 0x1472370 Offset: 0x1472370 VA: 0x1472370
	public JKNNIKNKMNJ()
    {
        long time = Utility.GetCurrentUnixTime();
        DDPGLABEIEM = 0;
        FBGGEFFJJHB = (int)time ^ 0x71020923;
        EHCBKLCHFHE = FBGGEFFJJHB;
        PINPIHODOKP = GPBGFJONHPB_GetMaxIntimacy();
        HICKJFPDBEG = PINPIHODOKP ^ FBGGEFFJJHB;
        OPDBPKLCEFO = 60;
        MKMBHBOGFHM = 0;
        BPADHGOCPIH = GPBGFJONHPB_GetMaxIntimacy();
        EMGIAPOEKLL = BPADHGOCPIH ^ FBGGEFFJJHB;
        JCGIEJGOEIM = FBGGEFFJJHB ^ 0x3c;
        HFMOEKIBNKA = FBGGEFFJJHB;
    }

	// // RVA: 0x1472588 Offset: 0x1472588 VA: 0x1472588
	// public void ODDIHGPONFL(JKNNIKNKMNJ GPBJHKLFCEP) { }

	// // RVA: 0x1472838 Offset: 0x1472838 VA: 0x1472838
	public int GPBGFJONHPB_GetMaxIntimacy()
    {
        if(IMMAOANGPNK.HHCJCDFCLOB != null)
        {
            if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
            {
                if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy != null)
                {
                    return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.LPJLEHAJADA_GetValue("intimacy_count_max", 5);
                }
            }
        }
        return 5;
    }

	// // RVA: 0x147292C Offset: 0x147292C VA: 0x147292C
	public int DCLKMNGMIKC(bool LIFPCFFJEOA = false)
	{
		if(!LIFPCFFJEOA)
		{
			if(DCBENCMNOGO_MaxCount <= NEPIPMPAFIE_CntVal)
			{
				return NEPIPMPAFIE_CntVal;
			}
		}
		int diff = DCBENCMNOGO_MaxCount - NEPIPMPAFIE_CntVal;
		long updateDiff = diff * FLJGHBLEDDB_UpdateInterval;
		long diff2 = FJDBNGEPKHL_Time - DLPEEDCCNMJ_CntSaveTime;
		if(updateDiff < diff2)
		{
			diff2 = updateDiff;
		}
		long v = NEPIPMPAFIE_CntVal + diff2 / FLJGHBLEDDB_UpdateInterval; // % or/ ?
		if(v <= DCBENCMNOGO_MaxCount)
		{
			return (int)v;
		}
		return DCBENCMNOGO_MaxCount;
	}

	// // RVA: 0x1472B28 Offset: 0x1472B28 VA: 0x1472B28
	public long CKEJFCLAOHP_GetRemainingTime()
	{
		if (NEPIPMPAFIE_CntVal < DCBENCMNOGO_MaxCount)
		{
			int cntLeft = DCBENCMNOGO_MaxCount - NEPIPMPAFIE_CntVal;
			int stamTime = (int)(cntLeft * FLJGHBLEDDB_UpdateInterval);
			if ((FJDBNGEPKHL_Time - DLPEEDCCNMJ_CntSaveTime) < stamTime)
			{
				long delta = (stamTime - (FJDBNGEPKHL_Time - DLPEEDCCNMJ_CntSaveTime)) % FLJGHBLEDDB_UpdateInterval;
				if (delta != 0)
				{
					return delta;
				}
				return FLJGHBLEDDB_UpdateInterval;
			}
		}
		return 0;
	}

	// // RVA: 0x1472C7C Offset: 0x1472C7C VA: 0x1472C7C
	// public long LEHHIGOOIJJ() { }

	// // RVA: 0x1472DCC Offset: 0x1472DCC VA: 0x1472DCC
	public bool IGFMNMADJPP(int CHIHFGDIBJM, bool DDGFCOPPBBN = true)
	{
		long l1 = DCLKMNGMIKC(false);
		if (CHIHFGDIBJM <= l1 && !DDGFCOPPBBN)
		{
			long r = CKEJFCLAOHP_GetRemainingTime();
			NEPIPMPAFIE_CntVal = (int)l1 - CHIHFGDIBJM;
			DLPEEDCCNMJ_CntSaveTime = FJDBNGEPKHL_Time;
			if(r != 0)
			{
				DLPEEDCCNMJ_CntSaveTime = r - FLJGHBLEDDB_UpdateInterval + FJDBNGEPKHL_Time;
			}
			return true;
		}
		return CHIHFGDIBJM <= l1;
	}

	// // RVA: 0x1472F08 Offset: 0x1472F08 VA: 0x1472F08
	// public bool MAPPOEFALIP(int BBCCIJGFKHD, bool MDNODGAFHJN = True, bool DDGFCOPPBBN = True) { }

	// // RVA: 0x1472FE8 Offset: 0x1472FE8 VA: 0x1472FE8
	// public bool FCEMLLDEJFL(bool MDNODGAFHJN = True, bool DDGFCOPPBBN = True) { }
}
