using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantHealer : Enemy
{
    [SerializeField] private GameObject healPrefab;
    [SerializeField] private AudioClip healSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void AttackSFX()
    {
        GameManager.Instance.GetComponent<AudioSource>().clip = healSFX;
        GameManager.Instance.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyUpdate();
    }
}
