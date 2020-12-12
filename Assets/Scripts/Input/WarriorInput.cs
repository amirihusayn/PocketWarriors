using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WarriorInput 
{
    // Fields
    protected Dictionary<keyTypes , KeyCode> keyDic;
    public enum keyTypes
    { 
        RightHandAction,LeftHandAction,SwitchHand,SwitchAction,
        Left,Right,Up,Down,Run,Sit,Jump,Spectral,Scabbard 
    };

    // Methods
    public KeyCode GetKey(keyTypes keyType)
    {
        KeyCode key;
        keyDic.TryGetValue(keyType , out key);
        return key;
    }
    public void SetKey(keyTypes keyType , KeyCode keyCode)
    {
        if(!keyDic.ContainsKey(keyType))
            throw new System.Exception("Key not found !");
        else
            keyDic[keyType] = keyCode;
    }
    protected abstract void Initialize();
}