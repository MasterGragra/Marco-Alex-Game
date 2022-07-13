using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBlessingMenu : MonoBehaviour
{
    private bool chestIsOpen;
    private ChestMenu script;
    [SerializeField] private GameObject BlessingMenu;

    void Start()
    {
        chestIsOpen = script.chestOpened;
    }

    public void BlessingMenuActive()
    {
        if (chestIsOpen == true)
        {
            BlessingMenu.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
