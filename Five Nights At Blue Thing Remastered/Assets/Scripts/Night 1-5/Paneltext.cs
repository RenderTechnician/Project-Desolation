using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paneltext : MonoBehaviour {
    public Fadeoffice fader; //Public reference to Fadeoffice.cs
    public int hour;         //
    public int minute;
    public float second;
    public Text time;
    public Text cutpower, date;
    public Text battery;
    public Text syphon;
    public Image green;
    public SpriteRenderer greensquare1;
    public SpriteRenderer static1;
    public string[] datestring;
    public TextManager textmanager;
    public GameObject[] maintenencespriterenderers;
    public SpriteRenderer panelref;
    // Use this for initialization
    void Awake()
    {

    }
    void Start () {
        InvokeRepeating("times", 1.0f, 1.0f);
        time.text = "Time: " + hour.ToString("00") + " : " + minute.ToString("00") + " : " + second.ToString("00");
        date.text = "Date: " + datestring[textmanager.whichday];
    }
	
	// Update is called once per frame
	void Update () {
        visibility();
    }
    void times()
    {
         second++;
        time.text = "Time: " + hour.ToString("00") + " : " + minute.ToString("00") + " : " + second.ToString("00");
        if (second > 59)
        {
            minute++;
            second = 0;
        }
         if(minute > 59)
        {
            hour++;
            minute = 0;
        }
    }
    void visibility()
    {
        if (!fader.config)
        {
            for (int i = 0; i < maintenencespriterenderers.Length; i++)
            {
                maintenencespriterenderers[i].SetActive(false);
            }
        }
            else if(panelref.sprite.name == "0030" && fader.config)
            {
            for (int i = 0; i < maintenencespriterenderers.Length; i++)
            {
                maintenencespriterenderers[i].SetActive(true);
            }
        }
    }
}
