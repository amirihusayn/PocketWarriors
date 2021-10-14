using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public class DefaultJoystickInput : InputPrototype
    {
        // Fields________________________________________________________
        private static DefaultJoystickInput instance;

        // Constructor_________________________________________________
        private DefaultJoystickInput()
        {
            Initialize();
        }

        // Properties___________________________________________________
        public static DefaultJoystickInput Instance
        {
            get 
            {
                if(instance == null)
                    instance = new DefaultJoystickInput();
                return instance;
            }
        }

        // Methods_____________________________________________________
        protected override void Initialize()
        {
            // keyDic = new Dictionary<keyTypes, KeyCode>();
            // keyDic.Add(keyTypes.Down , );
            // keyDic.Add(keyTypes.Jump , );
            // keyDic.Add(keyTypes.Left , );
            // keyDic.Add(keyTypes.LeftHandAction , );
            // keyDic.Add(keyTypes.Right , );
            // keyDic.Add(keyTypes.RightHandAction , );
            // keyDic.Add(keyTypes.Run , );
            // keyDic.Add(keyTypes.Scabbard , );
            // keyDic.Add(keyTypes.Sit , );
            // keyDic.Add(keyTypes.Spectral , );
            // keyDic.Add(keyTypes.SwitchAction , );
            // keyDic.Add(keyTypes.SwitchHand , );
            // keyDic.Add(keyTypes.Up , );
        }
    }
}