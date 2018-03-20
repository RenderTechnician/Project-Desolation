using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textmessages : MonoBehaviour {
    //audiosources
    public AudioSource blip;
    public AudioSource send;
    public AudioSource modem;
    //ints
    public int time;
    public int whichtext;
    public int state;
    //bools
    public bool switcher;
    //strings
    public string name;
    // 
    string[] chatline1 = {"welcome"};
    public Text textline1;
    public Text namedisplay;
    public Text connection;
    public InputField input;
    // Use this for initialization
	void Start () {
        name = "Will";
        textline1.text = "System: " + "\n" + "\n" + "Thankyou for signing up with Rippedtoad Communication Service, please enter your name to verify your identity."
            + "\n" + "----------------------------------------------------------------------------------------------------------------";
        input.text = "Enter Your Name, then press Enter";
	}
	
	// Update is called once per frame
	void Update () {
        stage1();
	}
    void stage1()
    {
        if (switcher == false)
        {
            time++;
        }
        if (time > 300 && state == 0)
        {
            textline1.enabled = true;
            switcher = true;
            blip.Play();
            state = 1;
            time = 0;
        }
        if (Input.GetKeyDown(KeyCode.Return) && state == 1)
        {
            name = input.text;
            input.text = "";
            namedisplay.text = "Hello there " + name + " Please wait whilst we log you in.";
            send.Play();
            Debug.Log("success");
            namedisplay.enabled = true;
            state = 2;
            switcher = false;
        }
        if (state == 2 && time == 120)
        {
            connection.enabled = true;
            modem.Play();
        }
        if (state == 2 && time > 1800)
        {
            connection.text = "Connection succesful, press any key to continue";
            modem.Stop();
            time = 0;
            state = 3;
        }
        if (Input.anyKeyDown && state == 3)
        {
            connection.enabled = false;
            namedisplay.enabled = false;
            textline1.enabled = false;
            state = 4;
            send.Play();
        }
    }
    void stage2()
    {
        if(state == 4)
        {

        }
    }
}
