using UnityEngine;

namespace PocketWarriors
{
    public class Settings : ISavable
    {
        // Fields________________________________________________________
        private CustomeKeyboardInput customInput;
        // resolutions, quality and sound option fields here

        // Constructor_________________________________________________
        public Settings()
        {
            customInput = new PocketWarriors.CustomeKeyboardInput();
        }

        // Properties___________________________________________________
        public CustomeKeyboardInput CustomeInput { get => customInput; set => customInput = value; }

        // Methods_____________________________________________________
        public void SavePrefrences()
        {
        }

        public void LoadPrefrences()
        {
            // if(PlayerPrefs.HasKey)
        }

        public void RestoreToDefault()
        {
            
        }
    }
}