using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuLogic : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject screenDim;

    private bool isPaused = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused == false)
            {
                pauseUI.SetActive(true);
                screenDim.SetActive(true);
                isPaused = true;

                Time.timeScale = 0.0f;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Unpause();
            }
        }
    }

    public void Unpause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseUI.SetActive(false);
            screenDim.SetActive(false);

            Time.timeScale = 1.0f;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
