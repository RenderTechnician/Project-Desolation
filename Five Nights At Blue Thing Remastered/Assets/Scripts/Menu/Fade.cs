using System.Collections;
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
        GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, (fader / 50.0f));
        time++;
        if (time > 0 && fader > 0 && switcher == false)
        {
            fader--;
        }
        else if (switcher == true)
        {
            fader++;
        }
        if(fader > 100 && whichload == 1)
        {
            SceneManager.LoadScene("Text");
        }
    }
    public void fadeout()
    {
        switcher = true;
        whichload = 1;
    }
}