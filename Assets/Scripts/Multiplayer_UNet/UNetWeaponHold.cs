using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(WeaponHold))]
public class UNetWeaponHold : NetworkBehaviour {
	private WeaponHold weaponHold;

	private void Awake() {
		weaponHold = GetComponent<WeaponHold>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
