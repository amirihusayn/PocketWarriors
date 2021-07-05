using UnityEngine;

public class ExitListner : ListnerPrototype
{
    // Methods
    protected override void OnClickListner()
    {
        Application.Quit();
    }
}