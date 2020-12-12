using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ActionContainer
{
    // Fields
    private List<ActionPrototype> availableActions;
    public event Action<WarriorInput> WarriorActionsChecker;

    // Constructor
    public ActionContainer()
    {
        InitializeActions();
    }

    // Methods
    private void InitializeActions()
    {
        availableActions = new List<ActionPrototype>();
        var allActionAssembly = Assembly.GetAssembly(typeof(ActionPrototype));
        var actionTypes = allActionAssembly.GetTypes().Where( 
            thisActionType => typeof(ActionPrototype).IsAssignableFrom(thisActionType) 
            && thisActionType.IsAbstract == false);
        foreach(var thisActionType in actionTypes)
        {
            ActionPrototype action = System.Activator.CreateInstance(thisActionType) as ActionPrototype;
            availableActions.Add(action);
            action.Subscribe(this);
        }
    }
    public void CheckWarriorActions(WarriorInput warriorInput)
    {
        if(WarriorActionsChecker != null)
            WarriorActionsChecker(warriorInput);
    }
}
