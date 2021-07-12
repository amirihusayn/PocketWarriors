using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHold : MonoBehaviour {
    // Fields
    [SerializeField] private Weapon weapon;
    private float damage;
    private int warriorID;

    // Properties
    public float Damage { get => damage; }
    public int WarriorID { get => warriorID; }

    // Methods
    private void Awake() 
    {
        Initialize();    
    }
    
    private void Initialize()
    {
        damage = weapon.Damage;
        WarriorAction warrior = GetComponentInParent<WarriorAction>();
        if(warrior != null)
            warriorID = warrior.gameObject.GetInstanceID();
    }
}
