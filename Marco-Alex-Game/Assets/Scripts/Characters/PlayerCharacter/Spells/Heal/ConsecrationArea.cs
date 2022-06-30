using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsecrationArea : StayAreaEffect
{
    private float consecrationDamageMultiplier = 0.2f;

    public override void ApplyAreaEffect(Collider2D collider)
    {
        collider.GetComponent<Character>().ReceiveIndirectDamage(Player.Instance.GetComponent<HealSpell>().CalculateHealing() * consecrationDamageMultiplier * Time.deltaTime);
    }
}
