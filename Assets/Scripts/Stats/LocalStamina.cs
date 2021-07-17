using System;
using System.Collections;
using UnityEngine;


public class LocalStamina : MonoBehaviour, IState<float>
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private StaminaIndicator staminaIndicator;
    [SerializeField] private float reloadTimeInSeconds;
    [SerializeField] private float increaseAmount;
    private float currentState, maxState;
    public Action<float> OnCurrentStaminaChanged;
    public Action OnNoStamina;

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
    public IIndicator<float> Indicator { get => staminaIndicator; }

    // Methods
    public void UpdateState(float updatedState)
    {
        if (updatedState > MaxState)
            currentState = MaxState;
        else if (updatedState <= 0)
            currentState = 0;
        else
            currentState = updatedState;
        if (OnCurrentStaminaChanged != null)
            OnCurrentStaminaChanged(currentState);
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
        OnCurrentStaminaChanged += UpdateIndicator;
    }

    public void UpdateIndicator(float updatedState)
    {
        Indicator.UpdateIndicator(updatedState, MaxState);
    }

    public void InitializeState()
    {
        MaxState = stats.MaxStamina;
        CurrentState = stats.MaxStamina;
        StopAllCoroutines();
        StartCoroutine("IncreaseStamina");
    }

    private IEnumerator IncreaseStamina()
    {
        while(true)
        {
            yield return new WaitForSeconds(reloadTimeInSeconds);
            CurrentState += increaseAmount;
        }
    }
        
    public void ConsumeStamina(float staminaAmount)
    {
        CurrentState -= staminaAmount;
    }

    public bool HasEnoughStamina(float staminaCost)
    {
        return staminaCost <= CurrentState;
    }
}
