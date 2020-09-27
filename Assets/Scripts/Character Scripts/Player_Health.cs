using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Rigidbody2D rb;

    public Health_Bar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            TakeDamage(20);
        }

        if (rb.position.y < -6f)
        {
            FindObjectOfType<Restart>().EndGame();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<Restart>().EndGame();
    }
}
