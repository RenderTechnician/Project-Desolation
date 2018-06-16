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
    public bool camcondit4;
    public Cutpower cutpower;
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
        if(timeupper >= 3600)
        {
            timeupper = 0;
            timebound++;
            time.text = timebound + " AM";
        }
    }
    public void power2()
    {
        if(camcondit1 == false )
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
        if (camcondit2 == false && cutpower.toggle == false)
        {
            camcondit2 = true;
            multiplier = multiplier + 2;
        }
        else if (camcondit2 == true && cutpower.toggle == false)
        {
            camcondit2 = false;
            multiplier = multiplier - 2;
        }
    }
    public void power4()
    {
        if (camcondit3 == false && cutpower.toggle == false)
        {
            camcondit3 = true;
            multiplier++;
        }
        else if (camcondit3 == true && cutpower.toggle == false)
        {
            camcondit3 = false;
            multiplier--;
        }
    }
    public void power5()
    {
        if (camcondit4 == false)
        {
            camcondit4 = true;
            multiplier++;
        }
        else
        {
            camcondit4 = false;
            multiplier--;
        }
    }
}
