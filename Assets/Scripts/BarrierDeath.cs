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

            // Make the player take damage (sometimes kills) - main purpose it to turn player red
            collision.gameObject.GetComponent<PlayerLogic>().TakeDamage();

            //Insta-kills player if they can survive the first hit
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