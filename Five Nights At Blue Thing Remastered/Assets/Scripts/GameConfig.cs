using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameConfig : MonoBehaviour
{
    public bool state;
    public bool Fullscreen;
    public Image check_fullscreen;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void OptionsPress()
        {
            if (state == false)
            {
                state = true;
            }
            else
            {
                state = false;
            }
        }
    public void FullScreenPress()
    {
        if (Fullscreen == false)
        {
            Fullscreen = true;
            check_fullscreen.enabled = true;
            Screen.fullScreen = Screen.fullScreen;
        }
        else
        {
            Fullscreen = false;
            check_fullscreen.enabled = false;
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
}