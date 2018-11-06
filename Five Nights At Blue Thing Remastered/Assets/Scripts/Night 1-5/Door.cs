using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour {
    public int Count;
    public Sprite[] dooranim;
    public bool trigger;
    public AudioSource slam;
    public Camera_Animation camacc;
    public Cutpower cuttpower;
    public AudioSource click;
    public TextManager textmanager;
    public Lights lightscript;
    public SoundManager soundmanager;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	 void Update () {
        if (textmanager.powerstatus == 0 && trigger == true && lightscript.lights == false) //Power equals zero, door is closed & lights are off
        {
            slam.Play();
            trigger = false;
            lightscript.office--;
            lightscript.door = false;
            textmanager.camcondit2 = false;
        }
        else if (textmanager.powerstatus == 0 && trigger == false && lightscript.lights == true) //Power equals zero, door is open & lights are on
        {
            lightscript.office = lightscript.office - 2;
            lightscript.door = false;
            lightscript.BackSprite.enabled = false;
            lightscript.lights = false;
            soundmanager.Lightbuzz.Stop();
            soundmanager.Lightbool = false;
            textmanager.camcondit2 = false;
        }
        else if (textmanager.powerstatus == 0 && trigger == true && lightscript.lights == true) //Power equals zero, door is closed & lights are on
        {
            lightscript.office = lightscript.office - 3;
            lightscript.door = false;
            lightscript.BackSprite.enabled = false;
            lightscript.lights = false;
            slam.Play();
            trigger = false;
            lightscript.door = false;
            soundmanager.Lightbuzz.Stop();
            soundmanager.Lightbool = false;
            textmanager.camcondit2 = false;
        }
        else if(trigger == true && Count < 11)
        {
            Count++;
        }
        else if(trigger == false && Count > 0 )
        {
            Count--;
        }
        
        this.GetComponent<SpriteRenderer>().sprite = dooranim[Count];
    }
    public void initiateaction()
    {
    if(trigger == false && cuttpower.toggle == false)
        {
            slam.Play();
            trigger = true;

        }
        else if(trigger == true)
        {
            slam.Play();
            trigger = false;
        }
    else if(trigger == false && cuttpower.toggle == true)
        {
            click.Play();
        }
    }
}
