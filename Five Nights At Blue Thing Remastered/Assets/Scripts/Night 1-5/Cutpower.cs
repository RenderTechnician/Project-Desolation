using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutpower : MonoBehaviour {
    public int common;               //Determines the 'colour' or 'visibility' of elemts that go dark if the power is turned off
    public float pitch;              //Sets the pitch attribute of the associated audiosources
    public bool toggle;              //Sets whether the lights are to turn off or turn on
    public AudioSource fan;          //Fan audio clip
    public SpriteRenderer office;    //Spriterrenderer for the office
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
        if (60> time)
        {
            office.color = Desk.color = Door.color = new Color(0.0f, 0.0f, 0.0f, 255.0f);
            fan.pitch = pitch;
            pitch = 0;
            textmanager.multiplier = 0;
        }
        else{
            //controls pitch of sounds and alpha transparency of sprites 
            office.color = Desk.color = Door.color = monstroudesk.color = new Color((common / 50.0f), (common / 50.0f), (common / 50.0f), 255.0f);
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

