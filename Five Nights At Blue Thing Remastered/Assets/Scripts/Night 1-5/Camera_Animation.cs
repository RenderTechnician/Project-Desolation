using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Animation : MonoBehaviour {
    //==//
    public SpriteRenderer Cams;              // Camera spriterender. Activates if condit = true and count == 12, deactivates if condit = false.
    public Sprite[] anim;                   // Array containing all 10 camera flip animation frames.
    public AudioSource up;                 // Sound that plays when the camera is flipped up (condit == False).
    public AudioSource down;              // Sound that plays when camera is flipped down (Condit == true).
    public AudioSource fan;              // Sound effect for the fan.
    public AudioSource buzz;            // Buzz that plays when the user presses the "Light" button.
    public int countup;                // 
    public int count;                 // Determines which frame of the Camera_Flip animation is playing. If == 12 then Cams (bool) is activated.
    public bool condit;              // Activates when the user clicks on the "Camera Button".
    public bool cams;               // Determies whether the camera spriterenderer is visible, activates if count == 12 and deactivates if count != 12.
    public bool scrollswitch;      // Determines which direction the camera moves if true move right and if true go left. 
    //==//
    public float scroll;                     //
    public SpriteRenderer map;
    public SpriteRenderer cameras;
    public SpriteRenderer statics;
    public SpriteRenderer bezel;
    public SpriteRenderer scanlines;
    public Canvas buttons;
    public Button lights;
    public Button door;
    public Camera camera1;
    public Switch_graphics graphicalbridge;
    public Fadeoffice officefader;
    public GameObject Cameraparent;
    public Cutpower cutpower;
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
    if (condit == false && officefader.config == false && cutpower.toggle == false)
        {
            condit = true;
            up.Play();
            down.Stop();
        }
        else if (condit == true && officefader.config == false)
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
