using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadZone : MonoBehaviour
{



    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Attic"))
        {
            SceneManager.LoadScene("AtticLevel");
        }
       if (other.gameObject.CompareTag("Bed"))
        {
            SceneManager.LoadScene("BedLevel");
        }
       if (other.gameObject.CompareTag("Closet"))
        {
            SceneManager.LoadScene("ClosetLevel");
        }
    }
}
