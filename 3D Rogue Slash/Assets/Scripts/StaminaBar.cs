using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityStandardAssets.Player;
public class StaminaBar : MonoBehaviour
{

    public Slider staminaBar;

    private int maxStamina = 100;
    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar instance;

    public PlayerSprint player;


    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }
    void Update()
    {
        if (currentStamina > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                UseStamina(.5f);
            }
            //player.sprint_Speed = 10f;
            //player.move_Speed = 5f;
        }
        else
        {
            //player.sprint_Speed = 5f;
            staminaBar.value = currentStamina;
            //player.move_Speed = 5f;
        }
    }
    public void UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
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
