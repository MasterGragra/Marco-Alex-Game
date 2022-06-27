using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBladesSpell : Spell, ISpell
{
    new string SpellName = "Wind Blades";

    private float windBladesSpeed = 15f;
    private int windBladesCount = 3;
    private float windBladesSpread = 15f;

    private bool piercingGales = false;
    private bool splittingGust = false;
    private bool echoingWind = false;

    private bool zephyr = false;
    private float zephyrSpeedMultiplier = 2f;

    public int WindBladesCount { get => windBladesCount; set => windBladesCount = value; }
    public bool PiercingGales { get => piercingGales; set => piercingGales = value; }
    public bool SplittingGust { get => splittingGust; set => splittingGust = value; }
    public bool EchoingWind { get => echoingWind; set => echoingWind = value; }
    public bool Zephyr { get => zephyr; set => zephyr = value; }

    //void Start()
    //{
    //    piercingGales = true;
    //    splittingGust = true;
    //    echoingWind = true;
    //    zephyr = true;
    //}

    public string ReturnDescription()
    {
        return "Press 2 to cast " + SpellName + " for " + MpCost + " mana, shooting " + ReturnProjectileCount()
            + ((Zephyr) ? "quick" : "")
            + ((PiercingGales) ? " piercing" : "") + " wind blades"
            + ((EchoingWind) ? " that bounces off terrain" : "") + ", each dealing "
            + CalculateDamage(Player.Instance.WindSpellModifier) + " points of damage to enemies"
            + ".\nCooldown: " + SpellCooldown + " seconds";
    }

    private void CastWindBlades()
    {
        if (CanCast())
        {
            Vector3 skillDirection = Quaternion.AngleAxis(-(windBladesSpread * ((float)ReturnProjectileCount() - 1f) / 2), Vector3.forward) * Player.Instance.GetComponent<PlayerMovement>().PlayerDirection;
            int projectileCount = ReturnProjectileCount();
            for(int i = 0; i < projectileCount; i++)
            {
                GameObject windBlade = Instantiate(SpellPrefab, Player.Instance.transform.position, Quaternion.identity);
                windBlade.GetComponent<Projectile>().Damage = CalculateDamage(Player.Instance.WindSpellModifier);
                if (EchoingWind) windBlade.GetComponent<WindBlade>().Bouncing = true;
                if (PiercingGales) windBlade.GetComponent<WindBlade>().DestroyOnCollision = false;

                Rigidbody2D rigid = windBlade.GetComponent<Rigidbody2D>();
                Vector3 force = (Zephyr) ? skillDirection.normalized * windBladesSpeed * zephyrSpeedMultiplier : skillDirection.normalized * windBladesSpeed;
                rigid.AddForce(force, ForceMode2D.Impulse);
                skillDirection = Quaternion.AngleAxis(windBladesSpread, Vector3.forward) * skillDirection;
            }
        }
    }

    private int ReturnProjectileCount()
    {
        if (SplittingGust) return WindBladesCount + 2;
        else return windBladesCount;
    }

    // Update is called once per frame
    void Update()
    {
        CastWindBlades();
    }
}
