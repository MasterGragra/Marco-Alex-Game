using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfFortitude : MonoBehaviour, IBlessing
{
    public void ApplyBlessing()
    {
        Player.Instance.MaxHp += 20f;
    }
}
