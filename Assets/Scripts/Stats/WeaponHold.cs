using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public class WeaponHold : MonoBehaviour {
        // Fields________________________________________________________
        [SerializeField] private Weapon weapon;
        private float damage;
        private int warriorID;

        // Properties___________________________________________________
        public float Damage { get => damage; }
        public int WarriorID { get => warriorID; }

        // Methods_____________________________________________________
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
}
