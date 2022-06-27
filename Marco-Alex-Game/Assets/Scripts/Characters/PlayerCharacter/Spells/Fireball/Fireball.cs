using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    [SerializeField] private GameObject explosionPrefab;
    private float burnDamage;
    private bool napalm = false;
    private float explosionScale = 1f;
    private float flameDurationMultiplier = 1f;

    public float BurnDamage { get => burnDamage; set => burnDamage = value; }
    public bool Napalm { get => napalm; set => napalm = value; }
    public float ExplosionScale { get => explosionScale; set => explosionScale = value; }
    public float FlameDurationMultiplier { get => flameDurationMultiplier; set => flameDurationMultiplier = value; }

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
        if (Napalm) explosion.GetComponent<FireballExplosion>().Napalm = true;
        if (ExplosionScale > 1f) explosion.transform.localScale *= ExplosionScale;
        if (FlameDurationMultiplier > 1f)
        {
            FireballExplosion script = explosion.GetComponent<FireballExplosion>();
            script.InitialLifetime = script.Lifetime *= FlameDurationMultiplier;
        }
        explosion.GetComponent<Projectile>().Damage = burnDamage;
    }
}