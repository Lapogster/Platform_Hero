using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayDropLogic : MonoBehaviour
{
    private bool hitboxEnabled = true;
    private float hitboxFixCooldown = 20f;
    private float startHitboxFixCooldown = 20f;

    // public GameObject player;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (hitboxEnabled && collision.gameObject.GetComponent<PlayerMovement>().IsGrounded())
                {
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    hitboxEnabled = false;
                    // ReEnableHitbox(collision.gameObject);
                }
            }
        }
    }

    // DO NOT CALL - CRASHES FOR SOME REASON
    private void ReEnableHitbox(GameObject playerObject)
    {
        if (hitboxEnabled == true)
        {
            playerObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (hitboxEnabled == false)
        {
            ReEnableHitbox(playerObject);
        }
    }

    private void FixedUpdate()
    {
        if (hitboxEnabled == false)
        {
            if (hitboxFixCooldown > 0f)
            {
                hitboxFixCooldown += -1f;
            }
            else if (hitboxFixCooldown == 0f)
            {
                hitboxEnabled = true;
                hitboxFixCooldown = startHitboxFixCooldown;
                GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().enabled = true;
            }
        }

        // Debug.Log(hitboxEnabled);
    }
}
