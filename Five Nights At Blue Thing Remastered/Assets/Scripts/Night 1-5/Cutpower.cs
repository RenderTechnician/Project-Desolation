using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutpower : MonoBehaviour {
    public int common;
    public float pitch;
    public bool toggle;
    public AudioSource fan;
    public SpriteRenderer office;
    public SpriteRenderer Desk;
    public SpriteRenderer Door;
    public SpriteRenderer monstroudesk;
    public TextManager textmanager;
    public AudioSource error;
    public AudioSource click;
    public Sprite[] cameraimage;
    public Button cameraacc;
    public int onoroff;
    public int time;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time++;
        cameraacc.GetComponent<Image>().sprite = cameraimage[onoroff];
        pitch = common / 50.0f;
        faders();
        thecommon();

	}
    public void thepower()
    {
        if(toggle == true)
        {
            toggle = false;
            textmanager.multiplier++;
            onoroff = 0;
        }
        else if(toggle == false && textmanager.camcondit1 == false && textmanager.camcondit2 == false && textmanager.camcondit3 == false)
        {
            onoroff = 1;
            toggle = true;
            textmanager.multiplier--;
        }
        else if(toggle == false && textmanager.camcondit1 == true || toggle == false && textmanager.camcondit2 == true || toggle == false && textmanager.camcondit3 == true)
        {
            error.Play();
        }
    }
    void faders()
    {
        if (textmanager.whichday == 0 &&  60> time)
        {
            office.color = new Color(0.0f, 0.0f, 0.0f, 255.0f);
            Desk.color = new Color(0.0f, 0.0f, 0.0f, 255.0f);
            Door.color = new Color(0.0f, 0.0f, 0.0f, 255.0f);
            fan.pitch = pitch;
            pitch = 0;
            textmanager.multiplier = 0;
        }
        else if (time > 60){
        //controls pitch of sounds and alpha transparency of sprites 
        office.color = new Color((common / 50.0f), (common / 50.0f), (common / 50.0f), 255.0f);
        Desk.color = new Color((common / 50.0f), (common / 50.0f), (common / 50.0f), 255.0f);
        Door.color = new Color((common / 50.0f), (common / 50.0f), (common / 50.0f), 255.0f);
        monstroudesk.color = new Color((common / 50.0f), (common / 50.0f), (common / 50.0f), 255.0f);
            fan.pitch = pitch;
        }
    }
    void thecommon()
    {
        //adjust the common variable based on whether power is being cut or restored
        if (toggle == true && common > 0)
        {
            common--;
        }
        if (50 > common && toggle == false)
        {
            common++;
        }
    }
    public void lighterror()
    {
        if(toggle == true)
        {
            click.Play();
        }
    }
}

