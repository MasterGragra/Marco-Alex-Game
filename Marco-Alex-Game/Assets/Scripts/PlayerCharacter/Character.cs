using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;

    private bool invincible = false;
    private float invincibilityTime = 0.2f;
    private Color originalColor;

    public float Hp { get => hp; set => hp = value; }
    public Color OriginalColor { get => originalColor; set => originalColor = value; }
    public float MaxHp { get => maxHp; set => maxHp = value; }

    private void Awake()
    {
        Hp = MaxHp;
        OriginalColor = GetComponent<SpriteRenderer>().color;
    }

    //Alex Version 
    public virtual void ReceiveDamage(float damage)
    {
        if (!invincible)
        {
            Hp -= damage;
            invincible = true;
            if (IsDead())
            {
                Die();
            }
            else
            {
                StartCoroutine("DamageFeedback");
                StartCoroutine("InvincibilityTimer");
            }
        }
    }

    public void ReceiveIndirectDamage(float damage)
    {
        Hp -= damage;
        if (IsDead()) Die();
        else StartCoroutine("DamageFeedback");
    }

    private bool IsDead()
    {
        return Hp <= 0;
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
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
}
