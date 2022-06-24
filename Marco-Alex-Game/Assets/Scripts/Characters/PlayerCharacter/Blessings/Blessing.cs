using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blessing : MonoBehaviour
{
    private string blessingName;
    private string description;

    public string BlessingName { get => blessingName; set => blessingName = value; }
    public string Description { get => description; set => description = value; }
}
