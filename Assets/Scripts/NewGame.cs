using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    private int gameType;

    private void CreateNewGame(string powerUpType)
    {
        PlayerPrefs.SetInt("Has Saved Game", 1);

        PlayerPrefs.SetInt("Current Level", 1);
        PlayerPrefs.SetString("Current PowerUp", "None");

        if (powerUpType == "None")
        {
            gameType = 0;
        }
        else if (powerUpType == "Sword")
        {
            gameType = 1;
        }

        // Debug.Log(gameType);
        PlayerPrefs.SetInt("GameClass", gameType);

        // Load the first level (when first level is loaded, it handles player spawn etc so unlike continue load first level all required.
        SceneManager.LoadScene("Demo Level 1", LoadSceneMode.Single);
    }

    public void CreateNewGameWithNone()
    {
        CreateNewGame("None");
    }
    public void CreateNewGameWithSword()
    {
        CreateNewGame("Sword");
    }
}
