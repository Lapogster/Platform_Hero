using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemyVision : MonoBehaviour
{
    [SerializeField] private GameObject chaseEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            chaseEnemy.GetComponent<ChasingEnemyAI>().isAgro = true;
            chaseEnemy.GetComponent<ChasingEnemyAI>().playerObject = collision.gameObject;
        }
    }
}
