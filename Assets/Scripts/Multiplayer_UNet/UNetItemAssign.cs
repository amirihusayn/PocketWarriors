using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace PocketWarriors
{
    public class ItemMessage : MessageBase
    {
        public short PlayerID;
        public short ConnectionID;
        public int index;
        public ItemContainer.ItemTypes ItemType;
    }

    public class UNetItemAssign : NetworkBehaviour, IItemAssign
    {
        // Fields________________________________________________________
        public NetworkConnection Connection;
        [SerializeField] private List<ItemContainer> ContainersList;
        private List<ItemAnchor> anchorsList;
        private Dictionary<ItemContainer.ItemTypes, ItemContainer> containersDic;
        private Dictionary<ItemContainer.ItemTypes, ItemAnchor> anchorsDic;

        // Properties___________________________________________________
        public Dictionary<ItemContainer.ItemTypes, ItemContainer> ContainersDic { get => containersDic; }
        public Dictionary<ItemContainer.ItemTypes, ItemAnchor> AnchorsDic { get => anchorsDic; }

        // Methods_____________________________________________________
        private void Awake()
        {
            Initialize();
            AssignItems();
        }

        public void Initialize()
        {
            anchorsList = new List<ItemAnchor>(GetComponentsInChildren<ItemAnchor>());
            containersDic = new Dictionary<ItemContainer.ItemTypes, ItemContainer>();
            anchorsDic = new Dictionary<ItemContainer.ItemTypes, ItemAnchor>();
            foreach (ItemContainer container in ContainersList)
                containersDic.Add(container.ItemType, container);
            foreach (ItemAnchor anchor in anchorsList)
                anchorsDic.Add(anchor.ItemType, anchor);
        }

        public void RegisterConnection()
        {
            NetworkServer.RegisterHandler((short)1002, OnIndexMessageRecievedInServer);
            Connection.RegisterHandler((short)1003, OnIndexMessageRecievedInClient);
        }

        public void AssignItems()
        {
            int itemIndex;
            foreach(ItemContainer.ItemTypes itemType in ContainersDic.Keys)
            {
                if (PlayerPrefs.HasKey(itemType.ToString()))
                    itemIndex = PlayerPrefs.GetInt(itemType.ToString());
                else
                {
                    itemIndex = 0;
                    PlayerPrefs.SetInt(itemType.ToString(), itemIndex);
                }
                GameObject targetPrefab = containersDic[itemType].GetItem(ref itemIndex);
                anchorsDic[itemType].CreateItem(targetPrefab);
            }
        }

        public void SendItemsToPlayer(short playerID, short connectionID)
        {
            if(!isLocalPlayer)
                return;
            int itemIndex;
            foreach(ItemContainer.ItemTypes itemType in ContainersDic.Keys)
            {
                if (PlayerPrefs.HasKey(itemType.ToString()))
                    itemIndex = PlayerPrefs.GetInt(itemType.ToString());
                else
                {
                    itemIndex = 0;
                    PlayerPrefs.SetInt(itemType.ToString(), itemIndex);
                } 
                ItemMessage message = new ItemMessage();
                message.index = (short)itemIndex;
                message.ItemType = itemType;
                message.PlayerID = playerID;
                message.ConnectionID = connectionID;
                Connection.Send(1002, message);
            }
        }

        public void SendItemsToAll(short playerID)
        {
            SendItemsToPlayer(playerID, -1);
        }

        private void OnIndexMessageRecievedInServer(NetworkMessage message)
        {
            ItemMessage itemMessage = message.ReadMessage<ItemMessage>();
            if(itemMessage.ConnectionID == -1)
                NetworkServer.SendToAll(1003, itemMessage);
            else
                NetworkServer.SendToClient(itemMessage.ConnectionID, 1003, itemMessage);
            GameObject warrior = Connection.playerControllers[itemMessage.PlayerID].gameObject;
            UNetItemAssign itemAssign = warrior.GetComponent<UNetItemAssign>();
            GameObject targetPrefab = itemAssign.containersDic[itemMessage.ItemType].GetItem(ref itemMessage.index);
            itemAssign.anchorsDic[itemMessage.ItemType].CreateItem(targetPrefab);
        }

        private void OnIndexMessageRecievedInClient(NetworkMessage message)
        {
            ItemMessage itemMessage = message.ReadMessage<ItemMessage>();
            GameObject warrior = Connection.playerControllers[itemMessage.PlayerID].gameObject;
            UNetItemAssign itemAssign = warrior.GetComponent<UNetItemAssign>();
            GameObject targetPrefab = itemAssign.containersDic[itemMessage.ItemType].GetItem(ref itemMessage.index);
            itemAssign.anchorsDic[itemMessage.ItemType].CreateItem(targetPrefab);
        }
    }
}