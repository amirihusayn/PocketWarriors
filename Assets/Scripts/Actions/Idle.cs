using UnityEngine;

public class Idle : ActionPrototype
{
    public override void Check(WarriorAction warriorActionChecker)
    {
        isNormalOperation = CheckNormalOperation(warriorActionChecker);
        isSpectralOperation = CheckSpectralOperation(warriorActionChecker);
    }

    public override void Perform(WarriorAction warriorActionChecker)
    {
        if(isSpectralOperation)
            PerformSpectralOperation(warriorActionChecker);
        else if(isNormalOperation)
            PerformNormalOperation(warriorActionChecker);
        isNormalOperation = false;
        isSpectralOperation = false;
    }

    protected override bool CheckNormalOperation(WarriorAction warriorActionChecker)
    {
        InputPrototype inputPrototype = warriorActionChecker.WarriorInput;
        bool isStoppedMovingDown = Input.GetKeyUp(inputPrototype.GetKey(InputPrototype.keyTypes.Down));
        bool isStoppedMovingUp = Input.GetKeyUp(inputPrototype.GetKey(InputPrototype.keyTypes.Up));
        bool isStoppedMovingLeft = Input.GetKeyUp(inputPrototype.GetKey(InputPrototype.keyTypes.Left));
        bool isStoppedMovingRight = Input.GetKeyUp(inputPrototype.GetKey(InputPrototype.keyTypes.Right));

        if(isStoppedMovingDown)
        {
           warriorActionChecker.Movement = new Vector3(warriorActionChecker.Movement.x , warriorActionChecker.Movement.y , 0 );
        }
        if(isStoppedMovingUp)
        {
           warriorActionChecker.Movement = new Vector3(warriorActionChecker.Movement.x , warriorActionChecker.Movement.y , 0 );
        }
        if(isStoppedMovingLeft)
        {
           warriorActionChecker.Movement = new Vector3(0 , warriorActionChecker.Movement.y , warriorActionChecker.Movement.z );
        }
        if(isStoppedMovingRight)
        {
           warriorActionChecker.Movement = new Vector3(0 , warriorActionChecker.Movement.y , warriorActionChecker.Movement.z );
        }

        // if(isStoppedMovingDown && isStoppedMovingUp)
        // {
        //    warriorActionChecker.Movement = new Vector3(warriorActionChecker.Movement.x , warriorActionChecker.Movement.y , 0 );
        // }
        // if(isStoppedMovingLeft && isStoppedMovingRight)
        // {
        //    warriorActionChecker.Movement = new Vector3(0 , warriorActionChecker.Movement.y , warriorActionChecker.Movement.z );
        // }

        return false;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorActionChecker)
    {
        // InputPrototype inputPrototype = warriorActionChecker.WarriorInput;
        // if(Input.GetKey(inputPrototype.GetKey(InputPrototype.keyTypes.Down))
        // && Input.GetKey(inputPrototype.GetKey(InputPrototype.keyTypes.Spectral)))
        //     return true;
        // else
        //     return false;
        return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorActionChecker)
    {
        warriorActionChecker.WarriorAnimator.SetBool("isWalking" , false);
    }

    protected override void PerformSpectralOperation(WarriorAction warriorActionChecker)
    {
        // 
    }
}