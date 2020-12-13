using UnityEngine;

public class Jump : ActionPrototype
{
    public override void CheckNormalOperation(InputPrototype warriorInput)
    {
        throw new System.NotImplementedException();
    }
    public override void CheckSpectralOperation(InputPrototype warriorInput)
    {
        if(Input.GetKeyDown(warriorInput.GetKey(InputPrototype.keyTypes.Jump)))
            Debug.Log("Jumped !");
    }
}