using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : Spell
{
    [SerializeField] private GameObject fireballPrefab;
    private float fireballSpeed = 10f;

    private void CastFireball()
    {
        if (CanCast())
        {
            Player.Instance.ActionCooldown(0.3f);
            MpCost(mpCost);
            GameObject fireball = Instantiate(fireballPrefab, Player.Instance.transform.position, Quaternion.identity);
            Rigidbody2D rigid = fireball.GetComponent<Rigidbody2D>();
            rigid.AddForce(Player.Instance.GetComponent<PlayerMovement>().PlayerDirection * fireballSpeed, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        CastFireball();
    }
}
