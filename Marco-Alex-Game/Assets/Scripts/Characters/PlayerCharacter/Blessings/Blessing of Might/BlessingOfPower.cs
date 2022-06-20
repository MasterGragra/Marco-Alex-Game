using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfPower : MonoBehaviour, IBlessing
{ 
    public void ApplyBlessing()
    {
        Player.Instance.AttackPower += 2f;
    }
}
