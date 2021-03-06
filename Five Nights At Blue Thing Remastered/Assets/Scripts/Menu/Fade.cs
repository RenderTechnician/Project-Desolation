﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {
    public int fader;
    public int time;
    public bool switcher;
    public int whichload;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (time > 0 && fader > 0 && switcher == false)
        {
            fader--;
        }
        else if (switcher == true)
        {
            fader++;
        }
        GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, (fader / 50.0f));
        time++; whichscene();
    }
    public void fadeout()
    {
        switcher = true;
        whichload = 1;
    }
    public void fadeout2()
    {
        switcher = true;
        whichload = 2;
    }
    public void fadeout3()
    {
        switcher = true;
        whichload = 3;
    }
    void whichscene()
    {
        if (fader > 100 && whichload == 1)
        {
            PlayerPrefs.SetInt("Currentnight", 0);
            SceneManager.LoadScene("Text");
        }
        if (fader > 100 && whichload == 2)
        {
            SceneManager.LoadScene("Loading");
        }
        if (fader > 100 && whichload == 3)
        {
            SceneManager.LoadScene("Extras");
        }
    }
}