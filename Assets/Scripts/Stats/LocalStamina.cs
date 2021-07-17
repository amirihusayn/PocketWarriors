using System;
using System.Collections;
using UnityEngine;


public class LocalStamina : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private StaminaIndicator staminaIndicator;
    [SerializeField] private float reloadTimeInSeconds;
    [SerializeField] private float increaseAmount;
    private float currentStamina, maxStamina;
    public Action<float> OnCurrentStaminaChanged;
    public Action OnNoStamina;

    // Properties
    public float CurrentStamina
    {
        get => currentStamina;
        private set
        {
            if(value > maxStamina)
                currentStamina = maxStamina;
            else if(value <= 0)
                currentStamina = 0;
            else
                currentStamina = value;
            if(OnCurrentStaminaChanged != null)
                OnCurrentStaminaChanged(currentStamina);
        }
    }
    public float MaxStamina { get => maxStamina; private set => maxStamina = value; }
    public StaminaIndicator StaminaIndicator { get => staminaIndicator; }

    // Methods
    private void Start()
    {
        if (!GameController.Instance.IsGameLocal)
            return;
        Initialize();
    }

    public void Initialize()
    {
        InitializeActions();
        InitializeLocalStamina();
        staminaIndicator.InitializeIndicator();
    }

    private void InitializeActions()
    {
        OnCurrentStaminaChanged += UpdateIndicator;
    }

    public void UpdateIndicator(float updatedCurrentStamina)
    {
        staminaIndicator.Update(updatedCurrentStamina, maxStamina);
    }

    public void InitializeLocalStamina()
    {
        MaxStamina = stats.MaxStamina;
        CurrentStamina = stats.MaxStamina;
        StopAllCoroutines();
        StartCoroutine("IncreaseStamina");
    }

    private IEnumerator IncreaseStamina()
    {
        while(true)
        {
            yield return new WaitForSeconds(reloadTimeInSeconds);
            CurrentStamina += increaseAmount;
        }
    }
        
    public void ConsumeStamina(float staminaAmount)
    {
        CurrentStamina -= staminaAmount;
    }

    public bool HasEnoughStamina(float staminaCost)
    {
        return staminaCost <= currentStamina;
    }
}
