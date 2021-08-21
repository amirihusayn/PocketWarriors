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
        public string MyServerAddress;
        public int MyServerPort;

        // Methods_____________________________________________________
        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            base.OnServerAddPlayer(conn, playerControllerId);
            
            GameObject warrior = conn.playerControllers[playerControllerId].gameObject;
            UNetItemAssign itemAssign = warrior.GetComponent<UNetItemAssign>();

            itemAssign.Connection = conn;
            itemAssign.RegisterConnection();
            itemAssign.Initialize();
            itemAssign.AssignItems();
            itemAssign.SendItemsToAll(playerControllerId);

            foreach(NetworkConnection connection in NetworkServer.connections)
                if(connection != conn)
                    foreach(PlayerController controller in connection.playerControllers)
                        controller.gameObject.GetComponent<UNetItemAssign>().SendItemsToPlayer(playerControllerId, (short)conn.connectionId);
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

        public void SetItemMessageServer(string address)
        {
            string [] segments = address.Split(':');
            address = segments[3];
            Debug.Log("ServerSet:     "  + address);
            NetworkServer.Listen(address, 4445);
            MyServerAddress = address;
            MyServerPort = 4445;
        }
    }
}
