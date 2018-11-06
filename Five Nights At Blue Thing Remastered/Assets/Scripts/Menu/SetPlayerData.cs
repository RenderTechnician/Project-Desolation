using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void InitialSet()
    {
        PlayerPrefs.SetInt("Speed", 1000);
        PlayerPrefs.SetInt("BatterySize", 600);
        PlayerPrefs.SetInt("DischargeRate", 10);
        PlayerPrefs.SetInt("RechargeRate", 100);
    }

    public void UpdatePlayerData()
    {
        if(PlayerPrefs.GetInt("Speed")> 2000)
        {
            PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") - 1000);
        } 

        if(PlayerPrefs.GetInt("BatterySize") > 200)
        {
            PlayerPrefs.SetInt("BatterySize", PlayerPrefs.GetInt("BatterySize") - 100);
        }

        PlayerPrefs.SetInt("DischargeRate", PlayerPrefs.GetInt("DischargeRate")-5);
        PlayerPrefs.SetInt("RechargeRate", PlayerPrefs.GetInt("RechargeRate") + 10);
        PlayerPrefs.Save();
    }
}
