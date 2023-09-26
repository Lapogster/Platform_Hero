using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public bool isInvulnerable;
    private bool isImmune = false;
    public float startHealth;
    private float currentHealth;

    private bool justTookDamage = false;
    private float damageRedCooldown = 40f;
    private float immunityFrames = 43f;
    private float maxImmunityFrames = 43f;

    private void Start()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage()
    {
        if (isInvulnerable == false && isImmune == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            currentHealth += -1;
            justTookDamage = true;
            damageRedCooldown = 40f;
            isImmune = true;
        }
    }

    private void Update()
    {
        if (currentHealth == 0)
        {
            gameObject.SetActive(false);
        }
        else if (justTookDamage == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void FixedUpdate()
    {
        if (justTookDamage == true)
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

        if (isImmune == true)
        {
            if (immunityFrames > 0f)
            {
                immunityFrames += -1f;
            }
            else if (immunityFrames == 0f)
            {
                immunityFrames = maxImmunityFrames;
                isImmune = false;
            }
        }
    }
}
