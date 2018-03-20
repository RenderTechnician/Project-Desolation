using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_graphics : MonoBehaviour {
    public Camera cam;
    public bool switcher;
    public float positioner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(switcher == false)
            {
                switcher = true;
                positioner = cam.transform.position.y + 15.0f;
            }
            else
            {
                switcher = false;
                positioner = cam.transform.position.y - 15.0f;

            }
        }
	}
}
