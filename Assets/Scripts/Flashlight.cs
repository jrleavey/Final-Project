using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSource;
   // public AudioSource toggleSound;
    public bool failSafe = false;

    
    void Update()
    {
        if (Input.GetButtonDown("FKey"))
        {
            if (isOn == false && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(true);
               // toggleSound.Play();
                isOn = true;
                StartCoroutine(FailSafe());
            }
            if (isOn == true && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(false);
               // toggleSound.Play();
                isOn = false;
                StartCoroutine(FailSafe());
            }
        }
    }
    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failSafe = false;
    }
}
