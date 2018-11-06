using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource Lightbuzz;
    public bool Lightbool;
    public Cutpower cutpower;
    public AudioSource[] phonecalls;
    public TextManager textmanager;
    public GameObject mutcall;
    // Use this for initialization
    void Start () {
        Invoke("call", 3.0f);
        Invoke("hideendcall", 10.0f);
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
    void call()
    {
        if (3 > textmanager.whichday)
        {
            mutcall.SetActive(true);
            phonecalls[textmanager.whichday].Play();
        }
    }
    public void endcall()
    {
        phonecalls[textmanager.whichday].Stop();
        mutcall.SetActive(false);
    }
    void hideendcall()
    {
        mutcall.SetActive(false);
    }
}
