
using System;
using System.Collections.Generic;
using System.IO;
using CriWare;
using DereTore.Exchange.Audio.HCA;
using UnityEngine;
using VGMToolbox.format;

namespace ExternLib
{
#if !UNITY_ANDROID
    public static partial class LibCriWare
    {    
        static float bytesToFloat(byte firstByte, byte secondByte)
        {
            // convert two bytes to one short (little endian)
            short s = (short)((secondByte << 8) | firstByte);
            // convert to range from -1 to (just below) 1
            return s / 32768.0F;
        }

        class PlayerData
        {
            public CriAtomExPlayer.Config config;
            public string cueName = "";
            public int cueId = -1;
            public IntPtr acbPtr;
            public CriAtomExPlayer.Status status = CriAtomExPlayer.Status.Stop;
            public Stream[] acbStreams;
            public HcaAudioStream[] audioStream;
            public uint currentPlayingId = 0;
			public bool isPaused = false;

		}
        static Dictionary<IntPtr, PlayerData> playersList = new Dictionary<IntPtr, PlayerData>();
        static List<IntPtr> playersToCheckEnd = new List<IntPtr>();
        static int playerCount = 0;

        public static void criAtomExPlayer_Stop(IntPtr player)
        {
            if(playersList.ContainsKey(player))
            {
                if(playersList[player].acbStreams != null)
                {
                    TodoLogger.Log(TodoLogger.CriAtomExPlayer, "Stop sound "+playersList[player].cueName+" "+playersList[player].cueId);
#if !UNITY_ANDROID
					playersList[player].config.source.unityAudioSource.Stop();
                    playersList[player].config.source.unityAudioSource.clip = null;
#endif
                    playersList[player].audioStream = null;
                    playersList[player].acbStreams = null;
                    playersList[player].status = CriAtomExPlayer.Status.Stop;
                    if(playersList[player].currentPlayingId != 0)
                        playbacksList.Remove(playersList[player].currentPlayingId);
                    playersList[player].currentPlayingId = 0;
                    playersList[player].cueName = "";
                    playersList[player].cueId = -1;
                }
                playersToCheckEnd.Remove(player);
            }
        }
        public static void criAtomExPlayer_StopWithoutReleaseTime(IntPtr player)
        {
			criAtomExPlayer_Stop(player);
		}
        public static void CRIWARE0C3ECA83_criAtomUnityEntryPool_Clear(IntPtr pool)
        {
            if(pool.ToInt32() != 0)
            {
                TodoLogger.LogError(TodoLogger.CriAtomExLib, "CRIWARE0C3ECA83_criAtomUnityEntryPool_Clear");
            }
        }
        public static void criAtomExPlayer_SetVolume(IntPtr player, float volume)
        {
            if(playersList.ContainsKey(player))
			{
#if !UNITY_ANDROID
                playersList[player].config.source.unityAudioSource.volume = volume;
#endif
            }
        }
        public static void CRIWARE693E0CA2_criAtomUnityEntryPool_Destroy(IntPtr pool)
        {
            TodoLogger.LogError(TodoLogger.CriAtomExLib, "CRIWARE693E0CA2_criAtomUnityEntryPool_Destroy");
        }
        public static IntPtr criAtomExPlayer_Create(ref CriAtomExPlayer.Config config, IntPtr work, int work_size)
        {
            IntPtr ptr = new IntPtr(++playerCount);
            PlayerData data = new PlayerData();
            data.config = config;
            playersList[ptr] = data;
            return ptr;
        }
        public static void criAtomExPlayer_Destroy(IntPtr player)
        {
            if(playersList.ContainsKey(player))
            {
                playersList.Remove(player);
            }
        }
        public static CriAtomExPlayer.Status criAtomExPlayer_GetStatus(IntPtr player)
        {
            if(playersList.ContainsKey(player))
            {
                return playersList[player].status;
            }
            return CriAtomExPlayer.Status.Error;
        }
        public static void criAtomExPlayer_SetStartTime(IntPtr player, long start_time_ms)
        {
            if(playersList.ContainsKey(player))
            {
#if !UNITY_ANDROID
				playersList[player].config.source.unityAudioSource.time = start_time_ms * 1.0f / 1000.0f;
#endif
            }
        }
        public static void criAtomExPlayer_UpdateAll(IntPtr player)
        {
			return;
        }
        public static void criAtomExPlayer_Set3dSourceHn(IntPtr player, IntPtr source)
        {
            if(playersList.ContainsKey(player) && srcsList.ContainsKey(source))
			{
#if !UNITY_ANDROID
                if(playersList[player].config.source.unityAudioSource == srcsList[source].config.source.unityAudioSource)
                    return;
#endif
            }
            TodoLogger.LogError(TodoLogger.CriAtomExPlayer, "criAtomExPlayer_Set3dSourceHn");
        }
        public static void criAtomExPlayer_Set3dListenerHn(IntPtr player, IntPtr listener)
        {
            TodoLogger.LogError(TodoLogger.CriAtomExLib, "criAtomExPlayer_Set3dListenerHn");
        }
        public static void criAtomExPlayer_SetPitch(IntPtr player, float pitch)
        {
            if(playersList.ContainsKey(player))
            {
                // Criware : 0 default, 100 = +1 semitone, -100 = -1 semitone.
                // Unity : 1 default, 1.05946 ^n, n being semitone.
                float numSemitone = pitch / 100;
                float unityVal = Mathf.Pow(1.05946f, numSemitone);
#if !UNITY_ANDROID
                playersList[player].config.source.unityAudioSource.pitch = unityVal;
#endif
            }
        }
		public static void criAtomExPlayer_SetCueName(IntPtr player, IntPtr acb_hn, string cue_name)
		{
			if (playersList.ContainsKey(player))
			{
				if (playersList[player].acbPtr != null)
					criAtomExPlayer_Stop(player);

				playersList[player].acbPtr = acb_hn;
				playersList[player].cueName = cue_name;
				SetupPlayer(playersList[player]);
			}
		}

		public static bool checkUncached = false;

		private static void SetupPlayer(PlayerData player)
		{
			if (!acbFiles.ContainsKey(player.acbPtr))
            {
				player.status = CriAtomExPlayer.Status.Error;
                return;
            }
			player.status = CriAtomExPlayer.Status.Prep;

			bool isStreaming;
			Stream[] acbStreams;
			player.audioStream = GetAudioStreams(acbFiles[player.acbPtr].file, player.cueName, player.cueId, out isStreaming, out acbStreams);
			if (player.audioStream == null)
			{
				player.status = CriAtomExPlayer.Status.Error;
				return;
			}
			player.acbStreams = acbStreams;

#if !UNITY_ANDROID
			AudioSource source = player.config.source.unityAudioSource;
			source.loop = player.audioStream[0].HcaInfo.LoopFlag;
			string clipName = player.cueName == "" ? "cue_" + player.cueId : player.cueName;
			AudioClip clip = null;
			if (!acbFiles[player.acbPtr].cachedAudioClips.TryGetValue(clipName, out clip))
			{
				if(checkUncached)
					UnityEngine.Debug.LogError("Loading uncached sound "+ clipName +" " + player.cueName+" "+ player.cueId+" "+player.acbPtr.ToString());
				clip = GetClip(player.audioStream, player.cueName, player.cueId, isStreaming);
			}
			source.clip = clip;
			player.status = CriAtomExPlayer.Status.Stop;
            //UnityEngine.Debug.Log("Prepared sound "+ player.cueName+" "+ player.cueId);
#endif
		}

		private static HcaAudioStream[] GetAudioStreams(CriAcbFile acbFile, string cueName, int cueId, out bool isStreaming, out Stream[] acbStreams)
		{
			var decodeParams = DecodeParams.CreateDefault(0x44C5F5F5, 0x0581B687);
			var audioParams = AudioParams.CreateDefault();
			audioParams.InfiniteLoop = true;
			audioParams.SimulatedLoopCount = 0;
			audioParams.OutputWaveHeader = false;

			if (cueName != "")
				acbStreams = acbFile.GetCueFileStreams(cueName, out isStreaming);
			else
				acbStreams = acbFile.GetCueFileStreams(cueId, out isStreaming);
			if (acbStreams == null)
				return null;

            HcaAudioStream[] audioStreams = new HcaAudioStream[acbStreams.Length];
            for(int i = 0; i < acbStreams.Length; i++)
            {
			    audioStreams[i] = new HcaAudioStream(acbStreams[i], decodeParams, audioParams);
            }
			return audioStreams;
		}

		private static AudioClip GetClip(CriAcbFile acbFile, string cueName, int cueId)
		{
			bool isStreaming;
			Stream[] acbStreams;
			HcaAudioStream[] audioStreams = GetAudioStreams(acbFile, cueName, cueId, out isStreaming, out acbStreams);
			return GetClip(audioStreams, cueName, cueId, isStreaming);
		}
		private static AudioClip GetClip(HcaAudioStream[] audioStreams, string cueName, int cueId, bool isStreaming)
		{
			int length = System.Int32.MaxValue;
            long reallength = 0;
            for(int i = 0; i < audioStreams.Length; i++)
            {
			    reallength += (audioStreams[i].Length / (2 * audioStreams[i].HcaInfo.ChannelCount));
            }
			if (reallength < System.Int32.MaxValue)
			{
				length = (int)reallength;
			}
            for(int i = 0; i < audioStreams.Length; i++)
            {
			    if (audioStreams[i].HcaInfo.LoopFlag)
				    isStreaming = true; // Length will be unlimited if loop is checked, so force as if streamed
            }
									//bool debug = player.cueName == "se_valkyrie_001";
			bool debug = false;
			if (debug)
			{
				TodoLogger.Log(TodoLogger.CriAtomExPlayer, "A " + reallength);
				TodoLogger.Log(TodoLogger.CriAtomExPlayer, "A " + cueName);
				TodoLogger.Log(TodoLogger.CriAtomExPlayer, "A " + cueId);
				TodoLogger.Log(TodoLogger.CriAtomExPlayer, "A " + length);
                for(int i = 0; i < audioStreams.Length; i++)
                {
                    TodoLogger.Log(TodoLogger.CriAtomExPlayer, "A " + audioStreams[i].HcaInfo.ChannelCount);
                    TodoLogger.Log(TodoLogger.CriAtomExPlayer, "A " + audioStreams[i].HcaInfo.SamplingRate);
                }
				TodoLogger.Log(TodoLogger.CriAtomExPlayer, "A " + isStreaming);
			}

			byte[] readData = null;
			AudioClip clip = null;
			//if(isStreaming)
			{
                int currentStream = 0;
				clip = AudioClip.Create(cueName, length, (int)audioStreams[0].HcaInfo.ChannelCount, (int)audioStreams[0].HcaInfo.SamplingRate, isStreaming, (float[] data) => 
                {
					if (debug)
						TodoLogger.Log(TodoLogger.CriAtomExPlayer, "Asked new data (" + data.Length + "), cur pos = " +/*curPos+*/" stream pos = " + audioStreams[currentStream].Position);
					int numLeft = data.Length * 2;
					if (readData == null || readData.Length < data.Length * 2)
					{
						readData = new byte[data.Length * 2];
					}
					int read = 1;
					int offset = 0;
					while (read > 0 && numLeft > 0)
					{
                        int toRead = numLeft;
                        bool switchToNext = false;
                        if(audioStreams.Length > 1 && audioStreams[currentStream].Position + numLeft >= audioStreams[currentStream].Length)
                        {
                            toRead = (int)(audioStreams[currentStream].Length - audioStreams[currentStream].Position);
                            switchToNext = true;
                        }
						read = audioStreams[currentStream].Read(readData, 0, toRead);
						if (debug)
							TodoLogger.Log(TodoLogger.CriAtomExPlayer, "Read " + read);
						for (int i = 0; i < read; i += 2)
						{
							data[offset] = bytesToFloat(readData[i], readData[i + 1]);
							offset++;
						}
						numLeft -= read;
                        if(switchToNext)
                        {
                            currentStream = currentStream + 1 % audioStreams.Length;
                        }
					}
					//curPos += data.Length;
				}, (int newPos) =>
				{
                    currentStream = 0;
                    for(int i = 0; i < audioStreams.Length; i++)
                    {
                        if(newPos * 2 < audioStreams[i].Length)
                            break;
                        currentStream++;
                    }
					audioStreams[currentStream].Seek(newPos * 2, SeekOrigin.Begin);
				});
			}
			/*else
            {
                clip = AudioClip.Create(cueName, length, (int)audioStream.HcaInfo.ChannelCount, (int) audioStream.HcaInfo.SamplingRate, false);
                float[] samples = new float[clip.samples * clip.channels];
                byte[] read = new byte[2];
                for(int i = 0; i < samples.Length; i++)
                {
                    audioStream.Read(read, 0, 2);
                    samples[i] = bytesToFloat(read[0], read[1]);
                }
                clip.SetData(samples, 0);
            }*/
			return clip;
		}

		public static void criAtomExPlayer_LimitLoopCount(IntPtr player, int count)
        {
            TodoLogger.LogError(TodoLogger.CriAtomExLib, "criAtomExPlayer_LimitLoopCount");
        }
        public static IntPtr criAtomExPlayer_GetPlayerParameter(IntPtr player)
        {
            TodoLogger.LogError(TodoLogger.CriAtomExPlayer, "criAtomExPlayer_GetPlayerParameter");
            return IntPtr.Zero;
        }
        public static void criAtomExPlayerParameter_RemoveParameter(IntPtr player_parameter, ushort id)
        {
            TodoLogger.LogError(TodoLogger.CriAtomExPlayer, "criAtomExPlayerParameter_RemoveParameter");
        }
        public static uint criAtomExPlayer_Start(IntPtr player)
        {
            if(playersList.ContainsKey(player))
            {
#if !UNITY_ANDROID
				AudioSource source = playersList[player].config.source.unityAudioSource;
                source.Play();
                //UnityEngine.Debug.Log("Play sound "+playersList[player].cueName+" "+playersList[player].cueId);
                playersList[player].status = CriAtomExPlayer.Status.Playing;
                playersList[player].currentPlayingId = (uint)++playbackCount;
                PlaybackInfo pbinfo = new PlaybackInfo();
                pbinfo.playerPtr = player;
                pbinfo.sourcePtr = playersList[player].config.source.source.nativeHandle;
                playbacksList[playersList[player].currentPlayingId] = pbinfo;
                if(!source.loop)
                    playersToCheckEnd.Add(player);
#endif
                return playersList[player].currentPlayingId;
            }
            return 0;
        }
        public static void criAtomExPlayer_SetCueId(IntPtr player, IntPtr acb_hn, int id)
        {
            if(playersList.ContainsKey(player))
            {
                playersList[player].acbPtr = acb_hn;
				playersList[player].cueName = "";
                playersList[player].cueId = id;
				SetupPlayer(playersList[player]);
            }
        }
        public static void criAtomExPlayer_Pause(IntPtr player, bool sw)
		{
			if (playersList.ContainsKey(player))
			{
                if(sw)
                {
#if !UNITY_ANDROID
				    playersList[player].config.source.unityAudioSource.Pause();
#endif
				    playersList[player].isPaused = true;
				    playersList[player].status = CriAtomExPlayer.Status.Prep;
                }
                else
                {
                    criAtomExPlayer_Resume(player, CriAtomEx.ResumeMode.AllPlayback);
                }
			}
		}
        public static void criAtomExPlayer_Resume(IntPtr player, CriAtomEx.ResumeMode mode)
		{
			if (playersList.ContainsKey(player))
			{
				bool canPlay = false;
				switch(mode)
				{
					case CriAtomEx.ResumeMode.AllPlayback:
						canPlay = true;
						break;
					case CriAtomEx.ResumeMode.PausedPlayback:
						canPlay = playersList[player].isPaused;
						break;
					case CriAtomEx.ResumeMode.PreparedPlayback:
						canPlay = playersList[player].status == CriAtomExPlayer.Status.Prep;
						TodoLogger.LogError(TodoLogger.ToCheck, "Resume");
						break;
				}
				if (canPlay)
				{
#if !UNITY_ANDROID
					playersList[player].config.source.unityAudioSource.UnPause();
#endif
					playersList[player].isPaused = false;
					playersList[player].status = CriAtomExPlayer.Status.Playing;
				}
			}
		}
        public static bool criAtomExPlayer_IsPaused(IntPtr player)
        {
			if (playersList.ContainsKey(player))
			{
				return playersList[player].isPaused;
			}
			return false;
        }
        public static void CheckSoundStatus()
        {
            List<IntPtr> playersStopped = new List<IntPtr>();
            for(int i = playersToCheckEnd.Count - 1; i >= 0; i--)
			{
#if !UNITY_ANDROID
                AudioSource source = playersList[playersToCheckEnd[i]].config.source.unityAudioSource;
                if(!source.isPlaying && !playersList[playersToCheckEnd[i]].isPaused)
                {
                    playersStopped.Add(playersToCheckEnd[i]);
                }
#endif
			}
			for (int i = 0; i < playersStopped.Count; i++)
            {
                criAtomExPlayer_Stop(playersStopped[i]);
            }
        }

        public static void criAtomExPlayer_SetPanType(IntPtr player, CriAtomEx.PanType panType)
		{
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "criAtomExPlayer_SetPanType");
		}
    }
#endif
}
