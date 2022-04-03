using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonFunctions : MonoBehaviour
{
public void ButtonPlay()
    {
        SceneManager.LoadScene("Lvl 1");
    }
}
