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

    public float Distance { get => distance; set => distance = value; }
    public float Angle { get => angle; set => angle = value; }
    public bool Clockwise { get => clockwise; set => clockwise = value; }
    public Transform Axis { get => axis; set => axis = value; }

    private void Start()
    {
        position = new Vector3(0f, Distance, 0f);
        position = Quaternion.AngleAxis(Angle, Vector3.forward) * position;
        transform.position = Axis.position + position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (axis == null) Destroy(gameObject);
        else
        {
            position = new Vector3(0f, Distance, 0f);
            position = Quaternion.AngleAxis(Angle, Vector3.forward) * position;
            if (Clockwise) Angle -= orbitSpeed * Time.fixedDeltaTime;
            else Angle += orbitSpeed * Time.fixedDeltaTime;
            Distance += outwardTravelSpeed * Time.fixedDeltaTime;
            transform.position = Axis.position + position;
        }
    }
}
