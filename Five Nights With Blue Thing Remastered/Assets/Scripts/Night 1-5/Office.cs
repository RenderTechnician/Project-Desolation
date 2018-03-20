using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Office : MonoBehaviour {
    public SpriteRenderer OfficeSprite;
    public Sprite[] officeindex;
    public int count;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<SpriteRenderer>().sprite = officeindex[count];
        if (count < 20)
        {
            count++;
        }
        else
        {
            count = 0;
        }
	}

}
