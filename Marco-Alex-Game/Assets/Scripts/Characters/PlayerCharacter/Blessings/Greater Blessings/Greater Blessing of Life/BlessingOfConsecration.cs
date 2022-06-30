using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfConsecration : GreaterBlessing
{
    new string BlessingName = "Blessing Of Consecration";
    new string Description = "Heal creates an area that deals damage to enemies equal to 10% of its healing amount per second for 8 seconds";

    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<HealSpell>().Consecration = true;
    }
}
