using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemyAI : MonoBehaviour
{
    // Variables
    public bool isEnemyFacingRight;
    public float speed;
    public bool isAgro;

    private bool startedAgro = false;

    private float despawnTimer = -1f;

    private float collisionTimer = -1f;
    private float collisionTimerResetTime = 25f;

    [SerializeField] private Rigidbody2D rb;

    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        if (isEnemyFacingRight == false)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyFacingRight == true)
        {
            rb.velocity = new Vector2(1f * speed, rb.velocity.y);
        }
        else if (isEnemyFacingRight == false)
        {
            rb.velocity = new Vector2(-1f * speed, rb.velocity.y);
        }

        if (isAgro)
        {
            if (startedAgro == false)
            {
                speed *= 3;
                startedAgro = true;
            }

            if (playerObject.transform.position.x > gameObject.transform.position.x)
            {
                if (isEnemyFacingRight == false)
                {
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                    isEnemyFacingRight = true;
                }
            }
            else if (playerObject.transform.position.x < gameObject.transform.position.x)
            {
                if (isEnemyFacingRight == true)
                {
                    Vector3 localScale = transform.localScale;
                    localScale.x *= -1f;
                    transform.localScale = localScale;
                    isEnemyFacingRight = false;
                }
            }
        }
    }

    public void Flip()
    {
        if (isEnemyFacingRight == true)
        {
            isEnemyFacingRight = false;
        }
        else if (isEnemyFacingRight == false)
        {
            isEnemyFacingRight = true;
        }
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Despawn()
    {
        if (despawnTimer == -1f)
        {
            despawnTimer = 60f;
        }
        else if (despawnTimer == 0f)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (despawnTimer > 0f)
        {
            despawnTimer += -1f;
            Despawn();
        }

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

    // Turn when walking into another instance
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chasing Enemy")
        {
            // Debug.Log("triggered");
            // Debug.Log(collision.gameObject);
            collision.gameObject.GetComponent<ChasingEnemyAI>().Flip();
            // Flip();

            if (collisionTimer == -1f)
            {
                collisionTimer = 75f;
            }
        }

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
        if (collision.gameObject.tag == "Chasing Enemy")
        {
            if (collisionTimer == 0f)
            {
                collisionTimer = -1f;
                Flip();
            }
        }

        if (collision.gameObject.tag == "Basic Enemy")
        {
            if (collisionTimer == 0f)
            {
                collisionTimer = -1f;
                Flip();
            }
        }
    }
}
