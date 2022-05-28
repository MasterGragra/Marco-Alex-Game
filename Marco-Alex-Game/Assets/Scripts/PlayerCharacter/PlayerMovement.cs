using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float movespeed = 500f;
    private Vector2 movement;
    private string direction = "Down";
    private Vector2 playerDirection = new Vector2(0f, -1f);

    public string Direction { get => direction; set => direction = value; }
    public Vector2 PlayerDirection { get => playerDirection; set => playerDirection = value; }

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
            rigid.velocity = movement.normalized * movespeed * Time.fixedDeltaTime;
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
    }

    private void Animate()
    {
        if (movement != Vector2.zero && Player.Instance.CooldownCheck())
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
        if ((movement.x != 0 || movement.y != 0) && Player.Instance.CooldownCheck())
        {
            PlayerDirection = new Vector2(movement.x, movement.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        Move();
        CalculateDirection();
    }
}
