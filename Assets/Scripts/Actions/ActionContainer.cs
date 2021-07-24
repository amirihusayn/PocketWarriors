using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PocketWarriors
{
    public class ActionContainer
    {
        // Fields________________________________________________________
        private Dictionary<Type, ActionPrototype> actionDictionary;
        public event Action<WarriorAction> Checker;
        public event Action<WarriorAction> Performer;

        // Properties___________________________________________________
        public Dictionary<Type, ActionPrototype> ActionDictionary { get => actionDictionary; }

        // Constructor
        public ActionContainer(WarriorAction warriorAction)
        {
            Initialize(warriorAction);
        }

        // Methods_____________________________________________________
        private void Initialize(WarriorAction warriorAction)
        {
            actionDictionary = new Dictionary<Type, ActionPrototype>();
            var allActionAssembly = Assembly.GetAssembly(typeof(ActionPrototype));
            var actionTypes = allActionAssembly.GetTypes().Where( 
                thisActionType => typeof(ActionPrototype).IsAssignableFrom(thisActionType) 
                && thisActionType.IsAbstract == false);
            foreach(var thisActionType in actionTypes)
            {
                ActionPrototype action = System.Activator.CreateInstance(thisActionType) as ActionPrototype;
                if(action.IsSubscribable)
                {
                    actionDictionary.Add(thisActionType, action);
                    action.Subscribe(this, warriorAction);
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
}
