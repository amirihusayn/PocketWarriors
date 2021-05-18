using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(WarriorRotation))]
public class UNetWarriorRotation : NetworkBehaviour
{
	// Fields
    private WarriorRotation rotation;

    // Methods
    private void Awake()
    {
        rotation = GetComponent<WarriorRotation>();
    }

    private void Start()
    {
        if(!isLocalPlayer)
          return;
        rotation.Initialize();
    }

    private void Update()
    {
        if(!isLocalPlayer)
          return;
        rotation.GetInputRotation();
    }

    private void FixedUpdate()
    {
        if(!isLocalPlayer)
          return;
        rotation.Rotate();
    }
}
