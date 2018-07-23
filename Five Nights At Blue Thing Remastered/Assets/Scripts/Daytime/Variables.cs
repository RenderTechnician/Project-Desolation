using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {
    public Flashlight flashlight;
    //PCTextScript2
    public int whichvalue;
    public List<string> enteredvaluelist = new List<string>();
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && whichvalue > 0)
        {
            whichvalue--;
            flashlight.input.text = enteredvaluelist[whichvalue -1];
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && enteredvaluelist.Count > whichvalue)
        {
            whichvalue++;
            flashlight.input.text = enteredvaluelist[whichvalue -1];
        }
    }
}