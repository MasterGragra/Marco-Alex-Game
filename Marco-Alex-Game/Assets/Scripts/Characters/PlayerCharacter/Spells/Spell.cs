using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spell : MonoBehaviour
{
    private string spellName;

    [SerializeField] private GameObject spellPrefab;
    private bool spellcast;
    [SerializeField] private float damageMultiplier;
    [SerializeField] private float mpCost;
    [SerializeField] private float spellCooldown;
    private float spellCooldownTimer = 0f;

    [SerializeField] private bool buffSpell = false;

    [SerializeField] private AudioClip spellSFX;
    [SerializeField] private float sfxDuration;

    public string SpellName { get => spellName; set => spellName = value; }
    public GameObject SpellPrefab { get => spellPrefab; set => spellPrefab = value; }
    public bool Spellcast { get => spellcast; set => spellcast = value; }
    public float DamageMultiplier { get => damageMultiplier; set => damageMultiplier = value; }
    public float MpCost { get => mpCost; set => mpCost = value; }
    public float SpellCooldown { get => spellCooldown; set => spellCooldown = value; }
    public float SpellCooldownTimer { get => spellCooldownTimer; set => spellCooldownTimer = value; }

    public void OnSpellcast(InputAction.CallbackContext context)
    {
        Spellcast = context.performed;
    }

    public float CalculateDamage(float spellModifier)
    {
        return Player.Instance.SpellPower * DamageMultiplier * spellModifier;
    }

    private bool MpCostCheck()
    {
        if (MpCost <= Player.Instance.Mp) return true;
        else return false;
    }

    public void MpCostDeduction()
    {
        Player.Instance.Mp -= MpCost;
    }

    public bool CanCast()
    {
        if (Spellcast && !Player.Instance.IsDead() 
            && Player.Instance.CheckCooldown() 
            && MpCostCheck())
        {
            if (SpellCooldownCheck())
            {
                Player.Instance.SetActionCooldown();
                MpCostDeduction();

                SpellcastAnimation();

                StartCoroutine(SpellSFX(sfxDuration));

                return true;
            }
        }
        return false;
    }

    private bool SpellCooldownCheck()
    {
        if(SpellCooldownTimer <= 0)
        {
            SpellCooldownTimer = SpellCooldown;
            return true;
        }
        return false;
    }

    private void SpellCooldownManager()
    {
        if(SpellCooldownTimer > 0)
        {
            SpellCooldownTimer -= Player.Instance.SpellCooldownMultiplier * Time.deltaTime;
        }
    }

    public void SpellcastAnimation()
    {
        if (buffSpell) Player.Instance.Animator.SetTrigger("Buffcast");
        else Player.Instance.Animator.SetTrigger("Spellcast");
    }

    private IEnumerator SpellSFX(float duration)
    {
        Player.Instance.NormalAudio.clip = spellSFX;
        Player.Instance.NormalAudio.Play();
        if (duration > 0)
        {
            yield return new WaitForSeconds(duration);
            Player.Instance.NormalAudio.Stop();
        }
    }

    private void FixedUpdate()
    {
        SpellCooldownManager();
    }
}
