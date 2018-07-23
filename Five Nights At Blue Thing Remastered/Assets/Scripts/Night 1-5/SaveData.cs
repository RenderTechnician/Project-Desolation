using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {
    public Battery batterybridge;
    public TextManager textmanager;
	// Use this for initialization
	void Start () {
        if (textmanager.whichday == 0)
        {
            PlayerPrefs.SetInt("battery1power", 100);
            PlayerPrefs.SetInt("battery2power", 100);
            PlayerPrefs.SetInt("battery3power", 100);
            PlayerPrefs.SetInt("battery4power", 100);
            PlayerPrefs.SetInt("battery5power", 100);
        }
        else
        {
            batterybridge.batterys[0] = PlayerPrefs.GetInt("battery1power");
            batterybridge.batterys[1] = PlayerPrefs.GetInt("battery2power");
            batterybridge.batterys[2] = PlayerPrefs.GetInt("battery3power");
            batterybridge.batterys[3] = PlayerPrefs.GetInt("battery4power");
            batterybridge.batterys[4] = PlayerPrefs.GetInt("battery5power");
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(batterybridge.batterys[0]);
        if (textmanager.timebound == 6)
        {
            PlayerPrefs.SetInt("battery1power", batterybridge.batterys[0]);
            PlayerPrefs.SetInt("battery2power", batterybridge.batterys[1]);
            PlayerPrefs.SetInt("battery3power", batterybridge.batterys[2]);
            PlayerPrefs.SetInt("battery4power", batterybridge.batterys[3]);
            PlayerPrefs.SetInt("battery5power", batterybridge.batterys[4]);
        }
	}
}
