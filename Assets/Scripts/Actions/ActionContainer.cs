using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


public class ActionContainer
{
    // Fields
    private Dictionary<Type, ActionPrototype> actionDictionary;
    public event Action<WarriorAction> Checker;
    public event Action<WarriorAction> Performer;

    // Properties
    public Dictionary<Type, ActionPrototype> ActionDictionary { get => actionDictionary; }

    // Constructor
    public ActionContainer()
    {
        Initialize();
    }

    // Methods
    private void Initialize()
    {
        actionDictionary = new Dictionary<Type, ActionPrototype>();
        var allActionAssembly = Assembly.GetAssembly(typeof(ActionPrototype));
        var actionTypes = allActionAssembly.GetTypes().Where( 
            thisActionType => typeof(ActionPrototype).IsAssignableFrom(thisActionType) 
            && thisActionType.IsAbstract == false);
        foreach(var thisActionType in actionTypes)
        {
            ActionPrototype action = System.Activator.CreateInstance(thisActionType) as ActionPrototype;
            if(action.isSubscribable)
            {
                actionDictionary.Add(thisActionType, action);
                action.Subscribe(this);
            }
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
