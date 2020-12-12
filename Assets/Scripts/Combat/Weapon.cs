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
    public float GetDamage { get => damage;}
    public float GetRange { get => range;}
    public float GetWeight { get => weight;}
    public float GetStaminaCost { get => staminaCost;}
    public MeshFilter GetMeshFilter { get => meshFilter;}
}
