using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfNight : MonoBehaviour {

    SetPlayerData SPD;

	void Start () {
        SPD = GameObject.Find("TextManager").GetComponent<SetPlayerData>();
        SPD.UpdatePlayerData();
        Invoke("load_day_scene", 15.0f);
	}

    void load_day_scene()
    {
        PlayerPrefs.SetInt("D/N", 1); //Determines whether it's day or night. Night = 0 & Day = 1
        if (5 > PlayerPrefs.GetInt("Currentnight")) { SceneManager.LoadScene("daytime"); }
        else { SceneManager.LoadScene("Menu 2"); }
    }
	
}
