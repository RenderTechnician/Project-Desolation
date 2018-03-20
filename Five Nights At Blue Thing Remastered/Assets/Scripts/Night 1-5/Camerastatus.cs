using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerastatus : MonoBehaviour {
    public Sprite[] sprite;
    public Sprite[] Static;
    public int count;
    public int gothrough;
    public AudioSource click;
    public bool activate;
    public GameObject spr;
    public SpriteRenderer white;
	// Use this for initialization
	void Start () {
		
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
        if (gothrough > 6)
        {
            activate = false;
            gothrough = 0;
        }

        spr.GetComponent<SpriteRenderer>().sprite = Static[gothrough];
        this.GetComponent<SpriteRenderer>().sprite = sprite[count];	
	}
    public void cam1a()
    {
        count = 0;
        activate = true;
        click.Play();
    }
    public void cam1b()
    {
        count = 1;
        activate = true;
        click.Play();
    }
    public void cam2a()
    {
        count = 2;
        activate = true;
        click.Play();
    }
    public void cam3a()
    {
        count = 3;
        activate = true;
        click.Play();
    }
    public void cam4a()
    {
        count = 4;
        activate = true;
        click.Play();
    }
}

