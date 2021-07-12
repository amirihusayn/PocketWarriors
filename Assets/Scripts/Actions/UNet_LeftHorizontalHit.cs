using UnityEngine;
using UnityEngine.Networking;

public class UNet_LeftHorizontalHit : ActionPrototype
{
    // Fields
    private NetworkAnimator networkAnimator;
    private bool isNetworkAnimatorInitialized;

    // Properties
    public override bool isSubscribable { get => !GameController.Instance.IsGameLocal;}

    // Methods
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
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.LeftHandAction)) && warriorAction.IsHorizontalAttack)
            return true;
        else
            return false;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.LeftHandAction)) && warriorAction.IsHorizontalAttack
        && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorAction)
    {
        networkAnimator.SetTrigger("OnLeftHorizontalHit");
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {
        //
    }
}