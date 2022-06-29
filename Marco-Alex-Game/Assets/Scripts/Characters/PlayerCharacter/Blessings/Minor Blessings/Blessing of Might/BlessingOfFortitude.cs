using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfFortitude : MinorBlessing
{
    new string BlessingName = "Blessing of Fortitude";
    new string Description = "Increase maximum health point by 20";

    public override void ApplyBlessing()
    {
        Player.Instance.MaxHp += 20f;
    }
}
