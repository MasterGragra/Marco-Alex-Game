using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfLife : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Life";
    new string Description = "Increase healing spell potency by 10%";

    public void ApplyBlessing()
    {
        Player.Instance.HealSpellModifier += 0.1f;
    }
}
