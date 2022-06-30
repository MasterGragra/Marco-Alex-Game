using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfPurity : GreaterBlessing
{
    new string BlessingName = "Blessing Of Purity";
    new string Description = "Increase Heal's area effects by 50%";

    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<HealSpell>().Purity = true;
    }
}
