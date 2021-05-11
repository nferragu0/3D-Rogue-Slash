using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public GameObject player;

    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = 100f;
    }

    void Update()
    {
        currentHealth = player.GetComponent<HealthScript>().health;
        loseHealth(currentHealth);
        
    }

    public void loseHealth(float amount)
    {
        healthBar.value = amount;
    }

    

}





    

    


