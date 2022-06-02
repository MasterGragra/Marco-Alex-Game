using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShield : Projectile
{
    private Animator animator;
    private int durability = 1;

    public int Durability { get => durability; set => durability = value; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < TargetTags.Length; i++)
        {
            if (collider.gameObject.CompareTag(TargetTags[i]))
            {
                collider.SendMessage("ReceiveDamage", Damage);
                durability--;
            }
        }
    }

    private IEnumerator DestroyShield()
    {
        animator.SetTrigger("Broken");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Lifetime -= Time.fixedDeltaTime;
        if (Lifetime <= 0f || durability <= 0)
        {
            StartCoroutine(DestroyShield());
        }
    }
}
