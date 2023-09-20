using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables
    public Transform cameraTarget;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    // Unity physics synced update
    private void FixedUpdate()
    {
        Vector3 movePosition = cameraTarget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
