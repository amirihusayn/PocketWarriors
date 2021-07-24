using UnityEngine;

namespace PocketWarriors
{
    public class Sit : ActionPrototype
    {
        // Properties___________________________________________________
        public override bool IsSubscribable { get => true;}

        // Methods_____________________________________________________
        protected override bool CheckNormalOperation(WarriorAction warriorAction)
        {
            InputPrototype warriorInput = warriorAction.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Sit)))
                return true;
            else
                return false;
        }

        protected override bool CheckSpectralOperation(WarriorAction warriorAction)
        {
            InputPrototype warriorInput = warriorAction.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Sit))
            && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
                return true;
            else
                return false;
        }

        protected override void PerformNormalOperation(WarriorAction warriorAction)
        {
            warriorAction.WarriorAnimator.SetBool("isSit" , true);
        }

        protected override void PerformSpectralOperation(WarriorAction warriorAction)
        {
            // 
        }
    }
}