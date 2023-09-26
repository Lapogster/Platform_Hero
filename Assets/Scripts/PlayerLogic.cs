using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    // Variables
    public bool isInvulnerable;
    private bool isImmune = false;
    public int startHealth;
    private int currentHealth;
    private bool justTookDamage = false;
    private float damageRedCooldown = 40f;
    private float maxImmunityFrames = 43f;
    private float immunityFrames = 43f;

    // Power Up
    public string currentPowerUp;
    // public GameObject powerUpUI;

    public Animator animator;

    public GameObject swordLogicObject;

    private void Start()
    {
        currentHealth = startHealth;

        justTookDamage = false;

        immunityFrames = maxImmunityFrames;

        currentPowerUp = "None";
    }

    public void TakeDamage()
    {
        if (isImmune == false && isInvulnerable == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            currentHealth += -1;
            justTookDamage = true;
            damageRedCooldown = 40f;

            isImmune = true;

            if (currentHealth <= 1)
            {
                currentPowerUp = "None";

                animator.SetBool("HasSword", false);

                swordLogicObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        // Debug.Log(currentHealth);

        if (currentHealth == 0)
        {
            Debug.Log("Player Died");

            // Reset health so restart works
            currentHealth = startHealth;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("You Died", LoadSceneMode.Single);
        }
        else if (justTookDamage == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void FixedUpdate()
    {
        if (justTookDamage)
        {
            if (damageRedCooldown == 0f)
            {
                justTookDamage = false;
            }
            else
            {
                damageRedCooldown += -1f;
            }
        }

        if (isImmune)
        {
            if (immunityFrames > 0)
            {
                immunityFrames += -1;
            }
            else if (immunityFrames == 0)
            {
                immunityFrames = maxImmunityFrames;
                isImmune = false;
            }
        }
    }

    public void CollectPowerup(string powerUpType)
    {
        // Debug.Log(powerUpType);
        if (powerUpType == "Sword")
        {
            if (currentPowerUp == "None")
            {
                currentHealth += 1;
            }

            if (currentPowerUp != "Sword")
            {
                currentPowerUp = "Sword";
                animator.SetBool("HasSword", true);
                swordLogicObject.SetActive(true);
            }
        }

        if (powerUpType == null)
        {
            Debug.Log("Power-up type error has occured. No type has been detected. This power-up will not take effect");
        }
    }
}
