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
    
    
    void Start()
    {
        transitionAnim = GetComponent<Animator> ();  
        //playButton.onClick.AddListener(TaskOnClick);
    }
    
    public void PlayGame ()
    {
        transitionAnim.Play("fadeMenuEnd");
        SceneManager.LoadScene("Hub");
    }

    public void QuitGame ()
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

    }

    
    

    public void TaskOnClick()
    {
        
        if(playButton != null)
        {
            transitionAnim.Play ("fadeMenuEnd");
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

}
