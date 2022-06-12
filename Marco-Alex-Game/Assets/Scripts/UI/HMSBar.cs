using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HMSBar : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Image manaBarImage;
    [SerializeField] private Image staminaBarImage;

    //private void Awake()
    //{
    //    manaBarImage = transform.Find("ManaFillBar").GetComponent<Image>();
    //    healthBarImage = transform.Find("HealthFillBar").GetComponent<Image>();
    //    staminaBarImage = transform.Find("StaminaFillBar").GetComponent<Image>();
    //}

    private void Update()
    {
        healthBarImage.fillAmount = Player.Instance.Hp / Player.Instance.MaxHp;
        manaBarImage.fillAmount = Player.Instance.Mp / Player.Instance.MaxMp;
        staminaBarImage.fillAmount = Player.Instance.Stamina / Player.Instance.MaxStamina;
    }    
}
