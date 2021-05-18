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
    [SerializeField] private MeshFilter projectileMesh;
    [SerializeField] private MeshFilter directPowerMesh;

    // Properties
    public float PowerCost
    {
        get
        {
            return powerCost;
        }
    }

    public float Range
    {
        get
        {
            return range;
        }
    }
}
