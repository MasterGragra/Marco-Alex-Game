using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfNapalm : GreaterBlessing
{
    new string BlessingName = "Blessing of Napalm";
    new string Description = "Fireball creates fire in a X pattern after detonation and increases burn damage by 50%";

    public override void ApplyBlessing()
    {
        Player.Instance.GetComponent<FireballSpell>().Napalm = true;
    }
}
