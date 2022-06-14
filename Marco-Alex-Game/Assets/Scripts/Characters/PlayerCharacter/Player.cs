using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private static Player instance;

    [SerializeField] private float mp = 100f;
    private float maxMp = 100f;
    private float mpRegen = 2f;
    private float spellPower = 10f;
    private float fireSpellModifier = 1f;
    private float windSpellModifier = 1f;
    private float earthSpellModifier = 1f;

    [SerializeField] private float stamina = 100f;
    private float maxStamina = 100f;
    private float staminaRegen = 4f;

    private Animator animator;

    [SerializeField] private AudioSource normalAudio;
    [SerializeField] private AudioSource loopingAudio;


    public static Player Instance { get => instance; set => instance = value; }
    public float Mp { get => mp; set => mp = value; }
    public float MaxMp { get => maxMp; set => maxMp = value; }
    public float SpellPower { get => spellPower; set => spellPower = value; }
    public float FireSpellModifier { get => fireSpellModifier; set => fireSpellModifier = value; }
    public float WindSpellModifier { get => windSpellModifier; set => windSpellModifier = value; }
    public float EarthSpellModifier { get => earthSpellModifier; set => earthSpellModifier = value; }
    public float Stamina { get => stamina; set => stamina = value; }
    public float MaxStamina { get => maxStamina; set => maxStamina = value; }
    public Animator Animator { get => animator; set => animator = value; }
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
            if (!HasDied)
            {
                HasDied = true;
                animator.SetTrigger("Death");
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                GetComponent<Rigidbody2D>().isKinematic = true;

                StartCoroutine("DeathCoroutine");
            }
        }
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(1.7f);
        int count = 8;
        do {
            count--;
            yield return new WaitForSeconds(0.05f);
            this.transform.position = new Vector3(this.transform.position.x - 0.025f, this.transform.position.y - 0.025f);
        } while (count > 0);
    }
    public override IEnumerator Knockback(Vector2 vector)
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(vector, ForceMode2D.Impulse);
        PlayerMovement script = GetComponent<PlayerMovement>();
        script.UsingPhysics = true;
        SetActionCooldown(0.5f);
        yield return new WaitForSeconds(0.5f);
        rigid.velocity = Vector2.zero;
        script.UsingPhysics = false;
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

    private void Debug()
    {
        //Suicide
        if (Input.GetKey(KeyCode.T))
        {
            ReceiveDamage(100f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead())
        {
            MpRegen();
            StaminaRegen();
            Cooldown();
        }

        Debug();
    }
}
