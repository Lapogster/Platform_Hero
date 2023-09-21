using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{
    // Variables
    public bool isEnemyFacingRight;
    public float speed;

    private float despawnTimer = -1f;

    [SerializeField] private Rigidbody2D rb;

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
        if (despawnTimer > 0)
        {
            despawnTimer += -1f;
            Despawn();
        }
    }
}
