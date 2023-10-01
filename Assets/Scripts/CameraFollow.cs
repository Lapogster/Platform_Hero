using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables
    // public Transform cameraTarget;
    private Transform cameraTarget;

    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Unity physics synced update
    private void FixedUpdate()
    {
        Vector3 movePosition = cameraTarget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
