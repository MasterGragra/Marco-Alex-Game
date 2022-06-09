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
    private WindBladesSpell wingSpell;
    private HealSpell healSpell;

    private void Start()
    {
        earthSpell = Player.Instance.GetComponent<EarthShieldSpell>();
        
    }
    // Update is called once per frame
    void Update()
    {
        earthSpellBarImage.fillAmount = earthSpell.SpellCooldownTimer / earthSpell.SpellCooldown;
    }
}
