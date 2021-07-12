using System;
using UnityEngine;


public class LocalHealth : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private TextMesh healthText;
    [SerializeField] private GameObject healthTextPrefab;
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

    // Methods
    private void Start()
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        InitializeLocalHealth();
        InstantiateHealthText();
        OnCurrentHealthChanged += UpdateHealthUI;
        OnDie += Die;
    }

    public void InitializeLocalHealth()
    {
        MaxHealth = stats.MaxHealth;
        CurrentHealth = stats.MaxHealth;
    }

    public void InstantiateHealthText()
    {
        GameObject healthTextObject = Instantiate(healthTextPrefab);
        healthTextObject.transform.SetParent(gameObject.transform);
        healthText = healthTextObject.GetComponent<TextMesh>();
    }

    public void UpdateHealthUI(float updatedCurrentHealth)
    {
        healthText.text = updatedCurrentHealth.ToString();
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
}
