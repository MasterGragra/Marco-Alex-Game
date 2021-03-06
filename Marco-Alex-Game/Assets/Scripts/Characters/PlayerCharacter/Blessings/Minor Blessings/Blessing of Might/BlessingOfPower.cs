using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfPower : MinorBlessing
{
    new string BlessingName = "Blessing of Power";
    new string Description = "Increase attack power by 2";

    public override void ApplyBlessing()
    {
        Player.Instance.AttackPower += 2f;
    }
}
