using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
    public int currentnight;
    public Text whichnight;
    public int time;
	// Use this for initialization
	void Start () {
        currentnight = PlayerPrefs.GetInt("Currentnight");
        whichnight.text = "Night " + (currentnight + 1);
        InvokeRepeating("TimeUpdate", 1.0f, 1.0f);
	}

    void TimeUpdate()
    {
        time++;
        if (time == 8)
        {
            if (PlayerPrefs.GetInt("D/N") == 0)
            {
                SceneManager.LoadScene("night 1-5");
            }
            else if (PlayerPrefs.GetInt("D/N") == 1)
            {
                SceneManager.LoadScene("daytime");
            }
        }
    }
}
