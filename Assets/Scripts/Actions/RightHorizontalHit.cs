using UnityEngine;

namespace PocketWarriors
{
    public class RightHorizontalHit : ActionPrototype
    {
        // Properties___________________________________________________
        public override bool IsSubscribable { get => GameController.Instance.IsGameLocal;}
        // Methods_____________________________________________________
        protected override bool CheckNormalOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.RightHandAction)) && requirement.IsHorizontalAttack)
                return true;
            else
                return false;
        }

        protected override bool CheckSpectralOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.RightHandAction)) && requirement.IsHorizontalAttack
            && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
                return true;
            else
                return false;
        }

        protected override void PerformNormalOperation(ActionRequirement requirement)
        {
            requirement.Animator.SetTrigger("OnRightHorizontalHit");
        }

        protected override void PerformSpectralOperation(ActionRequirement requirement)
        {
        }
    }
}