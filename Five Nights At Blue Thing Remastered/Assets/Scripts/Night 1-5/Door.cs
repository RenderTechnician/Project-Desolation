using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour {
    public int count;
    public Sprite[] dooranim;
    public bool trigger;
    public AudioSource slam;
    public Camera_Animation camacc;
    public Cutpower cuttpower;
    public AudioSource click;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {	
        if(trigger == true && count < 12)
        {
            count++;
        }
        else if(trigger == false && count > 0 )
        {
            count--;
        }
        this.GetComponent<SpriteRenderer>().sprite = dooranim[count];
    }
    public void initiateaction()
    {
    if(trigger == false && cuttpower.toggle == false)
        {
            slam.Play();
            trigger = true;

        }
        else if(trigger == true)
        {
            slam.Play();
            trigger = false;
        }
    else if(trigger == false && cuttpower.toggle == true)
        {
            click.Play();
        }
    }
}
