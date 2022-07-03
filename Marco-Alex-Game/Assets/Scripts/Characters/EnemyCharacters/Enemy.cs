using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private Rigidbody2D rigid;
    private Animator animator;
    private Transform target;

    [SerializeField] private float attackRange;
    [SerializeField] private float attackDelay;
    [SerializeField] private float movementSpeed;
    private Vector3 facingDirection;

    public Animator Animator { get => animator; set => animator = value; }
    public float AttackDelay { get => attackDelay; set => attackDelay = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public Vector3 FacingDirection { get => facingDirection; set => facingDirection = value; }

    // Start is called before the first frame update
    void Start()
    {
        CharacterStart();
        rigid = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        target = Player.Instance.transform;
        InvokeRepeating("FacePlayer", 0f, 0.2f);
        InvokeRepeating("Animate", 0f, 0.2f);
    }

    public float CheckDistance()
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }

    private void MoveEnemy()
    {
        if (AttackRange < CheckDistance() && movementSpeed > 0)
        {
            rigid.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.fixedDeltaTime));
            Animator.SetBool("Walking", true);
        }
        else Animator.SetBool("Walking", false);
    }

    private void FacePlayer()
    {
        FacingDirection = target.position - transform.position;
    }

    private void Animate()
    {
        Animator.SetFloat("X", FacingDirection.x);
        Animator.SetFloat("Y", FacingDirection.y);
    }

    public bool CanAttack()
    {
        if (!IsDead() && CheckCooldown()) return true;
        else return false;
    }

    public void EnemyUpdate()
    {
        Cooldown();
        if (!IsDead() && CheckCooldown())
        {
            MoveEnemy();
        }
    }
}
