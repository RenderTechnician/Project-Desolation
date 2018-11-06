using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Access : MonoBehaviour {
    public GameObject Continue, extras;
	// Use this for initialization
	void Start () {
        hidecontinue(); hideextras();
	}
	public void hidecontinue()
    {
        if (PlayerPrefs.GetInt("Currentnight") == 0)
        {
            Continue.SetActive(false);
        }
    }
    public void hideextras()
    {
        if (4 > PlayerPrefs.GetInt("Currentnight"))
        {
            extras.SetActive(false);
        }
    }
}
