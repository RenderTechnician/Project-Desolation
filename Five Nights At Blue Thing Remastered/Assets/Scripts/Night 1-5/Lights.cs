using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {
    public int office;
    public bool door;
    public bool lights;
    public SpriteRenderer BackSprite;
    public Sprite[] backindex;
    public Animator down;
    public Camera_Animation camacc;
    public Cutpower cutpower;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<SpriteRenderer>().sprite = backindex[office];
    }
    public void doorbutt()
    {
        if (door == false && cutpower.toggle == false)
        {
            office++;
            door = true;
        }
        else if(door == true && cutpower.toggle == false)
        {
            office--;
            door = false;
        }
    }
    public void lightbutt()
    {
        if (lights == false && cutpower.toggle == false)
        {
            BackSprite.enabled = true;
            office = office + 2;
            lights = true;
        }
        else if (lights == true && cutpower.toggle == false)
        {
            BackSprite.enabled = false;
            office = office - 2;
            lights = false;
        }
    }
}
