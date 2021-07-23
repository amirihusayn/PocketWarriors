using UnityEngine;

namespace PocketWarriors
{
    public class Settings : ISavable
    {
        // Fields
        private CustomeKeyboardInput customInput;
        // resolutions, quality and sound option fields here

        // Constructor
        public Settings()
        {
            customInput = new PocketWarriors.CustomeKeyboardInput();
            LoadPrefrences();
        }

        // Properties
        public CustomeKeyboardInput CustomeInput { get => customInput; set => customInput = value; }

        // Methods
        public void SavePrefrences()
        {
        }

        public void LoadPrefrences()
        {
        }
    }
}