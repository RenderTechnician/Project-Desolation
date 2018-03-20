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
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<SpriteRenderer>().sprite = backindex[office];
    }
    public void doorbutt()
    {
        if (door == false)
        {
            office++;
            door = true;
        }
        else
        {
            office--;
            door = false;
        }
    }
    public void lightbutt()
    {
        if (lights == false)
        {
            BackSprite.enabled = true;
            office = office + 2;
            lights = true;
        }
        else
        {
            BackSprite.enabled = false;
            office = office - 2;
            lights = false;
        }
    }
}
