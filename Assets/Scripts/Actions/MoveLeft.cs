using UnityEngine;

public class MoveLeft : ActionPrototype
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
        bool isPerformable = false;
        InputPrototype inputPrototype = warriorActionChecker.WarriorInput;
        if(Input.GetKey(inputPrototype.GetKey(InputPrototype.keyTypes.Left)))
        {
           warriorActionChecker.Movement = new Vector3(warriorActionChecker.Movement.x - Time.deltaTime , warriorActionChecker.Movement.y , warriorActionChecker.Movement.z);
           isPerformable = true;
        }
        return isPerformable;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorActionChecker)
    {
        InputPrototype inputPrototype = warriorActionChecker.WarriorInput;
        if(Input.GetKey(inputPrototype.GetKey(InputPrototype.keyTypes.Left))
        && Input.GetKey(inputPrototype.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorActionChecker)
    {
        warriorActionChecker.WarriorAnimator.SetBool("isWalking" , true);
    }

    protected override void PerformSpectralOperation(WarriorAction warriorActionChecker)
    {
        // 
    }
}