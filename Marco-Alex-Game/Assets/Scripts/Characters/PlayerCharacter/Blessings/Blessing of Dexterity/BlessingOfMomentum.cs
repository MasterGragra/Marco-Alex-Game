using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfMomentum : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.SkillCooldownMultiplier += 0.1f;
    }
}
