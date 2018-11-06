using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kevin : MonoBehaviour {
    public TextManager textmanager;
    public Camera_Animation camacc;
    public Camerastatus camstat;
    public int kevincountdown;
    public int specialnumber,delayvalue;
    public float kevpower;
    public bool kevswitch;
    public int kevboundary;
    public Slider kevbattery;
    public AudioSource alert;
    public AudioSource cut;
    // Use this for initialization
    void Start () {
        alert1 = GameObject.Find("alert").GetComponent<SpriteRenderer>();
        alert2 = GameObject.Find("alert2").GetComponent<SpriteRenderer>();
        specialnumber = Random.Range(1, PlayerPrefs.GetInt("Speed"));
        kevbattery.maxValue = PlayerPrefs.GetInt("BatterySize");
        Invoke("Kevin_Delay", 10.0f);
    }
	
	// Update is called once per frame
	void Update () {
        kevtriggered(); kevmath(); setboundary(); //calling other functions
        kevbattery.value = Mathf.RoundToInt(kevpower);
        int randomgenkev = Random.Range(0, PlayerPrefs.GetInt("Speed"));
        if (randomgenkev == specialnumber && delayvalue ==1 && !kevswitch)
        //if randomkev == specialnumber then kevswitch bool becomes true
        {
            kevswitch = true;
        }
    }

    SpriteRenderer alert1; SpriteRenderer alert2;

    void kevtriggered()
    {
        if(kevpower > 600)
        {
            kevcall();
        }
       else if (kevswitch == false)
        {
            alert1.enabled = alert2.enabled = false;
            alert.Stop();
        }
        else if (camacc.condit == true && kevswitch == true)
        {
            alert1.enabled = false;
            alert2.enabled = true;
            kevpower += Time.deltaTime * (30 * (textmanager.whichday + 1));
            if (!alert.isPlaying) { alert.Play(); }
            
        }
        else if (camacc.condit == false && kevswitch == true)
        {
            alert1.enabled = true;
            alert2.enabled = false;
            kevpower += Time.deltaTime * (30 * (textmanager.whichday + 1));
            if (!alert.isPlaying) { alert.Play(); }
        }
    }

    void kevcall()
    {
        int buffer = PlayerPrefs.GetInt("KevinLeft");
        if (!cut.isPlaying) { cut.Play(); }
        textmanager.powerstatus = 0 + buffer;
        kevswitch = false;
        kevpower = 0;
    }

    public void reroute()
    {
        if(camstat.count == 1)
        {
            kevswitch = false;
            alert.Stop();
        }
    }

    void kevmath()
    {
    if(kevswitch == false && kevpower > kevboundary)
        {
            kevpower -= Time.deltaTime * (60/PlayerPrefs.GetInt("DischargeRate"));
        }
    }

    void setboundary()
    {
        if(kevpower > 125 && 250 > kevpower)
        {
            kevboundary = 125;
        }
        else if (kevpower > 250 && 375> kevpower)
        {
            kevboundary = 250;
        }
        else if (kevpower > 375 && 600 > kevpower)
        {
            kevboundary = 375;
        }
        else if (kevpower > PlayerPrefs.GetInt("BatterySize"))
        {
            kevboundary = 0;
            kevpower = 0;
            camacc.condit = false;
        }
    }

    void Kevin_Delay()
    {
        delayvalue++;
    }

}
