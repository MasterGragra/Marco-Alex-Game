using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfAlacrity : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.AttackSpeedMultiplier += 0.1f;
    }
}
