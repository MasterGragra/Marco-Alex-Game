using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float lifetime;
    [SerializeField] private string[] targetTags = new string[] { "Enemy" };

    public float Damage { get => damage; set => damage = value; }
    public float KnockbackForce { get => knockbackForce; set => knockbackForce = value; }
    public float Lifetime { get => lifetime; set => lifetime = value; }
    public string[] TargetTags { get => targetTags; set => targetTags = value; }

    private void ManageLifetime()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ManageLifetime();
    }
}
