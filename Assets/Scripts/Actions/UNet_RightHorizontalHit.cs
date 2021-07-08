using UnityEngine;
using UnityEngine.Networking;

public class UNet_RightHorizontalHit : ActionPrototype
{
    // Fields
    private NetworkAnimator networkAnimator;
    private bool isNetworkAnimatorInitialized;

    // Methods
    public override void Perform(WarriorAction warriorAction)
    {
        InitializeNetworkAnimator(warriorAction);
        base.Perform(warriorAction);
    }

    private void InitializeNetworkAnimator(WarriorAction warriorAction)
    {
        if(isNetworkAnimatorInitialized)
            return;
        networkAnimator = warriorAction.GetComponent<NetworkAnimator>();
        isNetworkAnimatorInitialized = true;
        if(networkAnimator == null)
            UnSubscribe(warriorAction.ActionContainer);
    }

    protected override bool CheckNormalOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.RightHandAction)) && warriorAction.IsHorizontalAttack)
            return true;
        else
            return false;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.RightHandAction)) && warriorAction.IsHorizontalAttack
        && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorAction)
    {
        networkAnimator.SetTrigger("OnRightHorizontalHit");
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {
        //
    }
}