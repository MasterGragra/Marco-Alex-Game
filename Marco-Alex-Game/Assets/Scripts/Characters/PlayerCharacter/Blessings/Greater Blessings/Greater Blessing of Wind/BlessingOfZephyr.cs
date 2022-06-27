using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfZephyr : Blessing, IBlessing
{
    new string BlessingName = "Blessing of Zephyr";
    new string Description = "Increases Wind Blades projectile speed by 100%, its damage by 30% and the character's movement speed by 30%";

    public void ApplyBlessing()
    {
        Player.Instance.GetComponent<WindBladesSpell>().Zephyr = true;
        Player.Instance.WindSpellModifier += 0.3f;
        Player.Instance.GetComponent<PlayerMovement>().MovementSpeed *= 90f;
    }
}
