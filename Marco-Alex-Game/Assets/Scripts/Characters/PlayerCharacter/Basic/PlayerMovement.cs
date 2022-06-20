using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float movementSpeed = 300f;
    private Vector2 movement;
    private string direction = "Down";
    private Vector2 playerDirection = new Vector2(0f, -1f);
    private bool usingPhysics = false;

    [SerializeField] private AudioClip walkingSFX;
    private float walkCount = 0;

    public string Direction { get => direction; set => direction = value; }
    public Vector2 PlayerDirection { get => playerDirection; set => playerDirection = value; }
    public bool UsingPhysics { get => usingPhysics; set => usingPhysics = value; }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        if (Player.Instance.Animator.GetBool("Moving"))
        {
            rigid.velocity = movement.normalized * movementSpeed * Player.Instance.MovementSpeedMultiplier * Time.fixedDeltaTime;
        }
        else if(!UsingPhysics)
        {
            rigid.velocity = Vector2.zero;
        }
    }

    private void Animate()
    {
        if (movement != Vector2.zero && Player.Instance.CheckCooldown())
        {
            Player.Instance.Animator.SetFloat("X", movement.x);
            Player.Instance.Animator.SetFloat("Y", movement.y);
            Player.Instance.Animator.SetBool("Moving", true);

            CheckDirection();
        }
        else
        {
            Player.Instance.Animator.SetBool("Moving", false);
        }
    }

    private void CheckDirection()
    {
        if (movement.y > 0) Direction = "Up";
        else if (movement.y < 0) Direction = "Down";
        else if (movement.x > 0) Direction = "Right";
        else if (movement.x < 0) Direction = "Left";
    }

    private void CalculateDirection()
    {
        if ((movement.x != 0 || movement.y != 0) && Player.Instance.CheckCooldown())
        {
            PlayerDirection = new Vector2(movement.x, movement.y);
        }
    }

    private void WalkingSFX()
    {
        if (Player.Instance.Animator.GetBool("Moving") && walkCount == 0)
        {
            Player.Instance.LoopingAudio.Play();
        }
        else Player.Instance.LoopingAudio.Stop();

        walkCount += Time.deltaTime;
        if (walkCount >= 0.3 || !Player.Instance.Animator.GetBool("Moving"))
        {
            walkCount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.Instance.IsDead())
        {
            Animate();
            Move();
            CalculateDirection();
            WalkingSFX();
        }
    }
}
