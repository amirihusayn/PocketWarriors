using System;
using UnityEngine;

public class LocalHealth : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private HealthIndicator healthIndicator;
    private float currentHealth, maxHealth;
    public Action<float> OnCurrentHealthChanged;
    public Action OnDie;

    // Properties
    public float CurrentHealth
    {
        get => currentHealth;
        private set
        {
            if(value > maxHealth)
                currentHealth = maxHealth;
            else if(value <= 0)
            {
                currentHealth = 0;
                if(OnDie != null)
                    OnDie();
            }
            else
                currentHealth = value;
            if(OnCurrentHealthChanged != null)
                OnCurrentHealthChanged(currentHealth);
        }
    }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    public HealthIndicator HealthIndicator { get => healthIndicator; }

    // Methods
    private void Start()
    {
        if (!GameController.Instance.IsGameLocal)
            return;
        InitializeActions();
        InitializeLocalHealth();
        healthIndicator.InitializeIndicator();
    }

    private void InitializeActions()
    {
        OnCurrentHealthChanged += UpdateIndicator;
        OnDie += Die;
    }

    public void UpdateIndicator(float updatedCurrentHealth)
    {
        healthIndicator.Update(updatedCurrentHealth, maxHealth);
    }

    public void Die()
    {
        int xValue = UnityEngine.Random.Range(-5, 5);
        int yValue = 5;
        int zValue = UnityEngine.Random.Range(-5, 5);
        gameObject.SetActive(false);
        transform.position = new Vector3(xValue, yValue, zValue);
        CurrentHealth = MaxHealth;
        gameObject.SetActive(true);
    }

    public void InitializeLocalHealth()
    {
        MaxHealth = stats.MaxHealth;
        CurrentHealth = stats.MaxHealth;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        TakeDamage(other);
    }

    public void TakeDamage(Collider other)
    {
        WeaponHold weaponHold = other.GetComponent<WeaponHold>();
        if(weaponHold == null || weaponHold.WarriorID == gameObject.GetInstanceID())
            return;
        CurrentHealth -= weaponHold.Damage;
    }
}
