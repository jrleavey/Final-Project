using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWinObjects : MonoBehaviour
{
    public bool collectedBlanket = false;
    public bool collectedTeddy = false;
    public bool collectedStoryBook = false;
    public GameObject GameManager;

    public void Awake()
    {
        GameManager = GameObject.Find("GameManager");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Blanket")
        {
            collectedBlanket = true;
            GameManager.GetComponent<GameManager>().hasBlanket = true;
            SceneManager.LoadScene("HUB");
        }
        if (other.tag == "Player" && this.tag == "Teddy")
        {
            collectedTeddy = true;
            GameManager.GetComponent<GameManager>().hasBear = true;
            SceneManager.LoadScene("HUB");
        }
        if (other.tag == "Player" && this.tag == "StoryBook")
        {
            collectedStoryBook = true;
            GameManager.GetComponent<GameManager>().hasBook = true;

            SceneManager.LoadScene("HUB");
        }
    }
}
