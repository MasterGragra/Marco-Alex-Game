using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfConflagration : GreaterBlessing
{
    new string BlessingName = "Blessing of Conflagration";
    new string Description = "Increase Fireball's explosion radius by 50% and its damage by 30%";

    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<FireballSpell>().Conflagration = true;
        Player.Instance.FireSpellModifier += 0.3f;
    }
}
