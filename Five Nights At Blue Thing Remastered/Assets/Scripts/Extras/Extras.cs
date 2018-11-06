using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Extras : MonoBehaviour
{
    public SpriteRenderer enemy_spriterenderer, MOM_Spriterenderer, MOK_spriterenderer, BTS_spriterenderer;

    public Sprite[] Animatronics, Making_Of_Monstrou, Making_Of_Kevin, Behind_The_Scenes;

    public string[] Names;

    string[] descriptions = {
        "\n" + "Kevin was built using the most advanced techniques and technologies at the relative time of his creation." + "\n" + "Kevin sports a super realistic " +
            "humanoid exterior (relative to the time period) and has extensive knowledge on computer systems are software development." + "\n"
            + "\n" + "His original duties included helping guests with projects when they got stuck, maintaing all basic electronic systems within the establishment and " +
            "occasionally teaching French."
            +"\n" +"\n" + "However nowadays, due to a faulty battery his main focus is to distract the player to allow the others the chance to ambush you"
            
            ,"Very little is known about Monstrous origins, his original purpose or why he was even built in the first place","1"
};

    int AnimatronicCount, whatisshowing, MOMCount, MOKCount, BTSCount;

    public Text EnemyName, Enemybio;

    public GameObject[] ParentOfSelectables;

    // Use this for initialization
    void Start()
    {
        enemy_spriterenderer.GetComponent<SpriteRenderer>().sprite = Animatronics[AnimatronicCount];
        Enemybio.text = descriptions[AnimatronicCount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void down()
    {
        if (AnimatronicCount > 0 && whatisshowing == 0)
        {
            AnimatronicCount--;
            enemy_spriterenderer.sprite = Animatronics[AnimatronicCount];
            EnemyName.text = Names[AnimatronicCount];
            Enemybio.text = "\n" + descriptions[AnimatronicCount];
        }

       else if (MOMCount > 0 && whatisshowing == 1)
        {
            MOMCount--;
            MOM_Spriterenderer.sprite = Making_Of_Monstrou[MOMCount];
        }

        else if (MOKCount > 0 && whatisshowing == 2)
        {
            MOKCount--;
            MOK_spriterenderer.sprite = Making_Of_Kevin[MOKCount];
        }
        else if (BTSCount > 0 && whatisshowing == 3)
        {
            BTSCount--;
            BTS_spriterenderer.sprite = Behind_The_Scenes[BTSCount];
        }
    }

    public void up()
    {
        if(Animatronics.Length -1 > AnimatronicCount && whatisshowing == 0)
        {
            AnimatronicCount++;
            enemy_spriterenderer.sprite = Animatronics[AnimatronicCount];
            EnemyName.text = Names[AnimatronicCount];
            Enemybio.text = "\n" + descriptions[AnimatronicCount];
        }

        else if (Making_Of_Monstrou.Length - 1 > MOMCount && whatisshowing == 1)
        {
            MOMCount++;
            MOM_Spriterenderer.sprite = Making_Of_Monstrou[MOMCount];
        }

        else if (Making_Of_Kevin.Length - 1 > MOKCount && whatisshowing == 2)
        {
            MOKCount++;
            MOK_spriterenderer.sprite = Making_Of_Kevin[MOKCount];
        }
        else if (Behind_The_Scenes.Length - 1 > BTSCount && whatisshowing == 3)
        {
            BTSCount++;
            BTS_spriterenderer.sprite = Behind_The_Scenes[BTSCount];
        }
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu 2");
    }

    public void Enemies()
    {
        whatisshowing = 0;
    }

    public void MOM()
    {
        whatisshowing = 1;
    }

    public void MOK()
    {
        whatisshowing = 2;
    }

    public void BTS()
    {
        whatisshowing = 3;
    }
    public void SetVisibleSprite()
    {
        for (int i = 0; i < ParentOfSelectables.Length; i++)
        {
            if (i != whatisshowing)
            {
                ParentOfSelectables[i].SetActive(false);
            }
            else
            {
                ParentOfSelectables[i].SetActive(true);
            }
        }
    }
}
