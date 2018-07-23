using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCTextScript2 : MonoBehaviour {
    public AudioSource keyboardtap;
    public int size;
    public int noisei;
    public Text beforetext;
    public Flashlight flashlight;
    public bool catcher;
    public bool syphonmodestat;
    public bool lighttoggle;
    public int siphoncount;
    public int solarbattery;
    public int currentbat;
    public bool siphacc;
    public int[] addtobatteries;     //array containg all of the betteries
    public Variables variablebridge; //Reference to C# script 'Variables', defined in the inspector
    public Animator allanimations;
    public int volumegenint;
    public float volumeofgen;
    public AudioSource generator;
    // Use this for initialization
    void Start () {
        solarbattery = PlayerPrefs.GetInt("battery1solar") + Random.Range(100,150);
        Debug.Log(solarbattery);
        flashlight.computer.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        keyboard();
        noise();
        volumeofgen = volumegenint / 100.0f;
        generator.volume = volumeofgen;
    }
    void keyboard()//Called once per frame, calls appropriate method when the Return key is pressed and plays the key stroke sfx when any key is pressed.
    {
        if (Input.GetKeyDown(KeyCode.Return) && flashlight.whichselect == 2)
        {
            size++;
            variablebridge.enteredvaluelist.Add(flashlight.input.text);
            variablebridge.whichvalue++;
            if (flashlight.input.text == "!help" && syphonmodestat == false) { help(); }
            else if (flashlight.input.text == "!siphon" && syphonmodestat == false) { siphon(); }
            else if (flashlight.input.text.Contains("!siph") && syphonmodestat == true) { siph(); }
            else if (flashlight.input.text == "!exit" && syphonmodestat == true && siphacc == false) { siph(); }
            else if (flashlight.input.text == "!clear" && syphonmodestat == false) { clear(); }
            else if (flashlight.input.text == "!toggle" && syphonmodestat == false && (Input.GetKeyDown(KeyCode.Return))) { toggle(); }
            else { error(); }
        }
        else if (Input.anyKeyDown && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2) && flashlight.whichselect == 2 && !(Input.GetKeyDown(KeyCode.Return)))
        {
            keyboardtap.Play();
        }
        else if (siphacc == true && syphonmodestat == true) { siph2(); }
    }
    void help() //Called when the !help command is used. Will list all of the availiable commands. 
    {
        catcher = true;
        //help command
        keyboardtap.Play();
            string tempv = flashlight.input.text;
        //help text line
        flashlight.computer.text = flashlight.computer.text + "\n" + "\n" + "========================================================" +
            "Full List Of Commands" + "\n" + "\n" +

            //siphon command
            "!siphon" + "\n" + "\n" + "<color=green>Puts the system in siphon mode.</color>"
            + "\n" + "\n" +
            //!siph command
            "!siph(mainbat,'loaded battery')" + "\n" + "\n" + "<color=green>Allows you to siphon from main battery to auxilery battery as long as auxilery battery is less than 100%, replace 'loaded battery' with" +
            " the battery you would like to charge e.g. !siph(mainbat, battery1). Must be in syphon mode to perform command.</color>" + "\n" + "\n" +

            //!statuscommand
            "!status('battery')" + "\n" + "\n" + "<color=green>Allows you to see how much power is in a specific battery. You can use this command for the auxilery batteries or the main battery.</color>" +
             "\n" + "\n" +
             //!clear command
             "!clear" + "\n" + "\n" + "<color=green>Clears all of the text on the display.</color>" +
             "\n" + "\n" +

            //!toggle command 
            "!toggle" + "\n" + "\n" + "<color=green>Allows you to turn the lights on and off outside of your room. Don't forget this drains power from mainbat!</color>" +
             "\n" + "\n";

        size = size + 2;
        catcher = false;

    }
    void siphon() //Called if flashlight.input.text == "!siphon". Indicates that siphon mode is activated 
    {
        catcher = true;
        flashlight.computer.text = flashlight.computer.text + "\n" + "\n" + "Siphon Mode Activated";
            beforetext.text = "S>";
            syphonmodestat = true;
            catcher = false;
    }
    void siph() //Called when using the !siph command is used. Can be used to siphon power to batteries or exit siphon mode altogether.
    {
        catcher = true;

        //battery1
        if(flashlight.input.text == "!siph(mainbat,battery1)" && 100> PlayerPrefs.GetInt("battery1power") && solarbattery > 0)
        {
            siphacc = true;
            currentbat = 0;
            siph2();
            flashlight.computer.text = flashlight.computer.text + "\n" + "Battery siphon commencing!";
        }//battery1 (less than 100)
        else if (flashlight.input.text == "!siph(mainbat,battery1)" && 100 == PlayerPrefs.GetInt("battery1power"))
        {
            flashlight.computer.text = flashlight.computer.text + "\n" + "Battery already at 100%, please select another battery!";
        }//battery1 (equals 100)

        //battery2
        else if (flashlight.input.text == "!siph(mainbat,battery2)" && 100 > PlayerPrefs.GetInt("battery2power") && solarbattery > 0)
        {
            siphacc = true;
            currentbat = 1;
            siph2();
            flashlight.computer.text = flashlight.computer.text + "\n" + "Battery siphon commencing!";
        }//battery2 (less than 100)
        else if (flashlight.input.text == "!siph(mainbat,battery2)" && 100 == PlayerPrefs.GetInt("battery2power"))
        {
            flashlight.computer.text = flashlight.computer.text + "\n" + "Battery already at 100%, please select another battery!";
        }//battery2 (equals 100)

        //battery3
        else if (flashlight.input.text == "!siph(mainbat,battery3)" && 100 > PlayerPrefs.GetInt("battery3power") && solarbattery > 0)
        {
            siphacc = true;
            currentbat = 2;
            siph2();
            flashlight.computer.text = flashlight.computer.text + "\n" + "Battery siphon commencing!";
        }//battery3 (less than 100)
        else if (flashlight.input.text == "!siph(mainbat,battery3)" && 100 == PlayerPrefs.GetInt("battery3power"))
        {
            flashlight.computer.text = flashlight.computer.text + "\n" + "Battery already at 100%, please select another battery!";
        }//battery3 (equals 100)

        //battery4
        else if (flashlight.input.text == "!siph(mainbat,battery4)" && 100 > PlayerPrefs.GetInt("battery4power") && solarbattery > 0)
        {
            siphacc = true;
            currentbat = 3;
            siph2();
            flashlight.computer.text = flashlight.computer.text + "\n" + "Battery siphon commencing!";
        }//battery4 (less than 100)
        else if (flashlight.input.text == "!siph(mainbat,battery4)" && 100 == PlayerPrefs.GetInt("battery4power"))
        {
            flashlight.computer.text = flashlight.computer.text + "\n" + "Battery already at 100%, please select another battery!";
        }//battery4 (equals 100)

        //battery5
        else if (flashlight.input.text == "!siph(mainbat,battery5)" && 100 > PlayerPrefs.GetInt("battery5power") && solarbattery > 0)
        {
            siphacc = true;
            currentbat = 4;
            siph2();
            flashlight.computer.text = flashlight.computer.text + "\n" + "Battery siphon commencing!";
        }//battery5 (less than 100)
        else if (flashlight.input.text == "!siph(mainbat,battery5)" && 100 == PlayerPrefs.GetInt("battery5power"))
        {
            flashlight.computer.text = flashlight.computer.text + "\n" + "Battery already at 100%, please select another battery!";
        }//battery5 (equals 100)

        //exit
        else if (flashlight.input.text == "!exit" && siphacc == false)
        {
            flashlight.computer.text = flashlight.computer.text + "\n" + "\n" + "Goodbye";
            syphonmodestat = false;
            beforetext.text = "";
        }//exits siphon mode

    }
    void siph2() //Called when siphacc == true. Starts the procedure of adding power to your batteries ever 10 seconds
    {
        siphoncount++;
        if (siphoncount > 600)
        {
            solarbattery--;
            flashlight.computer.text = flashlight.computer.text + "\n" + "\n" + "1% added to Battery 1, solar battery now at " + solarbattery + " %. Type 'break' to halt siphon";
            addtobatteries[currentbat]++;
            siphoncount = 0;
            size = size + 1;
        }
        if(flashlight.input.text == "break")
        {
            siphoncount = 0;
            siphacc = false;
            flashlight.computer.text = flashlight.computer.text + "\n" + "Goodbye!";
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            size--;
        }
    }
    void error() //if the command is unknown then this method is called. Will return a different error based on the value of syphonmodestat
    {
        Debug.Log("what");
    if (catcher == false && syphonmodestat == false && (Input.GetKeyDown(KeyCode.Return)))
    {
        //no known commands
        string tempv = flashlight.input.text;
        flashlight.computer.text = flashlight.computer.text + "\n" + "\n" + "<color=red>The command you have entered is invalid. If you require assistance please type !help</color>" + "\n" + "\n" + tempv;
        Debug.Log("catch2");
    }
        else if (catcher == false && syphonmodestat == true && (Input.GetKeyDown(KeyCode.Return)))
        {
            //no known commands
            string tempv = flashlight.input.text;
            flashlight.computer.text = flashlight.computer.text + "\n" + "\n" + "<color=red>The command you have entered is not a siphon mode command, please exit siphon mode using !exit and try again </color>" + "\n" + "\n" + tempv;
            Debug.Log("catch3");
        }
    }
    void clear() //clears all of text on the screen and sets the screen height back to zero
    {
        flashlight.computer.text = "";
        size = 0;
    }
    void noise() //adds value to the noise attribute when power is being siphoned
    {
        if(siphacc == true)
        {
            noisei++;
            if(100 > volumegenint) {volumegenint++; }
        }
        else if(siphacc == false && noisei > 0)
        {
            noisei--;
            if (volumegenint > 0) { volumegenint--; }
        }
    }
    void toggle() //Toggles light on and off
    {
    if(lighttoggle == true)
        {
            lighttoggle = false;
            allanimations.SetTrigger("Mon On to Mon off");
            allanimations.ResetTrigger("Mon off to Mon on");
            flashlight.computer.text = flashlight.computer.text + "\n" + "Lights succesfully turned off";
        }
        else
        {
            lighttoggle = true;
            allanimations.SetTrigger("Mon off to Mon on");
            allanimations.ResetTrigger("Mon On to Mon off");
            flashlight.computer.text = flashlight.computer.text + "\n" + "Lights succesfully turned on";
        }
    }

}
