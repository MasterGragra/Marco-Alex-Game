using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spell : MonoBehaviour
{
    private bool spellcast;
    public float mpCost;

    public void OnSpellcast(InputAction.CallbackContext context)
    {
        spellcast = context.performed;
    }

    private bool MpCostCheck()
    {
        if (mpCost <= Player.Instance.Mp) return true;
        else return false;
    }

    public void MpCost(float mpCost)
    {
        Player.Instance.Mp -= mpCost;
    }

    public bool CanCast()
    {
        if (spellcast && Player.Instance.CooldownCheck() && MpCostCheck()) return true;
        return false;
    }
}
