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
        public event Action<ActionRequirement> Checker;
        public event Action<ActionRequirement> Performer;

        // Properties___________________________________________________
        public Dictionary<Type, ActionPrototype> ActionDictionary { get => actionDictionary; }

        // Constructor_________________________________________________
        public ActionContainer(ActionRequirement requirement)
        {
            Initialize(requirement);
        }

        // Methods_____________________________________________________
        private void Initialize(ActionRequirement requirement)
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
                    action.Subscribe(this, requirement);
                }
            }
        }

        public void CheckActions(ActionRequirement requirement)
        {
            if(Checker != null)
                Checker(requirement);
        }
        
        public void PerformActions(ActionRequirement requirement)
        {
            if(Performer != null)
                Performer(requirement);
        }
    }
}
