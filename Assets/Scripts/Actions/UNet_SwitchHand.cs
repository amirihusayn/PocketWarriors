using UnityEngine;
using UnityEngine.Networking;

namespace PocketWarriors
{
    public class UNet_SwitchHand : ActionPrototype
    {
        // Fields________________________________________________________
        private NetworkAnimator networkAnimator;
        private bool isNetworkAnimatorInitialized;

        // Properties___________________________________________________
        public override bool IsSubscribable { get => !GameController.Instance.IsGameLocal;}

        // Methods_____________________________________________________
        public override void Check(ActionRequirement requirement)
        {
            InitializeNetworkAnimator(requirement);
            base.Check(requirement);
        }

        private void InitializeNetworkAnimator(ActionRequirement requirement)
        {
            if(isNetworkAnimatorInitialized)
                return;
            networkAnimator = requirement.RigidBody.GetComponent<NetworkAnimator>();
        }

        protected override bool CheckNormalOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.SwitchHand)))
                return true;
            else
                return false;
        }

        protected override bool CheckSpectralOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.SwitchHand))
            && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
                return true;
            else
                return false;
        }

        protected override void PerformNormalOperation(ActionRequirement requirement)
        {
            networkAnimator.SetTrigger("OnSwitchHand");
        }

        protected override void PerformSpectralOperation(ActionRequirement requirement)
        {
            // 
        }
    }
}