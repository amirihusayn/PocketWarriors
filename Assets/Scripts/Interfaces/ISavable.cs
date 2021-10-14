using UnityEngine;

namespace PocketWarriors
{
    public interface ISavable
    {
        void SavePrefrences();
        void LoadPrefrences();
        void RestoreToDefault();
    }
}