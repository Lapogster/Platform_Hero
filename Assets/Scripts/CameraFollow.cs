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

    private bool playerFound = false;

    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (playerFound == false)
        {
            if (cameraTarget.gameObject.tag != "Player")
            {
                Debug.Log("Player not found yet");
            }
            else if (cameraTarget.gameObject.tag == "Player")
            {
                playerFound = true;
            }
        }
    }

    // Unity physics synced update
    private void FixedUpdate()
    {
        if (playerFound)
        {
            Vector3 movePosition = cameraTarget.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
        }
    }
}
