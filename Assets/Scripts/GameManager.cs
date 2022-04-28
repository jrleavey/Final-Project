using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasBear = false;
    public bool hasBook = false;
    public bool hasBlanket = false;
    public bool firsttime = true;

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance;  }
    }


    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }          
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
