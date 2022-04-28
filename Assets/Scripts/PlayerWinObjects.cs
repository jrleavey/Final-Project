using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWinObjects : MonoBehaviour
{
    public bool collectedBlanket = false;
    public bool collectedTeddy = false;
    public bool collectedStoryBook = false;

    public GameObject lvl1Win;
    public GameObject lvl2Win;
    public GameObject lvl3Win;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Blanket")
        {
            collectedBlanket = true;
            if (lvl2Win != null)
            {
                lvl2Win.SetActive(true);
            }
            GameManager.Instance.hasBlanket = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;


        }
        if (other.tag == "Player" && this.tag == "Bear")
        {
            collectedTeddy = true;
            if (lvl3Win != null)
            {
                lvl3Win.SetActive(true);
            }
            GameManager.Instance.hasBear = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        if (other.tag == "Player" && this.tag == "StoryBook")
        {
            collectedStoryBook = true;
            if (lvl1Win != null)
            {
                lvl1Win.SetActive(true);
            }
            GameManager.Instance.hasBook = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}
