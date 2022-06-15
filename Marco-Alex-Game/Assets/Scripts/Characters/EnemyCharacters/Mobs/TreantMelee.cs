using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantMelee : Enemy
{
    [SerializeField] private GameObject attackPrefab;
    private int attackCount = 3;

    private void MeleeAttack()
    {
        if (CanAttack() && AttackRange >= CheckDistance()) StartCoroutine("AttackCoroutine");
    }

    private IEnumerator MeleeAttackCoroutine()
    {
        SetActionCooldown(AttackDelay);
        yield return new WaitForSeconds(0.5f);
        Animator.SetBool("Attacking", true);
        for (int i = 0; i < attackCount; i++)
        {
            GameObject attack = Instantiate(attackPrefab, transform.position, Quaternion.identity);
            attack.GetComponent<WindBlade>().DamageModifier *= AttackPower;
            Orbit script = attack.GetComponent<Orbit>();
            script.Axis = transform;
            script.Angle = (360f / attackCount) * i;
        }
        yield return new WaitForSeconds(1f);
        Animator.SetBool("Attacking", false);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyUpdate();
        MeleeAttack();
    }
}
