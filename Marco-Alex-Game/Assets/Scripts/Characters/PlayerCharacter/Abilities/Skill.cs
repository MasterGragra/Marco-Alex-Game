using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Skill : MonoBehaviour
{
    private bool skillUse;
    [SerializeField] private float staminaCost;
    [SerializeField] private float actionCooldown = 0.3f;

    public float ActionCooldown { get => actionCooldown; set => actionCooldown = value; }

    public void OnSkillUse(InputAction.CallbackContext context)
    {
        skillUse = context.performed;
    }

    private bool StaminaCostCheck()
    {
        if (staminaCost <= Player.Instance.Stamina) return true;
        else return false;
    }

    public void PayStaminaCost()
    {
        Player.Instance.Stamina -= staminaCost;
    }

    public bool CanUse()
    {
        if (skillUse && Player.Instance.CooldownCheck() && StaminaCostCheck())
        {
            Player.Instance.ActionCooldown(ActionCooldown);
            PayStaminaCost();
            return true;
        }
        return false;
    }
}
