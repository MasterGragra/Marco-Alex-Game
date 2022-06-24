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
    private bool echoingWind = true;
    private bool zephyr = false;

    public int WindBladesCount { get => windBladesCount; set => windBladesCount = value; }
    public bool PiercingGales { get => piercingGales; set => piercingGales = value; }
    public bool SplittingGust { get => splittingGust; set => splittingGust = value; }
    public bool EchoingWind { get => echoingWind; set => echoingWind = value; }
    public bool Zephyr { get => zephyr; set => zephyr = value; }

    public string ReturnDescription()
    {
        return "Press 2 to cast " + SpellName + ", shooting "
            + WindBladesCount
            + ((PiercingGales) ? " piercing" : "") + " wind blades"
            + ((EchoingWind) ? " that bounces off walls" : "") + " each dealing "
            + CalculateDamage(Player.Instance.WindSpellModifier) + " points of damage"
            + ((Zephyr) ? " and increases the character's movement speed by 30% for 3 seconds" : "") + ".\n Cooldown: " + SpellCooldown + " seconds";
    }

    private void CastWindBlades()
    {
        if (CanCast())
        {
            Vector3 skillDirection = Quaternion.AngleAxis(-(windBladesSpread * ((float)WindBladesCount - 1f) / 2), Vector3.forward) * Player.Instance.GetComponent<PlayerMovement>().PlayerDirection;
            for(int i = 0; i < WindBladesCount; i++)
            {
                GameObject windBlade = Instantiate(SpellPrefab, Player.Instance.transform.position, Quaternion.identity);
                windBlade.GetComponent<Projectile>().Damage = CalculateDamage(Player.Instance.WindSpellModifier);
                if (EchoingWind)
                {
                    windBlade.GetComponent<WindBlade>().Bouncing = true;
                }
                if (PiercingGales) windBlade.GetComponent<WindBlade>().DestroyOnCollision = false;
                Rigidbody2D rigid = windBlade.GetComponent<Rigidbody2D>();
                Vector3 force = (Zephyr) ? skillDirection.normalized * windBladesSpeed * 2f : skillDirection.normalized * windBladesSpeed;
                rigid.AddForce(force, ForceMode2D.Impulse);
                skillDirection = Quaternion.AngleAxis(windBladesSpread, Vector3.forward) * skillDirection;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CastWindBlades();
    }
}
