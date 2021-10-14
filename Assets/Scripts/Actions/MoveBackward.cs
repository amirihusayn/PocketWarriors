using UnityEngine;

namespace PocketWarriors
{
    public class MoveBackward : ActionPrototype
    {
        // Properties___________________________________________________
        public override bool IsSubscribable { get => true;}

        // Methods_____________________________________________________
        protected override bool CheckNormalOperation(ActionRequirement requirement)
        {
            bool isPerformable = false;
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Down)))
            {
            requirement.Movement = new Vector3(requirement.Movement.x, requirement.Movement.y, requirement.Movement.z - 1) * Time.deltaTime;
            isPerformable = true;
            }
            return isPerformable;
        }

        protected override bool CheckSpectralOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Down))
            && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
                return true;
            else
                return false;
        }

        protected override void PerformNormalOperation(ActionRequirement requirement)
        {
            requirement.Animator.SetBool("isWalking" , true);
        }

        protected override void PerformSpectralOperation(ActionRequirement requirement)
        {
        }
    }
}