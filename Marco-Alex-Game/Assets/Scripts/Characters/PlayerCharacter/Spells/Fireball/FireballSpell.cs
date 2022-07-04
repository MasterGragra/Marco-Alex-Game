using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : Spell, ISpell
{
    new string SpellName = "Fireball";

    private float fireballSpeed = 10f;

    private bool amaterasu = false;
    private float amaterasuDurationMultiplier = 2f;

    private bool blazingSparks = false;
    private float blazingSparkSpeedMultiplier = 2f;
    private float blazingSparkDamageMultiplier = 3f;

    private bool conflagration = false;
    private float conflagrationScaleMultiplier = 1.5f;

    private bool napalm = false;
    private float napalmBurnDamageMultiplier = 1.5f;

    public bool Conflagration { get => conflagration; set => conflagration = value; }
    public bool Amaterasu { get => amaterasu; set => amaterasu = value; }
    public bool Napalm { get => napalm; set => napalm = value; }
    public bool BlazingSparks { get => blazingSparks; set => blazingSparks = value; }

    //void Start()
    //{
    //    Amaterasu = true;
    //    BlazingSparks = true;
    //    Conflagration = true;
    //    Napalm = true;
    //}

    public string ReturnDescription()
    {
        float damage = ((BlazingSparks) ? CalculateDamage(Player.Instance.FireSpellModifier) * blazingSparkDamageMultiplier : CalculateDamage(Player.Instance.FireSpellModifier));
        float duration = ((Amaterasu) ? SpellPrefab.GetComponent<Projectile>().Lifetime * amaterasuDurationMultiplier : SpellPrefab.GetComponent<Projectile>().Lifetime);
        float burnDamage = ((Napalm) ? CalculateDamage(Player.Instance.FireSpellModifier) * napalmBurnDamageMultiplier : CalculateDamage(Player.Instance.FireSpellModifier));

        return "Press 1 to cast " + SpellName + " for " + MpCost + " mana, shooting a"
            + ((BlazingSparks) ? " quick" : "") + " fireball that deals " 
            + damage + " damage to enemies on impact and creates flames in"
            + ((Conflagration) ? " a big" : " an") + " area that lasts "+ duration
            + " seconds that deals " + burnDamage + " damage every 0.3 seconds"
            + ((Napalm) ? " and spawns more flames in an X pattern" : "") + ".\nCooldown: " + SpellCooldown + " seconds";
    }

    private void CastFireball()
    {
        if (CanCast())
        {
            GameObject fireball = Instantiate(SpellPrefab, Player.Instance.transform.position, Quaternion.identity);
            Fireball script = fireball.GetComponent<Fireball>();
            script.Damage = CalculateDamage(Player.Instance.FireSpellModifier);
            if (BlazingSparks) script.Damage *= blazingSparkDamageMultiplier;
            script.BurnDamage = CalculateDamage(Player.Instance.FireSpellModifier / 2f);
            if (Napalm)
            {
                script.Napalm = true;
                script.BurnDamage *= napalmBurnDamageMultiplier;
            }
            if (Amaterasu) script.FlameDurationMultiplier = amaterasuDurationMultiplier;
            if (Conflagration) script.ExplosionScale = conflagrationScaleMultiplier;

            Rigidbody2D rigid = fireball.GetComponent<Rigidbody2D>();
            Vector2 vector = Player.Instance.GetComponent<PlayerMovement>().PlayerDirection.normalized * fireballSpeed;
            if (blazingSparks) vector *= blazingSparkSpeedMultiplier;
            rigid.AddForce(vector, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        CastFireball();
        if (Input.GetKeyDown(KeyCode.H))
            Debug.Log(ReturnDescription());
    }
}
