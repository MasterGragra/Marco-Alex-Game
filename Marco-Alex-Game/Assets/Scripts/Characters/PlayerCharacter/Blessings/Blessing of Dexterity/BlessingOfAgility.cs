using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfAgility : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.MovementSpeedMultiplier += 0.2f;
    }
}
