using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanctificationArea : EnterAreaEffect
{
    public override void ApplyAreaEffect()
    {
        Player.Instance.DamageReduction += 0.3f;
    }

    public override void RemoveAreaEffect()
    {
        Player.Instance.DamageReduction -= 0.3f;
    }
}
