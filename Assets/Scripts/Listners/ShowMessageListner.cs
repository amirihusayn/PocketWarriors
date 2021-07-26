using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PocketWarriors
{
    public class ShowMessageListner : ListnerPrototype
    {
        // Fields________________________________________________________
        [SerializeField] private GameObject messageObject;

        // Methods_____________________________________________________
        protected override void OnClickListner()
        {
            messageObject.SetActive(true);
        }
    }
}                                                                                           