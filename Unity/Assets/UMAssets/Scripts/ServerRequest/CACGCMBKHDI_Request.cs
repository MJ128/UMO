using XeApp.Core.WorkerThread;
using UnityEngine;
using System.Collections;
using XeApp.Game;

public delegate bool MMACCEADALH(SakashoErrorId PPFNGGCBJKC_Id);


public class IDNNDIHDLGA
{
	public string KLMPFGOCBHC; // 0x8
}

[System.Obsolete("Use CACGCMBKHDI_Request", true)]
public abstract class CACGCMBKHDI {}
public abstract class CACGCMBKHDI_Request
{
    public delegate void HDHIKGLMOGF(CACGCMBKHDI_Request ADKIDBJCAJA);

    public long CKOOCBJGHBI_RequestId; // 0x8
    public int CFICLNJACCD_NumRetry = 3; // 0x10
    public float GJAEJFLLKGC_RetryTime = 3.0f; // 0x14
    public float ICDEFIIADDO_Timeout = 120.0f; // 0x18
    protected string ECGDADGLAMM; // 0x28
    public MMACCEADALH NBFDEFGFLPJ; // 0x50
    public bool DLKLLHPLANH; // 0x54
    private bool GIAJMLDDPKF; // 0x55
    public bool EOPCHGLLONF; // 0x70
    public bool AILPHBMCCGP; // 0x71
    public static bool NLKPHFGBJHM; // 0x0
    public bool CMMCGNLPHLE; // 0x72
    public bool ALJHFFCKBDP; // 0x73
    private bool NAEDHHPPFCK_IsDone; // 0x74
    public bool KAEMPHIPDFN; // 0x75

    public HDHIKGLMOGF BHFHGFKBOHH_OnSuccess { get; set; } // 0x1C FJNKDKOKOMD MEOFOFHFBFD FAKPBHKKNOK
    public HDHIKGLMOGF MOBEEPPKFLG_OnFail { get; set; } // 0x20 HELECPOBDIL LLHGEKKIFIJ AHNDFJKKLDJ
    public WorkerThreadQueue BNJPAKLNOPA_WorkerThreadQueue { get; set; } // 0x24 EGCCKJEDANG IMDNDFIKMHN ODBGIMFJOHN
    public SakashoError ANMFDAGDMDE_Error { get; set; } // 0x2C GHCMEMELCJF ILGAFKNEAJI DPCCCKAKHDB
    public SakashoErrorId CJMFJOMECKI_ErrorId { get; set; } // 0x30 BCCAMPBOJHK LBJPGPOJOKP GPEILELFPCD
    public bool NPNNPNAIONN_IsError { get; set; } // 0x34 GMEODAHJILH IAGEPLEBOKJ DDHAFEDMPEH
    public bool JONHGMCILHM { get; set; } // 0x35 CEMOPAGHPJM JPIBKPPPIDG BMAPGPMEFKC
    public bool LEBKCAEHLPC { get; set; } // 0x36 DMGEAJAAHAO FHBJIBDPBLI ODMPKGGKPAN
    public bool PDAPLCPOCMA { get; set; } // 0x37 MIEDINFMHKL EBANJNNPMCM GNKHADMLLGA
    public bool EFGFPCBGDDK { get; set; } // 0x38 FMBCHNLOAHF  // EEEPONHOKCJ // EHJOEBHMHLB
    public string NGCAIEGPLKD_result { get; set; }  // 0x3C // JCIJAABGKKM; // ALHHGGDPGEH // GLHKPBHJAPP

    public OBOKMHHMOIL_ServerInfo HOHOBEOJPBK_ServerInfo { get; set; }  // 0x40 // POMCKJFOMGJ // PEMKJFHLBIA // FINMAPHMLHA
    public IDNNDIHDLGA HIBMKLEJEDP { get; set; } // 0x44 DFEGGDEPMMB PLKKKJIEJNE IPHOHNBDMOE
    public string GEKKKPIIOAF { get; set; } // 0x48 AOCPFCELECC EFJKDEPPKJL EOIEFLFHAFI
    public string JNDJDDBAIAJ { get; set; } // 0x4C APGMLBJEHPH NHPMIODGLEJ NJGFHKKAKEM
    // public virtual bool DCLHBCFKIJI { get; set; } IHGGDFHAGGM 0x18F2320 AHLIMCFMAHO 0x18F2328 
    public double KINJOEIAHFK_StartTime { get; set; } // 0x58 BLHFJCJNIGC CMNMHDELKND IOPPCLACPOF
    public double DMOBOIOFPCM_EndTime { get; set; } // 0x60 GJKEKJMCFLB IBBPAJGOFFA FNIKLDHAPEG
    public double LHGPAJGIAME_ResultTime { get; set; }  // 0x68 FOFFKBHGEPC OJCLNCIEHLL BPAIAMDPKBJ
    // public double MOCNPGKAPKE { get; } // FLDLAOCPFCP 0x18F23E0
    public virtual bool OIDCBBGLPHL { get { return false; } } // GINMIBJOABO 0x18F256C
    public virtual bool ICFMKEFJOIE { get { return false; } } // HOPDAAAEBBG 0x18F2574 
    public virtual bool BNCFONNOHFO { get { return false; } } // NPLNAJFJPEE 0x18F257C
    public bool PLOOEECNHFB_IsDone { get { return NAEDHHPPFCK_IsDone; } set { NAEDHHPPFCK_IsDone = value; } } // JFOKBBLFMLD 0x18F2584 EDBGNGILAKA 0x18F258C
    public SakashoAPICallContext EBGACDGNCAA_CallContext { get; set; }  // 0x78 NKPCDAJOMEO EEMOCCMAONH IGIDINIFHDJ
    public virtual bool EBPLLJGPFDA_HasResult { get { return true; } } // HGPAELCGELL 0x18F2BD8

    // // RVA: 0x18F2330 Offset: 0x18F2330 VA: 0x18F2330 Slot: 6
    // public virtual string NFODPNFPDGD() { }

    // // RVA: 0x18F240C Offset: 0x18F240C VA: 0x18F240C
    public void BOPHNJFGJBN()
    {
        if(!ALJHFFCKBDP)
            return;
        GameManager.Instance.InputEnabled = true;
    }

    // // RVA: 0x18F24BC Offset: 0x18F24BC VA: 0x18F24BC
    public void EHLFONGENNK()
    {
        if(!ALJHFFCKBDP)
            return;
        GameManager.Instance.InputEnabled = false;
    }

    // // RVA: 0x18F25A4 Offset: 0x18F25A4 VA: 0x18F25A4
    public void OGPFKGAKOFD()
    {
        EFGFPCBGDDK = false;
        ANMFDAGDMDE_Error = null;
        NGCAIEGPLKD_result = null;
        HOHOBEOJPBK_ServerInfo = null;
        HIBMKLEJEDP = null;
        EBGACDGNCAA_CallContext = null;
        DHLDNIEELHO();
    }

    // [ConditionalAttribute] // RVA: 0x6C3D70 Offset: 0x6C3D70 VA: 0x6C3D70
    // // RVA: 0x18F25D0 Offset: 0x18F25D0 VA: 0x18F25D0
    // public void FGNOINLMJLN(string INDDJNMPONH, string HEKJBOPBDIA) { }

    // // RVA: 0x18F272C Offset: 0x18F272C VA: 0x18F272C Slot: 10
    // public virtual bool CPIIKMBBKAI() { }

    // // RVA: 0x18F2734 Offset: 0x18F2734 VA: 0x18F2734 Slot: 11
    // public virtual void CBEPCFJOJOI() { }

    // // RVA: 0x18F2738 Offset: 0x18F2738 VA: 0x18F2738 Slot: 12
    public virtual void DHLDNIEELHO()
    {
        return;
    }

    // // RVA: 0x18F273C Offset: 0x18F273C VA: 0x18F273C
    public void MEOCKCJBDAD(SakashoError DOGDHKIEBJA)
    {
		EFGFPCBGDDK = true;
		ANMFDAGDMDE_Error = DOGDHKIEBJA;
		if(DOGDHKIEBJA.ErrorDetailJSON != null)
		{
			if(DOGDHKIEBJA.getErrorId() == SakashoErrorId.OLDER_REQUIREMENT_CLIENT_VERSION)
			{
				EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(DOGDHKIEBJA.ErrorDetailJSON);
                if(!data.BBAJPINMOEP_Contains("extra"))
                {
                    GEKKKPIIOAF = null;
                    return;
                }
                GEKKKPIIOAF = (string)data["extra"];
			}
			else if(DOGDHKIEBJA.getErrorId() == SakashoErrorId.SIGN_IN_WITH_APPLE_UNAVAILABLE)
			{
				EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(DOGDHKIEBJA.ErrorDetailJSON);
                if(!data.BBAJPINMOEP_Contains("message"))
                {
                    return;
                }
                JNDJDDBAIAJ = (string)data["message"];
			}
			else if (DOGDHKIEBJA.getErrorId() == SakashoErrorId.APPLICATION_UNDER_MAINTENANCE)
			{
				EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(DOGDHKIEBJA.ErrorDetailJSON);
                HIBMKLEJEDP = new IDNNDIHDLGA();
                HIBMKLEJEDP.KLMPFGOCBHC = CEDHHAGBIBA.KJFAGPBALNO((string)data["description"]);
			}
		}
	}

    // // RVA: 0x18F2B34 Offset: 0x18F2B34 VA: 0x18F2B34
    public void DCKLDDCAJAP(string IDLHJIOMJBK_result)
    {
        HOHOBEOJPBK_ServerInfo = new OBOKMHHMOIL_ServerInfo();
        HOHOBEOJPBK_ServerInfo.KHEKNNFCAOI_Init(IDLHJIOMJBK_result);
        EFGFPCBGDDK = true;
        NGCAIEGPLKD_result = IDLHJIOMJBK_result;
    }

    // // RVA: 0x18F2BD4 Offset: 0x18F2BD4 VA: 0x18F2BD4 Slot: 13
    public virtual void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        return;
    }

    // // RVA: 0x18F2BE0 Offset: 0x18F2BE0 VA: 0x18F2BE0 Slot: 15
    public virtual void NLDKLFODOJJ()
    {
        return;
    }

    // // RVA: 0x18F2BE4 Offset: 0x18F2BE4 VA: 0x18F2BE4
    public YieldInstruction GDPDELLNOBO_WaitDone(MonoBehaviour DANMJLOBLIE)
    {
        return DANMJLOBLIE.StartCoroutineWatched(HOHLIBIOPOM_CheckDone());
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C3DB0 Offset: 0x6C3DB0 VA: 0x6C3DB0
    // // RVA: 0x18F2C1C Offset: 0x18F2C1C VA: 0x18F2C1C
    private IEnumerator HOHLIBIOPOM_CheckDone()
    {
        //0x18F2D34
        while(!NAEDHHPPFCK_IsDone)
        {
            yield return null;
        }
    }

    // // RVA: 0x18F2CC8 Offset: 0x18F2CC8 VA: 0x18F2CC8 Slot: 16
    // public virtual string GHAIKECGKKO() { }

}

