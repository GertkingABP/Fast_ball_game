using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglerFullScreen : MonoBehaviour
{
    private Toggle toggleFullScreen;

    void Start()
    {
        //toggleFullScreen.onValueChanged.AddListener(delegate { ToggleFullscreen(); });
    }

    void ToggleFullscreen()
    {
        //Screen.fullScreen = toggleFullScreen.isOn;
    }
}
