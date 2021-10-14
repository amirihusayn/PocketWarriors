using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public class CustomeJoystickInput : InputPrototype, ISavable
    {
        // Constructor_________________________________________________
        public CustomeJoystickInput()
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
            foreach(InputPrototype.keyTypes thisKeyType in typeof(InputPrototype.keyTypes).GetEnumValues())
                SaveKey(thisKeyType, (int)GetKey(thisKeyType));
        }

        private void SaveKey(keyTypes thisKeyType, int keyCodeNumber)
        {
            PlayerPrefs.SetInt(thisKeyType.ToString(), keyCodeNumber);
        }

        public void LoadPrefrences()
        {
            int keyCodeNumber;
            foreach(InputPrototype.keyTypes thisKeyType in typeof(InputPrototype.keyTypes).GetEnumValues())
            {
                if(PlayerPrefs.HasKey(thisKeyType.ToString()))
                    keyCodeNumber = PlayerPrefs.GetInt(thisKeyType.ToString());
                else
                {
                    keyCodeNumber = (int)(DefaultJoystickInput.Instance.GetKey(thisKeyType));
                    SaveKey(thisKeyType, keyCodeNumber);
                }
                SetKeyCode(thisKeyType, (KeyCode)keyCodeNumber);
            }
        }

        public void RestoreToDefault()
        {
            int keyCodeNumber;
            foreach(InputPrototype.keyTypes thisKeyType in typeof(InputPrototype.keyTypes).GetEnumValues())
            {
                keyCodeNumber = (int)(DefaultKeyboardInput.Instance.GetKey(thisKeyType));
                SaveKey(thisKeyType, keyCodeNumber);
                SetKeyCode(thisKeyType, (KeyCode)keyCodeNumber);
            }
        }
    }
}