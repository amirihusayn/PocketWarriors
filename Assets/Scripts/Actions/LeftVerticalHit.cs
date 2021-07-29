using UnityEngine;

namespace PocketWarriors
{
    public class LeftVerticalHit : ActionPrototype
    {
        // Properties___________________________________________________
        public override bool IsSubscribable { get => GameController.Instance.IsGameLocal;}

        // Methods_____________________________________________________
        protected override bool CheckNormalOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.LeftHandAction)) && !requirement.IsHorizontalAttack)
                return true;
            else
                return false;
        }

        protected override bool CheckSpectralOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.LeftHandAction)) && !requirement.IsHorizontalAttack
            && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
                return true;
            else
                return false;
        }

        protected override void PerformNormalOperation(ActionRequirement requirement)
        {
            requirement.Animator.SetTrigger("OnLeftVerticalHit");
        }

        protected override void PerformSpectralOperation(ActionRequirement requirement)
        {

            // create a direct spectral power mesh front of warrior
        }
    }
}