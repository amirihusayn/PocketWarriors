using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

namespace PocketWarriors
{
    public class ItemMessage : MessageBase
    {

        // Fields________________________________________________________
        public short itemTypeNumber;
        public short itemIndex;
        public short playerControllerId;
    }

    public class UNetItemAssign : NetworkBehaviour, IItemAssign
    {
        // Fields________________________________________________________
        [SerializeField] private List<ItemContainer> ContainersList;
        private List<ItemAnchor> anchorsList;
        private Dictionary<ItemContainer.ItemTypes, ItemContainer> containersDic;
        private Dictionary<ItemContainer.ItemTypes, ItemAnchor> anchorsDic;
        

        [SyncVar(hook = "OnLeftHandItemIndexChange")] private int leftHandItemIndex;
        public int LeftHandItemIndex { get => leftHandItemIndex;}



        // Properties___________________________________________________
        public Dictionary<ItemContainer.ItemTypes, ItemContainer> ContainersDic { get => containersDic; }
        public Dictionary<ItemContainer.ItemTypes, ItemAnchor> AnchorsDic { get => anchorsDic; }

        // Methods_____________________________________________________
        private void Awake()
        {
            Initialize();
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

        public void AssignItems()
        {
            if(!isLocalPlayer)
                return;

            int itemIndex;
            if (PlayerPrefs.HasKey(ItemContainer.ItemTypes.LeftHand.ToString()))
                itemIndex = PlayerPrefs.GetInt(ItemContainer.ItemTypes.LeftHand.ToString());
            else
            {
                itemIndex = 0;
                PlayerPrefs.SetInt(ItemContainer.ItemTypes.LeftHand.ToString(), itemIndex);
            } 
            CmdAssign(itemIndex);
        }

        [Command]
        private void CmdAssign(int newIndex)
        {
            leftHandItemIndex = newIndex;
            RpcAssign(newIndex);
        }

        [ClientRpc]
        public void RpcAssign(int newIndex)
        {
            GameObject targetPrefab = containersDic[ItemContainer.ItemTypes.LeftHand].GetItem(ref newIndex);
            anchorsDic[ItemContainer.ItemTypes.LeftHand].CreateItem(targetPrefab);
        }

        private void OnLeftHandItemIndexChange(int newIndex)
        {
            GameObject targetPrefab = containersDic[ItemContainer.ItemTypes.LeftHand].GetItem(ref newIndex);
            anchorsDic[ItemContainer.ItemTypes.LeftHand].CreateItem(targetPrefab);
        }
    }
}