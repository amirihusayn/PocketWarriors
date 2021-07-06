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
    public string Name { get => name; }
    public float Damage { get => damage; }
    public float Range { get => range; }
    public float Weight { get => weight; }
    public float StaminaCost { get => staminaCost; }
    public MeshFilter MeshFilter { get => meshFilter; }
}
