using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLogic : MonoBehaviour
{
    public GameObject swordStaticSprite;

    private float staticSwordVisibleFrames = 25f;
    private float maxStaticSwordVisibleFrames = 25f;
    private bool canAttack = true;
    private bool isAttacking = false;
    private bool staticSpriteGone = true;
    private float maxAttackCooldown = 15f;
    private float attackCooldown = 15f;
    private bool onCooldown = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("Attack");

            if (canAttack == true)
            {
                canAttack = false;
                swordStaticSprite.SetActive(true);
                isAttacking = true;
                staticSpriteGone = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isAttacking == true)
        {
            if (staticSwordVisibleFrames > 0f)
            {
                staticSwordVisibleFrames += -1f;
            }
            else if (staticSwordVisibleFrames == 0f)
            {
                staticSwordVisibleFrames = maxStaticSwordVisibleFrames;
                isAttacking = false;
                swordStaticSprite.SetActive(false);
                staticSpriteGone = true;
                onCooldown = true;
            }
        }

        if (staticSpriteGone == true)
        {
            if (onCooldown == true)
            {
                if (attackCooldown > 0)
                {
                    attackCooldown += -1f;
                }
                else if (attackCooldown == 0f)
                {
                    attackCooldown = maxAttackCooldown;
                    onCooldown = false;
                    canAttack = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isAttacking == true)
        {
            if (collision.tag == "Basic Enemy")
            {
                collision.gameObject.GetComponent<EnemyDamage>().TakeDamage();
            }
            if (collision.tag == "Chasing Enemy")
            {
                collision.gameObject.GetComponent<EnemyDamage>().TakeDamage();
            }
        }
    }
}
