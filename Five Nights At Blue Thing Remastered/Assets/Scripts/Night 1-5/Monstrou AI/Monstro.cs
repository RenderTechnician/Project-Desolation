using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour {
    public SpriteRenderer monstrouspr;
    public Camera_Animation camacc;
    public Camerastatus camstat;
    public Animator monstroanim;
    public int monstroucountdown;
    public int whereishe;
    public int stage;
    public TextManager textmanager;
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
        if (whereishe == camstat.count && camacc.cams == true)
        {
            monstrouspr.enabled = true;
            monstroucountdown = 2000;
        }
        else if (whereishe == camstat.count && camacc.cams == false)
        {
            monstrouspr.enabled = false;
            monstroucountdown = monstroucountdown - textmanager.whichday;
        }
        else if (whereishe != camstat.count && camacc.cams == true)
        {
            monstrouspr.enabled = false;
            monstroucountdown = monstroucountdown - textmanager.whichday;
        }
        else if (whereishe != camstat.count && camacc.cams == false )
        {
            monstrouspr.enabled = false;
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
            monstroanim.ResetTrigger("start to off (stage 2)");
            monstroanim.SetTrigger("off to on (stage 2)");
            monstroanim.ResetTrigger("on to off (stage 2)");
        }
    }
    void stage3()
    {
        if (1 > monstroucountdown && stage == 1)
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
            monstroanim.ResetTrigger("start to off (stage 3)");
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
        }
    }
}

