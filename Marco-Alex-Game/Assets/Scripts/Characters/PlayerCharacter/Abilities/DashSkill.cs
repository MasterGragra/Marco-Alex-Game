using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    private float DashForce = 30f;
    private Rigidbody2D rigid;
    private Animator animator;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void UseDash()
    {
        if (CanUse()) StartCoroutine("Dash");
    }

    private IEnumerator Dash()
    {
        playerMovement.UsingPhysics= true;
        rigid.AddForce(playerMovement.PlayerDirection.normalized * DashForce, ForceMode2D.Impulse);
        animator.SetTrigger("Spellcast");
        yield return new WaitForSeconds(ActionCooldown);
        playerMovement.UsingPhysics = false;
    }

    // Update is called once per frame
    void Update()
    {
        UseDash();  
    }
}
