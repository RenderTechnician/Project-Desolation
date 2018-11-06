using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class addtobat : MonoBehaviour
{
    public SpriteRenderer time_left_sprite;

    public PCTextScript2 pctext2ref;

    public int timeleft;

    public maintenencepanel panelref;

    // Use this for initialization
    void Start()
    {
        timeleft = 181;
        InvokeRepeating("LowerTime", 0.0f, 1.0f);
    }

    void LowerTime()
    {
        timeleft--;
        time_left_sprite.transform.localScale = new Vector2(timeleft/(100.0f*1.81f), timeleft / (100.0f * 1.81f));

        if (0 > timeleft)
        {
            //set all batteries
            PlayerPrefs.SetInt("battery1power", PlayerPrefs.GetInt("battery2power") + pctext2ref.addtobatteries[0]);
            PlayerPrefs.SetInt("battery2power", PlayerPrefs.GetInt("battery2power") + pctext2ref.addtobatteries[1]);
            PlayerPrefs.SetInt("battery3power", PlayerPrefs.GetInt("battery3power") + pctext2ref.addtobatteries[2]);
            PlayerPrefs.SetInt("battery4power", PlayerPrefs.GetInt("battery4power") + pctext2ref.addtobatteries[3]);
            PlayerPrefs.SetInt("battery5power", PlayerPrefs.GetInt("battery5power") + pctext2ref.addtobatteries[4]);
            //Set Kevin Data
            PlayerPrefs.SetInt("Speed", panelref.speed);
            PlayerPrefs.SetInt("BatterySize", panelref.batterysize);
            PlayerPrefs.SetInt("DischargeRate", panelref.discharge);
            PlayerPrefs.SetInt("RechargeRate", panelref.recharge);
            //load loading scene
            PlayerPrefs.SetInt("D/N", 0); //Determines whether it's day or night. Night = 0 & Day = 1
            PlayerPrefs.Save();
            SceneManager.LoadScene("Loading");
        }

    }
}
