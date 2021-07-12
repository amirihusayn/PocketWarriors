using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalHealth))]
public class UNetHealth : NetworkBehaviour
{
    // Fields
    private LocalHealth localHealth;
    [SyncVar(hook = "UpdateCurrentHealth")] private float currentHealth;
	[SyncVar] private float maxHealth;

    // Methods
    private void Awake()
    {
        localHealth = GetComponent<LocalHealth>();
    }

    private void Start()
    {
        localHealth.InstantiateHealthText();
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        localHealth.InitializeLocalHealth();
        InitializeUNetHealth();
        localHealth.OnCurrentHealthChanged += SetUNetCurrentHealth;
        localHealth.OnCurrentHealthChanged += localHealth.UpdateHealthUI;
        localHealth.OnDie += RpcDie;
    }

    private void InitializeUNetHealth()
    {
        currentHealth = localHealth.CurrentHealth;
        maxHealth = localHealth.MaxHealth;
    }

    private void SetUNetCurrentHealth(float updatedCurrentHealth)
    {
        currentHealth = updatedCurrentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        localHealth.TakeDamage(other);
    }

	private void UpdateCurrentHealth(float updatedCurrentHealth)
	{
        localHealth.UpdateHealthUI(updatedCurrentHealth);
	}

    [ClientRpc]
    private void RpcDie()
    {
        localHealth.Die();
    }
}
