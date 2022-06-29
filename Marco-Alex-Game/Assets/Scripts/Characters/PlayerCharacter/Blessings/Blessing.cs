using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blessing : IBlessing
{
    private string blessingName;
    private string description;
    private int cost;

    public string BlessingName { get => blessingName; set => blessingName = value; }
    public string Description { get => description; set => description = value; }
    public int Cost { get => cost; set => cost = value; }

    public virtual void ApplyBlessing()
    {
        throw new System.NotImplementedException();
    }
}
