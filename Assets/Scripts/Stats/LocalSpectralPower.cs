using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSpectralPower : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    private float currentPower, maxPower;
    public static Action NoPower;

    // Properties
    public float CurrentPower
    {
        get
        {
            return currentPower;
        }
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

    public float MaxPower
    {
        get
        {
            return maxPower;
        }

        private set
        {
            maxPower = value;
        }
    }

    // Methods
    private void Start()
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        Initialize();
    }
    
    public void Initialize()
    {
        CurrentPower = stats.MaxPower;
        MaxPower = stats.MaxPower;
    }

    public void ConsumePower(float power)
    {
        CurrentPower -= power;
    }
}
