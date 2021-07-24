﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace PocketWarriors
{
    [RequireComponent(typeof(WarriorRotation))]
    public class UNetWarriorRotation : NetworkBehaviour
    {
        // Fields________________________________________________________
        private WarriorRotation rotation;

        // Methods_____________________________________________________
        private void Awake()
        {
            rotation = GetComponent<WarriorRotation>();
        }

        private void Start()
        {
            if (!isLocalPlayer)
                return;
            rotation.Initialize();
        }

        private void Update()
        {
            if (!isLocalPlayer)
                return;
            rotation.GetInputRotation();
        }

        private void FixedUpdate()
        {
            if (!isLocalPlayer)
                return;
            rotation.Rotate();
        }
    }
}
