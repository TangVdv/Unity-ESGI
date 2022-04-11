using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int maxHealth = 100;
    public int currentHealth;

    public float maxStamina = 100f;
    public float currentStamina;

    public string maxCatchingScore = "100";

    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public PokemonUI pokemon;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;

        healthBar.SetMaxHealth(maxHealth);
        staminaBar.SetMaxStamina(maxStamina);
        pokemon.SetMaxPokemon(maxCatchingScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            pokemon.AddPokemon();
        }

    }

    void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.name == "superpotion" && healthBar.getHealth() < 100)
        {
            healthBar.AddHealth(30);
            Destroy(other.gameObject);
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

}
