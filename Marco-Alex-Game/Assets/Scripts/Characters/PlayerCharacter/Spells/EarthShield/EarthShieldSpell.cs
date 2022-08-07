using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShieldSpell : Spell, ISpell
{
    new string SpellName = "Earth Shield";

    private int earthShieldCount = 3;
    private bool active = false;

    private bool fortification = false;
    private bool pebbles = false;

    private bool stoning = false;
    [SerializeField] GameObject stoningPrefab;
    private float stoningMultiplier = 1.5f;
    private float stoningSpeed = 15f;

    private bool stratification = false;
    [SerializeField] GameObject stratificationPrefab;

    public int EarthShieldCount { get => earthShieldCount; set => earthShieldCount = value; }
    public bool Fortification { get => fortification; set => fortification = value; }
    public bool Pebbles { get => pebbles; set => pebbles = value; }
    public bool Stoning { get => stoning; set => stoning = value; }
    public bool Stratification { get => stratification; set => stratification = value; }

    //void Start()
    //{
    //    fortification = true;
    //    pebbles = true;
    //    stoning = true;
    //    stratification = true;
    //}

    public string ReturnDescription()
    {
        return "Press 3 to cast " + SpellName + " for " + MpCost + " mana, creating "
            + ((Stratification) ? "2 layers of " : "")
            + ReturnProjectileCount() + " flying boulders that each deal "
            + CalculateDamage(Player.Instance.EarthSpellModifier) + " points of damage to enemies, block projectiles and break"
            + ((Fortification) ? "after 2 impacts." : "on impact.")
            + ((Stoning) ? " Press 3 while Earth Shield is active to throw the barrier forward and increases damage by 50%." : "")
            + "\nCooldown: " + SpellCooldown + " seconds";
    }

    private void CastEarthShield()
    {
        if(CanCast() && !active)
        {
            StartCoroutine(ManageActiveDuration());
            int projectileCount = ReturnProjectileCount();
            for (int i = 0; i < projectileCount; i++)
            {
                GameObject shield = Instantiate(SpellPrefab, transform.position, Quaternion.identity);
                shield.GetComponent<Projectile>().Damage = CalculateDamage(Player.Instance.EarthSpellModifier);
                Orbit script = shield.GetComponent<Orbit>();
                script.Axis = transform;
                script.Angle = (360f / projectileCount) * i;
                if (Fortification) shield.GetComponent<EarthShield>().Durability++;
            }

            if (Stratification)
            {
                for (int i = 0; i < projectileCount; i++)
                {
                    GameObject shield = Instantiate(stratificationPrefab, transform.position, Quaternion.identity);
                    shield.GetComponent<Projectile>().Damage = CalculateDamage(Player.Instance.EarthSpellModifier);
                    Orbit script = shield.GetComponent<Orbit>();
                    script.Axis = transform;
                    script.Angle = (360f / projectileCount) * i;
                    if (Fortification) shield.GetComponent<EarthShield>().Durability++;
                }
            }
        }
        else StoningThrow();
    }

    private IEnumerator ManageActiveDuration()
    {
        active = true;
        yield return new WaitForSeconds(5f);
        active = false;
    }

    private int ReturnProjectileCount()
    {
        if (Pebbles) return earthShieldCount + 2;
        else return earthShieldCount;
    }

    private void StoningThrow()
    {
        if (active && Stoning)
        {
            if (Spellcast && !Player.Instance.IsDead()
            && Player.Instance.CheckCooldown())
            {
                Player.Instance.SetActionCooldown();
                Player.Instance.Animator.SetTrigger("Spellcast");

                StartCoroutine(StoningCoroutine());
            }
        }
    }

    private IEnumerator StoningCoroutine()
    {
        GameObject projectile = Instantiate(stoningPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();
        rigid.AddForce(Player.Instance.GetComponent<PlayerMovement>().PlayerDirection.normalized * stoningSpeed, ForceMode2D.Impulse);

        EarthShield[] earthShields = (EarthShield[])GameObject.FindObjectsOfType(typeof(EarthShield));
        foreach (EarthShield earthShield in earthShields)
        {
            earthShield.Damage *= stoningMultiplier;
            Orbit script = earthShield.GetComponent<Orbit>();
            script.Axis = projectile.transform;
        }
        active = false;
        yield return new WaitForSeconds(6f);
        Destroy(projectile);
    }

    //private void StoningCoroutine()
    //{
    //    EarthShield[] earthShields = (EarthShield[])GameObject.FindObjectsOfType(typeof(EarthShield));
    //    foreach (EarthShield earthShield in earthShields)
    //    {
    //        earthShield.Damage *= stoningMultiplier;
    //        earthShield.GetComponent<Orbit>().enabled = false;
    //        Rigidbody2D rigid = earthShield.GetComponent<Rigidbody2D>();
    //        rigid.AddForce(Player.Instance.GetComponent<PlayerMovement>().PlayerDirection.normalized * stoningSpeed, ForceMode2D.Impulse);
    //    }
    //    active = false;
    //}

    private void Debug()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            fortification = true;
            pebbles = true;
            stoning = true;
            stratification = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CastEarthShield();
        Debug();
    }
}
