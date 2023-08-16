using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour
{

    [SerializeField]
    private float maxHealth = 100f;

    private float currentHealth;
    [SerializeField]
    private float upgradeHealth;

    public float CurrentHealth
    {
        get { return currentHealth; }
    }
    private void UpgradeHealth()
    {
        maxHealth += upgradeHealth;
    }
    private void DowngradeHealth()
    {
        maxHealth -= upgradeHealth;
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aquí maneja lo que ocurre cuando el personaje muere
    }
}

