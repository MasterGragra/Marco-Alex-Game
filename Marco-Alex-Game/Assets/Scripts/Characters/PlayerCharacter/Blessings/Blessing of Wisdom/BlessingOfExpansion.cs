using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfExpansion : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Expansion";
    new string Description = "Increase maximum mana by 20";

    public void ApplyBlessing()
    {
        Player.Instance.MaxMp += 20f;
    }
}
