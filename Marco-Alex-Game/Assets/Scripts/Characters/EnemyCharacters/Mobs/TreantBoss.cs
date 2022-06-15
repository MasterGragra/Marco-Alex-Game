using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantBoss : Enemy
{
    private Vector3 skillDirection;

    [SerializeField] private GameObject meleeAttackPrefab;
    private int meleeAttackCount = 3;

    [SerializeField] private GameObject fanAttackPrefab;
    private float fanAttackDelay = 5f;
    private int fanBarrageCount = 7;
    private float barrageDelay = 0.5f;
    private int fanProjectileCount = 5;
    private float fanProjectileSpeed = 5f;
    private float fanSpread = 30f;

    private IEnumerator MeleeAttackCoroutine()
    {
        if (AttackRange >= CheckDistance())
        {
            SetActionCooldown(AttackDelay);
            yield return new WaitForSeconds(1f);
            Animator.SetBool("Attacking", true);
            for (int i = 0; i < meleeAttackCount; i++)
            {
                GameObject attack = Instantiate(meleeAttackPrefab, transform.position, Quaternion.identity);
                attack.GetComponent<WindBlade>().DamageModifier *= AttackPower;
                Orbit script = attack.GetComponent<Orbit>();
                script.Axis = transform;
                script.Angle = (360f / meleeAttackCount) * i;
            }
            yield return new WaitForSeconds(1f);
            Animator.SetBool("Attacking", false);
        }
    }

    private IEnumerator FanAttackCoroutine()
    {
        SetActionCooldown(fanAttackDelay);
        for (int i = 0; i < fanBarrageCount; i++)
        {
            skillDirection = Quaternion.AngleAxis(-(fanSpread * ((float)fanProjectileCount - 1f) / 2), Vector3.forward) * FacingDirection;
            Vector3 offset = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1));
            skillDirection += offset;
            for (int k = 0; k < fanProjectileCount; k++)
            {
                GameObject projectile = Instantiate(fanAttackPrefab, transform.position, Quaternion.identity);
                projectile.GetComponent<WindBlade>().DamageModifier *= AttackPower;
                Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();
                rigid.AddForce(skillDirection.normalized * fanProjectileSpeed, ForceMode2D.Impulse);
                skillDirection = Quaternion.AngleAxis(fanSpread, Vector3.forward) * skillDirection;
            }
            yield return new WaitForSeconds(barrageDelay);
        }
    }

    private void AttackSelection()
    {
        if (CanAttack())
        {
            int attack = Random.Range(2, 2);
            switch (attack)
            {
                case 1:
                    StartCoroutine(MeleeAttackCoroutine());
                    break;
                case 2:
                    StartCoroutine(FanAttackCoroutine());
                    break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyUpdate();
        AttackSelection();
    }
}
