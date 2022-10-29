using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform bus;
    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float zOffset;
    [SerializeField]
    private float cameraAngle;

    void Start()
    {
        transform.position = bus.position;
        transform.rotation = Quaternion.Euler(cameraAngle, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(
            bus.position.x + xOffset, 
            bus.position.y + yOffset, 
            bus.position.z + zOffset);
        transform.position = targetPosition;
    }
}
