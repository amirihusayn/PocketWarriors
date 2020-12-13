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
    [SerializeField] private float maxFootSpeed; 
    [SerializeField] private float maxHandSpeed;

    // Properties
    public ComboProfile GetComboProfile { get => comboProfile;}
    public SpectralPower GetSpectralPower { get => spectralPower;}
    public float GetMaxHealth { get => maxHealth;}
    public float GetMaxStamina { get => maxStamina;}
    public float GetMaxPower { get => maxPower;}
    public float GetMaxFootSpeed { get => maxFootSpeed;}
    public float GetMaxHandSpeed { get => maxHandSpeed;}

}
