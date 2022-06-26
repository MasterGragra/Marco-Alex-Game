using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantBoss : Enemy
{
    [SerializeField] private GameObject meleeAttackPrefab;
    private float meleeDamageMultiplier = 1f;
    private int meleeProjectileCount = 3;

    [SerializeField] private GameObject rangeAttackPrefab;
    private float barrageDamageMultiplier = 2f;
    private float barrageAttackDelay = 6f;
    private int barrageProjectileCount = 30;
    private float barrageProjectileSpeed = 15f;

    private float fanDamageMultiplier = 2f;
    private float fanAttackDelay = 6f;
    private int fanBarrageCount = 7;
    private float fanBarrageDelay = 0.5f;
    private int fanProjectileCount = 7;
    private float fanProjectileSpeed = 5f;
    private float fanSpread = 20f;

    [SerializeField] private GameObject whirlwindAttackPrefab;
    private float whirlwindDamageMultiplier = 1.5f;
    private float whirlwindAttackDelay = 8f;
    private int whirlwindCount = 3;
    private int whirlwindLeafCount = 12;
    private float whirlwindBarrageDelay = 2f;

    [SerializeField] private AudioClip attackSFX;

    private IEnumerator MeleeAttackCoroutine()
    {
        if (AttackRange >= CheckDistance())
        {
            SetActionCooldown(AttackDelay);
            yield return new WaitForSeconds(1f);
            Animator.SetBool("Attacking", true);
            for (int i = 0; i < meleeProjectileCount; i++)
            {
                GameObject attack = Instantiate(meleeAttackPrefab, transform.position, Quaternion.identity);
                attack.GetComponent<WindBlade>().Damage = AttackPower * meleeDamageMultiplier;
                Orbit script = attack.GetComponent<Orbit>();
                script.Axis = transform;
                script.Angle = (360f / meleeProjectileCount) * i;
            }
            AttackSFX();
            yield return new WaitForSeconds(1f);
            Animator.SetBool("Attacking", false);
        }
    }

    private IEnumerator BarrageAttackCoroutine()
    {
        SetActionCooldown(barrageAttackDelay);
        for (int i = 0; i < barrageProjectileCount; i++)
        {
            GameObject projectile = Instantiate(rangeAttackPrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<WindBlade>().Damage = AttackPower * barrageDamageMultiplier;
            Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();
            rigid.AddForce(FacingDirection.normalized * barrageProjectileSpeed, ForceMode2D.Impulse);
            AttackSFX();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator FanAttackCoroutine()
    {
        SetActionCooldown(fanAttackDelay);
        for (int i = 0; i < fanBarrageCount; i++)
        {
            Vector3 skillDirection = Quaternion.AngleAxis(-(fanSpread * ((float)fanProjectileCount - 1f) / 2), Vector3.forward) * FacingDirection;
            Vector3 offset = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3));
            skillDirection += offset;
            for (int k = 0; k < fanProjectileCount; k++)
            {
                GameObject projectile = Instantiate(rangeAttackPrefab, transform.position, Quaternion.identity);
                projectile.GetComponent<WindBlade>().Damage = AttackPower * fanDamageMultiplier;
                Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();
                rigid.AddForce(skillDirection.normalized * fanProjectileSpeed, ForceMode2D.Impulse);
                skillDirection = Quaternion.AngleAxis(fanSpread, Vector3.forward) * skillDirection;
            }
            AttackSFX();
            yield return new WaitForSeconds(fanBarrageDelay);
        }
    }

    private IEnumerator WhirlwindAttackCoroutine()
    {
        SetActionCooldown(whirlwindAttackDelay);
        Animator.SetBool("Attacking", true);
        for (int i = 0; i < whirlwindCount; i++)
        {
            for (int j = 0; j < whirlwindLeafCount; j++)
            {
                GameObject projectile = Instantiate(whirlwindAttackPrefab, transform.position, Quaternion.identity);
                projectile.GetComponent<WindBlade>().Damage = AttackPower * whirlwindDamageMultiplier;
                Orbit script = projectile.GetComponent<Orbit>();
                script.Axis = gameObject.transform;
                script.Angle = 360f * 1 / whirlwindLeafCount * j;
            }
            AttackSFX();
            yield return new WaitForSeconds(whirlwindBarrageDelay);
        }
        Animator.SetBool("Attacking", false);
    }

    private void AttackSelection()
    {
        if (CanAttack())
        {
            int attack = Random.Range(1, 5);
            switch (attack)
            {
                case 1:
                    StartCoroutine(MeleeAttackCoroutine());
                    break;
                case 2:
                    StartCoroutine(BarrageAttackCoroutine());
                    break;
                case 3:
                    StartCoroutine(FanAttackCoroutine());
                    break;
                case 4:
                    StartCoroutine(WhirlwindAttackCoroutine());
                    break;
            }
        }
    }

    private void AttackSFX()
    {
        GameManager.Instance.GetComponent<AudioSource>().clip = attackSFX;
        GameManager.Instance.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyUpdate();
        AttackSelection();
    }
}
