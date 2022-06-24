using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfInsight : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Insight";
    new string Description = "Increase mana regeneration rate by 10%";

    public void ApplyBlessing()
    {
        Player.Instance.MpRegenMultiplier += 0.1f;
    }
}
