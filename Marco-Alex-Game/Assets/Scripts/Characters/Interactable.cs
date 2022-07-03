using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string[] targetTags = new string[] { "Enemy" };
    public string[] TargetTags { get => targetTags; set => targetTags = value; }
}
