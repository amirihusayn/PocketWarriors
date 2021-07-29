using UnityEngine;

namespace PocketWarriors
{
    public class Idle : ActionPrototype
    {
        // Properties___________________________________________________
        public override bool IsSubscribable { get => true;}

        // Methods_____________________________________________________
        protected override bool CheckNormalOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            bool isStoppedMovingDown = Input.GetKeyUp(warriorInput.GetKey(InputPrototype.keyTypes.Down));
            bool isStoppedMovingUp = Input.GetKeyUp(warriorInput.GetKey(InputPrototype.keyTypes.Up));
            bool isStoppedMovingLeft = Input.GetKeyUp(warriorInput.GetKey(InputPrototype.keyTypes.Left));
            bool isStoppedMovingRight = Input.GetKeyUp(warriorInput.GetKey(InputPrototype.keyTypes.Right));

            if(isStoppedMovingDown)
            {
            requirement.Movement = new Vector3(requirement.Movement.x , requirement.Movement.y , 0 );
            }
            if(isStoppedMovingUp)
            {
            requirement.Movement = new Vector3(requirement.Movement.x , requirement.Movement.y , 0 );
            }
            if(isStoppedMovingLeft)
            {
            requirement.Movement = new Vector3(0 , requirement.Movement.y , requirement.Movement.z );
            }
            if(isStoppedMovingRight)
            {
            requirement.Movement = new Vector3(0 , requirement.Movement.y , requirement.Movement.z );
            }
            return false;
        }

        protected override bool CheckSpectralOperation(ActionRequirement requirement)
        {
            return false;
        }

        protected override void PerformNormalOperation(ActionRequirement requirement)
        {
            requirement.Animator.SetBool("isWalking" , false);
        }

        protected override void PerformSpectralOperation(ActionRequirement requirement)
        {

        }
    }
}