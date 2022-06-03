using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : Spell
{
    private float healAmount = 50f;

    private void CastHeal()
    {
        if(CanCast() && Player.Instance.Hp < Player.Instance.MaxHp)
        {
            if (Player.Instance.Hp + healAmount < Player.Instance.MaxHp) Player.Instance.Hp = Player.Instance.MaxHp;
            else Player.Instance.Hp += healAmount;

            GameObject heal = Instantiate(SpellPrefab, transform.position, Quaternion.identity);
            //heal.GetComponent<Heal>().Target = transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CastHeal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
