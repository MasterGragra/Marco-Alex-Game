using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;
    private float attackPower = 10f;
    private float damageReduction = 0f;

    private bool invincible = false;
    private float invincibilityTime = 0.2f;
    private bool hasDied = false;
    private Color originalColor;

    private float cooldownTimer = 0f;

    public float Hp { get => hp; set => hp = value; }
    public float MaxHp { get => maxHp; set => maxHp = value; }
    public float AttackPower { get => attackPower; set => attackPower = value; }
    public float DamageReduction { get => damageReduction; set => damageReduction = value; }
    public bool HasDied { get => hasDied; set => hasDied = value; }
    public Color OriginalColor { get => originalColor; set => originalColor = value; }
    public float CooldownTimer { get => cooldownTimer; set => cooldownTimer = value; }

    public void CharacterStart()
    {
        Hp = MaxHp;
        OriginalColor = GetComponent<SpriteRenderer>().color;
    }
  
    public virtual void ReceiveDamage(float damage)
    {
        if (!invincible)
        {
            Hp -= damage * (1f - DamageReduction);
            //invincible = true;
            if (IsDead())
            {
                Die();
            }
            else
            {
                StartCoroutine(DamageFeedback());
                //StartCoroutine(InvincibilityTimer());
            }
        }
    }

    public void ReceiveIndirectDamage(float damage)
    {
        if (Hp > 1) Hp -= damage * (1f - DamageReduction);
    }

    public bool IsDead()
    {
        return Hp <= 0;
    }

    public virtual void Die()
    {
        if (!HasDied)
        {
            StartCoroutine(DeathCoroutine());
        }
    }

    private IEnumerator DeathCoroutine()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        Vector3 originalPosition = transform.position;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.gray;
        do
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 0.2f);
            float x = Random.Range(-0.1f, 0.1f);
            transform.position = new Vector3(originalPosition.x + x, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.1f);
            transform.position = originalPosition;
        } while (sprite.color.a > 0f);
        Destroy(gameObject);
    }

    public IEnumerator InvincibilityTimer()
    {
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }

    public IEnumerator DamageFeedback()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = OriginalColor;
    }

    public virtual IEnumerator Knockback(Vector2 vector)
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.isKinematic = false;
        rigid.AddForce(vector, ForceMode2D.Impulse);
        SetActionCooldown(0.5f);
        yield return new WaitForSeconds(0.5f);
        rigid.velocity = Vector2.zero;
        rigid.isKinematic = true;
    }

    public void SetActionCooldown()
    {
        if (CooldownTimer < 0.3f) CooldownTimer = 0.3f;
    }

    public void SetActionCooldown(float cooltime)
    {
        if (CooldownTimer < cooltime) CooldownTimer = cooltime;
    }

    public bool CheckCooldown()
    {
        if (CooldownTimer <= 0) return true;
        else return false;
    }

    public void Cooldown()
    {
        if (!CheckCooldown()) CooldownTimer -= Time.deltaTime;
    }
}
