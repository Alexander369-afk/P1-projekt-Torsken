using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.gamedev.tv/courses/enrolled/2002332

public class DamagingObject : MonoBehaviour
{
    public int damageAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player GameObject
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Check if the PlayerHealth component is found
            if (playerHealth != null)
            {
                // Inflict damage on the player
                playerHealth.TakeDamage(damageAmount);

                // Destroy the damaging object after it collides with the player
                Destroy(gameObject);
            }




        }
    }
}

