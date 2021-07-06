using UnityEngine;

public class RightHorizontalHit : ActionPrototype
{
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
        warriorAction.WarriorAnimator.SetTrigger("OnRightHorizontalHit");
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {
        //
    }
}