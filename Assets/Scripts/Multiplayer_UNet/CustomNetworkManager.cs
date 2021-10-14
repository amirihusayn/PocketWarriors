using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

namespace PocketWarriors
{
    public class CustomNetworkManager : NetworkManager
    {
        public override void OnClientDisconnect(NetworkConnection conn)
        {
            base.OnClientDisconnect(conn);
            ResetCursorState();
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
            ResetCursorState();
        }

        public override void OnStopClient()
        {
            base.OnStopClient();
            ResetCursorState();
        }

        public override void OnStopHost()
        {
            base.OnStopHost();
            ResetCursorState();
        }

        public override void OnStopServer()
        {
            base.OnStopServer();
            ResetCursorState();
        }

        private void ResetCursorState()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public override NetworkClient StartHost()
        {
            return base.StartHost();
        }
    }
}
