using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfFortification : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Fortification";
    new string Description = "Earth Shield projectiles break after 2 impacts instead of 1";
    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<EarthShieldSpell>().Fortification = true;
    }
}
