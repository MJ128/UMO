using UnityEngine;

namespace XeApp
{
	public class FacialTestDivaController : MonoBehaviour
	{
		[SerializeField]
		private AnimationClip faceBlendAnim;
		[SerializeField]
		private AnimationClip mouthBlendAnim;
		[SerializeField]
		private int divaId;
		[SerializeField]
		private int divaModelId;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
