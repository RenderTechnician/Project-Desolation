using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
    public AudioSource stat;
    public VideoPlayer static2;
    public int time;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time++;
         if(time > 240 && 600 > time)
        {
            static2.enabled = false;
            stat.volume = 0.5f;
        }
        else if(time > 600)
        {
            SceneManager.LoadScene("Menu 2");
        }
	}
}
