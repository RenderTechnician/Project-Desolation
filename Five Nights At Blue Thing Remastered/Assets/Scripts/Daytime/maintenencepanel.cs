using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class maintenencepanel : MonoBehaviour {
    public SpriteRenderer spr;
    bool panelstatus;
    public Animator panelanimator, jumpscareanim;
    public GameObject uiparent, kevparent;
    AudioSource panel, confirm, scream;
    public KevLights kevlights;
    public AudioSource[] KevinSpeak;

    public Sprite[] kevinarray;
    public SpriteRenderer kevinroom, kevinjumpscare;

    public int recharge, discharge, speed, img, batterysize, WhichKevinLine;

    public float aware;

    public bool rechargeb, dischargeb, speedb, batterysizeb;

    public Text rechargetext, dischargetext, speedtext, batterysizetext;
    

    // Use this for initialization
    void Start () {
        panel = GameObject.Find("381157__dynia87__menu-click").GetComponent<AudioSource>();
        confirm = GameObject.Find("90113__pierrecartoons1979__beep2").GetComponent<AudioSource>();
        speed = PlayerPrefs.GetInt("Speed");
        batterysize = PlayerPrefs.GetInt("BatterySize");
        discharge = PlayerPrefs.GetInt("DischargeRate");
        recharge = PlayerPrefs.GetInt("RechargeRate");
        scream = GameObject.Find("scream").GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update() {
        animationflip(); kevup();
        if(spr.sprite.name == "0030" && img != 4)
        {
            uiparent.SetActive(true);
            rechargetext.text = "Recharge Rate : " + recharge + " %";
            dischargetext.text = "Discharge Rate : " + discharge + " %";
            speedtext.text = "Probability Of Activation 1/" + speed;
            batterysizetext.text = "Size Of Main Battery " + (batterysize - 400) + " %";
        }
        else
        {
            uiparent.SetActive(false);
        }
        kevinroom.sprite = kevinarray[img];
    }

    public void flipdetermine() // Allow the player to flip the maintenence panel as long as the power is still on
    {
        if (!kevlights.statusoflights)
        {
            panelstatus = !panelstatus;
            panel.Play();
        }
    }

    void animationflip()
    {
        if (panelstatus)
        {
            panelanimator.SetTrigger("panelup");
            panelanimator.ResetTrigger("paneldown");
            if(501 > aware) { aware += Time.deltaTime * 50; }
        }
        else
        {
            panelanimator.SetTrigger("paneldown");
            panelanimator.ResetTrigger("panelup");
            if(aware > 0) { aware -= Time.deltaTime * 50; }
        }
    }
    // Recharge Rate Methods
    public void rechargeenter()
    {
        rechargeb = true;
        if (rechargeb)
        {
            Debug.Log("okay");
            InvokeRepeating("repeatadd", 1.0f, 5.0f);    
        }
    }
    public void rechargeexit()
    {
        rechargeb = false;
        CancelInvoke("repeatadd");
    }
    void repeatadd()
    {
        if (Input.GetMouseButton(0))
        {
            confirm.Play();
            recharge--;
        }
    }

    // Discharge Rate Methods
    public void dischargeenter()
    {
        dischargeb = true;
        if (dischargeb)
        {
            Debug.Log("okay");
            InvokeRepeating("repeatadd2", 1.0f, 5.0f);
        }
    }
    public void dischargeexit()
    {
        dischargeb = false;
        CancelInvoke("repeatadd2");
    }
    void repeatadd2()
    {
        if (Input.GetMouseButton(0))
        {
            confirm.Play();
            discharge++;
        }
    }

    // Speed Methods
    public void speedenter()
    {
        speedb = true;
        if (speedb)
        {
            Debug.Log("okay");
            InvokeRepeating("repeatadd3", 1.0f, 5.0f);
        }
    }
    public void speedexit()
    {
        speedb = false;
        CancelInvoke("repeatadd3");
    }
    void repeatadd3()
    {
        if (Input.GetMouseButton(0))
        {
            confirm.Play();
            speed = speed + 50;
        }
    }

    // Battery Size Methods
    public void batterysizeenter()
    {
        speedb = true;
        if (speedb)
        {
            InvokeRepeating("repeatadd4", 1.0f, 5.0f);
        }
    }
    public void batterysizeexit()
    {
        speedb = false;
        CancelInvoke("repeatadd4");
    }
    void repeatadd4()
    {
        if (Input.GetMouseButton(0))
        {
            confirm.Play();
            batterysize++;
        }
    }

    void kevup()
    {
        if(aware > 250 && 4 > img && panelstatus)
        {
            KevinSpeak[WhichKevinLine].volume = 0.1f * ((img + 1) * 3);
            WhichKevinLine = Random.Range(0, KevinSpeak.Length -1);
            img++;
            aware = 0;
            KevinSpeak[WhichKevinLine].Play();
        }
        else if(img == 4)
        {
            jumpscareanim.SetTrigger("Jumpscare_Trig");
            KevinSpeak[WhichKevinLine].Stop();
            kevinjumpscare.enabled = true;
            uiparent.SetActive(false);
            kevparent.SetActive(false);
            if (!scream.isPlaying) { scream.Play(); }
            if(kevinjumpscare.sprite.name == "0041")
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
