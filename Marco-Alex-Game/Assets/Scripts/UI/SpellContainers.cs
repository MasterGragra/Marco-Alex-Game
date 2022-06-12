using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellContainers : MonoBehaviour
{
    [SerializeField] private Image fireSpellBarImage;
    [SerializeField] private Image windSpellBarImage;
    [SerializeField] private Image earthSpellBarImage;
    [SerializeField] private Image healSpellBarImage;

    private FireballSpell fireSpell;
    private WindBladesSpell windSpell;
    private EarthShieldSpell earthSpell;
    private HealSpell healSpell;

    private void Start()
    {
        fireSpell = Player.Instance.GetComponent<FireballSpell>();
        windSpell = Player.Instance.GetComponent<WindBladesSpell>();
        earthSpell = Player.Instance.GetComponent<EarthShieldSpell>();
        healSpell = Player.Instance.GetComponent<HealSpell>();
        
    }
    // Update is called once per frame
    void Update()
    {
        fireSpellBarImage.fillAmount = 1f - fireSpell.SpellCooldownTimer / fireSpell.SpellCooldown;
        windSpellBarImage.fillAmount = 1f - windSpell.SpellCooldownTimer / windSpell.SpellCooldown;
        earthSpellBarImage.fillAmount = 1f - earthSpell.SpellCooldownTimer / earthSpell.SpellCooldown;
        healSpellBarImage.fillAmount = 1f - healSpell.SpellCooldownTimer / healSpell.SpellCooldown;
    }
}
