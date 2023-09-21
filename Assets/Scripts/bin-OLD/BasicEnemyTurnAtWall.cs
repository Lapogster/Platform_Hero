using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyTurnAtWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Basic Enemy")
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<BasicEnemyAI>().Flip();
        }
    }
}
