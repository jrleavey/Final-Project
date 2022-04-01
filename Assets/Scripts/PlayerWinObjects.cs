using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWinObjects : MonoBehaviour
{
    public bool collectedBlanket = false;
    public bool collectedTeddy = false;
    public bool collectedStoryBook = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Blanket")
        {
            other.gameObject.SetActive(false);
            collectedBlanket = true;
            SceneManager.LoadScene("HUB");
        }
        if (other.tag == "Player" && this.tag == "Teddy")
        {
            other.gameObject.SetActive(false);
            collectedTeddy = true;
            SceneManager.LoadScene("HUB");
        }
        if (other.tag == "Player" && this.tag == "StoryBook")
        {
            other.gameObject.SetActive(false);
            collectedStoryBook = true;
            SceneManager.LoadScene("HUB");
        }
    }
}
