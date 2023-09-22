using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnAtWall : MonoBehaviour
{
    // Variables
    //Basic Enemy
    private float collisionTimer = -1f;
    private float collisionTimerResetTime = 25f;

    private void FixedUpdate()
    {
        if (collisionTimer > 0f)
        {
            collisionTimer += -1f;
        }

        if (collisionTimer == 0f)
        {
            if (collisionTimerResetTime > 0f)
            {
                collisionTimerResetTime += -1f;
            }
            if (collisionTimerResetTime == 0)
            {
                collisionTimer = -1f;
                collisionTimerResetTime = 25f;
            }
        }

        if (collisionTimer == -1f)
        {
            collisionTimerResetTime = 25f;
        }
    }

    // Basic Enemy
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Basic Enemy")
        {
            collision.gameObject.GetComponent<BasicEnemyAI>().Flip();

            if (collisionTimer == -1f)
            {
                collisionTimer = 75f;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Basic Enemy")
        {
            if (collisionTimer == 0f)
            {
                collisionTimer = -1f;
                collision.gameObject.GetComponent<BasicEnemyAI>().Flip();
            }
        }
    }
}
