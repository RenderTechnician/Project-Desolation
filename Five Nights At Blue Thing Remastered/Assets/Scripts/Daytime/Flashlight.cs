using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {
    public SpriteRenderer flashlight;
    public int backroundstage;
    public bool state;
    public bool mainareastate;
    public bool mainareastate2;
    public bool mainareastate3;
    public bool mainareastate4;
    public bool leftorright1;
    public bool hidevisibility;
    public bool whichwaylooking1;
    public bool whichwaylooking2;
    public bool delaybool;
    public int rgbvalue;
    public int hidebuttontrans;
    public int arrowopacity;
    public int arrowopacity2;
    public int arrowopacity3;
    public int hideopacity;
    public int whichselect;
    public int solarbattery;
    public int returndelaydesk;
    public int delaytrans;
    public SpriteRenderer office;
    public SpriteRenderer outside;
    public Image arrow1;
    public Image arrow2;
    public Image arrow3;
    public Image hide;
    public AudioSource run;
    public Animator allanimations;
    public InputField input;
    public Text computer;
    public GameObject inputparent;
    public GameObject textboundary;
    public RectTransform compterrect;
    public PCTextScript2 pct2;

    // Use this for initialization
    void Start() {
        computer.text = "Welcome " + PlayerPrefs.GetString("playername1") + ", please type your commands below. If you require assistance please type !help." +
            " Remember to highlight your input box before inputting data";
    }

    // Update is called once per frame
    void Update() {
        fading();
        transparency();
        stopwalk();
        switchframe();
        hidevis();
        monitordelay();
        Vector3 mouse = (Input.mousePosition);
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        flashlight.transform.position = new Vector3((x / 100) - 6.0f, (y / 100) - 5.0f, 0.0f);
        office.color = new Color((rgbvalue / 50.0f), (rgbvalue / 50.0f), (rgbvalue / 50.0f), 255.0f);
        outside.color = new Color((rgbvalue / 50.0f), (rgbvalue / 50.0f), (rgbvalue / 50.0f), 255.0f);
        arrow1.color = new Color(255.0f, 255.0f, 255.0f, (arrowopacity / 5.0f));
        arrow2.color = new Color(255.0f, 255.0f, 255.0f, (arrowopacity2 / 5.0f));
        arrow3.color = new Color(255.0f, 255.0f, 255.0f, (arrowopacity3 / 5.0f));
        hide.color = new Color(255.0f, 255.0f, 255.0f, (hidebuttontrans / 5.0f) / 10.0f);
        compterrect.sizeDelta = new Vector2(510.0f, 200.0f + (pct2.size * 100));
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
            hidebuttontrans--;
        }
        else if (state == false && 50 > rgbvalue)
        {
            rgbvalue++;
            hidebuttontrans++;
        }
        else if (state == true && rgbvalue == 0 && whichselect != 2)
        {
            rgbvalue++;
            backroundstage = whichselect;
            state = false;
            inputparent.SetActive(false);
            textboundary.SetActive(false);
        }
        else if (state == true && rgbvalue == 0 && whichselect == 2)
        {
            rgbvalue++;
            backroundstage = whichselect;
            state = false;
            computer.enabled = true;
            inputparent.SetActive(true);
            textboundary.SetActive(true);
            hide.enabled = true; }
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
        if (rgbvalue == 50)
        {
            run.Stop();
        }
    }
    public void mainarefadein()
    {
        if (backroundstage == 0) { mainareastate = true; }
        if (backroundstage == 1) { mainareastate2 = true; }
    }
    public void mainarefadein2()
    {
        if (backroundstage == 1 && leftorright1 == true) { mainareastate3 = true; }
    }
    public void mainareafadeout()
    {
        if (backroundstage == 0) { mainareastate = false; }
        if (backroundstage == 1) { mainareastate2 = false; }
        if (backroundstage == 1) { mainareastate3 = false; }
    }
    public void stage1()
    {
        state = true;
        arrow1.enabled = false;
        arrow2.enabled = true;
        arrow3.enabled = true;
        hide.enabled = false;
        whichselect = 1;
        run.Play();
    }
    public void stage0()
    {
        state = true;
        arrow1.enabled = true;
        arrow2.enabled = false;
        arrow3.enabled = false;
        hide.enabled = false;
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
        if (rgbvalue == 0 && whichselect == 1)
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
    public void intobutton1()
    {
        hidevisibility = true;

    }
    public void outofbutton1()
    {
        hidevisibility = false;
    }
    void hidevis()
    {
        if(hidevisibility == true && whichselect == 2 && 50 > hidebuttontrans)
        {
            hidebuttontrans = hidebuttontrans + 5;
        }
        else if(hidevisibility == false && whichselect == 2 && hidebuttontrans > 0)
        {
            hidebuttontrans = hidebuttontrans - 5;
        }
    }
    public void desk5atrig()
    {
        if (whichwaylooking1 == true)
        {
            whichwaylooking1 = false;
            allanimations.SetTrigger("comeupon");
            allanimations.SetTrigger("comeupoff");
            allanimations.ResetTrigger("hideon");
            allanimations.ResetTrigger("hideoff");
        }
        else
        {
            whichwaylooking1 = true;
            allanimations.SetTrigger("hideon");
            allanimations.SetTrigger("hideoff");
            allanimations.ResetTrigger("comeupon");
            allanimations.ResetTrigger("comeupoff");
        }
    }
    public void lookinglightoff()
    {
        if (whichwaylooking2 == true)
        {
            whichwaylooking2 = false;
            allanimations.SetTrigger("lookleftoff");
            allanimations.SetTrigger("looklefton");
            allanimations.ResetTrigger("lookrightoff");
            allanimations.ResetTrigger("lookrighton");
            delaybool = false;
        }
        else
        {
            whichwaylooking2 = true;
            allanimations.SetTrigger("lookrightoff");
            allanimations.SetTrigger("lookrighton");
            allanimations.ResetTrigger("lookleftoff");
            allanimations.ResetTrigger("looklefton");
            delaybool = true;
            delaytrans = 40;
        }
    }
    void monitordelay()
    {
        if(delaytrans > 29 && delaybool == true)
        {
            input.enabled = false;
            computer.enabled = false;
        }
        else if(1 > delaytrans && delaybool == false && whichselect == 2)
        {
            computer.enabled = true;
            input.enabled = true;
            delaybool = false;
        }
        else if(delaybool == false && delaytrans > 0)
        {
            delaytrans--;
        }
    }
}
