using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo
{
    // Fields
    [SerializeField] private string name;
    [SerializeField] private int animationIntParameter;
    [SerializeField] private List<ActionPrototype> comboChainList;
    [SerializeField] private float durationTime;
    
    // Properties
    public int AnimationIntParameter { get => animationIntParameter; }
    public List<ActionPrototype> ComboChainList { get => comboChainList; }
    public float DurationTime { get => durationTime;}
}