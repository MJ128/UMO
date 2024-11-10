using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeApp.Game;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Adv
{
	public class AdvCharacter : MonoBehaviour
	{
		private enum State
		{
			None = 0,
			Expansion = 1,
			Shrink = 2,
		}

		[SerializeField]
		private Image _body; // 0xC
		[SerializeField]
		private Image _eye; // 0x10
		[SerializeField]
		private Image _mouth; // 0x14
		[SerializeField]
		private RawImage _aura; // 0x18
		[SerializeField]
		private RawImage _prism; // 0x1C
		[SerializeField]
		private AdvCharacterData _charaData; // 0x20
		[SerializeField]
		private ColorTween[] m_showTween; // 0x24
		[SerializeField]
		private TweenBase[] m_pickupTween; // 0x28
		[SerializeField]
		private ColorTween[] m_hideTween; // 0x2C
		[SerializeField]
		private Material auraMaterialSource; // 0x30
		[SerializeField]
		private Material prismMaterialSource; // 0x34
		private static readonly WaitForSeconds BlinkIntervalWait = new WaitForSeconds(3); // 0x0
		private static readonly WaitForSeconds BlinkFrameWait = new WaitForSeconds(1.0f/15); // 0x4
		private static readonly WaitForSeconds BlinkFrameWait2 = new WaitForSeconds(1.0f/30); // 0x8
		private const int BlinkAnimeStartRandMin = 1;
		private const int BlinkAnimeStartRandMax = 6;
		private Coroutine _blinkCoroutine; // 0x38
		private Coroutine _mouthCoroutine; // 0x3C
		private Coroutine _waitCoroutine; // 0x40
		private Texture2D _maskTexture; // 0x44
		private Material _auraMaterialInstance; // 0x48
		private Material _prismMaterialInstance; // 0x4C
		private RectTransform _selfRectTransform; // 0x50
		private int _faceId; // 0x54
		private int _charaId; // 0x58
		private int _positionId; // 0x5C
		private int _mouth_current; // 0x60
		private bool _isShowing; // 0x64
		private bool _isTweenPlaying; // 0x65
		private bool _isPrism; // 0x66
		private List<LayoutUGUIRuntime> m_effAnimeList = new List<LayoutUGUIRuntime>(); // 0x68
		public static readonly Vector2 BlurTextureUvOffset = new Vector2(0.01953125f, 0.01953125f); // 0xC
		private AdvCharacter.State _state; // 0x6C

		// public int FaceId { get; } 0xBBF5D4
		public int CharaId { get { return _charaId; } } //0xBBF5DC
		// public int PositionId { get; } 0xBBF5E4

		// // RVA: 0xBBF5EC Offset: 0xBBF5EC VA: 0xBBF5EC
		public void Clear()
		{
			_faceId = 0;
			_charaId = 0;
			_positionId = 0;
			_charaData = null;
			if(_blinkCoroutine != null)
			{
				this.StopCoroutineWatched(_blinkCoroutine);
				_blinkCoroutine = null;
			}
			if(_mouthCoroutine != null)
			{
				this.StopCoroutineWatched(_mouthCoroutine);
				_mouthCoroutine = null;
			}
			_body.sprite = null;
			_body.material = null;
			_eye.sprite = null;
			_eye.material = null;
			_mouth.sprite = null;
			_mouth.material = null;
			_aura.material = null;
			_prism.material = null;
			_maskTexture = null;
			_auraMaterialInstance = null;
			_prismMaterialInstance = null;
		}

		// // RVA: 0xBBF7A4 Offset: 0xBBF7A4 VA: 0xBBF7A4
		public void SetCharacterData(int charaId, AdvCharacterData data, int positionId, bool isPrism, int colorId)
		{
			_charaData = data;
			_selfRectTransform = GetComponent<RectTransform>();
			_faceId = 0;
			_charaId = charaId;
			_positionId = positionId;
			if(_blinkCoroutine != null)
			{
				this.StopCoroutineWatched(_blinkCoroutine);
				_blinkCoroutine = null;
			}
			if(_mouthCoroutine != null)
			{
				this.StopCoroutineWatched(_mouthCoroutine);
				_mouthCoroutine = null;
			}
			_charaData.Set(_body, _eye, _mouth, 1);
			_selfRectTransform.sizeDelta = _body.rectTransform.sizeDelta;
			_selfRectTransform.pivot = _body.rectTransform.pivot;
			_body.rectTransform.pivot = new Vector2(0.5f, 0.5f);
			_body.rectTransform.anchoredPosition = new Vector2(0, 0);
			_prism.enabled = false;
			_aura.enabled = false;
			if(isPrism)
			{
				_maskTexture = data.GetBlurTexture();
				if(_maskTexture != null)
				{
					if(colorId == 0)
					{
						colorId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[charaId - 1].HEHKNMCDBJJ_ColorId;
					}
					_prism.enabled = true;
					_aura.enabled = true;
					Vector2 v = BlurTextureUvOffset * _maskTexture.height * new Vector2(2, 1);
					_prism.rectTransform.sizeDelta = _body.rectTransform.sizeDelta;
					_aura.rectTransform.sizeDelta = _body.rectTransform.sizeDelta + v;
					_aura.rectTransform.anchoredPosition = new Vector2(0, _body.rectTransform.anchoredPosition.y + v.y * 0.5f);
					_auraMaterialInstance = new Material(auraMaterialSource);
					_prismMaterialInstance = new Material(prismMaterialSource);
					_aura.material = _auraMaterialInstance;
					_prism.material = _prismMaterialInstance;
					_aura.uvRect = new Rect(
						_body.sprite.uv[3].x, 
						_body.sprite.uv[3].y - BlurTextureUvOffset.y, 
						(_body.sprite.uv[1].x - _body.sprite.uv[0].x) + BlurTextureUvOffset.x * 2, 
						(_body.sprite.uv[0].y - _body.sprite.uv[1].y) + BlurTextureUvOffset.y
					);
					_prism.uvRect = new Rect(
						_body.sprite.uv[3].x,
						_body.sprite.uv[3].y,
						_body.sprite.uv[1].x - _body.sprite.uv[0].x,
						_body.sprite.uv[0].y - _body.sprite.uv[1].y
					);
					_auraMaterialInstance.SetTexture("_MainTex", _maskTexture);
					_auraMaterialInstance.SetColor("_MainColor", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.LOCEHOMKJEI_ColorConfigs[colorId - 1].DOKKMMFKLJI_Color);
					_auraMaterialInstance.SetFloat("_Power", 1.5f);
					_prismMaterialInstance.SetTexture("_MainTex", _maskTexture);
				}
			}
			ResetState();
		}

		// // RVA: 0xBC0BEC Offset: 0xBC0BEC VA: 0xBC0BEC
		public void SetPosition(Vector2 pos)
		{
			_body.rectTransform.anchoredPosition = pos;
		}

		// // RVA: 0xBC0C48 Offset: 0xBC0C48 VA: 0xBC0C48
		public void SetFace(int faceId)
		{
			if(_charaData != null && faceId != 0 && _faceId != faceId)
			{
				_charaData.Set(_body, _eye, _mouth, faceId);
				_selfRectTransform.sizeDelta = _body.rectTransform.sizeDelta;
				_selfRectTransform.pivot = _body.rectTransform.pivot;
				_body.rectTransform.pivot = new Vector2(0.5f, 0.5f);
				_body.rectTransform.anchoredPosition = new Vector2(0, 0);
				_faceId = faceId;
				if(_blinkCoroutine != null)
				{
					this.StopCoroutineWatched(_blinkCoroutine);
					_blinkCoroutine = null;
				}
				if(gameObject.activeInHierarchy)
				{
					_blinkCoroutine = this.StartCoroutineWatched(BlinkCoroutine());
				}
			}
		}

		// // RVA: 0xBC0FD8 Offset: 0xBC0FD8 VA: 0xBC0FD8
		public void StartMouthAnime(float ms)
		{
			if(_mouthCoroutine != null)
			{
				this.StopCoroutineWatched(_mouthCoroutine);
				_mouthCoroutine = null;
			}
			if (!gameObject.activeInHierarchy)
				return;
			_mouthCoroutine = this.StartCoroutineWatched(MouthPatternCoroutine(ms));
		}

		// // RVA: 0xBC1114 Offset: 0xBC1114 VA: 0xBC1114
		public void StartMouthOneAnime(UnityAction end)
		{
			if(_mouthCoroutine != null)
			{
				this.StopCoroutineWatched(_mouthCoroutine);
				_mouthCoroutine = null;
			}
			if (!gameObject.activeInHierarchy)
				return;
			_mouthCoroutine = this.StartCoroutineWatched(MouthOnePatternCoroutine(end));
		}

		// // RVA: 0xBC1244 Offset: 0xBC1244 VA: 0xBC1244
		public void EndMouthAnime()
		{
			if(_mouthCoroutine != null)
			{
				this.StopCoroutineWatched(_mouthCoroutine);
				_mouthCoroutine = null;
			}
			if (!gameObject.activeInHierarchy)
				return;
			_mouthCoroutine = this.StartCoroutineWatched(MouthPatternFinishCoroutine());
		}

		// // RVA: 0xBC1350 Offset: 0xBC1350 VA: 0xBC1350
		public void EndMouthOneAnime()
		{
			if(_mouthCoroutine != null)
			{
				this.StopCoroutineWatched(_mouthCoroutine);
				_mouthCoroutine = null;
			}
			if (!gameObject.activeInHierarchy)
				return;
			_mouthCoroutine = this.StartCoroutineWatched(MouthPatternOneFinishCoroutine());
		}

		// // RVA: 0xBC145C Offset: 0xBC145C VA: 0xBC145C
		public void SetEyePattern(int pattern)
		{
			_charaData.SetEyePattern(_eye, _faceId, pattern);
		}

		// // RVA: 0xBC15B4 Offset: 0xBC15B4 VA: 0xBC15B4
		public void SetMouthPattern(int pattern)
		{
			_charaData.SetMouthPattern(_mouth, _faceId, pattern);
		}

		// // RVA: 0xBC170C Offset: 0xBC170C VA: 0xBC170C
		public void SetDisp(bool isOn)
		{
			_body.enabled = isOn;
			_eye.enabled = isOn;
			_mouth.enabled = isOn;
			if(_isPrism)
			{
				_aura.enabled = isOn;
				_prism.enabled = isOn;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x741D3C Offset: 0x741D3C VA: 0x741D3C
		// // RVA: 0xBC17E0 Offset: 0xBC17E0 VA: 0xBC17E0
		public IEnumerator ShowCoroutine(bool isSkip)
		{
			//0xBC3EE8
			_isShowing = true;
			_eye.enabled = false;
			_mouth.enabled = false;
			_isTweenPlaying = true;
			for(int i = 0; i < m_showTween.Length; i++)
			{
				m_showTween[i].ResetTime();
			}
			if (!isSkip)
			{
				do
				{
					//LAB_00bc417c
					for (int i = 0; i < m_showTween.Length; i++)
					{
						m_showTween[i].UpdateCurve();
					}
					yield return null;
				} while (!m_showTween[0].IsEnd());
			}
			else
			{
				for (int i = 0; i < m_showTween.Length; i++)
				{
					m_showTween[i].End();
				}
			}
			_isShowing = false;
			_eye.enabled = true;
			_mouth.enabled = true;
			_isTweenPlaying = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x741DB4 Offset: 0x741DB4 VA: 0x741DB4
		// // RVA: 0xBC18A8 Offset: 0xBC18A8 VA: 0xBC18A8
		public IEnumerator HideCoroutine(bool isSkip)
		{
			//0xBC2EF8
			_isShowing = true;
			_eye.enabled = false;
			_mouth.enabled = false;
			_isTweenPlaying = true;
			for(int i = 0; i < m_hideTween.Length; i++)
			{
				m_hideTween[i].ResetTime();
			}
			if (!isSkip)
			{
				do
				{
					for (int i = 0; i < m_hideTween.Length; i++)
					{
						m_hideTween[i].UpdateCurve();
					}
					yield return null;
				} while (!m_hideTween[0].IsEnd());
			}
			else
			{
				for (int i = 0; i < m_showTween.Length; i++)
				{
					m_showTween[i].End();
				}
			}
			_isShowing = false;
			_eye.enabled = true;
			_mouth.enabled = true;
			_isTweenPlaying = false;
		}

		// // RVA: 0xBC1970 Offset: 0xBC1970 VA: 0xBC1970
		public void ChangeExpansion()
		{
			for(int i = 0; i < m_pickupTween.Length; i++)
			{
				if((i & 1) == 0)
				{
					m_pickupTween[i].End();
					m_pickupTween[i].UpdateCurve();
				}
			}
			_state = State.Expansion;
		}

		// // RVA: 0xBC1A68 Offset: 0xBC1A68 VA: 0xBC1A68
		public void ChangeShrink()
		{
			for (int i = 0; i < m_pickupTween.Length; i++)
			{
				if ((i & 1) != 0)
				{
					m_pickupTween[i].End();
					m_pickupTween[i].UpdateCurve();
				}
			}
			_state = State.Shrink;
		}

		// // RVA: 0xBC0AF4 Offset: 0xBC0AF4 VA: 0xBC0AF4
		public void ResetState()
		{
			for(int i = 0; i < m_pickupTween.Length; i++)
			{
				if((i & 1) != 0)
				{
					m_pickupTween[i].End();
					m_pickupTween[i].UpdateCurve();
				}
			}
			_state = 0;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x741E2C Offset: 0x741E2C VA: 0x741E2C
		// // RVA: 0xBC1B60 Offset: 0xBC1B60 VA: 0xBC1B60
		public IEnumerator Expansion()
		{
			//0xBC2C14
			if (_state == State.Expansion)
				yield break;
			for(int i = 0; i < m_pickupTween.Length; i++)
			{
				if((i & 1) == 0)
				{
					m_pickupTween[i].ResetTime();
				}
			}
			_state = State.Expansion;
			_isTweenPlaying = true;
			do
			{
				for (int i = 0; i < m_pickupTween.Length; i++)
				{
					if ((i & 1) == 0)
					{
						m_pickupTween[i].UpdateCurve();
					}
				}
				UpdateEffectScale(null);
				yield return null;
			} while (!m_pickupTween[0].IsEnd());
			_isTweenPlaying = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x741EA4 Offset: 0x741EA4 VA: 0x741EA4
		// // RVA: 0xBC1C0C Offset: 0xBC1C0C VA: 0xBC1C0C
		public IEnumerator Shrink()
		{
			//0xBC42B8
			if (_state == State.Shrink)
				yield break;
			for(int i = 0; i < m_pickupTween.Length; i++)
			{
				if((i & 1) != 0)
				{
					m_pickupTween[i].ResetTime();
				}
			}
			_state = State.Shrink;
			_isTweenPlaying = true;
			do
			{
				for (int i = 0; i < m_pickupTween.Length; i++)
				{
					if ((i & 1) != 0)
					{
						m_pickupTween[i].UpdateCurve();
					}
				}
				UpdateEffectScale(null);
			} while (!m_pickupTween[1].IsEnd());
			_isTweenPlaying = false;
		}

		// // RVA: 0xBC1CB8 Offset: 0xBC1CB8 VA: 0xBC1CB8
		public bool IsTweenPlaying()
		{
			return _isTweenPlaying;
		}

		// // RVA: 0xBC1CC0 Offset: 0xBC1CC0 VA: 0xBC1CC0
		private void UpdateEffectScale(TweenBase tween)
		{
			Vector3 v = new Vector3(1.0f / transform.localScale.x, 1.0f / transform.localScale.y, 1);
			for(int i = 0; i < m_effAnimeList.Count; i++)
			{
				m_effAnimeList[i].GetComponentInChildren<RawImageEx>(true).transform.localScale = v;
			}
		}

		// // RVA: 0xBC1ED0 Offset: 0xBC1ED0 VA: 0xBC1ED0
		public Vector2 GetEffectAttachAnchor()
		{
			return new Vector2(_eye.rectTransform.anchoredPosition.x / _body.rectTransform.sizeDelta.x + _eye.rectTransform.anchorMin.x, _eye.rectTransform.anchoredPosition.y / _body.rectTransform.sizeDelta.y);
		}

		// // RVA: 0xBC204C Offset: 0xBC204C VA: 0xBC204C
		public void AppendEffect(LayoutUGUIRuntime layout)
		{
			Vector2 v = GetEffectAttachAnchor();
			layout.transform.SetParent(transform, false);
			layout.GetComponent<RectTransform>().anchorMax = v;
			layout.GetComponent<RectTransform>().anchorMin = v;
			layout.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
			m_effAnimeList.Add(layout);
		}

		// // RVA: 0xBC2220 Offset: 0xBC2220 VA: 0xBC2220
		public void RemoveEffect(Transform parent)
		{
			for(int i = 0; i < m_effAnimeList.Count; i++)
			{
				m_effAnimeList[i].transform.SetParent(parent, false);
				m_effAnimeList[i].gameObject.SetActive(false);
			}
			m_effAnimeList.Clear();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x741F1C Offset: 0x741F1C VA: 0x741F1C
		// // RVA: 0xBC0F4C Offset: 0xBC0F4C VA: 0xBC0F4C
		private IEnumerator BlinkCoroutine()
		{
			int length;
			int current;
			float time;
			float waitTime;

			//0xBC26EC
			length = _charaData.GetEyePatternLength(_faceId) - 1;
			current = 0;
			time = 0;
			waitTime = 0;
			SetEyePattern(0);
			while(true)
			{
				//LAB_00bc2a48
				if(!_isShowing)
				{
					yield return BlinkIntervalWait;
					time = 0;
					waitTime = UnityEngine.Random.Range(1, 6);
					while(time < waitTime)
					{
						yield return null;
						time += TimeWrapper.deltaTime;
					}
					current = 1;
					while(current < length)
					{
						//LAB_00bc2824
						SetEyePattern(current);
						yield return BlinkFrameWait;
						current++;
					}
					current = length;
					while(current >= 0)
					{
						SetEyePattern(current);
						yield return BlinkFrameWait;
						current--;
					}
				}
				else
				{
					yield return null;
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x741F94 Offset: 0x741F94 VA: 0x741F94
		// // RVA: 0xBC1060 Offset: 0xBC1060 VA: 0xBC1060
		private IEnumerator MouthPatternCoroutine(float ms)
		{
			int length; // 0x1C
			int current; // 0x20

			//0xBC3710
			length = _charaData.GetMouthPatternLenght(_faceId) - 1;
			current = 0;
			bool isLoop = true;
			SetMouthPattern(current);
			if(_waitCoroutine != null)
			{
				this.StopCoroutineWatched(_waitCoroutine);
				_waitCoroutine = null;
			}
			_waitCoroutine = this.StartCoroutineWatched(WaitMouthCoroutine(ms, () =>
			{
				//0xBC26DC
				isLoop = false;
			}));
			while(isLoop)
			{
				current = 1;
				while(current < length)
				{
					SetMouthPattern(current);
					_mouth_current = current;
					yield return BlinkFrameWait;
					current++;
				}
				current = length;
				while (current > 0)
				{
					SetMouthPattern(current);
					_mouth_current = current;
					yield return BlinkFrameWait;
					current--;
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x74200C Offset: 0x74200C VA: 0x74200C
		// // RVA: 0xBC23FC Offset: 0xBC23FC VA: 0xBC23FC
		private IEnumerator WaitMouthCoroutine(float ms, UnityAction end)
		{
			float time;

			//0xBC45A0
			time = 0;
			do
			{
				time += TimeWrapper.deltaTime;
				yield return null;
			} while (time < ms);
			if (end != null)
				end();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x742084 Offset: 0x742084 VA: 0x742084
		// // RVA: 0xBC119C Offset: 0xBC119C VA: 0xBC119C
		private IEnumerator MouthOnePatternCoroutine(UnityAction end)
		{
			int length; // 0x18
			int current; // 0x1C

			//0xBC32C8
			length = _charaData.GetMouthPatternLenght(_faceId) - 1;
			current = 0;
			SetMouthPattern(current);
			current = 1;
			while(current < length)
			{
				SetMouthPattern(current);
				_mouth_current = current;
				yield return BlinkFrameWait;
				current++;
			}
			current = length;
			while (current >= 0)
			{
				SetMouthPattern(current);
				_mouth_current = current;
				yield return BlinkFrameWait2;
				current--;
			}
			if (end != null)
				end();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7420FC Offset: 0x7420FC VA: 0x7420FC
		// // RVA: 0xBC12C4 Offset: 0xBC12C4 VA: 0xBC12C4
		private IEnumerator MouthPatternFinishCoroutine()
		{
			//0xBC3B90
			while(_mouth_current > -1)
			{
				SetMouthPattern(_mouth_current);
				yield return BlinkFrameWait;
				_mouth_current--;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x742174 Offset: 0x742174 VA: 0x742174
		// // RVA: 0xBC13D0 Offset: 0xBC13D0 VA: 0xBC13D0
		private IEnumerator MouthPatternOneFinishCoroutine()
		{
			//0xBC3D84
			_mouth_current = 0;
			SetMouthPattern(0);
			yield break;
		}
	}
}
