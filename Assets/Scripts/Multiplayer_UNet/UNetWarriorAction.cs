using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(WarriorAction))]
public class UNetWarriorAction : NetworkBehaviour
{
    // Fields________________________________________________________
    private WarriorAction action;
    
    // Methods_____________________________________________________
    private void Awake()
    {
        action = GetComponent<WarriorAction>();
    }

    private void Start()
    {
        if(!isLocalPlayer)
            return;
        action.Initialize();
    }

    private void Update()
    {
        if(!isLocalPlayer)
            return;
        action.Check();        
    }

    private void FixedUpdate()
    {
        if(!isLocalPlayer)
            return;
        action.Perform();  
    }

    [Command]
    private void CmdCreateProjectile()
    {
        if(!isLocalPlayer)
            return;
        action.CreateProjectile();
        // NetworkServer.Spawn()
    }
}