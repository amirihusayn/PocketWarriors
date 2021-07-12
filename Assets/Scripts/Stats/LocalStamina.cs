using System;
using UnityEngine;


public class LocalStamina : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private TextMesh staminaText;
    private float currentStamina, maxStamina;
    public Action<LocalStamina> OnNoStamina, OnCurrentStaminaChanged;

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
                OnCurrentStaminaChanged(this);
        }
    }
    public float MaxStamina { get => maxStamina; private set => maxStamina = value; }

    // Methods
    private void Start()
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        InitializeLocalStamina();
        OnCurrentStaminaChanged += UpdateStaminaUI;
    }

    public void InitializeLocalStamina()
    {
        MaxStamina = stats.MaxStamina;
        CurrentStamina = stats.MaxStamina;
    }

    public void UpdateStaminaUI(LocalStamina localStamina)
    {
        staminaText.text = localStamina.currentStamina.ToString();
    }
    
    public void ConsumeStamina(float stamina)
    {
        CurrentStamina -= stamina;
    }
}
