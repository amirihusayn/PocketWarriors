using System;
using System.Collections;
using UnityEngine;

public class LocalSpectralPower : MonoBehaviour 
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private TextMesh spectralText;
    [SerializeField] private float reloadTimeInSeconds;
    [SerializeField] private float increaseAmount;
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
            if(OnCurrentPowerChanged != null)
                OnCurrentPowerChanged(this);
        }
    }
    public float MaxPower { get => maxPower; private set => maxPower = value; }

    // Methods
    private void Start()
    {
        if (!GameController.Instance.IsGameLocal)
            return;
        InitializeActions();
        InitializeLocalPower();
    }

    private void InitializeActions()
    {
        OnCurrentPowerChanged += UpdatePowerUI;
    }

    public void InitializeLocalPower()
    {
        MaxPower = stats.MaxPower;
        CurrentPower = stats.MaxPower;
        StopAllCoroutines();
        StartCoroutine("IncreasePower");
    }

    private IEnumerator IncreasePower()
    {
        while(true)
        {
            yield return new WaitForSeconds(reloadTimeInSeconds);
            currentPower += increaseAmount;
        }
    }

    public void UpdatePowerUI(LocalSpectralPower localPower)
    {
        spectralText.text = localPower.currentPower.ToString();
    }

    public void ConsumePower(float powerAmount)
    {
        CurrentPower -= powerAmount;
    }

    public bool HasEnoughPower(float powerCost)
    {
        return powerCost <= currentPower;
    }
}
