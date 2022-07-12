using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellMenu : MonoBehaviour
{
    [SerializeField] private GameObject spellDescriptionOne;
    [SerializeField] private GameObject spellDescriptionTwo;
    [SerializeField] private GameObject spellDescriptionThree;
    [SerializeField] private GameObject spellDescriptionFour;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject spellMenu;

    public void LoadDescriptions()
    {
        Player.Instance.GetComponent<FireballSpell>().ReturnDescription();
        Player.Instance.GetComponent<WindBladesSpell>().ReturnDescription();
        Player.Instance.GetComponent<EarthShieldSpell>().ReturnDescription();
        Player.Instance.GetComponent<HealSpell>().ReturnDescription();
    }

    public void OpenSpellMenu()
    {
        LoadDescriptions();
        spellMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
