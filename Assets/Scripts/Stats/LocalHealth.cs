using System;
using UnityEngine;

public class LocalHealth : MonoBehaviour, IState<float>
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private HealthIndicator healthIndicator;
    private float currentState, maxState;
    public Action<float> OnCurrentHealthChanged;
    public Action OnDie;

    // Properties
    public float CurrentState
    {
        get => currentState;
        private set
        {
            UpdateState(value);
        }
    }
    public float MaxState { get => maxState; private set => maxState = value; }
    public IIndicator<float> Indicator { get => healthIndicator; }

    // Methods
    public void UpdateState(float updatedState)
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
        if (OnCurrentHealthChanged != null)
            OnCurrentHealthChanged(currentState);
    }

    private void Start()
    {
        if (!GameController.Instance.IsGameLocal)
            return;
        InitializeActions();
        InitializeState();
        Indicator.InitializeIndicator();
    }

    public void InitializeActions()
    {
        OnCurrentHealthChanged += UpdateIndicator;
        OnDie += Die;
    }

    public void UpdateIndicator(float updatedState)
    {
        Indicator.UpdateIndicator(updatedState, MaxState);
    }

    public void Die()
    {
        int xValue = UnityEngine.Random.Range(-5, 5);
        int yValue = 5;
        int zValue = UnityEngine.Random.Range(-5, 5);
        gameObject.SetActive(false);
        transform.position = new Vector3(xValue, yValue, zValue);
        CurrentState = MaxState;
        gameObject.SetActive(true);
    }

    public void InitializeState()
    {
        MaxState = stats.MaxHealth;
        CurrentState = stats.MaxHealth;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        TakeDamage(other);
    }

    public void TakeDamage(Collider other)
    {
        WeaponHold weaponHold = other.GetComponent<WeaponHold>();
        if(weaponHold == null || weaponHold.WarriorID == gameObject.GetInstanceID())
            return;
        CurrentState -= weaponHold.Damage;
    }
}
