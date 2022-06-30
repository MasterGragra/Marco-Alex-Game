using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : StayAreaEffect
{
    public override void ApplyAreaEffect(Collider2D collider)
    {
        collider.GetComponent<Character>().Hp -= collider.GetComponent<Character>().MaxHp * 0.02f * Time.deltaTime;
    }
}
