using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfStratification : GreaterBlessing
{
    new string BlessingName = "Blessing of Stratification";
    new string Description = "Grants Earth Shield an extra layer";

    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<EarthShieldSpell>().Stratification = true;
    }
}
