using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfPebbles : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Pebbles";
    new string Description = "Grants Earth Shield 2 additional projectiles";
    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<EarthShieldSpell>().Pebbles = true;
    }
}
