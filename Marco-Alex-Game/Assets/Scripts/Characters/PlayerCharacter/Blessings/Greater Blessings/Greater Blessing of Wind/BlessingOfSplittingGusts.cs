using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfSplittingGusts : GreaterBlessing
{
    new string BlessingName = "Blessing of Splitting Gusts";
    new string Description = "Grants Wind Blades 2 additional projectiles";
    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<WindBladesSpell>().SplittingGust = true;
    }
}
