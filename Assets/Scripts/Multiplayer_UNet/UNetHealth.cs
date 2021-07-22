using System;
using UnityEngine;
using UnityEngine.Networking;

public class UNetHealth : NetworkBehaviour, IState<short>, IHealth<short>
{
    // Fields________________________________________________________
    [SerializeField] private WarriorStats stats;
    [SerializeField] private HealthIndicator healthIndicator;
    [SyncVar(hook = "UpdateState")] private short currentState;
	[SyncVar] private short maxState;
    [SyncVar(hook = "UpdateIndicator")] private short indicatorValue;
    public Action OnDie;

    // Properties___________________________________________________
    public short CurrentState
    {
        get => currentState;
        private set
        {
            SetCurrentState(value);
        }
    }
    public short MaxState { get => maxState; private set => maxState = value; }
    public IIndicator<short> Indicator { get => healthIndicator; }

    // Methods_____________________________________________________
    public void SetCurrentState(short updatedState)
    {
        if (updatedState > MaxState)
            currentState = MaxState;
        else if (updatedState <= 0)
        {
            currentState = 0;
            if (OnDie != null)
                OnDie();
        }
        else
            currentState = updatedState;
    }

    private void Start()
    {
        Indicator.InitializeIndicator();
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        InitializeActions();
        InitializeState();
        indicatorValue = Indicator.CurrentValue;
    }

    public void InitializeActions()
    {
        OnDie += RpcDie;
    }

    [ClientRpc]
    private void RpcDie()
    {
        int xValue = UnityEngine.Random.Range(-5, 5);
        int yValue = 5;
        int zValue = UnityEngine.Random.Range(-5, 5);
        gameObject.SetActive(false);
        transform.position = new Vector3(xValue, yValue, zValue);
        gameObject.SetActive(true);
        CurrentState = MaxState;
    }

    public void InitializeState()
    {
        MaxState = (short)stats.MaxHealth;
        CurrentState = (short)stats.MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        TakeDamage(other);
    }

    public void TakeDamage(Collider other)
    {
        WeaponHold weaponHold = other.GetComponent<WeaponHold>();
        if(weaponHold == null || weaponHold.WarriorID == gameObject.GetInstanceID())
            return;
        CurrentState -= (short)weaponHold.Damage;
    }

	public void UpdateState(short updatedState)
	{
        if(Indicator == null)
            return;
        Indicator.UpdateIndicator(updatedState, MaxState);
        indicatorValue = Indicator.CurrentValue;
	}

    public void UpdateIndicator(short updatedIndicatorValue)
    {
        if(Indicator == null)
            return;
        Indicator.SetCurrentValue(updatedIndicatorValue);
    }
}
