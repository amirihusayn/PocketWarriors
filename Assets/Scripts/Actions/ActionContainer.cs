using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;


public class ActionContainer
{
    // Fields
    public event Action<WarriorAction> Checker;
    public event Action<WarriorAction> Performer;

    // Constructor
    public ActionContainer()
    {
        Initialize();
    }

    // Methods
    private void Initialize()
    {
        var allActionAssembly = Assembly.GetAssembly(typeof(ActionPrototype));
        var actionTypes = allActionAssembly.GetTypes().Where( 
            thisActionType => typeof(ActionPrototype).IsAssignableFrom(thisActionType) 
            && thisActionType.IsAbstract == false);
        foreach(var thisActionType in actionTypes)
        {
            ActionPrototype action = System.Activator.CreateInstance(thisActionType) as ActionPrototype;
            action.Subscribe(this);
        }
    }

    public void CheckActions(WarriorAction warriorAction)
    {
        if(Checker != null)
            Checker(warriorAction);
    }
    
    public void PerformActions(WarriorAction warriorAction)
    {
        if(Performer != null)
            Performer(warriorAction);
    }
}
