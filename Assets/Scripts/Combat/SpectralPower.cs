using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSpectralPower", menuName = "PocketWarriors/SpectralPower", order = 1)]
public class SpectralPower : ScriptableObject 
{
    // Fields________________________________________________________
    [SerializeField] private string name;
    [SerializeField] private float powerCost;
    [SerializeField] private float range;
    [SerializeField] private MeshFilter projectileMesh;
    [SerializeField] private MeshFilter directPowerMesh;

    // Properties___________________________________________________
    public float PowerCost { get => powerCost;}
    public float Range { get => range;}
}
