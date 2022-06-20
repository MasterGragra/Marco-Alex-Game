using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : Spell
{
    //new string SpellName = "Heal";
    //new string Description = "Press 4 to restore 100% of player spell power + 40 health point.\n Cooldown: 10 seconds.";

    private float healAmount = 40f;

    private void CastHeal()
    {
        if (Player.Instance.Hp < Player.Instance.MaxHp)
        {
            if (CanCast())
            {
                GameObject heal = Instantiate(SpellPrefab, this.transform.position, Quaternion.identity);
                Heal script = heal.GetComponent<Heal>();
                script.Target = this.transform;
                script.HealAmount = Player.Instance.SpellPower + healAmount;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CastHeal();
    }
}
