using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warning : MonoBehaviour {
    public float time, fader;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 255.0f, (fader/50.0f));
        time += Time.deltaTime * 50;
        if(200 > time)
        {
            fader += Time.deltaTime * 50;
        }
        else if(time > 200)
        {
            fader -= Time.deltaTime * 50;
        }
        if(0 > fader)
        {
            //load next scene
            SceneManager.LoadScene("Menu 2");
        }
	}
}
