using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private Transform target;
    private float lifetime = 0.5f;
    private float healAmount;

    public Transform Target { get => target; set => target = value; }
    public float HealAmount { get => healAmount; set => healAmount = value; }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
        HealTarget();
    }

    private void HealTarget()
    {
        Character character = target.GetComponent<Character>();
        if (character.Hp + HealAmount > character.MaxHp) character.Hp = character.MaxHp;
        else character.Hp += HealAmount;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.transform.position;
    }
}
