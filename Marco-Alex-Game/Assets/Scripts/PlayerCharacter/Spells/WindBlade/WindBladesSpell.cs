using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBladesSpell : Spell
{
    private float windBladesSpeed = 15f;
    private int windBladesCount = 3;
    private float windBladesSpread = 15f;

    private void CastWindBlades()
    {
        if (CanCast())
        {
            Player.Instance.ActionCooldown(0.3f);
            MpCost(mpCost);
            Vector3 skillDirection = Quaternion.AngleAxis(-(windBladesSpread * ((float)windBladesCount - 1f) / 2), Vector3.forward) * Player.Instance.GetComponent<PlayerMovement>().PlayerDirection;
            for(int i = 0; i < windBladesCount; i++)
            {
                GameObject windBlade = Instantiate(spellPrefab, Player.Instance.transform.position, Quaternion.identity);
                Rigidbody2D rigid = windBlade.GetComponent<Rigidbody2D>();
                rigid.AddForce(skillDirection.normalized * windBladesSpeed, ForceMode2D.Impulse);
                skillDirection = Quaternion.AngleAxis(windBladesSpread, Vector3.forward) * skillDirection;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CastWindBlades();
    }
}
