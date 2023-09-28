using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePadLogic : MonoBehaviour
{
    public float jumpPower = 18f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().coyoteTimeTimer = 0f;
            collision.gameObject.GetComponent<PlayerMovement>().jumpCooldown = 5f;
            collision.gameObject.GetComponent<PlayerMovement>().rb.velocity = new Vector2(collision.gameObject.GetComponent<PlayerMovement>().rb.velocity.x, jumpPower);
        }

        if (collision.tag == "Basic Enemy")
        {
            collision.gameObject.GetComponent<BasicEnemyAI>().rb.velocity = new Vector2(collision.gameObject.GetComponent<BasicEnemyAI>().rb.velocity.x, jumpPower);
        }
        else if (collision.tag == "Chasing Enemy")
        {
            collision.gameObject.GetComponent<ChasingEnemyAI>().rb.velocity = new Vector2(collision.gameObject.GetComponent<ChasingEnemyAI>().rb.velocity.x, jumpPower);
        }
    }
}
