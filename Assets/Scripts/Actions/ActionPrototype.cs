public abstract class ActionPrototype 
{
    // Fields________________________________________________________
    protected bool isNormalOperation, isSpectralOperation;
    protected LocalStamina localStamina;
    protected LocalSpectralPower localPower;

    // Properties___________________________________________________
    public abstract bool IsSubscribable { get;}
    
    // Methods_____________________________________________________
    public void Subscribe(ActionContainer actionContainer, WarriorAction warriorAction)
    {
        actionContainer.Checker += Check;
        actionContainer.Performer += Perform;
        localStamina = warriorAction.GetComponent<LocalStamina>();
        localPower = warriorAction.GetComponent<LocalSpectralPower>();
    }

    public virtual void Check(WarriorAction warriorAction)
    {
        isNormalOperation = CheckNormalOperation(warriorAction);
        isSpectralOperation = CheckSpectralOperation(warriorAction);
    }

    public virtual void Perform(WarriorAction warriorAction)
    {
        if(isSpectralOperation)
        {
            warriorAction.WarriorAnimator.SetBool("isSpectral", true);
            PerformSpectralOperation(warriorAction);
        }
        else if(isNormalOperation)
        {
            warriorAction.WarriorAnimator.SetBool("isSpectral", false);
            PerformNormalOperation(warriorAction);
        }
        isNormalOperation = false;
        isSpectralOperation = false;
    }

    protected abstract bool CheckNormalOperation(WarriorAction warriorAction);
    protected abstract bool CheckSpectralOperation(WarriorAction warriorAction);
    protected abstract void PerformNormalOperation(WarriorAction warriorAction);
    protected abstract void PerformSpectralOperation(WarriorAction warriorAction);
}