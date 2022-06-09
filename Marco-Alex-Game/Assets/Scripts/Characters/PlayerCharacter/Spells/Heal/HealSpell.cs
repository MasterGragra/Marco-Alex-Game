using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : Spell
{
    private float healAmount = 50f;

    private void CastHeal()
    {
        if (Player.Instance.Hp < Player.Instance.MaxHp)
        {
            if (CanCast())
            {
                GameObject heal = Instantiate(SpellPrefab, this.transform.position, Quaternion.identity);
                Heal script = heal.GetComponent<Heal>();
                script.Target = this.transform;
                script.HealAmount = healAmount;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CastHeal();
    }
}