using UnityEngine;

namespace PocketWarriors
{
    public interface IRotation
    {
        void Initialize();
        void GetInputRotation();
        void Rotate();
    }
}