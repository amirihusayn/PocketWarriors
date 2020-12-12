using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Combo
{
    // Fields
    [SerializeField] private string name;
    [SerializeField] private int animationIntParameter;
    [SerializeField] private List<ActionPrototype> comboChainList;
    [SerializeField] private float durationTime;
    
    // Properties
    public int GetAnimationIntParameter { get => animationIntParameter;}
    public List<ActionPrototype> GetComboChainList { get => comboChainList;}
    public float GetDurationTime { get => durationTime;}
}