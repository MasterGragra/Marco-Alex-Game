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
                if (Player.Instance.Hp + healAmount > Player.Instance.MaxHp) Player.Instance.Hp = Player.Instance.MaxHp;
                else Player.Instance.Hp += healAmount;

                GameObject heal = Instantiate(SpellPrefab, this.transform.position, Quaternion.identity);
                heal.GetComponent<Heal>().Target = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CastHeal();
    }
}
