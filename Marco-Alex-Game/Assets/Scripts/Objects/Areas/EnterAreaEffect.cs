using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterAreaEffect : AreaEffect, IEnterAreaEffect
{
    [SerializeField] private string[] targetTags = new string[] { "Player" };

    public string[] TargetTags { get => targetTags; set => targetTags = value; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < TargetTags.Length; i++)
        {
            if (collider.gameObject.CompareTag(TargetTags[i]))
            {
                ApplyAreaEffect();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        for (int i = 0; i < TargetTags.Length; i++)
        {
            if (collider.gameObject.CompareTag(TargetTags[i]))
            {
                ApplyAreaEffect();
            }
        }
    }

    public virtual void ApplyAreaEffect()
    {
        throw new System.NotImplementedException();
    }

    public virtual void RemoveAreaEffect()
    {
        throw new System.NotImplementedException();
    }
}
