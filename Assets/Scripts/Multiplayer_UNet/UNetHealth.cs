using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalHealth))]
public class UNetHealth : NetworkBehaviour
{
    // Fields
    private LocalHealth health;
    [SyncVar(hook = "UpdateCurrentHealth")] private float currentHealth;
	[SyncVar] private float maxHealth;

    // Methods
    private void Awake()
    {
        health = GetComponent<LocalHealth>();
    }

    private void Start()
    {
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        health.InitializeLocalHealth();
        InitializeUNetHealth();
        health.OnCurrentHealthChanged += SetUNetCurrentHealth;
        health.OnCurrentHealthChanged += health.UpdateHealthUI;
    }

    private void InitializeUNetHealth()
    {
        currentHealth = health.CurrentHealth;
        maxHealth = health.MaxHealth;
    }

    private void SetUNetCurrentHealth(LocalHealth localHealth)
    {
        currentHealth = localHealth.CurrentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        health.TakeDamage(other);
    }

	private void UpdateCurrentHealth(float updatedHealth)
	{
		health.OnCurrentHealthChanged(health);
	}
}
