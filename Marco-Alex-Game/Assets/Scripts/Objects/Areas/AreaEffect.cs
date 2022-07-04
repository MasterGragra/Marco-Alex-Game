using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffect : MonoBehaviour
{
    [SerializeField] private float duration = 0f;
    [SerializeField] private bool countdown = false;

    public float Duration { get => duration; set => duration = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (Duration > 0f) countdown = true;
    }

        private void ManageDuration()
    {
        if (countdown) Duration -= Time.deltaTime;
        if (Duration < 0) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ManageDuration();
    }
}
