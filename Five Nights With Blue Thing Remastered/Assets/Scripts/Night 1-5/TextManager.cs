using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
    public Text power;
    public Text time;
    public int powerstatus;
    public int multiplier;
    public int intervalpower;
    public int timeupper;
    public int timebound;
    public bool camcondit1;
    public bool camcondit2;
    public bool camcondit3;
    // Use this for initialization
    void Start () {
        powerstatus = 99;
        multiplier = 1;
	}
	
	// Update is called once per frame
	void Update () {
        timeup();
        power.text = "Power : " + powerstatus + " %";
        intervalpower = intervalpower + 1 * multiplier;
        if (intervalpower > 350)
        {
            powerstatus--;
            intervalpower = 0;
        }
    }
    void powerdown()
    {

    }
    void timeup()
    {
        timeupper++;
        if(timeupper >= 5000
            )
        {
            timeupper = 0;
            timebound++;
            time.text = timebound + " AM";
        }
    }
    public void power2()
    {
        if(camcondit1 == false)
        {
            camcondit1 = true;
            multiplier++;
        }
        else
        {
            camcondit1 = false;
            multiplier--;
        }
    }
    public void power3()
    {
        if (camcondit2 == false)
        {
            camcondit2 = true;
            multiplier++;
        }
        else
        {
            camcondit2 = false;
            multiplier--;
        }
    }
    public void power4()
    {
        if (camcondit3 == false)
        {
            camcondit3 = true;
            multiplier++;
        }
        else
        {
            camcondit3 = false;
            multiplier--;
        }
    }
}
