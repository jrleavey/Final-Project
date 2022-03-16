using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    private AudioSource AudioSource;
    public AudioClip winSound;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject pCamera;
    public bool isLightOn = true;

    public GameObject playerCamera;
    public GameObject monsterCamera;
    public bool playerCamOn = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera.SetActive(true);
        monsterCamera.SetActive(false);
    }
    void Update()
    {
        Movement();
        CameraSwap();

    }
    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
    public void CaughtByMonster()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        pCamera.GetComponent<MouseLook>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Win")
        {
            pCamera.GetComponent<MouseLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            winScreen.SetActive(true);
            AudioSource.PlayClipAtPoint(winSound, transform.position);
            Time.timeScale = 0;
        }
    }
    public void CameraSwap()
    {
        if (Input.GetKeyDown(KeyCode.G) && playerCamOn == true)
        {
            playerCamera.SetActive(false);
            monsterCamera.SetActive(true);
            playerCamOn = false;
        }
        else if (Input.GetKeyDown(KeyCode.G) && playerCamOn == false)
        {
            monsterCamera.SetActive(false);
            playerCamera.SetActive(true);
            playerCamOn = true;
        }
    }
}
