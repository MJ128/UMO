using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace CriWare
{
    public class CriFsWebInstaller : CriDisposable
    {
        public enum Status
        {
            Stop = 0,
            Busy = 1,
            Complete = 2,
            Error = 3,
        }

        public enum Error
        {
            None = 0,
            Timeout = 1,
            Memory = 2,
            LocalFs = 3,
            DNS = 4,
            Connection = 5,
            SSL = 6,
            HTTP = 7,
            Internal = 8,
        }

        public struct StatusInfo
        {
            public CriFsWebInstaller.Status status; // 0x0
            public CriFsWebInstaller.Error error; // 0x4
            public int httpStatusCode; // 0x8
            public long contentsSize; // 0x10
            public long receivedSize; // 0x18
        }

        public struct ModuleConfig
        {
            public uint numInstallers; // 0x0
            public string proxyHost; // 0x4
            public ushort proxyPort; // 0x8
            public string userAgent; // 0xC
            public uint inactiveTimeoutSec; // 0x10
            public bool allowInsecureSSL; // 0x14
            public bool crcEnabled; // 0x15
            public CriFsWebInstaller.ModulePlatformConfig platformConfig; // 0x16
        }

        public struct ModulePlatformConfig
        {
            public byte reserved; // 0x0

            // public static CriFsWebInstaller.ModulePlatformConfig defaultConfig { get; } 0x294DE24
        }

        public const int InvalidHttpStatusCode = -1;
        public const long InvalidContentsSize = -1;
        private IntPtr handle; // 0x18

        public static bool isInitialized { get; private set; } // 0x0
        public static bool isCrcEnabled { get; private set; } // 0x1
        public static CriFsWebInstaller.ModuleConfig defaultModuleConfig { get { return new ModuleConfig() { numInstallers = 2, proxyHost = null, proxyPort = 0, userAgent = null, inactiveTimeoutSec = 300, allowInsecureSSL = false }; } }// 0x294DDFC

		// tmp hack
		public UnityEngine.WWW www = null;
        public string fileSavePath;
        public CriFsWebInstaller.StatusInfo status = new CriFsWebInstaller.StatusInfo();
        // tmp hack

        // // RVA: 0x294D7A4 Offset: 0x294D7A4 VA: 0x294D7A4
        public CriFsWebInstaller()
        {
			criFsWebInstaller_Create(out handle);
			if(handle != IntPtr.Zero)
			{
				CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.FsWeb);
			}
			else
				throw new Exception("criFsWebInstaller_Create() failed.");
        }

        // // RVA: 0x294DF48 Offset: 0x294DF48 VA: 0x294DF48 Slot: 1
        // protected override void Finalize() { }

        // // RVA: 0x294E0CC Offset: 0x294E0CC VA: 0x294E0CC Slot: 5
        public override void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        // // RVA: 0x294D8BC Offset: 0x294D8BC VA: 0x294D8BC
        public void Copy(string url, string dstPath)
        {
#if UNITY_ANDROID
            criFsWebInstaller_Copy(handle, url, dstPath);
#else
			url = FileSystemProxy.ConvertURL(url);
            UnityEngine.Debug.Log("Copy "+url+" "+dstPath);
            fileSavePath = dstPath;
            try
            {
                www = new UnityEngine.WWW(url);
                status.status = Status.Busy;
            }
            catch(Exception e)
            {
                UnityEngine.Debug.LogError(e);
                status.status = Status.Error;
            }
#endif
        }

        // // RVA: 0x294D728 Offset: 0x294D728 VA: 0x294D728
        public void Stop()
        {
#if UNITY_ANDROID
            if(handle != IntPtr.Zero)
            {
                criFsWebInstaller_Stop(handle);
            }
#else
            if(www != null)
            {
                www.Dispose();
                www = null;
            }
            status.status = Status.Stop;
#endif
        }

        // // RVA: 0x294DB28 Offset: 0x294DB28 VA: 0x294DB28
        public CriFsWebInstaller.StatusInfo GetStatusInfo()
        {
            CriFsWebInstaller.StatusInfo st;
            if(handle != IntPtr.Zero)
            {
                criFsWebInstaller_GetStatusInfo(this, out st);
            }
            else
            {
                st = new CriFsWebInstaller.StatusInfo();
                st.contentsSize = -1;
                st.receivedSize = 0;
                st.httpStatusCode = -1;
                st.status = Status.Stop;
                st.error = Error.None;
            }
            return st;
        }

        // // RVA: 0x294DC68 Offset: 0x294DC68 VA: 0x294DC68
        // public bool GetCRC32(out uint ret_val) { }

        // // RVA: 0x294E59C Offset: 0x294E59C VA: 0x294E59C
        public static void InitializeModule(ModuleConfig config)
		{
			if(isInitialized)
			{
				UnityEngine.Debug.LogError("[CRIWARE] CriFsWebInstaller module is already initialized.");
				return;
			}

            CriFsPlugin.InitializeLibrary();
            criFsWebInstaller_Initialize(config);
			isCrcEnabled = config.crcEnabled;
			isInitialized = true;
		}

        // // RVA: 0x294E8A4 Offset: 0x294E8A4 VA: 0x294E8A4
        public static void FinalizeModule()
		{
			TodoLogger.LogError(TodoLogger.CriFsWebInstaller, "CriFsWebInstaller FinalizeModule");
		}

		// // RVA: 0x294C460 Offset: 0x294C460 VA: 0x294C460
		public static void ExecuteMain()
        {
            criFsWebInstaller_ExecuteMain();
        }

        // // RVA: 0x294EC08 Offset: 0x294EC08 VA: 0x294EC08
        // public static bool SetRequestHeader(string field, string value) { }

        // // RVA: 0x294DFB0 Offset: 0x294DFB0 VA: 0x294DFB0
        private void Dispose(bool disposing)
        {
            CriDisposableObjectManager.Unregister(this);
            if(handle != IntPtr.Zero)
            {
                if(GetStatusInfo().status != Status.Stop)
                {
                    Stop();
                    criFsWebInstaller_ExecuteMain();
                    while(GetStatusInfo().status != Status.Stop)
                    {
                        Thread.Sleep(1);
                        criFsWebInstaller_ExecuteMain();
                    }
                }
                criFsWebInstaller_Destroy(handle);
                handle = IntPtr.Zero;
            }
        }

        // // RVA: 0x294E798 Offset: 0x294E798 VA: 0x294E798
#if UNITY_ANDROID
        [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
        private static extern int criFsWebInstaller_Initialize(in CriFsWebInstaller.ModuleConfig config);
#else
        private static int criFsWebInstaller_Initialize(in CriFsWebInstaller.ModuleConfig config)
        {
            return 0;
        }
#endif
        // // RVA: 0x294EA58 Offset: 0x294EA58 VA: 0x294EA58
        // private static extern int criFsWebInstaller_Finalize() { }

        // // RVA: 0x294EB30 Offset: 0x294EB30 VA: 0x294EB30
#if UNITY_ANDROID
        [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
        private static extern int criFsWebInstaller_ExecuteMain();
#else
        private static int criFsWebInstaller_ExecuteMain()
        {
            return 0;
        }
#endif

        // // RVA: 0x294DE30 Offset: 0x294DE30 VA: 0x294DE30
#if UNITY_ANDROID
        [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
        private static extern int criFsWebInstaller_Create(out IntPtr installer);
#else
        private static /*extern */int criFsWebInstaller_Create(out IntPtr installer)
		{
			TodoLogger.LogError(TodoLogger.CriFsWebInstaller, "CriFsWebInstaller.criFsWebInstaller_Create");
			installer = new IntPtr(1);
			return 0;
		}
#endif

        // // RVA: 0x294ED50 Offset: 0x294ED50 VA: 0x294ED50
#if UNITY_ANDROID
        [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
        private static extern int criFsWebInstaller_Destroy(IntPtr installer);
#else
        private static int criFsWebInstaller_Destroy(IntPtr installer)
        {
            return 0;
        }
#endif

        // // RVA: 0x294E160 Offset: 0x294E160 VA: 0x294E160
#if UNITY_ANDROID
        [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
        private static extern int criFsWebInstaller_Copy(IntPtr installer, string url, string dstPath);
#else
        private static int criFsWebInstaller_Copy(IntPtr installer, string url, string dstPath)
        {
            return 0;
        }
#endif

        // // RVA: 0x294E2B8 Offset: 0x294E2B8 VA: 0x294E2B8
#if UNITY_ANDROID
        [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
        private static extern int criFsWebInstaller_Stop(IntPtr installer);
#else
        private static int criFsWebInstaller_Stop(IntPtr installer)
        {
            return 0;
        }
#endif

        // // RVA: 0x294E3D0 Offset: 0x294E3D0 VA: 0x294E3D0
#if UNITY_ANDROID
        [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
        private static extern int criFsWebInstaller_GetStatusInfo(IntPtr installer, out CriFsWebInstaller.StatusInfo status);
#endif
        private static int criFsWebInstaller_GetStatusInfo(/*IntPtr*/CriFsWebInstaller installer, out CriFsWebInstaller.StatusInfo status)
        {
#if UNITY_ANDROID
            return criFsWebInstaller_GetStatusInfo(installer.handle, out status);
#else
            TodoLogger.LogError(TodoLogger.CriFsWebInstaller, "criFsWebInstaller_GetStatusInfo");
            
            status = installer.status;

            if(installer.www != null)
            {
                if(status.status != Status.Complete)
                {
                    status.status = Status.Busy;
                    status.contentsSize = 1000;
                    status.receivedSize = (long)(1000 * installer.www.progress);
                    if(installer.www.isDone)
                    {
						if (string.IsNullOrEmpty(installer.www.error))
						{
                            status.status = Status.Complete;
							TodoLogger.Log(TodoLogger.Filesystem, "Write file " + installer.fileSavePath);
							System.IO.File.WriteAllBytes(installer.fileSavePath, installer.www.bytes);
						}
                        else
                        {
                            status.status = Status.Error;
                            TodoLogger.LogError(TodoLogger.Filesystem, "Install Error for "+installer.www.url+" : "+installer.www.error);
                        }
                    }
                }
            }
            else
            {
                status.contentsSize = -1;
                status.receivedSize = 0;
                status.httpStatusCode = 0;
                status.status = Status.Stop;
                status.error = Error.None;
            }
            return 0;
#endif
        }

        // // RVA: 0x294E4B8 Offset: 0x294E4B8 VA: 0x294E4B8
        // private static extern int criFsWebInstaller_GetCRC32(IntPtr installer, out uint crc32) { }

        // // RVA: 0x294EC28 Offset: 0x294EC28 VA: 0x294EC28
        // private static extern int criFsWebInstaller_SetRequestHeader(string field, string value) { }
    }
}
