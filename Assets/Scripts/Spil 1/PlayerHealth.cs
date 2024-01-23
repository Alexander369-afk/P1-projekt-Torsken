// Code from https://www.gamedev.tv/courses/enrolled/2002332
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private AudioManager audioManager;
    public int maxHealth = 3;
    private int currentHealth;
    private Flash flash;

    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        if (audioManager == null)
        {

            Debug.LogWarning("AudioMangager not found in the scene.");
        }
    }
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
        audioManager.Play("TorskenAv");
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

