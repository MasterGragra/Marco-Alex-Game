using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Skill : MonoBehaviour
{
    private bool skillUse;
    [SerializeField] private float staminaCost;
    [SerializeField] private float actionCooldown = 0.3f;
    [SerializeField] private float skillCooldown;
    private float skillCooldownTimer = 0f;

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

    public void StaminaCost()
    {
        Player.Instance.Stamina -= staminaCost;
    }

    public bool CanUse()
    {
        if (skillUse && !Player.Instance.IsDead() 
            && Player.Instance.CheckCooldown() 
            && StaminaCostCheck())
        
        {
            if (SkillCooldownCheck())
            {
                Player.Instance.SetActionCooldown(ActionCooldown);
                StaminaCost();
                return true;
            }
        }
        return false;
    }
    private bool SkillCooldownCheck()
    {
        if (skillCooldownTimer <= 0)
        {
            skillCooldownTimer = skillCooldown;
            return true;
        }
        return false;
    }

    private void SkillCooldownManager()
    {
        if (skillCooldownTimer > 0)
        {
            skillCooldownTimer -= Player.Instance.SkillCooldownMultiplier * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        SkillCooldownManager();
    }
}
