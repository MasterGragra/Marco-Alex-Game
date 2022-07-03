using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantMelee : Enemy
{
    [SerializeField] private GameObject attackPrefab;
    private float attackMultiplier = 0.5f;
    private int attackCount = 3;
    [SerializeField] private AudioClip attackSFX;

    private void MeleeAttack()
    {
        if (CanAttack() && AttackRange >= CheckDistance()) StartCoroutine(MeleeAttackCoroutine());
    }

    private IEnumerator MeleeAttackCoroutine()
    {
        SetActionCooldown(AttackDelay);
        yield return new WaitForSeconds(0.5f);
        Animator.SetBool("Attacking", true);
        for (int i = 0; i < attackCount; i++)
        {
            GameObject attack = Instantiate(attackPrefab, transform.position, Quaternion.identity);
            attack.GetComponent<WindBlade>().Damage = AttackPower * attackMultiplier;
            Orbit script = attack.GetComponent<Orbit>();
            script.Axis = transform;
            script.Angle = (360f / attackCount) * i;
        }
        AttackSFX();
        yield return new WaitForSeconds(1f);
        Animator.SetBool("Attacking", false);
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
        MeleeAttack();
    }
}
