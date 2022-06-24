using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfZephyr : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Zephyr";
    new string Description = "Increases Wind Blades projectile speed by 100% and character movement speed by 30%";

    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<WindBladesSpell>().Zephyr = true;
        Player.Instance.GetComponent<PlayerMovement>().MovementSpeed += 90f;
    }
}
