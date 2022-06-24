using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfAgility : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Agility";
    new string Description = "Increase movement speed by 20%";

    public void ApplyBlessing()
    {
        Player.Instance.MovementSpeedMultiplier += 0.2f;
    }
}
