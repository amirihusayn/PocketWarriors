using UnityEngine;

public abstract class ActionPrototype 
{
    // Fields
    protected static bool isHorizontal = false;
    protected bool isNormalOperation, isSpectralOperation;
    
    // Methods
    public void Subscribe(ActionContainer actionContainer)
    {
        actionContainer.Checker += Check;
        actionContainer.Performer += Perform;
    }

    public virtual void Check(WarriorAction warriorAction)
    {
        isNormalOperation = CheckNormalOperation(warriorAction);
        isSpectralOperation = CheckSpectralOperation(warriorAction);
    }

    public virtual void Perform(WarriorAction warriorAction)
    {
        if(isSpectralOperation)
            PerformSpectralOperation(warriorAction);
        else if(isNormalOperation)
            PerformNormalOperation(warriorAction);
        isNormalOperation = false;
        isSpectralOperation = false;
    }

    protected abstract bool CheckNormalOperation(WarriorAction warriorAction);
    protected abstract bool CheckSpectralOperation(WarriorAction warriorAction);
    protected abstract void PerformNormalOperation(WarriorAction warriorAction);
    protected abstract void PerformSpectralOperation(WarriorAction warriorAction);
}