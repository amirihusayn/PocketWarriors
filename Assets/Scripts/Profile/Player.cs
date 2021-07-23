using UnityEngine;

namespace PocketWarriors
{
    public class Player : MonoBehaviour
    {
        // Fields
        private Profile profile;
        private Settings settings;

        // Methods
        private void Awake() 
        {
            profile = new Profile();  
            settings = new Settings();
        }

        private void OnDisable() 
        {
            SaveProfile();    
        }

        public void SaveProfile()
        {
            profile.SavePrefrences();
        }

        public void SaveSettings()
        {
            settings.SavePrefrences();
        }
    }
}