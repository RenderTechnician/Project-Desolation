using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {

    public SpriteRenderer flashlight , kevbackdrop , office , outside;

    public int backroundstage;

    public bool state;

    public bool mainareastate , mainareastate2 , mainareastate3 , mainareastate4;

    public bool leftorright1;

    public bool hidevisibility , hidevisibility2;

    public bool whichwaylooking1 , whichwaylooking2;

    public bool delaybool;
    public int rgbvalue;
    public int hidebuttontrans;
    public int hidebuttontrans2;
    public int hideopacity;
    public int whichselect;
    public int solarbattery;
    public int returndelaydesk;
    public int delaytrans;

    public Image turnaround , hide;

    public AudioSource run , rustle;

    public Animator allanimations;

    public InputField input;

    public Text computer;

    public GameObject inputparent , textboundary, turnbutton;

    public RectTransform compterrect;

    public PCTextScript2 pct2;

    public MonstrouAI monst;
    
    public GameObject Kevinparent;

    // Use this for initialization
    void Start() {
        //definining elements 
        arrow1 = GameObject.Find("To_Main_Area_Button");
        //Computer default text
        computer.text = "Welcome " + PlayerPrefs.GetString("playername1") + ", please type your commands below. If you require assistance please type !help." +
            " Remember to highlight your input box before inputting data";
    }

    // Update is called once per frame
    void Update() {

        // Calling additional methods
        fading(); stopwalk(); switchframe(); hidevis(); hidevis2(); monitordelay();
        Vector3 mouse = (Input.mousePosition);
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        flashlight.transform.position = new Vector3((x / 100) - 4.5f, (y / 100) - 3.0f, 0.0f);
        kevbackdrop.color = office.color = outside.color = new Color((rgbvalue / 50.0f), (rgbvalue / 50.0f), (rgbvalue / 50.0f), 255.0f);
        hide.color = new Color(255.0f, 255.0f, 255.0f, (hidebuttontrans / 5.0f) / 10.0f);
        turnaround.color = new Color(255.0f, 255.0f, 255.0f, (hidebuttontrans2 / 5.0f) / 10.0f);
        compterrect.sizeDelta = new Vector2(510.0f, 200.0f + (pct2.size * 100));
        if(whichselect == 3) { turnbutton.SetActive(false); }
        
    }

    public void changestate()
    {
        state = !state;
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

    //Arrow References
   GameObject arrow1;

   public GameObject arrow2 , arrow3 , arrow4;

    public void stage1()
    {
        state = true;
        arrow1.SetActive(false);
        arrow2.SetActive(true);
        hide.enabled = false;
        whichselect = 1;
        run.Play();
    }

    public void stage0()
    {
        state = true;
        arrow1.SetActive(true);
        arrow2.SetActive(false);
        hide.enabled = false;
        whichselect = 0;
        run.Play();
    }

    public void stage2()
    {
        state = true;
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);
        whichselect = 2;
        run.Play();
    }

    public void stage3()
    {
        GameObject.Find("KevinRoom").GetComponent<SpriteRenderer>().enabled = true;
        state = true;
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);
        whichselect = 3;
        run.Play();
    }

    void switchframe()
    {
        if (rgbvalue == 0 && whichselect == 1) // when the screen goes black load Main Area
        {
            allanimations.SetTrigger("0 to 1");
            allanimations.ResetTrigger("1 to 0");
            allanimations.ResetTrigger("right to 0");
            outside.enabled = false;
            arrow4.SetActive(true);
        }
        if (rgbvalue == 0 && whichselect == 0) // when screen goes black load main office
        {
            allanimations.ResetTrigger("0 to 1");
            allanimations.SetTrigger("1 to 0");
            allanimations.SetTrigger("right to 0");
            outside.enabled = true;
            
        }
        if (rgbvalue == 0 && whichselect == 2) // when screen goes black load monitor room
        {
            arrow4.SetActive(true);
            allanimations.ResetTrigger("0 to 1");
            allanimations.SetTrigger("1 to 0");
            allanimations.SetTrigger("right to monitor");
            flashlight.enabled = false;
            arrow4.SetActive(false);
        }
        if (rgbvalue == 0 && whichselect == 3) // when screen goes black load Kevin room
        {
            allanimations.ResetTrigger("0 to 1");
            allanimations.ResetTrigger("1 to 0");
            flashlight.enabled = false;
            office.enabled = false;
            Kevinparent.SetActive(true);
        }
    }

    public void swingright1()
    {
        if (whichselect == 1)
        {
            leftorright1 = true;
            allanimations.SetTrigger("statictoright");
            allanimations.ResetTrigger("right to swing");
            arrow3.SetActive(true);
            arrow4.SetActive(false);
        }
    }

    public void swingleft1()
    {
        if (whichselect == 1)
        {
            leftorright1 = false;
            allanimations.SetTrigger("right to swing");
            allanimations.ResetTrigger("statictoright");
            arrow3.SetActive(false);
            arrow4.SetActive(true);
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

    public void intobutton2()
    {
        hidevisibility2 = true;

    }

    public void outofbutton2()
    {
        hidevisibility2 = false;
    }

    void hidevis2()
    {
        if (hidevisibility2 == true && whichselect == 2 && 50 > hidebuttontrans2)
        {
            hidebuttontrans2 = hidebuttontrans2 + 5;
        }
        else if (hidevisibility2 == false && whichselect == 2 && hidebuttontrans2 > 0)
        {
            hidebuttontrans2 = hidebuttontrans2 - 5;
        }
    }

    public void desk5atrig()
    {
        rustle.Play();
        if (whichwaylooking1 == true)
        {
            whichwaylooking1 = false;
            allanimations.SetTrigger("comeupon");
            allanimations.SetTrigger("comeupoff");
            allanimations.ResetTrigger("hideon");
            allanimations.ResetTrigger("hideoff");
            delaybool = false;
        }
        else
        {
            whichwaylooking1 = true;
            allanimations.SetTrigger("hideon");
            allanimations.SetTrigger("hideoff");
            allanimations.ResetTrigger("comeupon");
            allanimations.ResetTrigger("comeupoff");
            delaybool = true;
            delaytrans = 40;
            if (pct2.siphacc == true)
            {
                pct2.siphacc = false;
                computer.text = computer.text + "\n" + "\n" + "<color=red>battery siphon quit unexpectedly, monitor uses optic sensors to ensure optimal power efficiency. Looking away from monitor will" +
                    "put it into a low power state and cancel all processes. For full details please contact your administrator.</color>";
            }
        }
    } //method which dictates whether the player hides or surfaces when pressing the appropriate button

    public void lookinglightoff()
    {
        if (whichwaylooking2 == true && monst.isatoffice == false)
        {
            whichwaylooking2 = false;
            allanimations.SetTrigger("lookleftoff");
            allanimations.SetTrigger("looklefton");
            allanimations.ResetTrigger("lookrightoff");
            allanimations.ResetTrigger("lookrighton");
            delaybool = false;
        }
        else if (whichwaylooking2 == false && monst.isatoffice == false)
        {
            whichwaylooking2 = true;
            allanimations.SetTrigger("lookrightoff");
            allanimations.SetTrigger("lookrighton");
            allanimations.ResetTrigger("lookleftoff");
            allanimations.ResetTrigger("looklefton");
            delaybool = true;
            delaytrans = 40;

            if(pct2.siphacc == true)
            {
                pct2.siphacc = false;
                computer.text = computer.text + "\n" + "\n" + "<color=red>battery siphon quit unexpectedly, monitor uses optic sensors to ensure optimal power efficiency. Looking away from monitor will" +
                    "put it into a low power state and cancel all processes. For full details please contact your administrator.</color>";
            }
        }
        else if(whichwaylooking2 == false && monst.isatoffice == true)
        {
            whichwaylooking2 = true;
            allanimations.SetTrigger("lookrightmonstrouoff");
            allanimations.ResetTrigger("lookleftoff");
            allanimations.ResetTrigger("lookleftmonstrouoff");
            allanimations.SetTrigger("lookrightmonstrouon");
            allanimations.ResetTrigger("lookleftmonstrouon");
            delaybool = true;
            delaytrans = 40;
            if (pct2.siphacc == true)
            {
                pct2.siphacc = false;
                computer.text = computer.text + "\n" + "\n" + "<color=red>battery siphon quit unexpectedly, monitor uses optic sensors to ensure optimal power efficiency. Looking away from monitor will" +
                    "put it into a low power state and cancel all processes. For full details please contact your administrator.</color>";
            }
        }
        else if (whichwaylooking2 == true && monst.isatoffice == true)
        {
            whichwaylooking2 = false;
            allanimations.SetTrigger("lookleftmonstrouoff");
            allanimations.SetTrigger("lookleftoff");
            allanimations.ResetTrigger("lookrightmonstrouoff");
            allanimations.SetTrigger("lookleftmonstrouon");
            allanimations.ResetTrigger("lookrightmonstrouon");
            delaybool = false;
        }
    }

    void monitordelay()
    {
        if(delaytrans > 29 && delaybool == true)
        {
            inputparent.SetActive(false);
            computer.enabled = false;
            pct2.beforetext.enabled = false;
        }
        else if(1 > delaytrans && delaybool == false && whichselect == 2)
        {
            computer.enabled = true;
            inputparent.SetActive(true);
            pct2.beforetext.enabled = true;
            delaybool = false;
            rustle.Stop();
        }
        else if(delaybool == false && delaytrans > 0)
        {
            delaytrans--;
        }
    }
}
