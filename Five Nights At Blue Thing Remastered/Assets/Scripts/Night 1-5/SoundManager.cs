using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource Lightbuzz;
    public bool Lightbool;
    public Fadeoffice fader;
    public Cutpower cutpower;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        }
    public void lightbuzz()
    {
        if(Lightbool == false && cutpower.toggle == false)
        {
            Lightbuzz.Play();
            Lightbool = true;
        }
        else if (Lightbool == true)
        {
            Lightbuzz.Stop();
            Lightbool = false;
        }
    }
}
