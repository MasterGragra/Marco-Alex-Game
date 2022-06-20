using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfRecovery : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.StaminaRegenMultiplier += 0.1f;
    }
}
