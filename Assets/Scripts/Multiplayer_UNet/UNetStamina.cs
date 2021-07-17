using System;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalStamina))]
public class UNetStamina : NetworkBehaviour
{
    // Fields
    private LocalStamina localStamina;
    private StaminaIndicator staminaIndicator;
    [SyncVar(hook = "OnUpdateCurrentStamina")] private float currentStamina;
	[SyncVar] private float maxStamina;
    [SyncVar(hook = "OnUpdateIndicatorHeight")] private float indicatorHeight;

    // Methods
    private void Awake()
    {
        localStamina = GetComponent<LocalStamina>();
        staminaIndicator = localStamina.StaminaIndicator;
    }

    void Start()
    {
        staminaIndicator.InitializeIndicator();
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        InitializeActions();
        localStamina.InitializeLocalStamina();
        indicatorHeight = staminaIndicator.CurrentHeight;
        InitializeUNetStamina();
    }

    private void InitializeActions()
    {
        localStamina.OnCurrentStaminaChanged += SetUNetCurrentStamina;
    }

    private void SetUNetCurrentStamina(float updatedCurrentStamina)
    {
        currentStamina = updatedCurrentStamina;
    }

    private void InitializeUNetStamina()
    {
        currentStamina = localStamina.CurrentStamina;
        maxStamina = localStamina.MaxStamina;
    }

    private void OnUpdateCurrentStamina(float updatedCurrentStamina)
    {
        if(localStamina == null || staminaIndicator == null)
            return;
        staminaIndicator.Update(updatedCurrentStamina, maxStamina);
        indicatorHeight = staminaIndicator.CurrentHeight;
    }

    private void OnUpdateIndicatorHeight(float updatedHeight)
    {
        if(localStamina == null || staminaIndicator == null)
            return;
        staminaIndicator.SetCurrentHeight(updatedHeight);
    }
}
