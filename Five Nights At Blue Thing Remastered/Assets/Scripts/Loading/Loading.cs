using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
    public int currentnight;
    public Text whichnight;
    public int time;
	// Use this for initialization
	void Start () {
        currentnight = PlayerPrefs.GetInt("Currentnight");
        whichnight.text = "Night " + (currentnight + 1);	
	}
	
	// Update is called once per frame
	void Update () {
        time++;
        if(time > 600) { SceneManager.LoadScene("night 1-5"); }
    }
}
