using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfFire : MinorBlessing
{
    new string BlessingName = "Blessing of Fire";
    new string Description = "Increase fire spell damage by 10%";

    public override void ApplyBlessing()
    {
        Player.Instance.FireSpellModifier += 0.1f;
    }
}
