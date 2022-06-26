using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfStratification : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Stratification";
    new string Description = "Grants Earth Shield an extra layer";
    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<EarthShieldSpell>().Stratification = true;
    }
}
