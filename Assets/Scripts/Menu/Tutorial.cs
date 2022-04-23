using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialTxt;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && this.gameObject.tag == "Tutorial")
        {
            TutorialTxt.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && this.gameObject.tag == "Tutorial")
        {
            TutorialTxt.SetActive(false);
        }

    }
}
