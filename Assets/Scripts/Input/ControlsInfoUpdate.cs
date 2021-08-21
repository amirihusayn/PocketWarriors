using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PocketWarriors
{
    public class ControlsInfoUpdate : singleton<ControlsInfoUpdate>
    {
        // Fields________________________________________________________
        [SerializeField] private GameObject ControlPrefab;
        [SerializeField] private RectTransform panelRectTransform;
        private List<Control> controlsList;
        private Settings settings;
        private bool isInfoInitialized;

        // Methods_____________________________________________________
        private void OnEnable() 
        {
            if(!isInfoInitialized)
                InitializeControlsInfo();
            else
                UpdateControlsInfo();   
        }

        private void InitializeControlsInfo()
        {
            GameObject thisControlObject;
            Control thisControl;
            KeyCode thisKeyCode;
            controlsList = new List<Control>();
            settings = new Settings();
            settings.LoadPrefrences();
            foreach (InputPrototype.keyTypes thisKeyType in typeof(InputPrototype.keyTypes).GetEnumValues())
            {
                thisControlObject = Instantiate(ControlPrefab, panelRectTransform);
                thisControl = thisControlObject.GetComponent<Control>();
                controlsList.Add(thisControl);
                thisKeyCode = settings.CustomeInput.GetKey(thisKeyType);
                thisControl.SetControl(thisKeyType, thisKeyCode);
            }
            isInfoInitialized = true;
        }

        private void UpdateControlsInfo()
        {
            Control thisControl;
            KeyCode thisKeyCode;
            int controlsIndex = 0;
            settings = new Settings();
            settings.LoadPrefrences();
            foreach (InputPrototype.keyTypes thisKeyType in typeof(InputPrototype.keyTypes).GetEnumValues())
            {
                thisControl = controlsList[controlsIndex];
                thisKeyCode = settings.CustomeInput.GetKey(thisKeyType);
                thisControl.SetControl(thisKeyType, thisKeyCode);
                controlsIndex ++;
            }
        }

        private void OnDisable() 
        {
            SaveControlsInfo();    
        }

        public void SaveControlsInfo()
        {
            foreach (Control thisControl in controlsList)
                if (thisControl.IsEdited)
                {
                    thisControl.IsEdited = false;
                    PlayerPrefs.SetInt(thisControl.KeyType.ToString(), (int)thisControl.KeyCode);
                }
        }

        public void SetNotAssignedKeys(Control editedControl)
        {
            List<Control> repeatedControlsList = new List<Control>();
            foreach (Control thisControl in controlsList)
                if (editedControl.KeyCode == thisControl.KeyCode && thisControl != editedControl)
                    repeatedControlsList.Add(thisControl);
            foreach(Control thisControl in repeatedControlsList)
            {
                thisControl.SetControl(thisControl.KeyType, KeyCode.None);
                PlayerPrefs.SetInt(thisControl.KeyType.ToString(), (int)thisControl.KeyCode);
            }
        }

        public void RestoreToDefault()
        {
            settings = new Settings();
            settings.CustomeInput.RestoreToDefault();
            UpdateControlsInfo();
        }
    }
}
