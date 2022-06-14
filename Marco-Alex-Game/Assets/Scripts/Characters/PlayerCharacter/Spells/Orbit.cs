using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private Vector3 position;
    [SerializeField] private float distance;
    private float angle = 0f;
    [SerializeField] bool clockwise;
    [SerializeField] private float orbitSpeed;
    [SerializeField] private float outwardTravelSpeed;
    [SerializeField] private Transform axis;

    public float Angle { get => angle; set => angle = value; }
    public Transform Axis { get => axis; set => axis = value; }

    private void Start()
    {
        position = new Vector3(0f, distance, 0f);
        position = Quaternion.AngleAxis(Angle, Vector3.forward) * position;
        transform.position = Axis.position + position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (axis == null) Destroy(gameObject);
        else
        {
            position = new Vector3(0f, distance, 0f);
            position = Quaternion.AngleAxis(Angle, Vector3.forward) * position;
            if (clockwise) Angle -= orbitSpeed * Time.fixedDeltaTime;
            else Angle += orbitSpeed * Time.fixedDeltaTime;
            distance += outwardTravelSpeed * Time.fixedDeltaTime;
            transform.position = Axis.position + position;
        }
    }
}
