using UnityEngine;

namespace PocketWarriors
{
    public class Run : ActionPrototype
    {
        // Properties___________________________________________________
        public override bool IsSubscribable { get => true;}

        // Methods_____________________________________________________
        protected override bool CheckNormalOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Run)))
                return true;
            else
                return false;
        }

        protected override bool CheckSpectralOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Run))
            && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
                return true;
            else
                return false;
        }

        protected override void PerformNormalOperation(ActionRequirement requirement)
        {
            requirement.Animator.SetBool("isWalking" , true);
            // Increase animation speed and movement speed
        }

        protected override void PerformSpectralOperation(ActionRequirement requirement)
        {
        }
    }
}