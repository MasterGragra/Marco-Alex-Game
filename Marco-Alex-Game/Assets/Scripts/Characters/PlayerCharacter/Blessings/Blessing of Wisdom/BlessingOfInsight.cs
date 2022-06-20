using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfInsight : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.MpRegenMultiplier += 0.1f;
    }
}
