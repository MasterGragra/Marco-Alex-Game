using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfAlacrity : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Alacrity";
    new string Description = "Increase attack speed by 10%";

    public void ApplyBlessing()
    {
        Player.Instance.AttackSpeedMultiplier += 0.1f;
    }
}
