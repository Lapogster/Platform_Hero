using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButtons : MonoBehaviour
{
    public void RestartButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (PlayerPrefs.GetInt("Current Level") == 1)
        {
            SceneManager.LoadScene("Demo Level 1", LoadSceneMode.Single);
        }
    }

    public void QuitButton()
    {
        Debug.Log("Application closed");
        Application.Quit();
    }
}
