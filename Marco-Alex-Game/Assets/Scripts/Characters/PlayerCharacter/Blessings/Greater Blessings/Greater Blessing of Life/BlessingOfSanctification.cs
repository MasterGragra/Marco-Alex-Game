using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfSanctification : GreaterBlessing
{
    new string BlessingName = "Blessing Of Sanctification";
    new string Description = "Heal creates an area reduces damage taken by 30% for 8 seconds";

    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<HealSpell>().Sanctification = true;
    }
}
