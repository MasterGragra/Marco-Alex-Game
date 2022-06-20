using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : Spell
{
    private float fireballSpeed = 10f;

    private bool conflagration = false;
    private bool amaterasu = false;
    private bool napalm = false;
    private bool blazingSparks = false;

    private void CastFireball()
    {
        if (CanCast())
        {
            GameObject fireball = Instantiate(SpellPrefab, Player.Instance.transform.position, Quaternion.identity);
            fireball.GetComponent<Projectile>().Damage = CalculateDamage(Player.Instance.FireSpellModifier);
            fireball.GetComponent<Fireball>().BurnDamage = CalculateDamage(Player.Instance.FireSpellBurnModifier);
            Rigidbody2D rigid = fireball.GetComponent<Rigidbody2D>();
            rigid.AddForce(Player.Instance.GetComponent<PlayerMovement>().PlayerDirection.normalized * fireballSpeed, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        CastFireball();
    }
}
