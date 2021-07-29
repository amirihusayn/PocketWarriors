using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace PocketWarriors
{
    public class UNetRotation : NetworkBehaviour, IRotation
    {
          // Fields________________________________________________________
        [SerializeField] private WarriorStats stats;
        [SerializeField] private Rigidbody warriorRigidBody;
        private float rotationDegree, rotationSpeed;

        // Methods_____________________________________________________
        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (!isLocalPlayer)
                return;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            rotationSpeed = stats.RotationSpeed;
        }

        private void Update()
        {
            GetInputRotation();
        }

        public void GetInputRotation()
        {
            if (!isLocalPlayer)
                return;
            rotationDegree = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            Rotate();
        }

        public void Rotate()
        {
            if (!isLocalPlayer)
                return;
            Vector3 eular = warriorRigidBody.rotation.eulerAngles + transform.up * rotationDegree;
            warriorRigidBody.MoveRotation(Quaternion.Euler(eular));
        }
    }
}
