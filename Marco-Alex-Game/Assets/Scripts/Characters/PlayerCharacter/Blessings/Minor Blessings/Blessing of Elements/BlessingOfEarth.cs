using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfEarth : MinorBlessing
{
    new string BlessingName = "Blessing of Earth";
    new string Description = "Increase earth spell damage by 10%";

    public override void ApplyBlessing()
    {
        Player.Instance.EarthSpellModifier += 0.1f;
    }
}
