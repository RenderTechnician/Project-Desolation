using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KevLights : MonoBehaviour {
    public bool statusoflights, sitsoundbool;

    public Animator KevLightsAnim;

    AudioSource Kevinsit;

    maintenencepanel panelref;

	// Use this for initialization
	void Start () {
        panelref = GameObject.Find("Scriptmanager").GetComponent<maintenencepanel>();
        Kevinsit = GameObject.Find("408094__biawinter__sit-on-chair").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	if(panelref.img == 1)
        {
            sitsoundbool = false;
        }	
	}

    public void triggeranim()
    {
        statusoflights = !statusoflights;
        if (statusoflights)
        {
            KevLightsAnim.SetTrigger("CutPower");
            KevLightsAnim.ResetTrigger("RestorePower");
            InvokeRepeating("KevinReset", 1.5f, 1.5f);
        }
        else
        {
            KevLightsAnim.ResetTrigger("CutPower");
            KevLightsAnim.SetTrigger("RestorePower");
            CancelInvoke("KevinReset");
        }
    }

    void KevinReset()
    {
        if(panelref.img > -1)
        {
            Debug.Log("powerreduced");
            panelref.aware = 0;
            panelref.img--;
        }
        else if(!sitsoundbool && panelref.img == -1)
        {
            Kevinsit.Play();
            sitsoundbool = true;
        }

    }
}
