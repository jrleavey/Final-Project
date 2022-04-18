using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  bool hasBear = false;
    public  bool hasBook = false;
    public  bool hasBlanket = false;

    public GameObject BlanketLight;
    public GameObject BearLight;
    public GameObject BookLight;

    public GameObject winMenu;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBook == true && hasBlanket == true && hasBear == true)
        {
            winGame();
        }

        if (hasBear == true)
        {
            BearLight.SetActive(true);
        }

        if (hasBlanket == true)
        {
            BlanketLight.SetActive(true);

        }

        if (hasBook == true)
        {
            BookLight.SetActive(true);

        }

    }
    
    void winGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        AudioListener.pause = true;
        winMenu.SetActive(true);
    }
        
}
