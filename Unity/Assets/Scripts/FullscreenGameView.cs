#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class FullscreenGameView
{
    static readonly Type GameViewType = Type.GetType("UnityEditor.GameView,UnityEditor");
    static EditorWindow instance;

    private static readonly bool FullscreenOnPlay = true;

    static FullscreenGameView()
    {
        EditorApplication.playModeStateChanged -= ToggleFullscreen;
        if (!FullscreenOnPlay)
            return;
        EditorApplication.playModeStateChanged += ToggleFullscreen;
    }

    [MenuItem("Window/General/Game (Fullscreen) %#&2", priority = 2)]
    public static void Toggle()
    {
        ToggleFullscreen(PlayModeStateChange.EnteredPlayMode);
    }

    public static void ToggleFullscreen(PlayModeStateChange pmsc)
    {
        if (GameViewType == null)
        {
            Debug.LogError("GameView type not found.");
            return;
        }

        if (pmsc == PlayModeStateChange.EnteredEditMode || pmsc == PlayModeStateChange.ExitingEditMode)
        {
            CloseGameWindow();
            return;
        }

        switch (pmsc)
        {
            case PlayModeStateChange.ExitingPlayMode:
                return;

            case PlayModeStateChange.EnteredPlayMode:
                if (CloseGameWindow())
                    return;
                break;
        }

        float width = Screen.currentResolution.width;
        float height = Screen.currentResolution.height;
        float offset = 17.0f;

        instance = (EditorWindow)ScriptableObject.CreateInstance(GameViewType);
        instance.ShowPopup();
        instance.minSize = new Vector2(width, height + offset);
        instance.position = new Rect(0, -offset, width, height + offset);
        instance.Focus();
    }

    private static bool CloseGameWindow()
    {
        if (instance != null)
        {
            instance.Close();
            instance = null;
            return true;
        }
        return false;
    }
}

#endif
