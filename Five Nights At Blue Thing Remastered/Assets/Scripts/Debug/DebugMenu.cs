using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DebugMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("DebugMenu");
        }	
	}
    public void Menu()
    {
        SceneManager.LoadScene("Menu 2");
    }
    public void Nights()
    {
        SceneManager.LoadScene("Night 1-5");
    }
    public void Day()
    {
        SceneManager.LoadScene("daytime");
    }
    public void boot()
    {
        SceneManager.LoadScene("Warning");
    }
    public void chat()
    {
        SceneManager.LoadScene("Text");
    }
    public void debmenu()
    {
        SceneManager.LoadScene("DebugMenu");
    }
}
