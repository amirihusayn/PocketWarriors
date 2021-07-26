using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public abstract class InputPrototype
    {
        // Fields________________________________________________________
        protected Dictionary<keyTypes , KeyCode> keyDic;
        public enum keyTypes
        { 
            RightHandAction, LeftHandAction, SwitchHand, SwitchAction,
            Left, Right, Up, Down, Run, Sit, Jump, Spectral, Scabbard 
        };

        // Methods_____________________________________________________
        public KeyCode GetKey(keyTypes keyType)
        {
            KeyCode key;
            keyDic.TryGetValue(keyType , out key);
            return key;
        }

        public void SetKeyCode(keyTypes keyType , KeyCode keyCode)
        {
            if(keyDic.ContainsKey(keyType))
                keyDic[keyType] = keyCode;
            else
                keyDic.Add(keyType, keyCode);
        }

        public bool ContainsKeyCode(KeyCode keyCode)
        {
            return !keyDic.ContainsValue(keyCode);
        }

        protected abstract void Initialize();
    }
}