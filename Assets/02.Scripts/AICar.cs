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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
