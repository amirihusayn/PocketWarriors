using UnityEngine;

public class Run : ActionPrototype
{
    // Properties___________________________________________________
    public override bool IsSubscribable { get => true;}

    // Methods_____________________________________________________
    protected override bool CheckNormalOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Run)))
            return true;
        else
            return false;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Run))
        && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorAction)
    {
        warriorAction.WarriorAnimator.SetBool("isWalking" , true);
        ////// increase animation speed and movement speed
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {
        // double movement speed but more power cost
    }
}