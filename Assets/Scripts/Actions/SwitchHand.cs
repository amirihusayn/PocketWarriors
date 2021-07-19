using UnityEngine;

public class SwitchHand : ActionPrototype
{
    // Properties
    public override bool IsSubscribable { get => GameController.Instance.IsGameLocal;}

    // Methods
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
        warriorAction.WarriorAnimator.SetTrigger("OnSwitchHand");
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {
        // 
    }
}