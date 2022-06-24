using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfSplittingGusts : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Splitting Gusts";
    new string Description = "Grants Wind Blades 2 additional projectiles";
    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<WindBladesSpell>().SplittingGust = true;
        Player.Instance.GetComponent<WindBladesSpell>().WindBladesCount += 2;
    }
}
