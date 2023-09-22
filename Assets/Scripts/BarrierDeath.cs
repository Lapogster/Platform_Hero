using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrierDeath : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player has entered a death barrier");
            SceneManager.LoadScene("You Died", LoadSceneMode.Single);
        }
        else if (collision.tag == "Basic Enemy")
        {
            collision.gameObject.GetComponent<BasicEnemyAI>().Despawn();
        }
        else if (collision.tag == "Chasing Enemy")
        {
            collision.gameObject.GetComponent<ChasingEnemyAI>().Despawn();
        }
    }
}