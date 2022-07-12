using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RNGBlessing : MonoBehaviour
{
    //UI 
    [SerializeField] private GameObject blessingMenu;
    [SerializeField] private GameObject textbox;
    [SerializeField] private Text text;

    public ChestMenu script;
    public bool chestIsOpen;

    public int randomNumber = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        chestIsOpen = script.chestOpened;
    }

    void RollForGreaterBlessing()
    {
        randomNumber = Random.Range(1, 4);
        
    }

    void RollForLesserBlessing()
    {
        randomNumber = Random.Range(5, 8);
        
    }

    void OpenBlessingMenu()
    {
        if (chestIsOpen == true)
        {
            blessingMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

