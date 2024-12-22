using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoLoginBonus : SakashoAPIBase
{
	// RVA: 0x2BCB654 Offset: 0x2BCB654 VA: 0x2BCB654
	public static SakashoAPICallContext GetLoginBonuses(int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoLoginBonusGetLoginBonuses, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BCB840 Offset: 0x2BCB840 VA: 0x2BCB840
	public static SakashoAPICallContext IncrementLoginCount(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoLoginBonusIncrementLoginCount, "", onSuccess, onError));
	}

	//// RVA: 0x2BCB924 Offset: 0x2BCB924 VA: 0x2BCB924
	public static SakashoAPICallContext GetLoginBonusStatuses(int[] ids, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if(ids != null)
		{
			l = new ArrayList();
			for(int i = 0; i < ids.Length; i++)
			{
				l.Add(ids[i]);
			}
		}
		h["ids"] = l;
		return new SakashoAPICallContext(Call(SakashoLoginBonusGetLoginBonusStatuses, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BCBB60 Offset: 0x2BCBB60 VA: 0x2BCBB60
	public static SakashoAPICallContext IncrementLoginCount(int[] ids, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if(ids != null)
		{
			l = new ArrayList();
			for(int i = 0; i < ids.Length; i++)
				l.Add(ids[i]);
		}
		h["ids"] = l;
		return new SakashoAPICallContext(Call(SakashoLoginBonusIncrementLoginCountIntArray, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BCBD9C Offset: 0x2BCBD9C VA: 0x2BCBD9C
	public static SakashoAPICallContext GetLoginBonusRecord(int id, bool allPrizes, int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["id"] = id;
		h["allPrizes"] = allPrizes;
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoLoginBonusGetLoginBonusRecord, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BCC040 Offset: 0x2BCC040 VA: 0x2BCC040
	//private static extern int SakashoLoginBonusGetLoginBonuses(int callbackId, string json) { }
	private static int SakashoLoginBonusGetLoginBonuses(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoLoginBonusGetLoginBonuses(callbackId, json);
	}

	//// RVA: 0x2BCC150 Offset: 0x2BCC150 VA: 0x2BCC150
	private static int SakashoLoginBonusIncrementLoginCount(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoLoginBonusIncrementLoginCount(callbackId, json);
	}

	//// RVA: 0x2BCC268 Offset: 0x2BCC268 VA: 0x2BCC268
	private static int SakashoLoginBonusGetLoginBonusStatuses(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoLoginBonusGetLoginBonusStatuses(callbackId, json);
	}

	//// RVA: 0x2BCC380 Offset: 0x2BCC380 VA: 0x2BCC380
	private static int SakashoLoginBonusIncrementLoginCountIntArray(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoLoginBonusIncrementLoginCountIntArray(callbackId, json);
	}

	//// RVA: 0x2BCC4A0 Offset: 0x2BCC4A0 VA: 0x2BCC4A0
	private static int SakashoLoginBonusGetLoginBonusRecord(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoLoginBonusGetLoginBonusRecord(callbackId, json);
	}
}
