using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public int selector;
    public int catcher;
    public bool perform;
    public bool doorbool;
    public SpriteRenderer back;
    public SpriteRenderer office;
    public int state;
    public int local1;
    public int counter;
    public int someoneoutside;
    public int whosthere;
    public int doorcount;
    public GameObject officestage;
    public Sprite[] officeanim;
    public Door doorbridge;
    public float fader;
    public Image black;
    public Animator animation1;
	// Use this for initialization
	void Start () {
        selector = Random.Range(0, 1000);
        perform = false;
	}
	
	// Update is called once per frame
	void Update () {
        counting();
        catcher = Random.Range(0, 1000);
        someoneoutside = Random.Range(1, 5);
        if(catcher == selector && perform == false)
        {
            performer();
        }
        officestage.GetComponent<SpriteRenderer>().sprite = officeanim[state];
	}
    void performer()
    {
        Debug.Log("hi");
        perform = true;
        back.enabled = true;
        state++;
        if(someoneoutside == 2)
        {
            doorbool = true;
            counter = (local1 - 300);
        }
        else
        {
            doorbool = false;
        }
    }
    void counting()
    {
      local1 = Random.Range(500,1000);
    if(back.enabled == true)
        {
            counter++;
        }
    if(counter > local1 && doorbool == false)
        {
            perform = false;
            back.enabled = false;
            counter = 0;
            state = 0;
        }
       else if (counter > local1 && doorbool == true)
        {
            doorbridge.trigger = true;
            state = 2;
            back.enabled = false;
            counter = 0;
        }
    if(doorbridge.trigger == true)
        {
            doorcount++;
        }
    if(doorcount > 300)
        {
            doorbridge.trigger = false;
            doorcount = 0;
            performer();
        }
    if(doorbool == false && state > 1)
        {
            state = 0;
        }
    }
    public void newgame()
    {
          SceneManager.LoadScene("Text");
    }
}
    