using UnityEngine;

namespace PocketWarriors
{
    public class Profile : ISavable
    {
        // Fields________________________________________________________
        private string userName;
        private int score;

        // Properties___________________________________________________
        public string UserName { get => userName; set => userName = value; }
        public int Score { get => score; set => score = value; }

        // Constructor_________________________________________________
        public Profile()
        {
            UserName = "NoName Player"; 
            Score = 0; 
        }

        // Methods_____________________________________________________
        public void SavePrefrences()
        {
            PlayerPrefs.SetString("UserName", UserName);
            PlayerPrefs.SetInt("Score", Score);
        }

        public void LoadPrefrences()
        {
            if(PlayerPrefs.HasKey("UserName"))
                UserName = PlayerPrefs.GetString("UserName");
            else
                PlayerPrefs.SetString("UserName", UserName);
            if(PlayerPrefs.HasKey("Score"))
                Score = PlayerPrefs.GetInt("Score");
            else
                PlayerPrefs.SetInt("Score", Score);
        }

        public void RestoreToDefault()
        {
        }
    }
}