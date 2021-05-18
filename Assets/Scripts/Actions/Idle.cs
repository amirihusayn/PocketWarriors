using UnityEngine;

public class Idle : ActionPrototype
{
    protected override bool CheckNormalOperation(WarriorAction warriorAction)
    {
        InputPrototype warriorInput = warriorAction.WarriorInput;
        bool isStoppedMovingDown = Input.GetKeyUp(warriorInput.GetKey(InputPrototype.keyTypes.Down));
        bool isStoppedMovingUp = Input.GetKeyUp(warriorInput.GetKey(InputPrototype.keyTypes.Up));
        bool isStoppedMovingLeft = Input.GetKeyUp(warriorInput.GetKey(InputPrototype.keyTypes.Left));
        bool isStoppedMovingRight = Input.GetKeyUp(warriorInput.GetKey(InputPrototype.keyTypes.Right));

        if(isStoppedMovingDown)
        {
           warriorAction.Movement = new Vector3(warriorAction.Movement.x , warriorAction.Movement.y , 0 );
        }
        if(isStoppedMovingUp)
        {
           warriorAction.Movement = new Vector3(warriorAction.Movement.x , warriorAction.Movement.y , 0 );
        }
        if(isStoppedMovingLeft)
        {
           warriorAction.Movement = new Vector3(0 , warriorAction.Movement.y , warriorAction.Movement.z );
        }
        if(isStoppedMovingRight)
        {
           warriorAction.Movement = new Vector3(0 , warriorAction.Movement.y , warriorAction.Movement.z );
        }
        return false;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorAction)
    {
        return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorAction)
    {
        warriorAction.WarriorAnimator.SetBool("isWalking" , false);
    }

    protected override void PerformSpectralOperation(WarriorAction warriorAction)
    {
    }
}