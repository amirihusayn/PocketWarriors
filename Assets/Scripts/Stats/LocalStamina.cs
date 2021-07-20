using System;
using System.Collections;
using UnityEngine;


public class LocalStamina : MonoBehaviour, IState<short>, IStamina<short>
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private StaminaIndicator staminaIndicator;
    [SerializeField] private float reloadTimeInSeconds;
    [SerializeField] private short increaseAmount;
    private short currentState, maxState;
    public Action<short> OnCurrentStaminaChanged;
    public Action OnNoStamina;

    // Properties
    public short CurrentState
    {
        get => currentState;
        private set
        {
            UpdateState(value);
        }
    }
    public short MaxState { get => maxState; private set => maxState = value; }
    public IIndicator<short> Indicator { get => staminaIndicator; }

    // Methods
    public void UpdateState(short updatedState)
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
        InitializeAllStaminaCosts();
        InitializeState();
        Indicator.InitializeIndicator();
    }

    public void InitializeActions()
    {
        OnCurrentStaminaChanged += UpdateIndicator;
    }

    public void UpdateIndicator(short updatedState)
    {
        Indicator.UpdateIndicator(updatedState, MaxState);
    }

    public void InitializeState()
    {
        MaxState = (short) stats.MaxStamina;
        CurrentState = (short) stats.MaxStamina;
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

    private void InitializeAllStaminaCosts()
    {
        Animator animator = GetComponent<Animator>();
        StaminaCost []staminaCostArray = animator.GetBehaviours<StaminaCost>();
        foreach(StaminaCost thisStaminaCost in staminaCostArray)
            thisStaminaCost.InitializeStaminaCostBehaviour(this);
    } 

    public void ConsumeStamina(short staminaAmount)
    {
        CurrentState -= staminaAmount;
    }

    public bool HasEnoughStamina(short staminaCost)
    {
        return staminaCost <= CurrentState;
    }
}
