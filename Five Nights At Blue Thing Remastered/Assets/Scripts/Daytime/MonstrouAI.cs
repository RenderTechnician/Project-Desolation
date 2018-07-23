using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstrouAI : MonoBehaviour {
    public PCTextScript2 PCT2ref;
    public bool isactive;
    public bool isatoffice;
    public int countdowntooffice;

	// Use this for initialization
	void Start () {
        countdowntooffice = 2000;
    }
	
	// Update is called once per frame
	void Update () {
        movementstage1();
	if(PCT2ref.noisei > 1500)
        {
            isactive = true;
        }	
	}
    void movementstage1()
    {
        
        if(isactive == true)
        {
            countdowntooffice--;
        }
        else if(1 > countdowntooffice)
        {
            isatoffice = true;
        }
        if(countdowntooffice == 120)
        {
            //play door creaking sfx
        }
    }
}
