using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCheck : MonoBehaviour 
{
    // Fields________________________________________________________
    private int keysCount, maxComboLength;
    private float durationTime;
    private string comboString; 
    private ComboProfile comboProfile;
    [SerializeField] private WarriorAction warriorAction;

    // Methods_____________________________________________________
    private void Awake()
    {
        Initialize();
    }

    private void Update() 
    {
        CheckInput();    
    }

    private void Initialize()
    {
        comboString = string.Empty;
        keysCount = typeof(InputPrototype.keyTypes).GetEnumValues().Length;
        comboProfile = warriorAction.Stats.ComboProfile;
        GenerateComboStrings();
        foreach(Combo combo in comboProfile.ComboList)
            if(maxComboLength < combo.ComboString.Length)
                maxComboLength = combo.ComboString.Length;
    }

    private void GenerateComboStrings()
    {
        foreach(Combo combo in comboProfile.ComboList)
            foreach(InputPrototype.keyTypes key in combo.ComboChainList)
                combo.ComboString = ((int) key).ToString();
    }

    private void CheckInput()
    {
        InputPrototype input = warriorAction.WarriorInput;
        InputPrototype.keyTypes key;
        KeyCode keyCode;
        for(int index = 0; index < keysCount; index++)
        {
            key = (InputPrototype.keyTypes)(index);
            keyCode = input.GetKey(key);
            if(Input.GetKeyDown(keyCode))
            {
                comboString += ((int) key).ToString();
                UpdateTime();
                CheckCombo();
            }
        }
    }

    private void CheckCombo()
    {
        if(comboString.Length > maxComboLength)
        {
            ResetCheckProcess();
            return;
        }
        Combo comboToPerfom = null;
        foreach(Combo combo in comboProfile.ComboList)
            if(combo.ComboString == comboString && durationTime <= combo.DurationTime)
                comboToPerfom = combo;
        if(comboToPerfom != null)
        {
            warriorAction.WarriorAnimator.Play(comboToPerfom.AnimationIntParameter);
            ResetCheckProcess();
        }
    }

    private void ResetCheckProcess()
    {
        durationTime = 0;
        comboString = string.Empty;
    }

    private void UpdateTime()
    {
    }
}
