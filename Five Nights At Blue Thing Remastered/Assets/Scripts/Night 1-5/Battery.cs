using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Battery : MonoBehaviour {
    public int[] batterys;                           // The array containing the values of all 5 batteries
    public Image size;                              // The green bar behind the syphon text, size is dictated by amount of power left in that battery
    public int whichbattery;                       // Which battery is currently selected?
    public bool syphon;                           // Activates if the user clicks on the <<Syphon>> text and catcher is up
    public bool catcher;                         // Activates if the mouse cursor is over the syphon text
    public string[] WhichBatteryString;         //Determines which battery text is shown e.g. if = 0 then batterytext.text = battery1
    public TextManager textmanager;            // Textmanager script manager reference
    public Fadeoffice officefade;             // Fadeoffice script reference
    public Text batterytext;                 // UI text that shows what battery is currently selected
    public AudioSource clip1;               //Plays when power is syphoned from an auxilery battery to the main one
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        size.transform.localScale = new Vector3(batterys[whichbattery] / 20.0f, 0.4f, 0.4f);
        if (catcher == true && officefade.config == true &&  100 > textmanager.powerstatus && Input.GetMouseButton(0))
        //if the mouse pointer is over <<syphon>> text, the maintenence panel is up, the main battery is less than 100 and left mouse button has ben clicked then trigger condition
        {
            if (whichbattery == 0 && batterys[whichbattery] > 0) //battery1
            {
                batterys[whichbattery]--;
                textmanager.powerstatus++;
                batterytext.text = WhichBatteryString[whichbattery ] + " " + batterys[whichbattery] + " %";
                clip1.Play();
            }
            else if (whichbattery == 1 && batterys[whichbattery] > 0)//battery2
            {
                batterys[whichbattery]--;
                textmanager.powerstatus++;
                batterytext.text = WhichBatteryString[whichbattery] + " " + batterys[whichbattery] + " %";
                clip1.Play();
            }
            else if (whichbattery == 2 && batterys[whichbattery] > 0)//battery3
            {
                batterys[whichbattery]--;
                textmanager.powerstatus++;
                batterytext.text = WhichBatteryString[whichbattery] + " " + batterys[whichbattery] + " %";
                clip1.Play();
            }
            else if (whichbattery == 3 && batterys[whichbattery] > 0)//battery4
            {
                batterys[whichbattery]--;
                textmanager.powerstatus++;
                batterytext.text = WhichBatteryString[whichbattery] + " " + batterys[whichbattery] + " %";
                clip1.Play();
            }
            else if (whichbattery == 4 && batterys[whichbattery] > 0)//battery5
            {
                batterys[whichbattery]--;
                textmanager.powerstatus++;
                batterytext.text = WhichBatteryString[whichbattery] + " " + batterys[whichbattery] + " %";
                clip1.Play();
            }
        }
        else
        {
            syphon = false;
        }
	}
    public void enter()    // triggers when pointer enters Syphon text collider
    {
        catcher = true;
    }
    public void exit()    // triggers when pointer exits Syphon text collider
    {
        catcher = false;
    }
    public void Up()     // triggered when right arrow is pressed, selects next battery
    {
        if(5> whichbattery)
        {
            whichbattery++;
            batterytext.text = WhichBatteryString[whichbattery] + " " + batterys[whichbattery] + " %";
        }
    }
    public void Down()  // triggered when left arrow is pressed, selects previous battery
    {
        if(whichbattery > 0)
        {
            whichbattery--;
            batterytext.text = WhichBatteryString[whichbattery] + " " + batterys[whichbattery] + " %";
        }
    }

}
