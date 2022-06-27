using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosion : Projectile
{
    private BoxCollider2D explosionCollider;
    private LayerMask enemyLayer;
    private float initialLifetime;
    [SerializeField] GameObject napalmPrefab;
    private bool napalm = false;
    private int napalmCounter = 2;

    private AudioSource audioSource;
    [SerializeField] private AudioClip explosionSFX;

    public float InitialLifetime { get => initialLifetime; set => initialLifetime = value; }
    public bool Napalm { get => napalm; set => napalm = value; }

    // Start is called before the first frame update
    void Start()
    {
        explosionCollider = GetComponent<BoxCollider2D>();
        enemyLayer = LayerMask.GetMask("Enemy");
        InvokeRepeating("BurnDamage", 0.1f, 0.3f);
        InvokeRepeating("NapalmEffect", 0.1f, 0.2f);
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

    private void NapalmEffect()
    {
        if (Napalm)
        {
            Vector3[] coordinates = new[]
            {
                new Vector3(transform.position.x - napalmCounter * transform.localScale.x, transform.position.y - napalmCounter * transform.localScale.y, transform.position.z),
                new Vector3(transform.position.x + napalmCounter * transform.localScale.x, transform.position.y - napalmCounter * transform.localScale.y, transform.position.z),
                new Vector3(transform.position.x - napalmCounter * transform.localScale.x, transform.position.y + napalmCounter * transform.localScale.y, transform.position.z),
                new Vector3(transform.position.x + napalmCounter * transform.localScale.x, transform.position.y + napalmCounter * transform.localScale.y, transform.position.z)
            };

            for (int i = 0; i < coordinates.Length; i++)
            {
                GameObject flame = Instantiate(napalmPrefab, coordinates[i], Quaternion.identity);
                flame.transform.localScale = transform.localScale;
            }

            napalmCounter++;
        }
    }

    private IEnumerator ExplosionSFX()
    {
        if (explosionSFX != null)
        {
            audioSource = GameManager.Instance.GetComponent<AudioSource>();
            audioSource.clip = explosionSFX;
            audioSource.Play();
            yield return new WaitForSeconds(0.4f);
            audioSource.Stop();
        }
    }
}


