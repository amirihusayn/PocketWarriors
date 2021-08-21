using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PocketWarriors
{
    public class RestoreInputListner : ListnerPrototype
    {
        // Methods_____________________________________________________
        protected override void OnClickListner()
        {
            ControlsInfoUpdate.Instance.RestoreToDefault();
        }
    }
}                                                                                           