using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfMomentum : MinorBlessing
{
    new string BlessingName = "Blessing of Momentum";
    new string Description = "Increase skill cooldown speed by 10%";

    public override void ApplyBlessing()
    {
        Player.Instance.SkillCooldownMultiplier += 0.1f;
    }
}
