using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Battery : MonoBehaviour {
    public int[] batterys;
    public Image size;
    public int remaining;
    public int whichbattery;
    public bool syphon;
    public bool catcher;
    public string[] WhichBatteryString;
    public TextManager textmanager;
    public Fadeoffice officefade;
    public Text batterytext;
    public AudioSource clip1;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        size.transform.localScale = new Vector3(batterys[whichbattery] / 20.0f, 0.4f, 0.4f);
        whichtransform();
        if (catcher == true && officefade.config == true &&  100 > textmanager.powerstatus && Input.GetMouseButton(0))
        {
            if (whichbattery == 0 && batterys[whichbattery] > 0)
            {
                batterys[whichbattery]--;
                textmanager.powerstatus++;
                batterytext.text = WhichBatteryString[whichbattery ] + " " + batterys[whichbattery] + " %";
                clip1.Play();
            }
        }
        else
        {
            syphon = false;
        }
	}
    public void enter()
    {
        catcher = true;
    }
    public void exit()
    {
        catcher = false;
    }
    public void Up()
    {
        if( 5> whichbattery)
        {
            whichbattery++;
            batterytext.text = WhichBatteryString[whichbattery] + " " + batterys[whichbattery] + " %";
        }
    }
    public void Down()
    {
        if(whichbattery > 0)
        {
            whichbattery--;
            batterytext.text = WhichBatteryString[whichbattery] + " " + batterys[whichbattery] + " %";
        }
    }
    void whichtransform()
    {
      //  if (whichbattery == 0) { size.transform.localScale = new Vector3(battery1 / 20.0f, 0.4f, 0.4f); }
          
    }
}
