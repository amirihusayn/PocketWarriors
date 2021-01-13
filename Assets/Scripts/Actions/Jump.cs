using UnityEngine;

public class Jump : ActionPrototype
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
        bool isPerformable = false;
        if(Input.GetKeyDown(inputPrototype.GetKey(InputPrototype.keyTypes.Jump)))
        {
            isPerformable = true;
        }
        return isPerformable;
    }

    protected override bool CheckSpectralOperation(WarriorAction warriorActionChecker)
    {
        InputPrototype inputPrototype = warriorActionChecker.WarriorInput;
        if(Input.GetKeyDown(inputPrototype.GetKey(InputPrototype.keyTypes.Jump))
        && Input.GetKey(inputPrototype.GetKey(InputPrototype.keyTypes.Spectral)))
            return true;
        else
            return false;
    }

    protected override void PerformNormalOperation(WarriorAction warriorActionChecker)
    {
        warriorActionChecker.WarriorRigidBody.velocity = new Vector3(warriorActionChecker.WarriorRigidBody.velocity.x , 0 , warriorActionChecker.WarriorRigidBody.velocity.z);
        warriorActionChecker.WarriorRigidBody.AddForce(Vector3.up * 100);  
    }

    protected override void PerformSpectralOperation(WarriorAction warriorActionChecker)
    {
        // create a projectile on ground that will explode
    }
}