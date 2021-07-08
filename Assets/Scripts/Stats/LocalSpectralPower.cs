using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalSpectralPower : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private TextMesh spectralText;
    private float currentPower, maxPower;
    public static Action NoPower;

    // Properties
    public float CurrentPower
    {
        get => currentPower;
        private set
        {
            if(value > maxPower)
                currentPower = maxPower;
            else if(value <= 0)
            {
                currentPower = 0;
            }
            else
                currentPower = value;
        }
    }
    public float MaxPower { get => maxPower; private set => maxPower = value; }

    // Methods
    private void Start()
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        Initialize();
    }
    
    public void Initialize()
    {
        MaxPower = stats.MaxPower;
        CurrentPower = stats.MaxPower;
    }

    public void ConsumePower(float power)
    {
        CurrentPower -= power;
    }

    public void UpdateSpectralPowerStuffs(float updatedPower)
    {
        spectralText.text = updatedPower.ToString();
    }
}
