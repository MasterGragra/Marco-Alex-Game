using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animator;
    private Transform target;
    private Enemy script;

    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float movementSpeed = 5f;
    private Vector3 facingDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = Player.Instance.transform;
        script = GetComponent<Enemy>();
        InvokeRepeating("FacePlayer", 0f, 0.2f);
    }

    private float CheckDistance()
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }

    private void MoveEnemy()
    {
        if (attackRange < CheckDistance())
        {
            rigid.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.fixedDeltaTime));
            animator.SetBool("Walking", true);
        }
        else animator.SetBool("Walking", false);
    }

    private void FacePlayer()
    {
        facingDirection = target.position - transform.position;
    }

    private void Animate()
    {
        animator.SetFloat("X", facingDirection.x);
        animator.SetFloat("Y", facingDirection.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!script.IsDead() && script.CheckCooldown())
        {
            MoveEnemy();
            FacePlayer();
            Animate();
        }
    }
}
