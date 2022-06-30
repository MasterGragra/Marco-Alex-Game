using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyGroundsArea : StayAreaEffect
{
    private float holyGroundsMultiplier = 0.05f;

    public override void ApplyAreaEffect(Collider2D collider)
    {
        if (Player.Instance.GetComponent<Character>().Hp < Player.Instance.GetComponent<Character>().MaxHp)
            Player.Instance.GetComponent<Character>().Hp += Player.Instance.GetComponent<HealSpell>().CalculateHealing() * holyGroundsMultiplier * Time.deltaTime;
        else Player.Instance.GetComponent<Character>().Hp = Player.Instance.GetComponent<Character>().MaxHp;
    }
}
