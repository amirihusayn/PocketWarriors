using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public class LocalRotation : MonoBehaviour, IRotation
    {
        // Fields________________________________________________________
        [SerializeField] private WarriorStats stats;
        [SerializeField] private Rigidbody warriorRigidBody;
        private short rotationDegree;
        private float rotationSpeed;

        // Methods_____________________________________________________
        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
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
            rotationDegree = (short)(Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            Rotate();
        }

        public void Rotate()
        {
            Vector3 eular = warriorRigidBody.rotation.eulerAngles + transform.up * rotationDegree;
            warriorRigidBody.MoveRotation(Quaternion.Euler(eular));
        }
    }
}