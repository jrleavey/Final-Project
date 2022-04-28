using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenuTrigger : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject winMenu;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        winMenu = GameObject.FindGameObjectWithTag("WinMenu");
    }

    // Update is called once per frame
}
