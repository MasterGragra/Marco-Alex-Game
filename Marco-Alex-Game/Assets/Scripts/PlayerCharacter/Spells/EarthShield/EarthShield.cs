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

    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GameManager.Instance.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < TargetTags.Length; i++)
        {
            if (collider.gameObject.CompareTag(TargetTags[i]))
            {
                durability--;
                collider.SendMessage("ReceiveDamage", Damage);
                DestroyShieldSFX();
            }
        }
    }

    private IEnumerator DestroyShield()
    {
        animator.SetTrigger("Broken");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void DestroyShieldSFX()
    {
        audioSource.clip = brokenShieldSFX;
        audioSource.Play();
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
