using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int catchingScore = 0;

    public int maxHealth = 100;
    public int currentHealth;

    public float maxStamina = 100f;
    public float currentStamina;

    public HealthBar healthBar;
    public StaminaBar staminaBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;

        healthBar.SetMaxHealth(maxHealth);
        staminaBar.SetMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            AddCatchingPoint(1);
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void SetStamina(float stamina)
    {
        currentStamina += stamina;
        staminaBar.SetStamina(currentStamina);
    }

    public void AddCatchingPoint(int points)
    {
        catchingScore += points;
    }

}
