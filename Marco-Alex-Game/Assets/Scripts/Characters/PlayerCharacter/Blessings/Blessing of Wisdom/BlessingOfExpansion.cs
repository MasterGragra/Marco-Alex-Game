using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfExpansion : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.MaxMp += 40f;
    }
}
