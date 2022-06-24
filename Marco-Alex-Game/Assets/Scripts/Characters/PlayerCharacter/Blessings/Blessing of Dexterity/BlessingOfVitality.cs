using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfVitality : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Vitality";
    new string Description = "Increase max stamina by 20";

    public void ApplyBlessing()
    {
        Player.Instance.MaxStamina += 20f;
    }
}
