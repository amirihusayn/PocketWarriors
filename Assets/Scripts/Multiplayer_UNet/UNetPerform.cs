using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace PocketWarriors
{
    public class UNetPerform : NetworkBehaviour, IPerform
    {
        // Fields________________________________________________________
        [SerializeField] private ActionRequirement requirement;
        [SerializeField] private GameObject cameraPrefab;
        private ActionContainer actionContainer;
        private InputPrototype warriorInput;

        // Properties___________________________________________________
        public ActionRequirement Requirement { get => requirement; }
        
        // Methods_____________________________________________________
        private void Start()
        {
            Initialize();
        }
        public void Initialize()
        {
            if(!isLocalPlayer)
                return;
            actionContainer = new ActionContainer(requirement);
            warriorInput = new CustomeKeyboardInput();
            requirement.ActionContainer = actionContainer;
            requirement.WarriorInput = warriorInput;
            GameObject camera = Instantiate(cameraPrefab, new Vector3(0, 15, -18), Quaternion.Euler(30, 0, 0));
            camera.transform.SetParent(gameObject.transform);
        }

        private void Update()
        {
            Check();        
        }

        public void Check()
        {
            if(!isLocalPlayer)
                return;
            requirement.ActionContainer.CheckActions(requirement);
        }

        private void FixedUpdate()
        {
            Perform();  
        }

        public void Perform()
        {
            if(!isLocalPlayer)
                return;
            requirement.ActionContainer.PerformActions(requirement);
            requirement.Movement = new Vector3(requirement.Movement.x, 0, requirement.Movement.z);
            requirement.Movement = Vector3.Normalize(requirement.Movement) * requirement.Stats.FootSpeed;
            requirement.RigidBody.velocity = transform.forward * requirement.Movement.z + transform.right * requirement.Movement.x + transform.up * requirement.RigidBody.velocity.y;
        }

        [Command]
        private void CmdCreateProjectile()
        {
            if(!isLocalPlayer)
                return;
            // Instantiate projectile
            // NetworkServer.Spawn()
        }
    }
}