using UnityEngine;

namespace PocketWarriors
{
    public interface IHealth<T>
    {
        void TakeDamage(Collider other);
    }
}