using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Animation : MonoBehaviour {
    public SpriteRenderer Cams;
    public Sprite[] anim;
    public AudioSource up;
    public AudioSource down;
    public AudioSource fan;
    public AudioSource buzz;
    public int count;
    public bool condit;
    public bool cams;
    public bool scrollswitch;
    public SpriteRenderer map;
    public SpriteRenderer cameras;
    public SpriteRenderer statics;
    public SpriteRenderer bezel;
    public SpriteRenderer scanlines;
    public Canvas buttons;
    public Button lights;
    public Button door;
    public Camera camera1;
    public float scroll;
    public int countup;
    public Switch_graphics graphicalbridge;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        condition();
        uivis();
        scrolling();
        scrolling2();
        this.GetComponent<SpriteRenderer>().sprite = anim[count];
	}
    public void Camacc()
    {
    if (condit == false)
        {
            condit = true;
            up.Play();
            down.Stop();
        }
        else
        {
            condit = false;
            down.Play();
            up.Stop();
        }
    }
    void condition()    //camera flip
    {
        if (condit == true && count < 12)
        {
            count++;
        }
        else if (condit == false && count > 0)
        {
            count--;
        }
    }
    void uivis()       //camera ui visibility
    {
if(count == 12)
        {
            map.enabled = true;
            cameras.enabled = true;
            statics.enabled = true;
            bezel.enabled = true;
            scanlines.enabled = true;
            cams = true;
            fan.volume = 0.2f;
            buzz.volume = 0.1f;
            buttons.enabled = true;
            door.enabled = false;
            lights.enabled = false;
            camera1.transform.position = new Vector4(scroll, graphicalbridge.positioner, -10.0f);
        }
        else
        {
            map.enabled = false;
            cameras.enabled = false;
            statics.enabled = false;
            bezel.enabled = false;
            scanlines.enabled = false;
            cams = false;
            fan.volume = 0.8f;
            buzz.volume = 1.0f;
            buttons.enabled = false;
            door.enabled = true;
            lights.enabled = true;
            camera1.transform.position = new Vector4(0.0f, graphicalbridge.positioner, -10.0f);
        }
    }
    void scrolling()
    {
        if(scrollswitch == false)
        {
            countup++;
            scroll = countup / 60.0f;
        }
        else
        {
            countup--;
            scroll = countup / 60.0f;
        }
    }
    void scrolling2()
    {
        if (scroll > 4.5)
        {
            scrollswitch = true;
        }
        if (scroll < -4.5)
        {
            scrollswitch = false;
        }
    }
}
