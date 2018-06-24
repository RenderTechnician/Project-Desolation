using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour {
    public SpriteRenderer monstrouspr;
    public SpriteRenderer monstroudesk;
    public SpriteRenderer desk;
    public Camera_Animation camacc;
    public Camerastatus camstat;
    public SoundManager soundmanager;
    public Fadeoffice fadeoffice;
    public Cutpower cutpower;
    public Lights lights;
    public Door door;
    public Animator monstroanim;
    public int monstroucountdown;
    public int whereishe;
    public int stage;
    public int swingbuffer;
    public TextManager textmanager;
    public AudioSource scare;
    public bool scarebool;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        triggers();
        show();
        stage2();
        triggers2();
        stage3();
        triggers3();
        stage4();
        triggers4();
        stage5();
        stage6();
        flasher();
    }
    void triggers()
    {
        if (camacc.cams == true && camstat.lightup == false && stage == 0)
        {
            monstroanim.SetTrigger("start to off (stage 1)");
            monstroanim.SetTrigger("on to off (stage 1)");
            monstroanim.ResetTrigger("off to on (stage 1)");
        }
        else if (camacc.cams == true && camstat.lightup == true && stage == 0)
        {
            monstroanim.ResetTrigger("start to off (stage 1)");
            monstroanim.SetTrigger("off to on (stage 1)");
            monstroanim.ResetTrigger("on to off (stage 1)");
        }
        else if (camacc.cams == false)
        {
            monstrouspr.enabled = false;
        }
    }
    void show()
    {
        if (whereishe == camstat.count && camacc.cams == true && 3 > stage)
        {
            monstrouspr.enabled = true;
            monstroucountdown = 2000;
        }
        else if (whereishe == camstat.count && camacc.cams == false && 3 > stage)
        {
            monstrouspr.enabled = false;
            monstroucountdown = monstroucountdown - textmanager.whichday;
        }
        else if (whereishe != camstat.count && camacc.cams == true && 3 > stage)
        {
            monstrouspr.enabled = false;
            monstroucountdown = monstroucountdown - textmanager.whichday;
        }
        else if (whereishe != camstat.count && camacc.cams == false && 3 > stage)
        {
            monstrouspr.enabled = false;
            monstroucountdown = monstroucountdown - textmanager.whichday;
        }
        else if(lights.lights == true && stage == 3)
        {
            monstrouspr.enabled = true;
            monstroucountdown = 1000;
        }
        else if (lights.lights == false && stage == 3)
        {
            monstroucountdown = monstroucountdown - textmanager.whichday;
        }
    }
    void stage2()
    {
        if(1 > monstroucountdown && stage == 0)
        {
            monstroucountdown = 2000;
            stage = 1;
            monstroanim.SetTrigger("on to start (stage 1)");
            monstroanim.SetTrigger("off to start (stage 1)");
            monstroanim.ResetTrigger("off to on (stage 1)");
            monstroanim.ResetTrigger("start to off (stage 1)");
            monstroanim.ResetTrigger("start to on (stage 1)");
            monstroanim.ResetTrigger("on to off (stage 1)");
        }
    }
    void triggers2()
    {
        if (camacc.cams == true && camstat.lightup == false && stage == 1)
        {
            monstroanim.SetTrigger("start to off (stage 2)");
            monstroanim.SetTrigger("on to off (stage 2)");
            monstroanim.ResetTrigger("off to on (stage 2)");
        }
        else if (camacc.cams == true && camstat.lightup == true && stage == 1)
        {
            monstroanim.SetTrigger("start to on (stage 2)");
            monstroanim.SetTrigger("off to on (stage 2)");
            monstroanim.ResetTrigger("on to off (stage 2)");
        }
    }
    void stage3()
    {
        if (1 > monstroucountdown && stage == 1 )
        {
            monstroucountdown = 2000;
            stage = 2;
            whereishe = 4;
            monstroanim.SetTrigger("on to start (stage 2)");
            monstroanim.SetTrigger("off to start (stage 2)");
            monstroanim.ResetTrigger("off to on (stage 2)");
            monstroanim.ResetTrigger("start to off (stage 2)");
            monstroanim.ResetTrigger("start to on (stage 2)");
            monstroanim.ResetTrigger("on to off (stage 2)");
        }
    }
    void triggers3()
    {
        if (camacc.cams == true && camstat.lightup == false && stage == 2)
        {
            monstroanim.SetTrigger("start to off (stage 3)");
            monstroanim.SetTrigger("on to off (stage 3)");
            monstroanim.ResetTrigger("off to on (stage 3)");
        }
        else if (camacc.cams == true && camstat.lightup == true && stage == 2)
        {
            monstroanim.SetTrigger("start to on (stage 3)");
            monstroanim.SetTrigger("off to on (stage 3)");
            monstroanim.ResetTrigger("on to off (stage 3)");
        }
    }
    void stage4()
    {
        if (1 > monstroucountdown && stage == 2)
        {
            monstroucountdown = 2000;
            stage = 3;
            whereishe = 0;
            monstroanim.SetTrigger("on to start (stage 3)");
            monstroanim.SetTrigger("off to start (stage 3)");
            monstroanim.ResetTrigger("off to on (stage 3)");
            monstroanim.ResetTrigger("start to off (stage 3)");
            monstroanim.ResetTrigger("start to on (stage 3)");
            monstroanim.ResetTrigger("on to off (stage 3)");
            monstrouspr.sortingOrder = -1;
            if (lights.lights == true) { lights.lightbutt(); soundmanager.Lightbool = false; soundmanager.Lightbuzz.Stop(); }
        }

    }
    void triggers4()
    {
        if (lights.lights == false && stage == 3)
        {
            monstroanim.SetTrigger("start to off (stage 4)");
            monstroanim.SetTrigger("on to off (stage 4)");
            monstroanim.ResetTrigger("off to on (stage 4)");
        }
        else if (lights.lights == true && stage == 3)
        {
            monstroanim.SetTrigger("start to on (stage 4)");
            monstroanim.SetTrigger("off to on (stage 4)");
            monstroanim.ResetTrigger("on to off (stage 4)");
        }
    }
    void stage5()
    {
        //goes back to room
        if (1 > monstroucountdown && stage == 3 && door.trigger == true)
        {
            if (lights.lights == true) { lights.lightbutt(); soundmanager.Lightbool = false; soundmanager.Lightbuzz.Stop(); }
        }
        //kill player
        else if (1 > monstroucountdown && stage == 3 && door.trigger == false)
        {
            monstrouspr.enabled = false;
            stage = 4;
            if (lights.lights == true) { lights.lightbutt(); soundmanager.Lightbool = false; soundmanager.Lightbuzz.Stop(); }
        }
    }
    void stage6()
    {
        if (camacc.cams == true && stage == 4)
        {
            monstroudesk.enabled = true;
            desk.enabled = false;
        }
        if (fadeoffice.config == true && stage == 4 && 14 > swingbuffer)
        {
            swingbuffer++;
        }
        else
        {
            if (fadeoffice.config == true && stage == 4 && 14 == swingbuffer)
            {
                monstroudesk.enabled = true;
                desk.enabled = false;
            }
        }
    }
    void flasher()
    {
        if (5 > monstroucountdown && stage == 0 && camacc.cams == true)
        {
            camstat.activate = true;
        }
        else if (5 > monstroucountdown && stage == 1 && camacc.cams == true)
        {
            camstat.activate = true;
        }
        else if (5 > monstroucountdown && stage == 2 && camacc.cams == true)
        {
            camstat.activate = true;
        }

    }

    public void scaretrigger()
    {
        if(scarebool == false && cutpower.toggle == false && stage == 3)
        {
            scare.Play();
            scarebool = true;
        }
    }
}

