using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfAcuity : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.SpellCooldownMultiplier += 0.1f;
    }
}
