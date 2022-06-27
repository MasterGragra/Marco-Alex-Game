using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    [SerializeField] private GameObject explosionPrefab;
    private float burnDamage;
    private float scale = 1f;
    private float durationMultiplier = 1f;

    public float BurnDamage { get => burnDamage; set => burnDamage = value; }
    public float Scale { get => scale; set => scale = value; }
    public float DurationMultiplier { get => durationMultiplier; set => durationMultiplier = value; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < TargetTags.Length; i++)
        {
            if (collider.gameObject.CompareTag(TargetTags[i]))
            {
                collider.SendMessage("ReceiveDamage", Damage);
                Destroy(gameObject);
            }
        }

        if (collider.gameObject.tag == "Terrain")
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if (Scale > 1f) explosion.transform.localScale *= Scale;
        if (DurationMultiplier > 1f) explosion.GetComponent<Projectile>().Lifetime *= DurationMultiplier;
        explosion.GetComponent<Projectile>().Damage = burnDamage;
    }
}