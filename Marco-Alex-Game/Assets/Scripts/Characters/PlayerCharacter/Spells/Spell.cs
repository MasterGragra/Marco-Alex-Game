using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spell : MonoBehaviour
{
    [SerializeField] private GameObject spellPrefab;
    private bool spellcast;
    [SerializeField] private float mpCost;
    [SerializeField] private float actionCooldown = 0.3f;
    [SerializeField] private float spellCooldown;

    [SerializeField] private bool buffSpell = false;

    [SerializeField] private AudioClip spellSFX;
    [SerializeField] private float sfxDuration;

    public GameObject SpellPrefab { get => spellPrefab; set => spellPrefab = value; }

    public void OnSpellcast(InputAction.CallbackContext context)
    {
        spellcast = context.performed;
    }

    private bool MpCostCheck()
    {
        if (mpCost <= Player.Instance.Mp) return true;
        else return false;
    }

    public void MpCost()
    {
        Player.Instance.Mp -= mpCost;
    }

    public bool CanCast()
    {
        if (spellcast && Player.Instance.CooldownCheck() && MpCostCheck())
        {
            Player.Instance.ActionCooldown(actionCooldown);
            MpCost();

            SpellcastAnimation();

            StartCoroutine("SpellSFX", sfxDuration);

            return true;
        }
        return false;
    }

    private void SpellcastAnimation()
    {
        if (buffSpell) Player.Instance.Animator.SetTrigger("Buffcast");
        else Player.Instance.Animator.SetTrigger("Spellcast");
    }

    private IEnumerator SpellSFX(float duration)
    {
        Player.Instance.NormalAudio.clip = spellSFX;
        Player.Instance.NormalAudio.Play();
        yield return new WaitForSeconds(duration);
        Player.Instance.NormalAudio.Stop();
    }
}
