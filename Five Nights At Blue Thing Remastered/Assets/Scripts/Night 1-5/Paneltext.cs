using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paneltext : MonoBehaviour {
    public Fadeoffice fader;
    public int shower;
    public int hour;
    public int minute;
    public int second;
    public Text time;
    public Text nameofservice;
    public Text cutpower;
    public Text leftarrow;
    public Text rightarrow;
    public Text battery;
    public Text syphon;
    public Text date;
    public Image green;
    public SpriteRenderer greensquare1;
    public SpriteRenderer static1;
    public string[] datestring;
    public TextManager textmanager;
    // Use this for initialization
    void Start () {
        date.text = "Date: " + datestring[textmanager.whichday];
	}
	
	// Update is called once per frame
	void Update () {
        times();
        second++;
        visibility();
    }
    void times()
    {
    //     if(hour == 0) { hour = 12;}
         if(second > 59)
        {
            minute++;
            second = 0;
        }
         if(minute > 59)
        {
            hour++;
            minute = 0;
        }
        time.text = "Time: " + hour.ToString("00") +" : "+ minute.ToString("00") + " : " + second.ToString("00");
    }
    void visibility()
    {
if(fader.config == true)
        {
            shower++;
        }
        else
        {
            time.enabled = false;
            nameofservice.enabled = false;
            greensquare1.enabled = false;
            static1.enabled = false;
            cutpower.enabled = false;
            leftarrow.enabled = false;
            rightarrow.enabled = false;
            battery.enabled = false;
            syphon.enabled = false;
            green.enabled = false;
            date.enabled = false;
            shower = 0;
        }
            if(shower > 20 && fader.config == true)
            {
                time.enabled = true;
                nameofservice.enabled = true;
                greensquare1.enabled = true;
                static1.enabled = true;
                cutpower.enabled = true;
                leftarrow.enabled = true;
                rightarrow.enabled = true;
                battery.enabled = true;
                syphon.enabled = true;
                green.enabled = true;
                date.enabled = true;
            }
    }
}
