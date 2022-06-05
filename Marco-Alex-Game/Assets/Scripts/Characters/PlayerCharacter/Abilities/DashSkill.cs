using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    private float DashForce = 30f;
    private Rigidbody2D rigid;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void UseDash()
    {
        if (CanUse()) StartCoroutine("Dash");
    }

    private IEnumerator Dash()
    {
        playerMovement.Dashing = true;
        rigid.AddForce(playerMovement.PlayerDirection.normalized * DashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(ActionCooldown);
        playerMovement.Dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        UseDash();  
    }
}
