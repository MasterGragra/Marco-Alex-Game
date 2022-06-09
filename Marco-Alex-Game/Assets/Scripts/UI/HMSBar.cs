using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HMSBar : MonoBehaviour
{
    [SerializeField] private Image manaBarImage;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Image StaminaBarImage;
    

    private void Awake()
    {
        //manaBarImage = transform.Find("ManaFillBar").GetComponent<Image>();
        //healthBarImage = transform.Find("HealthFillBar").GetComponent<Image>();
        //StaminaBarImage = transform.Find("StaminaFillBar").GetComponent<Image>();
    }

    private void Update()
    {
        manaBarImage.fillAmount = Player.Instance.Mp / Player.Instance.MaxMp;
        healthBarImage.fillAmount = Player.Instance.Hp / Player.Instance.MaxHp;
        StaminaBarImage.fillAmount = Player.Instance.Stamina / Player.Instance.MaxStamina;
    }    
}
