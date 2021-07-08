using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LocalHealth : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private TextMesh healthText;
    private float currentHealth, maxHealth;
    public static Action NoHealth;

    // Properties
    public float CurrentHealth
    {
        get => currentHealth;
        private set
        {
            if(value > maxHealth)
                currentHealth = maxHealth;
            else if(value <= 0)
                currentHealth = 0;
            else
                currentHealth = value;
            OnHealthChanged();
        }
    }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    // Methods
    private void Start()
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        Initialize();
    }

    private void OnTriggerEnter(Collider other) {
        if(!GameController.Instance.IsGameLocal)
            return;
        TakeDamage(other);
    }

    public void Initialize()
    {
        MaxHealth = stats.MaxHealth;
        CurrentHealth = stats.MaxHealth;
    }

    public void TakeDamage(Collider other)
    {
        WeaponHold weaponHold = other.GetComponent<WeaponHold>();
        if(weaponHold == null)
            return;
        CurrentHealth -= weaponHold.Damage;
    }

	private void OnHealthChanged()
	{
        if(!GameController.Instance.IsGameLocal)
            return;
        UpdateHealthStuffs(currentHealth);
	}

    public void UpdateHealthStuffs(float updatedHealth)
    {
        healthText.text = updatedHealth.ToString();
    }

    public void Die()
    {
    }
}
