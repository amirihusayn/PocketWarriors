using UnityEngine;
using UnityEngine.Networking;

public class UNet_Jump : ActionPrototype
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
        bool isPerformable = false;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Jump)))
            if(warriorAction.transform.position.y <= warriorAction.Stats.JumpLimit)
                isPerformable = true;
        return isPerformable;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Jump))
        && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorAction)
    {
        networkAnimator.SetTrigger("OnJump");
        warriorAction.WarriorRigidBody.velocity = new Vector3(warriorAction.WarriorRigidBody.velocity.x , warriorAction.Stats.JumpSpeed , warriorAction.WarriorRigidBody.velocity.z);
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {
        networkAnimator.SetTrigger("OnJump");

        // create a projectile on ground that will explode
    }
}