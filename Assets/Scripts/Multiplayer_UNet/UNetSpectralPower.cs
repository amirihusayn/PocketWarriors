using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalSpectralPower))]
public class UNetSpectralPower : NetworkBehaviour
{
    // Fields________________________________________________________
    private LocalSpectralPower power;
    [SyncVar(hook = "UpdateCurrentPower")] private float currentPower;
    [SyncVar] private float maxPower;

    // Methods_____________________________________________________
    private void Awake()
    {
        power = GetComponent<LocalSpectralPower>();
    }

    private void Start()
    {
        if (!isServer || GameController.Instance.IsGameLocal)
            return;
        power.InitializeLocalPower();
        InitializeUNetPower();
        power.OnCurrentPowerChanged += SetUNetCurrentPower;
        power.OnCurrentPowerChanged += power.UpdatePowerUI;
    }

    private void InitializeUNetPower()
    {
        maxPower = power.MaxPower;
    }

    private void SetUNetCurrentPower(LocalSpectralPower localPower)
    {
        currentPower = localPower.CurrentPower;
    }

    private void UpdateCurrentPower(float updatedPower)
    {
        if(power.OnCurrentPowerChanged != null)
            power.OnCurrentPowerChanged(power);
    }
}
