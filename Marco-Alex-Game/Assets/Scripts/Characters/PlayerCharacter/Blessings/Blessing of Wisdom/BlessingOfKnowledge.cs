using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfKnowledge : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Knowledge";
    new string Description = "Increase spell power by 2";

    public void ApplyBlessing()
    {
        Player.Instance.SpellPower += 2f;
    }
}
