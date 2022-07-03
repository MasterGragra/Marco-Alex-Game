using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : Interactable
{
    [SerializeField] private float knockbackForce = 5f;
    public float KnockbackForce { get => knockbackForce; set => knockbackForce = value; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < TargetTags.Length; i++)
        {
            if (collider.gameObject.CompareTag(TargetTags[i]))
            {
                Vector2 direction = collider.transform.position - transform.position;
                collider.GetComponent<Character>().StartCoroutine("Knockback", direction * KnockbackForce);
            }
        }
    }
}
