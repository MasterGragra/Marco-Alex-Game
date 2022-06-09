using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HMSBar : MonoBehaviour
{
    private Image manaBarImage;
    private Image healthBarImage;
    private Image StaminaBarImage;
    
    private void Awake()
    {
        manaBarImage = transform.Find("ManaFillBar").GetComponent<Image>();
        healthBarImage = transform.Find("HealthFillBar").GetComponent<Image>();
        StaminaBarImage = transform.Find("StaminaFillBar").GetComponent<Image>();
    }

    private void Update()
    {
        manaBarImage.fillAmount = Player.Instance.Mp;
        healthBarImage.fillAmount = Player.Instance.Hp;
        StaminaBarImage.fillAmount = Player.Instance.Stamina;
    }    
}
