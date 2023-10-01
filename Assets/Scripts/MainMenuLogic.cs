using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public GameObject continueButton;

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject newGameMenu;

    // Text colour for beaten classes
    public GameObject redNone;
    public GameObject greenNone;
    public GameObject redSword;
    public GameObject greenSword;
    public GameObject redBow;
    public GameObject greenBow;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Has Saved Game") == false)
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
        else if (PlayerPrefs.GetInt("Has Saved Game") == 0)
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            Debug.Log("Saved game found");
        }

        if (PlayerPrefs.HasKey("Isn't First Open") == false)
        {
            PlayerPrefs.SetInt("Isn't First Open", 1);
            PlayerPrefs.SetInt("Has Saved Game", 0);
            PlayerPrefs.SetInt("Has Beat Class None", 0);
            PlayerPrefs.SetInt("Has Beat Class Sword", 0);
            PlayerPrefs.SetInt("Has Beat Class Bow", 0);
        }
    }

    public void QuitButton()
    {
        Debug.Log("Application closed");
        Application.Quit();
    }

    public void OptionsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OptionsBackButton()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void NewGame()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(true);

        // Handling text colour loading
        if (PlayerPrefs.GetInt("Has Beat Class None") == 1)
        {
            greenNone.SetActive(true);
            redNone.SetActive(false);
        }
        else
        {
            greenNone.SetActive(false);
            redNone.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Has Beat Class Sword") == 1)
        {
            greenSword.SetActive(true);
            redSword.SetActive(false);
        }
        else
        {
            greenSword.SetActive(false);
            redSword.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Has Beat Class Bow") == 1)
        {
            greenBow.SetActive(true);
            redBow.SetActive(false);
        }
        else
        {
            greenBow.SetActive(false);
            redBow.SetActive(true);
        }
    }

    public void NewGameBack()
    {
        newGameMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LoadTestLevel()
    {
        Debug.Log("Loading Testing Only Level");
        SceneManager.LoadScene("Test Level", LoadSceneMode.Single);
    }

    public void ContinueButton()
    {
        if (PlayerPrefs.GetInt("Current Level") == 1)
        {
            SceneManager.LoadScene("Demo Level 1", LoadSceneMode.Single);
        }
        else if (PlayerPrefs.GetInt("Current Level") == 2)
        {
            SceneManager.LoadScene("Demo Level 2", LoadSceneMode.Single);
        }
    }
}
