using UnityEngine;

namespace PocketWarriors
{
    public class Profile : ISavable
    {
        // Fields
        private string userName;
        private int score;

        // Properties
        public string UserName { get => userName; set => userName = value; }
        public int Score { get => score; set => score = value; }

        // Constructor
        public Profile()
        {
            LoadPrefrences(); 
        }

        // Methods
        public void SavePrefrences()
        {
            PlayerPrefs.SetString("UserName", UserName);
            PlayerPrefs.SetInt("Score", Score);
        }

        public void LoadPrefrences()
        {
            UserName = PlayerPrefs.GetString("UserName");
            Score = PlayerPrefs.GetInt("Score");
        }
    }
}