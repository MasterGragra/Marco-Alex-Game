using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfAcuity : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Acuity";
    new string Description = "Increase spell cooldown speed by 10%";

    public void ApplyBlessing()
    {
        Player.Instance.SpellCooldownMultiplier += 0.1f;
    }
}
