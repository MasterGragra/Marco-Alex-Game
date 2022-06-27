using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfAmaterasu : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Amaterasu";
    new string Description = "Increase the lifetime of the flames from Fireball's explosion by 100% and turn the flames black";

    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<FireballSpell>().Amaterasu = true;
    }
}
