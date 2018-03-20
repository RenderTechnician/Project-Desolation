using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour {
    public int count;
    public Sprite[] dooranim;
    public bool trigger;
    public AudioSource slam;
    public Camera_Animation camacc;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {	
        if(trigger == true && count < 12)
        {
            count++;
        }
        else if(trigger == false && count > 0)
        {
            count--;
        }
        this.GetComponent<SpriteRenderer>().sprite = dooranim[count];
    }
    public void initiateaction()
    {
    if(trigger == false)
        {
            slam.Play();
            trigger = true;

        }
        else
        {
            slam.Play();
            trigger = false;
        }
    }
}
