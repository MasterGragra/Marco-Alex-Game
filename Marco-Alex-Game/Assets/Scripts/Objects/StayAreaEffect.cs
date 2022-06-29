using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAreaEffect : MonoBehaviour, IStayAreaEffect
{
    [SerializeField] private string[] targetTags = new string[] { "Player" };

    public string[] TargetTags { get => targetTags; set => targetTags = value; }

    private void OnTriggerStay2D(Collider2D collider)
    {
        for (int i = 0; i < TargetTags.Length; i++)
        {
            if (collider.gameObject.CompareTag(TargetTags[i]))
            {
                AreaEffect(collider);
            }
        }
    }

    public virtual void AreaEffect(Collider2D collider)
    {
        throw new NotImplementedException();
    }
}
