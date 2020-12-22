using UnityEngine;

public abstract class ActionPrototype 
{
    // Fields
    protected static string animationTriggerName;
    protected bool isNormalOperation;
    protected bool isSpectralOperation;
    protected static bool isHorizontal = false;
    
    // Methods
    public void Subscribe(ActionContainer targetActionChecker)
    {
        targetActionChecker.WarriorActionsChecker += Check;
    }
    public abstract void Check(WarriorAction warriorActionChecker);
    protected abstract bool CheckNormalOperation(WarriorAction warriorActionChecker);
    protected abstract bool CheckSpectralOperation(WarriorAction warriorActionChecker);
    public abstract void Perform(WarriorAction warriorActionChecker);
    protected abstract void PerformNormalOperation(WarriorAction warriorActionChecker);
    protected abstract void PerformSpectralOperation(WarriorAction warriorActionChecker);
}