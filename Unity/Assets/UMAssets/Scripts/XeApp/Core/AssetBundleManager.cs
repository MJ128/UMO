using XeSys;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace XeApp.Core
{
	public class AssetBundleManager : SingletonBehaviour<AssetBundleManager>
	{
		private static AssetBundleManifest m_AssetBundleManifest = null; // 0x0
		private static Dictionary<string, LoadedAssetBundle> m_LoadedAssetBundles = new Dictionary<string, LoadedAssetBundle>(); // 0x4
		private static Dictionary<string, int> m_lodingAssetBundle = new Dictionary<string, int>(); // 0x8
		private static Dictionary<string, string> m_lodingErrors = new Dictionary<string, string>(); // 0xC
		private static List<AssetBundleLoadOperation> m_InProgressOperations = new List<AssetBundleLoadOperation>(); // 0x10
		private static Dictionary<string, string[]> m_Dependencies = new Dictionary<string, string[]>(); // 0x14
		public static bool isTutorialNow; // 0x18
		public static Dictionary<string, int> m_tutorialAssetMap = new Dictionary<string, int>(); // 0x1C

		public static string BaseAssetBundleInstallPath { get; set; } // 0x20
		public static string StreamingAssetBundlePath { get; set; } // 0x24

		// // RVA: 0xE12174 Offset: 0xE12174 VA: 0xE12174
		public static string GetPlatformName()
		{
			RuntimePlatform platform = Application.platform;
			if(platform == RuntimePlatform.Android)
				return "android";
			else if(platform == RuntimePlatform.IPhonePlayer)
				return "ios";
			//return "unknown";
			return "android"; // Hack for editor play
		}

		// // RVA: 0xE121F4 Offset: 0xE121F4 VA: 0xE121F4
		protected static bool LoadAssetBundleInternal(string assetBundleName)
		{
			LoadedAssetBundle loadedBundle = null;
			if(m_LoadedAssetBundles.TryGetValue(assetBundleName, out loadedBundle))
			{
				TodoLogger.Log(TodoLogger.AssetBundle, "LoadAssetBundle using already loaded AB " + assetBundleName);
				loadedBundle.m_ReferencedCount++;
				return true;
			}
			else
			{
				int loadingCount = -1;
				string path = null;
				if(m_lodingAssetBundle.TryGetValue(assetBundleName, out loadingCount))
				{
					m_lodingAssetBundle[assetBundleName] = ++loadingCount;
					TodoLogger.Log(TodoLogger.AssetBundle, "LoadAssetBundle using currently loading AB " + assetBundleName+" count is "+m_lodingAssetBundle[assetBundleName]);
					return true;
				}
				else
				{
					m_lodingErrors.Remove(assetBundleName);
					if(m_tutorialAssetMap.ContainsKey(assetBundleName))
					{
						path = Path.Combine(StreamingAssetBundlePath, assetBundleName);
					}
				}
				if(string.IsNullOrEmpty(path))
				{
					path = Path.Combine(BaseAssetBundleInstallPath, assetBundleName);
				}
				TodoLogger.Log(TodoLogger.AssetBundle, "LoadAssetBundle " + assetBundleName);
				FileLoader.Instance.Request(path, assetBundleName, 
					(FileResultObject fo) => {
						//0x1D6AC7C
						TodoLogger.Log(TodoLogger.AssetBundle, "LoadAssetBundle loaded " + assetBundleName);
						fo.dispose = true;
						AssetBundle bundle = fo.assetBundle;
						if(bundle != null)
						{ 
#if UNITY_EDITOR || UNITY_STANDALONE
							BundleShaderInfo.Instance.RegisterShaderIds(bundle, () => {
#endif
								LoadedAssetBundle res = new LoadedAssetBundle(bundle);
								m_LoadedAssetBundles.Add(assetBundleName, res);
								if(m_lodingAssetBundle.TryGetValue(assetBundleName, out loadingCount))
								{
									res.m_ReferencedCount += loadingCount;
								}
								TodoLogger.Log(TodoLogger.AssetBundle, "LoadAssetBundle shader done " + assetBundleName+" count is "+m_LoadedAssetBundles[assetBundleName].m_ReferencedCount);
								m_lodingAssetBundle.Remove(assetBundleName);

#if UNITY_EDITOR || UNITY_STANDALONE
							});
#endif
						}
						else
						{
							m_lodingErrors[assetBundleName] = "Load Assetbundle Failed:" + assetBundleName;
							m_lodingAssetBundle.Remove(assetBundleName);
						}
						return true;
					}, 
					(FileResultObject fo) => {
						//0x1D6AEDC
						TodoLogger.LogError(TodoLogger.AssetBundle, "Load Assetbundle Failed:"+assetBundleName);
						m_lodingErrors[assetBundleName] = "Load Assetbundle Failed:"+assetBundleName;
						m_lodingAssetBundle.Remove(assetBundleName);
						fo.dispose = true;
						return true;
					}, null, 0, true);

				FileLoader.Instance.Load();
				m_lodingAssetBundle.Add(assetBundleName, 0);
				TodoLogger.Log(TodoLogger.AssetBundle, "LoadAssetBundle added in m_lodingAssetBundle " + assetBundleName);
				return false;
			}
		}

		// [ConditionalAttribute] // RVA: 0x747C20 Offset: 0x747C20 VA: 0x747C20
		// // RVA: 0xE127E8 Offset: 0xE127E8 VA: 0xE127E8
		// protected static void LoadDependencies(string assetBundleName) { }

		// // RVA: 0xE12A28 Offset: 0xE12A28 VA: 0xE12A28
		protected static void LoadAssetBundle(string assetBundleName, bool isLoadingAssetBundleManifest = false)
		{
			LoadAssetBundleInternal(assetBundleName);
		}

		// // RVA: 0xE12AA8 Offset: 0xE12AA8 VA: 0xE12AA8
		public static AssetBundleLoadAssetOperation LoadAssetAsync(string assetBundleName, string assetName, Type type)
		{
			LoadAssetBundle(assetBundleName, false);
			AssetBundleLoadAssetOperationFull operation = new AssetBundleLoadAssetOperationFull(assetBundleName, assetName, type);
			m_InProgressOperations.Add(operation);
			return operation;
		}

		// // RVA: 0xE12BA8 Offset: 0xE12BA8 VA: 0xE12BA8
		public static UnionAssetBundleLoadOperation LoadUnionAssetBundle(string assetBundleName)
		{
			LoadAssetBundle(assetBundleName, false);
			UnionAssetBundleLoadOperation operation = new UnionAssetBundleLoadOperation(assetBundleName);
			m_InProgressOperations.Add(operation);
			return operation;
		}

		// // RVA: 0xE12C98 Offset: 0xE12C98 VA: 0xE12C98
		public static ShaderAssetBundleLoadOperation LoadShaderAssetBundle(string assetBundleName)
		{
			LoadAssetBundle(assetBundleName, false);
			ShaderAssetBundleLoadOperation operation = new ShaderAssetBundleLoadOperation(assetBundleName);
			m_InProgressOperations.Add(operation);
			return operation;
		}

		// // RVA: 0xE12D88 Offset: 0xE12D88 VA: 0xE12D88
		public static AssetBundleLoadAllAssetOperationBase LoadAllAssetAsync(string assetBundleName)
		{
			LoadAssetBundle(assetBundleName, false);
			AssetBundleLoadAllAssetOperation operation = new AssetBundleLoadAllAssetOperation(assetBundleName);
			m_InProgressOperations.Add(operation);
			return operation;
		}

		// // RVA: 0xE12E78 Offset: 0xE12E78 VA: 0xE12E78
		public static AssetBundleLoadLayoutOperationBase LoadLayoutAsync(string assetBundleName, string prefabName)
		{
			LoadAssetBundle(assetBundleName, false);
			AssetBundleLoadLayoutOperationBase operation = new AssetBundleLoadLayoutOperation(assetBundleName, prefabName);
			m_InProgressOperations.Add(operation);
			return operation;
		}

		// // RVA: 0xE12F6C Offset: 0xE12F6C VA: 0xE12F6C
		public static AssetBundleLoadUGUIOperationBase LoadUGUIAsync(string assetBundleName, string prefabName)
		{
			LoadAssetBundle(assetBundleName, false);
			AssetBundleLoadUGUIOperation operation = new AssetBundleLoadUGUIOperation(assetBundleName, prefabName);
			m_InProgressOperations.Add(operation);
			return operation;
		}

		// // RVA: 0xE0F2E0 Offset: 0xE0F2E0 VA: 0xE0F2E0
		public static LoadedAssetBundle GetLoadedAssetBundle(string assetBundleName, out string error)
		{
			if(!m_lodingErrors.TryGetValue(assetBundleName, out error))
			{
				LoadedAssetBundle bundle = null;
				m_LoadedAssetBundles.TryGetValue(assetBundleName, out bundle);
				if(bundle != null)
				{
					string[] deps = null;
					m_Dependencies.TryGetValue(assetBundleName, out deps);
					if(deps == null)
						return bundle;
					for(int i = 0; i < deps.Length; i++)
					{
						if(m_lodingErrors.TryGetValue(deps[i], out error))
							return bundle;
						LoadedAssetBundle depBundle = null;
						m_LoadedAssetBundles.TryGetValue(deps[i], out depBundle);
						if(depBundle == null)
							return null;
					}
					return bundle;
				}
			}
			return null;
		}

		// // RVA: 0xE13060 Offset: 0xE13060 VA: 0xE13060
		// public static string MakeAssetBundlePath(string assetBundleName) { }

		// // RVA: 0xE130F4 Offset: 0xE130F4 VA: 0xE130F4
		public static AssetBundleLoadAllAssetOperationBase LoadDecorationItemAssetAsync(string assetBundleName)
		{
			LoadAssetBundle(assetBundleName, false);
			AssetBundleLoadAllAssetOperation op = new AssetBundleLoadAllAssetOperation(assetBundleName);
			m_InProgressOperations.Add(op);
			return op;
		}

		// // RVA: 0xE131E4 Offset: 0xE131E4 VA: 0xE131E4
		public static void UnloadAssetBundle(string assetBundleName, bool unloadAllLoadedObject = false)
		{
			UnloadAssetBundleInternal(assetBundleName, unloadAllLoadedObject);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x747C54 Offset: 0x747C54 VA: 0x747C54
		// // RVA: 0xE133B0 Offset: 0xE133B0 VA: 0xE133B0
		public static IEnumerator UnloadAllAssetBundle()
		{
			//0x1D6B054
			while (m_InProgressOperations.Count > 0)
				yield return null;
			m_lodingErrors.Clear();
			foreach(var k in m_LoadedAssetBundles)
			{
				k.Value.m_AssetBundle.Unload(true);
			}
			m_LoadedAssetBundles.Clear();
			m_InProgressOperations.Clear();
		}

		// [ConditionalAttribute] // RVA: 0x747CCC Offset: 0x747CCC VA: 0x747CCC
		// // RVA: 0xE13420 Offset: 0xE13420 VA: 0xE13420
		// protected static void UnloadDependencies(string assetBundleName) { }

		// // RVA: 0xE1326C Offset: 0xE1326C VA: 0xE1326C
		protected static void UnloadAssetBundleInternal(string assetBundleName, bool unloadAllLoadedObject = false)
		{
			TodoLogger.Log(TodoLogger.AssetBundle, "Request bundle unload " + assetBundleName);
			string error;
			LoadedAssetBundle info = GetLoadedAssetBundle(assetBundleName, out error);
			if(info != null)
			{
				info.m_ReferencedCount -= 1;
				TodoLogger.Log(TodoLogger.AssetBundle, "Refcount is " + info.m_ReferencedCount);
				if(info.m_ReferencedCount == 0)
				{
					info.m_AssetBundle.Unload(unloadAllLoadedObject);
					m_LoadedAssetBundles.Remove(assetBundleName);
				}
			}
		}

		// // RVA: 0xE135EC Offset: 0xE135EC VA: 0xE135EC
		private void Update()
		{
			for(int i = 0; i < m_InProgressOperations.Count; )
			{
				if(!m_InProgressOperations[i].Update())
				{
					m_InProgressOperations.RemoveAt(i);
				}
				else
					i++;
			}
		}

		// // RVA: 0xE137F0 Offset: 0xE137F0 VA: 0xE137F0
		// public static void LoadTutorialAssetsList() { }

#if UNITY_EDITOR
		[MenuItem("UMO/Debug/Dump bundle status")]
		public static void DumpBundleStatus()
		{
			UnityEngine.Debug.LogError("Loaded bundles : ");
			foreach(var it in m_LoadedAssetBundles)
			{
				UnityEngine.Debug.LogError(it.Key+" "+it.Value.m_ReferencedCount);
			}
			UnityEngine.Debug.LogError("Loading bundles : ");
			foreach(var it in m_lodingAssetBundle)
			{
				UnityEngine.Debug.LogError(it.Key+" "+it.Value);
			}
			UnityEngine.Debug.LogError("Loading Errors : ");
			foreach(var it in m_lodingErrors)
			{
				UnityEngine.Debug.LogError(it.Key+" "+it.Value);
			}
		}
#endif
	}
}
