using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmanager : MonoBehaviour {
    TextManager textmanager; //Reference to TextManager script
    GameObject[] Kevin;     // Array of objects with the 'KevinTag' Tag
    GameObject[] BlueThing; // Array of objects with the 'BlueThingTag' Tag
	
    void Awake()
    {
        // Assigns each variable by finding a gameobject and getting a variable from it

        Kevin = GameObject.FindGameObjectsWithTag("KevinTag");                      //Finds objects with specified tag and adds them to the array
        BlueThing = GameObject.FindGameObjectsWithTag("BlueThingTag");            //Finds objects with specified tag and adds them to the array
        kev(); bt();
    }

    void kev()
    {
        //Disables Kevin if earlier than Night 2 by setting all tagged objects and the Kevin script to false and thus disabling it
        if (PlayerPrefs.GetInt("Currentnight") < 1)
        {
            for (int i = 0; i < Kevin.Length; i++)
            {
                Kevin[i].SetActive(false);
            }
            GameObject.Find("ScriptManager").GetComponent<Kevin>().enabled = false;
        }
    }

    void bt()
    {
        //Disables Blue Thing if earlier than Night 3 by setting all tagged objects and the BlueThing script to false and thus disabling it
        if (PlayerPrefs.GetInt("Currentnight") < 2)
        {
            for (int i = 0; i < BlueThing.Length; i++)
            {
                BlueThing[i].SetActive(false);
            }
            GameObject.Find("ScriptManager").GetComponent<BlueThing>().enabled = false;
        }
    }
}
