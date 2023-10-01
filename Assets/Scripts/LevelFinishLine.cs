using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishLine : MonoBehaviour
{
    private int currentLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            currentLevel = PlayerPrefs.GetInt("Current Level");
            PlayerPrefs.SetInt("Current Level", currentLevel + 1);

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>().currentPowerUp == "None")
            {
                PlayerPrefs.SetString("Current PowerUp", "None");
            }
            else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>().currentPowerUp == "Sword")
            {
                PlayerPrefs.SetString("Current PowerUp", "Sword");
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene("Level Passed", LoadSceneMode.Single);
        }
    }
}
