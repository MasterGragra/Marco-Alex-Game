using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShield : Projectile
{
    private Animator animator;
    private int durability = 1;

    private AudioSource audioSource;
    [SerializeField] private AudioClip brokenShieldSFX;

    public int Durability { get => durability; set => durability = value; }

    private void Awake()
    {
        StartCoroutine(DestroyShield());
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GameManager.Instance.GetComponent<AudioSource>();
        StartCoroutine(ActivateCollider());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < TargetTags.Length; i++)
        {
            if (collider.gameObject.CompareTag(TargetTags[i]))
            {
                collider.SendMessage("ReceiveDamage", Damage);
                Vector2 direction = collider.transform.position - transform.position;
                collider.GetComponent<Character>().StartCoroutine("Knockback", direction * KnockbackForce);
                DamageShield();
            }

            else if (collider.gameObject.tag == "Projectile")
            {
                DamageShield();
            }
        }
    }

    private IEnumerator ActivateCollider()
    {
        yield return new WaitForSeconds(0.4f);
        GetComponent<CircleCollider2D>().enabled = true;
    }

    private void DamageShield()
    {
        durability--;
        if(durability > 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(ActivateCollider());
        }
        else StartCoroutine(DestroyShield());
    }

    private IEnumerator DestroyShield()
    {
        if (durability > 0)
        {
            yield return new WaitForSeconds(Lifetime);
        }
        animator.SetTrigger("Broken");
        GetComponent<CircleCollider2D>().enabled = false;
        DestroyShieldSFX();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void DestroyShieldSFX()
    {
        audioSource.clip = brokenShieldSFX;
        audioSource.Play();
    }
}
