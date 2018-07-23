using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfNight : MonoBehaviour {
    public int night;
    public int time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time++;
        if(time > 1000) { SceneManager.LoadScene("daytime"); }
        night = PlayerPrefs.GetInt("Currentnight");
    }
}
