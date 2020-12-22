using UnityEngine;

public class Run : ActionPrototype
{
    public override void Check(WarriorAction warriorActionChecker)
    {
        isNormalOperation = CheckNormalOperation(warriorActionChecker);
        isSpectralOperation = CheckSpectralOperation(warriorActionChecker);
    }

    public override void Perform(WarriorAction warriorActionChecker)
    {
        if(isSpectralOperation)
            PerformSpectralOperation(warriorActionChecker);
        else if(isNormalOperation)
            PerformNormalOperation(warriorActionChecker);
        isNormalOperation = false;
        isSpectralOperation = false;
    }

    protected override bool CheckNormalOperation(WarriorAction warriorActionChecker)
    {
        InputPrototype inputPrototype = warriorActionChecker.WarriorInput;
        if(Input.GetKeyDown(inputPrototype.GetKey(InputPrototype.keyTypes.Run)))
            return true;
        else
            return false;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorActionChecker)
    {
        InputPrototype inputPrototype = warriorActionChecker.WarriorInput;
        if(Input.GetKeyDown(inputPrototype.GetKey(InputPrototype.keyTypes.Run))
        && Input.GetKey(inputPrototype.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorActionChecker)
    {
        warriorActionChecker.WarriorAnimator.SetBool("isWalking" , true);
        ////// increase animation speed and movement speed
    }

    protected override void PerformSpectralOperation(WarriorAction warriorActionChecker)
    {
        // double movement speed but more power cost
    }
}