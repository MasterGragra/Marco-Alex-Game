using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfVitality : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.MaxStamina += 20f;
    }
}
