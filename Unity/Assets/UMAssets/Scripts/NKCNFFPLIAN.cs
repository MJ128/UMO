using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class NKCNFFPLIAN
{
	private NNJFKLBPBNK_SecureString MLCELGHBCLK_Key = new NNJFKLBPBNK_SecureString(); // 0x8
	private CEBFFLDKAEC_SecureInt PJHFOFGOPDA_Mode = new CEBFFLDKAEC_SecureInt(); // 0xC
	private CEBFFLDKAEC_SecureInt CKDHEFMLDIG_Id = new CEBFFLDKAEC_SecureInt(); // 0x10
	private NNJFKLBPBNK_SecureString FINCFIGKHPA_Name = new NNJFKLBPBNK_SecureString(); // 0x14

	public string LJNAKDMILMC { get { return MLCELGHBCLK_Key.DNJEJEANJGL_Value; } } // LIIHHICIBKM 0x18AEE50
	public int CNDDKMJAIBG { get { return PJHFOFGOPDA_Mode.DNJEJEANJGL_Value; } } // HIGNHAEJKAH 0x18AEE7C
	public int DMJGDDEACMD { get { return CKDHEFMLDIG_Id.DNJEJEANJGL_Value; } } // FPNFJECMBAG 0x18AEEA8
	public string OPFGFINHFCE { get { return FINCFIGKHPA_Name.DNJEJEANJGL_Value; } } // DKJOHDGOIJE 0x18AEED4
 
	// // RVA: 0x18AEF00 Offset: 0x18AEF00 VA: 0x18AEF00
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
    {
        MLCELGHBCLK_Key.DNJEJEANJGL_Value = ((string)OBHAFLMHAKG[AFEHLCGHAEE_Strings.LJNAKDMILMC_key]);
        PJHFOFGOPDA_Mode.DNJEJEANJGL_Value = ((int)OBHAFLMHAKG[AFEHLCGHAEE_Strings.CNDDKMJAIBG_mode]);
        FINCFIGKHPA_Name.DNJEJEANJGL_Value = ((string)OBHAFLMHAKG[AFEHLCGHAEE_Strings.OPFGFINHFCE_name]);
        CKDHEFMLDIG_Id.DNJEJEANJGL_Value = ((int)OBHAFLMHAKG[AFEHLCGHAEE_Strings.DMJGDDEACMD_game_id]);
    }

	// // RVA: 0x18AF150 Offset: 0x18AF150 VA: 0x18AF150
	public static List<NKCNFFPLIAN> PCODDPDFLHK()
    {
        TextAsset text = Resources.Load("cn") as TextAsset;
        byte[] data = text.bytes;
        byte[] data2 = new byte[data.Length];
        byte k = 117;
        for(int i = 0; i < data.Length; i++)
        {
            data2[i] = (byte)(k ^ data[i]);
            k = (byte)((k * 13)%256);
        }
        byte[] data3 = BOBCNJIPPJN.JCBCBNFPJDH(data2);
        EDOHBJAPLPF_JsonData jsondata = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(Encoding.UTF8.GetString(data3));
        List<NKCNFFPLIAN> res = new List<NKCNFFPLIAN>();
        for(int i = 0; i < jsondata.HNBFOAJIIAL_Count; i++)
        {
            NKCNFFPLIAN n = new NKCNFFPLIAN();
            n.KHEKNNFCAOI_Init(jsondata[i]);
            res.Add(n);
        }
        return res;
    }
}
