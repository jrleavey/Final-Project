using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerArtDemo : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    Vector3 Velocity;
    public GameObject pCamera;


    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        controller.Move(Velocity * Time.deltaTime);
    }
}
