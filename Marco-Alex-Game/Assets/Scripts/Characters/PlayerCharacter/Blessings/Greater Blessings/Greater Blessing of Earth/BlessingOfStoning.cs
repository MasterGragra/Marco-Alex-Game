using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfStoning : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Stoning";
    new string Description = "Cast Earth Shield while it is active to throw the barrier forward and increase its damage by 50%";
    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<EarthShieldSpell>().Stoning = true;
    }
}
