﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource Lightbuzz;
    public bool Lightbool;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void lightbuzz()
    {
        if(Lightbool == false)
        {
            Lightbuzz.Play();
            Lightbool = true;
        }
        else
        {
            Lightbuzz.Stop();
            Lightbool = false;
        }
    }
}
