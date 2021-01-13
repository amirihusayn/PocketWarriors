using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorRotation : MonoBehaviour
{
    // Fields
    [SerializeField] private Rigidbody warriorRigidBody;
    private float rotationDegree , x;
    private float variableCoordinate;
    private float mouseX;

    // public float MouseX {
    //     get { return mouseX;}
    //     set {
    //         if(Mathf.Abs(value) >= Screen.width/2 -1)
    //         {
    //             mouseX = value - mouseX;
    //             Cursor.lockState = CursorLockMode.Locked;
    //             // mouseX = 0;
    //         }
    //         else
    //             mouseX = value;
    //     }
    // }

    // Properties


    // Methods
    private void Start()
    {
        // Cursor.SetCursor(null , new Vector2(0,0) , CursorMode.Auto);
        variableCoordinate = Screen.width / 2;
        mouseX = Input.mousePosition.x;
    }
    private void Update()
    {
        GetRotation();
    }
    private void FixedUpdate()
    {
        warriorRigidBody.rotation = Quaternion.Euler(warriorRigidBody.rotation.eulerAngles + transform.up * rotationDegree);
        // warriorRigidBody.rotation = Quaternion.Euler(warriorRigidBody.rotation.eulerAngles + Vector3.up * rotationDegree);
        // warriorRigidBody.Move(Quaternion.Euler(0,x,0));
    }

    private void GetRotation()
    {
        rotationDegree = Input.GetAxis("Mouse X") * 200 * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y");







        // MouseX = Input.mousePosition.x;
        // float difference = (MouseX - variableCoordinate);

        // rotationDegree = ( difference / (variableCoordinate) ) * 180;
        // Cursor.lockState = CursorLockMode.None;
        // // variableCoordinate += difference;
        // Debug.Log("Rotation >>   " + rotationDegree);



        // mouseX = Input.mousePosition.x - Screen.width/2;
        // // Debug.Log("MouseX >>   " + mouseX);
        // mouseY = Input.mousePosition.y - Screen.height/2;
        // // Debug.Log("MouseY >>   " + mouseY);
        // rotationDegree = Mathf.Atan2(mouseY , mouseX) * Mathf.Rad2Deg;
        // // rotationDegree -= 90;
    }
}