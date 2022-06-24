using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfInvigoration : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Invigoration";
    new string Description = "Increase stamina regeneration rate by 10%";

    public void ApplyBlessing()
    {
        Player.Instance.StaminaRegenMultiplier += 0.1f;
    }
}
