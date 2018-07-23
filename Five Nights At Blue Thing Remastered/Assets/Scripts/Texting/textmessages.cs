using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textmessages : MonoBehaviour {
    public AudioSource blip;
    public AudioSource modem;
    public AudioSource send;
    public bool switcher;
    public Canvas inputcanvas;
    public int pickline;
    public int pickline2;
    public int time;
    public int state;
    public int whichtext;
    public Text textline1;
    public Text namedisplay;
    public Text connection;
    public InputField input;
    public string[] sentence1part1;
    public string[] sentence1part2;
    public string[] Sentence2;
    public string name; // determines what the users name is
    public Text BossLine1;
    public Text Playerline1;
    public Text BossLine2;

    // Use this for initialization
	void Start () {
        textline1.text = "System: " + "\n" + "\n" + "Thankyou for signing up with Rippedtoad Communication Service, please enter your name to verify your identity."
            + "\n" + "----------------------------------------------------------------------------------------------------------------";
        input.text = "Enter Your Name, then press Enter";
	}
	
	// Update is called once per frame
	void Update () {
        stage1();
        stage2();
        camscroller();
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
            inputcanvas.enabled = true;
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
            inputcanvas.enabled = false;
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
        if(state == 4  && time == 299)
        {
            pickline = Random.Range(0, sentence1part1.Length);
            pickline2 = Random.Range(0, sentence1part1.Length);
            BossLine1.text = "BOSS" +"\n" + "--------------------------------------------------------------------------" + "\n"
                + sentence1part1[pickline] + " " + name + " ," + sentence1part2[pickline2];
            BossLine1.enabled = true;
            switcher = true;
            time = 300;
            blip.Play();
            inputcanvas.enabled = true;
            state = 5;
        }
        if (Input.GetKeyDown(KeyCode.Return) && state == 5)
        {
            state = 5;
            send.Play();
            Playerline1.enabled = true;
            Playerline1.text = "You" + "\n" + "--------------------------------------------------------------------------" + "\n" + input.text;
            switcher = false;
            time = 0;
        }
        if(time == 299 && state == 5)
        {
            BossLine2.enabled = true;
            BossLine2.text = "BOSS" + "\n" + "--------------------------------------------------------------------------" + "\n" + Sentence2[pickline];
            blip.Play();
            PlayerPrefs.SetString("playername1", name);
        }

    }
    void camscroller()
    {

    }
}
public class values { 
}
