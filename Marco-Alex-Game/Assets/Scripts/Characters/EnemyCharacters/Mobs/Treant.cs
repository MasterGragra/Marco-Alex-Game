using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treant : Enemy
{
    [SerializeField] private GameObject attackPrefab;
    private int attackCount = 3;

    private void Attack()
    {
        if (!IsDead() && CheckCooldown())
        {
            if (AttackRange >= CheckDistance())
            {
                SetActionCooldown(AttackDelay);
                StartCoroutine("AttackCoroutine");
            }
        }
    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < attackCount; i++)
        {
            GameObject attack = Instantiate(attackPrefab, transform.position, Quaternion.identity);
            Orbit script = attack.GetComponent<Orbit>();
            script.Axis = transform;
            script.Angle = (360f / attackCount) * i;
        }
        Animator.SetTrigger("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        EnemyUpdate();
        Attack();
    }
}
