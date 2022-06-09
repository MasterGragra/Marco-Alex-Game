using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellContainers : MonoBehaviour
{
    [SerializeField] private Image fireSpellBarImage;
    [SerializeField] private Image windSpellBarImage;
    [SerializeField] private Image healSpellBarImage;
    [SerializeField] private Image earthSpellBarImage;

    private EarthShieldSpell earthSpell;
    private FireballSpell fireSpell;
    private WindBladesSpell windSpell;
    private HealSpell healSpell;

    private void Start()
    {
        earthSpell = Player.Instance.GetComponent<EarthShieldSpell>();
        fireSpell = Player.Instance.GetComponent<FireballSpell>();
        windSpell = Player.Instance.GetComponent<WindBladesSpell>();
        healSpell = Player.Instance.GetComponent<HealSpell>();
        
    }
    // Update is called once per frame
    void Update()
    {
        earthSpellBarImage.fillAmount = 1f - earthSpell.SpellCooldownTimer / earthSpell.SpellCooldown;
        fireSpellBarImage.fillAmount = 1f - fireSpell.SpellCooldownTimer / fireSpell.SpellCooldown;
        windSpellBarImage.fillAmount = 1f - windSpell.SpellCooldownTimer / windSpell.SpellCooldown;
        healSpellBarImage.fillAmount = 1f - healSpell.SpellCooldownTimer / healSpell.SpellCooldown;
    }
}
