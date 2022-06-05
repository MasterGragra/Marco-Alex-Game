using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShieldSpell : Spell
{
    private int earthShieldCount = 3;

    private void CastEarthShield()
    {
        if(CanCast())
        {
            for (int i = 0; i < earthShieldCount; i++)
            {
                GameObject shield = Instantiate(SpellPrefab, transform.position, Quaternion.identity);
                Orbit script = shield.GetComponent<Orbit>();
                script.Axis = transform;
                script.Angle = (360f / earthShieldCount) * i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CastEarthShield();
    }
}
