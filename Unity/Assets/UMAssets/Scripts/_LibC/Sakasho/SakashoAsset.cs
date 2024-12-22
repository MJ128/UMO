using System.Collections;
using System.IO;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static int SakashoAssetGetAssetList(int callbackId, string json)
        {
            string message = "{}";
            if(json.Contains("db"))
            {
                // Hack directly send response
                message =
@"{
    ""SAKASHO_CURRENT_ASSET_REVISION"":""20220622141305"",
    ""SAKASHO_CURRENT_DATE_TIME"":" + Utility.GetCurrentUnixTime()+ @",
    ""SAKASHO_CURRENT_MASTER_REVISION"":5,
    ""base_url"": ""[SERVER_DATA_PATH]"",
    ""files"": [
        {
            ""file"": ""/db/ar_event!sa4130fcbz!.dat"",
            ""hash_value"": ""f4cbac7f656217558e1208903d941e9e"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/ar_marker!s3e75269bz!.dat"",
            ""hash_value"": ""75daca6651a05fb211c24803e260467c"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20170701-000000_v00000001_s1_h00000000!see11e970z!.dat"",
            ""hash_value"": ""a35f3e2d8e353e8c94a2ca2e49b3f4dd"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20170701-000000_v01000000_s0_h00000000!sbe7e64cfz!.dat"",
            ""hash_value"": ""b3e1ab3865f4b6fb283902318a6c6c13"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220529-000000_v00007630_s1_h00000000!s09a5539bz!.dat"",
            ""hash_value"": ""a955545abe377a6c3d0348e34a87b137"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220601-000000_v00007635_s1_h00000000!s710a70fdz!.dat"",
            ""hash_value"": ""58dd2bc3632eda638cc35542b5016166"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220601-110000_v00007637_s1_h00000000!s618d84f5z!.dat"",
            ""hash_value"": ""8ee42a2d845c97096f282019a094c40d"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220601-120000_v00007640_s1_h00000000!s1c1bb0acz!.dat"",
            ""hash_value"": ""4a42a623a53eda2666b468c42c62fbc7"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220605-000000_v00007650_s1_h00000000!sfb50aedaz!.dat"",
            ""hash_value"": ""2cde5aa897b221cc93e6a9c5fcc36d25"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220606-000000_v00007660_s1_h00000000!se15da7baz!.dat"",
            ""hash_value"": ""476b50fad1e57bc881077c6cb631d17d"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220607-000000_v00007670_s1_h00000000!s94a79346z!.dat"",
            ""hash_value"": ""f7951330a3f83b967b30036cad6c9c41"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220608-120000_v00007690_s1_h00000000!s0770fff0z!.dat"",
            ""hash_value"": ""32a49f8e738c5715f176a98d042b788b"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220611-000000_v00007700_s1_h00000000!sa05467cdz!.dat"",
            ""hash_value"": ""30f2b71d8efab10aa1b23988f96a1cbe"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220615-120000_v00007720_s1_h00000000!s89aade2az!.dat"",
            ""hash_value"": ""82a87c92562b54763d8277c0b4f20045"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220616-000000_v00007730_s1_h00000000!s99522649z!.dat"",
            ""hash_value"": ""7d40139a8e972a2f0b7ea5cb404cae2c"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220617-000000_v00007740_s1_h00000000!se2dc19afz!.dat"",
            ""hash_value"": ""34595d1b4bdbe088658414924ec14b97"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220618-120000_v00007750_s1_h00000000!s194f08f0z!.dat"",
            ""hash_value"": ""fecff12754bf5c2a1dc4b5d840eb5523"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220621-120000_v00007760_s1_h00000000!sdd9835c1z!.dat"",
            ""hash_value"": ""92797952fb3c68e0f3d3ae192967e103"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220623-000000_v00007770_s1_h00000000!s6f563c05z!.dat"",
            ""hash_value"": ""18ed372ae38dc04a44a580b831a53f3c"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220624-210000_v00007780_s1_h00000000!sb8f86186z!.dat"",
            ""hash_value"": ""fbce9837f4bad70da495b3bab2e0d264"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/md-20220626-000000_v00007790_s1_h00000000!s602bc890z!.dat"",
            ""hash_value"": ""ee562528c63b399f9cfe1988cb83f6ce"",
            ""last_updated_at"": 1655815884
        },
        {
            ""file"": ""/db/sd!s6b10b98cz!.dat"",
            ""hash_value"": ""d3bdafa5033c02ec5158359aefb64185"",
            ""last_updated_at"": 1655191263
        }
    ]
}";
            }
            else if(json.Contains("android"))
            {
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM// && !UNITY_EDITOR
                if(File.Exists(Application.persistentDataPath+"/data/RequestGetFiles.json"))
                {
                    message = System.Text.Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(Application.persistentDataPath+"/data/RequestGetFiles.json"));
                }
                else
                {
                    GameManager.Instance.StartCoroutineWatched(DownloadRequestGetFiles(callbackId, json));
                    return 0;
                }
#else
                message = System.Text.Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(UnityEngine.Application.dataPath+"/../../Data/RequestGetFiles.json"));
#endif
				message = message.Replace("https://assets-sakasho.cdn-dena.com/1246/20220502151005", "[SERVER_DATA_PATH]");
                message = message.Replace("https://assets-sakasho.cdn-dena.com/1246/20220622141305", "[SERVER_DATA_PATH]");
                message = message.Replace("[[DATE]]", ""+Utility.GetCurrentUnixTime());
			}
            else
            {
                TodoLogger.LogError(TodoLogger.SakashoServer, "SakashoAssetGetAssetList "+json);
            }
			SendMessage(callbackId, message);
            // end hack

            return 0;
        }
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
        public static IEnumerator DownloadRequestGetFiles(int callbackId, string json)
        {
            bool retry = false;
            yield return Co.R(FileSystemProxy.WaitServerInfo("Missing "+Application.persistentDataPath+"/data/RequestGetFiles.json"+ ".", true, true, (PopupButton.ButtonLabel btn) =>
            {
                if(btn == PopupButton.ButtonLabel.Retry)
                    retry = true;
            }));
            if(!retry)
            {
                WWW req = new WWW("http://"+FileSystemProxy.foundServer+":8000/RequestGetFiles.json");
                while(!req.isDone)
                    yield return null;
                if(req.error == null)
                {
                    if(!Directory.Exists(Application.persistentDataPath+"/data/"))
                        Directory.CreateDirectory(Application.persistentDataPath+"/data/");
                    File.WriteAllBytes(Application.persistentDataPath+"/data/RequestGetFiles.json", req.bytes);
                    yield return Co.R(FileSystemProxy.ReloadFileList());
                }
                else
                {
                    UnityEngine.Debug.LogError("Error downloading json : "+req.error);
                    /*EDOHBJAPLPF_JsonData res = GetBaseMessage();
                    res["error_code"] = "NETWORK_ERROR";
                    res["error_detail"] = null;
                    SendMessage(callbackId, res);*/
                }
            }
            SakashoAssetGetAssetList(callbackId, json);
        }
#endif
    }
}
