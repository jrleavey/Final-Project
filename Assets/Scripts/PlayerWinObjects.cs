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
        if (other.gameObject.CompareTag("Blanket"))
        {
            collectedBlanket = true;
            SceneManager.LoadScene("HubLevel");
        }
        if (other.gameObject.CompareTag("Teddy"))
        {
            collectedTeddy = true;
            SceneManager.LoadScene("HubLevel");
        }
        if (other.gameObject.CompareTag("StoryBook"))
        {
            collectedStoryBook = true;
            SceneManager.LoadScene("HubLevel");
        }
    }
}
