using FlatBuffers;
using System.Collections.Generic;

public class COGPJCIDIKA
{
	public uint PPFNGGCBJKC { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
	public uint FBFLDFMFFOH { get; set; } // 0xC LMKEDCAPLEE HNLMNIOMOLI CHHJKABBIBL
	public uint JBGEEPFKIGG { get; set; } // 0x10 AHPLCJAKAOP OLOCMINKGON ABAFHIBFKCE
	public uint GBJFNGCDKPM { get; set; } // 0x14 GHLFADHILNN CEJJMKODOGK HOHCEBMMACI
}
public class OOFJBDCPKBJ
{
	public COGPJCIDIKA[] LMNJDPMHNLB { get; set; } // 0x8 KKMMFCHFCME OIJNIAFGIJA NEMCLJHANIO
	public static OOFJBDCPKBJ HEGEKFMJNCC(byte[] NIODCJLINJN)// 0xCB02B0
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		DOLNHKKDNCC res_readData = DOLNHKKDNCC.GetRootAsDOLNHKKDNCC(buffer);
		OOFJBDCPKBJ res_data = new OOFJBDCPKBJ();

		List<COGPJCIDIKA> LMNJDPMHNLB_list = new List<COGPJCIDIKA>();
		for(int LMNJDPMHNLB_idx = 0; LMNJDPMHNLB_idx < res_readData.FPOHCPNHGMNLength; LMNJDPMHNLB_idx++)
		{
			KKJKDONIHBM LMNJDPMHNLB_readData = res_readData.GetFPOHCPNHGMN(LMNJDPMHNLB_idx);
			COGPJCIDIKA LMNJDPMHNLB_data = new COGPJCIDIKA();

			LMNJDPMHNLB_data.PPFNGGCBJKC = LMNJDPMHNLB_readData.BBPHAPFBFHK;
			LMNJDPMHNLB_data.FBFLDFMFFOH = LMNJDPMHNLB_readData.ODBPKGJPLMD;
			LMNJDPMHNLB_data.JBGEEPFKIGG = LMNJDPMHNLB_readData.KJFEBMBHKOC;
			LMNJDPMHNLB_data.GBJFNGCDKPM = LMNJDPMHNLB_readData.LPJPOOHJKAE;
			LMNJDPMHNLB_list.Add(LMNJDPMHNLB_data);
		}
		res_data.LMNJDPMHNLB = LMNJDPMHNLB_list.ToArray();

		return res_data;
	}
}
