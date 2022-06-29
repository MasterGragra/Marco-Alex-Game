using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfInsight : MinorBlessing
{
    new string BlessingName = "Blessing of Insight";
    new string Description = "Increase mana regeneration rate by 10%";

    public override void ApplyBlessing()
    {
        Player.Instance.MpRegenMultiplier += 0.1f;
    }
}
