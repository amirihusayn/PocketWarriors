using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    void Start()
    {
        GameObject go;
        // Sprite s = new Sprite();
    }
    public override void OnStartLocalPlayer()
    {
        // Client Authority:
        // if(!isLocalPlayer)
        // [Command]
        /// NetworkServer.Spawn() for other spawning objects. (After Instantiate)

        // Server Authority:
        // syncs are on the server ! when u modity sync variable be sure it is changing in server
            // if(!isServer)
        // declaring callback for changing sync variable :
            // [SyncVar(hook="methodName")]
        
        // a method that excutes from server to clients :
        // [ClientRPC]
            // isLocalPlayer
    }
    void Update()
    {
    }
}
