using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsLogic : MonoBehaviour
{
    public GameObject title;
    public GameObject backButton;
    public GameObject popup;

    public GameObject popupConfirm;
    public GameObject popupDone;

    public void DeleteButton()
    {
        title.SetActive(false);
        backButton.SetActive(false);
        popup.SetActive(true);
    }

    public void PopupBack()
    {
        title.SetActive(true);
        backButton.SetActive(true);
        popup.SetActive(false);
    }

    public void DeleteConfirm()
    {
        popupConfirm.SetActive(false);
        popupDone.SetActive(true);
    }

    public void DeleteDone()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All data deleted and application closed");
        Application.Quit();
    }
}
