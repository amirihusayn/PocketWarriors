using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSpectralPower", menuName = "PocketWarriors/SpectralPower", order = 1)]
public class SpectralPower : ScriptableObject 
{
    // Fields
    [SerializeField] private string name;
    [SerializeField] private float powerCost;
    [SerializeField] private float range;

    // Properties
    public float GetPowerCost { get => powerCost;}
    public float GetRange { get => range;}
}