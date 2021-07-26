using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PocketWarriors
{
    public class ReadInputListner : ListnerPrototype
    {
        // Fields________________________________________________________
        [SerializeField] private Control control;
        private KeyCode keyCode;
        private bool isFound;

        // Methods_____________________________________________________
        protected override void OnClickListner()
        {
            control.ControlText.text = "Please enter a key";
            StopAllCoroutines();
            StartCoroutine("ReadInput");
        }

        private IEnumerator ReadInput()
        {
            while(!isFound && !Input.GetKey(KeyCode.Escape))
            {
                foreach(KeyCode thisKeyCode in typeof(KeyCode).GetEnumValues())
                {
                    if(Input.GetKey(thisKeyCode) && thisKeyCode != KeyCode.Escape)
                    {
                        keyCode = thisKeyCode;
                        isFound = true;
                        break;
                    }
                }
                yield return null;
            }
            if(isFound)
            {
                control.SetControl(control.KeyType, keyCode);
                ControlsInfoUpdate.Instance.SetNotAssignedKeys(control);
                isFound = false;
            }
        }
    }
}                                                                                           