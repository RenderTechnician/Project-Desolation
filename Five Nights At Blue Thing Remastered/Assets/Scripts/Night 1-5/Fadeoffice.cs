using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeoffice : MonoBehaviour {
    public bool config;
    public Camera_Animation cameraacc;
    public Button thisbutton;
    public SpriteRenderer blur;
    public int blurint;
    public Animator panel;
    public AudioSource flip;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        blur.color = new Color(255.0f, 255.0f, 255.0f, (blurint / 20.0f));
        if (cameraacc.condit == true)
        {
            thisbutton.enabled = false;
        }
        else
        {
            thisbutton.enabled = true;
        }
        blurring();
        //  GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 255.0f, (fader / 50.0f));
    }
    public void trigger()
    {
        if (config == true)
        {
            config = false;
            panel.SetTrigger("paneldown");
            panel.ResetTrigger("panelup");
            flip.Play();
        }
        else if (config == false && cameraacc.condit == false)
        {
            config = true;
            panel.SetTrigger("panelup");
            panel.ResetTrigger("paneldown");
            flip.Play();
        }
    }
    void blurring()
    {
        if (config == true && 20 > blurint)
        {
            blurint++;
        }
        else if (config == false && blurint > 0)
        {
            blurint--;
        }
    }
}
