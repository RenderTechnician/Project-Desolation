using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Animation : MonoBehaviour {
    
    public Sprite[] anim;                   // Array containing all camera flip animation frames.
    public SpriteRenderer Panel;
    public Animator CamPanel;
    public AudioSource up;                 // Sound that plays when the camera is flipped up (condit == False).
    public AudioSource down;              // Sound that plays when camera is flipped down (Condit == true).
    public AudioSource fan;              // Sound effect for the fan.
    public AudioSource buzz;            // Buzz that plays when the user presses the "Light" button.
    public float count;                 // Determines which frame of the Camera_Flip animation is playing. If == 12 then Cams (bool) is activated.
    public bool condit;              // Activates when the user clicks on the "Camera Button".
    public bool cams;               // Determies whether the camera spriterenderer is visible, activates if count == 11 and deactivates if count != 11.
    public bool scrollswitch;      // Determines which direction the camera moves if true move right and if true go left. 
    public float scroll;                     //Variable that determines which way the camera moves
    public Canvas buttons;                  // Canvas containing every button
    public Button lights;
    public Button door;
    public Fadeoffice officefader;       //Fadeoffice script reference
    public Cutpower cutpower;           //Cutpower script reference
    GameObject Camera;                  //The 'Camera' object, allows player to view other buildings in the area
    GameObject[] cameralayer;           // An array containing each room in the building
    //GameObject camflip;                 //Parent Gameobject of 'anim' spriterenderer
    
    void Awake ()
    {
        //Assigning values to variables by finding their corresponding counterpart in the inspector
        Camera = GameObject.Find("Main Camera");
        cameralayer = GameObject.FindGameObjectsWithTag("CameraLayer");
    }	

	void Update () {
        // Call
        condition(); uivis(); scrolling(); scrolling2();
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
        if (condit == true)
        {
            CamPanel.SetTrigger("Up");
            CamPanel.ResetTrigger("Down");
        }
        else if (condit == false)
        {
            CamPanel.SetTrigger("Down");
            CamPanel.ResetTrigger("Up");
        }
    }
    void uivis()       //camera ui visibility
    {
        if (Panel.sprite.name == "0030")
        {
            for (int i=0; i < cameralayer.Length; i++)
            {
                cameralayer[i].GetComponent<SpriteRenderer>().enabled = true;
            }
            fan.volume = 0.2f;
            buzz.volume = 0.1f;
            cams = true;
            buttons.enabled = true;
            door.enabled = false;
            lights.enabled = false;
            Camera.transform.position = new Vector4(scroll, 0.0f, -10.0f);
        }
        else
        {
            for (int i = 0; i < cameralayer.Length; i++)
            {
                cameralayer[i].GetComponent<SpriteRenderer>().enabled = false;
            }
            fan.volume = 0.8f;
            buzz.volume = 1.0f;
            cams = false;
            buttons.enabled = false;
            door.enabled = true;
            lights.enabled = true;
            Camera.transform.position = new Vector4(0.0f, 0.0f, -10.0f);
        }
    }

    float countup;
    void scrolling()
    {
        
        if(!scrollswitch)
        {
            countup += Time.deltaTime * 60;
            scroll = countup / 60.0f;
        }
        else
        {
            countup -= Time.deltaTime * 60;
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
