using System;
using UnityEngine;

public class LocalSpectralPower : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private TextMesh spectralText;
    private float currentPower, maxPower;
    public Action<LocalSpectralPower> OnNoPower, OnCurrentPowerChanged;

    // Properties
    public float CurrentPower
    {
        get => currentPower;
        private set
        {
            if(value > maxPower)
                currentPower = maxPower;
            else if(value <= 0)
                currentPower = 0;
            else
                currentPower = value;
            OnCurrentPowerChanged(this);
        }
    }
    public float MaxPower { get => maxPower; private set => maxPower = value; }

    // Methods
    private void Start()
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        InitializeLocalPower();
        OnCurrentPowerChanged += UpdatePowerUI;
    }

    public void InitializeLocalPower()
    {
        MaxPower = stats.MaxPower;
        CurrentPower = stats.MaxPower;
    }

    public void UpdatePowerUI(LocalSpectralPower localPower)
    {
        spectralText.text = localPower.currentPower.ToString();
    }

    public void ConsumePower(float power)
    {
        CurrentPower -= power;
    }
}
