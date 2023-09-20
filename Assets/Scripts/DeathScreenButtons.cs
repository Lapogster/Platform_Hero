using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButtons : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    public void QuitButton()
    {
        Debug.Log("Application closed");
        Application.Quit();
    }
}
