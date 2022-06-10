using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private static Player instance;

    private bool hasDied = false;
    private float mp = 100f;
    private float maxMp = 100f;
    private float mpRegen = 2f;

    private float stamina = 100f;
    private float maxStamina = 100f;
    private float staminaRegen = 3f;

    private Animator animator;
    private float cooldownTime = 0f;

    [SerializeField] private AudioSource normalAudio;
    [SerializeField] private AudioSource loopingAudio;


    public static Player Instance { get => instance; set => instance = value; }
    public float Mp { get => mp; set => mp = value; }
    public float MaxMp { get => maxMp; set => maxMp = value; }
    public float Stamina { get => stamina; set => stamina = value; }
    public float MaxStamina { get => maxStamina; set => maxStamina = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public float CooldownTime { get => cooldownTime; set => cooldownTime = value; }
    public AudioSource NormalAudio { get => normalAudio; set => normalAudio = value; }
    public AudioSource LoopingAudio { get => loopingAudio; set => loopingAudio = value; }
    

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
        Animator = GetComponent<Animator>();
    }

    public override void Die()
    {
        if (IsDead())
        {
            if (!hasDied)
            {
                hasDied = true;
                animator.SetTrigger("Die");
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
    }

    private void MpRegen()
    {
        if (mp < MaxMp)
        {
            mp += mpRegen * Time.deltaTime;
        }
        else if (mp > MaxMp) mp = MaxMp;
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
        if (stamina < MaxStamina)
        {
            stamina += staminaRegen * Time.deltaTime;
        }
        else if (stamina > MaxStamina) stamina = MaxStamina;
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

        if(Input.GetKey(KeyCode.T))
        {
            ReceiveDamage(100f);
        }
    }
}
