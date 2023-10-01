using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelFinishLine : MonoBehaviour
{
    private string gameClass;

    private void Start()
    {
        if (PlayerPrefs.GetInt("GameClass") == 0)
        {
            gameClass = "None";
        }
        else if (PlayerPrefs.GetInt("GameClass") == 1)
        {
            gameClass = "Sword";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            PlayerPrefs.SetInt("Has Saved Game", 0);

            if (gameClass == "None")
            {
                PlayerPrefs.SetInt("Has Beat Class None", 1);
            }
            else if (gameClass == "Sword")
            {
                PlayerPrefs.SetInt("Has Beat Class Sword", 1);
            }

            SceneManager.LoadScene("Game Beat", LoadSceneMode.Single);
        }
    }
}
