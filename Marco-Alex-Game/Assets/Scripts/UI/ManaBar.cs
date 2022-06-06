using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaBar : MonoBehaviour
{
    private Image manaBarImage;
    private Mana mana;

    private void Awake()
    {
        manaBarImage = transform.Find("Bar").GetComponent<Image>();
        mana = new Mana();
    }

    private void Update()
    {
        mana.Update();

        manaBarImage.fillAmount = mana.GetManaNormalized();
    }

    public class Mana
    {
        public const int MaxMana = 100;
        private float manaAmount;
        private float manaRegen;

        public Mana()
        {
            manaAmount = 100;
            manaRegen = 10f;
        }

        public void Update()
        {
            manaAmount += manaRegen * Time.deltaTime;
        }

        public void CastingSpell(int amount)
        {
            if(manaAmount >= amount)
            {
                manaAmount -= manaAmount;
            }
        }

        public float GetManaNormalized()
        {
            return manaAmount / MaxMana;
        }
    }
}
