namespace PocketWarriors
{
    public abstract class ActionPrototype 
    {
        // Fields________________________________________________________
        protected bool isNormalOperation, isSpectralOperation;

        // Properties___________________________________________________
        public abstract bool IsSubscribable { get;}
        
        // Methods_____________________________________________________
        public void Subscribe(ActionContainer actionContainer)
        {
            actionContainer.Checker += Check;
            actionContainer.Performer += Perform;
        }

        public virtual void Check(ActionRequirement requirement)
        {
            isNormalOperation = CheckNormalOperation(requirement);
            isSpectralOperation = CheckSpectralOperation(requirement);
        }

        public virtual void Perform(ActionRequirement requirement)
        {
            if(isSpectralOperation)
            {
                requirement.Animator.SetBool("isSpectral", true);
                PerformSpectralOperation(requirement);
            }
            else if(isNormalOperation)
            {
                requirement.Animator.SetBool("isSpectral", false);
                PerformNormalOperation(requirement);
            }
            isNormalOperation = false;
            isSpectralOperation = false;
        }

        protected abstract bool CheckNormalOperation(ActionRequirement requirement);
        protected abstract bool CheckSpectralOperation(ActionRequirement requirement);
        protected abstract void PerformNormalOperation(ActionRequirement requirement);
        protected abstract void PerformSpectralOperation(ActionRequirement requirement);
    }
}