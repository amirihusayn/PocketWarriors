using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalStamina))]
public class UNetStamina : NetworkBehaviour
{
    // Fields
    private LocalStamina stamina;
    [SyncVar] private float currentStamina;
    [SyncVar] private float maxStamina;

    // Methods
    private void Awake()
    {
        stamina = GetComponent<LocalStamina>();
    }

    void Start()
    {
		if(!isServer)
			return;
		stamina.Initialize();
		SetUNetStaminaValues();
    }

    private void SetUNetStaminaValues()
    {
        currentStamina = stamina.CurrentStamina;
        maxStamina = stamina.MaxStamina;
    }
}
