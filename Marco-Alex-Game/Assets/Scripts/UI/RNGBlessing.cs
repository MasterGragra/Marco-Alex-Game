using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RNGBlessing : MonoBehaviour
{
    //greater blessings

    //Great Fire Blessing 
    //public bool fireBlessing = false;
    public bool amaterasu = false;
    public bool spark = false;
    public bool confliguration = false;
    public bool napalm = false;

    //Great Wind Blessing
    //public bool windBlessing = false;
    public bool echo = false;
    public bool gale = false;
    public bool gust = false;
    public bool zephyr = false;

    //Great Earth Blessing
    //public bool earthBlessing = false;
    public bool fortification = false;
    public bool pebbles = false;
    public bool stoning = false;
    public bool stratification = false;

    //Great Healing Blessing
    //public bool healingBlessing = false;
    public bool holy = false;
    public bool purity = false;
    public bool rejuvenation = false;
    public bool sanctafication = false;


    //lesser blessings

    //Dex Blessings
    //public bool dexterityBlessing = false;
    public bool agility = false;
    public bool invigoration = false;
    public bool momentum = false;
    public bool vitality = false;

    //Element Blessings
    //public bool elementBlessing = false;
    public bool fire = false;
    public bool wind = false;
    public bool earth = false;
    public bool life = false;

    //Might Blessings
    //public bool mightBlessing = false;
    public bool alacrity = false;
    public bool endurance = false;
    public bool fortitude = false;
    public bool power = false;

    //Wisdom Blessings
    //public bool wisdomBlessing = false;
    public bool acuity = false;
    public bool expansion = false;
    public bool insight = false;
    public bool knowledge = false;

    //UI 
    public Animator animator;
    public GameObject blessingMenu;
    public GameObject textbox;

    public TextAsset textFile;
    public string[] textLines;
    public Text text;

    public ChestMenu script;
    public bool chestIsOpen;

    public int randomNumber =0;
    public bool reroll = false;


    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
        blessingMenu.SetActive(false);

        chestIsOpen = script.chestOpened;

        if(textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
    }

    void RollForGreaterBlessing()
    {
        randomNumber = Random.Range(1, 16);
        if (reroll == true)
        {
            reroll = false;
        }
    }

    void RollForLesserBlessing()
    {
        randomNumber = Random.Range(17, 32);
        if (reroll == true)
        {
            reroll = false;
        }
    }

    void OpenBlessingMenu()
    {
        if (chestIsOpen == true)
        {
            blessingMenu.SetActive(true);
        }
    }

    void GreaterBlessingDisplay()
    {
        switch (randomNumber)
        {
            case 1:
                if (amaterasu == true)
                {
                    RollForGreaterBlessing();
                }
                    if (amaterasu != true)
                    {
                        amaterasu = true;
                    }
                    OpenBlessingMenu();
                text.text = textLines[1];
                    Player.Instance.GetComponent<Blessing>();
                
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

