using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStamina = 100;

    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    public static Stamina instance;

    private Coroutine regen;

    public PlayerController playerSprint; 

   
    void Start()
    {
        currentStamina = maxStamina;

        staminaBar.maxValue = maxStamina;

        staminaBar.value = maxStamina;
    }

    void Update()
    {
        if (currentStamina > 10)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                UseStamina(0.40f);
            }

            playerSprint.speed = 2f;
            playerSprint.speedSprint = 14f;
        }
        else if (currentStamina <= 10)
        {
            playerSprint.isSprinting = false;
            staminaBar.value = currentStamina;
            playerSprint.speed = 1f;
            playerSprint.speedSprint = 5f;
        }


    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
    }
}

