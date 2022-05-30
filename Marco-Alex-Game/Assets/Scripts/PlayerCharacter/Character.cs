using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float hp;
    private bool invincible = false;
    private float invincibilityTime = 0.2f;
    private Color originalColor;

    public Color OriginalColor { get => originalColor; set => originalColor = value; }

    public virtual void ReceiveDamage(float damage)
    {
        if (!invincible)
        {
            hp -= damage;
            invincible = true;
            if (IsDead())
            {
                Die();
            }
            StartCoroutine("DamageFeedback");
            StartCoroutine("InvincibilityTimer");
        }
    }

    public void ReceiveIndirectDamage(float damage)
    {
        hp -= damage;
        if (IsDead())
        {
            Die();
        }
        StartCoroutine("DamageFeedback");
    }

    private bool IsDead()
    {
        return hp <= 0;
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

    private void Awake()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
    }
}
