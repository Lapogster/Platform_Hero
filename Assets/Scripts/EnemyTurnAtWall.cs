using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnAtWall : MonoBehaviour
{
    // Basic Enemy
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Basic Enemy")
        {
            collision.gameObject.GetComponent<BasicEnemyAI>().Flip();
        }
    }
}
