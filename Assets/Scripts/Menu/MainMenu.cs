using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Animator transitionAnim;

    public Button playButton;

    public float transitionTime = 1.5f;

    public GameObject BedPortal;
    public GameObject ClosetPortal;
    public GameObject WindowPortal;

    public GameObject BedLight;
    public GameObject ClosetLight;
    public GameObject WindowLight;

    public GameObject WinMenu;


    void Start()
    {
        transitionAnim = GetComponent<Animator>();
        checkGM();
        //playButton.onClick.AddListener(TaskOnClick);
                transitionAnim.Play("fadeMenuEnd");
    }

    public void PlayGame()
    {
        transitionAnim.Play("fadeMenuEnd");
        SceneManager.LoadScene("Hub");
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit!");
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

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape Quit!");
        }
        if (GameManager.Instance.hasall == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            Debug.Log("Got Variables");
            WinMenu.SetActive(true);
        }
    }




    public void TaskOnClick()
    {

        if (playButton != null)
        {
            transitionAnim.Play("fadeMenuEnd");
            LoadNextLevel();
        }

    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        //PlayGame();
    }

    IEnumerator LoadScene(int levelIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }

    public void checkGM()
    {
        if (GameManager.Instance.hasBook == true)
        {
            BedPortal.SetActive(false);
            BedLight.SetActive(true);
        }
        if (GameManager.Instance.hasBlanket == true)
        {
            ClosetPortal.SetActive(false);
            ClosetLight.SetActive(true);
        }
        if (GameManager.Instance.hasBear == true)
        {
            WindowPortal.SetActive(false);
            WindowLight.SetActive(true); 
        }
    }

    public void BackToHub()
    {
        SceneManager.LoadScene("HUB");
    }

}
