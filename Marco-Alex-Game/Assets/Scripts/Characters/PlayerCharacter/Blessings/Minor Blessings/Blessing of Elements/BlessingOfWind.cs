using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfWind : MinorBlessing
{
    new string BlessingName = "Blessing of Wind";
    new string Description = "Increase wind spell damage by 10%";

    public override void ApplyBlessing()
    {
        Player.Instance.WindSpellModifier += 0.1f;
    }
}
