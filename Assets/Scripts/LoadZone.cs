using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadZone : MonoBehaviour
{



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.tag == "Bed")
        {
            SceneManager.LoadScene("Lvl 1");
        }
        if (other.tag == "Player" && this.tag == "Closet")
        {
            SceneManager.LoadScene("Lvl 2");
        }
        if (other.tag == "Player" && this.tag == "CrawlSpace")
        {
            SceneManager.LoadScene("Lvl 3");
        }
    }
}
