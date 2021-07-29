using UnityEngine;
using UnityEngine.Networking;

namespace PocketWarriors
{
    public class UNet_Jump : ActionPrototype
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
            bool isPerformable = false;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Jump)))
                if(requirement.RigidBody.position.y <= requirement.Stats.JumpLimit)
                    isPerformable = true;
            return isPerformable;
        }

        protected override bool CheckSpectralOperation(ActionRequirement requirement)
        {
            InputPrototype warriorInput = requirement.WarriorInput;
            if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Jump))
            && Input.GetKey(warriorInput.GetKey(InputPrototype.keyTypes.Spectral)))
                return true;
            else
                return false;
        }

        protected override void PerformNormalOperation(ActionRequirement requirement)
        {
            networkAnimator.SetTrigger("OnJump");
            requirement.RigidBody.velocity = new Vector3(requirement.RigidBody.velocity.x , requirement.Stats.JumpSpeed , requirement.RigidBody.velocity.z);
        }

        protected override void PerformSpectralOperation(ActionRequirement requirement)
        {
            networkAnimator.SetTrigger("OnJump");

            // create a projectile on ground that will explode
        }
    }
}