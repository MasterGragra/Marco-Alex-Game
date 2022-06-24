using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlade : Projectile
{
    [SerializeField] private bool knockback = true;
    private bool bouncing = false;
    [SerializeField] private bool destroyOnCollision = true;

    public bool Bouncing { get => bouncing; set => bouncing = value; }
    public bool DestroyOnCollision { get => destroyOnCollision; set => destroyOnCollision = value; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < TargetTags.Length; i++)
        {
            if (collider.gameObject.CompareTag(TargetTags[i]))
            {
                collider.SendMessage("ReceiveDamage", Damage);
                if (knockback)
                {
                    Vector2 direction = collider.transform.position - transform.position;
                    collider.GetComponent<Character>().StartCoroutine("Knockback", direction * KnockbackForce);
                }
                if (destroyOnCollision) Destroy(gameObject);
            }
        }

        if (collider.gameObject.tag == "Terrain")
        {
            if (bouncing)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * -1f, GetComponent<Rigidbody2D>().velocity.y * -1f);
            }
            else Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Fire") Destroy(gameObject);
    }
}
