using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueThing : MonoBehaviour {
    public int[] currentbt;
    public float Random_Number;
    public int location; // 0 = office, 1 = 1a, 2 = 1b, 3 = 2a, 4 = 3a, 5 = 4a, 6 = 5a 
    public Camerastatus camstat;
    public Camera_Animation camacc;
    public Sprite[] bluethingspritearray;
    public SpriteRenderer[] bluethingmanipulate;

    bool Outisideoffice;

    public Animator Bluethinganimator , jumpscare_animator;

    public GameObject Blue_Thing_Outside , Blue_Thing_Jumpscare_Parent;

    public Lights Lights_Reference;

    public bool Blue_Thing_Outside_TOF;

    public SpriteRenderer Blue_Thing_Cams, blue_thing_jumpscare;

    public AudioSource scream;

    // Use this for initialization
    void Start () {
        //if night is less than three disable blue thing parent object
        bluethingspr = GameObject.Find("BlueThing").GetComponent<SpriteRenderer>();
        Random_Number = Random.Range(20, 20);
        InvokeRepeating("bluethingappear", Random_Number, Random_Number);
    }

    // Update is called once per frame
    SpriteRenderer bluethingspr;
    void Update()
    {
        bluethingmath();
    }

    void bluethingmath()
    {
        if (camstat.count == 0 && camacc.condit == true) { currentbt[0]++; } //cam 1a
        if (camstat.count == 1 && camacc.condit == true) { currentbt[1]++; } //cam1b
        if (camstat.count == 2 && camacc.condit == true) { currentbt[2]++; } //cam2a
        if (camstat.count == 3 && camacc.condit == true) { currentbt[3]++; } //cam3a
        if (camstat.count == 4 && camacc.condit == true) { currentbt[4]++; } //cam4a
        if (camstat.count == 5 && camacc.condit == true) { currentbt[5]++; } //cam5a

        var temp = Mathf.Min(currentbt[0], currentbt[1], currentbt[2], currentbt[3], currentbt[4], currentbt[5]); //gets the lowest value from each camera

        location = System.Array.IndexOf(currentbt, temp) + 1; //trawls the array for the lowest value and pulls the index ID, then finally adds one to the value

        if(location == camstat.count && camacc.cams) { bluethingspr.enabled = true; } else { bluethingspr.enabled = false; whichimg(); }
    }

    public void officeshow()
    {
        if (Lights_Reference.lights && Blue_Thing_Outside_TOF)
        {
            Blue_Thing_Outside.SetActive(true);
            Bluethinganimator.SetTrigger("Lights_Active");
            StopCoroutine("Jumpscare_Coroutine");
            StartCoroutine("Jumpscare_Reset");
        }
        else { Blue_Thing_Outside.SetActive(false); }
    }

    public void whichimg()
    {
        bluethingspr.GetComponent<SpriteRenderer>().sprite = bluethingspritearray[Random.Range(0, 9)];
    }
    public IEnumerator Jumpscare_Coroutine()
    {
        yield return new WaitForSeconds(5.0f);
        Blue_Thing_Outside.SetActive(false);
        Blue_Thing_Cams.enabled = true;
        Blue_Thing_Jumpscare_Parent.SetActive(true);
        jumpscare_animator.SetTrigger("Trigger_jumpscare");
        scream.Play();
        Blue_Thing_Outside_TOF = false;
        Blue_Thing_Cams.enabled = true;
        if (blue_thing_jumpscare.sprite.name == "0060")
        {
            Blue_Thing_Jumpscare_Parent.SetActive(false);
        }

        //set all objects in array to 1.0f
        for (int i = 0; i < bluethingmanipulate.Length; i++)
        {
            bluethingmanipulate[i].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        //Get Gameobjects for panel and camera and disable them
        //wait 5 seconds
        //Enable said gameobjects
        yield return new WaitForSeconds(5.0f);

        //set all objects in array to 0.3f
        for (int i = 0; i < bluethingmanipulate.Length; i++)
        {
            bluethingmanipulate[i].color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        }
        Random_Number = Random.Range(20, 60);


    }
    public IEnumerator Jumpscare_Reset()
    {
        yield return new WaitForSeconds(1.0f);
        Bluethinganimator.ResetTrigger("Lights_Active");
        Bluethinganimator.SetTrigger("Reset");
        Blue_Thing_Outside.SetActive(false);
        Blue_Thing_Outside_TOF = false;
        yield return new WaitForSeconds(2.5f);
        Bluethinganimator.ResetTrigger("Reset");

    }

    void bluethingappear()
    {
        whitelines();
        if (!Blue_Thing_Outside_TOF)
        {
            Blue_Thing_Outside_TOF = true;
            Blue_Thing_Cams.enabled = false;
            StartCoroutine("Jumpscare_Coroutine");
        } 
    }
    void whitelines()
    {
        if (camacc.cams)
        {
            camstat.activate = true;
        }
    }
}
