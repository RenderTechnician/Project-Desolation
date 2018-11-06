using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Settings : MonoBehaviour {
    GameObject[] Links_To_Other_Scenes;

    public GameObject Settings_Parent, Metric_Parent;

    public Toggle Fullscreen, Metrics, vsync, tablet;

    public Dropdown Resolution , Framerate;

    public int w, h , fps;

    public Button_Access BA;

    public string FullScreen_YN;

    public bool FullScreenBool, Tablet_Bool, Metric_Bool, Vsync_Bool;
	// Use this for initialization
	void Start () {
        Links_To_Other_Scenes = GameObject.FindGameObjectsWithTag("Links_To_Other_Scenes");

        //Set variables to playerpref data
        GetFramerate();
        Metrics.isOn = PlayerPrefs.GetInt("Metrics") == 1;
        Fullscreen.isOn = PlayerPrefs.GetInt("ScreenStat") == 1;
        vsync.isOn = PlayerPrefs.GetInt("Sync") == 1;

        if(w == 0){ w = 1280; h = 720; Fullscreen_Toggle(); }
        else { w = PlayerPrefs.GetInt("Width"); h = PlayerPrefs.GetInt("Height"); }
        fps = PlayerPrefs.GetInt("Framerate");
        Fullscreen_Toggle(); StartCalc(); Vsync_toggle(); Metrics_Toggle(); GetFramerate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Settings_Button_Clicked()
    {
        for (int i = 0; i < Links_To_Other_Scenes.Length; i++){
            Links_To_Other_Scenes[i].SetActive(false);
        }
        Settings_Parent.SetActive(true);
        BA.hidecontinue(); BA.hideextras();
    }

    public void Cancel_Button_Clicked()
    {
        for (int i = 0; i < Links_To_Other_Scenes.Length; i++)
        {
            Links_To_Other_Scenes[i].SetActive(true);
        }
        Settings_Parent.SetActive(false);
        BA.hidecontinue(); BA.hideextras();
    }

    public void AnimationStyle()
    {

    }

    public void Fullscreen_Toggle()
    {
        FullScreenBool = !FullScreenBool;
        Screen.SetResolution(w, h, FullScreenBool);
    }

    public void Vsync_toggle()
    {
        if (vsync.isOn) { QualitySettings.vSyncCount = 1; Vsync_Bool = true; }
        else if (!vsync.isOn) { QualitySettings.vSyncCount = 0; Vsync_Bool = false; }
    }

    public void SetResolution()
    {
        if (Resolution.value == 0)
        {
            w = 1280; h = 720;
        }
        else if (Resolution.value == 1)
        {
            w = 1600; h = 900;
        }
        else if (Resolution.value == 2)
        {
            w = 1920; h = 1080;
        }
        Screen.SetResolution(w, h, FullScreenBool);
    }

    void GetFramerate()
    {
        if (fps == 0) { fps = 60; }
        else if (fps == 30) { Framerate.value = 0; }
        else if (fps == 60) { Framerate.value = 1; }
        else if (fps == 120) { Framerate.value = 2; }
        else if (fps == 144) { Framerate.value = 3; }
        else if (fps == 240) { Framerate.value = 4; }
        else if (fps == 20000) { Framerate.value = 5; }
        SetRFrameRate();
    }

    public void SetRFrameRate()
    {
        if (Framerate.value == 0)
        {
            fps = 30;
        }
        else if (Framerate.value == 1)
        {
            fps = 60;
        }
        else if (Framerate.value == 2)
        {
            fps = 120;
        }
        else if (Framerate.value == 3)
        {
            fps = 144;
        }
        else if (Framerate.value == 4)
        {
            fps = 240;
        }
        else if (Framerate.value == 5)
        {
            fps = 20000;
        }
        Application.targetFrameRate = fps;
    }

    public void Apply_Changes()
    {
        PlayerPrefs.SetInt("Width", w);
        PlayerPrefs.SetInt("Height", h);
        PlayerPrefs.SetInt("Framerate", fps);
        PlayerPrefs.SetInt("Tabletmode", Tablet_Bool ? 1:0); //Converts Tabletbool to an int
        PlayerPrefs.SetInt("ScreenStat", FullScreenBool ? 1:0);
        PlayerPrefs.SetInt("Metrics", Metric_Bool ? 1:0);
        PlayerPrefs.SetInt("Sync", Vsync_Bool ? 1:0);
    }

    public void Metrics_Toggle()
    {
        if (Metrics.isOn) { Metric_Parent.SetActive(true); Metric_Bool = true; }
        else { Metric_Parent.SetActive(false); Metric_Bool = false; }
    }

    public void Tablet_Mode()
    {
        Tablet_Bool = !Tablet_Bool;
    }

    void StartCalc()
    {
        if (PlayerPrefs.GetInt("ScreenState") != 0)
        {
            Screen.SetResolution(w, h, PlayerPrefs.GetInt("ScreenState") == 1);
            FullScreenBool = PlayerPrefs.GetInt("ScreenState") == 1;
        }
        else
        {
            Screen.SetResolution(w, h, FullScreenBool);
        }
    }
}
