using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosion : Projectile
{
    private BoxCollider2D explosionCollider;
    private LayerMask enemyLayer;

    private AudioSource audioSource;
    [SerializeField] private AudioClip explosionSFX;

    // Start is called before the first frame update
    void Start()
    {
        explosionCollider = GetComponent<BoxCollider2D>();
        enemyLayer = LayerMask.GetMask("Enemy");
        InvokeRepeating("BurnDamage", 0.1f, 0.3f);
        StartCoroutine(ExplosionSFX());
    }

    private void BurnDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapBoxAll(explosionCollider.transform.position, explosionCollider.size, 0f, enemyLayer);
        foreach(Collider2D enemy in enemies)
        {
            enemy.SendMessage("ReceiveDamage", Damage);
        }
    }

    private IEnumerator ExplosionSFX()
    {
        audioSource = GameManager.Instance.GetComponent<AudioSource>();
        audioSource.clip = explosionSFX;
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        audioSource.Stop();
    }
}


