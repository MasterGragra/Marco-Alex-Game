using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : Spell
{
    new string SpellName = "Heal";

    private float healAmount = 40f;

    private bool holyGrounds = false;
    private bool purity = false;
    private bool rejuvenation = false;
    private bool sanctification = false;

    private void CastHeal()
    {
        if (Player.Instance.Hp < Player.Instance.MaxHp)
        {
            if (CanCast())
            {
                GameObject heal = Instantiate(SpellPrefab, this.transform.position, Quaternion.identity);
                Heal script = heal.GetComponent<Heal>();
                script.Target = this.transform;
                script.HealAmount = CalculateHealing();
            }
        }
    }

    private float CalculateHealing()
    {
        return (Player.Instance.SpellPower + healAmount) * Player.Instance.HealSpellModifier;
    }

    // Update is called once per frame
    void Update()
    {
        CastHeal();
    }
}
