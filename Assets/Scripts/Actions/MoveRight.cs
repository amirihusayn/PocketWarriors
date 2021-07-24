using UnityEngine;

namespace PocketWarriors
{
    public class MoveRight : ActionPrototype
    {
        // Properties___________________________________________________
        public override bool IsSubscribable { get => true;}

        // Methods_____________________________________________________
        protected override bool CheckNormalOperation(WarriorAction warriorAction)
        {
            bool isPerformable = false;
            InputPrototype warriorInput = warriorAction.WarriorInput;
            if(Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Right)))
            {
            warriorAction.Movement = new Vector3(warriorAction.Movement.x + 1, warriorAction.Movement.y, warriorAction.Movement.z) * Time.deltaTime;
            isPerformable = true;
            }
            return isPerformable;
        }

        protected override bool CheckSpectralOperation(WarriorAction warriorAction)
        {
            InputPrototype warriorInput = warriorAction.WarriorInput;
            if(Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Right))
            && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
                return true;
            else
                return false;
        }

        protected override void PerformNormalOperation(WarriorAction warriorAction)
        {
            warriorAction.WarriorAnimator.SetBool("isWalking" , true);
        }

        protected override void PerformSpectralOperation(WarriorAction warriorAction)
        {

            // 
        }
    }
}