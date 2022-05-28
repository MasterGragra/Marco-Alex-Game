using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private static Player instance;

    private float mp = 100f;
    private float maxMp = 100f;
    private float mpRegen = 2f;

    private float stamina = 100f;
    private float maxStamina = 100f;
    private float staminaRegen = 3f;

    private Animator animator;
    private float cooldownTime = 0f;

    public static Player Instance { get => instance; set => instance = value; }
    public float Mp { get => mp; set => mp = value; }
    public float Stamina { get => stamina; set => stamina = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public float CooldownTime { get => cooldownTime; set => cooldownTime = value; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public override void Die()
    {

    }
    
    private void MpRegen()
    {
        if (mp < maxMp)
        {
            mp += mpRegen * Time.deltaTime;
        }
        if (mp > maxMp) mp = maxMp;
    }

    public bool StaminaCostCheck(float cost)
    {
        if (cost <= Stamina) return true;
        else return false;
    }

    public void StaminaCost(float cost)
    {
        Stamina -= cost;
    }

    private void StaminaRegen()
    {
        if(stamina < maxStamina)
        {
            stamina += staminaRegen * Time.deltaTime;
        }
        if (stamina > maxStamina) stamina = maxStamina;
    }

    public void ActionCooldown(float cooltime)
    {
        CooldownTime = cooltime;
    }

    public bool CooldownCheck()
    {
        if (CooldownTime <= 0) return true;
        else return false;
    }

    private void Cooldown()
    {
        if (!CooldownCheck()) CooldownTime -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        MpRegen();
        StaminaRegen();
        Cooldown();
    }
}
