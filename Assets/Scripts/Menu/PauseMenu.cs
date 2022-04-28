using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool isPaused;

    public GameObject LoseScreen;
    public GameObject WinScreen;

    private void Update()
    {
        if (LoseScreen.activeInHierarchy == false && WinScreen.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.P) | (Input.GetKeyDown(KeyCode.JoystickButton7)))
            {
                isPaused = !isPaused;
            }

            if (isPaused)
            {
                ActivateMenu();
            }

            else
            {
                DeactivateMenu();
            }
        }
    }

    public void ActivateMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
    }
}
