using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfEndurance : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.AttackStaminaCostMultiplier -= 0.2f;
    }
}
