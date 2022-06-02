using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float lifetime;
    public string[] targetTags;

    void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
