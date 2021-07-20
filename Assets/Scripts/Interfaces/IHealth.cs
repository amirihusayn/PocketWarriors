using UnityEngine;

public interface IHealth<T>
{
    void TakeDamage(Collider other);
}