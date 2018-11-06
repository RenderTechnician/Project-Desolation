using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonstrouAI : MonoBehaviour {
    public PCTextScript2 PCT2ref;

    public bool isactive , isatoffice;

    public int countdowntooffice;

    public Animator allanimations , monstroujump;

    public Flashlight flashlight;
    public AudioSource squekin;
    public AudioSource squeakout;
    public int leavebuffer;
    public int scaretrigger;
    public SpriteRenderer jumpscareM;
    public int scaredelay;
    public Canvas overlaycanvas1;
    public AudioSource scream;
    // Use this for initialization
    void Start () {
        countdowntooffice = 1000;
    }
	
	// Update is called once per frame
	void Update () {
        movementstage1();
	if(PCT2ref.noisei > 1000)
        {
            isactive = true;
        }	
	}
    void movementstage1()
    {
        
        if(isactive == true && isatoffice == false)
        {
            if(countdowntooffice > 0)
            {
                countdowntooffice--;
                 if (countdowntooffice == 750)
                {
                    squekin.Play();
                }
            }
            //possibly * this by the night value to increase difficulty over time
            else if (1 > countdowntooffice && flashlight.whichwaylooking1 == true)
            {
                leavebuffer++;
               if (leavebuffer ==1 ) { allanimations.SetTrigger("monstroupeekinon"); allanimations.SetTrigger("monstroupeekinoff"); }
               else if (leavebuffer > 240) //30 moving to look at player, 120 looking at player, 30 moving away, 60 between going behind wall and leaving
                {
                    PCT2ref.noisei = 0;
                    squeakout.Play();
                    leavebuffer = 0;
                    countdowntooffice = 1000;
                    isactive = false;
                    allanimations.ResetTrigger("monstroupeekinon");
                    allanimations.ResetTrigger("monstroupeekinoff");
                }
            }
            else if (1 > countdowntooffice && flashlight.whichwaylooking1 == false)
            {
                isatoffice = true;
            }
        }
        if(isatoffice == true)
        {
            scaredelay++;
            if (scaredelay > 450 && flashlight.delaytrans == 0)
            {
                scaretrigger++;
                jumpscareM.enabled = true;
                overlaycanvas1.enabled = false;
                monstroujump.SetTrigger("jumpscare_Trigger");
                if (scaretrigger == 1) { scream.Play(); }
               else if (scaretrigger > 50)
                {
                    scream.Stop();
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}
