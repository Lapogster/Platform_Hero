using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLogic : MonoBehaviour
{
    // Power up type variables
    public bool isSword;
    public bool isBow;
    // Add every powerup type

    private string powerUpType;

    private void Start()
    {
        if (isSword)
        {
            powerUpType = "Sword";
        }
        else if (isBow)
        {
            powerUpType = "Bow";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLogic>().CollectPowerup(powerUpType);
            gameObject.SetActive(false);
        }
    }
}
