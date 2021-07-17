using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalHealth))]
public class UNetHealth : NetworkBehaviour, IState<float>
{
    // Fields
    private LocalHealth localHealth;
    [SyncVar(hook = "UpdateState")] private float currentState;
	[SyncVar] private float maxState;
    [SyncVar(hook = "UpdateIndicator")] private float indicatorValue;

    // Properties
    public float CurrentState { get => currentState; private set => currentState = value; }
    public float MaxState { get => maxState; private set => maxState = value; }
    public IIndicator<float> Indicator { get => localHealth.Indicator; }

    // Methods
    private void Awake()
    {
        localHealth = GetComponent<LocalHealth>();
    }

    private void Start()
    {
        Indicator.InitializeIndicator();
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        InitializeActions();
        localHealth.InitializeState();
        indicatorValue = Indicator.CurrentValue;
        InitializeState();
    }

    public void InitializeActions()
    {
        localHealth.OnCurrentHealthChanged += SetUNetCurrentHealth;
        localHealth.OnDie += RpcDie;
    }

    private void SetUNetCurrentHealth(float updatedState)
    {
        CurrentState = updatedState;
    }

    [ClientRpc]
    private void RpcDie()
    {
        localHealth.Die();
    }

    public void InitializeState()
    {
        CurrentState = localHealth.CurrentState;
        MaxState = localHealth.MaxState;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        localHealth.TakeDamage(other);
    }

	public void UpdateState(float updatedState)
	{
        if(localHealth == null || Indicator == null)
            return;
        Indicator.UpdateIndicator(updatedState, MaxState);
        indicatorValue = Indicator.CurrentValue;
	}

    public void UpdateIndicator(float updatedIndicatorValue)
    {
        if(localHealth == null || Indicator == null)
            return;
        Indicator.SetCurrentValue(updatedIndicatorValue);
    }
}
