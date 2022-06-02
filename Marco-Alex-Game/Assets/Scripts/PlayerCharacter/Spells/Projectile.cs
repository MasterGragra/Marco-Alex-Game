using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float lifetime;
    private string[] targetTags = new string[] { "Enemy" };

    public float Damage { get => damage; set => damage = value; }
    public float Lifetime { get => lifetime; set => lifetime = value; }
    public string[] TargetTags { get => targetTags; set => targetTags = value; }

    void Awake()
    {
        Destroy(gameObject, Lifetime);
    }
}
