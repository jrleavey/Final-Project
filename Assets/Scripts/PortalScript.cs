using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public GameObject closetText;
    public GameObject bedText;
    public GameObject windowText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && this.gameObject.tag == "Closet")
        {
            closetText.SetActive(true);
            if (Input.GetKey(KeyCode.G) | Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                SceneManager.LoadScene("Lvl 2");
            }
        }

        if (other.tag == "Player" && this.gameObject.tag == "Bed")
        {
            bedText.SetActive(true);
            if (Input.GetKey(KeyCode.G) | Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                SceneManager.LoadScene("Lvl 1");
            }
        }
        if (other.tag == "Player" && this.gameObject.tag == "Window")
        {
            windowText.SetActive(true);
            if (Input.GetKey(KeyCode.G) | Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                SceneManager.LoadScene("Lvl 3");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && this.gameObject.tag == "Closet")
        {
            closetText.SetActive(false);
        }

        if (other.tag == "Player" && this.gameObject.tag == "Bed")
        {
            bedText.SetActive(false);

        }
        if (other.tag == "Player" && this.gameObject.tag == "Window")
        {
            windowText.SetActive(false);
        }
    }
}

