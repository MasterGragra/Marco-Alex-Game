using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Interactable
{
    private float damage;
    [SerializeField] private float lifetime;

    public float Damage { get => damage; set => damage = value; }
    public float Lifetime { get => lifetime; set => lifetime = value; }

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
