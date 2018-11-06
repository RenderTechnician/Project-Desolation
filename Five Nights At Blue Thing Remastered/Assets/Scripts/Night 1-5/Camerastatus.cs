using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camerastatus : MonoBehaviour {
    public Sprite[] sprite;
    public Sprite[] Static;
    public int count;
    public int gothrough;
    public AudioSource click;
    public bool activate;
    public GameObject spr;
    public SpriteRenderer white;
    public bool lightup;
    public int lightupint;
    public GameObject buttonparent;
	// Use this for initialization
	void Start () {
        lightupint = 0;
        buttonparent.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(activate == true)
        {
            gothrough++;
            white.enabled = true;
        }
        else
        {
            white.enabled = false;
        }
        if (gothrough > 5)
        {
            activate = false;
            gothrough = 0;
        }

        spr.GetComponent<SpriteRenderer>().sprite = Static[gothrough];
        this.GetComponent<SpriteRenderer>().sprite = sprite[count + lightupint];	
	}
    public void cam1a()
    {
        count = 0;
    }
    public void cam1b()
    {
        count = 1;
        buttonparent.SetActive(true);
        activate = true;
        click.Play();
    }
    public void cam2a()
    {
        count = 2;
    }
    public void cam3a()
    {
        count = 3;
    }
    public void cam4a()
    {
        count = 4;
    }
    public void cam5a()
    {
        count = 5;
    }
    public void Camfunction()
    {
        activate = true;
        click.Play();
        buttonparent.SetActive(false);
    }
    public void Lightup()
    {
if(lightup == false)
        {
            lightup = true;
            lightupint = 6;
        }
        else
        {
            lightup = false;
            lightupint = 0;
        }
    }
}

