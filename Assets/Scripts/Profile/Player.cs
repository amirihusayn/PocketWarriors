using UnityEngine;

namespace PocketWarriors
{
    public class Player : MonoBehaviour
    {
        // Fields________________________________________________________
        private Profile profile;
        private Settings settings;

        // Methods_____________________________________________________
        private void Awake() 
        {
            profile = new Profile();  
            settings = new Settings();
        }

        private void OnEnable() 
        {
            LoadProfile();
            LoadSettings();
        }

        public void LoadProfile()
        {
            profile.LoadPrefrences();
        }

        private void OnDisable() 
        {
            SaveProfile();    
        }

        public void SaveProfile()
        {
            profile.SavePrefrences();
        }

        public void LoadSettings()
        {
            settings.LoadPrefrences();
        }

        public void SaveSettings()
        {
            settings.SavePrefrences();
        }
    }
}