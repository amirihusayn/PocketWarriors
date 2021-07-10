using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(LocalStamina))]
public class UNetStamina : NetworkBehaviour
{
    // Fields
    private LocalStamina stamina;
    [SyncVar(hook = "UpdateCurrentStamina")] private float currentStamina;
    [SyncVar] private float maxStamina;

    // Methods
    private void Awake()
    {
        stamina = GetComponent<LocalStamina>();
    }

    void Start()
    {
		if(!isServer || GameController.Instance.IsGameLocal)
			return;
		stamina.InitializeLocalStamina();
        InitializeUNetStamina();
        stamina.OnCurrentStaminaChanged += SetUNetCurrentStamina;
        stamina.OnCurrentStaminaChanged += stamina.UpdateStaminaUI;
    }

    private void InitializeUNetStamina()
    {
        currentStamina = stamina.CurrentStamina;
        maxStamina = stamina.MaxStamina;
    }

    private void SetUNetCurrentStamina(LocalStamina localStamina)
    {
        currentStamina = localStamina.CurrentStamina;
    }

    private void UpdateCurrentStamina(float updatedStamina)
    {
        stamina.OnCurrentStaminaChanged(stamina);
    }
}
