using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfHolyGrounds : GreaterBlessing
{
    new string BlessingName = "Blessing Of Holy Grounds";
    new string Description = "Heal creates an area that heals the player for 5% of its healing amount per second for 8 seconds";

    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<HealSpell>().HolyGrounds = true;
    }
}
