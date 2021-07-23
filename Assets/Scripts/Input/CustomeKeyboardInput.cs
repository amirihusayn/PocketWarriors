using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors 
{
    public class CustomeKeyboardInput : InputPrototype, ISavable
    {
        // Constructor
        public CustomeKeyboardInput()
        {
            Initialize();
        }

        // Methods_____________________________________________________
        protected override void Initialize()
        {
            keyDic = new Dictionary<keyTypes, KeyCode>();
            LoadPrefrences();
        }

        public void SavePrefrences()
        {
            int keyCodeNumber;
            foreach(InputPrototype.keyTypes thisKeyType in typeof(InputPrototype.keyTypes).GetEnumValues())
            {
                keyCodeNumber = (int)GetKey(thisKeyType);
                PlayerPrefs.SetInt(thisKeyType.ToString(), keyCodeNumber);
            }
        }

        public void LoadPrefrences()
        {
            int keyCodeNumber;
            foreach(InputPrototype.keyTypes thisKeyType in typeof(InputPrototype.keyTypes).GetEnumValues())
            {
                keyCodeNumber = PlayerPrefs.GetInt(thisKeyType.ToString());
                SetKeyCode(thisKeyType, (KeyCode)keyCodeNumber);
            }
        }
    }
}