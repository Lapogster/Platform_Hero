using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUILogic : MonoBehaviour
{
    // Variables
    // private GameObject player = GameObject.FindGameObjectWithTag("Player");

    // Add all class/power-up ui logos here
    public GameObject swordUI;
    public GameObject bowUI;

    string currentUIShown = "None";

    private void Start()
    {
        currentUIShown = "None";
        DisableAllUI();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>().currentPowerUp == "None")
        {
            if (currentUIShown != "None")
            {
                DisableAllUI();
                currentUIShown = "None";
            }
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>().currentPowerUp == "Sword")
        {
            if (currentUIShown != "Sword")
            {
                DisableAllUI();
                swordUI.SetActive(true);
                currentUIShown = "Sword";
            }
        }
    }

    void DisableAllUI()
    {
        // Add all class/power-up ui logos here
        swordUI.SetActive(false);
        bowUI.SetActive(false);
    }
}
