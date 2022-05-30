using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{


    // Start is called before the first frame update
    void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
