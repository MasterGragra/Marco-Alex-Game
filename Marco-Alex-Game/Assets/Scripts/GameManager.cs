using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private int gold = 0;

    public static GameManager Instance { get => instance; set => instance = value; }
    public int Gold { get => gold; set => gold = value; }

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
}
