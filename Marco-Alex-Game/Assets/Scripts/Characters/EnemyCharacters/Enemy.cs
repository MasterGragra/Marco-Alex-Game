using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private Rigidbody2D rigid;
    private Animator animator;
    private Transform target;

    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackDelay = 2f;
    [SerializeField] private float movementSpeed = 5f;
    private Vector3 facingDirection;

    public Animator Animator { get => animator; set => animator = value; }
    public float AttackDelay { get => attackDelay; set => attackDelay = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }

    // Start is called before the first frame update
    void Start()
    {
        CharacterStart();
        rigid = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        target = Player.Instance.transform;
        InvokeRepeating("FacePlayer", 0f, 0.2f);
    }

    public float CheckDistance()
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }

    private void MoveEnemy()
    {
        if (AttackRange < CheckDistance())
        {
            rigid.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.fixedDeltaTime));
            Animator.SetBool("Walking", true);
        }
        else Animator.SetBool("Walking", false);
    }

    private void FacePlayer()
    {
        facingDirection = target.position - transform.position;
    }

    private void Animate()
    {
        Animator.SetFloat("X", facingDirection.x);
        Animator.SetFloat("Y", facingDirection.y);
    }

    public void EnemyUpdate()
    {
        if (!IsDead() && CheckCooldown())
        {
            MoveEnemy();
            FacePlayer();
            Animate();
        }
        Cooldown();
    }
}
