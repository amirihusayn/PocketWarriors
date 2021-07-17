using System;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalStamina))]
public class UNetStamina : NetworkBehaviour, IState<float>
{
    // Fields
    private LocalStamina localStamina;
    [SyncVar(hook = "UpdateState")] private float currentState;
	[SyncVar] private float maxState;
    [SyncVar(hook = "UpdateIndicator")] private float indicatorValue;

    // Properties
    public float CurrentState { get => currentState; private set => currentState = value; }
    public float MaxState { get => maxState; private set => maxState = value; }
    public IIndicator<float> Indicator { get => localStamina.Indicator; }

    // Methods
    private void Awake()
    {
        localStamina = GetComponent<LocalStamina>();
    }

    void Start()
    {
        Indicator.InitializeIndicator();
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        InitializeActions();
        localStamina.InitializeState();
        indicatorValue = Indicator.CurrentValue;
        InitializeState();
    }

    public void InitializeActions()
    {
        localStamina.OnCurrentStaminaChanged += SetUNetCurrentStamina;
    }

    private void SetUNetCurrentStamina(float updatedState)
    {
        CurrentState = updatedState;
    }

    public void InitializeState()
    {
        CurrentState = localStamina.CurrentState;
        MaxState = localStamina.MaxState;
    }

    public void UpdateState(float updatedState)
    {
        if(localStamina == null || Indicator == null)
            return;
        Indicator.UpdateIndicator(updatedState, MaxState);
        indicatorValue = Indicator.CurrentValue;
    }

    public void UpdateIndicator(float updatedIndicatorValue)
    {
        if(localStamina == null || Indicator == null)
            return;
        Indicator.SetCurrentValue(updatedIndicatorValue);
    }
}
