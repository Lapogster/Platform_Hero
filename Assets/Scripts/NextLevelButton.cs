using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void NextLevelButtonPressed()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (PlayerPrefs.GetInt("Current Level") == 2)
        {
            SceneManager.LoadScene("Demo Level 1", LoadSceneMode.Single);
        }
    }
}
