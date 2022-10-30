using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed = 50f;
    public float rotationSpeed = 10f;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(0, 0, speed);
    }
}