using UnityEngine;
using UnityEngine.Networking;

public class UNet_SwitchHand : ActionPrototype
{
    // Fields________________________________________________________
    private NetworkAnimator networkAnimator;
    private bool isNetworkAnimatorInitialized;

    // Properties___________________________________________________
    public override bool IsSubscribable { get => !GameController.Instance.IsGameLocal;}

    // Methods_____________________________________________________
    public override void Check(WarriorAction warriorAction)
    {
        InitializeNetworkAnimator(warriorAction);
        base.Check(warriorAction);
    }

    private void InitializeNetworkAnimator(WarriorAction warriorAction)
    {
        if(isNetworkAnimatorInitialized)
            return;
        networkAnimator = warriorAction.GetComponent<NetworkAnimator>();
    }

    protected override bool CheckNormalOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.SwitchHand)))
            return true;
        else
            return false;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.SwitchHand))
        && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorAction)
    {
        networkAnimator.SetTrigger("OnSwitchHand");
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {
        // 
    }
}