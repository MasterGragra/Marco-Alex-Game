using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    [SerializeField] private float lifetime;
    public string[] targetTags;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
