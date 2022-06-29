using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfPebbles : GreaterBlessing
{
    new string BlessingName = "Blessing of Pebbles";
    new string Description = "Grants Earth Shield 2 additional projectiles";

    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<EarthShieldSpell>().Pebbles = true;
    }
}
