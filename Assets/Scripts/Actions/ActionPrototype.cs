using System;
using UnityEngine;

public abstract class ActionPrototype 
{
    // Fields
    protected static string animationTriggerName;
    
    // Methods
    public void Subscribe(ActionContainer targetActionChecker)
    {
        targetActionChecker.WarriorActionsChecker += CheckSpectralOperation;
    }
    public abstract void CheckNormalOperation(WarriorInput warriorInput);
        /// get warrior animator
        /// get warrior
        /// animation set trigger /// and multiply by animationSpeed(Setfloat = animationSpeed)
    public abstract void CheckSpectralOperation(WarriorInput warriorInput);
    /// get warrior animator
    /// animation set trigger /// and multiply by animationSpeed(Setfloat = animationSpeed)
    /// create for exmaple spectral projectile
}