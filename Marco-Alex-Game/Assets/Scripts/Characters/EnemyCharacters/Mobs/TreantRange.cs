using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantRange : Enemy
{
    [SerializeField] private GameObject attackPrefab;
    private float attackMultiplier = 1f;
    private int attackCount = 3;
    private float fanSpread = 30f;
    private float projectileSpeed = 5f;
    [SerializeField] private AudioClip attackSFX;

    private void RangedAttack()
    {
        if (CanAttack() && AttackRange >= CheckDistance()) StartCoroutine(RangedAttackCoroutine());
    }

    private IEnumerator RangedAttackCoroutine()
    {
        SetActionCooldown(AttackDelay);
        yield return new WaitForSeconds(0.5f);
        Vector3 skillDirection = Quaternion.AngleAxis(-(fanSpread * ((float)attackCount - 1f) / 2), Vector3.forward) * FacingDirection;
        for (int k = 0; k < attackCount; k++)
        {
            GameObject projectile = Instantiate(attackPrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<WindBlade>().Damage = AttackPower * attackMultiplier;
            Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();
            rigid.AddForce(skillDirection.normalized * projectileSpeed, ForceMode2D.Impulse);
            skillDirection = Quaternion.AngleAxis(fanSpread, Vector3.forward) * skillDirection;
        }
        AttackSFX();
    }
    private void AttackSFX()
    {
        GameManager.Instance.GetComponent<AudioSource>().clip = attackSFX;
        GameManager.Instance.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyUpdate();
        RangedAttack();
    }
}
