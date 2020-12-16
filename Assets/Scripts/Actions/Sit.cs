public class Sit : ActionPrototype
{
    public override void Check(LocalInputCheck localInputChecker)
    {
        isNormalOperation = CheckNormalOperation(localInputChecker);
        isSpectralOperation = CheckSpectralOperation(localInputChecker);
    }

    public override void Perform(LocalInputCheck localInputChecker)
    {
        throw new System.NotImplementedException();
    }

    protected override bool CheckNormalOperation(LocalInputCheck localInputChecker)
    {
        throw new System.NotImplementedException();
        // InputPrototype inputPrototype = localInputChecker.WarriorInput;
        // if(Input.GetKeyDown(inputPrototype.GetKey(KeyTypes.Jump)))
        //     return true;
        // else
        //     return false;
    }

    protected override bool CheckSpectralOperation(LocalInputCheck localInputChecker)
    {
        throw new System.NotImplementedException();
    }

    protected override void PerformNormalOperation(LocalInputCheck localInputChecker)
    {
        throw new System.NotImplementedException();
    }

    protected override void PerformSpectralOperation(LocalInputCheck localInputChecker)
    {
        throw new System.NotImplementedException();
    }
}