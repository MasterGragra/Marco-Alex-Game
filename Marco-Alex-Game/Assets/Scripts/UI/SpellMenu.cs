using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellMenu : MonoBehaviour
{
    [SerializeField] private Text fireSpellName;
    [SerializeField] private Text windSpellName;
    [SerializeField] private Text earthSpellName;
    [SerializeField] private Text healingSpellName;

    [SerializeField] private Text fireSpellDesc;
    [SerializeField] private Text windSpellDesc;
    [SerializeField] private Text earthSpellDesc;
    [SerializeField] private Text healingSpellDesc;

    [SerializeField] private GameObject pauseMenuButtonContainer;
    [SerializeField] private GameObject spellMenu;

    public void LoadDescriptions()
    {
        fireSpellDesc.text = Player.Instance.GetComponent<FireballSpell>().ReturnDescription();
        windSpellDesc.text = Player.Instance.GetComponent<WindBladesSpell>().ReturnDescription();
        earthSpellDesc.text = Player.Instance.GetComponent<EarthShieldSpell>().ReturnDescription();
        healingSpellDesc.text = Player.Instance.GetComponent<HealSpell>().ReturnDescription();
    }

    void LoadSpellNames()
    {
        fireSpellName.text = Player.Instance.GetComponent<FireballSpell>().SpellName;
        windSpellName.text = Player.Instance.GetComponent<WindBladesSpell>().SpellName;
        earthSpellName.text = Player.Instance.GetComponent<EarthShieldSpell>().SpellName;
        healingSpellName.text = Player.Instance.GetComponent<HealSpell>().SpellName;
    }

    public void OpenSpellMenu()
    {
        LoadSpellNames();
        LoadDescriptions();
        spellMenu.SetActive(true);
        pauseMenuButtonContainer.SetActive(false);
    }
}
