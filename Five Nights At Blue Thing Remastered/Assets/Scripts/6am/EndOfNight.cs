using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfNight : MonoBehaviour {
    public int night;
    public int time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time++;
        if(time > 1000) { Debug.Log("time to go"); }
        night = PlayerPrefs.GetInt("Currentnight");
    }
    public void getnight(int whatnight)
    {
        Debug.Log(whatnight);
        PlayerPrefs.SetInt("Currentnight", whatnight);
    }
}
