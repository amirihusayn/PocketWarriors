using UnityEngine;
public class LocalInputCheck : MonoBehaviour
{
    // Fields
    private ActionContainer actionContainer;
    private InputPrototype warriorInput;

    private void Start() 
    {
        warriorInput = new WarriorInputPC();////////// Initialize it somewhere
        actionContainer = new ActionContainer();
    }
    private void Update() 
    {
        actionContainer.CheckWarriorActions(warriorInput);
    }

}