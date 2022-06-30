using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : Spell
{
    new string SpellName = "Heal";

    private float healMultiplier = 3f;

    private bool consecration = false;
    [SerializeField] private GameObject consecrationPrefab;

    private bool holyGrounds = false;
    [SerializeField] private GameObject holyGroundsPrefab;

    private bool purity = false;
    private float purityDurationMultiplier = 1.5f;

    private bool sanctification = false;
    [SerializeField] private GameObject sanctificationPrefab;

    public bool Consecration { get => consecration; set => consecration = value; }
    public bool HolyGrounds { get => holyGrounds; set => holyGrounds = value; }
    public bool Purity { get => purity; set => purity = value; }
    public bool Sanctification { get => sanctification; set => sanctification = value; }

    void Start()
    {
        Consecration = true;
        HolyGrounds = true;
        Purity = true;
        Sanctification = true;
    }

    private void CastHeal()
    {
        if (Player.Instance.Hp < Player.Instance.MaxHp ||
            consecration == true || holyGrounds == true || sanctification == true)
        {
            if (CanCast())
            {
                GameObject heal = Instantiate(SpellPrefab, this.transform.position, Quaternion.identity);
                Heal script = heal.GetComponent<Heal>();
                script.Target = this.transform;
                script.HealAmount = CalculateHealing();

                if (Consecration)
                {
                    GameObject area = Instantiate(consecrationPrefab, this.transform.position, Quaternion.identity);
                    if (Purity) area.GetComponent<AreaEffect>().Duration *= purityDurationMultiplier;
                }

                if (HolyGrounds)
                {
                    GameObject area = Instantiate(holyGroundsPrefab, this.transform.position, Quaternion.identity);
                    if (Purity) area.GetComponent<AreaEffect>().Duration *= purityDurationMultiplier;
                }

                if (Sanctification)
                {
                    GameObject area = Instantiate(sanctificationPrefab, this.transform.position, Quaternion.identity);
                    if (Purity) area.GetComponent<AreaEffect>().Duration *= purityDurationMultiplier;
                }
            }
        }
    }

    public float CalculateHealing()
    {
        return Player.Instance.SpellPower * healMultiplier * Player.Instance.HealSpellModifier;
    }

    // Update is called once per frame
    void Update()
    {
        CastHeal();
    }
}
