using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBlade : Projectile
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < targetTags.Length; i++)
        {
            if (collider.gameObject.CompareTag(targetTags[i]))
            {
                collider.SendMessage("ReceiveDamage", damage);
                Destroy(gameObject);
            }
        }

        if (collider.gameObject.tag == "Terrain" || collider.gameObject.tag == "Fire")
            Destroy(gameObject);
    }
}
