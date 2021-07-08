using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LocalStamina : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private TextMesh staminaText;
    private float currentStamina, maxStamina;
    public static Action NoStamina;

    // Properties
    public float CurrentStamina
    {
        get => currentStamina;
        private set
        {
            if(value > maxStamina)
                currentStamina = maxStamina;
            else if(value <= 0)
            {
                currentStamina = 0;
            }
            else
                currentStamina = value;
        }
    }
    public float MaxStamina { get => maxStamina; private set => maxStamina = value; }

    // Methods
    private void Start()
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        Initialize();
    }
    
    public void Initialize()
    {
        MaxStamina = stats.MaxStamina;
        CurrentStamina = stats.MaxStamina;
    }

    public void ConsumeStamina(float stamina)
    {
        CurrentStamina -= stamina;
    }

    public void UpdateStaminaStuffs(float updatedStamina)
    {
        staminaText.text = updatedStamina.ToString();
    }
}
