using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorRotation : MonoBehaviour
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private Rigidbody warriorRigidBody;
    private float rotationDegree, rotationSpeed;

    // Methods
    private void Start()
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        Initialize();
    }

    private void Update()
    {
        if(!GameController.Instance.IsGameLocal)
            return;        
        GetInputRotation();
    }

    private void FixedUpdate()
    {
        if(!GameController.Instance.IsGameLocal)
            return;
        Rotate();
    }

    public void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rotationSpeed = stats.RotationSpeed;
    }

    public void GetInputRotation()
    {
        rotationDegree = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
    }
    
    public void Rotate()
    {
        Vector3 eular = warriorRigidBody.rotation.eulerAngles + transform.up * rotationDegree;
        warriorRigidBody.MoveRotation(Quaternion.Euler(eular));
    }
}