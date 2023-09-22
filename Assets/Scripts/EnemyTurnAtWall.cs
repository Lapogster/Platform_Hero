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

    // Enemy Collision Detection
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Basic Enemy
        if (collision.gameObject.tag == "Basic Enemy")
        {
            collision.gameObject.GetComponent<BasicEnemyAI>().Flip();

            if (collisionTimer == -1f)
            {
                collisionTimer = 75f;
            }
        }

        // Chasing Enemy
        if (collision.gameObject.tag == "Chasing Enemy")
        {
            collision.gameObject.GetComponent<ChasingEnemyAI>().Flip();

            if (collisionTimer == -1f)
            {
                collisionTimer = 75f;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Basic Enemy
        if (collision.gameObject.tag == "Basic Enemy")
        {
            if (collisionTimer == 0f)
            {
                collisionTimer = -1f;
                collision.gameObject.GetComponent<BasicEnemyAI>().Flip();
            }
        }

        // Chasing Enemy
        if (collision.gameObject.tag == "Chasing Enemy")
        {
            if (collisionTimer == 0f)
            {
                collisionTimer = -1f;
                collision.gameObject.GetComponent<ChasingEnemyAI>().Flip();
            }
        }
    }
}
