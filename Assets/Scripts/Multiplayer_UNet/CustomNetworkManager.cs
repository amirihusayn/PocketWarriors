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
        // Fields________________________________________________________
        private List<UNetItemAssign> itemAssignList = new List<UNetItemAssign>();

        // Methods_____________________________________________________
        public override void OnClientDisconnect(NetworkConnection conn)
        {
            base.OnClientDisconnect(conn);
            ResetCursorState();
        }

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            base.OnServerAddPlayer(conn, playerControllerId);

            GameObject warrior = conn.playerControllers[playerControllerId].gameObject;
            UNetItemAssign itemAssign = warrior.GetComponent<UNetItemAssign>();
            itemAssignList.Add(itemAssign);

            itemAssign.Initialize();
            itemAssign.AssignItems();

            // foreach(NetworkConnection connection in NetworkServer.connections)
            // {
            //     foreach(PlayerController controller in connection.playerControllers)
            //     {
            //         controller.gameObject.GetComponent<UNetItemAssign>().LocalAssign(controller.gameObject.GetComponent<UNetItemAssign>().LeftHandItemIndex);
            //     }
            // }
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
            ResetCursorState();
        }

        public void StartClient()
        {
            base.StartClient();
        }

        public override void OnStartClient(NetworkClient client)
        {
            base.OnStartClient(client);
        }

        public override void OnStartHost()
        {
            base.OnStartHost();
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
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
