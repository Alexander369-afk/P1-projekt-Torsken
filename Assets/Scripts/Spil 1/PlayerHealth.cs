using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from https://www.gamedev.tv/courses/enrolled/2002332

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 3;
    private int currentHealth;
    private Flash flash;

    void Start()
    {
        currentHealth = maxHealth;
        flash = GetComponent<Flash>();
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        StartCoroutine(flash.FlashRoutine());
        FindObjectOfType<AudioManager>().Play("Torsken Av");
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            
            LevelManager.instance.GameOver();
            
            gameObject.SetActive(false);
        }
    }
}

