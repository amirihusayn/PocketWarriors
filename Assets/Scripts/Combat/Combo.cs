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
    [SerializeField] private List<InputPrototype.keyTypes> comboChainList;
    [SerializeField] private float durationTime;
    private string comboString;
    
    // Properties
    public int AnimationIntParameter { get => animationIntParameter; }
    public List<InputPrototype.keyTypes> ComboChainList { get => comboChainList; }
    public float DurationTime { get => durationTime;}
    public string ComboString { get => comboString; set => comboString = value; }
}