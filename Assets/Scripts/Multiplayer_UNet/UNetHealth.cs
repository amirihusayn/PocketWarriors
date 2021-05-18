using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalHealth))]
public class UNetHealth : NetworkBehaviour
{
    // Fields
    private LocalHealth health;
    [SyncVar(hook = "OnHealthChanged")] private float currentHealth;
	[SyncVar] private float maxHealth;

    // Methods
    private void Awake()
    {
        health = GetComponent<LocalHealth>();
    }

    private void Start()
    {
		if(!isServer)
			return;
        health.Initialize();
        SetUNetHealthValues();
    }

    private void SetUNetHealthValues()
    {
        currentHealth = health.CurrentHealth;
        maxHealth = health.MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer)
            return;
        health.TakeDamage(other);
		SetUNetHealthValues();
    }

	private void OnHealthChanged(float updatedHealth)
	{
		health.UpdateHealthStuffs(updatedHealth);
	}
}
