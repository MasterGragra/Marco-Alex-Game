using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfAcuity : MinorBlessing
{
    new string BlessingName = "Blessing of Acuity";
    new string Description = "Increase spell cooldown speed by 10%";

    public override void ApplyBlessing()
    {
        Player.Instance.SpellCooldownMultiplier += 0.1f;
    }
}
