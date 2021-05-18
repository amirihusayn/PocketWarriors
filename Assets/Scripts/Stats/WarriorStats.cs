using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewWarriorStats", 
menuName = "PocketWarriors/WarriorStats", order = 0)]
public class WarriorStats : ScriptableObject
{
    // Fields
    [SerializeField] private string name;
    [SerializeField] private ComboProfile comboProfile;
    [SerializeField] private SpectralPower spectralPower;
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxStamina;
    [SerializeField] private float maxPower;
    [SerializeField] private float footSpeed; 
    [SerializeField] private float jumpSpeed; 
    [SerializeField] private float jumpLimit;
    [SerializeField] private float handSpeed;
    [SerializeField] private float rotationSpeed;

    // Properties
    public ComboProfile ComboProfile
    {
        get
        {
            return comboProfile;
        }
    }

    public SpectralPower SpectralPower
    {
        get
        {
            return spectralPower;
        }
    }

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public float MaxStamina
    {
        get
        {
            return maxStamina;
        }
    }

    public float MaxPower
    {
        get
        {
            return maxPower;
        }
    }

    public float FootSpeed
    {
        get
        {
            return footSpeed;
        }
    }

    public float JumpSpeed
    {
        get
        {
            return jumpSpeed;
        }
    }

    public float JumpLimit
    {
        get
        {
            return jumpLimit;
        }
    }

    public float HandSpeed
    {
        get
        {
            return handSpeed;
        }
    }

    public float RotationSpeed
    {
        get
        {
            return rotationSpeed;
        }
    }
}
