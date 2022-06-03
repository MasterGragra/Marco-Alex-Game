using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private Transform target;
    private float lifetime = 0.5f;

    public Transform Target { get => target; set => target = value; }


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.transform.position;
    }
}
