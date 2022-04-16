using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 2;
    public float speedSprint = 14;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    public bool isSprinting;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    private AudioSource AudioSource;
    public AudioClip winSound;
    public AudioClip loseSound;
    public GameObject winScreen;
    public GameObject loseScreen;

    public bool isLightOn = true;
    public GameObject fLight;


    public GameObject playerCamera;
    public GameObject monsterCamera;
    public bool playerCamOn = true;
    public GameObject monsterFilter;

    public Rigidbody throwablePrefab;
    public Transform throwSpawnPoint;
    public float Tforce = 800;
    public bool canThrow = true;
    public bool isGameOver = false;
    public GameObject brMusic;
    public GameObject winBook;
    public bool isWalking = false;
    public Animator animator;

    public float maxStamina = 5;
    public float currentStamina;

    public float maxBattery= 15;
    public float currentBattery;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera.SetActive(true);
        monsterCamera.SetActive(false);
        currentStamina = 5;
        currentBattery = 15;
    }
    void Update()
    {
        Movement();
        CameraSwap();
        FlashLight();
        ThrowDistraction();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (isWalking == true)
        {
            animator.SetBool("IsMoving", true);
        }
        else if (isWalking == false)
        {
            animator.SetBool("IsMoving", false);
        }

        if (currentStamina <= 0)
        {
            currentStamina = 0;
        }

        if (currentStamina>= 5)
        {
            currentStamina = 5;
        }

        if (currentBattery <= 0)
        {
            currentBattery = 0;
            isLightOn = false;
            fLight.SetActive(false);
        }

        if (currentBattery >= 15)
        {
            currentBattery = maxBattery;
        }

        if (isLightOn == true)
        {
            currentBattery -= Time.deltaTime;
        }
        else if (isLightOn == false)
        {
            currentBattery += Time.deltaTime;
        }
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
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetKey(KeyCode.JoystickButton8)) && currentStamina > 0)
        {
            speed = speedSprint;
            currentStamina-= Time.deltaTime;
            //isSprinting = true;    code I tried to use for sprintbar
        }
        else
        {
            speed = 4;
            currentStamina+= Time.deltaTime;
            
            //isSprinting = false;  code I tried to use for sprintbar
        }
        
        

    }
    public void CaughtByMonster()
    {
        loseScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isGameOver = true;
        AudioSource.PlayClipAtPoint(loseSound, transform.position);

    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Win")
        {
            isGameOver = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            winScreen.SetActive(true);
            brMusic.SetActive(false);
            winBook.SetActive(false);
            AudioSource.PlayClipAtPoint(winSound, transform.position);
        }
    }
    public void CameraSwap()
    {
        if (Input.GetKeyDown(KeyCode.G) && playerCamOn == true)
        {
            playerCamera.SetActive(false);
            monsterCamera.SetActive(true);
            playerCamOn = false;
            monsterFilter.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.G) && playerCamOn == false)
        {
            monsterCamera.SetActive(false);
            playerCamera.SetActive(true);
            playerCamOn = true;
            monsterFilter.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && playerCamOn == true)
        {
            playerCamera.SetActive(false);
            monsterCamera.SetActive(true);
            playerCamOn = false;
            monsterFilter.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton0) && playerCamOn == false)
        {
            monsterCamera.SetActive(false);
            playerCamera.SetActive(true);
            playerCamOn = true;
            monsterFilter.SetActive(false);
        }
    }
    public void FlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F) && isLightOn == true)
        {
            fLight.SetActive(false);
            isLightOn = false;
        }
       else if (Input.GetKeyDown(KeyCode.F) && isLightOn == false)
        {
            fLight.SetActive(true);
            isLightOn = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2) && isLightOn == true)
        {
            fLight.SetActive(false);
            isLightOn = false;
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton2) && isLightOn == false)
        {
            fLight.SetActive(true);
            isLightOn = true;
        }
    }
    public void ThrowDistraction()
    {

        if (Input.GetKeyDown(KeyCode.E) && canThrow == true)
        {
            // Instantiate a prefab object
            var throwableinstance = Instantiate(throwablePrefab, throwSpawnPoint.position, throwSpawnPoint.rotation);
            throwableinstance.AddForce(throwSpawnPoint.forward * Tforce);
            canThrow = false;
            StartCoroutine(CoolDownTimer());
        }
        // it needs to bounce off on non ground objects
        // despawn after 3 seconds
        // reference monster AI to update waypoint system.
        if (Input.GetKeyDown(KeyCode.JoystickButton5) && canThrow == true)
        {
            // Instantiate a prefab object
            var throwableinstance = Instantiate(throwablePrefab, throwSpawnPoint.position, throwSpawnPoint.rotation);
            throwableinstance.AddForce(throwSpawnPoint.forward * Tforce);
            canThrow = false;
            StartCoroutine(CoolDownTimer());
        }
    }

    public IEnumerator CoolDownTimer()
    {
        yield return new WaitForSeconds(5f);
        canThrow = true;
    }
}
