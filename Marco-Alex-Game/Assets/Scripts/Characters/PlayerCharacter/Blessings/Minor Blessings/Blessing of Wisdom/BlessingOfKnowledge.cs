using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfKnowledge : MinorBlessing
{
    new string BlessingName = "Blessing of Knowledge";
    new string Description = "Increase spell power by 2";

    public override void ApplyBlessing()
    {
        Player.Instance.SpellPower += 2f;
    }
}
