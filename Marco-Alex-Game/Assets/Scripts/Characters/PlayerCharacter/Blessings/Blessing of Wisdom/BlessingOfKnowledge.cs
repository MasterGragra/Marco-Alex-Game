using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfKnowledge : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.SpellPower += 2f;
    }
}
