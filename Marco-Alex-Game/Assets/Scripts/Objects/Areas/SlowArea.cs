using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowArea : EnterAreaEffect
{
    public override void ApplyAreaEffect()
    {
        Player.Instance.MovementSpeedMultiplier -= 0.5f;
    }

    public override void RemoveAreaEffect()
    {
        Player.Instance.MovementSpeedMultiplier += 0.5f;
    }
}
