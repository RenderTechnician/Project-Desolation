using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {
    public SpriteRenderer flashlight;
    public Sprite[] backroundstagespr;
    public int backroundstage;
    public bool state;
    public bool mainareastate;
    public bool mainareastate2;
    public bool mainareastate3;
    public bool mainareastate4;
    public bool leftorright1;
    public int rgbvalue;
    public int arrowopacity;
    public int arrowopacity2;
    public int arrowopacity3;
    public int whichselect;
    public SpriteRenderer office;
    public SpriteRenderer outside;
    public Image arrow1;
    public Image arrow2;
    public Image arrow3;
    public AudioSource run;
    public AudioSource keyboardtap;
    public Animator allanimations;
    public InputField input;
    public Text computer;
    // Use this for initialization
    void Start() {
        computer.text = "Welcome " + PlayerPrefs.GetString("playername1") + ", please type your commands below. If you require assistance please type !help.";
    }

    // Update is called once per frame
    void Update() {
        fading();
        keyboard();
        transparency();
        stopwalk();
        switchframe();
        Vector3 mouse = (Input.mousePosition);
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        flashlight.transform.position = new Vector3((x / 100) - 6.0f, (y / 100) - 5.0f, 0.0f);
        office.color = new Color((rgbvalue / 50.0f), (rgbvalue / 50.0f), (rgbvalue / 50.0f), 255.0f);
        outside.color = new Color((rgbvalue / 50.0f), (rgbvalue / 50.0f), (rgbvalue / 50.0f), 255.0f);
        arrow1.color = new Color(255.0f, 255.0f, 255.0f, (arrowopacity / 5.0f));
        arrow2.color = new Color(255.0f, 255.0f, 255.0f, (arrowopacity2 / 5.0f));
        arrow3.color = new Color(255.0f, 255.0f, 255.0f, (arrowopacity3 / 5.0f));
        office.GetComponent<SpriteRenderer>().sprite = backroundstagespr[backroundstage];
        computer.color = new Color(255.0f, 255.0f, 255.0f, (arrowopacity3 / 5.0f));
        computer.text = input.text;
    }
public void changestate()
    {
        if (state == true)
        {
            state = false;
        }
        else
        {
            state = true;
        }
    }
    void fading()
    {
        if (state == true && rgbvalue > 0)
        {
            rgbvalue--;
        }
        else if(state == false && 50 > rgbvalue)
        {
            rgbvalue++;
        }
        else if(state == true && rgbvalue == 0)
        {
            rgbvalue++;
            backroundstage = whichselect;
            state = false;
        }
    }
    void transparency()
    {
        //To Main Area
        if (mainareastate == false && arrowopacity > 0 && whichselect == 0)
        {
            arrowopacity--;
        }
        else if (mainareastate == true && 5 > arrowopacity && whichselect == 0)
        {
            arrowopacity++;
        }
        // To Office
       else if (mainareastate2 == false && arrowopacity2 > 0 && whichselect == 1)
        {
            arrowopacity2--;
        }
        else if (mainareastate2 == true && 5 > arrowopacity2 && whichselect == 1)
        {
            arrowopacity2++;
        }
        // To monitor room
        else if (mainareastate3 == false && arrowopacity3 > 0 && whichselect == 1)
        {
            arrowopacity3--;
        }
        else if (mainareastate3 == true && 5 > arrowopacity3 && whichselect == 1)
        {
            arrowopacity3++;
        }
    }
    void stopwalk()
    {
        if(rgbvalue == 50)
        {
            run.Stop();
        }
    }
    public void mainarefadein()
    {
        if(backroundstage == 0) { mainareastate = true;}
        if (backroundstage == 1 && arrowopacity2 != 0) { mainareastate3 = false; }
        if (backroundstage == 1 && arrowopacity3 != 0) { mainareastate2 = false; }  
        if (backroundstage == 1 && arrowopacity3 == 0) { mainareastate2 = true;}
        if(backroundstage == 1 && leftorright1 == true && arrowopacity2 == 0) { mainareastate3 = true; }

    }
    public void mainareafadeout()
    {
        if (backroundstage == 0) { mainareastate = false; }
        if (backroundstage == 1) { mainareastate2 = false; }
        if (backroundstage == 1 && arrowopacity2 != 0) { mainareastate3 = false; }
    }
    public void stage1()
    {
        state = true;
        arrow1.enabled = false;
        arrow2.enabled = true;
        arrow3.enabled = true;
        whichselect = 1;
        run.Play();
    }
    public void stage0()
    {
        state = true;
        arrow1.enabled = true;
        arrow2.enabled = false;
        arrow3.enabled = false;
        whichselect = 0;
        run.Play();
    }
    public void stage2()
    {
        state = true;
        arrow1.enabled = false;
        arrow2.enabled = false;
        arrow3.enabled = false;
        whichselect = 2;
        run.Play();
    }
    void switchframe()
    {
        if(rgbvalue == 0 && whichselect == 1)
        {
            allanimations.SetTrigger("0 to 1");
            allanimations.ResetTrigger("1 to 0");
            allanimations.ResetTrigger("right to 0");
        }
        if (rgbvalue == 0 && whichselect == 0)
        {
            allanimations.ResetTrigger("0 to 1");
            allanimations.SetTrigger("1 to 0");
            allanimations.SetTrigger("right to 0");
        }
        if (rgbvalue == 0 && whichselect == 2)
        {
            allanimations.ResetTrigger("0 to 1");
            allanimations.SetTrigger("1 to 0");
            allanimations.SetTrigger("right to monitor");
            flashlight.enabled = false;
        }
    }
    public void swingright1()
    {
        if (whichselect == 1)
        {
            leftorright1 = true;
            allanimations.SetTrigger("statictoright");
            allanimations.ResetTrigger("right to swing");
        }
    }
    public void swingleft1()
    {
        if (whichselect == 1)
        {
            leftorright1 = false;
            allanimations.SetTrigger("right to swing");
            allanimations.ResetTrigger("statictoright");
        }
    }
    void keyboard()
    {
        if (Input.anyKeyDown && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2) && whichselect == 2)
        {
            keyboardtap.Play();
        }
    }
}
