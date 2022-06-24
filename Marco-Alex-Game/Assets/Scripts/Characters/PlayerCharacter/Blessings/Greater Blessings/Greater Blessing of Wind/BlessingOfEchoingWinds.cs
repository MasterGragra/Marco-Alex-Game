using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfEchoingWinds : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Echoing Winds";
    new string Description = "Grants Wind Blades the ability to bounce of walls and increases their lifetime by 200%";

    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<WindBladesSpell>().EchoingWind = true;
        Player.Instance.GetComponent<WindBladesSpell>().SpellPrefab.GetComponent<Projectile>().Lifetime *= 3f;
    }
}
