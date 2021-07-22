using UnityEngine;

public class LeftVerticalHit : ActionPrototype
{
    // Properties___________________________________________________
    public override bool IsSubscribable { get => GameController.Instance.IsGameLocal;}

    // Methods_____________________________________________________
    protected override bool CheckNormalOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.LeftHandAction)) && !warriorAction.IsHorizontalAttack)
            return true;
        else
            return false;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.LeftHandAction)) && !warriorAction.IsHorizontalAttack
        && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorAction)
    {
        warriorAction.WarriorAnimator.SetTrigger("OnLeftVerticalHit");
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {

        // create a direct spectral power mesh front of warrior
    }
}