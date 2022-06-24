using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfAgility : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Agility";
    new string Description = "Increase movement speed by 10%";

    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<PlayerMovement>().MovementSpeed += 30f;
    }
}
