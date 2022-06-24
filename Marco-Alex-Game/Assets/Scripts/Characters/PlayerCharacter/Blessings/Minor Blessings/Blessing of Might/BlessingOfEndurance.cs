using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfEndurance : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Endurance";
    new string Description = "Decrease basic attack stamina cost by 10%";

    public void ApplyBlessing()
    {
        Player.Instance.AttackStaminaCostMultiplier -= 0.1f;
    }
}
