using UnityEngine;

public class ExitListner : ListnerPrototype
{
    // Methods_____________________________________________________
    protected override void OnClickListner()
    {
        Application.Quit();
    }
}