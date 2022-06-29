using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfFortification : GreaterBlessing
{
    new string BlessingName = "Blessing of Fortification";
    new string Description = "Earth Shield projectiles break after 2 impacts instead of 1";

    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<EarthShieldSpell>().Fortification = true;
    }
}
