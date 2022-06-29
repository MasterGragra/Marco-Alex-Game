using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfPiercingGales : GreaterBlessing
{
    new string BlessingName = "Blessing of Piercing Gales";
    new string Description = "Grants Wind Blades piercing properties and increases its damage by 50%";

    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<WindBladesSpell>().PiercingGales = true;
        Player.Instance.WindSpellModifier += 0.5f;
    }
}
