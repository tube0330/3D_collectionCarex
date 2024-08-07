using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : MonoBehaviour
{
    [Header("Center of Mass")]
    [SerializeField]Rigidbody rb;
    public Vector3 CenterOfMass = new Vector3(0, -0.5f, 0);

    [Header("wheel Colliders")]
    [SerializeField] WheelCollider Front_L;
    [SerializeField] WheelCollider Front_R;
    [SerializeField] WheelCollider Back_L;
    [SerializeField] WheelCollider Back_R;
    [Header("Modeling")]

    [Header("Path")]
    [SerializeField] Transform path;
    [SerializeField] Transform[] pathTransforms;
    [SerializeField] List<Transform> pathList;

    public float curSpeed = 0f;
    private float maxSpeed = 100f;
    private int point = 0;

    public float maxMotorTorque = 1000f;
    public float maxSteerAngle = 30f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfMass;
        path = GameObject.Find("PathTransform").transform;
        pathTransforms = path.GetComponentsInChildren<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path)
                pathList.Add(pathTransforms[i]);
        }
    }
void FixedUpdate()
    {
        ApplySteer();
        Drive();
        CheckWayPointDistance();
    }

    void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(pathList[point].position);

        float newSteer = relativeVector.x / relativeVector.magnitude * maxSteerAngle;

        Front_L.steerAngle = newSteer;
        Front_R.steerAngle = newSteer;
    }

    void Drive()
    {
        curSpeed = 2 * Mathf.PI * Front_L.radius * Front_L.rpm * 60 / 1000;

        if (curSpeed < maxSpeed)
        {
            Back_L.motorTorque = maxMotorTorque;
            Back_R.motorTorque = maxMotorTorque;
        }

        else
        {
            Back_L.motorTorque = 0;
            Back_R.motorTorque = 0;
        }
    }

    void CheckWayPointDistance()
    {
        Debug.Log(point);
        if(Vector3.Distance(transform.position, pathList[point].position) <= 10f)
        {
            if(point == pathList.Count - 1)
            point = 0;

            else point++;
        }
    }
}
