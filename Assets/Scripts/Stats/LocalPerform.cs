using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public class LocalPerform : MonoBehaviour, IPerform
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
            requirement.ActionContainer.CheckActions(requirement);
        }

        private void FixedUpdate()
        {
            Perform();
        }

        public void Perform()
        {
            requirement.ActionContainer.PerformActions(requirement);
            requirement.Movement = new Vector3(requirement.Movement.x, 0, requirement.Movement.z);
            requirement.Movement = Vector3.Normalize(requirement.Movement) * requirement.Stats.FootSpeed;
            requirement.RigidBody.velocity = transform.forward * requirement.Movement.z + transform.right * requirement.Movement.x + transform.up * requirement.RigidBody.velocity.y;
        }

        public void CreateProjectile()
        {
        }
    }
}