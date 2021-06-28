using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHold : MonoBehaviour {
    // Fields
    [SerializeField] private Weapon weapon;
    [SerializeField] private float controlRange;
    private Rigidbody rigidbody;
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

    private void Update() 
    {
        ControlTransform();
    }
    
    private void Initialize()
    {
        damage = weapon.Damage;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void ControlTransform()
    {
        bool isShouldResetTransform = transform.localPosition.y > controlRange
    || transform.localPosition.x > controlRange || transform.localPosition.z > controlRange;
        if(isShouldResetTransform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            rigidbody.velocity = Vector3.zero;
        }
    }
}
