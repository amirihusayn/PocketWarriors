using UnityEngine;

public class MoveBackward : ActionPrototype
{
    // Properties
    public override bool isSubscribable { get => true;}

    // Methods
    protected override bool CheckNormalOperation(WarriorAction warriorAction)
    {
        bool isPerformable = false;
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Down)))
        {
           warriorAction.Movement = new Vector3(warriorAction.Movement.x, warriorAction.Movement.y, warriorAction.Movement.z - 1) * Time.deltaTime;
           isPerformable = true;
        }
        return isPerformable;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Down))
        && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorAction)
    {
        warriorAction.WarriorAnimator.SetBool("isWalking" , true);
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {
        // 
    }
}