using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;


public class ActionContainer
{
    // Fields
    [SerializeField] private List<ActionPrototype> availableActions;
    public event Action<WarriorAction> WarriorActionsChecker;

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
    public void CheckWarriorActions(WarriorAction warriorActionChecker)
    {
        if(WarriorActionsChecker != null)
            WarriorActionsChecker(warriorActionChecker);
    }
    public void PerformWarriorActions(WarriorAction warriorActionChecker)
    {
        foreach(ActionPrototype thisAction in availableActions)
            thisAction.Perform(warriorActionChecker);
    }
}
