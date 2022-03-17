using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void PlayGame ()
    {
        SceneManager.LoadScene("HUB");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LossScreen()
    {
        SceneManager.LoadScene("Loss");
    }

    public void WinScreen()
    {
        SceneManager.LoadScene("Win");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Escape Quit!");
        }
    }
}
