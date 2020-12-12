using UnityEngine;

public class Jump : ActionPrototype
{
    public override void CheckNormalOperation(WarriorInput warriorInput)
    {
        throw new System.NotImplementedException();
    }
    public override void CheckSpectralOperation(WarriorInput warriorInput)
    {
        if(Input.GetKeyDown(warriorInput.GetKey(WarriorInput.keyTypes.Jump)))
            Debug.Log("Jumped !");
    }
}