using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    [CreateAssetMenu(fileName = "NewWarriorStats", 
    menuName = "PocketWarriors/WarriorStats", order = 0)]
    public class WarriorStats : ScriptableObject
    {
        // Fields________________________________________________________
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

        // Properties___________________________________________________
        public ComboProfile ComboProfile { get => comboProfile; }
        public SpectralPower SpectralPower { get => spectralPower; }
        public float MaxHealth { get => maxHealth; }
        public float MaxStamina { get => maxStamina; }
        public float MaxPower { get => maxPower; }
        public float FootSpeed { get => footSpeed; }
        public float JumpSpeed { get => jumpSpeed; }
        public float JumpLimit { get => jumpLimit; }
        public float HandSpeed { get => handSpeed; }
        public float RotationSpeed { get => rotationSpeed; }
    }
}
