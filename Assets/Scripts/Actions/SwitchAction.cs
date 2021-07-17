using UnityEngine;

public class SwitchAction : ActionPrototype
{
    // Properties
    public override bool IsSubscribable { get => true;}

    // Methods
    protected override bool CheckNormalOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.SwitchAction)))
            return true;
        else
            return false;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.SwitchAction))
        && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorAction)
    {
        warriorAction.IsHorizontalAttack = !warriorAction.IsHorizontalAttack;
        warriorAction.WarriorAnimator.SetTrigger("OnSwitchAction");
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {
        // 
    }
}