using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RNGBlessing : MonoBehaviour
{
    //greater blessings
    public int fireBlessing;
    public int windBlessing;
    public int earthBlessing;
    public int healingBlessing;
    public int randomNumber;

    //lesser blessings
    public int dexterityBlessing;
    public int elementBlessing;
    public int mightBlessing;
    public int wisdomBlessing;

    // Start is called before the first frame update
    void Start()
    {
        fireBlessing = 1;
        windBlessing = 2;
        earthBlessing = 3;
        healingBlessing = 4;

        dexterityBlessing = 5;
        elementBlessing = 6;
        mightBlessing = 7;
        wisdomBlessing = 8;
        randomNumber = Random.Range(1, 4);
    }

    private void ReRollGreaterBlessing()
    {
        randomNumber = Random.Range(1, 4);
    }

    private void ReRollLesserBlessing()
    {
        randomNumber = Random.Range(5, 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
