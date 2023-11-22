using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.gamedev.tv/courses/enrolled/2002332

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the damaging object
        if (collision.gameObject.CompareTag("Bubble"))
        {
            // Get the DamagingObject component from the colliding object
            DamagingObject Bubble = collision.gameObject.GetComponent<DamagingObject>();

            // Check if the DamagingObject component is found
            if (Bubble != null)
            {
                // Handle damage logic
                TakeDamage(Bubble.damageAmount);

                // Optionally, destroy the damaging object after collision
                Destroy(collision.gameObject);
            }
        }
    }
  

    public void TakeDamage(int damageAmount)
    {
        // Reduce player's health
        currentHealth -= damageAmount;

        // Add any additional logic, such as checking for death
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        // Handle player death, e.g., play death animation, reset level, etc.
        Destroy(gameObject);
    }
}
