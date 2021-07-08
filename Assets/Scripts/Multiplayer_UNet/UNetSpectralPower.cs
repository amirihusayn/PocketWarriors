using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalSpectralPower))]
public class UNetSpectralPower : NetworkBehaviour
{
    // Fields
    private LocalSpectralPower power;
    [SyncVar(hook = "OnSpectralPowerChanged")] private float currentPower;
    [SyncVar] private float maxPower;

    // Methods
    private void Awake()
    {
        power = GetComponent<LocalSpectralPower>();
    }

    private void Start()
    {
        if (!isServer)
            return;
        power.Initialize();
		SetUNetPowerValues();
    }

    private void SetUNetPowerValues()
    {
        currentPower = power.CurrentPower;
        maxPower = power.MaxPower;
    }

    private void OnSpectralPowerChanged(float updatedPower)
    {
        power.UpdateSpectralPowerStuffs(updatedPower);
    }

}
