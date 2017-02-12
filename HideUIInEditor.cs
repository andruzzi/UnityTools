using UnityEngine;

/// <summary>
/// Auto hide the canvas while not in play mode
/// Auto show when turning play mode.
/// </summary>
[ExecuteInEditMode]
public class HideUIInEditor : MonoBehaviour {

    public Canvas canvas;
    public bool AutoHideInEditMode = true;

    private bool isVisible = true; // default
    private bool autoRestarted = false;

    void Start() // in case this gets into the build... always show the canvas.
    {
        if (Application.isPlaying) canvas.enabled = isVisible = true;
    }

    void OnDisable()
    {
        canvas.enabled = isVisible = true;
    }

#if UNITY_EDITOR

    void Update()
    {
        if (Application.isEditor)
        {
            if (Application.isPlaying) // playmode.
            {
                if (!autoRestarted) // always show in playmode.
                {
                    autoRestarted = isVisible = canvas.enabled = true;
                }
            } else // edit mode
            {
                if (autoRestarted) autoRestarted = false; // reset playmode switch
                if (AutoHideInEditMode && isVisible) // basic toggle
                {
                    isVisible = false;
                    canvas.enabled = isVisible;
                }
                else if (!AutoHideInEditMode && !isVisible)
                {
                    isVisible = true;
                    canvas.enabled = isVisible;
                }

            }
        }
    }

#endif
}

