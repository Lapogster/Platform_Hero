using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject sword;
    public GameObject bow;

    private int currentPowerup;

    private bool hasChecked = false;
    private bool readyToCheck = false;
    private readonly float maxTimeBeforeCheck = 2f;
    private float timeBeforeCheck = 2f;

    private void Start()
    {
        currentPowerup = PlayerPrefs.GetInt("GameClass");
        Debug.Log(currentPowerup);
    }

    private void FixedUpdate()
    {
        if (hasChecked == false)
        {
            if (readyToCheck == false)
            {
                if (timeBeforeCheck > 0)
                {
                    timeBeforeCheck += -1f;
                }
                else if (timeBeforeCheck == 0f)
                {
                    timeBeforeCheck = maxTimeBeforeCheck;
                    readyToCheck = true;

                    currentPowerup = PlayerPrefs.GetInt("GameClass");
                }
            }
            else if (readyToCheck)
            {
                Debug.Log("current powerup =" + currentPowerup);
                Debug.Log("playerprefs say - " + PlayerPrefs.GetInt("GameClass"));

                if (currentPowerup == 0)
                {
                    Debug.Log("No powerups spawned");
                    sword.gameObject.SetActive(false);
                    bow.gameObject.SetActive(false);
                }
                else if (currentPowerup == 1)
                {
                    Debug.Log("Swords spawned");
                    sword.gameObject.SetActive(true);
                }

                hasChecked = true;
            }
        }
    }
}
