using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosion : Projectile
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {
            for (int i = 0; i < targetTags.Length; i++)
            {
                if (collider.gameObject.CompareTag(targetTags[i])) collider.SendMessage("ReceiveDamage", damage);
            }
        }
    }
}
