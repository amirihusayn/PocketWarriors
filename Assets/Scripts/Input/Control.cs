using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PocketWarriors
{
    public class Control : MonoBehaviour
    {
        // Fields________________________________________________________
        [SerializeField] private Text controlText;
        private InputPrototype.keyTypes keyType;
        private KeyCode keyCode;
        private bool isEdited;

        // Properties___________________________________________________
        public InputPrototype.keyTypes KeyType { get => keyType; }
        public KeyCode KeyCode { get => keyCode; }
        public Text ControlText { get => controlText; }
        public bool IsEdited { get => isEdited; set => isEdited = value; }

        // Methods_____________________________________________________
        public void SetControl(InputPrototype.keyTypes keyType, KeyCode keyCode)
        {
            string textString;
            this.keyCode = keyCode;
            this.keyType = keyType;
            if(keyCode == KeyCode.None)
                textString = keyType.ToString() + "   is not assigned !";
            else
                textString = keyType.ToString() + "   with   " + keyCode.ToString();
            controlText.text = textString;
            isEdited = true;
        }
    }
}
