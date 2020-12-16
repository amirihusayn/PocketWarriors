using UnityEngine;

public class Jump : ActionPrototype
{
    public override void Check(LocalInputCheck localInputChecker)
    {
        isNormalOperation = CheckNormalOperation(localInputChecker);
        isSpectralOperation = CheckSpectralOperation(localInputChecker);
    }

    public override void Perform(LocalInputCheck localInputChecker)
    {
        if(isNormalOperation)
            PerformNormalOperation(localInputChecker);
        if(isSpectralOperation)
            PerformSpectralOperation(localInputChecker);
    }

    protected override bool CheckNormalOperation(LocalInputCheck localInputChecker)
    {
        InputPrototype inputPrototype = localInputChecker.WarriorInput;
        if(Input.GetKeyDown(inputPrototype.GetKey(InputPrototype.keyTypes.Jump)))
            return true;
        else
            return false;
    }

    protected override bool CheckSpectralOperation(LocalInputCheck localInputChecker)
    {
        InputPrototype inputPrototype = localInputChecker.WarriorInput;
        if(Input.GetKeyDown(inputPrototype.GetKey(InputPrototype.keyTypes.Jump))
        && Input.GetKey(inputPrototype.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(LocalInputCheck localInputChecker)
    {
        localInputChecker.WarriorAnimator.SetTrigger("OnJump");
    }

    protected override void PerformSpectralOperation(LocalInputCheck localInputChecker)
    {
        throw new System.NotImplementedException();
    }
}