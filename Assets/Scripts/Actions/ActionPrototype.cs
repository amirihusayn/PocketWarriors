using UnityEngine;

public abstract class ActionPrototype 
{
    // Fields
    protected static string animationTriggerName;
    protected bool isNormalOperation;
    protected bool isSpectralOperation;
    
    // Methods
    public void Subscribe(ActionContainer targetActionChecker)
    {
        targetActionChecker.WarriorActionsChecker += Check;
    }
    public abstract void Check(LocalInputCheck localInputChecker);
    protected abstract bool CheckNormalOperation(LocalInputCheck localInputChecker);
    protected abstract bool CheckSpectralOperation(LocalInputCheck localInputChecker);
    public abstract void Perform(LocalInputCheck localInputChecker);
    protected abstract void PerformNormalOperation(LocalInputCheck localInputChecker);
    protected abstract void PerformSpectralOperation(LocalInputCheck localInputChecker);

}