using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalHealth))]
public class UNetHealth : NetworkBehaviour
{
    // Fields
    private LocalHealth localHealth;
    private HealthIndicator healthIndicator;
    [SyncVar(hook = "OnUpdateCurrentHealth")] private float currentHealth;
	[SyncVar] private float maxHealth;
    [SyncVar(hook = "OnUpdateIndicatorScale")] private float indicatorScale;

    // Methods
    private void Awake()
    {
        localHealth = GetComponent<LocalHealth>();
        healthIndicator = localHealth.HealthIndicator;
    }

    private void Start()
    {
        healthIndicator.InitializeIndicator();
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        InitializeActions();
        localHealth.InitializeLocalHealth();
        indicatorScale = healthIndicator.CurrentScale;
        InitializeUNetHealth();
    }

    private void InitializeActions()
    {
        localHealth.OnCurrentHealthChanged += SetUNetCurrentHealth;
        localHealth.OnDie += RpcDie;
    }

    private void SetUNetCurrentHealth(float updatedCurrentHealth)
    {
        currentHealth = updatedCurrentHealth;
    }

    [ClientRpc]
    private void RpcDie()
    {
        localHealth.Die();
    }

    private void InitializeUNetHealth()
    {
        currentHealth = localHealth.CurrentHealth;
        maxHealth = localHealth.MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        localHealth.TakeDamage(other);
    }

	private void OnUpdateCurrentHealth(float updatedCurrentHealth)
	{
        if(localHealth == null || healthIndicator == null)
            return;
        healthIndicator.Update(updatedCurrentHealth, maxHealth);
        indicatorScale = healthIndicator.CurrentScale;
	}

    private void OnUpdateIndicatorScale(float updatedScale)
    {
        if(localHealth == null || healthIndicator == null)
            return;
        healthIndicator.SetCurrentScale(updatedScale);
    }
}
