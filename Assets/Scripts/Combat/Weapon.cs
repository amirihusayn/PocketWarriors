using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewWeapon", menuName = "PocketWarriors/Weapon", order = 2)]
public class Weapon : ScriptableObject 
{
    // Fields
    [SerializeField] private string name;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float weight;
    [SerializeField] private float staminaCost;
    [SerializeField] private MeshFilter meshFilter;

    // Properties

    public float Damage
    {
        get
        {
            return damage;
        }
    }

    public float Range
    {
        get
        {
            return range;
        }
    }

    public float Weight
    {
        get
        {
            return weight;
        }
    }

    public float StaminaCost
    {
        get
        {
            return staminaCost;
        }
    }

    public MeshFilter MeshFilter
    {
        get
        {
            return meshFilter;
        }
    }
}
