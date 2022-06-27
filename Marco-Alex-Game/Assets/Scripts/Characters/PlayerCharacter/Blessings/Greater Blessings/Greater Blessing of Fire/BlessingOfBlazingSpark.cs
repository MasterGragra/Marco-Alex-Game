using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfBlazingSpark : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Blazing Sparks";
    new string Description = "Increase Fireball's projectile speed by 100% and its damage by 300%";

    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<FireballSpell>().BlazingSparks = true;
    }
}
