using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RNGBlessing : MonoBehaviour
{
    [SerializeField] private GameObject[] greaterChestPrefabs;
    [SerializeField] private GameObject[] lesserChestPrefabs;

    [SerializeField] private GameObject[] chestLocations;

    [SerializeField] private bool bossroom = false;

    
    void SpawnLesserChest()
    {
        int index = 0;
        int randomNumber = Random.Range(0, 3);
        for(int i = 0; i < lesserChestPrefabs.Length; i++)
        {
            if (randomNumber != i)
            {
                Instantiate(lesserChestPrefabs[i], chestLocations[index].transform.position, Quaternion.identity);
                index++;
            }
        }
    }

    void SpawnGreaterChest()
    {
        int index = 0;
        int randomNumber = Random.Range(0, 4);
        for (int i = 0; i < greaterChestPrefabs.Length; i++)
        {
            if (randomNumber != i)
            {
                Instantiate(greaterChestPrefabs[i], chestLocations[index].transform.position, Quaternion.identity);
                index++;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (bossroom) SpawnGreaterChest();
        else SpawnLesserChest();
    }


}

