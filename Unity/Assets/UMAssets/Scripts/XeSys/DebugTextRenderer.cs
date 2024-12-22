using UnityEngine;
using System.Collections;

namespace XeSys
{
	public class DebugTextRenderer : MonoBehaviour
	{
		private struct Info
		{
			public Vector3 mBasePosition; // 0x0
			public TextAnchor mAnchor; // 0xC
			public float mDirection; // 0x10

			// // RVA: 0x806050 Offset: 0x806050 VA: 0x806050
			public Info(Vector3 posi, TextAnchor anchor, float direction)
			{
				mBasePosition = posi;
				mAnchor = anchor;
				mDirection = direction;
			}
		}

		public static bool enable = true; // 0x0
		private const float LINE_SPACE = 18;
		private static Info[] mAnchorInfo = new Info[5] { new Info(new Vector3(0,1,0), TextAnchor.UpperLeft, 0),
														new Info(new Vector3(0,1,0), TextAnchor.UpperLeft, 1),
														new Info(new Vector3(1,1,0), TextAnchor.UpperRight, 1),
														new Info(new Vector3(0,0,0), TextAnchor.LowerLeft, -1),
														new Info(new Vector3(1,0,0), TextAnchor.LowerRight, -1) }; // 0x4
		private float[] mPosiY; // 0xC
		private Vector2 mBasePosition; // 0x10
		private Vector2 mNextPosition; // 0x18
		private static DebugTextRenderer mInstance; // 0x8
		[SerializeField]
		private GameObject mDebugTextObject; // 0x20
		private ArrayList mStringList; // 0x24

		// public Vector2 BasePosition { get; set; }
		// public static DebugTextRenderer Instance { get; }

		// // RVA: 0x2036788 Offset: 0x2036788 VA: 0x2036788
		// public Vector2 get_BasePosition() { }

		// // RVA: 0x203679C Offset: 0x203679C VA: 0x203679C
		// public void set_BasePosition(Vector2 value) { }

		// // RVA: 0x20367A8 Offset: 0x20367A8 VA: 0x20367A8
		// public static DebugTextRenderer get_Instance() { }

		// // RVA: 0x2036834 Offset: 0x2036834 VA: 0x2036834
		public static GameObject Create(DebugTextRenderer prefab)
		{
			return null;
		}

		// // RVA: 0x203683C Offset: 0x203683C VA: 0x203683C
		private void Awake()
		{
			TodoLogger.LogError(TodoLogger.DebugTextRenderer, "Debug Text Renderer Awake");
		}

		// // RVA: 0x2036AF0 Offset: 0x2036AF0 VA: 0x2036AF0
		private void Start()
		{
			TodoLogger.LogError(TodoLogger.DebugTextRenderer, "Debug Text Renderer Start");
		}

		// // RVA: 0x2036AF4 Offset: 0x2036AF4 VA: 0x2036AF4
		private void Update()
		{
			TodoLogger.LogError(TodoLogger.DebugTextRenderer, "Debug Text Renderer Update");
		}

		// // RVA: 0x20369B4 Offset: 0x20369B4 VA: 0x20369B4
		// private void InitializeCamera() { }

		// // RVA: 0x2036BB4 Offset: 0x2036BB4 VA: 0x2036BB4
		// private void SetupGuiText(GameObject obj, float x, float y, string str, int anchor, Color[] color) { }

		// // RVA: 0x2036EB8 Offset: 0x2036EB8 VA: 0x2036EB8
		// public void Print(string str, DebugTextRenderer.Anchor anchor, Color[] color) { }

		// // RVA: 0x20371FC Offset: 0x20371FC VA: 0x20371FC
		// public void PrintFree(float x, float y, string str, Color[] color) { }

		// // RVA: 0x2037454 Offset: 0x2037454 VA: 0x2037454
		// public void SetBasePosition(float x, float y) { }

		// // RVA: 0x20374A0 Offset: 0x20374A0 VA: 0x20374A0
		// public void Print(string str, Color[] color) { }
	}
}
