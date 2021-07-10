using System;
using UnityEngine;


public class LocalHealth : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private TextMesh healthText;
    private float currentHealth, maxHealth;
    public Action<LocalHealth> OnDie, OnCurrentHealthChanged;

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
            OnCurrentHealthChanged(this);
        }
    }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    // Methods
    private void Start()
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        InitializeLocalHealth();
        OnCurrentHealthChanged += UpdateHealthUI;
    }

    public void InitializeLocalHealth()
    {
        MaxHealth = stats.MaxHealth;
        CurrentHealth = stats.MaxHealth;
    }

    public void UpdateHealthUI(LocalHealth localHealth)
    {
        healthText.text = localHealth.currentHealth.ToString();
    }

    private void OnTriggerEnter(Collider other) {
        if(!GameController.Instance.IsGameLocal)
            return;
        TakeDamage(other);
    }

    public void TakeDamage(Collider other)
    {
        WeaponHold weaponHold = other.GetComponent<WeaponHold>();
        if(weaponHold == null)
            return;
        CurrentHealth -= weaponHold.Damage;
    }

    public void Die()
    {
    }
}
