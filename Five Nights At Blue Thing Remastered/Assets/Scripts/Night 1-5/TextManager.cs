using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour {
    public Text power;

    public int powerstatus , multiplier, intervalpower, timeupper , timebound;

    public bool camcondit1 , camcondit2 , camcondit3 , camcondit4;

    public Cutpower cutpower;

    public Camera_Animation camacc;

    public int whichday;

    public float powerdeterminer;

    // Use this for initialization
    void Start () {
        multiplier = 1;
        timebound = -1;
        whichday = PlayerPrefs.GetInt("Currentnight");
        InvokeRepeating("timeup", 0.0f, 60.0f);
    }
	
	// Update is called once per frame
	void Update () {
        powerdown();
        power.text = "Power : " + powerstatus + " %";
        intervalpower = intervalpower + 1 * multiplier;
        if(multiplier > 0) { powerdeterminer += Time.deltaTime * 50; }
        if (powerdeterminer > 350/multiplier)
        {
            powerdraw();
            powerdeterminer = 0;
        }
    }

    void powerdraw()
    {
        if(powerstatus > 0 && multiplier > 0)
        {
            powerstatus--;
        }
    }

    void powerdown()
    {
        if (powerstatus == 0)
        {
            cutpower.toggle = true;
            multiplier = 0;
            camacc.condit = false;
        }
        if(powerstatus == 1 && cutpower.toggle == true)
        {
            cutpower.toggle = false;
            multiplier++;
        }
    }

    void timeup()
    {
        timebound++;
    }

    public void power2()
    {
        if(camcondit1 == false && cutpower.toggle == false)
        {
            camcondit1 = true;
            multiplier++;
        }
        else if (camcondit1 == true && cutpower.toggle == false)
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
