using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryInput : InputPrototype
{
    // Constructor
    public PrimaryInput()
    {
        Initialize();
    }

    // Methods
    protected override void Initialize()
    {
        keyDic = new Dictionary<keyTypes, KeyCode>();
        keyDic.Add(keyTypes.Down , KeyCode.S);
        keyDic.Add(keyTypes.Jump , KeyCode.Space);
        keyDic.Add(keyTypes.Left , KeyCode.A);
        keyDic.Add(keyTypes.LeftHandAction , KeyCode.Mouse0);
        keyDic.Add(keyTypes.Right , KeyCode.D);
        keyDic.Add(keyTypes.RightHandAction , KeyCode.Mouse1);
        keyDic.Add(keyTypes.Run , KeyCode.LeftShift);
        keyDic.Add(keyTypes.Scabbard , KeyCode.R);
        keyDic.Add(keyTypes.Sit , KeyCode.LeftControl);
        keyDic.Add(keyTypes.Spectral , KeyCode.E);
        keyDic.Add(keyTypes.SwitchAction , KeyCode.Tab);
        keyDic.Add(keyTypes.SwitchHand , KeyCode.Q);
        keyDic.Add(keyTypes.Up , KeyCode.W);
    }
}