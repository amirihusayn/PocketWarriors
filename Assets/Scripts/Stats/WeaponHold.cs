using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHold : MonoBehaviour {
    // Fields
    [SerializeField] private Weapon weapon;
    private float damage;

    // Properties
    public float Damage
    {
        get
        {
            return damage;
        }
    }

    // Methods
    private void Awake() 
    {
        Initialize();    
    }
    
    private void Initialize()
    {
        damage = weapon.Damage;
    }
}
